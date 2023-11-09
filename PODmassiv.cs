using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            
            int[] numbers = new int[30];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 5);
            }

            Console.WriteLine("Сгенерированный массив:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);
                if (i < numbers.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();

            int currentNumber = numbers[0];
            int currentCount = 1;

            int maxNumberRepeat = currentNumber;
            int maxCount = currentCount;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == currentNumber)
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > maxCount)
                    {
                        maxNumberRepeat = currentNumber;
                        maxCount = currentCount;
                    }

                    currentNumber = numbers[i];
                    currentCount = 1;
                }
            }

            
            if (currentCount > maxCount)
            {
                maxNumberRepeat = currentNumber;
                maxCount = currentCount;
            }

          
            Console.Write("Самый длинный подмассив: ");
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(maxNumberRepeat);
                if (i < maxCount - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine($", Число: {maxNumberRepeat}, Количество повторений: {maxCount}");
        }
    }
}

