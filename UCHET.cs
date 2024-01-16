using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class Program
    {
        private const int AddDossierCommand = 1;
        private const int PrintDossiersCommand = 2;
        private const int DeleteDossierCommand = 3;
        private const int SearchByLastNameCommand = 4;
        private const int ExitCommand = 5;

        static void Main(string[] args)
        {
            string[] names = new string[0];
            string[] positions = new string[0];
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
                        AddDossier(ref names,ref positions);
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

        private static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine($"{AddDossierCommand}. Добавить досье");
            Console.WriteLine($"{PrintDossiersCommand}. Вывести все досье");
            Console.WriteLine($"{DeleteDossierCommand}. Удалить досье");
            Console.WriteLine($"{SearchByLastNameCommand}. Поиск по фамилии");
            Console.WriteLine($"{ExitCommand}. Выход");
        }

        static void AddDossier(ref string[] names,ref string[] positions)
        {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите должность: ");
            string position = Console.ReadLine();

            IncreaseArray(names,name);
            IncreaseArray( positions, position);
            names =IncreaseArray(names,name);
            positions=IncreaseArray(positions,position);
            Console.WriteLine("Досье успешно добавлено.");
           
        }

        private static string[] IncreaseArray( string[] array, string text)
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

        private static void PrintDossiers(string[] names,string [] positions)
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

        private static void DeleteDossier( ref string[] names, ref string[] positions)
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

        private static string[] DecreaseArray(string[] array, int index)
        {
            int length = array.Length;
            string[] tempArray = new string[length - 1];
           
            for (int i = 0; i<index; i++)
            { 
                    tempArray[i] = array[i];   
            }
            for (int i = index; i < array.Length - 1; i++)
            {
                tempArray[i] = array[i+1];
            }
            array= tempArray;
            return tempArray;
        }

        private static void SearchByLastName(string[] names,string[] positions)
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
                if (split[0].ToLower().StartsWith(lastName))
                {
                    Console.WriteLine($"Найдено досье: {names[i]} - {positions[i]}");
                    haveFound = true;
                }
            }

            if (haveFound == false)
            {
                Console.WriteLine($"Досье с фамилией '{lastName}' не найдено.");
            }
        }
    }
}
