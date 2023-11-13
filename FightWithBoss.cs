using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightWithBoss1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                const int InitialPlayerHealth = 1000;
                const int InitialBossHealth = 3000;
                const int ShadowSpiritDamage = 100;
                const int HuGanZakuraDamage = 300;
                const int InterdimensionalRiftHeal = 750;
                const int BossAttackDamage = 100;

                int playerHealth = InitialPlayerHealth;
                int bossHealth = InitialBossHealth;
                bool shadowSpiritSummoned = false;
                bool interdimensionalRiftActive = false;

                const string CommandRashamon = "1";
                const string CommandHuGanZakura = "2";
                const string CommandInterdimensionalRift = "3";
                const string CommandExit = "4";



                Console.WriteLine("Добро пожаловать, теневой маг!");
                Console.WriteLine("Ваше здоровье: " + playerHealth);
                Console.WriteLine("Здоровье босса: " + bossHealth);

                while (playerHealth > 0 && bossHealth > 0)
                {
                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine($"{CommandRashamon}. Рашамон");
                    Console.WriteLine($"{CommandHuGanZakura}. Хуганзакура");
                    Console.WriteLine($"{CommandInterdimensionalRift}. Межпространственный разлом");
                    Console.WriteLine($"{CommandExit}. Сдаться и покинуть игру");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case CommandRashamon:
                            if (!shadowSpiritSummoned)
                            {
                                Console.WriteLine("Вы призвали теневого духа. Босс атакует вас и наносит " + BossAttackDamage + " урона.");
                                playerHealth -= ShadowSpiritDamage;
                                shadowSpiritSummoned = true;
                            }
                            else
                            {
                                Console.WriteLine("Теневой дух уже призван.");
                            }
                            break;

                        case CommandHuGanZakura:
                            if (shadowSpiritSummoned)
                            {
                                Console.WriteLine("Вы использовали Хуганзакура и нанесли " + HuGanZakuraDamage + " урона боссу.");
                                bossHealth -= HuGanZakuraDamage;
                                shadowSpiritSummoned = false;
                            }
                            else
                            {
                                Console.WriteLine("Нельзя использовать Хуганзакура без призванного теневого духа.");
                            }
                            break;

                        case CommandInterdimensionalRift:
                            if (!interdimensionalRiftActive)
                            {
                                Console.WriteLine("Вы активировали Межпространственный разлом и восстановили " + InterdimensionalRiftHeal + " хп.");
                                playerHealth += InterdimensionalRiftHeal;
                                interdimensionalRiftActive = true;
                            }
                            else
                            {
                                Console.WriteLine("Разлом уже активен. Нельзя использовать его снова.");
                            }
                            break;

                        case CommandExit:
                            Console.WriteLine("Вы решили сдаться. Босс победил.");
                            playerHealth = 0;
                            break;

                        default:
                            Console.WriteLine("Некорректный выбор.");
                            break;
                    }

                    if (playerHealth <= 0)
                    {
                        Console.WriteLine("Вы проиграли. Босс победил.");
                    }
                    else if (bossHealth <= 0)
                    {
                        Console.WriteLine("Вы победили босса! Поздравляю!");
                    }

                    Console.WriteLine("Ваше здоровье: " + playerHealth);
                    Console.WriteLine("Здоровье босса: " + bossHealth);
                }

                Console.ReadLine();
            }
        }
    }
}



