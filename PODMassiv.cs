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
                numbers[i] = random.Next(1, 6);
            }

            Console.WriteLine("Сгенерированный массив: " + string.Join(" ", numbers));

            int currentNumber = numbers[0];
            int currentCount = 1;

            int maxNumber = currentNumber;
            int maxCount = currentCount;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == currentNumber)
                {
                    currentCount++;
                    if (currentCount > maxCount)
                    {
                        maxNumber = currentNumber;
                        maxCount = currentCount;
                    }
                }
                else
                {
                    currentNumber = numbers[i];
                    currentCount = 1;
                }
            }

            Console.WriteLine($" Число: {maxNumber}, Количество повторений: {maxCount}");
        }
    }
    
}

