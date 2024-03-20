using HD_Support_API.Components;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HD_Support_API.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly BancoContext _contexto;
        public EmprestimoRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Emprestimos> AdicionarEmprestimo(Emprestimos emprestimo)
        {
            var verificarEquipamento = _contexto.Emprestimo.FirstOrDefault(x => x.Equipamento.IdPatrimonio == emprestimo.Equipamento.IdPatrimonio);
            var verificarFuncionario = _contexto.Emprestimo.FirstOrDefault(x => x.Funcionario.Id == emprestimo.Funcionario.Id);
            if(verificarEquipamento == null && verificarFuncionario == null)
            {
                await _contexto.Emprestimo.AddAsync(emprestimo);
                _contexto.SaveChangesAsync();
                return emprestimo;
            }
            throw new Exception("Equipamento em emprestimo ou funcionario já possui um emprestimo.");
           
            
        }

        public async Task<Emprestimos> AtualizarEmprestimo(Emprestimos emprestimo, int id)
        {
            var busca = await BuscarEmprestimosPorID(id);
            var verificarEquipamento = _contexto.Emprestimo.FirstOrDefault(x => x.Equipamento.IdPatrimonio == emprestimo.Equipamento.IdPatrimonio);
            var verificarFuncionario = _contexto.Emprestimo.FirstOrDefault(x => x.Funcionario.Email == emprestimo.Funcionario.Email);
            if (busca == null)
            {
                throw new Exception($"Equipamento de Id:{emprestimo.Id} não encontrado na base de dados.");
            }
            if(verificarEquipamento == null && verificarFuncionario == null)
            {
                busca.Equipamento = emprestimo.Equipamento;
                busca.Funcionario = emprestimo.Funcionario;

                _contexto.Emprestimo.Update(busca);
                await _contexto.SaveChangesAsync();

                return busca;
            }
            if(verificarEquipamento != null || verificarFuncionario != null)
            {
                if (verificarEquipamento != null && verificarFuncionario == null)
                {
                    throw new Exception($"Não foi possivel atualizar o emprestimo, pois o equipamento de Id:{emprestimo.Equipamento.IdPatrimonio}. Já existe um emprestimo ultilizando o mesmo Id.");
                }
                if (verificarFuncionario != null && verificarEquipamento == null)
                {
                    throw new Exception($"Não foi possivel atualizar o emprestimo, pois o funcionario de E-mail:{emprestimo.Funcionario.Email}. Já existe um emprestimo cadastrado neste e-mail.");
                }
                
            }
            throw new Exception($"Não foi possivel atualizar o emprestimo");
        }

        public async Task<Emprestimos> BuscarEmprestimos(int idPatrimonio, string nome)
        {
            return _contexto.Emprestimo.FirstOrDefault(
                x => x.Equipamento.IdPatrimonio == idPatrimonio ||
                x.Funcionario.Nome == nome);
        }

        public async Task<Emprestimos> BuscarEmprestimosPorID(int id)
        {
            return _contexto.Emprestimo.FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> ExcluirEmprestimo(int id)
        {
            var buscar = await BuscarEmprestimosPorID(id);

            if (buscar == null)
            {
                throw new Exception($"Emprestimo de Id:{id} não encontrado na base de dados.");
            }
            _contexto.Remove(buscar);
            await _contexto.SaveChangesAsync();

            return true;
        }

        public async Task<List<Emprestimos>> ListarEmprestimos()
        {
            var lista =  await _contexto.Emprestimo.ToListAsync();
            if(lista == null)
            {
                throw new Exception("Ainda não temos nenhum emprestimo registrado");
            }
            return await _contexto.Emprestimo.ToListAsync();
        }
    }
}
