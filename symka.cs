using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace symka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenghtArray = 0;
            int[] array = new int[lenghtArray];

            bool isOpen = true;

            string commandExit = "exit";
            string commandSum = "sum";

            while (isOpen)
            {
                Console.Clear();

                Console.Write($"[ ");

                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i]} ");
                }

                Console.WriteLine($" ]");

                Console.WriteLine($"Введите число, {commandSum} или {commandExit}.");
                string commandConsole = Console.ReadLine();

                if (commandConsole == commandExit)
                {
                    Console.WriteLine("До свидания!");
                    isOpen = false;
                }
                else if (commandConsole == commandSum)
                {
                    int sumArray = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        sumArray += array[i];
                    }

                    Console.WriteLine($"Сумма массива {sumArray}");
                    Console.ReadKey();
                }
                else
                {
                    if (int.TryParse(commandConsole, out int number))
                    {
                        int[] tempArray = new int[array.Length + 1];

                        for (int i = 0; i < array.Length; i++)
                        {
                            tempArray[i] = array[i];
                        }

                        tempArray[tempArray.Length - 1] = number;
                        array = tempArray;
                    }
                }
            }
        }
    }
}





