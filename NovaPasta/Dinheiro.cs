namespace Sistema_de_delivery_back.NovaPasta
{
    public class Dinheiro
    {
        public decimal Valor { get; private set; }
        public string Moeda { get; private set; } = "BRL";
        public Dinheiro(decimal valor)
        {
            if (valor < 0) throw new ArgumentException("O valor não pode ser negativo.");
            Valor = valor;
        }
    }
}
