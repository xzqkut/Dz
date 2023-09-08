using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomsg
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
            Random random = new Random();

            int lowrandom = 0;
            int highrandom = 101;
            int number= random.Next(lowrandom,highrandom);
            int divider1 = 3;
            int divider2 = 5;
            int sum=0;

            Console.WriteLine(number);
            Console.ReadKey();

            for (int i = 0; i <= number; i++)
            {
                if (i % divider1 == 0 || i % divider2 == 0)
                {
                    sum += i;
                    Console.WriteLine(i + "");
                }
            }
            Console.WriteLine(sum);
        }
    }
}
