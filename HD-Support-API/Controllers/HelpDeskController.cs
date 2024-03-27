using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD_Support_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpDeskController : ControllerBase
    {
        private readonly IHelpDeskRepositorio _repositorio;

        public HelpDeskController(IHelpDeskRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("Lista-HelpDesk")]
        public async Task<IActionResult> ListarHelpDesk()
        {
            var ListaHelpDesk = await _repositorio.ListarHelpDesk();
            return Ok(ListaHelpDesk);
        }

        [HttpPost]
        [Route("Registro-HelpDesk")]
        public async Task<IActionResult> AdicionarHelpDesk([FromBody] HelpDesk helpDesk)
        {
            if (helpDesk == null)
            {
                return BadRequest("Dados do HelpDesk não fornecidos");
            }

            var helpDeskAdicionado = await _repositorio.AdicionarHelpDesk(helpDesk);

            return Ok(helpDeskAdicionado);
        }

        [HttpPut]
        [Route("Editar-Perfil-HelpDesk/{id}")]
        public async Task<IActionResult> AtualizarHelpDesk(int id, [FromBody] HelpDesk helpDesk)
        {
            if (helpDesk == null)
            {
                return BadRequest($"Cadastro com ID:{id} não encontrado");
            }

            var AtualizarHelpDesk = await _repositorio.AtualizarHelpDesk(helpDesk, id);
            return Ok(AtualizarHelpDesk);
        }

        [HttpGet]
        [Route("Buscar-HelpDesk-Por-ID/{id}")]
        public async Task<IActionResult> BuscarHelpDeskPorID(int id)
        {
            var buscarHelpDesk = await _repositorio.BuscarHelpDeskPorID(id);

            if (buscarHelpDesk == null)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(buscarHelpDesk);
        }

        [HttpPost]
        [Route("Excluir-Perfil/{id}")]
        public async Task<IActionResult> ExcluirHelpDesk(int id)
        {
            var ExcluirPerfil = await _repositorio.ExcluirHelpDesk(id);

            if (ExcluirPerfil == null)
            {
                return NotFound($"Cadastro com ID:{id} não encontrado");
            }

            return Ok(ExcluirPerfil);
        }

        [HttpPost]
        [Route("Login-HelpDesk")]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var result = await _repositorio.Login(email, senha);

            return Ok(result);
        }

        [HttpPut]
        [Route("Atualizar-Status-HelpDesk/{id}")]
        public async Task<IActionResult> AtualizarHelpDesk(int id, int status)
        {
            var result = await _repositorio.AtualizarStatus(id, status);

            return Ok(result);
        }
    }
}
