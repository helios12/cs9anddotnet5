using System;
using System.Collections.Generic;

using static System.Console;

namespace Packt.Shared
{
    public class Person
    {
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();
        
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth: dddd}.");
        }

        public static Person Procreate(Person p1, Person p2)
        {
            Person baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}."
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }

        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }
    }
}
