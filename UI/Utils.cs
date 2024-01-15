using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sistema.UI
{
    public abstract class GeneralUtils
    {
        protected static T ReceberValor<T>(string NomeDoTipo)
        {
            var tipoEsperado = typeof(T);

            do
            {
                Console.WriteLine($"Por favor, insira um valor do tipo {NomeDoTipo}:");
                var input = Console.ReadLine();

                try
                {
                    T valor = (T)Convert.ChangeType(input, tipoEsperado);
                    Console.Clear();
                    return valor;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Erro: Valor inserido não é do tipo {NomeDoTipo}.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (InvalidCastException)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Erro: Não é possível converter para o tipo {NomeDoTipo}.");
                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (true);
        }
        protected static T[] ReceberArray<T>(string NomeDoTipo)
        {
            Console.WriteLine($"Por favor, insira o tamanho do array de {NomeDoTipo}: \n");
            int arrayLength = ReceberValor<int>("Inteiro");

            T[] array = new T[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                do
                {
                    Console.WriteLine($"Por favor, insira o valor {i + 1} do array de {NomeDoTipo}:");
                    var input = Console.ReadLine();

                    try
                    {
                        array[i] = (T)Convert.ChangeType(input, typeof(T));
                        Console.Clear();
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Erro: Valor inserido não é do tipo {NomeDoTipo}.");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (InvalidCastException)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Erro: Não é possível converter para o tipo {NomeDoTipo}.");
                        Console.ResetColor();
                        Console.ReadKey();
                        Console.Clear();
                    }

                } while (true);
            }

            return array;
        }
        public abstract void DoCalculations();

        protected static void PrintArray<T>(T[] array)
        {
            var stringBuilder = new StringBuilder("O array é\n");
            Array.ForEach(array, element => stringBuilder.AppendLine(element.ToString()));
            Console.WriteLine(stringBuilder);
        }



        protected static void GoOn(string question = null)
        {
            Console.WriteLine();
            Console.WriteLine(question == null ? "Aperte qualquer tecla para continuar..." : $"{question}");
            Console.ReadLine();
            Console.Clear();
        }

        protected static bool ReadYesOrNo(string question)
        {
            Console.WriteLine();
            Console.WriteLine($"{question}? (s/n)");

            while (true)
            {
                string input = Console.ReadLine()?.ToLower();

                if (Regex.IsMatch(input, "^(s(im)?|n(ao|ão)|n(ao)?o?)$")) return input.StartsWith("s");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada inválida.");
                Console.ResetColor();

                Console.WriteLine($"{question} ? (s / n)");
                Console.WriteLine();
            }
        }

        public static int ReadOption(int min, int max)
        {
            bool valid = false;
            int number = 0;

            while (!valid)
            {
                Console.WriteLine();
                Console.WriteLine("Digite uma opção: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    if (number >= min && number <= max) valid = true;
                    else
                    {
                        Console.WriteLine($"Digite um número entre {min} e {max}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite um número válido");
                    Console.ResetColor();
                }

            }

            return number;
        }


    }
}
