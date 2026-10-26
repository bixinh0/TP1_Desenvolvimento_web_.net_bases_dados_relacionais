using Exercicio06.Services;
using Exercicio06.Services;
using System;

namespace Exercicio06
{
    public class Program
    {
        public static void Main()
        {
            var logger = new Logger("logs.txt");

            // Multicast delegate: um único Action<string> apontando para vários métodos
            Action<string> registrarLog = logger.LogToConsole;
            registrarLog += logger.LogToFile;
            registrarLog += logger.LogToDatabase;

            Console.WriteLine("=== Sistema de Registro de Logs ===");
            Console.WriteLine($"Destinos encadeados no delegate: {registrarLog.GetInvocationList().Length}");
            foreach (Delegate destino in registrarLog.GetInvocationList())
            {
                Console.WriteLine($"  - {destino.Method.Name}");
            }
            Console.WriteLine("Digite uma mensagem de log (ou 'sair' para encerrar).");

            while (true)
            {
                Console.Write("\nMensagem: ");
                string? mensagem = Console.ReadLine()?.Trim();

                if (string.Equals(mensagem, "sair", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(mensagem))
                {
                    Console.WriteLine("A mensagem não pode ficar vazia.");
                    continue;
                }

                // Uma única chamada executa os três métodos, na ordem em que foram adicionados
                registrarLog(mensagem);
            }

            Console.WriteLine();
            Console.WriteLine($"Total de registros no banco simulado: {logger.RegistrosNoBanco.Count}");
            Console.WriteLine("Sistema encerrado.");
        }
    }
}