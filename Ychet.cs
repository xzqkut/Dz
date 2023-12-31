using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ychet
{
    using System;
    using System.Collections.Generic;

    class DossierProgram
    {
        const int AddDossierCommand = 1;
        const int PrintDossiersCommand = 2;
        const int DeleteDossierCommand = 3;
        const int SearchByLastNameCommand = 4;
        const int ExitCommand = 5;

        static List<string> names = new List<string>();
        static List<string> positions = new List<string>();

        static void Main()
        {
            int choice;

            while (true)
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

            names.Add(name);
            positions.Add(position);

            Console.WriteLine("Досье успешно добавлено.");
        }

       private  static void PrintDossiers()
        {
            if (names.Count == 0)
            {
                Console.WriteLine("Досье пусто.");
                return;
            }

            Console.WriteLine("Все досье:");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]} - {positions[i]}");
            }
        }

        private static void DeleteDossier()
        {
            if (names.Count == 0)
            {
                Console.WriteLine("Досье пусто. Удаление невозможно.");
                return;
            }

            Console.Write("Введите порядковый номер досье для удаления: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= names.Count)
            {
                Console.WriteLine("Некорректный номер досье.");
                return;
            }

            names.RemoveAt(index);
            positions.RemoveAt(index);

            Console.WriteLine("Досье успешно удалено.");
        }

        private static void SearchByLastName()
        {
            if (names.Count == 0)
            {
                Console.WriteLine("Досье пусто.");
                return;
            }

            Console.Write("Введите фамилию для поиска: ");
            string lastName = Console.ReadLine().ToLower();

            bool found = false;
            for (int i = 0; i < names.Count; i++)
            {
                if (names[i].ToLower().StartsWith(lastName))
                {
                    Console.WriteLine($"Найдено досье: {names[i]} - {positions[i]}");
                    found = true;
                }
            }

            if (!found)
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

