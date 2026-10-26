using Exercicio05.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Exercicio05.Services
{
    // Classe responsável pelo download e por avisar quando ele termina
    public class DownloadManager
    {
        public event EventHandler<DownloadCompletedEventArgs>? DownloadCompleted;

        public void Baixar(string nomeArquivo)
        {
            Console.WriteLine($"Iniciando download de \"{nomeArquivo}\"...");
            var cronometro = Stopwatch.StartNew();

            // Simula o tempo de download em 5 etapas de 1 segundo
            for (int progresso = 20; progresso <= 100; progresso += 20)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"  Progresso: {progresso}%");
            }

            cronometro.Stop();

            // Dispara o evento ao final do processo
            OnDownloadCompleted(new DownloadCompletedEventArgs(nomeArquivo, cronometro.Elapsed));
        }

        // Dispara o evento somente se houver assinantes
        protected virtual void OnDownloadCompleted(DownloadCompletedEventArgs e)
        {
            DownloadCompleted?.Invoke(this, e);
        }
    }
}
