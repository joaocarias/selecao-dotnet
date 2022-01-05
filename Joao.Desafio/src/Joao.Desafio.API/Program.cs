using Joao.Desafio.API.AutoMapper;
using AutoMapper;
using Joao.Desafio.Dominio.IRepositorio;
using Joao.Desafio.Infraestrutura.Contextos;
using Joao.Desafio.Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppContexto>(opt => opt.UseInMemoryDatabase("DbLocalMemoria"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AppProfile));

builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
