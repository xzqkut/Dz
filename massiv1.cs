using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace massiv1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberLine = 10;
            int numberColumn = 10;
            int[,] array = new int[numberLine, numberColumn];
            int maxNumber = int.MinValue;
            int markChange = 0;
            int minimumElementArray = 10;
            int maximumElementArray = 100;

            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minimumElementArray, maximumElementArray);
                    Console.Write(array[i, j] + " ");

                    if (maxNumber < array[i, j])
                    {
                        maxNumber = array[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Наибольший элемент матрицы: {maxNumber}");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxNumber)
                    {
                        array[i, j] = markChange;
                    }

                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

