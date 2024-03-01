internal class Program
{
    static void Main(string[] args)
    {
        int[] seriesOfNumbers = { 1, 2, 3, 4, 5, 6, 7 };
        bool isShuffling = true;
        string positiveUserResponse = "Да";
        string negativeUserResponse = "Нет";
       
        Console.WriteLine("Исходный массив:");

        PrintArray(seriesOfNumbers);

        ShuffleArray(seriesOfNumbers);

        while (isShuffling)
        {
            Console.WriteLine($"\nХотите еще раз перетасовать массив? ({positiveUserResponse}/ {negativeUserResponse})");
            string response = Console.ReadLine();

            if (response == positiveUserResponse)
            {
                PrintArray(seriesOfNumbers);
                ShuffleArray(seriesOfNumbers);
            }
            else if (response == negativeUserResponse)
            {
                isShuffling = false;
            }
            else
            {
                Console.WriteLine($"Неверный ответ. Пожалуйста, введите {positiveUserResponse} или {negativeUserResponse}.");
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
