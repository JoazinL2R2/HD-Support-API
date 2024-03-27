using EncryptionDecryptionUsingSymmetricKey;
using HD_Support_API.Components;
using HD_Support_API.Enums;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD_Support_API.Repositorios
{
    public class HelpDeskRepositorio : IHelpDeskRepositorio
    {
        private readonly BancoContext _contexto;

        public HelpDeskRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<HelpDesk> AdicionarHelpDesk(HelpDesk helpDesk)
        {
            helpDesk.Senha = AesOperation.CriarHash(helpDesk.Senha);
            await _contexto.HelpDesk.AddAsync(helpDesk);
            await _contexto.SaveChangesAsync();
            return helpDesk;
        }

        public async Task<HelpDesk> AtualizarHelpDesk(HelpDesk helpDesk, int id)
        {
            HelpDesk buscarId = await BuscarHelpDeskPorID(id);

            if (buscarId == null)
            {
                throw new Exception($"HelpDesk de Id:{id} não encontrado na base de dados.");
            }

            buscarId.Senha = helpDesk.Senha;
            buscarId.Nome = helpDesk.Nome;
            buscarId.Email = helpDesk.Email;

            _contexto.HelpDesk.Update(buscarId);
            await _contexto.SaveChangesAsync();

            return buscarId;
        }

        public async Task<HelpDesk> BuscarHelpDesk(string nome)
        {
            var busca = await _contexto.HelpDesk.FirstOrDefaultAsync(x => x.Nome == nome);
            if (busca != null)
            {
                return busca;
            }
            throw new Exception("Nome não encontrado.");
        }

        public async Task<HelpDesk> BuscarHelpDeskPorID(int id)
        {
            var busca = await _contexto.HelpDesk.FirstOrDefaultAsync(x => x.Id == id);
            if (busca == null)
            {
                throw new Exception("ID não encontrado.");
            }
            return busca;
        }


        public async Task<bool> ExcluirHelpDesk(int id)
        {
            HelpDesk HelpDeskPorId = await BuscarHelpDeskPorID(id);

            if (HelpDeskPorId == null)
            {
                throw new Exception($"HelpDesk de Id:{id} não encontrado na base de dados.");
            }

            _contexto.Remove(HelpDeskPorId);
            await _contexto.SaveChangesAsync();

            return true;
        }

        public async Task<List<HelpDesk>> ListarHelpDesk()
        {
            return await _contexto.HelpDesk.ToListAsync();
        }

        public async Task<HelpDesk> Login(string email, string senha)
        {
            var tentativaLogin = await _contexto.HelpDesk.FirstOrDefaultAsync(x => x.Email == email && x.Senha == AesOperation.CriarHash(senha));
            if (tentativaLogin!=null)
            {
                return tentativaLogin;
            }
            throw new Exception("Email ou senha incorretos.");
        }

        public async Task<bool> AtualizarStatus(int id, int status)
        {
            var busca = await _contexto.HelpDesk.FirstOrDefaultAsync(x => x.Id == id);
            if (busca == null)
            {
                throw new Exception("ID não encontrado.");
            }
            StatusHelpDeskConversa statusConversa = (StatusHelpDeskConversa)status;
            busca.StatusConversa = statusConversa;
            _contexto.HelpDesk.Update(busca);
            await _contexto.HelpDesk.ToListAsync();
            return true;
        }
    }
}
