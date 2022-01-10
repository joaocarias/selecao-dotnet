using Joao.Desafio.Dominio.IRepositorios;
using Microsoft.AspNetCore.Mvc;

namespace Joao.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepositorio _emailRepositorio;

        public EmailController(IEmailRepositorio emailRepositorio)
        {
            _emailRepositorio = emailRepositorio;
        }

        // GET obter-por-destinatario
        /// <summary>
        /// Obtem a partir do endereço de email do estudante
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /obter-por-destinatario/?destinatario=joao@mail.com
        /// 
        /// </remarks>
        /// <returns>Retorna lista de emails de acordo com o destinatario </returns>
        /// <response code="200">Matriculas cadastradas</response>
        [HttpGet("obter-por-destinatario")]
        public IActionResult ObterMatriculasPorEstudante(string destinatario)
        {
            return Ok(_emailRepositorio.BuscarPorDestinatario(destinatario));
        }
    }
}
