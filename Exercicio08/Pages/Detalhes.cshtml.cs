using Exercicio08.Data;
using Exercicio08.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercicio08.Pages
{
    public class DetalhesModel : PageModel
    {
        public Produto? Produto { get; private set; }

        // O id vem da URL: /Detalhes/2
        public IActionResult OnGet(int id)
        {
            Produto = ProdutoRepositorio.ObterPorId(id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
