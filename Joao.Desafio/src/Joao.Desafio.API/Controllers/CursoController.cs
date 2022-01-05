using Microsoft.AspNetCore.Mvc;

namespace Joao.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Novo()
        {


            return Ok();
        }
    }
}
