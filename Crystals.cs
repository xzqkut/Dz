using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int moneyHero;
            int purchasedCrystal;
            int priceOfCrystals = 50;
            bool canToPay; 

            Console.WriteLine($"Продавец:Приветствую в своем магазине кристалов, самые дешевые кристалы у меня, всего по {priceOfCrystals} золота ");
            Console.Write("Сколько у вас золота");
            moneyHero=Convert.ToInt32( Console.ReadLine() );

            Console.WriteLine("Сколько кристалов вы бы хотели приобрести?");
            purchasedCrystal=Convert.ToInt32( Console.ReadLine() );

            canToPay= moneyHero >= purchasedCrystal*priceOfCrystals;
            purchasedCrystal *= Convert.ToInt32(canToPay);
            moneyHero -= purchasedCrystal * priceOfCrystals;

            Console.WriteLine($"У вас в сумке {purchasedCrystal} кристалов и ваша сдача {moneyHero}.");

        }
    }
}
