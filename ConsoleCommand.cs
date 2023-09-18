using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCommand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandMenu1 = "SetName";
            const string CommandMenu2 = "SetPassword";
            const string CommandMenu3 = "WriteName";
            const string CommandMenu4 = "ConsoleColor";
            const string CommandMenu5 = "Exit";
            const int Red = 1;
            const int Green=2;
            const int Blue=3;   

            string enteredСommand = " ";
            string name = " ";
            string password = " ";
            string userInput;
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("////////////////////////////");
                Console.WriteLine(CommandMenu1 + "-Установить имя");
                Console.WriteLine(CommandMenu2 + "-Установить пароль");
                Console.WriteLine(CommandMenu3 + "-Вывести имя.");
                Console.WriteLine(CommandMenu4 + "-Цвет консоли");
                Console.WriteLine(CommandMenu5 + "-Выход");
                Console.WriteLine("//////////////////////////\n");
                Console.WriteLine("Введите команду из пункта меню");
                enteredСommand = Console.ReadLine();

                switch (enteredСommand)
                {
                    case CommandMenu1:
                        Console.Clear();
                        Console.WriteLine(CommandMenu1);
                        Console.Write("Введите имя:");
                        name = Console.ReadLine();
                        Console.WriteLine($"Здравствуйте {name}!Для продолжения нажмите Enter.");
                        Console.ReadKey();
                        break;

                    case CommandMenu2:
                        Console.Clear();
                        Console.WriteLine(CommandMenu2);
                        Console.WriteLine("Установите пароль:");
                        password = Console.ReadLine();
                        Console.WriteLine("Пароль установлен! Для продолжения нажмите Enter");
                        Console.ReadKey();
                        break;

                    case CommandMenu3:
                        Console.WriteLine(CommandMenu3);
                        Console.WriteLine("Введите пароль чтобы вывести имя:");
                        userInput = Console.ReadLine();

                        if (userInput != password)
                        {
                            Console.WriteLine("Неверный пароль.Доступ закрыт!");
                            Console.ReadKey();
                        }
                        else if (password == userInput)
                        {
                            Console.WriteLine($"Приветствую вас {name}");
                            Console.ReadKey();
                        }
                        break;

                    case CommandMenu4:
                        Console.WriteLine("Выбирите цвет: \n 1) Red \n 2) Green \n 3) Blue \n ");
                        int color = Int32.Parse(Console.ReadLine());
                        switch (color)
                        {
                            case Red:
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                break;

                            case Green:
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Clear();
                                break;

                            case Blue:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Clear();
                                Console.WriteLine("Цвет не найден.");
                                break;

                            default:
                                Console.WriteLine("Неверный выбор.");
                                break;   
                        }
                        break;

                    case CommandMenu5:
                        isRunning = false;
                        Console.WriteLine("Пока.");
                        break;

                    default:
                        Console.WriteLine("Неверный ввод");
                        break;


                }
            }
        }
    }
}
