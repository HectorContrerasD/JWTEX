using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaludosController : ControllerBase
    {
        public IActionResult get()
        {
            return Ok("Hola mundo");
        }
    }
}
