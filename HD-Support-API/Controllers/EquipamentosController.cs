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
        [Route("Lista-Equipamentos")]
        public async Task<IActionResult> ListarEquipamentos()
        {
            var ListaHelpDesk = await _repositorio.ListarEquipamentos();
            return Ok(ListaHelpDesk);
        }

        [HttpPost]
        [Route("Registro-HelpDesk")]
        public async Task<IActionResult> AdicionarHelpDesk([FromBody] Equipamentos equipamentos)
        {
            if (equipamentos == null)
            {
                return BadRequest("Dados do HelpDesk não fornecidos");
            }

            var equipamentoAdicionado = await _repositorio.AdicionarEquipamento(equipamentos);

            return Ok(equipamentoAdicionado);
        }

        [HttpPut]
        [Route("Editar-Maquina/{id}")]
        public async Task<IActionResult> AtualizarHelpDesk(int id, [FromBody] Equipamentos equipamentos)
        {
            if (equipamentos == null)
            {
                return BadRequest($"Cadastro com ID:{id} não encontrado");
            }

            var atualizarEquipamento = await _repositorio.AtualizarEquipamento(equipamentos, id);
            return Ok(atualizarEquipamento);
        }

        [HttpGet]
        [Route("Buscar-HelpDesk-Por-ID/{id}")]
        public async Task<IActionResult> BuscarEquipamentosPorId(int id)
        {
            var busca = await _repositorio.BuscarEquipamentosPorId(id);

            if (busca == null)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(busca);
        }

        [HttpPost]
        [Route("Excluir-Perfil/{id}")]
        public async Task<IActionResult> ExcluirEquipamento(int id)
        {
            var excluirMaquina = await _repositorio.ExcluirEquipamento(id);

            if (excluirMaquina == null)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(excluirMaquina);
        }
    }
}

