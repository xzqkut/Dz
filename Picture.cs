using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = 3;
            int albumPictures = 52;
            int everythingIsPossible = albumPictures % row;
            int fitPictures = albumPictures / row;
            Console.WriteLine($"Поместилось {fitPictures}.") ;
            Console.WriteLine($"Осталось {everythingIsPossible}.");
        }
    }
}
