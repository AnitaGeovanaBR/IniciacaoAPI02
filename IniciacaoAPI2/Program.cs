using Domain.Repositories;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração dos Controllers e JSON (CamelCase para o Angular reconhecer os nomes)
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

// 2. Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 3. Configuração do Banco de Dados SQL Server
var connectionString = builder.Configuration.GetConnectionString("biblioteca")
    ?? throw new InvalidOperationException("Connection string 'biblioteca' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// 4. Injeção de Dependência dos Repositórios
builder.Services.AddTransient<IBibliotecaRepository, BibliotecaRepository>();
builder.Services.AddTransient<ILivroRepository, LivroRepository>();

// 5. Configuração do CORS (Permite que o Angular acesse a API)
builder.Services.AddCors(options => {
    options.AddPolicy("AngularPolicy", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configuração do Pipeline de Requisições (Middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// IMPORTANTE: O UseCors deve vir antes do UseAuthorization e MapControllers
app.UseCors("AngularPolicy");

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();