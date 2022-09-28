namespace RockPaperScissorsLizardSpock
{
    class Program
    {
        /*
            "Scissors cuts paper, paper covers rock, 
             rock crushes lizard, lizard poisons Spock, 
             Spock smashes scissors, scissors decapitate lizard, 
             lizard eats paper, paper disproves Spock, 
             Spock vaporizes rock. And as it always has, rock crushes scissors." 
                                                              -- Dr. Sheldon Cooper
        */
        static void Main(string[] args)
        {
            var consoleReader1 = new ConsoleUserInputProvider();
            var consoleReader2 = new ConsoleUserInputProvider();
            var game = new Game(consoleReader1, consoleReader2);
            game.Run();
        }
    }
}
