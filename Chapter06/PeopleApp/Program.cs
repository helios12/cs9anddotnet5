using System;

using Packt.Shared;

using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"5! is {Person.Factorial(5)}.");

            Person harry = new Person { Name = "Harry" };
            Person mary = new Person { Name = "Mary" };
            Person jill = new Person { Name = "Jill" };

            Person baby1 = mary.ProcreateWith(harry);
            baby1.Name = "Gary";
            Person baby2 = Person.Procreate(harry, jill);
            Person baby3 = harry * mary;
            WriteLine($"{harry.Name} has {harry.Children.Count} children.");
            WriteLine($"{mary.Name} has {mary.Children.Count} children.");
            WriteLine($"{jill.Name} has {jill.Children.Count} children.");
            WriteLine("{0}'s first child is named \"{1}\".",
                arg0: harry.Name,
                arg1: harry.Children[0].Name
            );

            harry.Shout += Harry_Shout;
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();

            Person [] people = 
            {
                new Person { Name = "Simon" },
                new Person { Name = "Jenny" },
                new Person { Name = "Adam" },
                new Person { Name = "Richard" }
            };
            WriteLine("Initial list of people:");
            foreach (Person person in people)
            {
                WriteLine($"\t{person.Name}");
            }
            WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (Person person in people)
            {
                WriteLine($"\t{person.Name}");
            }

            WriteLine("Use PersonComparer's IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (Person person in people)
            {
                WriteLine($"\t{person.Name}");
            }

            Thing t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer: {t1.Process(42)}");
            Thing t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with a string: {t2.Process("apple")}");

            GenericThing<int> gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer: {gt1.Process(42)}");
            GenericThing<string> gt2 = new GenericThing<string>
            {
                Data = "apple"
            };
            WriteLine($"GenericThing with a string: {gt2.Process("apple")}");

            string number1 = "4";
            WriteLine("{0} squared is {1}.",
                arg0: number1,
                arg1: Squarer.Square<string>(number1)
            );
            byte number2 = 3;
            WriteLine("{0} squared is {1}.",
                arg0: number2,
                arg1: Squarer.Square(number2)
            );

            DisplacementVector dv1 = new DisplacementVector(3, 5);
            DisplacementVector dv2 = new DisplacementVector(-2, 7);
            DisplacementVector dv3 = dv1 + dv2;
            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

            Employee john = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime(1990, 7, 28)
            };
            john.WriteToConsole();
        }

        private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }
    }
}
