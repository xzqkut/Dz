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
            int inputUser;
            int[] array = new int[4] { 1, 2, 3, 4 };
            int tempNumber;
            int shift;

            Console.Write("Дан массив чисел: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.Write("\nНасколько позиций циклически сдвинуть массив влево? Введите число: ");
            inputUser = Convert.ToInt32(Console.ReadLine());

            shift = inputUser % array.Length;

            for (int i = 0; i < shift; i++)
            {
                Console.Clear();
                Console.Write("Измененный массив: ");

                tempNumber = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];

                    Console.Write(array[j] + " ");
                }

                array[array.Length - 1] = tempNumber;

                Console.Write(array[array.Length - 1]);
                Console.ReadKey();
            }
        }
    }
}
