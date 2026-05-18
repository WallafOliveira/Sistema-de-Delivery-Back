using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases;

public class ListarRestaurantesAbertosUseCase
{
    private readonly IRestauranteRepository _restauranteRepository;

    public ListarRestaurantesAbertosUseCase(IRestauranteRepository restauranteRepository)
    {
        _restauranteRepository = restauranteRepository;
    }

    public List<RestauranteDto> Execute()
    {
        var restaurantes = _restauranteRepository.ListarAbertos();

        return restaurantes.Select(r => new RestauranteDto
        {
            Id = r.Id,
            Nome = r.Nome,
            CPNJ = r.CPNJ,
            Endereco = r.Endereco,
            EstaAberto = r.EstaAberto
        }).ToList();
    }
}
