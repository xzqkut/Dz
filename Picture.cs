﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = 3;
            int albumPictures = 52;
            int everythingIsPossible = albumPictures%row;
            Console.WriteLine(everythingIsPossible);
        }
    }
}