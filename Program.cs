using Microsoft.EntityFrameworkCore;
using Sistema_de_delivery_back.Application.UseCases;
using Sistema_de_delivery_back.Domain.Interfaces;
using Sistema_de_delivery_back.Infrastructure.Data;
using Sistema_de_delivery_back.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("DeliveryDb"));

// Repository Registration
builder.Services.AddScoped<IRestauranteRepository, RestauranteRepository>();

// Use Cases Registration
builder.Services.AddScoped<CreateRestauranteUseCase>();
builder.Services.AddScoped<UpdateRestauranteUseCase>();
builder.Services.AddScoped<ListarRestaurantesUseCase>();
builder.Services.AddScoped<ListarRestaurantesAbertosUseCase>();
builder.Services.AddScoped<BuscarRestaurantePorIdUseCase>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
