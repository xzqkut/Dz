using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputAttempts = 3;

            string password = "drwoswir123";

            Console.WriteLine("Введите пароль чтобы прочитать скрытое сообщение. ");

            for (int i = 0; i < inputAttempts; i++)
            {
                Console.WriteLine("Введите пароль: ");
                string userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine("Скрытое сообщение: Хорошего вам дня!");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный пароль");
                    Console.WriteLine("У вас осталось " + (inputAttempts - (i + 1)) + " попыток");
                }
            }
        }
    }
}
