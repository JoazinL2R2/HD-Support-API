using HD_Support_API.Models;

namespace HD_Support_API.Repositorios.Interfaces
{
    public interface IHelpDeskRepositorio
    {
        Task<List<HelpDesk>> ListarHelpDesk();
        Task<HelpDesk> BuscarHelpDesk(int nome);
        Task<HelpDesk> AdicionarHelpDesk(HelpDesk helpDesk);
        Task<HelpDesk> AtualizarHelpDesk(HelpDesk helpDesk, int id);
        Task<bool> ExcluirHelpDesk(int id);
    }
}
