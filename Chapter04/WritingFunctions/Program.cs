using System;

using static System.Console;

namespace WritingFunctions
{
    class Program
    {
        static void TimesTable(byte number)
        {
            WriteLine($"This is the {number} times table:");
            for (int row = 1; row <= 12; row++)
            {
                WriteLine($"{row} x {number} = {row * number}");
            }
            WriteLine();
        }
        static void RunTimesTable()
        {
            bool isNumber;
            do
            {
                Write("Write a number between 0 and 255: ");
                isNumber = byte.TryParse(ReadLine(), out byte number);
                if (isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    WriteLine("You did not enter a valid number.");
                }
            }
            while (isNumber);
        }

        static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
        {
            decimal rate = 0.0M;
            switch (twoLetterRegionCode)
            {
                case "CH":
                    rate = 0.08M;
                    break;
                case "DK":
                case "NO":
                    rate = 0.25M;
                    break;
                case "GB":
                case "FR":
                    rate = 0.2M;
                    break;
                case "HU":
                    rate = 0.27M;
                    break;
                case "OR":
                case "AK":
                case "MT":
                    rate = 0.0M;
                    break;
                case "ND":
                case "WI":
                case "ME":
                case "VA":
                    rate = 0.05M;
                    break;
                case "CA":
                    rate = 0.0825M;
                    break;
                default:
                    rate = 0.06M;
                    break;
            }
            return amount * rate;
        }

        static decimal CalculateTaxViaSwitchExpression(decimal amount, string twoLetterRegionCode)
        {
            decimal rate = twoLetterRegionCode.ToUpper() switch
            {
                "CH" => rate = 0.08M,
                "DK" => rate = 0.25M,
                "NO" => rate = 0.25M,
                "GB" => rate = 0.2M,
                "FR" => rate = 0.2M,
                "HU" => rate = 0.27M,
                "OR" => rate = 0.0M,
                "AK" => rate = 0.0M,
                "MT" => rate = 0.0M,
                "ND" => rate = 0.05M,
                "WI" => rate = 0.05M,
                "ME" => rate = 0.05M,
                "VA" => rate = 0.05M,
                "CA" => rate = 0.0825M,
                _ => rate = 0.06M
            };

            return amount * rate;
        }

        static void RunCalculateTask()
        {
            Write("Enter an amount: ");
            string amountInText = ReadLine();
            Write("Enter a two-letter region code: ");
            string region = ReadLine();
            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTaxViaSwitchExpression(amount, region);
                WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                WriteLine("You did not enter a valid amount.");
            }
        }

        /// <summary>
        /// Pass a 32-bit integer and it will be converted to its ordinal equivalent.
        /// </summary>
        /// <param name="number">Number as a cardinal value, e.g. 1, 2, 3 and so on.</param>
        /// <returns>Number as an ordinal value, e.g. 1st, 2nd, 3rd and so on.</returns>
        static string CardinalToOrdinal(int number)
        {
            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    int lastDigit = number % 10;
                    string suffix = lastDigit switch
                    {
                        1 => "st",
                        2 => "nd",
                        3 => "rd",
                        _ => "th"
                    };
                    return $"{number}{suffix}";
            }
        }

        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number <= 40; number++)
            {
                Write($"{CardinalToOrdinal(number)} ");
            }
        }

        static int Factorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                checked
                {
                    return number * Factorial(number - 1);
                }
            }
        }

        static void RunFactorial()
        {
            for (int i = 1; i < 15; i ++)
            {
                try
                {
                    WriteLine($"{i}! = {Factorial(i):N0}");
                }
                catch (OverflowException)
                {
                    WriteLine($"{i}! is too big for a 32-bit integer.");
                }
            }
        }

        static int FibImperative(int term)
        {
            if (term == 1)
            {
                return 0;
            }
            else if (term == 2)
            {
                return 1;
            }
            else
            {
                return FibImperative(term - 1) + FibImperative(term - 2);
            }
        }

        static void RunFibImperative()
        {
            for (int i = 1; i <= 30; i++)
            {
                WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
                    arg0: CardinalToOrdinal(i),
                    arg1: FibImperative(i)
                );
            }
        }

        static int FibFunctional(int term) =>
            term switch
            {
                1 => 0,
                2 => 1,
                _ => FibFunctional(term - 1) + FibFunctional(term - 2)
            };

        static void RunFibFunctional()
        {
            for (int i = 1; i <= 30; i++)
            {
                WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
                    arg0: CardinalToOrdinal(i),
                    arg1: FibFunctional(i)
                );
            }
        }

        static void Main(string[] args)
        {
            // RunTimesTable();
            // RunCalculateTask();
            // RunCardinalToOrdinal();
            // RunFactorial();
            // RunFibImperative();
            RunFibFunctional();
        }
    }
}
