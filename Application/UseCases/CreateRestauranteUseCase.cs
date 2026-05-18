using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Entities;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases;

public class CreateRestauranteUseCase
{
    private readonly IRestauranteRepository _restauranteRepository;

    public CreateRestauranteUseCase(IRestauranteRepository restauranteRepository)
    {
        _restauranteRepository = restauranteRepository;
    }

    public RestauranteDto Execute(CreateRestauranteDto dto)
    {
        var restaurante = new Restaurante(dto.Nome, dto.CPNJ, dto.Endereco);
        
        _restauranteRepository.Adicionar(restaurante);

        return new RestauranteDto
        {
            Id = restaurante.Id,
            Nome = restaurante.Nome,
            CPNJ = restaurante.CPNJ,
            Endereco = restaurante.Endereco,
            EstaAberto = restaurante.EstaAberto
        };
    }
}
