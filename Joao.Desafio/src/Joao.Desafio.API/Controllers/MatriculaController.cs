using Joao.Desafio.API.DTO;
using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Dominio.IServico;
using Microsoft.AspNetCore.Mvc;

namespace Joao.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly IPagamentoGerenciadorServico _pagamentoGerenciadorServico;

        public MatriculaController(IMatriculaRepositorio matriculaRepositorio, IPagamentoGerenciadorServico pagamentoGerenciadorServico)
        {
            _matriculaRepositorio = matriculaRepositorio;
            _pagamentoGerenciadorServico = pagamentoGerenciadorServico;
        }

        // POST matricular
        /// <summary>
        /// Registra uma nova matricula
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /novo
        ///     {
        ///          "estudanteId": "216d5ef4-c339-4bfa-8f47-38e7b3dc563d",
        ///          "cursoId": "566d5ef4-ads1-5bfh-8f47-40e7b3asdf9d"
        ///     }
        /// 
        /// </remarks>
        /// <param name="estudanteId">Guid referente ao Estudante</param>
        /// <param name="cursoId">Guid referente ao Curso</param>
        /// <returns>Retorna informações do cadastrado</returns>
        /// <response code="200">Matricula cadastrado</response>
        [HttpPost("matricular")]
        public IActionResult Novo(MatriculaDTO matriculaNova)
        {
            if (_pagamentoGerenciadorServico.VerificarExistePagamento(matriculaNova.EstudanteId))
            {
                var matricula = new Matricula(matriculaNova.EstudanteId, matriculaNova.CursoId);

                _matriculaRepositorio.Adicionar(matricula);

                return Ok(matricula);
            }

            return BadRequest("Não foi possível realizar a matrícula");            
        }
    }
}
