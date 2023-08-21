using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yakovlev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age;
            string name;
            string sign;
            string work;

            Console.Write("Как вас зовут?");
           
            name=Console.ReadLine();
            Console.Write("Сколько вам лет?");
           age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Кто вы по знаку зодиака?");
            sign=Console.ReadLine();
            Console.WriteLine("Где вы работаете?");
            work=Console.ReadLine();
            Console.WriteLine($"Вас зовут {name},вам {age} год, вы {sign} и работаете на {work} ");




        }
    }
}
