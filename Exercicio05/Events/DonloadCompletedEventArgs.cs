using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Exercicio05.Events
{
    // Dados enviados junto com o evento de download concluído
    public class DownloadCompletedEventArgs : EventArgs
    {
        public string NomeArquivo { get; }
        public TimeSpan Duracao { get; }
        public DateTime ConcluidoEm { get; }

        public DownloadCompletedEventArgs(string nomeArquivo, TimeSpan duracao)
        {
            NomeArquivo = nomeArquivo;
            Duracao = duracao;
            ConcluidoEm = DateTime.Now;
        }
    }
}
