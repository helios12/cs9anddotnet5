using System;

using PrimeFactorsLib;

namespace PrimeFactorsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var pf = new PrimeFactors();
            Console.WriteLine(pf.GetPrimeFactors(17));
            Console.WriteLine(pf.GetPrimeFactors(4));
            Console.WriteLine(pf.GetPrimeFactors(30));
            Console.WriteLine(pf.GetPrimeFactors(40));
            Console.WriteLine(pf.GetPrimeFactors(50));
        }
    }
}
