using Joao.Desafio.Dominio.IRepositorio;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Dominio.IServico;
using Joao.Desafio.Infraestrutura.Contextos;
using Joao.Desafio.Infraestrutura.Repositorios;
using Joao.Desafio.Infraestrutura.Servico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    public class IntegracaoTesteFixture
    {
        public IntegracaoTesteFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<AppContexto>(opt => opt.UseInMemoryDatabase("DbLocalMemoriaTeste"));

            serviceCollection.AddScoped<IEstudanteRepositorio, EstudanteRepositorio>();
            serviceCollection.AddScoped<ICursoRepositorio, CursoRepositorio>();
            serviceCollection.AddScoped<ICartaoCreditoRepositorio, CartaoCreditoRepositorio>();
            serviceCollection.AddScoped<IPagamentoRepositorio, PagamentoRepositorio>();
            serviceCollection.AddScoped<IMatriculaRepositorio, MatriculaRepositorio>();
            serviceCollection.AddScoped<IEmailRepositorio, EmailRepositorio>();            
            
            serviceCollection.AddScoped<IPagamentoGerenciadorServico, PagamentoGereciadorServico>();
            serviceCollection.AddScoped<IEmailServico, EmailServico>();
            
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }    
}
