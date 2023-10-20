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
            int[] nums = new int[arraySize];
            int minValue = 1;
            int maxValue = 11;


            for (int i = 0; i < nums.Length ; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    nums[i] = rand.Next(minValue, maxValue);
                }
            }

            for (int i =0; i < nums.Length-1 ;i++)
            {
                for(int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        int temp = nums[i];

                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            Console.WriteLine("Вывод отсортированного массива: ");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"{nums[i]}" + " ");

            }
            Console.WriteLine();
        }
    }
}
