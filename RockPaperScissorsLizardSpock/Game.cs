using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissorsLizardSpock
{
    public class Game
    {
        private readonly Dictionary<string, SelectionBase> _playable =
            new Dictionary<string, SelectionBase>
                {
                { "1", new Rock() },
                { "2", new Paper() },
                { "3", new Scissors() },
                { "4", new Lizard() },
                { "5", new Spock() }
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
                if (player == null) return;

                var sheldon = new Spock();
                var result = player.CompareTo(sheldon);

                _resultWriter.OutputResult(result, player, sheldon);
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
                Console.WriteLine("\t[{0}] {1}", item.Key, item.Value.Name);

            Console.WriteLine();
        }

        private SelectionBase GetUserSelection()
        {
            var values = _playable.Keys.ToList();
            values.Add(string.Empty); // allows a non-selection

            var input = _consoleInput.GetValidUserInput("Your selection? <ENTER> to quit.", values);
            if (input == string.Empty) return null;

            return _playable[input];
        }
    }
}
