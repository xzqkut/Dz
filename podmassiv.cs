using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 30;
            int minRandomValue = 1;
            int maxRandomValue = 6;
            int[] numbers = new int[arraySize];

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minRandomValue, maxRandomValue);
            }

            Console.WriteLine("\nСгенерированный массив:");
            Console.WriteLine(string.Join(" ", numbers));

            if (numbers.Length == 0)
            {
                Console.WriteLine("Массив пустой");
                return;
            }

            int mostFrequentNumber = numbers[0];
            int mostFrequentCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int count = 0;

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] == numbers[i])
                    {
                        count++;
                    }
                }

                if (count > mostFrequentCount)
                {
                    mostFrequentCount = count;
                    mostFrequentNumber = numbers[i];
                }
            }

            Console.WriteLine($"\nЧисло, встречающееся чаще всего: {mostFrequentNumber}, Количество вхождений: {mostFrequentCount}");
        }
    }
}


