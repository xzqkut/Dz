using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberLine = 10;
            int numberColumn = 10;
            int[,] array = new int[numberLine, numberColumn];
            int maxNumber = 0;
            int FindingNumberColumns = numberColumn;
            int FindingNumberLine = numberLine;
            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int minimumElementArray = 10;
                    int maximumElementArray = 100;
                    array[i, j] = random.Next(minimumElementArray, maximumElementArray);
                    Console.Write(array[i, j] + " ");

                    if (maxNumber < array[i, j])
                    {
                        maxNumber = array[i, j];
                        FindingNumberColumns = i;
                        FindingNumberLine = j;
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Наибольший элемент матрицы: {maxNumber},число находится под рядом {FindingNumberColumns + 1}, в столбце {FindingNumberLine + 1}");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxNumber)
                    {
                        array[i, j] = 0;
                    }

                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

