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
            var consoleReader = new ConsoleUserInputProvider();
            var game = new Game(consoleReader);
            game.Run();
        }
    }
}
