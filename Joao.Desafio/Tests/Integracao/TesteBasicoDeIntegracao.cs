using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Integracao
{
    public class TesteBasicoDeIntegracao : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public TesteBasicoDeIntegracao()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Theory]
        [InlineData("/api/Estudante/obter-todos")]
        [InlineData("/api/Curso/obter-todos")]
        [InlineData("/api/CartaoCredito/obter-todos")]
        [InlineData("/api/CartaoCredito/obter-cartoes-creditos-por-estudante/?id=216d5ef4-c339-4bfa-8f47-38e7b3dc563d")]
        [InlineData("/api/Email/obter-por-destinatario/?destinatario=joao@mail.com")]
        public async Task ObterTodosReturnaSucesso(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
