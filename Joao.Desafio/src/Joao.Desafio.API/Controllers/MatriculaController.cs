﻿using Joao.Desafio.API.DTO;
using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Dominio.IServico;
using Joao.Desafio.Dominio.Uteis;
using Microsoft.AspNetCore.Mvc;

namespace Joao.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly IPagamentoGerenciadorServico _pagamentoGerenciadorServico;
        private readonly IEmailServico _emailServico;

        public MatriculaController(IMatriculaRepositorio matriculaRepositorio, IPagamentoGerenciadorServico pagamentoGerenciadorServico, IEmailServico emailServico)
        {
            _matriculaRepositorio = matriculaRepositorio;
            _pagamentoGerenciadorServico = pagamentoGerenciadorServico;
            _emailServico = emailServico;
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

                EnviarEmail(matricula);

                return Ok(matricula);
            }

            return BadRequest("Não foi possível realizar a matrícula");            
        }

        // GET obter-por-estudante
        /// <summary>
        /// Obtem a partir do guid do estudante, informacoes sobre matriculas
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /obter-por-estudante?estudanteId=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        /// 
        /// </remarks>
        /// <returns>Retorna lista de matriculas com informações do cadastrado</returns>
        /// <response code="200">Matriculas cadastradas</response>
        [HttpGet("obter-por-estudante")]
        public IActionResult ObterMatriculasPorEstudante(Guid estudanteId)
        {
            return Ok(_matriculaRepositorio.ObterMatriculasPorEstudante(estudanteId));
        }

        private void EnviarEmail(Matricula matricula)
        {
            var matriculaInclude = _matriculaRepositorio.Obter(matricula.Id);
            _emailServico.EnviarEmail(matriculaInclude);
        }

       
    }
}
