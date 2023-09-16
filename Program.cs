using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var symbol = 0;
            var count = 0;
            var result = 0;

            Console.WriteLine("Введите строку из символов '(' и ')'");
            var text = Console.ReadLine();

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                    symbol++;
                else if (text[i] == ')')
                {
                    if (i != text.Length - 1 && text[i + 1] != '(')
                        count++;
                    symbol--;
                }
                if (symbol < 0)
                {
                    break;
                }
                if (symbol == 0)
                {
                    result = count;
                }
            }
            if (symbol == 0)
                Console.WriteLine("Строка корректная " + text + "\n" + "Максимальная глубина равняется: " + (result + 1));
            else Console.WriteLine("Ошибка! Не верная строка " + text);
        }
    }
}
