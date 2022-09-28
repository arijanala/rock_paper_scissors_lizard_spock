namespace RockPaperScissorsLizardSpock
{
    public enum Item
    {
        Rock, Paper, Scissors, Lizard, Spock
    }

    public class Rule
    {
        public readonly Item Winner;
        public readonly Item Loser;
        public readonly string WinningPhrase;

        public Rule(Item winner, string winningPhrase, Item loser)
        {
            Winner = winner;
            Loser = loser;
            WinningPhrase = winningPhrase;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Winner, WinningPhrase, Loser);
        }
    }
}
