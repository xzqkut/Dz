using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] array  =  { 1, 2, 3, 4, 5, 6, 7 };
            ShuffleArray(array);
        }

        static void ShuffleArray(int[] array)
        {
            Random random = new Random();

            int randomValue;
            int shuffleElement;

                for(int i = array.Length - 1; i >= 0; i--)
            {
                randomValue = random.Next(array[i]);
                shuffleElement = array[randomValue];
                
                Console.Write(shuffleElement+ " ");
            }
        }

    }
}
