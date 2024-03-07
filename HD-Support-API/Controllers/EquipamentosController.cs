using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HD_Support_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly IEquipamentosRepositorio _repositorio;

        public EquipamentosController(IEquipamentosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("Listar-Equipamentos")]
        public async Task<IActionResult> ListarEquipamentos()
        {
            var ListarEquipamentos = await _repositorio.ListarEquipamentos();
            return Ok(ListarEquipamentos);
        }

        [HttpPost]
        [Route("Buscar-Equipamentos")]
        public async Task<IActionResult> AdicionarEquipamento([FromBody] Equipamentos equipamentos)
        {
            if (equipamentos == null)
            {
                return BadRequest("Dados do Equipamento não fornecidos");
            }

            var equipamentoAdicionado = await _repositorio.AdicionarEquipamento(equipamentos);

            return Ok(equipamentoAdicionado);
        }

        [HttpPut]
        [Route("Editar-Equipamento/{id}")]
        public async Task<IActionResult> AtualizarEquipamento(int id, [FromBody] Equipamentos equipamentos)
        {
            if (equipamentos == null)
            {
                return BadRequest($"Equipamento com ID:{id} não encontrado");
            }

            var AtualizarEquipamento = await _repositorio.AtualizarEquipamento(equipamentos, id);
            return Ok(AtualizarEquipamento);
        }

        [HttpGet]
        [Route("Buscar-Equipamento-Por-ID/{id}")]
        public async Task<IActionResult> BuscarEquipamentos(int id)
        {
            var buscarEquipamentos = await _repositorio.BuscarEquipamentos(id);

            if (buscarEquipamentos == null)
            {
                return NotFound($"Equipamento com ID:{id} não encontrado");
            }

            return Ok(buscarEquipamentos);
        }

        [HttpPost]
        [Route("Excluir-Equipamento/{id}")]
        public async Task<IActionResult> ExcluirEquipamento(int id)
        {
            var excluirEmprestimo = await _repositorio.ExcluirEquipamento(id);

            if (excluirEmprestimo == null)
            {
                return NotFound($"Equipamento com ID:{id} não encontrado");
            }

            return Ok(excluirEmprestimo);
        }
    }
}