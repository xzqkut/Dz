using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            while (isOpen)
            {
                int money = clients.Dequeue();
                cash += money;

                Console.WriteLine($"{numberClients++} клиент сделал покупки на сумму {money} рублей.");
                Console.WriteLine($"В кассе - {cash} рублей.");
                Console.ReadKey();
                Console.Clear();
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
