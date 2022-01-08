using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorio;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Unitarios
{
    public class TesteCurso : IClassFixture<IntegracaoTesteFixture>
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public TesteCurso(IntegracaoTesteFixture fixture)
        {
            _cursoRepositorio = fixture.ServiceProvider.GetRequiredService<ICursoRepositorio>();
        }

        [Theory]
        [InlineData("Computacao")]
        [InlineData("Matematica")]
        [InlineData("Administacao")]
        public void CadastrarRetornaVerdadeiro(string nome)
        {
            var novo = new Curso(nome);

            var retornoAdd = _cursoRepositorio.Adicionar(novo);
            var busca = _cursoRepositorio.Obter(novo.Id);

            Assert.True(retornoAdd && busca != null && busca.Descricao.Equals(nome));
        }
    }
}
