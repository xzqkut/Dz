using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace massiv5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int arraySize = 10;
            int[] numsArray = new int[arraySize];
            int minValue = 1;
            int maxValue = 11;

            for (int i = 0; i < numsArray.Length ; i++)
            {
                for (int j = i; j < numsArray.Length; j++)
                {
                    numsArray[i] = rand.Next(minValue, maxValue);
                }
            }

            for (int i =0; i < numsArray.Length-1 ;i++)
            {
                for(int j = i+1; j < numsArray.Length; j++)
                {
                    if (numsArray[i] > numsArray[j])
                    {
                        int tempArray = numsArray[i];
                        numsArray[i] = numsArray[j];
                        numsArray[j] = tempArray;
                    }
                }
            }

            Console.WriteLine("Вывод отсортированного массива: ");

            for (int i = 0; i < numsArray.Length; i++)
            {
                Console.WriteLine($"{numsArray[i]}" + " ");
            }
            Console.WriteLine();
        }
    }
}
