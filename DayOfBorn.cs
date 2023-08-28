using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exitUser = "Exit";
            int age;

            Console.WriteLine("Введите ваш возраст:");
            age = Convert.ToInt32(Console.ReadLine());
 
            while (age-- > 0)
            {
                Console.WriteLine("С Днем Рождения!");
            }

            Console.WriteLine("Введите Exit для выхода");
            exitUser = Convert.ToString(Console.ReadLine());
            
            while(exitUser == "Exit")
            {
                Console.WriteLine("Досвидания!");
                break;
            }
        }  
    }
}
