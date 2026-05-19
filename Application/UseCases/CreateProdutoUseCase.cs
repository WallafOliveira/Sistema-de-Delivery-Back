using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Entities;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases
{
    public class CreateProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        // A injeção de dependência recebe a interface (a "Porta"), não a implementação
        public CreateProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoDto Executar(CreateProdutoDto dto)
        {
            // 1. Instancia a Entidade (as validações do construtor vão rodar aqui)
            var produto = new Produto(dto.RestauranteId, dto.Nome, dto.Quantidade, dto.Valor);

            // 2. Persiste no banco de dados
            _produtoRepository.Adicionar(produto);

            // 3. Mapeia e retorna o DTO de resposta
            return new ProdutoDto
            {
                Id = produto.Id,
                RestauranteId = produto.RestauranteId,
                Nome = produto.Nome,
                Quantidade = produto.Quantidade,
                Valor = produto.Valor
            };
        }
    }
}
