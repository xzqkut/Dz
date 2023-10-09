using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
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

            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i] = random.Next(minValue, maxValue);
                Console.Write(array[i] + " ");
                initialArray += Convert.ToString(array[i] + " ");

                if ((i == array.GetLength(0) - 1) && (array[0] > array[1]))
                {
                    localMaximaArray += array[0] + " ";
                }

                if (i == array.GetLength(0) - 1)
                {

                    for (int j = 1; j < array.GetLength(0) - 1; j++)
                    {

                        if (array[j] > array[j + 1] && array[j] > array[j - 1])
                        {
                            localMaximaArray += array[j] + " ";

                        }

                    }

                    if ((i == array.GetLength(0) - 1) && (array[array.GetLength(0) - 1] > array[array.GetLength(0) - 2]))
                    {
                        localMaximaArray += "" + array[array.GetLength(0) - 1];
                    }

                }

                Console.WriteLine("Исходный массив " + "\n" + initialArray);
                Console.WriteLine($"Локальные максимумы: {localMaximaArray}");
                Console.WriteLine($"Длина массива {array.GetLength(0)} ");

            }
        }
    }


