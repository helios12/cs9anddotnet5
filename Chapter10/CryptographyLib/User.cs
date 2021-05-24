using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Packt.Shared
{
    public class User
    {
        public string Name {get; set;}
        public string Salt {get; set;}
        public string SaltedHashedPassword {get; set;}
        public string[] Roles {get; set;}

        public static Dictionary<string, User> CurrentUsers = new Dictionary<string, User>();

        public static User Register(string userName, string password, string[] roles = null)
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
                SaltedHashedPassword = saltedHashedPassword,
                Roles = roles
            };
            CurrentUsers.Add(user.Name, user);
            return user;
        }


    }
}
