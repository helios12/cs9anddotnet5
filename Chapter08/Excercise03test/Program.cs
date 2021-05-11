using System;
using System.Numerics;

using Packt.Shared;

using static System.Console;

namespace Packt.Shared
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1234, b = 12005678, c = 1234567890;
            WriteLine(a.GetNumberDescription());
            WriteLine(b.GetNumberDescription());
            WriteLine(c.GetNumberDescription());

            BigInteger bigA = new BigInteger(1234567890123);
            WriteLine(bigA.GetNumberDescription());
        }
    }
}
