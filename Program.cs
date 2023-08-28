using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalAmountMessage;

            Console.WriteLine("Введите количество сообщений:");
            totalAmountMessage = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < totalAmountMessage; i++)
            {
                Console.WriteLine("Привет,желаю тебе хорошего дня!");
            }
        }
    }
}
