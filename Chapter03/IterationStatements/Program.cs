using System;

using static System.Console;

namespace IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            while (x < 10)
            {
                WriteLine(x);
                x++;
            }

            // string password = string.Empty;
            // string correctPassword = "password";
            // int maxCount = 5, currentCount = 0;
            // do
            // {
            //     currentCount++;
            //     Write($"Enter your password [{currentCount}]: ");
            //     password = ReadLine();
            // } while (password != correctPassword && currentCount < maxCount);
            // if (password == correctPassword)
            // {
            //     WriteLine("Correct!");
            // }
            // else
            // {
            //     WriteLine("You have exceeded the number of attempts!");
            // }

            for (int i = 1; i <= 10; i++)
            {
                WriteLine(i);
            }

            string[] names = {"Adam", "Barry", "Charlie"};
            foreach (string name in names)
            {
                WriteLine($"{name} has {name.Length} characters.");
            }
        }

    }
}
