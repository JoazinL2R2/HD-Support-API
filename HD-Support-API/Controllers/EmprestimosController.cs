using HD_Support_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HD_Support_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Equipamentos>> ListarTodosEmprestimos()
        {
            return Ok();
        }
    }
}
