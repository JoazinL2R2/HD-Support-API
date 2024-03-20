using HD_Support_API.Components;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HD_Support_API.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly BancoContext _contexto;
        public FuncionarioRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Funcionarios> AdicionarFuncionario(Funcionarios funcionarios)
        {
            var verificar =  _contexto.Funcionario.FirstOrDefault(x => x.Email == funcionarios.Email);
            if(verificar == null)
            {
                await _contexto.Funcionario.AddAsync(funcionarios);
                _contexto.SaveChanges();
                return funcionarios;
            }
            throw new Exception("Email já cadastrado, tente novamente.");

        }

        public async Task<Funcionarios> AtualizarFuncionario(Funcionarios funcionarios, int id)
        {
            Funcionarios FuncionariosPorID = await BuscarFuncionarioPorID(id);

            if (FuncionariosPorID == null)
            {
                throw new Exception($"Funcionario de Id:{id} não encontrado na base de dados.");
            }
            var verificar =  _contexto.Funcionario.FirstOrDefault(x => x.Email == funcionarios.Email);
            if(verificar == null)
            {
                FuncionariosPorID.Nome = funcionarios.Nome;
                FuncionariosPorID.Email = funcionarios.Email;
                FuncionariosPorID.Telefone = funcionarios.Telefone;
                FuncionariosPorID.Telegram = funcionarios.Telegram;
                FuncionariosPorID.Categoria = funcionarios.Categoria;
                FuncionariosPorID.StatusFuncionario = funcionarios.StatusFuncionario;

                _contexto.Funcionario.Update(FuncionariosPorID);
                await _contexto.SaveChangesAsync();

                return FuncionariosPorID;
            }
            throw new Exception($"Email já cadastrado, tente novamente.");
        }

        public async Task<Funcionarios> BuscarFuncionario(string nome, string telefone)
        {
            var busca =  await _contexto.Funcionario.FirstOrDefaultAsync(
            x => x.Nome == nome
            || x.Telefone == telefone);
            if(busca == null)
            {
                throw new Exception("Funcionario não encontrado");
            }
            return busca;
        }

        public async Task<Funcionarios> BuscarFuncionarioPorID(int id)
        {
            var busca =  await _contexto.Funcionario.FirstOrDefaultAsync(
                x => x.Id == id);
            if(busca == null)
            {
                throw new Exception($"Funcionario com o Id:{id} não encontrado");
            }
            return busca;
        }

        public async Task<bool> ExcluirFuncionario(int id)
        {
            Funcionarios FuncionarioPorId = await BuscarFuncionarioPorID(id);

            if (FuncionarioPorId == null)
            {
                throw new Exception($"Funcionario de Id:{id} não encontrado na base de dados.");
            }
            _contexto.Remove(FuncionarioPorId);
            await _contexto.SaveChangesAsync();

            return true;
        }

        public async Task<List<Funcionarios>> ListarFuncionario()
        {
            var lista =  await _contexto.Funcionario.ToListAsync();
            if(lista == null)
            {
                throw new Exception($"Nenhum funcionario registrado em nossa base de dados.");
            }
            return lista;
        }
    }
}
