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
            var verificacao = _contexto.Equipamento.FirstOrDefault(x => x.IdPatrimonio == equipamento.IdPatrimonio);
            if(verificacao == null)
            {
                await _contexto.Equipamento.AddAsync(equipamento);
                _contexto.SaveChanges();
                return equipamento;
            }
            throw new Exception($"O patrimônio com Id:{equipamento.IdPatrimonio} já está cadastrado.");
        }

        public async Task<Equipamentos> AtualizarEquipamento(Equipamentos equipamento, int id)
        {
            Equipamentos equipamentosPorId = await BuscarEquipamentosPorId(id);
            var verificacao = _contexto.Equipamento.FirstOrDefault(x => x.IdPatrimonio == equipamento.IdPatrimonio);
            if (equipamentosPorId == null)
            {
                throw new Exception($"Equipamento de Id:{id} não encontrado na base de dados.");
            }
            if(verificacao == null)
            {
                equipamentosPorId.IdPatrimonio = equipamento.IdPatrimonio;
                equipamentosPorId.Modelo = equipamento.Modelo;
                equipamentosPorId.Processador = equipamento.Processador;
                equipamentosPorId.HeadSet = equipamento.HeadSet;

                _contexto.Equipamento.Update(equipamentosPorId);
                await _contexto.SaveChangesAsync();

                return equipamentosPorId;
            }
            throw new Exception($"Equipamento de Id:{id} já cadastrado na base de dados.");

        }

        public async Task<Equipamentos> BuscarEquipamentos(int idPatrimonio)
        {
            return  _contexto.Equipamento.FirstOrDefault(x => x.IdPatrimonio == idPatrimonio);
        }        
        public async Task<Equipamentos> BuscarEquipamentosPorId(int id)
        {
            var busca =  _contexto.Equipamento.FirstOrDefault(x => x.Id == id);
            if(busca == null)
            {
                throw new Exception($"Equipamento com o ID {id} não encontrado");
            }
            return busca;
        }

        public async Task<bool> ExcluirEquipamento(int id)
        {
            var busca = await BuscarEquipamentosPorId(id);

            if (busca == null)
            {
                throw new Exception($"Equipamento de Id:{id} não encontrado na base de dados.");
            }
            _contexto.Remove(busca);
            await _contexto.SaveChangesAsync();

            return true;

        }

        public async Task<List<Equipamentos>> ListarEquipamentos()
        {
            return await _contexto.Equipamento.ToListAsync();
        }
    }
}
