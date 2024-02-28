using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7 };
            bool continueShuffling = true;

            ShuffleArray(array);

            while (continueShuffling)
            {
                Console.WriteLine("\nХотите еще раз перетасовать массив? (Да/нет)");
                string response = Console.ReadLine();

                if (response == "Да")
                {
                    ShuffleArray(array);
                }
                else if (response == "Нет")
                {
                    continueShuffling = false;
                }
                else
                {
                    Console.WriteLine("Неверный ответ. Пожалуйста, введите Да или Нет.");
                }
            }

            Console.WriteLine("Программа прекращена.");
        }

        static void ShuffleArray(int[] array)
        {
            Random random = new Random();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            Console.WriteLine("\nМассив перетасован:");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}

