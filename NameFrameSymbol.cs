using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string frameName = "";

            Console.WriteLine("Вывести имя в прямоугольнике с символами");
            Console.Write("Введите имя:");
            string name = Console.ReadLine();
            Console.WriteLine($"Имя {name}, длина имени: {name.Length}");

            Console.WriteLine("Введите символ: ");
            string symbol= Console.ReadLine();
            int additionToLength=4;
            string emptySpaceForSecondLine =" ";
            Console.WriteLine($"Cимвол: {symbol}");

            Console.WriteLine("Обработка имени:");
            for (int i = 1; i<=(name.Length + additionToLength); i+=1)
            {
                frameName += symbol;
            }
            Console.WriteLine(frameName);
            Console.WriteLine(frameName[0] +emptySpaceForSecondLine+name+emptySpaceForSecondLine+frameName[frameName.Length-1]);
            Console.WriteLine(frameName);
        }
    }
}
