using System;
using System.Collections.Generic;
using System.Linq;
using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases
{
    public class ListarProdutosPorRestauranteUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutosPorRestauranteUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoDto> Executar(Guid restauranteId)
        {
            var produtos = _produtoRepository.ObterPorRestauranteId(restauranteId);

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