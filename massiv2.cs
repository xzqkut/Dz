using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace massiv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string initialArray = "";
            string localMaximaArray = "";

            int[] array = new int[30];
            int minValue = 1;
            int maxValue = 10;
            int lastIndex = array.Length - 1;
            int lastButNotLeast = array.Length - 2;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
                initialArray += Convert.ToString(array[i] + " ");
            }

            if (array[0] > array[1])
            {
                localMaximaArray += array[0] + " ";
            }

            for (int i = 1; i < lastIndex; i++)
            {
                if (array[i] > array[i + 1] && array[i] > array[i - 1])
                {
                    localMaximaArray += array[i] + " ";
                }
            }

            if (array[lastIndex] > array[array.Length - lastButNotLeast])
            {
                localMaximaArray += "" + array[lastIndex];
            }

            Console.WriteLine($"\n\nИсходный массив {initialArray}");
            Console.WriteLine($"Локальные максимумы: {localMaximaArray}");
            Console.WriteLine($"Длина массива {array.Length} ");
        }
    }
}

