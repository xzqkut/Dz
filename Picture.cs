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
            int picturesInRow = 3;
            int picturesInAlbum = 52;
            int redundantPictures = picturesInAlbum % picturesInRow;
            int filledRows = picturesInAlbum / picturesInRow;
            Console.WriteLine($"Поместилось {filledRows}.") ;
            Console.WriteLine($"Осталось {redundantPictures}.");
        }
    }
}
