using Joao.Desafio.API.DTO;
using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace Joao.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public CursoController(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        // GET dados-api-pessoa
        /// <summary>
        /// Obtem todos os cursos cadastrados 
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /obter-todos
        /// 
        /// </remarks> 
        /// <returns>Listagem de cursos cadastrados .</returns>
        /// <response code="200">Retorna listagem de cursos</response>
        [HttpGet("obter-todos")]
        public IActionResult ObterTodos()
        {
            return Ok(_cursoRepositorio.ObteTodos());
        }


        [HttpGet("obter")]
        public IActionResult Obter(Guid id)
        {
            return Ok(_cursoRepositorio.Obter(id));
        }

        [HttpPost("novo")]
        public IActionResult Novo(CursoDTO cursoNovo)
        {
            var curso = new Curso(cursoNovo.Descricao);

            _cursoRepositorio.Adicionar(curso);

            return Ok(curso);
        }


        [HttpPut("editar")]
        public IActionResult Editar(Guid id, CursoDTO cursoEditado)
        {
            var curso = _cursoRepositorio.Obter(id);
            if (curso != null)
            {
                curso.Editar(cursoEditado.Descricao);

                _cursoRepositorio.Atualizar(curso);

                return Ok(curso);
            }

            return BadRequest();
        }

        [HttpDelete("remover")]
        public IActionResult Remover(Guid id)
        {
            var curso = _cursoRepositorio.Obter(id);
            if (curso != null)
            {
                _cursoRepositorio.Apagar(curso);

                return Ok(curso);
            }

            return BadRequest();
        }
    }
}
