using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases;

public class ListarRestaurantesUseCase
{
    private readonly IRestauranteRepository _restauranteRepository;

    public ListarRestaurantesUseCase(IRestauranteRepository restauranteRepository)
    {
        _restauranteRepository = restauranteRepository;
    }

    public List<RestauranteDto> Execute()
    {
        var restaurantes = _restauranteRepository.ListarTodos();

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
