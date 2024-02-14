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
            int minimumSamplePercent = 0;
            int maximumSamplePercent = 100;

            Console.WriteLine($"Введите процент здоровья (от {minimumSamplePercent} до {maximumSamplePercent}): ");

            if (int.TryParse(Console.ReadLine(), out int percentHealth))
            {
                string symbolBar = "#";
                string nameBar = $"Шкала здоровья при {percentHealth}%\n";
                int maxValue = 20;

                DrawBar(percentHealth, symbolBar, nameBar, maxValue);
            }
            else
            {
                Console.WriteLine($"Некорректный ввод. Пожалуйста, введите число от {minimumSamplePercent} до {maximumSamplePercent}.");
            }

        }
        static void DrawBar(int percent, string symbol, string name, int maxValue)
        {
            int selectedDivisor = 100;
            int value = maxValue * percent / selectedDivisor;
            string quantitySymbols = GenerateSymbolString(symbol, value);

            if (percent >= 0 && percent <= selectedDivisor)
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

