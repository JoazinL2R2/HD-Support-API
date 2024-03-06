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
            _contexto.Emprestimo.AddAsync(emprestimo);
            _contexto.SaveChangesAsync();
            return emprestimo;
        }

        public async Task<Emprestimos> AtualizarEmprestimo(Emprestimos emprestimo, int id)
        {
            Emprestimos emprestimosPorId = await BuscarEmprestimosPorID(id);

            if (emprestimosPorId == null)
            {
                throw new Exception($"Equipamento de Id:{id} não encontrado na base de dados.");
            }
            emprestimosPorId.Equipamento = emprestimo.Equipamento;
            emprestimosPorId.Funcionario = emprestimo.Funcionario;

            _contexto.Emprestimo.Update(emprestimosPorId);
            await _contexto.SaveChangesAsync();

            return emprestimosPorId;
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
            Emprestimos emprestimoPorId = await BuscarEmprestimosPorID(id);

            if (emprestimoPorId == null)
            {
                throw new Exception($"Emprestimo de Id:{id} não encontrado na base de dados.");
            }
            _contexto.Remove(emprestimoPorId);
            await _contexto.SaveChangesAsync();

            return true;
        }

        public async Task<List<Emprestimos>> ListarEmprestimos()
        {
            return await _contexto.Emprestimo.ToListAsync();
        }
    }
}
