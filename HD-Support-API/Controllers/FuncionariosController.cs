using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HD_Support_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioRepositorio _repositorio;

        public FuncionariosController(IFuncionarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("Lista-Funcionarios")]
        public async Task<IActionResult> ListarFuncionario()
        {
            var ListaFuncionarios = await _repositorio.ListarFuncionario();
            return Ok(ListaFuncionarios);
        }
        [HttpPost]
        [Route("Registro-Funcionarios")]
        public async Task<IActionResult> AdicionarFuncionario([FromBody] Funcionarios funcionarios)
        {
            if (funcionarios == null)
            {
                return BadRequest("Dados dos funcionarios não fornecidos");
            }

            var funcionariosAdicionados = await _repositorio.AdicionarFuncionario(funcionarios);

            return Ok(funcionariosAdicionados);
        }

        [HttpPut]
        [Route("Editar-Perfil-Funcionario/{id}")]
        public async Task<IActionResult> AtualizarFuncionario(Funcionarios funcionarios, int id)
        {
            if (funcionarios == null)
            {
                return BadRequest($"Cadastro com ID:{id} não encontrado");
            }

            var AtualizarFuncionario = await _repositorio.AtualizarFuncionario(funcionarios, id);
            return Ok(AtualizarFuncionario);
        }

        [HttpGet]
        [Route("Buscar-Funcionario-Por-ID/{id}")]
        public async Task<IActionResult> BuscarFuncionarioPorID(int id)
        {
            var buscarFuncionario = await _repositorio.BuscarFuncionarioPorID(id);

            if (buscarFuncionario == null)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(buscarFuncionario);
        }

        [HttpPost]
        [Route("Excluir-Perfil-Funcionario/{id}")]
        public async Task<IActionResult> ExcluirFuncionario(int id)
        {
            var ExcluirPerfilFuncionario = await _repositorio.ExcluirFuncionario(id);

            if (ExcluirPerfilFuncionario == null)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(ExcluirPerfilFuncionario);
        }

        //ExcluirFuncionario(int id);
        //BuscarFuncionarioPorID(int id);
        //AtualizarFuncionario(Funcionarios funcionarios, int id);
        //AdicionarFuncionario(Funcionarios funcionarios);
    }
}
