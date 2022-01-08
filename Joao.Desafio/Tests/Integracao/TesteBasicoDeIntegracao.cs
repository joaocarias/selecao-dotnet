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
