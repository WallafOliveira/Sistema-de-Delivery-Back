namespace Sistema_de_delivery_back.Domain.Entities;

public class Restaurante
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string CPNJ { get; private set; }
    public string Endereco { get; private set; }
    public bool EstaAberto { get; private set; }

    public Restaurante(string nome, string cpnj, string endereco)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        CPNJ = cpnj;
        Endereco = endereco;
        EstaAberto = false;
    }

    private Restaurante() { }

    public void AtualizarDados(string nome, string cpnj, string endereco, bool estaAberto)
    {
        Nome = nome;
        CPNJ = cpnj;
        Endereco = endereco;
        EstaAberto = estaAberto;
    }
}
