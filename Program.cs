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
            int loverNumber = 5;
            int step = 7;
            int upperNumber = 100;

            for (int i = loverNumber; i<upperNumber; i+=step)
            {
                Console.WriteLine(i+" ");
            }
        }
    }
}
