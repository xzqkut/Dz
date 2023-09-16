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
            int maxNumberToCheck = 1000;
            int minNumberToCheck = 100;
            int numberN;
            Random random = new Random();
            int counter = 0;

            numberN = random.Next(startNumber, endNumber);
            Console.WriteLine($"Число N = {numberN}");
            for (int i = 1; i < maxNumberToCheck; i += numberN)
            {
                if (i >= minNumberToCheck)
                {
                    counter++;
                }
            }
            Console.WriteLine($"Трехзначных чисел кратных N - {counter}");
        }
    }
}
