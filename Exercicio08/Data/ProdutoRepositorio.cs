using System.Collections.Generic;
using System.Linq;
using Exercicio08.Models;

namespace Exercicio08.Data
{
    // Lista fixa de produtos, compartilhada entre as páginas
    public static class ProdutoRepositorio
    {
        private static readonly List<Produto> _produtos = new()
        {
            new Produto { Id = 1, Nome = "Notebook", Preco = 3499.90m, Descricao = "Notebook 15,6\" com 16 GB de RAM e SSD de 512 GB." },
            new Produto { Id = 2, Nome = "Mouse sem fio", Preco = 89.90m, Descricao = "Mouse óptico sem fio com receptor USB." },
            new Produto { Id = 3, Nome = "Monitor 24\"", Preco = 899.00m, Descricao = "Monitor Full HD de 24 polegadas com entrada HDMI." }
        };

        public static IReadOnlyList<Produto> ObterTodos() => _produtos;

        public static Produto? ObterPorId(int id) => _produtos.FirstOrDefault(p => p.Id == id);
    }
}