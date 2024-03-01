using HD_Support_API.Components;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;

namespace HD_Support_API.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly BancoContext _contexto;
        public EmprestimoRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public Task<Emprestimos> AdicionarEmprestimo(Emprestimos emprestimo)
        {
            throw new NotImplementedException();
        }

        public Task<Emprestimos> AtualizarEmprestimo(Emprestimos emprestimo, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Emprestimos> BuscarEmprestimos(int idPatrimonio, string nome)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirEmprestimo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Emprestimos>> ListarEmprestimos()
        {
            throw new NotImplementedException();
        }
    }
}
