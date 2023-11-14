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
                const string CommandRashamon = "1";
                const string CommandHuGanZakura = "2";
                const string CommandInterdimensionalRift = "3";
                const string CommandExit = "4";

                int playerHealth = InitialPlayerHealth;
                int bossHealth = InitialBossHealth;
                bool haveShadowSpiritSummoned = false;
                bool canInterdimensionalRiftActive = false;




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
                            if (!haveShadowSpiritSummoned)
                            {
                                Console.WriteLine("Вы призвали теневого духа. Босс атакует вас и наносит " + BossAttackDamage + " урона.");
                                playerHealth -= ShadowSpiritDamage;
                                haveShadowSpiritSummoned = true;
                            }
                            else
                            {
                                Console.WriteLine("Теневой дух уже призван.");
                            }
                            break;

                        case CommandHuGanZakura:
                            if (haveShadowSpiritSummoned)
                            {
                                Console.WriteLine("Вы использовали Хуганзакура и нанесли " + HuGanZakuraDamage + " урона боссу.");
                                bossHealth -= HuGanZakuraDamage;
                                haveShadowSpiritSummoned = false;
                            }
                            else
                            {
                                Console.WriteLine("Нельзя использовать Хуганзакура без призванного теневого духа.");
                            }
                            break;

                        case CommandInterdimensionalRift:
                            if (!canInterdimensionalRiftActive)
                            {
                                Console.WriteLine("Вы активировали Межпространственный разлом и восстановили " + InterdimensionalRiftHeal + " хп.");
                                playerHealth += InterdimensionalRiftHeal;
                                canInterdimensionalRiftActive = true;
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


                    Console.WriteLine("Ваше здоровье: " + playerHealth);
                    Console.WriteLine("Здоровье босса: " + bossHealth);
                }
                if (playerHealth <= 0)
                {
                    Console.WriteLine("Вы проиграли. Босс победил.");
                }
                if(playerHealth<=0 && bossHealth<=0)
                {
                    Console.WriteLine("Ваши силы с боссом оказались равными,объявляется ничья!");
                }
                else if (bossHealth <= 0)
                {
                    Console.WriteLine("Вы победили босса! Поздравляю!");
                }

                Console.ReadLine();
            }
        }
    }
}



