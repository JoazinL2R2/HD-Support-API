using HD_Support_API.Components;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;

namespace HD_Support_API.Repositorios
{
    public class HelpDeskRepositorio : IHelpDeskRepositorio
    {
        private readonly BancoContext _contexto;
        public HelpDeskRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public Task<HelpDesk> AdicionarHelpDesk(HelpDesk helpDesk)
        {
            throw new NotImplementedException();
        }

        public Task<HelpDesk> AtualizarHelpDesk(HelpDesk helpDesk, int id)
        {
            throw new NotImplementedException();
        }

        public Task<HelpDesk> BuscarHelpDesk(int nome)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirHelpDesk(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<HelpDesk>> ListarHelpDesk()
        {
            throw new NotImplementedException();
        }
    }
}
