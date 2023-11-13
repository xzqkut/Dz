using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skobka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = " ";
            input = Console.ReadLine();

            int depth = 0; 
            int maxDepth = 0; 

            foreach (char symbol in input)
            {
                if (symbol == '(')
                {
                    depth++; 
                    if (depth > maxDepth)
                    {
                        maxDepth = depth;
                    }
                }

                else if (symbol == ')')
                {
                    if (depth > 0)
                    {
                        depth--;
                    }
                    else
                    {
                        
                        Console.WriteLine("Некорректное скобочное выражение");
                        return;
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
