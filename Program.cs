using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dayOfWeek;
            Console.WriteLine("Введите день недели для открытия заметки, введите Exit для выхода");
            dayOfWeek =Console.ReadLine();
            
            {
                switch(dayOfWeek)
                {
                    case "Понедельник":
                    case "Четверг":
                        Console.WriteLine("Работа");
                        break;
                    case "Вторник":
                    case "Пятница":
                        Console.WriteLine("Учеба");
                        break;
                    case "Среда":
                    case "Всокресенье":
                        Console.WriteLine("Курс");
                        break;
                    case "Суббота":
                        Console.WriteLine("Отдых");
                        break;
                    case "Exit":
                        Console.WriteLine("Досвидания");
                        break;
                        default: Console.WriteLine("Введены неверные данные");
                        break;
                       
                }
            }



         
            
        }
    }
}
