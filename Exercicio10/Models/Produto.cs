using System.ComponentModel.DataAnnotations;

namespace Exercicio10.Models
{
    // Model com os dados do formulário e as regras de validação
    public class Produto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Informe o preço do produto.")]
        [Range(0.01, 1000000, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal? Preco { get; set; }
    }
}