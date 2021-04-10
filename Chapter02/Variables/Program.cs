using System;
using System.IO;
using System.Xml;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88;
            object name = "Amir";
            Console.WriteLine($"{name} is {height} meters tall.");
            
            int length = ((string)name).Length;
            Console.WriteLine($"{name} has {length} characters.");

            dynamic anotherName = "Ahmed";
            int length1 = anotherName.Length;
            Console.WriteLine(length1);

            var population = 66_000_000;
            var weight = 1.88;
            var price = 1.99M;
            var fruit = "apples";
            var letter = 'Z';
            var happy = true;

            // var xml1 = new XmlDocument();
            // XmlDocument xml2 = new XmlDocument();
            // var file1 = File.CreateText(@"c:\file1.txt");
            // StreamWriter file2 = File.CreateText(@"c:\file2.txt");
            // XmlDocument xml3 = new();

            Console.WriteLine($"default(int) is {default(int)}");
            Console.WriteLine($"default(bool) is {default(bool)}");
            Console.WriteLine($"default(DateTime) is {default(DateTime)}");
            Console.WriteLine($"default(string) is {default(string)}");
        }
    }
}
