using Exercicio07.Services;
using Exercicio07.Services;
using System;

namespace Exercicio07
{
    public class Program
    {
        public static void Main()
        {
            var logger = new Logger("logs.txt");

            // O delegate começa sem nenhum método associado (null)
            Action<string>? registrarLog = null;

            Console.WriteLine("=== Sistema de Registro de Logs (invocação segura) ===");

            // TESTE 1: delegate sem métodos associados
            Console.WriteLine("\n[TESTE 1] Invocando o delegate sem nenhum método associado...");
            ExibirDestinos(registrarLog);

            // Chamada direta, apenas para comparação: com o delegate nulo, gera NullReferenceException
            try
            {
                registrarLog!("Mensagem com chamada direta");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("  Chamada direta registrarLog(...): NullReferenceException.");
            }

            // Chamada segura: com o delegate nulo, simplesmente não faz nada
            registrarLog?.Invoke("Mensagem com chamada segura");
            Console.WriteLine("  Chamada segura registrarLog?.Invoke(...): nenhuma exceção.");

            // TESTE 2: delegate com os três destinos encadeados
            registrarLog += logger.LogToConsole;
            registrarLog += logger.LogToFile;
            registrarLog += logger.LogToDatabase;

            Console.WriteLine("\n[TESTE 2] Delegate com os três destinos associados.");
            ExibirDestinos(registrarLog);
            Console.WriteLine("Digite mensagens de log (ou 'sair' para encerrar este teste).");

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

                registrarLog?.Invoke(mensagem);
            }

            // TESTE 3: removendo todos os métodos (o delegate volta a ser null)
            registrarLog -= logger.LogToConsole;
            registrarLog -= logger.LogToFile;
            registrarLog -= logger.LogToDatabase;

            Console.WriteLine("\n[TESTE 3] Todos os métodos removidos do delegate.");
            ExibirDestinos(registrarLog);
            registrarLog?.Invoke("Mensagem após remover todos os destinos");
            Console.WriteLine("  Chamada segura registrarLog?.Invoke(...): nenhuma exceção.");

            Console.WriteLine();
            Console.WriteLine($"Total de registros no banco simulado: {logger.RegistrosNoBanco.Count}");
            Console.WriteLine("Sistema encerrado sem erros.");
        }

        // Lista os métodos associados ao delegate, tratando o caso de ele estar vazio
        private static void ExibirDestinos(Action<string>? registrarLog)
        {
            Delegate[] destinos = registrarLog?.GetInvocationList() ?? Array.Empty<Delegate>();

            Console.WriteLine($"  Destinos associados: {destinos.Length}");
            foreach (Delegate destino in destinos)
            {
                Console.WriteLine($"    - {destino.Method.Name}");
            }
        }
    }
}