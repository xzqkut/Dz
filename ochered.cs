using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> clients = FillClients();

            int cash = 0;
            int numberClients = 1;

            bool isOpen = true;

            while (isOpen&&clients.Count>=0)
            {
                int money = clients.Dequeue();
                cash += money;

                Console.WriteLine($"{numberClients++} клиент сделал покупки на сумму {money} рублей.");
                Console.WriteLine($"В кассе - {cash} рублей.");
                Console.ReadKey();
                Console.Clear();

                if (clients.Count == 0)
                {
                    isOpen = false;
                    Console.WriteLine("Программа завершена, очередь кончилась");
                }
            }
        }

        static Queue<int> FillClients()
        {
            Queue<int> clients = new Queue<int>();
            Random random = new Random();
            int maxValue = 2000;

            Console.WriteLine("Введите количество клиентов в очереди: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int number))
            {
                for (int i = 0; i < number; i++)
                {
                    clients.Enqueue(random.Next(maxValue));
                }
            }
           
            return clients;
        }
    }
}
