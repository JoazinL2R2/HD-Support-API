using HD_Support_API.Models;

namespace HD_Support_API.Repositorios.Interfaces
{
    public interface IEquipamentosRepositorio
    {
        Task<List<Equipamentos>> ListarEquipamentos();
        Task<Equipamentos> BuscarEquipamentos(int idPatrimonio);
        Task<Equipamentos> BuscarEquipamentosPorId(int id);
        Task<Equipamentos> AdicionarEquipamento(Equipamentos equipamento);
        Task<Equipamentos> AtualizarEquipamento(Equipamentos equipamento, int id);
        Task<bool> ExcluirEquipamento(int id);
    }
}
