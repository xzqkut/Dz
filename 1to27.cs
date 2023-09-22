using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1to27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 1;
            int endNumber = 27;
            int maxRange = 1000;
            int minRange = 100;
            int numberN;
            Random random = new Random();
            int counter = 0;

            numberN = random.Next(startNumber, endNumber+1);
            Console.WriteLine($"Число N = {numberN}");
            
            for (int i = 1; i < maxRange; i += numberN)
            {
                if (i >= minRange)
                {
                    counter++;
                }
            }

            Console.WriteLine($"Трехзначных чисел кратных N - {counter}");
        }
    }
}
