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
                Console.WriteLine("Здравствуйте администратор, что вы хотите сделать?");
                Console.WriteLine("1 - Добавить игрока");
                Console.WriteLine("2 - Забанить игрока");
                Console.WriteLine("3 - Разбанить игрока");
                Console.WriteLine("4 - Показать всех игроков");
                Console.WriteLine("5 - Показать забаненных игроков");
                Console.WriteLine("0 - Выход");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Присвойте ID игроку");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Назначьте игроку имя");
                        string name = Console.ReadLine();
                        Console.WriteLine("С каким уровнев появится его персонаж?");
                        int levelUser = Convert.ToInt32(Console.ReadLine());

                        database.AddPlayer(new Player(id, name, levelUser, false));
                        Console.WriteLine("Игрок создан!");
                        break;
                    case "2":

                        database.BannedPlaye();
                        break;
                    case "3":
                        database.UnBan();
                        break;
                    case "4":
                        database.ShowAllPlayer();
                        break;
                    case "5":
                        database.ShowAllBannedPlayers();
                        break;
                    case "6":
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }

        class Player
        {
            public int Id;
            public string Nickname;
            public int Level;
            public bool isBanned;

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
            private List<Player> _list = new List<Player>();

            public void AddPlayer(Player player)
            {
                _list.Add(player);
            }

            public void ShowAllPlayer()
            {
                foreach (Player player in _list)
                {
                    Console.WriteLine($"Игроки:{player.Nickname},ID:{player.Id}");
                }

            }

            public void ShowAllBannedPlayers()
            {
                Console.WriteLine("Список игроков в бане:");

                foreach (Player player in _list)
                {
                    if (player.isBanned)
                    {
                        Console.WriteLine($"Ник:{player.Nickname},ID Игрока:{player.Id}");
                    }
                }
            }

            public void BannedPlaye()
            {
                Console.WriteLine("Введите ID игрока которого следует забанить.");
                int id = Convert.ToInt32(Console.ReadLine());
                bool found = false;

                foreach (Player player in _list)
                {
                    if (player.Id == id)
                    {
                        player.isBanned = true;
                        Console.WriteLine($"Игрок {player.Nickname} забанен!");
                        found = true;
                        break;
                    }
                    if (!found)
                    {
                        Console.WriteLine("Игрок не найден");
                    }
                }
            }

            public void UnBan()
            {
                Console.WriteLine("Введите ID игрока которого следует разбанить.");

                int id = Convert.ToInt32(Console.ReadLine());
                bool found = false;

                foreach (Player player in _list)
                {
                    if (player.Id == id)
                    {
                        player.isBanned = false;
                        Console.WriteLine($"Игрок {player.Nickname} разбанен!");
                        found = true;
                        break;
                    }
                    if (!found)
                    {
                        Console.WriteLine("Игрок не найден");
                    }
                }
            }
        }
    }
}
