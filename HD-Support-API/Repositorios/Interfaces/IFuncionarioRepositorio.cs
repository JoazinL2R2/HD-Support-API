using HD_Support_API.Models;

namespace HD_Support_API.Repositorios.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<List<Funcionarios>> ListarFuncionario();
        Task<Funcionarios> BuscarFuncionario(string nome,string telefone);
        Task<Funcionarios> BuscarFuncionarioPorID(int id);
        Task<Funcionarios> AdicionarFuncionario(Funcionarios funcionarios);
        Task<Funcionarios> AtualizarFuncionario(Funcionarios funcionarios, int id);
        Task<bool> ExcluirFuncionario(int id);
    }
}
