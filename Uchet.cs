using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    internal class Program
    {

        private const int AddDossierCommand = 1;
        private const int PrintDossiersCommand = 2;
        private const int DeleteDossierCommand = 3;
        private const int SearchByLastNameCommand = 4;
        private const int ExitCommand = 5;

        private static string[] names = new string[0];
        private static string[] positions = new string[0];

        static void Main()
        {
            int choice;
            bool isOpen = true;
            while (isOpen)
            {
                PrintMenu();

                Console.Write("Выберите действие (1-5): ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case AddDossierCommand:
                        AddDossier();
                        break;
                    case PrintDossiersCommand:
                        PrintDossiers();
                        break;
                    case DeleteDossierCommand:
                        DeleteDossier();
                        break;
                    case SearchByLastNameCommand:
                        SearchByLastName();
                        break;
                    case ExitCommand:
                        ExitProgram();
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine($"{AddDossierCommand}. Добавить досье");
            Console.WriteLine($"{PrintDossiersCommand}. Вывести все досье");
            Console.WriteLine($"{DeleteDossierCommand}. Удалить досье");
            Console.WriteLine($"{SearchByLastNameCommand}. Поиск по фамилии");
            Console.WriteLine($"{ExitCommand}. Выход");
        }

        private static void AddDossier()
        {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            Array.Resize(ref names, names.Length + 1);
            Array.Resize(ref positions, positions.Length + 1);

            names[names.Length - 1] = name;
            positions[positions.Length - 1] = position;

            Console.WriteLine("Досье успешно добавлено.");
        }

        private static void PrintDossiers()
        {
            if (names.Length == 0)
            {
                Console.WriteLine("Досье пусто.");
                return;
            }

            Console.WriteLine("Все досье:");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]} - {positions[i]}");
            }
        }

        private static void DeleteDossier()
        {
            if (names.Length == 0)
            {
                Console.WriteLine("Досье пусто. Удаление невозможно.");
                return;
            }

            Console.Write("Введите порядковый номер досье для удаления: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= names.Length)
            {
                Console.WriteLine("Некорректный номер досье.");
                return;
            }

            for (int i = index; i < names.Length - 1; i++)
            {
                names[i] = names[i + 1];
                positions[i] = positions[i + 1];
            }

            Array.Resize(ref names, names.Length - 1);
            Array.Resize(ref positions, positions.Length - 1);

            Console.WriteLine("Досье успешно удалено.");
        }

        private static void SearchByLastName()
        {
            if (names.Length == 0)
            {
                Console.WriteLine("Досье пусто.");
                return;
            }

            Console.Write("Введите фамилию для поиска: ");
            string lastName = Console.ReadLine().ToLower();
            bool haveFound = false;

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower().StartsWith(lastName))
                {
                    Console.WriteLine($"Найдено досье: {names[i]} - {positions[i]}");
                    haveFound = true;
                }
            }

            if (haveFound==false)
            {
                Console.WriteLine($"Досье с фамилией '{lastName}' не найдено.");
            }
        }

        private static void ExitProgram()
        {
            Console.WriteLine("Выход из программы.");
           
        }
    }
}
    

