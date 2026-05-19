using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases
{
    public class ListarProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoDto> Executar()
        {
            var produtos = _produtoRepository.ObterTodos();

            // Transforma (Mapeia) a Entidade em DTO
            return produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                RestauranteId = p.RestauranteId,
                Nome = p.Nome,
                Quantidade = p.Quantidade,
                Valor = p.Valor
            });
        }
    }
}
