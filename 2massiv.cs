using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massiv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minrandom = 1;
            int maxrandom = 5;

            int rowNumber = 2;
            int coloumnNumber = 1;

            int sumLine = 0;
            int increaseColoumn = 1;

            int[,] array =  new int[2,2];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = random.Next(minrandom, maxrandom);
                    Console.Write(array[i,j]+" ");
                }
                Console.WriteLine();
                
            }
            for (int i = 0;i < array.GetLength(1); i++)
            {
                sumLine += array[rowNumber-1,i];
            }
            for (int i = 0;i<array.GetLength(0); i++)
            {
                increaseColoumn *= array[coloumnNumber-1,i];
            }
            Console.WriteLine($"\nСумма чисел {rowNumber} строки: {sumLine}");
            Console.WriteLine($"\nПроизведение чисел {coloumnNumber} столбца: {increaseColoumn}");
            Console.ReadLine();


        }
    }
}
