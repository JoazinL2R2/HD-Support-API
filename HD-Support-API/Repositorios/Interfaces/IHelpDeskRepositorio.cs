using HD_Support_API.Models;

namespace HD_Support_API.Repositorios.Interfaces
{
    public interface IHelpDeskRepositorio
    {
        Task<List<HelpDesk>> ListarHelpDesk();
        Task<HelpDesk> BuscarHelpDesk(string nome);
        Task<HelpDesk> BuscarHelpDeskPorID(int id);
        Task<HelpDesk> AdicionarHelpDesk(HelpDesk helpDesk);
        Task<HelpDesk> AtualizarHelpDesk(HelpDesk helpDesk, int id);
        Task<bool> ExcluirHelpDesk(int id);
        Task<HelpDesk> Login(string email, string senha);
        Task<bool> AtualizarStatus(int id, int status);
    }
}
