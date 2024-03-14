using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HD_Support_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        private readonly IEmprestimoRepositorio _repositorio;

        public EmprestimosController(IEmprestimoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("Lista-Emprestimos")]
        public async Task<IActionResult> ListarEmprestimos()
        {
            var listaEquipamentos = await _repositorio.ListarEmprestimos();
            return Ok(listaEquipamentos);
        }

        [HttpPost]
        [Route("Registro-Emprestimo")]
        public async Task<IActionResult> AdicionarEmprestimo([FromBody] Emprestimos emprestimo)
        {
            if (emprestimo == null)
            {
                return BadRequest("Dados do HelpDesk não fornecidos");
            }

            var equipamentoAdicionado = await _repositorio.AdicionarEmprestimo(emprestimo);

            return Ok(equipamentoAdicionado);
        }

        [HttpPut]
        [Route("Editar-Emprestimo/{id}")]
        public async Task<IActionResult> AtualizarEmprestimo(int id, [FromBody] Emprestimos emprestimo)
        {
            if (emprestimo == null)
            {
                return BadRequest($"Cadastro com ID:{id} não encontrado");
            }

            var atualizarEmprestimo = await _repositorio.AtualizarEmprestimo(emprestimo, id);
            return Ok(atualizarEmprestimo);
        }

        [HttpGet]
        [Route("Buscar-Emprestimo-Por-Id/{id}")]
        public async Task<IActionResult> BuscarEmprestimosPorID(int id)
        {
            var busca = await _repositorio.BuscarEmprestimosPorID(id);

            if (busca == null)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(busca);
        }

        [HttpPost]
        [Route("Excluir-Emprestimo/{id}")]
        public async Task<IActionResult> ExcluirEmprestimo(int id)
        {
            var Excluir = await _repositorio.ExcluirEmprestimo(id);

            if (Excluir == false)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(Excluir);
        }
    }
}

