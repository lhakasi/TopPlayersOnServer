using System;
using System.Collections.Generic;
using System.Linq;

namespace TopPlayersOnServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal();

            terminal.Work();
        }
    }

    class Player
    {
        private string _name;

        public Player(string name, int level, int strength)
        {
            _name = name;
            Level = level;
            Strength = strength;
        }

        public int Strength { get; private set; }
        public int Level { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} Lvl:{Level} - Str:{Strength}");
        }
    }

    class Server
    {
        private List<Player> _players;

        private int _amountOfTopPlayers = 3;

        public Server()
        {
            _players = new List<Player>()
            {
                new Player("player1", 97, 738),
                new Player("player2", 99, 823),
                new Player("player3", 95, 569),
                new Player("player4", 98, 950),
                new Player("player5", 92, 542),
                new Player("player6", 94, 682),
                new Player("player7", 95, 946),
                new Player("player8", 96, 366),
                new Player("player9", 97, 756),
                new Player("player10", 99, 256)               
            };
        }

        public List<Player> GetPlayers() => 
            new List<Player>(_players);

        public List<Player> SortByLevel() =>
            _players.OrderByDescending(player => player.Level).Take(_amountOfTopPlayers).ToList();

        public List<Player> SortByStrength() =>
            _players.OrderByDescending(player => player.Strength).Take(_amountOfTopPlayers).ToList();
    }

    class Terminal
    {
        private Server _server = new Server();

        public void Work()
        {            
            Console.WriteLine("Сервер: \"Let's waste time!\"");
            Console.WriteLine("\nТоп 3 игроков по уровню:");
            
            ShowPlayers(_server.SortByLevel());

            Console.WriteLine("Топ 3 игроков по силе:");
            
            ShowPlayers(_server.SortByStrength());

            Console.WriteLine("Список всех игроков:");

            ShowPlayers(_server.GetPlayers());

            Console.ReadKey();
        }
                
        private void ShowPlayers(List<Player> players)
        {
            Console.WriteLine();

            foreach (Player player in players)
                player.ShowInfo();

            Console.WriteLine();
        }
    }
}
