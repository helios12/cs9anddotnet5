using System;

namespace PrimeFactorsLib
{
    public class PrimeFactors
    {
        public string GetPrimeFactors(int number)
        {
            string result = "";
            int i = 2;
            int currentNumber = number;
            while (i <= number / 2)
            {
                if (currentNumber % i == 0)
                {
                    result = string.IsNullOrWhiteSpace(result) ? i.ToString() : $"{i} x {result}";
                    currentNumber /= i;
                }
                else
                {
                    if (i == number / 2)
                    {
                        if (result == "")
                        {
                            result = number.ToString();
                        }
                    }
                    i++;
                }

            }  
            return result;
        }
    }
}
