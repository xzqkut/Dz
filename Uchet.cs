using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchetKadrov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDosier = "1";
            const string CommandShowDosier = "2";
            const string CommandRemoveDosier = "3";
            const string CommandExit = "4";

            List<string> employeeDetails = new List<string>();
            List<string> positions = new List<string>();
            string userInput;
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine($"{CommandAddDosier}- добавить досье\n{CommandShowDosier}-показать досье\n{CommandRemoveDosier}-удалить досье\n{CommandExit}-Выход");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddDosier:
                        AddDossier(employeeDetails, positions);
                        break;

                    case CommandRemoveDosier:
                        RemoveDossier(employeeDetails, positions);
                        break;

                    case CommandShowDosier:
                        ShowDossiers(employeeDetails, positions);
                        break;

                    case CommandExit:
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Неверный ввод");
                        break;

                }
            }
        }

        static void AddDossier(List<string> employeeDetails, List<string> positions)
        {
            char symbol = ' ';

            Console.WriteLine("Введите фамилию: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();

            Console.WriteLine("Введите отчество: ");
            string patronymic = Console.ReadLine();

            Console.WriteLine("Введите должность: ");
            string position = Console.ReadLine();

            string entireData = surname + symbol + name + symbol + patronymic;

            employeeDetails.Add(entireData);
            positions.Add(position);

        }

        static void RemoveDossier(List<string> positions, List<string> employeeDetails)
        {
            if (positions.Count > 0)
            {
                Console.WriteLine("Введите индекс сотрудника для удаления:");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int id))
                {
                    if (id >= 0 && id < employeeDetails.Count)
                    {
                        employeeDetails.RemoveAt(id);
                        positions.RemoveAt(id);
                    }
                    else
                    {
                        Console.WriteLine("Неверный индекс.");
                    }
                }
            }
        }

        static void ShowDossiers(List<string> employeeDetails, List<string> positions)
        {
            if (employeeDetails.Count > 0)
            {
                for (int i = 0; i < employeeDetails.Count; i++)
                {
                    Console.Write($"{i}) Фио - {employeeDetails[i]}, должность {positions[i]}");
                    Console.WriteLine();
                }
            }
        }
    }
}
