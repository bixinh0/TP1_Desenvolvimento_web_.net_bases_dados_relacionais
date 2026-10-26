using System;

namespace Exercicio11.Services
{
    // Métodos compatíveis com Func<string, string, string>:
    // todos recebem nome e sobrenome e devolvem uma string
    public static class TransformadorNome
    {
        public static string Concatenar(string nome, string sobrenome)
        {
            string resultado = $"{nome} {sobrenome}";
            Console.WriteLine($"  Concatenar          -> \"{resultado}\"");
            return resultado;
        }

        public static string ConverterMaiusculas(string nome, string sobrenome)
        {
            string resultado = $"{nome} {sobrenome}".ToUpper();
            Console.WriteLine($"  ConverterMaiusculas -> \"{resultado}\"");
            return resultado;
        }

        public static string RemoverEspacos(string nome, string sobrenome)
        {
            string resultado = $"{nome} {sobrenome}".Replace(" ", "");
            Console.WriteLine($"  RemoverEspacos      -> \"{resultado}\"");
            return resultado;
        }

        // Versões de uma entrada, usadas no pipeline encadeado de verdade (Parte 3)
        public static string ParaMaiusculas(string texto) => texto.ToUpper();

        public static string SemEspacos(string texto) => texto.Replace(" ", "");
    }
}