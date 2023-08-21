using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perestanovka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "Pavel";
            string b = "Yakovlev";
            Console.WriteLine($"{a}+{b}");
            (a, b) = (b, a);
            Console.WriteLine($"{a}+{b}");
        }
    }
}
