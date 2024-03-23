using HD_Support_API.Components;
using HD_Support_API.Enums;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD_Support_API.Repositorios
{
    public class HelpDeskRepositorio : IHelpDeskRepositorio
    {
        private readonly BancoContext _contexto;
        private readonly IEmailSender _SendEmailRepository;

        public HelpDeskRepositorio(BancoContext contexto, IEmailSender sendEmailRepository)
        {
            _contexto = contexto;
            _SendEmailRepository = sendEmailRepository;
        }

        public async Task<HelpDesk> AdicionarHelpDesk(HelpDesk helpDesk)
        {
            _contexto.HelpDesk.AddAsync(helpDesk);
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
            return await _contexto.HelpDesk.FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task<HelpDesk> BuscarHelpDeskPorID(int id)
        {
            HelpDesk helpDesk = await _contexto.HelpDesk.FirstOrDefaultAsync(x => x.Id == id);
            if (helpDesk == null)
            {
                throw new Exception("ID não encontrado.");
            }
            return helpDesk;
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
            var busca = await _contexto.HelpDesk.FirstOrDefaultAsync(x => x.Email == email && x.Senha == senha);
            if (busca != null)
            {
                return busca;
            }
            throw new Exception("Login invalido");
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

        public async Task RecuperarSenha(string email)
        {
            int? idHelpDesk = await BuscarHelpDeskPorEmail(email);

            if (idHelpDesk == null)
            {
                throw new Exception("Nenhum HelpDesk encontrado com o email fornecido.");
            }
            var texto = $"Seu link de redefinição de senha é: https://localhost:7299/api/HelpDesk/Editar-Perfil-HelpDesk/{idHelpDesk}";
            await _SendEmailRepository.SendEmailAsync(email, "Redefinição de senha HD-Support", texto);
        }



        public async Task<int?> BuscarHelpDeskPorEmail(string email)
        {
            if (email == null)
            {
                throw new Exception("Email vazio");
            }

            var idHelpDesk = await _contexto.HelpDesk
                                            .Where(x => x.Email == email)
                                            .Select(x => x.Id)
                                            .FirstOrDefaultAsync();

            if (idHelpDesk == null)
            {
                throw new Exception("Nenhum HelpDesk encontrado com o email fornecido.");
            }

            return idHelpDesk;
        }
    }
}
