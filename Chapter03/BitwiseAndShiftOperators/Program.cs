using System;

using static System.Console;

namespace BitwiseAndShiftOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 6;
            WriteLine($"a = {a}");
            WriteLine($"b = {b}");
            WriteLine($"a & b = {a & b}");
            WriteLine($"a | b = {a | b}");
            WriteLine($"a ^ b = {a ^ b}");

            WriteLine($"a << 3 = {a << 3}");
            WriteLine($"a * 8 = {a * 8}");
            WriteLine($"b >> 1 = {b >> 1}");

            System.Diagnostics.Stopwatch stopWatch = System.Diagnostics.Stopwatch.StartNew();
            for (long i = 0; i < (long)int.MaxValue * 10; i++)
            {
                int newValue = a * 8;
            }
            stopWatch.Stop();
            WriteLine($"multiplication took {stopWatch.ElapsedMilliseconds} ms");

            stopWatch.Restart();
            for (long i = 0; i < (long)int.MaxValue * 10; i++)
            {
                int newValue = a << 3;
            }
            stopWatch.Stop();
            WriteLine($"left-shifting took {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}
