using System;
using System.Text.RegularExpressions;

using static System.Console;

namespace WorkingWithRegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write("Enter your age: ");
            // string input = ReadLine();
            // Regex ageChecker = new Regex(@"^\d{1,3}\.?\d{1,2}$");
            // if (ageChecker.IsMatch(input))
            // {
            //     WriteLine("Thank you!");
            // }
            // else
            // {
            //     WriteLine($"This is not a valid age {input}.");
            // }

            string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";
            string [] filmsDumb = films.Split(',');
            WriteLine("Dumb attempt at splitting:");
            foreach(string film in filmsDumb)
            {
                WriteLine(film);
            }
            Regex csv = new Regex("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
            MatchCollection filmsSmart = csv.Matches(films);
            WriteLine("Smart attempt at splitting:");
            foreach(Match film in filmsSmart)
            {
                // WriteLine(film.Groups[2].Value);
                WriteLine(film.Value);
            }
        }
    }
}
