using System;
using System.Globalization;

namespace Exercicio03
{
    public class Program
    {
        private static readonly CultureInfo PtBr = new CultureInfo("pt-BR");

        public static void Main()
        {
            Console.WriteLine("=== Cálculo de Área do Retângulo ===");

            double baseRetangulo = LerMedida("Informe a base (ex.: 4,5): ");
            double altura = LerMedida("Informe a altura (ex.: 2,0): ");

            // Func com dois parâmetros double e retorno double (o último tipo é o retorno)
            Func<double, double, double> calcularArea = (b, h) => b * h;

            // Usa o delegate para obter o resultado
            double area = calcularArea(baseRetangulo, altura);

            Console.WriteLine();
            Console.WriteLine($"Base:   {baseRetangulo.ToString("N2", PtBr)}");
            Console.WriteLine($"Altura: {altura.ToString("N2", PtBr)}");
            Console.WriteLine($"Área:   {area.ToString("N2", PtBr)} unidades²");
        }

        // Solicita uma medida até receber um número maior que zero
        private static double LerMedida(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? entrada = Console.ReadLine();

                if (double.TryParse(entrada, NumberStyles.Float, PtBr, out double valor) && valor > 0)
                {
                    return valor;
                }

                Console.WriteLine("Valor inválido. Digite um número maior que zero, usando vírgula para decimais.");
            }
        }
    }
}