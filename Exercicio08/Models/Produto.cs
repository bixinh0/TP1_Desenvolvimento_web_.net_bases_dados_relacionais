namespace Exercicio08.Models
{
    // Model: só guarda os dados do produto
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}