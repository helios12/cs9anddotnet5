using System;

using static System.Console;
using static System.Convert;

namespace CastingConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            double b = a;
            WriteLine(b);

            double c = 9.8;
            int d = (int)c;
            WriteLine(d);

            long e = 10;
            int f = (int)e;
            WriteLine($"e is {e:N0} and f is {f:N0}");
            e = 5_000_000_000;
            f = (int)e;
            WriteLine($"e is {e:N0} and f is {f:N0}");

            double g = 9.8;
            int h = ToInt32(g);
            WriteLine($"g is {g} and h is {h}");

            double[] doubles = {9.49, 9.5, 9.51, 10.49, 10.5, 10.51};
            foreach (double n in doubles)
            {
                WriteLine($"ToInt32({n}) is {ToInt32(n)}");
            }

            foreach (double n in doubles)
            {
                WriteLine(format:
                    "Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
                    arg0: n,
                    arg1: Math.Round(n, 0, MidpointRounding.AwayFromZero)
                );
            }

            foreach (double n in doubles)
            {
                WriteLine(format:
                    "Math.Round({0}, 0, MidpointRounding.ToZero) is {1}",
                    arg0: n,
                    arg1: Math.Round(n, 0, MidpointRounding.ToZero)
                );
            }
        }
    }
}
