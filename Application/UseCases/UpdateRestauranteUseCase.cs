using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases;

public class UpdateRestauranteUseCase
{
    private readonly IRestauranteRepository _restauranteRepository;

    public UpdateRestauranteUseCase(IRestauranteRepository restauranteRepository)
    {
        _restauranteRepository = restauranteRepository;
    }

    public RestauranteDto Execute(Guid id, UpdateRestauranteDto dto)
    {
        var restaurante = _restauranteRepository.BuscarPorId(id);

        if (restaurante == null)
        {
            throw new Exception($"Restaurante com ID {id} não encontrado.");
        }

        restaurante.AtualizarDados(dto.Nome, dto.CPNJ, dto.Endereco, dto.EstaAberto);

        _restauranteRepository.Atualizar(restaurante);

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
