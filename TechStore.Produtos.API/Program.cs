using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TechStore.Produtos.Application.Services;
using TechStore.Produtos.Domain.Repositories;
using TechStore.Produtos.Infrastructure;
using TechStore.Produtos.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionStringDB = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IProdutoDigitalRepository, ProdutoDigitalRepository>();
builder.Services.AddScoped<ProdutoDigitalService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStringDB));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
