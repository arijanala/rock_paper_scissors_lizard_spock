using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissorsLizardSpock
{
    public interface IUserInputProvider
    {
        string GetValidUserInput(string prompt, IEnumerable<string> validValues);
    }
    public class ConsoleUserInputProvider : IUserInputProvider
    {
        private string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        private string GetUserInput(string prompt, IEnumerable<string> validValues)
        {
            var input = GetUserInput(prompt);
            var isValid = validValues.Select(v => v.ToLower()).Contains(input.ToLower());
            return isValid ? input : string.Empty;
        }
        public string GetValidUserInput(string prompt, IEnumerable<string> validValues)
        {
            var input = string.Empty;
            var isValid = false;
            while (!isValid)
            {
                input = GetUserInput(prompt, validValues);
                isValid = !string.IsNullOrEmpty(input) || validValues.Contains(string.Empty);
            }
            return input;
        }
    }
}
