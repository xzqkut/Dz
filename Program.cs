using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numberOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 5;
            int step = 7;
            int amountOfNumber = 14;

            for(int i = 0; i<amountOfNumber; i++)
            {
                int currentNumber = startNumber + i * step;
                Console.WriteLine(currentNumber);
            }


        }
    }
}
