using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases
{
    public class UpdateProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public UpdateProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoDto Executar(UpdateProdutoDto dto)
        {
            // 1. Busca o produto existente
            var produto = _produtoRepository.ObterPorId(dto.Id);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            // 2. Atualiza os dados usando o método de domínio
            produto.AtualizarDetalhes(dto.Nome, dto.Quantidade, dto.Valor);

            // 3. Salva a alteração
            _produtoRepository.Atualizar(produto);

            // 4. Retorna o DTO atualizado
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
