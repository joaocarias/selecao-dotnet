using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorio;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Dominio.IServico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;


namespace Tests.Unitarios
{
    public class TesteMatricula : IClassFixture<IntegracaoTesteFixture>
    {
        private readonly IEstudanteRepositorio _estudanteRepositorio;
        private readonly ICursoRepositorio _cursoRepositorio;
        private readonly ICartaoCreditoRepositorio _cartaoCreditoRepositorio;
        private readonly IPagamentoRepositorio _pagamentoRepositorio;
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly IEmailRepositorio _emailRepositorio;

        private readonly IPagamentoGerenciadorServico _pagamentoGerenciadorServico;
        private readonly IEmailServico _emailServico;

        public TesteMatricula(IntegracaoTesteFixture fixture)
        {
            _estudanteRepositorio = fixture.ServiceProvider.GetRequiredService<IEstudanteRepositorio>();
            _cursoRepositorio = fixture.ServiceProvider.GetRequiredService<ICursoRepositorio>();
            _cartaoCreditoRepositorio = fixture.ServiceProvider.GetRequiredService<ICartaoCreditoRepositorio>();
            _pagamentoRepositorio = fixture.ServiceProvider.GetRequiredService<IPagamentoRepositorio>();
            _matriculaRepositorio = fixture.ServiceProvider.GetRequiredService<IMatriculaRepositorio>();
            _emailRepositorio = fixture.ServiceProvider.GetRequiredService<IEmailRepositorio>();
                       
            _pagamentoGerenciadorServico = fixture.ServiceProvider.GetRequiredService<IPagamentoGerenciadorServico>();
            _emailServico = fixture.ServiceProvider.GetRequiredService<IEmailServico>();
        }

        [Theory]
        [InlineData("joao", "Matematica")]
        [InlineData("Ana", "Pedagogia")]
        [InlineData("Cristina", "Enfermagem")]
        public void MatricularEstudantePosPagamento(string estudante, string curso)
        {
            var novoEstudante = new Estudante(estudante, estudante + "@email.com");
            var novoCurso = new Curso(curso);            

            var retornoAddEstudante = _estudanteRepositorio.Adicionar(novoEstudante);
            var retornoAddCurso = _cursoRepositorio.Adicionar(novoCurso);

            var novoCartao = new CartaoCredito(
                                        novoEstudante.Id,
                                        Convert.ToString(new Random().Next(1000, 9999))
                                        + " " + Convert.ToString(new Random().Next(1000, 9999))
                                        + " " + Convert.ToString(new Random().Next(1000, 9999))
                                        + " " + Convert.ToString(new Random().Next(1000, 9999)) ,
                                        estudante.ToUpper(),
                                        Convert.ToString(new Random().Next(1, 12))
                                        + " " + Convert.ToString(new Random().Next(2022, 2030)),
                                        Convert.ToString(new Random().Next(1, 999))
                                 );

            var retornoAddCartao = _cartaoCreditoRepositorio.Adicionar(novoCartao);

            var novoPagamento = new Pagamento(novoEstudante.Id, new Random().Next(1000), novoCartao.Id);

            var retornoPagamento = _pagamentoRepositorio.Adicionar(novoPagamento);

            var buscaEstudante = _estudanteRepositorio.Obter(novoEstudante.Id);
            var buscaCurso = _cursoRepositorio.Obter(novoCurso.Id);
            var buscaCartao = _cartaoCreditoRepositorio.Obter(novoCartao.Id);
            var buscaPagemento = _pagamentoRepositorio.Obter(novoPagamento.Id);

            bool retornoMatricula = false;
            Matricula novaMatricula = null;

            if (_pagamentoGerenciadorServico.VerificarExistePagamento(novoEstudante.Id))
            {
                 novaMatricula = new Matricula(buscaEstudante.Id, buscaCurso.Id); ;

                 retornoMatricula = _matriculaRepositorio.Adicionar(novaMatricula);

                if (retornoMatricula)
                {
                    _emailServico.EnviarEmail(_matriculaRepositorio.Obter(novaMatricula.Id));
                }
            }

            var buscarEmail = _emailRepositorio.BuscarPorDestinatario(buscaEstudante.Email);

            Assert.True(
                    retornoAddEstudante
                    && retornoAddCurso
                    && retornoPagamento
                    && retornoMatricula
                    && buscaEstudante.NomeCompleto.Equals(estudante)
                    && buscaCurso.Descricao.Equals(curso)
                    && buscaCartao.NomeTitular.Equals(estudante.ToUpper())
                    && buscaPagemento != null
                    && _matriculaRepositorio.Obter(novaMatricula.Id).CursoId.Equals(novoCurso.Id)
                    && buscarEmail.Any(e => e.Destinatario.Equals(novoEstudante.Email))
                );

        }

        [Theory]
        [InlineData("joao", "Matematica")]
        [InlineData("Ana", "Pedagogia")]
        [InlineData("Cristina", "Enfermagem")]
        public void MatricularEstudanteNaoPagamentoMatriculaFalha(string estudante, string curso)
        {
            var novoEstudante = new Estudante(estudante, estudante + "@email.com");
            var novoCurso = new Curso(curso);

            var retornoAddEstudante = _estudanteRepositorio.Adicionar(novoEstudante);
            var retornoAddCurso = _cursoRepositorio.Adicionar(novoCurso);

            var novoCartao = new CartaoCredito(
                                        novoEstudante.Id,
                                        Convert.ToString(new Random().Next(1000, 9999))
                                        + " " + Convert.ToString(new Random().Next(1000, 9999))
                                        + " " + Convert.ToString(new Random().Next(1000, 9999))
                                        + " " + Convert.ToString(new Random().Next(1000, 9999)),
                                        estudante.ToUpper(),
                                        Convert.ToString(new Random().Next(1, 12))
                                        + " " + Convert.ToString(new Random().Next(2022, 2030)),
                                        Convert.ToString(new Random().Next(1, 999))
                                 );

            var retornoAddCartao = _cartaoCreditoRepositorio.Adicionar(novoCartao);

            var buscaEstudante = _estudanteRepositorio.Obter(novoEstudante.Id);
            var buscaCurso = _cursoRepositorio.Obter(novoCurso.Id);
            var buscaCartao = _cartaoCreditoRepositorio.Obter(novoCartao.Id);

            bool retornoMatricula = false;
            Matricula novaMatricula = null;

            if (_pagamentoGerenciadorServico.VerificarExistePagamento(novoEstudante.Id))
            {
                novaMatricula = new Matricula(buscaEstudante.Id, buscaCurso.Id); ;

                retornoMatricula = _matriculaRepositorio.Adicionar(novaMatricula);

                if (retornoMatricula)
                {
                    _emailServico.EnviarEmail(_matriculaRepositorio.Obter(novaMatricula.Id));
                }
            }

            var buscarEmail = _emailRepositorio.BuscarPorDestinatario(buscaEstudante.Email);

            Assert.True(
                    retornoAddEstudante
                    && retornoAddCurso
                    && !retornoMatricula
                    && buscaEstudante.NomeCompleto.Equals(estudante)
                    && buscaCurso.Descricao.Equals(curso)
                    && buscaCartao.NomeTitular.Equals(estudante.ToUpper())
                    && !_matriculaRepositorio.ObteTodos().Any()
                    && !_pagamentoGerenciadorServico.VerificarExistePagamento(novoEstudante.Id)
                    && !buscarEmail.Any()
                ) ;

        }


    }
}
