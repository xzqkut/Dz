using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fullMassiv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = { "1", "2", "3","4"};
            string[] secondArray = { "2","3"};

            List<string> collectionNumber = new List<string>();

            AddItem(firstArray, collectionNumber);
            AddItem(secondArray, collectionNumber);

            Show(collectionNumber);
        }

        static void Show(List<string> array)
        {
            foreach (string item in array)
            {
                Console.WriteLine($"{item}");
            }
        }

        static void AddItem(string[] array,List<string> collectionNumber)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (collectionNumber.Contains(array[i]) == false)
                {
                    collectionNumber.Add(array[i]);
                }
            }
        }
    }
}
