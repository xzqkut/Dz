using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace UCHET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int AddDossierCommand = 1;
            const int PrintDossiersCommand = 2;
            const int DeleteDossierCommand = 3;
            const int SearchByLastNameCommand = 4;
            const int ExitCommand = 5;

            string[] names = new string[0];
            string[] positions = new string[0];
            int choice;
            bool isOpen = true;

            while (isOpen)
            {
                PrintMenu(AddDossierCommand, PrintDossiersCommand, DeleteDossierCommand, SearchByLastNameCommand, ExitCommand);

                Console.Write($"Выберите действие ({AddDossierCommand}-{ExitCommand}): ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case AddDossierCommand:
                        AddDossier(ref names, ref positions);
                        break;

                    case PrintDossiersCommand:
                        PrintDossiers(names, positions);
                        break;

                    case DeleteDossierCommand:
                        DeleteDossier(ref names, ref positions);
                        break;

                    case SearchByLastNameCommand:
                        SearchByLastName(names, positions);
                        break;

                    case ExitCommand:
                        isOpen = false;
                        Console.WriteLine("Выход.");
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                        break;
                }
            }
        }

        static void PrintMenu(int AddDossierCommand, int PrintDossiersCommand, int DeleteDossierCommand, int SearchByLastNameCommand, int ExitCommand)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine($" {AddDossierCommand}. Добавить досье");
            Console.WriteLine($"{PrintDossiersCommand}. Вывести все досье");
            Console.WriteLine($"{DeleteDossierCommand}. Удалить досье");
            Console.WriteLine($"{SearchByLastNameCommand}. Поиск по фамилии");
            Console.WriteLine($"{ExitCommand}. Выход");
        }

        static void AddDossier(ref string[] names, ref string[] positions)
        {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            names = AddData(names, name);
            positions = AddData(positions, position);

            Console.WriteLine("Досье успешно добавлено.");
        }

        static string[] AddData(string[] array, string text)
        {
            int length = array.Length;
            string[] tempArray = new string[length + 1];

            for (int i = 0; i < length; i++)
            {
                tempArray[i] = array[i];
            }
                
            tempArray[length] = text;
            array = tempArray;
            return array;
        }

        static void PrintDossiers(string[] names, string[] positions)
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

        static void DeleteDossier(ref string[] names, ref string[] positions)
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

            names = DecreaseArray(names, index);
            positions = DecreaseArray(positions, index);

            Console.WriteLine("Досье успешно удалено.");
        }

        static string[] DecreaseArray(string[] array, int index)
        {
            int length = array.Length;
            string[] tempArray = new string[length - 1];

            for (int i = 0; i < index; i++)
            {
                tempArray[i] = array[i];
            }
            for (int i = index; i < array.Length - 1; i++)
            {
                tempArray[i] = array[i + 1];
            }
            return tempArray;
        }

        static void SearchByLastName(string[] names, string[] positions)
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
                string[] split = names[i].Split(' ');
                if (split[0].ToLower() == lastName)
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
    }
}