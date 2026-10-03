using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TechStore.Produtos.Application.Services;
using TechStore.Produtos.Domain.Repositories;
using TechStore.Produtos.Infrastructure;
using TechStore.Produtos.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var politicaCors = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: politicaCors, policy =>
    {
        policy.WithOrigins("https://lively-field-03916740f.3.azurestaticapps.net")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    //Rate Limiter que permite 5 requisições a cada 10 segundos, sem fila de espera
    options.AddFixedWindowLimiter("fixo10s", limiterOptions =>
    {
        limiterOptions.PermitLimit = 5;
        limiterOptions.Window = TimeSpan.FromSeconds(10);
        limiterOptions.QueueLimit = 0;
    });
});

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

app.UseCors(politicaCors);

app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();
