using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Packt.Shared
{
    public static class NumbersExtensionMethods
    {
        private static ImmutableDictionary<int, string> NumberNames = new Dictionary<int, string>() 
        {
            {1, "thousand"}, 
            {2, "million"}, 
            {3, "billion"}, 
            {4, "trillion"}, 
            {5, "quadrillion"}
        }.ToImmutableDictionary();

        public static string GetNumberDescription(this int number)
        {
            string result = string.Empty;
            int positionCounter = 0;
            int currentNumber = number;
            
            while (currentNumber > 0)
            {
                int currentPart = currentNumber % 1000;
                result = string.IsNullOrWhiteSpace(result) ? 
                    currentPart.ToString() :
                    string.Format("{0} {1}, {2}",
                        currentPart.ToString(),
                        NumberNames[positionCounter],
                        result
                    );
                positionCounter++;
                currentNumber /= 1000;
            }

            return result;
        }
    }
}
