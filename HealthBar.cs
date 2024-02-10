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
            int percentHealth=40;
            int maxHealth =0;
            string symbolBar = "#";
            string nameBar = $"Шкала здоровья при {percentHealth}%\n";

            DrawBar(percentHealth, maxHealth, symbolBar, nameBar);
        }

        static void DrawBar(int percent, int maxValue, string symbol, string name)
        {
           maxValue = int.Parse(Console.ReadLine());
            int value = maxValue * percent / 100;
            string quantitySymbols = "";

            if (percent >= 0 && percent <= 100)
            {
                for (int i = 0; i < value; i++)
                {
                    quantitySymbols += symbol;
                }

                Console.Write($"{name} [{quantitySymbols}");

                symbol = " ";
                quantitySymbols = "";

                for (int i = value; i < maxValue; i++)
                {
                    quantitySymbols += symbol;
                }

                Console.Write($"{quantitySymbols}]");
            }
            else
            {
                Console.WriteLine("Исходные данные некорректные");
            }

            Console.ReadKey();
        }
    }
}
    

