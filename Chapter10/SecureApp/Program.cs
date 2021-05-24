using System;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Claims;

using static System.Console;

using Packt.Shared;

namespace SecureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User.Register("Alice", "Pa$$w0rd", new[] {"Admins"});
            User.Register("Bob", "Pa$$w0rd", new[] {"Sales", "TeamLeads"});
            User.Register("Eve", "Pa$$w0rd");
            Write("Enter your user name: ");
            string userName = ReadLine();
            Write("Enter your password: ");
            string password = ReadLine();
            Protector.LogIn(userName, password);
            if (Thread.CurrentPrincipal == null)
            {
                WriteLine("Login failed.");
                return;
            }
            IPrincipal p = Thread.CurrentPrincipal;
            WriteLine($"IsAuthenticated: {p.Identity.IsAuthenticated}");
            WriteLine($"AuthenticationType: {p.Identity.AuthenticationType}");
            WriteLine($"Name: {p.Identity.Name}");
            WriteLine($"IsInRole(\"Admins\"): {p.IsInRole("Admins")}");
            WriteLine($"IsInRole(\"Sales\"): {p.IsInRole("Sales")}");
            if (p is ClaimsPrincipal)
            {
                WriteLine($"{p.Identity.Name} has the following claims:");
                foreach (Claim claim in (p as ClaimsPrincipal).Claims)
                {
                    WriteLine($"{claim.Type}: {claim.Value}");
                }
            }

            try 
            {
                SecureFeature();
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }
        }

        static void SecureFeature()
        {
            if (Thread.CurrentPrincipal == null)
            {
                throw new SecurityException("A user must be logged in to access this feature.");
            }
            if (!Thread.CurrentPrincipal.IsInRole("Admins"))
            {
                throw new SecurityException("User must be a member of Admins to access this feature.");
            }
            WriteLine("You have access to this secure feature.");
        }
    }
}
