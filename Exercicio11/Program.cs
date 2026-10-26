using System;
using Exercicio11.Services;

namespace Exercicio11
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Manipulação de Strings com Delegates Encadeados ===");

            string nome = LerTexto("Informe o nome: ");
            string sobrenome = LerTexto("Informe o sobrenome: ");

            // PARTE 1: delegate multicast com os três métodos encadeados
            Func<string, string, string> processar = TransformadorNome.Concatenar;
            processar += TransformadorNome.ConverterMaiusculas;
            processar += TransformadorNome.RemoverEspacos;

            Console.WriteLine("\n[PARTE 1] Invocando o delegate multicast:");
            string resultado = processar(nome, sobrenome);
            Console.WriteLine($"  Valor retornado pelo delegate: \"{resultado}\"");

            // PARTE 2: obtendo o retorno de cada método separadamente
            Console.WriteLine("\n[PARTE 2] Retorno de cada método da lista de invocação:");
            foreach (Func<string, string, string> metodo in processar.GetInvocationList())
            {
                string retorno = metodo(nome, sobrenome);
                Console.WriteLine($"    Retorno guardado de {metodo.Method.Name}: \"{retorno}\"");
            }

            // PARTE 3: pipeline de verdade (a saída de um vira entrada do outro)
            Func<string, string, string> concatenar = (n, s) => $"{n} {s}";
            Func<string, string> maiusculas = TransformadorNome.ParaMaiusculas;
            Func<string, string> semEspacos = TransformadorNome.SemEspacos;

            string pipeline = semEspacos(maiusculas(concatenar(nome, sobrenome)));

            Console.WriteLine("\n[PARTE 3] Pipeline encadeado (composição de funções):");
            Console.WriteLine($"  Resultado: \"{pipeline}\"");

            // Análise
            Console.WriteLine("\n=== Análise ===");
            Console.WriteLine("1. Todos os métodos do multicast são executados, na ordem em que foram adicionados.");
            Console.WriteLine("2. Cada método recebe os MESMOS argumentos originais (nome e sobrenome);");
            Console.WriteLine("   o resultado de um NÃO é repassado para o próximo.");
            Console.WriteLine("3. O delegate devolve apenas o retorno do ÚLTIMO método; os outros são descartados.");
            Console.WriteLine("4. Para obter todos os retornos, é preciso percorrer GetInvocationList().");
            Console.WriteLine("5. Para transformar em sequência, é preciso compor as funções (Parte 3).");
        }

        private static string LerTexto(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? entrada = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    return entrada;
                }

                Console.WriteLine("O valor não pode ficar vazio.");
            }
        }
    }
}