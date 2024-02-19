using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadINt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumber();

            Console.WriteLine($"Символ {number} соответствует числу\n Программа завершена.");
            Console.ReadKey();

        }

        static int GetNumber()
        {
            int number = 0;
            bool isOpenProgram = true;

            while (isOpenProgram)
            {
                Console.WriteLine("Введите число: ");

                string inputNumber = Console.ReadLine();

                if (int.TryParse(inputNumber, out number))
                {
                    isOpenProgram = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введеное значение не является числом");
                }

            }

            return number;
        }
    }
}

