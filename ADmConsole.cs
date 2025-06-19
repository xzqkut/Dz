using System;
using System.Collections.Generic;

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
        private const string AddPlayerCommand = "1";
        private const string BanPlayerCommand = "2";
        private const string UnbanPlayerCommand = "3";
        private const string ShowAllPlayersCommand = "4";
        private const string ShowbannedPlayersCommand = "5";
        private const string RemovePlayerCommand = "6";
        private const string ExitCommand = "0";

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
                    case AddPlayerCommand:
                        AddNewPlayer();
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

                    case ShowbannedPlayersCommand:
                        _database.ShowAllBannedPlayers();
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
            Console.WriteLine($"{ShowbannedPlayersCommand} - Показать забаненных игроков");
            Console.WriteLine($"{RemovePlayerCommand} - Удалить игрока");
            Console.WriteLine($"{ExitCommand} - Выход");
        }

        private void AddNewPlayer()
        {
            Console.Write("Присвойте ID игроку: ");
            string idInput = Console.ReadLine();
            int id;

            if (int.TryParse(idInput, out id) == false)
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
            Console.Write("Введите ID игрока для бана: ");
            string input = Console.ReadLine();
            int id;

            if (int.TryParse(input, out id) == true)
            {
                if (_database.TryGetPlayer(id, out Player player) == true)
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

            if (int.TryParse(input, out id) == true)
            {
                if (_database.TryGetPlayer(id, out Player player) == true)
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

            if (int.TryParse(input, out id) == true)
            {
                if (_database.RemovePlayer(id) == true)
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
        public Player(int id, string nickname, int level)
        {
            Id = id;
            Nickname = nickname;
            Level = level;
            IsBanned = false;
        }

        public int Id { get; private set; }
        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

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

        public bool CanRemovePlayer(int id)
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
            player = null;

            foreach (Player receivedPlayer in _players)
            {
                if (receivedPlayer.Id == id)
                {
                    player = receivedPlayer;
                    return true;
                }
            }

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

