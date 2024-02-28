internal class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        bool continueShuffling = true;
        string responsYes = "Да";
        string responsNo = "Нет";

        ShuffleTheArray(array);

        while (continueShuffling)
        {
            Console.WriteLine("\nХотите еще раз перетасовать массив? (Да/нет)");
            string response = Console.ReadLine();

            if (response == responsYes)
            {
                ShuffleTheArray(array);
            }
            else if (response == responsNo)
            {
                continueShuffling = false;
            }
            else
            {
                Console.WriteLine("Неверный ответ. Пожалуйста, введите Да или Нет.");
            }
        }

        Console.WriteLine("Программа прекращена.");
    }

    static void ShuffleTheArray(int[] array)
    {
        Random random = new Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        AcceptShuflleArray(array);
    }

    static void AcceptShuflleArray(int[]array)
    {
        Console.WriteLine("\nМассив перетасован:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
    }
}
