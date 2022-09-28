using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsLizardSpock
{
    public class Rock : SelectionBase
    {
        public override string GetWinningVerb(SelectionBase other)
        {
            if (other is Scissors) return "crushes";
            if (other is Lizard) return "crushes";
            throw new InvalidOperationException("Are we playing the same game?");
        }
        public override int CompareTo(SelectionBase other)
        {
            if (other is Rock) return 0;
            if (other is Paper) return -1;
            if (other is Scissors) return 1;
            if (other is Lizard) return 1;
            if (other is Spock) return -1;
            throw new InvalidOperationException("Are we playing the same game?");
        }
    }

    public class Paper : SelectionBase
    {
        public override string GetWinningVerb(SelectionBase other)
        {
            if (other is Rock) return "covers";
            if (other is Spock) return "disproves";
            throw new InvalidOperationException("Are we playing the same game?");
        }
        public override int CompareTo(SelectionBase other)
        {
            if (other is Rock) return 1;
            if (other is Paper) return 0;
            if (other is Scissors) return -1;
            if (other is Lizard) return -1;
            if (other is Spock) return 1;
            throw new InvalidOperationException("Are we playing the same game?");
        }
    }

    public class Scissors : SelectionBase
    {
        public override string GetWinningVerb(SelectionBase other)
        {
            if (other is Paper) return "cuts";
            if (other is Lizard) return "decapitates";
            throw new InvalidOperationException("Are we playing the same game?");
        }
        public override int CompareTo(SelectionBase other)
        {
            if (other is Rock) return -1;
            if (other is Paper) return 1;
            if (other is Scissors) return 0;
            if (other is Lizard) return 1;
            if (other is Spock) return -1;
            throw new InvalidOperationException("Are we playing the same game?");
        }
    }

    public class Lizard : SelectionBase
    {
        public override string GetWinningVerb(SelectionBase other)
        {
            if (other is Paper) return "eats";
            if (other is Spock) return "poisons";
            throw new InvalidOperationException("Are we playing the same game?");
        }
        public override int CompareTo(SelectionBase other)
        {
            if (other is Rock) return -1;
            if (other is Paper) return 1;
            if (other is Scissors) return -1;
            if (other is Lizard) return 0;
            if (other is Spock) return 1;
            throw new InvalidOperationException("Are we playing the same game?");
        }
    }

    public class Spock : SelectionBase
    {
        public override string GetWinningVerb(SelectionBase other)
        {
            if (other is Rock) return "vaporizes";
            if (other is Scissors) return "smashes";
            throw new InvalidOperationException("Are we playing the same game?");
        }
        public override int CompareTo(SelectionBase other)
        {
            if (other is Rock) return 1;
            if (other is Paper) return -1;
            if (other is Scissors) return 1;
            if (other is Lizard) return -1;
            if (other is Spock) return 0;
            throw new InvalidOperationException("Are we playing the same game?");
        }
    }
}
