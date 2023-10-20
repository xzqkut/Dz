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
            Random random = new Random();

            int elementsArray = 30;
            int[] array = new int[elementsArray];
            int firstNumberOption = 2;
            int secondNumberOption = 5;
            int maxLength = 0;
            int temporaryRepeatNumber = 0;
            int repetitionsNumber = 0;
            int repeatNumber = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = random.Next(firstNumberOption, secondNumberOption);
                Console.WriteLine($"{array[i]}");
            }
            Console.WriteLine();

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    repetitionsNumber++;
                    temporaryRepeatNumber = array[i];
                }

                else
                {
                    repetitionsNumber = 0;
                }

                if (maxLength < repetitionsNumber)
                {
                    maxLength = repetitionsNumber;
                    repeatNumber = temporaryRepeatNumber;
                }
            }

            if (maxLength > repetitionsNumber)
            {
                Console.WriteLine($"Число {repeatNumber} потворяется {maxLength + 1} раз подряд");
            }

            else
            {
                Console.WriteLine("Нет повторяемых подряд чисел");
            }
        }
    }
}
