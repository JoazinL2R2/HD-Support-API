using HD_Support_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HD_Support_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Equipamentos>> ListarTodosEquipamentos()
        {
            return Ok();
        }
    }
}
