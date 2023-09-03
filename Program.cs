using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomsg
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Random rand = new Random();

            int minValue=0;
            int maxValue=101;
            int number= rand.Next(minValue,maxValue);
            int sum = number;
            int multiplicityOfNumbers1 = 3;
            int multiplicityOfNumbers2 = 5;
            Console.WriteLine(number);

            for(int i = 0;i<number; i++)
            {
                if (i % multiplicityOfNumbers1 ==0 || i % multiplicityOfNumbers2 == 0)
                {
                    sum += i;

                    Console.WriteLine(i+" ");
                }
            }
            Console.WriteLine(sum);



        }
    }
}
