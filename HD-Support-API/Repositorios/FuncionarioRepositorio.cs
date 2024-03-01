using HD_Support_API.Components;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;

namespace HD_Support_API.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly BancoContext _contexto;
        public FuncionarioRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public Task<Funcionarios> AdicionarFuncionario(Funcionarios funcionarios)
        {
            throw new NotImplementedException();
        }

        public Task<Funcionarios> AtualizarFuncionario(Funcionarios funcionarios, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Funcionarios> BuscarFuncionario(int nome, string telefone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirFuncionario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Funcionarios>> ListarFuncionario()
        {
            throw new NotImplementedException();
        }
    }
}
