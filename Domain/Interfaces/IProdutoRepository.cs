using System;
using System.Collections.Generic;
using Sistema_de_delivery_back.Domain.Entities;

namespace Sistema_de_delivery_back.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        Produto ObterPorId(Guid id);
        IEnumerable<Produto> ObterTodos();
        IEnumerable<Produto> ObterPorRestauranteId(Guid restauranteId);
    }
}