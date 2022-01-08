using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Unitarios
{
    public class TesteEstudante : IClassFixture<IntegracaoTesteFixture>
    {
        private readonly IEstudanteRepositorio _estudanteRepositorio;

        public TesteEstudante(IntegracaoTesteFixture fixture)
        {
            _estudanteRepositorio = fixture.ServiceProvider.GetRequiredService<IEstudanteRepositorio>();
        }

        [Theory]
        [InlineData("joao")]
        [InlineData("ana")]
        [InlineData("cristina")]
        public void CadastrarRetornaVerdadeiro(string nome)
        {
            var estudante = new Estudante(nome, nome+"@email.com");           

            var retornoAdd = _estudanteRepositorio.Adicionar(estudante);
            var busca = _estudanteRepositorio.Obter(estudante.Id);

            Assert.True(retornoAdd && busca != null && busca.NomeCompleto.Equals(nome));
        }
    }
}
