using System;
using Exercicio12.Models;

namespace Exercicio12.Services
{
    // Manipulador compatível com Action<Event>: registra a criação no console
    public static class EventLogger
    {
        public static void RegistrarNoConsole(Event evento)
        {
            ConsoleColor corOriginal = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Novo evento criado: " +
                $"\"{evento.Titulo}\" em {evento.Data:dd/MM/yyyy HH:mm} - Local: {evento.Local}");
            Console.ForegroundColor = corOriginal;
        }
    }
}