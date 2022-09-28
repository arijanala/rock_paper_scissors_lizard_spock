using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissorsLizardSpock
{
    public class Decision
    {
        private bool? _HasPlayerWon;
        private Rule _WinningRule;

        static List<Rule> Rules = new List<Rule> 
        {
            new Rule(Item.Rock, "crushes", Item.Scissors),
            new Rule(Item.Spock, "vaporizes", Item.Rock),
            new Rule(Item.Paper, "disproves", Item.Spock),
            new Rule(Item.Lizard, "eats", Item.Paper),
            new Rule(Item.Scissors, "decapitate", Item.Lizard),
            new Rule(Item.Spock, "smashes", Item.Scissors),
            new Rule(Item.Lizard, "poisons", Item.Spock),
            new Rule(Item.Rock, "crushes", Item.Lizard),
            new Rule(Item.Paper, "covers", Item.Rock),
            new Rule(Item.Scissors, "cut", Item.Paper)
        };

        private Decision(bool? hasPlayerWon, Rule winningRule)
        {
            _HasPlayerWon = hasPlayerWon;
            _WinningRule = winningRule;
        }

        public static Decision Decide(Item player, Item sheldon)
        {
            var rule = FindWinningRule(player, sheldon);
            if (rule != null)
            {
                return new Decision(true, rule);
            }

            rule = FindWinningRule(sheldon, player);
            if (rule != null)
            {
                return new Decision(false, rule);
            }

            return new Decision(null, null);
        }

        private static Rule FindWinningRule(Item player, Item opponent)
        {
            return Rules.FirstOrDefault(r => r.Winner == player && r.Loser == opponent);
        }

        public override string ToString()
        {
            if (_HasPlayerWon == null)
            {
                return "Meh. Tie!";
            }
            else if (_HasPlayerWon == true)
            {
                return string.Format("{0}. You win!", _WinningRule);
            }
            else
            {
                return string.Format("{0}. You lose!", _WinningRule);
            }
        }
    }
}
