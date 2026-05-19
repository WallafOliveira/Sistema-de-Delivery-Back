using Microsoft.EntityFrameworkCore;
using Sistema_de_delivery_back.Application.UseCases;
using Sistema_de_delivery_back.Domain.Interfaces;
using Sistema_de_delivery_back.Infrastructure.Data;
using Sistema_de_delivery_back.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Database Configuration
// Nota: Você está usando banco em memória (InMemoryDatabase) para testes iniciais, o que é ótimo!
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("DeliveryDb"));

// Repository Registration
builder.Services.AddScoped<IRestauranteRepository, RestauranteRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>(); // <-- Adicionado o repositório de Produto

// Use Cases Registration - Restaurante
builder.Services.AddScoped<CreateRestauranteUseCase>();
builder.Services.AddScoped<UpdateRestauranteUseCase>();
builder.Services.AddScoped<ListarRestaurantesUseCase>();
builder.Services.AddScoped<ListarRestaurantesAbertosUseCase>();
builder.Services.AddScoped<BuscarRestaurantePorIdUseCase>();

// Use Cases Registration - Produto
builder.Services.AddScoped<CreateProdutoUseCase>();       // <-- Adicionado o Use Case de Criar Produto
builder.Services.AddScoped<UpdateProdutoUseCase>();   // <-- Adicionado o Use Case de Atualizar Produto
builder.Services.AddScoped<ListarProdutoUseCase>();
builder.Services.AddScoped<ListarProdutosPorRestauranteUseCase>();

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();