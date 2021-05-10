using System;
using System.Text.RegularExpressions;

using static System.Console;

namespace Excercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;

            do
            {
                string defaultRegularExpression = @"\d";
                WriteLine("The default regular expression checks for at least one digit.");
                Write("Enter a regular expression (or press [ENTER] to use the default): ");
                string regularExpression = ReadLine();
                if (string.IsNullOrWhiteSpace(regularExpression))
                {
                    regularExpression = defaultRegularExpression;
                }

                Write("Enter some input: ");
                string input = ReadLine();
                if (Regex.IsMatch(input, regularExpression))
                {
                    WriteLine($"{input} matches {regularExpression}");
                }
                else
                {
                    WriteLine($"{input} does not match {regularExpression}");
                }
                WriteLine("Press [ESC] to end or any other key to try again.");
                key = ReadKey();
            }
            while (key.Key != ConsoleKey.Escape);
        }
    }
}
