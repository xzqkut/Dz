internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        bool isShuffling = true;
        string responsYes = "Да";
        string responsNo = "Нет";
        string emptySymbol = " ";

        Console.WriteLine("Исходный массив:");

        PrintArray(array,emptySymbol);

        ShuffleArray(array, emptySymbol);

        while (isShuffling)
        {
            Console.WriteLine($"\nХотите еще раз перетасовать массив? ({responsYes}/ {responsNo})");
            string response = Console.ReadLine();

            if (response == responsYes)
            {
                PrintArray(array, emptySymbol);
                ShuffleArray(array,emptySymbol);
            }
            else if (response == responsNo)
            {
                isShuffling = false;
            }
            else
            {
                Console.WriteLine($"Неверный ответ. Пожалуйста, введите {responsYes} или {responsNo}.");
            }
        }

        Console.WriteLine("Программа прекращена.");
    }

    static void ShuffleArray(int[] array, string emptySymbol)
    {
        Random random = new Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = random.Next(i + 1);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }

        Console.WriteLine("\n Перетасованный массив:");
            PrintArray(array,emptySymbol);
    }

    static void PrintArray(int[] array,string emptySymbol)
    {
        foreach (var item in array)
        {
            Console.Write(item + emptySymbol) ;
        }
        Console.WriteLine();
    }
}
