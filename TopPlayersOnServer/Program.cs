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
    }

    class Terminal
    {
        private Server _server = new Server();

        public void Work()
        {            
            Console.WriteLine("Сервер: \"Let's waste time!\"");
            Console.WriteLine("\nТоп 3 игроков по уровню:");
            
            ShowTopPlayers(SortByLevel());

            Console.WriteLine("Топ 3 игроков по силе:");
            
            ShowTopPlayers(SortByStrength());
            ShowAllPlayers();            
        }

        private List<Player> SortByLevel() =>
            _server.GetPlayers().OrderByDescending(player => player.Level).Take(3).ToList();

        private List<Player> SortByStrength() =>
            _server.GetPlayers().OrderByDescending(player => player.Strength).Take(3).ToList();
        
        private void ShowTopPlayers(List<Player> filteredPlayers)
        {
            Console.WriteLine();

            foreach (Player player in filteredPlayers)
                player.ShowInfo();

            Console.WriteLine();
        }

        private void ShowAllPlayers()
        {
           Console.WriteLine("Список всех игроков:\n");

            foreach (Player player in _server.GetPlayers())
                player.ShowInfo();

            Console.ReadKey();
        }
    }
}
