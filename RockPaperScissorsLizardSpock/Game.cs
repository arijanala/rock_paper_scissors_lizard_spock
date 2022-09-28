using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissorsLizardSpock
{
    public class Game
    {
        private readonly Dictionary<string, Item> _playable =
            new Dictionary<string, Item>
                {
                { "1", Item.Rock },
                { "2", Item.Paper },
                { "3", Item.Scissors },
                { "4", Item.Lizard },
                { "5", Item.Spock }
                };

        private readonly IUserInputProvider _consoleInput;
        private readonly IResultWriter _resultWriter;

        public Game(IUserInputProvider console, IResultWriter resultWriter)
        {
            _consoleInput = console;
            _resultWriter = resultWriter;
        }

        public void Run()
        {
            while (true)
            {
                LayoutGameScreen();

                var player = GetUserSelection();
                if (player == 0) return;

                var sheldon = Item.Spock;
                Console.WriteLine(Decision.Decide(player, sheldon).ToString());

                Pause();
            }
        }

        private void Pause()
        {
            Console.WriteLine("\nPress <ENTER> to continue.");
            Console.ReadLine();
        }

        private void LayoutGameScreen()
        {
            Console.Clear();
            Console.WriteLine("Rock-Paper-Scissors-Lizard-Spock 1.0\n{0}\n", new string('=', 40));

            foreach (var item in _playable)
                Console.WriteLine("\t[{0}] {1}", item.Key, item.Value.ToString());

            Console.WriteLine();
        }

        private Item GetUserSelection()
        {
            var values = _playable.Keys.ToList();
            values.Add(string.Empty); // allows a non-selection

            var input = _consoleInput.GetValidUserInput("Your selection? <ENTER> to quit.", values);
            if (input == string.Empty) return 0;

            return _playable[input];
        }
    }
}
