using Exercicio05.Events;
using Exercicio05.Services;
using System;

namespace Exercicio05
{
    public class Program
    {
        public static void Main()
        {
            var gerenciador = new DownloadManager();

            // Inscreve o manipulador no evento
            gerenciador.DownloadCompleted += ExibirConclusao;

            Console.WriteLine("=== Gerenciador de Download ===");
            Console.Write("Informe o nome do arquivo a baixar: ");
            string? nomeArquivo = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(nomeArquivo))
            {
                nomeArquivo = "arquivo.zip";
            }

            Console.WriteLine();
            gerenciador.Baixar(nomeArquivo);

            // Cancela a inscrição antes de encerrar
            gerenciador.DownloadCompleted -= ExibirConclusao;
        }

        // Manipulador do evento: mostra a mensagem de conclusão no console
        private static void ExibirConclusao(object? sender, DownloadCompletedEventArgs e)
        {
            ConsoleColor corOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(
                $"[{e.ConcluidoEm:HH:mm:ss}] Download de \"{e.NomeArquivo}\" concluído " +
                $"em {e.Duracao.TotalSeconds:N1} segundos.");
            Console.ForegroundColor = corOriginal;
        }
    }
}