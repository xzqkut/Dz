using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletRUBUSDEUR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandExit = "Exit";
            const float rubInUSD = 100f;
            const float rubInEu = 115f;
            const float usdInRub = 0.01f;
            const float usdInEu = 1.8f;
            const float euInRub = 0.02f;
            const float euInUSD = 2f;
            const string CommandConvertRubInUsd = "1";
            const string CommandConvertUsdInRub = "2";
            const string CommandConvertRubInEur = "3";
            const string CommandConvertEurInRub = "4";
            const string CommandConvertEurInUsd = "5";
            const string CommandConvertUsdInEur = "6";

            float rubInWallet;
            float euInWallet;
            float usdInWallet;
            float exchangeCurrencyCount;
            string disairedOperation = " ";

            Console.WriteLine("Добро пожаловать в обменник валют!");
            Console.Write("Введите баланс рублей:");
            rubInWallet = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс евро:");
            euInWallet = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс долларов:");
            usdInWallet = Convert.ToSingle(Console.ReadLine());

            while (disairedOperation != CommandExit)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine(CommandConvertRubInUsd + "-обменять рубли на доллары");
                Console.WriteLine(CommandConvertUsdInRub + " -обменять доллары на рубли");
                Console.WriteLine(CommandConvertUsdInRub + " -обменять рубли на евро");
                Console.WriteLine(CommandConvertEurInRub + " -обменять евро на рубли");
                Console.WriteLine(CommandConvertEurInUsd + " -обменять евро на доллар");
                Console.WriteLine(CommandConvertUsdInEur + " -обменять доллар на евро");
                Console.WriteLine("Для выхода напишите - "+CommandExit);
                Console.Write("Ваш выбор:");
                disairedOperation = Console.ReadLine();

                switch (disairedOperation)
                {
                    case CommandConvertRubInUsd:
                        Console.WriteLine("Обмен рубли на доллары");
                        Console.WriteLine("Сколько вы хотиете обменять?");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (rubInWallet >= exchangeCurrencyCount)
                        {
                            rubInWallet -= exchangeCurrencyCount;
                            usdInWallet += exchangeCurrencyCount / rubInUSD;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во рублей");
                        }

                        break;

                    case CommandConvertUsdInRub:
                        Console.WriteLine("Обмен доллары на рубли");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (usdInWallet >= exchangeCurrencyCount)
                        {
                            usdInWallet -= exchangeCurrencyCount;
                            rubInWallet += exchangeCurrencyCount / usdInRub;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во долларов");
                        }

                        break;

                    case CommandConvertRubInEur:
                        Console.WriteLine("Обмен рублей на евро");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (rubInWallet >= exchangeCurrencyCount)
                        {
                            rubInWallet -= exchangeCurrencyCount;
                            euInWallet += exchangeCurrencyCount / rubInEu;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во рублей");
                        }

                        break;

                    case CommandConvertEurInRub:
                        Console.WriteLine("Обмен евро на рубли");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (euInWallet >= exchangeCurrencyCount)
                        {
                            euInWallet -= exchangeCurrencyCount;
                            rubInWallet += exchangeCurrencyCount / euInRub;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во евро");
                        }

                        break;

                    case CommandConvertEurInUsd:
                        Console.WriteLine("Обмен евро на доллар");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (euInWallet >= exchangeCurrencyCount)
                        {
                            euInWallet -= exchangeCurrencyCount;
                            usdInWallet += exchangeCurrencyCount / euInUSD;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во евро");
                        }

                        break;

                    case CommandConvertUsdInEur:
                        Console.WriteLine("Обмен доллара на евро");
                        Console.WriteLine("Сколько вы хотите обменять?");
                        exchangeCurrencyCount = Convert.ToSingle(Console.ReadLine());

                        if (usdInWallet >= exchangeCurrencyCount)
                        {
                            usdInWallet -= exchangeCurrencyCount;
                            euInWallet += exchangeCurrencyCount / usdInEu;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во долларов");
                        }

                        break;
                    case CommandExit:
                        Console.WriteLine("До встречи-_о");
                        break;

                    default:
                        Console.WriteLine("Введена неверная операция.");
                        break;

                }

                Console.WriteLine($"Ваш баланс: {rubInWallet} рублей, " + $"{usdInWallet} долларов, " + $"{euInWallet} евро");                
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
