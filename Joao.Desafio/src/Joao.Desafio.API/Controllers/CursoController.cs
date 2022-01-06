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

        // GET obter-todos
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

        // GET obter
        /// <summary>
        /// Obtem o curso cadastrado a partir do Guid do registro do mesmo 
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /obter?id=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        /// 
        /// </remarks> 
        /// <returns>Curso com o Guid informado em caso de encontrado.</returns>
        /// <response code="200">Retorna o Curso buscado</response>
        [HttpGet("obter")]
        public IActionResult Obter(Guid id)
        {
            return Ok(_cursoRepositorio.Obter(id));
        }

        // POST novo
        /// <summary>
        /// Registra um novo curso
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /novo
        ///     {
        ///          "descricao": "Matematica",
        ///      }
        /// 
        /// </remarks>
        /// <param name="descricao">Descrição ou nome do curso</param>
        /// <returns>Retorna o novo curso cadastrado</returns>
        /// <response code="200">Curso cadastrado</response>
        [HttpPost("novo")]
        public IActionResult Novo(CursoDTO cursoNovo)
        {
            var curso = new Curso(cursoNovo.Descricao);

            _cursoRepositorio.Adicionar(curso);

            return Ok(curso);
        }

        // PUT editar
        /// <summary>
        /// Edita um curso existente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Editar?id=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        ///     {
        ///          "descricao": "MatematicaEdicao",
        ///      }
        /// 
        /// </remarks>
        /// <param name="descricao">Descrição ou nome do curso</param>
        /// <returns>Retorna informações de curso editado </returns>
        /// <response code="200">Curso Editado</response>
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

        // DELETE remover
        /// <summary>
        /// Apaga um registro de curso.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /remover?id=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        /// 
        /// </remarks> 
        /// <returns>Mensagem de sucesso</returns>
        /// <response code="200">Retorna mensagem de sucesso</response>
        [HttpDelete("remover")]
        public IActionResult Remover(Guid id)
        {
            var curso = _cursoRepositorio.Obter(id);
            if (curso != null)
            {
                _cursoRepositorio.Apagar(curso);

                return Ok("Sucesso!");
            }

            return BadRequest();
        }
    }
}
