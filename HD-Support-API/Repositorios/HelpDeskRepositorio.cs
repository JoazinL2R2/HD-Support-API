using HD_Support_API.Components;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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
            return await _contexto.HelpDesk.FirstOrDefaultAsync(
                x => x.Nome == nome);
        }

        public async Task<HelpDesk> BuscarHelpDeskPorID(int id)
        {
            return await _contexto.HelpDesk.FirstOrDefaultAsync(
                x => x.Id == id);
        }

        public async Task<bool> ExcluirHelpDesk(int id)
        {
            HelpDesk HelpDeskPorId = await BuscarHelpDeskPorID(id);

            if (BuscarHelpDeskPorID == null)
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
    }
}
