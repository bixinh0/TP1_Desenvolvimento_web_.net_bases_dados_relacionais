using System;
using System.Collections.Generic;

namespace Exercicio02
{
    public class Program
    {
        // Mensagens de boas-vindas: cada método recebe o nome do cliente e não retorna nada
        public static void BoasVindasPortugues(string nome) =>
            Console.WriteLine($"Olá, {nome}! Seja bem-vindo(a) à nossa plataforma.");

        public static void BoasVindasIngles(string nome) =>
            Console.WriteLine($"Hello, {nome}! Welcome to our platform.");

        public static void BoasVindasEspanhol(string nome) =>
            Console.WriteLine($"¡Hola, {nome}! Bienvenido(a) a nuestra plataforma.");

        public static void Main()
        {
            // Estrutura que associa cada opção de idioma ao seu Action<string>
            var mensagens = new Dictionary<string, (string Idioma, Action<string> Exibir)>
            {
                ["1"] = ("Português", BoasVindasPortugues),
                ["2"] = ("English", BoasVindasIngles),
                ["3"] = ("Español", BoasVindasEspanhol)
            };

            Console.WriteLine("=== Boas-vindas Multilíngue ===");
            Console.Write("Informe seu nome: ");
            string? nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome))
            {
                nome = "cliente";
            }

            Action<string>? exibirMensagem = null;

            while (exibirMensagem == null)
            {
                Console.WriteLine();
                Console.WriteLine("Escolha o idioma:");
                foreach (var opcao in mensagens)
                {
                    Console.WriteLine($"  {opcao.Key} - {opcao.Value.Idioma}");
                }
                Console.Write("Opção: ");
                string? escolha = Console.ReadLine()?.Trim();

                if (escolha != null && mensagens.TryGetValue(escolha, out var selecionado))
                {
                    exibirMensagem = selecionado.Exibir;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite 1, 2 ou 3.");
                }
            }

            Console.WriteLine();
            // Invoca o delegate escolhido
            exibirMensagem(nome.Trim());
        }
    }
}