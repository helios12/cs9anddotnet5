using System;

using static System.Console;

namespace Excercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(4.5, 3);
            WriteLine($"Rectangle H: {r.Height}, W: {r.Width}, Area: {r.Area}");

            Square s = new Square(5);
            WriteLine($"Square H: {s.Height}, W: {s.Width}, Area: {s.Area}");

            Circle c = new Circle(2.5);
            WriteLine($"Circle H: {c.Height}, W: {c.Width}, Area: {c.Area}");
        }
    }
}
