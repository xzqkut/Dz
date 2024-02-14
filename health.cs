using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите процент здоровья (от 0 до 100): ");

            if (int.TryParse(Console.ReadLine(), out int percentHealth))
            {
                string symbolBar = "#";
                string nameBar = $"Шкала здоровья при {percentHealth}%\n";
                int maxValue = 20;

                DrawBar(percentHealth, symbolBar, nameBar, maxValue);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 0 до 100.");
            }

        }
        static void DrawBar(int percent, string symbol, string name, int maxValue)
        {
            int isDivisor = 100;
            int value = maxValue * percent / isDivisor;
            string quantitySymbols = GenerateSymbolString(symbol, value);

            if (percent >= 0 && percent <= isDivisor)
            {
                Console.Write($"{name} [{quantitySymbols}");

                string emptySymbol = " ";
                string emptySymbols = GenerateSymbolString(emptySymbol, maxValue - value);
                
                Console.Write($"{emptySymbols}]");
            }
            else
            {
                Console.WriteLine("Исходные данные некорректные");
            }

            Console.ReadKey();
        }

        static string GenerateSymbolString(string symbol, int length)
        {
            string symbolString = "";

            for (int i = 0; i < length; i++)
            {
                symbolString += symbol;
            }

            return symbolString;
        }
    }
}  

