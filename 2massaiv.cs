using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massiv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomMin = 1;
            int randomMax = 5;

            int[,] array = new int[2, 5];

            int rowNumber = 2;
            int columnNumber = 1;

            int lineSum = 0;
            int columnMultiplier = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(randomMin, randomMax);
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                lineSum += array[rowNumber - 1, i];
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                columnMultiplier *= array[i, columnNumber - 1];
            }

            Console.WriteLine($"\nСумма чисел {rowNumber} ряда: {lineSum}");
            Console.WriteLine($"\nПроизведение чисел {columnNumber} столбца: {columnMultiplier}");
            Console.ReadKey();

        }
    }
}