using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Numerics;

namespace Packt.Shared
{
    public static class NumbersExtensionMethods
    {
        private static ImmutableDictionary<int, string> BigNumberNames = new Dictionary<int, string>() 
        {
            {1, "thousand"}, 
            {2, "million"}, 
            {3, "billion"}, 
            {4, "trillion"}, 
            {5, "quadrillion"}
        }.ToImmutableDictionary();
        private static ImmutableDictionary<int, string> TenthNumberNames = new Dictionary<int, string>() 
        {
            {11, "eleven"}, 
            {12, "twelve"}, 
            {13, "thirteen"}, 
            {14, "fourteen"}, 
            {15, "fifteen"}, 
            {16, "sixteen"}, 
            {17, "seventeen"}, 
            {18, "eighteen"}, 
            {19, "nineteen"}
        }.ToImmutableDictionary();
        private static ImmutableDictionary<int, string> TenthRowNumberNames = new Dictionary<int, string>() 
        {
            {1, "ten"}, 
            {2, "twenty"}, 
            {3, "thirty"}, 
            {4, "fourty"}, 
            {5, "fifty"}, 
            {6, "sixty"}, 
            {7, "seventy"}, 
            {8, "eighty"}, 
            {9, "ninety"}
        }.ToImmutableDictionary();
        private static ImmutableDictionary<int, string> DigitNames = new Dictionary<int, string>() 
        {
            {1, "one"}, 
            {2, "two"}, 
            {3, "three"}, 
            {4, "four"}, 
            {5, "five"}, 
            {6, "six"}, 
            {7, "seven"}, 
            {8, "eight"}, 
            {9, "nine"}
        }.ToImmutableDictionary();

        public static string GetNumberDescription(this BigInteger number) 
        {
            string result = string.Empty;
            int positionCounter = 0;
            BigInteger currentNumber = number;
            
            while (currentNumber > 0)
            {
                int currentPart = (int)(currentNumber % 1000);
                string currentPartAsString = GetThreeDigitNumberDescription(currentPart);
                result = string.IsNullOrWhiteSpace(result) ? 
                    currentPartAsString :
                    string.Format("{0} {1}, {2}",
                        currentPartAsString,
                        BigNumberNames[positionCounter],
                        result
                    );
                positionCounter++;
                currentNumber /= 1000;
            }

            return result;
        }

        public static string GetNumberDescription(this int number)
        {
            return GetNumberDescription(new BigInteger(number));
        }

        private static string GetThreeDigitNumberDescription(int number)
        {
            string result = string.Empty;

            int lastTwoDigits = number % 100;
            if (TenthNumberNames.ContainsKey(lastTwoDigits))
            {
                result = TenthNumberNames[lastTwoDigits];
            }
            else
            {
                int thirdDigit = lastTwoDigits % 10;
                if (thirdDigit != 0)
                {
                    result = DigitNames[thirdDigit];
                }

                int secondDigit = lastTwoDigits / 10;
                if (secondDigit != 0)
                {
                    result = SafeConcatNumberName(result, TenthRowNumberNames[secondDigit]);
                }
            }

            int firstDigit = number / 100;
            if (firstDigit != 0)
            {
                string fullFirstDigitName = DigitNames[firstDigit] + " hundred";
                result = SafeConcatNumberName(result, fullFirstDigitName);
            }

            return result;
        }

        private static string SafeConcatNumberName(string result, string newBlock)
        {
            if (string.IsNullOrWhiteSpace(result))
            {
                result = newBlock;
            }
            else
            {
                result = string.Format("{0} {1}",
                        newBlock,
                        result
                );
            }

            return result;
        }
    }
}
