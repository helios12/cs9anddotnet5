using System;

using Packt.Shared;

using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 2);
            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            WriteLine(format: "{0} was born on {1:dddd, dd MMMM yyyy}",
                arg0: bob.Name,
                arg1: bob.DateOfBirth);
            WriteLine(format: "{0}'s favorite wonder is {1}. Its byte is {2}.",
                arg0: bob.Name,
                arg1: bob.FavoriteAncientWonder,
                arg2: (byte)bob.FavoriteAncientWonder);
            bob.Children.Add(new Person { Name = "Alfred" });
            bob.Children.Add(new Person { Name = "Zoe" });
            WriteLine($"{bob.Name} has {bob.Children.Count} children:");
            foreach (Person child in bob.Children)
            {
                WriteLine($"\t- {child.Name}");
            }
            WriteLine($"{bob.Name} is a {Person.Species}.");
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");
            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());
            (string, int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
            (string Name, int Number) namedFruit = bob.GetNamedFruit();
            WriteLine($"There are {namedFruit.Number} {namedFruit.Name}.");
            (string fruitName, int fruitNumber) = bob.GetFruit();
            WriteLine($"Deconstructed: {fruitName} and {fruitNumber}.");
            WriteLine(bob.SayHello());
            WriteLine(bob.SayHello("Emily"));
            WriteLine(bob.OptionalParameters());
            WriteLine(bob.OptionalParameters("Jump!", 98.5));
            WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));
            WriteLine(bob.OptionalParameters(command: "Poke!", active: false));

            Person alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };
            WriteLine(format: "{0} was born on {1:dd MMM yy}",
                arg0: alice.Name,
                arg1: alice.DateOfBirth);

            BankAccount.InterestRate = 0.012M;
            BankAccount jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine(format: "{0} earned {1:C} interest.",
                arg0: jonesAccount.AccountName,
                arg1: jonesAccount.Balance * BankAccount.InterestRate);
            BankAccount gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;
            WriteLine(format: "{0} earned {1:C} interest.",
                arg0: gerrierAccount.AccountName,
                arg1: gerrierAccount.Balance * BankAccount.InterestRate);

            Person blankPerson = new Person();
            WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0: blankPerson.Name,
                arg1: blankPerson.HomePlanet,
                arg2: blankPerson.Instantiated
            );
            
            Person gunny = new Person("Gunny", "Mars");
            WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0: gunny.Name,
                arg1: gunny.HomePlanet,
                arg2: gunny.Instantiated
            );

            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
            var thing2 = (bob.Name, bob.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count} children.");

            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Before: a = {a}, b = {b}, c = {c}.");
            bob.PassingParameters(a, ref b, out c);
            WriteLine($"After: a = {a}, b = {b}, c = {c}.");
            int d = 10;
            int e = 20;
            WriteLine($"Before: d = {d}, e = {e}, f does not exist yet.");
            bob.PassingParameters(d, ref e, out int f);
            WriteLine($"After: d = {d}, e = {e}, f = {f}.");

            Person sam = new Person
            {
                Name = "Sam",
                DateOfBirth = new DateTime(1972, 1, 27)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);
            sam.FavoriteIceCream = "Chocolate Fudge";
            WriteLine($"{sam.Name}'s favorite ice-cream flavor is {sam.FavoriteIceCream}.");
            sam.FavoritePrimaryColor = "Red";
            WriteLine($"{sam.Name}'s favorite primary color is {sam.FavoritePrimaryColor}.");
            sam.Children.Add(new Person { Name = "Charlie" });
            sam.Children.Add(new Person { Name = "Ella" });
            WriteLine($"{sam.Name}'s first child is {sam.Children[0].Name}.");
            WriteLine($"{sam.Name}'s second child is {sam.Children[1].Name}.");
            WriteLine($"{sam.Name}'s first child is {sam[0].Name}.");
            WriteLine($"{sam.Name}'s second child is {sam[1].Name}.");

            object [] passengers = {
                new FirstClassPassenger { AirMiles = 1_419 }, 
                new FirstClassPassenger { AirMiles = 16_562 }, 
                new BusinessClassPassenger(), 
                new CoachClassPassenger { CarryOnKG = 25.7 },
                new CoachClassPassenger { CarryOnKG = 0 }
            };
            foreach (var passenger in passengers)
            {
                decimal flightCost = passenger switch
                {
                    FirstClassPassenger p => p.AirMiles switch 
                    {
                        > 35000 => 1500M,
                        > 15000 => 1750M,
                        _ => 2000M
                    },
                    BusinessClassPassenger => 1000M,
                    CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
                    CoachClassPassenger => 650M,
                    _ => 800M
                };
                WriteLine($"Flight costs {flightCost:C} for {passenger}");
            }

            ImmutablePerson jeff = new ImmutablePerson
            {
                FirstName = "Jeff",
                LastName = "Winger"
            };
            // jeff.FirstName = "Geoff";

            ImmutableVehicle car = new ImmutableVehicle
            {
                Brand = "Mazda MX-5 RF",
                Color = "Soul Red Crystal Metallic",
                Wheels = 4
            };
            ImmutableVehicle repaintedCar = car with 
            {
                Color = "Polymetal Grey Metallic"
            };
            WriteLine("Original color was {0}, new color is {1}.",
                arg0: car.Color,
                arg1: repaintedCar.Color
            );

            ImmutablAnimal oscar = new ImmutablAnimal("Oscar", "Labrador");
            var (who, what) = oscar;
            WriteLine($"{who} is a {what}.");
        }
    }
}
