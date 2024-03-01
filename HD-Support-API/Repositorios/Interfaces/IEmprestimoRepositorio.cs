using HD_Support_API.Models;

namespace HD_Support_API.Repositorios.Interfaces
{
    public interface IEmprestimoRepositorio
    {
        Task<List<Emprestimos>> ListarEmprestimos();
        Task<Emprestimos> BuscarEmprestimos(int idPatrimonio, string nome);
        Task<Emprestimos> AdicionarEmprestimo(Emprestimos emprestimo);
        Task<Emprestimos> AtualizarEmprestimo(Emprestimos emprestimo, int id);
        Task<bool> ExcluirEmprestimo(int id);
    }
}
