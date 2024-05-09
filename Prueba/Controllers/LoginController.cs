using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Helper;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(string username, string password)
        {
            if (password == "ITESRC")
            {
                JwtTokenGenerator jwtToken = new();
                return Ok(jwtToken.GetTokem(username));
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
