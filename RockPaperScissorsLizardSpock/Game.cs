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

        private readonly IUserInputProvider _consoleInput1;
        private readonly IUserInputProvider _consoleInput2;

        int player = 1;

        public Game(IUserInputProvider consoleInput1, IUserInputProvider consoleInput2)
        {
            _consoleInput1 = consoleInput1;
            _consoleInput2 = consoleInput2;
        }

        public void Run()
        {
            while (true)
            {
                LayoutGameScreen();

                var player1 = GetUserSelection(_consoleInput1);
                if (player1 == 0) return;

                //Player number 2 is a random
                //var r = new Random();
                //var sheldon = (Item)r.Next(1,5);
                var player2 = GetUserSelection(_consoleInput2);

                Console.WriteLine(Decision.Decide(player1, player2).ToString());

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

        private Item GetUserSelection(IUserInputProvider consoleInput)
        {
            if (player > 2)
                player = 1;

            var values = _playable.Keys.ToList();
            values.Add(string.Empty); // allows a non-selection

            var input = consoleInput.GetValidUserInput("Player " + player + " selection ? <ENTER> to quit.", values);
            ++player;
            if (input == string.Empty) return 0;

            return _playable[input];
        }
    }
}
