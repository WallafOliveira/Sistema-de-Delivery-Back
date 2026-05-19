
using System;

namespace Sistema_de_delivery_back.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public Guid RestauranteId { get; private set; }
        public virtual Restaurante Restaurante { get; private set; }

        public string Nome { get; private set; }
        public int Quantidade { get; private set; } 
        public decimal Valor { get; private set; }

        public Produto(Guid restauranteId, string nome, int quantidade, decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor deve ser maior que zero.");
            if (quantidade < 0) throw new ArgumentException("A quantidade não pode ser negativa.");

            Id = Guid.NewGuid();
            RestauranteId = restauranteId;
            Nome = nome;
            Quantidade = quantidade;
            Valor = valor;
        }

        // Método para abater o estoque quando um pedido é feito
        public void DeduzirQuantidade(int quantidadeComprada)
        {
            if (Quantidade < quantidadeComprada)
                throw new InvalidOperationException("Quantidade insuficiente em estoque.");

            Quantidade -= quantidadeComprada;
        }

        // Adicione este método dentro da sua classe Produto existente
        public void AtualizarDetalhes(string nome, int quantidade, decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor deve ser maior que zero.");
            if (quantidade < 0) throw new ArgumentException("A quantidade não pode ser negativa.");

            Nome = nome;
            Quantidade = quantidade;
            Valor = valor;
        }
    }
}
