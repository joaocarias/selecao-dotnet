using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests
{    
    public class TesteWebAppFactory
    {
        [Fact]
        public void Teste()
        {
            using var app = new WebApplicationFactory<Program>();
            using var client = app.CreateClient();
        }
    }
}
