using System.Collections.Generic;
using Exercicio08.Data;
using Exercicio08.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercicio08.Pages
{
    public class IndexModel : PageModel
    {
        public IReadOnlyList<Produto> Produtos { get; private set; } = new List<Produto>();

        // Executado quando a página é acessada (requisição GET)
        public void OnGet()
        {
            Produtos = ProdutoRepositorio.ObterTodos();
        }
    }
}
