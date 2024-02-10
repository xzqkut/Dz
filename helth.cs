using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthBAR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int percentHealth = 40;
            string symbolBar = "#";
            string nameBar = $"Шкала здоровья при {percentHealth}%\n";

            DrawBar(percentHealth, symbolBar, nameBar);
        }

        static void DrawBar(int percent, string symbol, string name)
        {
            int maxValue = int.Parse(Console.ReadLine());
            int isDivisor = 100;
            int value = maxValue * percent / isDivisor;
            string quantitySymbols = "";

            if (percent >= 0 && percent <= isDivisor)
            {
                for (int i = 0; i < value; i++)
                {
                    quantitySymbols += symbol;
                }

                Console.Write($"{name} [{quantitySymbols}");

                symbol = " ";
                quantitySymbols = "";

                DrawSymbol(value, maxValue, quantitySymbols, symbol);

            }
            else
            {
                Console.WriteLine("Исходные данные некорректные");
            }

            Console.ReadKey();
        }
        static void DrawSymbol(int value, int maxValue, string quantitySymbols, string symbol)
        {
            for (int i = value; i < maxValue; i++)
            {
                quantitySymbols += symbol;
            }

            Console.Write($"{quantitySymbols}]");

        }
    }
}


