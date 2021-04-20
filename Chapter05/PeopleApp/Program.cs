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
        }
    }
}
