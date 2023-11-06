using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace massiv3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            Random random = new Random();
            int minValue = 1;
            int maxValue = 11;
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }

            int currentNumber = array[0];
            int currentCount = 1;
            int maxNumber = array[0];
            int maxCount = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                    currentNumber = array[i];
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxNumber = currentNumber;
                }
            }

            Console.WriteLine("Сгенерированный массив:");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Самый длинный подмассив:");
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(maxNumber + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Число, которое самое больше раз повторяется подряд: " + maxNumber);
            Console.WriteLine("Количество повторений: " + maxCount);
        }
    }
}
