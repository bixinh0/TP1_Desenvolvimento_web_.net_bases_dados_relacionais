using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio06.Services
{
    // Classe com os três destinos de log
    public class Logger
    {
        private readonly string _caminhoArquivo;

        // "Banco de dados" simulado em memória
        private readonly List<string> _tabelaLogs = new List<string>();

        public IReadOnlyList<string> RegistrosNoBanco => _tabelaLogs;

        public Logger(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
        }

        public void LogToConsole(string mensagem)
        {
            Console.WriteLine($"[CONSOLE]  {Formatar(mensagem)}");
        }

        public void LogToFile(string mensagem)
        {
            File.AppendAllText(_caminhoArquivo, Formatar(mensagem) + Environment.NewLine);
            Console.WriteLine($"[ARQUIVO]  Mensagem gravada em \"{_caminhoArquivo}\".");
        }

        public void LogToDatabase(string mensagem)
        {
            _tabelaLogs.Add(Formatar(mensagem));
            Console.WriteLine($"[BANCO]    Registro #{_tabelaLogs.Count} inserido na tabela de logs.");
        }

        private static string Formatar(string mensagem) =>
            $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {mensagem}";
    }
}
