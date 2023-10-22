using System;
using System.Collections.Generic;
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
            int[] tempArray = new int[array.Length + 1];
            bool isOpen = true;
            int sumArray = 0;
            string exitApp = "exit";
            string sumApp = "sum";


            Console.WriteLine($"Введите число, sum или exit.");

            while (isOpen)
            {
                string commandConsole = Console.ReadLine();

                if (commandConsole != exitApp && commandConsole != sumApp)
                {
                    int inputNumber = Convert.ToInt32(commandConsole);
                    lenghtArray += 1;
                    array = new int[lenghtArray];

                    for (int i = 0; i < tempArray.Length; i++)
                    {
                        array[i] = tempArray[i];
                    }
                    array[lenghtArray - 1] = inputNumber;
                    tempArray = new int[lenghtArray];
                    for (int i = 0; i < tempArray.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }
                    tempArray[lenghtArray - 1] = inputNumber;
                }
                else if (commandConsole == sumApp)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        sumArray += tempArray[i];
                        Console.WriteLine();
                    }
                    Console.WriteLine($"Сумма массива: {sumArray}");
                }
                else if (commandConsole == exitApp)
                {
                    isOpen = false;
                    Console.WriteLine("Досвидания.");
                }
                else Console.WriteLine("Такого сделать я не могу");

            }

        }

    }

}


