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



        [HttpGet]
        public ActionResult<List<Equipamentos>> ListarEmprestimos()
        {
            return Ok();
        }
    }
}
