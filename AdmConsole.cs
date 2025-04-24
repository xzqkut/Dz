using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();

            bool isOpen = true;

            while (isOpen)
            {
                ShowMenu();

                string input = Console.ReadLine();
                switch (input)
                {
                    case MenuCommands.AddPlayer:
                        AddNewPlayer(database);
                        break;
                    case MenuCommands.BanPlayer:
                        database.BanPlayer();
                        break;
                    case MenuCommands.UnbanPlayer:
                        database.Unban();
                        break;
                    case MenuCommands.ShowAll:
                        database.ShowAllPlayers();
                        break;
                    case MenuCommands.ShowBanned:
                        database.ShowAllBannedPlayers();
                        break;
                    case MenuCommands.Exit:
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nЗдравствуйте администратор, что вы хотите сделать?");
            Console.WriteLine("1 - Добавить игрока");
            Console.WriteLine("2 - Забанить игрока");
            Console.WriteLine("3 - Разбанить игрока");
            Console.WriteLine("4 - Показать всех игроков");
            Console.WriteLine("5 - Показать забаненных игроков");
            Console.WriteLine("0 - Выход");
        }

        static void AddNewPlayer(Database database)
        {
            Console.Write("Присвойте ID игроку: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Назначьте игроку имя: ");
            string name = Console.ReadLine();
            Console.Write("С каким уровнем появится его персонаж?: ");
            int level = Convert.ToInt32(Console.ReadLine());

            database.AddPlayer(new Player(id, name, level, false));
            Console.WriteLine("Игрок создан!");
        }
    }

    public static class MenuCommands
    {
        public const string AddPlayer = "1";
        public const string BanPlayer = "2";
        public const string UnbanPlayer = "3";
        public const string ShowAll = "4";
        public const string ShowBanned = "5";
        public const string Exit = "0";
    }

    class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public bool isBanned { get; set; }

        public Player(int idNumber, string nickName, int userLevel, bool ban)
        {
            Id = idNumber;
            Nickname = nickName;
            Level = userLevel;
            isBanned = ban;
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void ShowAllPlayers()
        {
            foreach (Player player in _players)
            {
                Console.WriteLine($"Игроки:{player.Nickname},ID:{player.Id}");
            }
        }

        public void ShowAllBannedPlayers()
        {
            Console.WriteLine("Список игроков в бане:");

            foreach (Player player in _players)
            {
                if (player.isBanned)
                {
                    Console.WriteLine($"Ник:{player.Nickname},ID Игрока:{player.Id}");
                }
            }
        }

        public void BanPlayer()
        {
            Console.WriteLine("Введите ID игрока которого следует забанить.");
            int id = Convert.ToInt32(Console.ReadLine());
            bool found = false;

            foreach (Player player in _players)
            {
                if (player.Id == id)
                {
                    player.isBanned = true;
                    Console.WriteLine($"Игрок {player.Nickname} забанен!");
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                Console.WriteLine("Игрок не найден");
            }
        }

        public void Unban()
        {
            Console.WriteLine("Введите ID игрока которого следует разбанить.");

            string input = Console.ReadLine();
            int id;
            bool found = false;

            if (int.TryParse(input, out id))
            {
                foreach (Player player in _players)
                {
                    if (player.Id == id)
                    {
                        player.isBanned = false;
                        Console.WriteLine($"Игрок {player.Nickname} разбанен!");
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("Игрок не найден");
                }
            }
        }
    }
}

