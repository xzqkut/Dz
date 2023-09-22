using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightWithBoss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int healthMage = random.Next(80, 100);
            int healthBoss = random.Next(100, 130);
            int damageMage = random.Next(1, 10);
            int damageBoss = random.Next(10, 30);
           
            const int divineStormDamage = 50;
            const int fireballDamage = 40;
            const int holyRepair = 100;
            const int sacredAreaDamage = 10;

            int tickSacredArea = 3;

            bool enableGame = true;
            string spellMage;
           
            Console.WriteLine($"Перед вами орк-разрушитель. И он яростно бежит на вас!Не щелкайте носом, если вы произнесете заклинание неправильно, боссу будет наплевать!!!");
            Console.WriteLine("Примените свои заклинания чтобы убить босса.Список заклинаний:" +
                $"\n1)Священный шторм - Удар священной молнии который наносит {divineStormDamage} урона " +
                $"\n2)Огненный шар - Огненный шар наносит {fireballDamage} урона" +
                $"\n3)Священная земля -впускает в землю энергию света нанося урон врагам равный {sacredAreaDamage} в течении 3 секунд" +
                $"\n4)Клятва - восстанавливает магу {holyRepair} здоровья");
            Console.Write("\nБитва началась! ");

            while (enableGame)
            {

                Console.WriteLine($"Журнал боя: \nБосс:\n здоровье:{healthBoss},\n урон:{damageBoss}.\nМаг:\n здоровье:{healthMage}, \n урон:{damageMage}");
                Console.WriteLine("Возьмите свою магическую книгу и произнесите заклинание:");
                spellMage = Console.ReadLine();

                switch (spellMage)
                {
                    //сделать константу
                    case "Священный шторм":
                        Console.WriteLine("Священный шторм!");
                        if (enableGame)
                        {
                            healthBoss -= divineStormDamage;
                        }
                        break;

                    case "Огненный шар":
                        Console.Clear();
                        Console.WriteLine("Огенный шар - Сгори!");
                        if (enableGame)
                        {
                            healthBoss -= fireballDamage;
                        }
                        break;

                    case "Священная земля":
                        Console.Clear();
                        Console.WriteLine("Священная земля - бойся нечисть!");
                        if (enableGame)
                        {
                            for (int i = 0; i < tickSacredArea; i++)
                            {
                                healthBoss -= sacredAreaDamage;
                                Console.WriteLine($"Урон по боссу {sacredAreaDamage}");
                            }
                        }
                        break;

                    case "Клятва":
                        Console.Clear();
                        Console.WriteLine("Клятва - повинуйся всевышнему!");
                        if (healthMage <= 50)
                        {
                            healthMage += holyRepair;
                            Console.WriteLine($"Ваше здоровье пополненно {healthMage}");
                        }
                        break;

                    case "killboss":
                        healthBoss -= healthBoss + 10;
                        break;

                    default:
                        Console.WriteLine("Вы не знаетете это заклинания или вы произнесли его не правильно.", spellMage);
                        break;
                }
                healthMage -= damageBoss;
                if (healthMage <= 0 && healthBoss <= 0)
                {
                    Console.WriteLine("Ничья!");
                }
                else if (healthBoss <=0)
                {
                    Console.WriteLine("Босс понес поражение.Поздравляю с победой!");
                    enableGame = false;
                }
                else if (healthMage <= 0)
                {
                    Console.WriteLine("Вы проиграли!Попробуйте еще раз.");
                    enableGame = false;
                }
            }
        }

    }
}
