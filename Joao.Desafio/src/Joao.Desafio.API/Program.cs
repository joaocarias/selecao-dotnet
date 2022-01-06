using Joao.Desafio.API.AutoMapper;
using Joao.Desafio.Dominio.IRepositorio;
using Joao.Desafio.Dominio.IRepositorios;
using Joao.Desafio.Dominio.IServico;
using Joao.Desafio.Infraestrutura.Contextos;
using Joao.Desafio.Infraestrutura.Repositorios;
using Joao.Desafio.Infraestrutura.Servico;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppContexto>(opt => opt.UseInMemoryDatabase("DbLocalMemoria"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Joao.Desafio", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddAutoMapper(typeof(AppProfile));

builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
builder.Services.AddScoped<IEstudanteRepositorio, EstudanteRepositorio>();
builder.Services.AddScoped<ICartaoCreditoRepositorio, CartaoCreditoRepositorio>();
builder.Services.AddScoped<IPagamentoRepositorio, PagamentoRepositorio>();
builder.Services.AddScoped<IMatriculaRepositorio, MatriculaRepositorio>();

builder.Services.AddScoped<IPagamentoGerenciadorServico, PagamentoGereciadorServico>();
builder.Services.AddScoped<IEmailServico, EmailServico>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Joao.Desafio v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
