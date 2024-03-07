using HD_Support_API.Components;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HD_Support_API.Repositorios
{
    public class EquipamentoRepositorio : IEquipamentosRepositorio
    {
        private readonly BancoContext _contexto;
        public EquipamentoRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Equipamentos> AdicionarEquipamento(Equipamentos equipamento)
        {
            await _contexto.Equipamento.AddAsync(equipamento);
            _contexto.SaveChanges();
            return equipamento;
        }

        public async Task<Equipamentos> AtualizarEquipamento(Equipamentos equipamento, int id)
        {
            Equipamentos equipamentosPorId = await BuscarEquipamentos(id);

            if(equipamentosPorId == null)
            {
                throw new Exception($"Equipamento de Id:{id} não encontrado na base de dados.");
            }
            equipamentosPorId.IdPatrimonio = equipamento.IdPatrimonio;
            equipamentosPorId.Modelo = equipamento.Modelo;
            equipamentosPorId.Processador = equipamento.Processador;
            equipamentosPorId.HeadSet = equipamento.HeadSet;

            _contexto.Equipamento.Update(equipamentosPorId);
            await _contexto.SaveChangesAsync();

            return equipamentosPorId;

        }

        public async Task<Equipamentos> BuscarEquipamentos(int idPatrimonio)
        {
            return _contexto.Equipamento.FirstOrDefault(x => x.IdPatrimonio == idPatrimonio);
        }

        public async Task<bool> ExcluirEquipamento(int id)
        {
            Equipamentos equipamentosPorId = await BuscarEquipamentos(id);

            if (equipamentosPorId == null)
            {
                throw new Exception($"Equipamento de Id:{id} não encontrado na base de dados.");
            }
            _contexto.Remove(equipamentosPorId);
            await _contexto.SaveChangesAsync();

            return true;

        }

        public async Task<List<Equipamentos>> ListarEquipamentos()
        {
            return await _contexto.Equipamento.ToListAsync();
        }
    }
}
