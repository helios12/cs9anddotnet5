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

            int number = 12;
            WriteLine(number.ToString());
            bool boolean = true;
            WriteLine(boolean.ToString());
            DateTime now = DateTime.Now;
            WriteLine(now.ToString());
            object me = new object();
            WriteLine(me);

            byte[] binaryObject = new byte[128];
            (new Random()).NextBytes(binaryObject);
            WriteLine("Binary object as bytes:");
            for (int i = 0; i < binaryObject.Length; i++)
            {
                Write($"{binaryObject[i]:X} ");
            }
            WriteLine();
            string encoded = Convert.ToBase64String(binaryObject);
            WriteLine($"Binary object as Base64: {encoded}");

            int age = int.Parse("39");
            DateTime birthday = DateTime.Parse("12 May 1981");
            WriteLine($"I was born {age} years ago.");
            WriteLine($"My birthday is {birthday}.");
            WriteLine($"My birthday is {birthday:D}.");

            Write("How many eggs are there? ");
            int count;
            string input = ReadLine();
            if (int.TryParse(input, out count))
            {
                WriteLine($"There are {count} eggs.");
            }
            else
            {
                WriteLine("I could not parse the input!");
            }
        }
    }
}
