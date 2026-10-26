using Exercicio04.Events;
using Exercicio04.Services;
using System;
using System.Globalization;

namespace Exercicio04
{
    public class Program
    {
        private static readonly CultureInfo PtBr = new CultureInfo("pt-BR");

        public static void Main()
        {
            var sensor = new TemperatureSensor();

            // Inscreve o manipulador no evento
            sensor.TemperatureExceeded += ExibirAlerta;

            Console.WriteLine("=== Monitoramento de Temperatura ===");
            Console.WriteLine($"Limite seguro: {TemperatureSensor.LimiteSeguro.ToString("N1", PtBr)} ºC");
            Console.WriteLine("Digite as leituras do sensor (ou 'sair' para encerrar).");

            while (true)
            {
                Console.Write("\nTemperatura (ºC): ");
                string? entrada = Console.ReadLine()?.Trim();

                if (string.Equals(entrada, "sair", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (!double.TryParse(entrada, NumberStyles.Float, PtBr, out double temperatura))
                {
                    Console.WriteLine("Leitura inválida. Digite um número (use vírgula para decimais).");
                    continue;
                }

                sensor.RegistrarLeitura(temperatura);

                if (temperatura <= TemperatureSensor.LimiteSeguro)
                {
                    Console.WriteLine($"Leitura OK: {temperatura.ToString("N1", PtBr)} ºC");
                }
            }

            // Cancela a inscrição antes de encerrar
            sensor.TemperatureExceeded -= ExibirAlerta;
            Console.WriteLine("Monitoramento encerrado.");
        }

        // Manipulador do evento: mostra o alerta no console
        private static void ExibirAlerta(object? sender, TemperatureEventArgs e)
        {
            ConsoleColor corOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                $"[ALERTA {e.Momento:HH:mm:ss}] Temperatura de {e.Temperatura.ToString("N1", PtBr)} ºC " +
                $"ultrapassou o limite de {e.Limite.ToString("N1", PtBr)} ºC!");
            Console.ForegroundColor = corOriginal;
        }
    }
}