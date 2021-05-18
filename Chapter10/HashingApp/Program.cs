using System;
using System.Collections.Generic;
using System.Security.Cryptography;

using Packt.Shared;

using static System.Console;

namespace HashingApp
{
    class Program
    {
        private static Dictionary<string, User> Users = new Dictionary<string, User>();

        private static User Register(string userName, string password)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            string saltText = Convert.ToBase64String(saltBytes);
            string saltedHashedPassword = Protector.SaltAndHash(password, saltText);
            User user = new User
            {
                Name = userName,
                Salt = saltText,
                SaltedHashedPassword = saltedHashedPassword
            };
            Users.Add(user.Name, user);
            return user;
        }

        private static bool CheckPassword(string userName, string password)
        {
            if (!Users.ContainsKey(userName))
            {
                return false;
            }
            User user = Users[userName];
            string saltedHashedPassword = Protector.SaltAndHash(password, user.Salt);
            return (saltedHashedPassword == user.SaltedHashedPassword);
        }

        static void Main(string[] args)
        {
            WriteLine("Registering Alice with Pa$$w0rd.");
            User alice = Register("Alice", "Pa$$w0rd");
            WriteLine($"Name: {alice.Name}");
            WriteLine($"Salt: {alice.Salt}");
            WriteLine("Password salted and hashed: {0}", alice.SaltedHashedPassword);
            WriteLine();
            Write("Enter a new user to register: ");
            string userName = ReadLine();
            Write($"Enter a password for {userName}: ");
            string password = ReadLine();
            User user = Register(userName, password);
            WriteLine($"Name: {user.Name}");
            WriteLine($"Salt: {user.Salt}");
            WriteLine("Password salted and hashed: {0}", user.SaltedHashedPassword);
            WriteLine();
            bool correctPassword = false;
            while (!correctPassword)
            {
                Write("Enter a user name to log in: ");
                string loginUserName = ReadLine();
                Write("Enter a password to log in: ");
                string loginPassword = ReadLine();
                correctPassword = CheckPassword(loginUserName, loginPassword);
                if (correctPassword)
                {
                    WriteLine($"Correct! {loginUserName} has been logged-in.");
                }
                else
                {
                    WriteLine("Invalid user name and password. Try again.");
                }
            }
        }
    }
}
