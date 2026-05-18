using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases;

public class BuscarRestaurantePorIdUseCase
{
    private readonly IRestauranteRepository _restauranteRepository;

    public BuscarRestaurantePorIdUseCase(IRestauranteRepository restauranteRepository)
    {
        _restauranteRepository = restauranteRepository;
    }

    public RestauranteDto? Execute(Guid id)
    {
        var restaurante = _restauranteRepository.BuscarPorId(id);

        if (restaurante == null)
        {
            return null;
        }

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
