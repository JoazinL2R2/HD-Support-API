using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> ListarHelpDesk()
        {
            var ListaHelpDesk = await _repositorio.ListarHelpDesk();
            return Ok(ListaHelpDesk);
        }

    }
}
