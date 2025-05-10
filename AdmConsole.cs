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
            GameManager manager = new GameManager(database);
            manager.Run();
        }
    }
    class GameManager
    {
        private Database _database;
        private bool _isOpen = true;

        public GameManager(Database database)
        {
            _database = database;
        }

        public void Run()
        {
            while (_isOpen)
            {
                ShowMenu();

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AddNewPlayer();
                        break;

                    case "2":
                        BanPlayer();
                        break;

                    case "3":
                        UnbanPlayer();
                        break;

                    case "4":
                        _database.ShowAllPlayers();
                        break;

                    case "5":
                        _database.ShowAllBannedPlayers();
                        break;

                    case "6":
                        RemovePlayer();
                        break;

                    case "0":
                        _isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\nЗдравствуйте администратор, что вы хотите сделать?");
            Console.WriteLine("1 - Добавить игрока");
            Console.WriteLine("2 - Забанить игрока");
            Console.WriteLine("3 - Разбанить игрока");
            Console.WriteLine("4 - Показать всех игроков");
            Console.WriteLine("5 - Показать забаненных игроков");
            Console.WriteLine("6 - Удалить игрока");
            Console.WriteLine("0 - Выход");
        }

        private void AddNewPlayer()
        {
            Console.Write("Присвойте ID игроку: ");
            string idInput = Console.ReadLine();
            int id;

            if (!int.TryParse(idInput, out id))
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
                return;
            }

            if (_database.IsIdTaken(id))
            {
                Console.WriteLine("Ошибка: Игрок с таким ID уже существует.");
                return;
            }

            Console.Write("Назначьте игроку имя: ");
            string name = Console.ReadLine();

            Console.Write("С каким уровнем появится его персонаж?: ");
            string levelInput = Console.ReadLine();
            int level;

            if (!int.TryParse(levelInput, out level))
            {
                Console.WriteLine("Ошибка: Уровень должен быть числом.");
                return;
            }

            Player newPlayer = new Player(id, name, level);
            _database.AddPlayer(newPlayer);
            Console.WriteLine("Игрок создан!");
        }

        private void BanPlayer()
        {
            Console.Write("Введите ID игрока для бана: ");
            string input = Console.ReadLine();
            int id;

            if (int.TryParse(input, out id))
            {
                if (_database.TryGetPlayer(id, out Player player))
                {
                    player.Ban();
                    Console.WriteLine("Игрок забанен!");
                }
                else
                {
                    Console.WriteLine("Игрок не найден");
                }
            }
        }

        private void UnbanPlayer()
        {
            Console.Write("Введите ID игрока для разбана: ");
            string input = Console.ReadLine();
            int id;

            if (int.TryParse(input, out id))
            {
                if (_database.TryGetPlayer(id, out Player player))
                {
                    player.Unban();
                    Console.WriteLine("Игрок разбанен!");
                }
                else
                {
                    Console.WriteLine("Игрок не найден");
                }
            }
        }

        private void RemovePlayer()
        {
            Console.Write("Введите ID игрока для удаления: ");
            string input = Console.ReadLine();
            int id;

            if (int.TryParse(input, out id))
            {
                if (_database.RemovePlayer(id))
                {
                    Console.WriteLine("Игрок удален.");
                }
                else
                {
                    Console.WriteLine("Игрок не найден.");
                }
            }
        }
    }
    class Player
    {
        public int Id { get; private set; }
        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(int id, string nickname, int level)
        {
            Id = id;
            Nickname = nickname;
            Level = level;
            IsBanned = false;
        }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }
    class Database
    {
        private List<Player> _players = new List<Player>();

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public bool RemovePlayer(int id)
        {
            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == id)
                {
                    _players.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void ShowAllPlayers()
        {
            Console.WriteLine("Все игроки:");
            foreach (Player player in _players)
            {
                Console.WriteLine($"Ник: {player.Nickname}, ID: {player.Id}, Уровень: {player.Level}, Забанен: {player.IsBanned}");
            }
        }

        public void ShowAllBannedPlayers()
        {
            Console.WriteLine("Список забаненных игроков:");
            foreach (Player player in _players)
            {
                if (player.IsBanned)
                {
                    Console.WriteLine($"Ник: {player.Nickname}, ID: {player.Id}");
                }
            }
        }

        public bool TryGetPlayer(int id, out Player player)
        {
            foreach (Player p in _players)
            {
                if (p.Id == id)
                {
                    player = p;
                    return true;
                }
            }
            player = null;
            return false;
        }

        public bool IsIdTaken(int id)
        {
            foreach (Player player in _players)
            {
                if (player.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

