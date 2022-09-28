using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsLizardSpock
{
    public interface IResultWriter
    {
        void OutputResult(int comparisonResult, SelectionBase player, SelectionBase sheldon);
    }

    public class ConsoleResultWriter : IResultWriter
    {
        public void OutputResult(int comparisonResult, SelectionBase player, SelectionBase sheldon)
        {
            var resultActions = new Dictionary<int, Action<SelectionBase, SelectionBase>>
        {
            { 1, OutputPlayerWinsResult },
            { -1, OutputPlayerLosesResult },
            { 0, OutputTieResult }
        };
            resultActions[comparisonResult].Invoke(player, sheldon);
        }
        private void OutputPlayerLosesResult(SelectionBase player, SelectionBase sheldon)
        {
            Console.WriteLine("\n\tSheldon says: \"{0} {1} {2}. You lose!\"\n", sheldon.Name, sheldon.GetWinningVerb(player), player.Name);
        }
        private void OutputPlayerWinsResult(SelectionBase player, SelectionBase sheldon)
        {
            Console.WriteLine("\n\tSheldon says: \"{0} {1} {2}. You win!\"\n", player.Name, player.GetWinningVerb(sheldon), sheldon.Name);
        }
        private void OutputTieResult(SelectionBase player, SelectionBase sheldon)
        {
            Console.WriteLine("\n\tSheldon says: \"Meh. Tie!\"\n");
        }
    }
}
