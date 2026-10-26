using System;
using System.Globalization;

namespace Exercicio01
{
    // Delegate personalizado: recebe o preço original e devolve o preço com desconto
    public delegate decimal CalculateDiscount(decimal precoOriginal);

    public class Program
    {
        private static readonly CultureInfo PtBr = new CultureInfo("pt-BR");

        // Método compatível com a assinatura do delegate (decimal -> decimal)
        public static decimal AplicarDescontoDezPorCento(decimal precoOriginal)
        {
            const decimal percentualDesconto = 0.10m;
            return precoOriginal - (precoOriginal * percentualDesconto);
        }

        public static void Main()
        {
            Console.WriteLine("=== Cálculo de Desconto ===");

            decimal precoOriginal = LerPreco();

            // Instancia o delegate apontando para o método de regra de negócio
            CalculateDiscount calcularDesconto = AplicarDescontoDezPorCento;

            // Usa o delegate no fluxo da aplicação
            decimal precoFinal = calcularDesconto(precoOriginal);

            Console.WriteLine();
            Console.WriteLine($"Preço original:       {precoOriginal.ToString("C", PtBr)}");
            Console.WriteLine($"Desconto aplicado:    10%");
            Console.WriteLine($"Preço com desconto:   {precoFinal.ToString("C", PtBr)}");
        }

        // Solicita o preço ao usuário até receber um valor válido
        private static decimal LerPreco()
        {
            while (true)
            {
                Console.Write("Informe o preço original do produto (ex.: 150,90): R$ ");
                string? entrada = Console.ReadLine();

                if (decimal.TryParse(entrada, NumberStyles.Number, PtBr, out decimal preco) && preco >= 0)
                {
                    return preco;
                }

                Console.WriteLine("Valor inválido. Digite um número positivo, usando vírgula para os centavos.");
            }
        }
    }
}