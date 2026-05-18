namespace Sistema_de_delivery_back.Application.DTOs;

public class CreateRestauranteDto
{
    public string Nome { get; set; } = string.Empty;
    public string CPNJ { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
}
