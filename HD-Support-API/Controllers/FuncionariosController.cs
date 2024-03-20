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
        public async Task<IActionResult> AdicionarFuncionario([FromBody] Funcionarios funcionario)
        {
            if (funcionario == null)
            {
                return BadRequest("Dados do HelpDesk não fornecidos");
            }

            var helpDeskAdicionado = await _repositorio.AdicionarFuncionario(funcionario);

            return Ok(helpDeskAdicionado);
        }

        [HttpPut]
        [Route("Editar-Perfil-Funcionario/{id}")]
        public async Task<IActionResult> AtualizarFuncionario(int id, [FromBody] Funcionarios funcionario)
        {
            if (funcionario == null)
            {
                return BadRequest($"Cadastro com ID:{id} não encontrado");
            }

            var atualizarFuncionario = await _repositorio.AtualizarFuncionario(funcionario, id);
            return Ok(atualizarFuncionario);
        }

        [HttpGet]
        [Route("Buscar-Funcionario-Por-Id/{id}")]
        public async Task<IActionResult> BuscarFuncionarioPorID(int id)
        {
            var busca = await _repositorio.BuscarFuncionarioPorID(id);

            if (busca == null)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(busca);
        }

        [HttpPost]
        [Route("Excluir-Perfil-Funcionario/{id}")]
        public async Task<IActionResult> ExcluirFuncionario(int id)
        {
            var Excluir = await _repositorio.ExcluirFuncionario(id);

            if (Excluir == false)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(Excluir);
        }
    }
}
