using System;
using System.Collections.Generic;

namespace DinamMass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            List<int> numbers = new List<int>();
            string userInput;
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine($"{CommandSum}-сложить числа пользователя.\n{CommandExit}-Выход.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSum:
                        ShowSum(numbers);
                        break;
                    case CommandExit:
                        isOpen = false;
                        break;
                    default:
                        AddNumber(userInput, numbers);
                        break;
                }
            }
        }

        static void ShowSum(List<int> numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"Сумма всех чисел-{sum}");
        }

        static void AddNumber(string userInput, List<int> numbers)
        {
            if (int.TryParse(userInput, out int number))
            {
                numbers.Add(number);
            }
        }
    }
}
