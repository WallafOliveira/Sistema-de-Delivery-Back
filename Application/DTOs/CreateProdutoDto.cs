using System.ComponentModel.DataAnnotations;

namespace Sistema_de_delivery_back.Application.DTOs
{
    public class CreateProdutoDto
    {
        public Guid RestauranteId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
