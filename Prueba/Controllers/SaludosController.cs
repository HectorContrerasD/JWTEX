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
            var context = HttpContext;
            if (User.Identity != null)
            {
                return Ok("Hola " + User.Identity.Name);

            }
            return Ok("Hola a todos");
        }
    }
}
