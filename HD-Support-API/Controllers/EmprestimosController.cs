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
        [Route("Listar-Emprestimos")]
        public async Task<IActionResult> ListarEmprestimos()
        {
            var ListarEmprestimos = await _repositorio.ListarEmprestimos();
            return Ok(ListarEmprestimos);
        }

        [HttpPost]
        [Route("Buscar-Emprestimos")]
        public async Task<IActionResult> AdicionarEmprestimo([FromBody] Emprestimos emprestimo)
        {
            if (emprestimo == null)
            {
                return BadRequest("Dados de Emprestimo não fornecidos");
            }

            var emprestimoAdicionado = await _repositorio.AdicionarEmprestimo(emprestimo);

            return Ok(emprestimoAdicionado);
        }

        [HttpPut]
        [Route("Editar-Emprestimo/{id}")]
        public async Task<IActionResult> AtualizarEmprestimo(int id, [FromBody] Emprestimos emprestimos)
        {
            if (emprestimos == null)
            {
                return BadRequest($"Cadastro com ID:{id} não encontrado");
            }

            var AtualizarEmprestimo = await _repositorio.AtualizarEmprestimo(emprestimos, id);
            return Ok(AtualizarEmprestimo);
        }

        [HttpGet]
        [Route("Buscar-Emprestimo-Por-ID/{id}")]
        public async Task<IActionResult> BuscarEmprestimosPorID(int id)
        {
            var BuscarEmprestimos = await _repositorio.BuscarEmprestimosPorID(id);

            if (BuscarEmprestimos == null)
            {
                return NotFound($"Emprestimo com ID:{id} não encontrado");
            }

            return Ok(BuscarEmprestimos);
        }

        [HttpPost]
        [Route("Excluir-Emprestimo/{id}")]
        public async Task<IActionResult> ExcluirEmprestimo(int id)
        {
            var ExcluirEmprestimo = await _repositorio.ExcluirEmprestimo(id);

            if (ExcluirEmprestimo == null)
            {
                return NotFound($"Emprestimo com ID:{id} não encontrado");
            }

            return Ok(ExcluirEmprestimo);
        }
    }
}
