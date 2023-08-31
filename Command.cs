using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string exitCommand = "Exit";

            Console.WriteLine("Программа будет работать пока не введете Exit");
            userInput = string.Empty;

            while (Console.ReadLine() != exitCommand)
            {
                Console.WriteLine("Программа работает!");
            }
            Console.WriteLine("Программа завершена!");
        }
       
    }
}
