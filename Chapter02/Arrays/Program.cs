using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names;
            names = new string[4];
            names[0] = "Diana";
            names[1] = "Vera";
            names[2] = "Lena";
            names[3] = "Dima";

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
