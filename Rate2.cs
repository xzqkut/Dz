using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNumber = 1;
            int maxNumber = 1000;
            int result = 1;
            int basicRate = 2;
            int rate=0;

            Random random = new Random();
            int number= random.Next(minNumber, maxNumber);

            while (result < number)
            {
                rate++;
                result*=basicRate;
            }
            Console.WriteLine("Случайное число: " + number);
            Console.WriteLine("Нужная степень двойки: " + rate);
            Console.WriteLine("Число два в найденной степени: " + result);

        }
    }
}
