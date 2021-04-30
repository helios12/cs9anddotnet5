using System;
using System.Numerics;

using static System.Console;

namespace WorkingWithNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong largest = ulong.MaxValue;
            WriteLine($"{largest,40:N0}");
            BigInteger atomsInTheUniverse = BigInteger.Parse("123456789012345678901234567890");
            WriteLine($"{atomsInTheUniverse,40:N0}");

            Complex c1 = new Complex(4, 2);
            Complex c2 = new Complex(3, 7);
            Complex c3 = c1 + c2;
            WriteLine($"{c1} added to {c2} is {c3}");
        }
    }
}
