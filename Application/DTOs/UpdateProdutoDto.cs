using System.ComponentModel.DataAnnotations;

namespace Sistema_de_delivery_back.Application.DTOs
{
    public class UpdateProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
