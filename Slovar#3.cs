using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slovar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandUseDictionary = "1";
            const string CommandExit = "2";

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("Собака", " Собака — домашнее животное, одно из наиболее популярных животных - компаньонов.");
            dictionary.Add("Змея", "Змеи — подотряд класса пресмыкающихся отряда чешуйчатые");
            dictionary.Add("Человек", "Человек — общественное существо, обладающее разумом и сознанием, субъект общественно-исторической деятельности и культуры.");

            bool isOpen = true;
            while (isOpen)
            {
                Console.WriteLine($"{CommandUseDictionary})Заглянуть в словарь. \n{CommandExit})Завершить. ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandUseDictionary:
                        SearchWord(dictionary);
                        break;

                    case CommandExit:
                        isOpen = false;
                        break;

                }
            }
        }

        static void SearchWord(Dictionary<string,string> dictionary)
        {
            Console.WriteLine($"Здравствуйте! О чем бы вам хотелось узнать?\nВыбирете и напишите слово из списка>>\n");

            foreach(string word in dictionary.Keys)
            {
                Console.WriteLine(word);
            }

            string userInput= Console.ReadLine();

            if (dictionary.ContainsKey(userInput))
            {
                Console.WriteLine(dictionary[userInput]);
            }
            else
            {
                Console.WriteLine("Такого слова еще нет.");
            }
        }


    }
}
