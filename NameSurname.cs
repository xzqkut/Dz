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
            string name = "Pavel";
            string surName = "Yakovlev";
            Console.WriteLine(name+" "+surName);
            Console.ReadLine();
            string trueName;
            trueName = surName + " " + name;
            Console.WriteLine(trueName);
        }
    }
}
