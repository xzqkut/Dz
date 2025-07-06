using System;
using System.Collections.Generic;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            DatabaseView manager = new DatabaseView(database);
            manager.Run();
        }
    }

    class DatabaseView
    {
        private const string AddPlayerCommand = "1";
        private const string BanPlayerCommand = "2";
        private const string UnbanPlayerCommand = "3";
        private const string ShowAllPlayersCommand = "4";
        private const string RemovePlayerCommand = "5";
        private const string ExitCommand = "0";

        private Database _database;
        private bool _isOpen = true;

        public DatabaseView(Database database)
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
                    case AddPlayerCommand:
                        AddPlayer();
                        break;

                    case BanPlayerCommand:
                        BanPlayer();
                        break;

                    case UnbanPlayerCommand:
                        UnbanPlayer();
                        break;

                    case ShowAllPlayersCommand:
                        _database.ShowAllPlayers();
                        break;

                    case RemovePlayerCommand:
                        RemovePlayer();
                        break;

                    case ExitCommand:
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
            Console.WriteLine("\nЗдравствуйте администратор, выбирите цифру из списка для взаимодействия с меню:");
            Console.WriteLine($"{AddPlayerCommand} - Добавить игрока");
            Console.WriteLine($"{BanPlayerCommand} - Забанить игрока");
            Console.WriteLine($"{UnbanPlayerCommand}- Разбанить игрока");
            Console.WriteLine($"{ShowAllPlayersCommand} - Показать всех игроков");
            Console.WriteLine($"{RemovePlayerCommand} - Удалить игрока");
            Console.WriteLine($"{ExitCommand} - Выход");
        }

        private void AddPlayer()
        {
            Console.Write("Присвойте ID игроку: ");

            if (TryReadId(out int id) == false)
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
                return;
            }

            if (_database.ContainsId(id))
            {
                Console.WriteLine("Ошибка: Игрок с таким ID уже существует.");
                return;
            }

            Console.Write("Назначьте игроку имя: ");
            string name = Console.ReadLine();

            Console.Write("С каким уровнем появится его персонаж?: ");
            string levelInput = Console.ReadLine();

            int level;
            if (int.TryParse(levelInput, out level) == false)
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
            if (TryReadId(out int id))
            {
                if (_database.TryGetPlayer(id, out Player player))
                {
                    player.Ban();
                    Console.WriteLine("Игрок забанен!");
                }
                else
                {
                    Console.WriteLine("Игрок не найден.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
            }
        }

        private void UnbanPlayer()
        {
            if (TryReadId(out int id))
            {
                if (_database.TryGetPlayer(id, out Player player))
                {
                    player.Unban();
                    Console.WriteLine("Игрок разбанен!");
                }
                else
                {
                    Console.WriteLine("Игрок не найден.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: ID должен быть числом.");
            }
        }

        private void RemovePlayer()
        {
            if (TryReadId(out int id))
            {
                if (_database.TryGetPlayer(id, out Player player))
                {
                    _database.RemovePlayer(player);
                    Console.WriteLine("Игрок удален.");
                }
                else
                {
                    Console.WriteLine("Игрок не найден.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка! ID должен быть числом");
            }
        }

        private bool TryReadId(out int id)
        {
            Console.WriteLine("Введите ID игрока: ");
            string input = Console.ReadLine();

            if(int.TryParse(input, out id) == true)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка! ID игрока должен состоять из чисел");
                return false;
            }
        }
    }

    class Player
    {
        public Player(int id, string nickname, int level)
        {
            _id = id;
            _nickname = nickname;
            _level = level;
            _isbanned = false;
        }

        public int _id { get; private set; }
        public string _nickname { get; private set; }
        public int _level { get; private set; }
        public bool _isbanned { get; private set; }

        public void Ban()
        {
            _isbanned = true;
        }

        public void Unban()
        {
            _isbanned = false;
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public bool RemovePlayer(Player player)
        {
            return _players.Remove(player);
        }

        public void ShowAllPlayers()
        {
            Console.WriteLine("Все игроки:");
            foreach (Player player in _players)
            {
                Console.WriteLine($"Ник: {player._nickname}, ID: {player._id}, Уровень: {player._level}, Забанен: {player._isbanned}");
            }
        }

        public bool TryGetPlayer(int id, out Player player)
        {
            player = null;

            foreach (Player receivedPlayer in _players)
            {
                if (receivedPlayer._id == id)
                {
                    player = receivedPlayer;
                    return true;
                }
            }

            return false;
        }

        public bool ContainsId(int id)
        {
            foreach (Player player in _players)
            {
                if (player._id == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

