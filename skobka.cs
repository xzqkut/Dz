using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = " ";
            char openBracket = '(';
            char closeBracket = ')';

            Console.Write("Введите скобочное выражение:");
            input = Console.ReadLine();

            int depth = 0;
            int maxDepth = 0;

            foreach (char symbol in input)
            {
                if (symbol == openBracket)
                {
                    depth++;

                    if (depth > maxDepth)
                    {
                        maxDepth = depth;
                    }
                }
                else if (symbol == closeBracket)
                {
                    depth--;

                    if (depth < 0)
                    {
                        break;
                    }
                }
            }

            if (depth == 0)
            {
                Console.WriteLine($"Строка является корректным скобочным выражением, максимальная глубина: {maxDepth}");
            }
            else
            {
                Console.WriteLine("Некорректное скобочное выражение");
            }
        }
    }
}
