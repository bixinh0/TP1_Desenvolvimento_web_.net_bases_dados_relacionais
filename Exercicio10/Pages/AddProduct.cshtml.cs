using Exercicio10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercicio10.Pages
{
    public class AddProductModel : PageModel
    {
        // Liga os campos do formulário a esta propriedade quando ele é enviado (POST)
        [BindProperty]
        public Produto Produto { get; set; } = new Produto();

        // Indica se há dados enviados para exibir
        public bool Enviado { get; private set; }

        // Primeiro acesso à página: mostra o formulário vazio
        public void OnGet()
        {
        }

        // Envio do formulário
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Volta para a página mostrando as mensagens de erro
                return Page();
            }

            Enviado = true;
            return Page();
        }
    }
}