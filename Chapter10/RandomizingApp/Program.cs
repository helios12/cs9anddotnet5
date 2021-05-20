using System;

using Packt.Shared;

using static System.Console;

namespace RandomizingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("How big do you want the key (in bytes): ");
            string sizeString = ReadLine();
            int size;
            if (int.TryParse(sizeString, out size))
            {
                byte[] key = Protector.GetRandomKeyOrIV(size);
                WriteLine("Key as byte array:");
                for (int b = 0; b < key.Length; b++)
                {
                    Write($"{key[b]:x2} ");
                    if ((b + 1) % 16 == 0)
                    {
                        WriteLine();
                    }
                }
            }
            else
            {
                WriteLine("Enter a valid key size.");
            }
        }
    }
}
