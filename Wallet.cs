﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace wallet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string CommandExit = "Exit";

            float rublesInWallet;
            float dollarInWallet;
            float euroInWallet;
            int usdToRub = 50, rubToUsd = 25, euToRub = 100, rubToEu = 20, euToUsd= 1, usdToEu = 2;
            float exchangeCurrencyCount;
            string disairedOperation;

            Console.WriteLine("Добро пожаловать в обменник валют!");
            Console.Write("Введите баланс рублей:");
            rublesInWallet=Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс евро:");
            euroInWallet=Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс долларов:");
            dollarInWallet=Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1-обменять рубли на доллары");
            Console.WriteLine("2-обменять доллары на рубли");
            Console.WriteLine("3-обменять рубли на евро");
            Console.WriteLine("4-обменять евро на рубли");
            Console.WriteLine("5-обменять евро на доллар");
            Console.WriteLine("6-обменять доллар на евро");
            Console.Write("Ваш выбор:");
            disairedOperation= Console.ReadLine();

            switch(disairedOperation)
            {
                case "1":
                    Console.WriteLine("Обмен рубли на доллары");
                    Console.WriteLine("Сколько вы хотиете обменять?");
                    exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                    if (rublesInWallet >= exchangeCurrencyCount)
                    {
                        rublesInWallet-=exchangeCurrencyCount;
                        dollarInWallet += exchangeCurrencyCount / rubToUsd;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое кол-во рублей");
                    }
                    break;

                    case "2":
                    Console.WriteLine("Обмен доллары на рубли");
                    Console.WriteLine("Сколько вы хотите обменять?");
                    exchangeCurrencyCount= Convert.ToSingle(Console.ReadLine());
                    if (dollarInWallet >= exchangeCurrencyCount)
                    {
                        dollarInWallet-=exchangeCurrencyCount;
                        rublesInWallet += exchangeCurrencyCount * usdToRub;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое кол-во долларов");
                    }

                    break;

                    case "3":
                    Console.WriteLine("Обмен рублей на евро");
                    Console.WriteLine("Сколько вы хотите обменять?");
                    exchangeCurrencyCount=Convert.ToSingle(Console.ReadLine());
                    if (rublesInWallet >= exchangeCurrencyCount)
                    {
                        rublesInWallet -= exchangeCurrencyCount;
                        euroInWallet += exchangeCurrencyCount / rubToEu;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое кол-во рублей");
                    }
                    break;

                    case "4":
                    Console.WriteLine("Обмен евро на рубли");
                    Console.WriteLine("Сколько вы хотите обменять?");
                    exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());
                    if (euroInWallet >= exchangeCurrencyCount)
                    {
                        euroInWallet-=exchangeCurrencyCount;
                        rublesInWallet += exchangeCurrencyCount/ euToRub;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое кол-во евро");
                    }
                    break;

                    case "5":
                    Console.WriteLine("Обмен евро на доллар");
                    Console.WriteLine("Сколько вы хотите обменять?");
                    exchangeCurrencyCount= Convert.ToSingle(Console.ReadLine());
                    if (euroInWallet >= exchangeCurrencyCount)
                    {
                        euroInWallet -= exchangeCurrencyCount;
                        dollarInWallet += exchangeCurrencyCount * euToUsd;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое кол-во евро");
                    }

                    break;

                        case "6":
                    Console.WriteLine("Обмен доллара на евро");
                    Console.WriteLine("Сколько вы хотите обменять?");
                     exchangeCurrencyCount=Convert.ToSingle(Console.ReadLine());
                    if (dollarInWallet >= exchangeCurrencyCount)
                    {
                        dollarInWallet -= exchangeCurrencyCount;
                        euroInWallet += exchangeCurrencyCount / usdToEu;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое кол-во долларов");
                    }
                    break;

                default: Console.WriteLine("Введена неверная операция.");
                    break;
            }
            Console.WriteLine($"Ваш баланс: {rublesInWallet} рублей, " + $"{dollarInWallet} долларов, " + $"{euroInWallet} евро");
           
            while (Console.ReadLine() == "Exit")
            {
                Console.WriteLine("Выход...");
                Console.WriteLine("Программа завершена");
            }
            
        }
    }
}
