using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using Packt.Shared;

using static System.Console;

namespace WorkingWithReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Assembly metadata:");
            Assembly assembly = Assembly.GetEntryAssembly();
            WriteLine($" Full name: {assembly.FullName}");
            WriteLine($" Location: {assembly.Location}");
            IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();
            WriteLine($" Attributes:");
            foreach (Attribute a in attributes)
            {
                WriteLine($" {a.GetType()}");
            }

            AssemblyInformationalVersionAttribute version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            WriteLine($" Version: {version.InformationalVersion}");
            AssemblyCompanyAttribute company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            WriteLine($" Company: {company.Company}");

            WriteLine();
            WriteLine("* Types:");
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                WriteLine();
                WriteLine($"Type: {type.FullName}");
                MemberInfo[] members = type.GetMembers();
                foreach (MemberInfo member in members)
                {
                    WriteLine("{0}: {1} ({2})",
                        arg0: member.MemberType,
                        arg1: member.Name,
                        arg2: member.DeclaringType.Name
                    );
                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);
                    foreach (CoderAttribute coder in coders)
                    {
                        WriteLine("Modified by {0} on {1}",
                            coder.Coder,
                            coder.LastModified.ToShortDateString()
                        );
                    }
                }
            }
        }

        [Coder("Dmitriy Golubitskiy", "09 May 2021")]
        [Coder("Diana Golubitski", "11 August 2028")]
        public static void DoStuff()
        {

        }
    }
}
