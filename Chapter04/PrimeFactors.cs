using System;

namespace PrimeFactors
{
    public class PrimeFactors
    {
        public string GetPrimeFactors(int number)
        {
            string result = "";
            int i = 2;
            while (i <= number / 2)
            {
                if (number % i == 0)
                {
                    result = string.IsNullOrWhiteSpace(result) ? number.ToString() : $"{result}, {number}";
                }

                if (i == number / 2)
                {
                    if (result == "")
                    {
                        result = number.ToString();
                    }
                }
                else
                {
                    i++;
                }
            }  
            return result;
        }
    }
}
