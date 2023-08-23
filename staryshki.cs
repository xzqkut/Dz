using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOldLadies;
            int minutesPerPerson = 10;
            int timeConverter = 60;

            Console.Write("Введите кол-во старушек: ");
            numberOfOldLadies=Convert.ToInt32(Console.ReadLine());

            int totalMinutes = numberOfOldLadies * minutesPerPerson;
            int hoursInLine = totalMinutes / timeConverter;
            int minutesInLine = totalMinutes % timeConverter;

            Console.WriteLine($"Вы должны отстоять в очереди {hoursInLine} часа и {minutesInLine} минут.");
        }
    }
}
