internal class Program
{
    static void Main(string[] args)
    {
        int[] seriesOfNumbers = { 1, 2, 3, 4, 5, 6, 7 };
        bool isShuffling = true;
        string mixRow = "Да";
        string closedRow = "Нет";
       

        Console.WriteLine("Исходный массив:");

        PrintArray(seriesOfNumbers);

        ShuffleArray(seriesOfNumbers);

        while (isShuffling)
        {
            Console.WriteLine($"\nХотите еще раз перетасовать массив? ({mixRow}/ {closedRow})");
            string response = Console.ReadLine();

            if (response == mixRow)
            {
                PrintArray(seriesOfNumbers, emptySymbol);
                ShuffleArray(seriesOfNumbers,emptySymbol);
            }
            else if (response == closedRow)
            {
                isShuffling = false;
            }
            else
            {
                Console.WriteLine($"Неверный ответ. Пожалуйста, введите {mixRow} или {closedRow}.");
            }
        }

        Console.WriteLine("Программа прекращена.");
    }

    static void ShuffleArray(int[] array)
    {
        Random random = new Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = random.Next(i + 1);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }     
    }

    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ") ;
        }

        Console.WriteLine();
    }
}
