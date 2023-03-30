using FluxoDiario.Api.Contracts;
using FluxoDiario.Api.Extended;
using FluxoDiario.Api.Services;
using FluxoDiario.Infra.Data.Context;
using FluxoDiario.Infra.Data.Contracts;
using FluxoDiario.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ConnectionString
var conectionString = builder.Configuration.GetConnectionString("Projeto");
builder.Services.AddDbContext<DataContext>
    (options => options.UseSqlServer(conectionString));

//inje��o de dependencia
builder.Services.AddTransient<ILancamentoService, LancamentoService>();
builder.Services.AddTransient<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddTransient<IRelatorioService, RelatorioService>();


var app = builder.Build();

app.IniciarDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
