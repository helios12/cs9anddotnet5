﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

using NuJson = System.Text.Json.JsonSerializer;

using Packt.Shared;

using static System.Console;

namespace WorkingWithSerialization
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person(30000M) {FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1974, 3, 14)},
                new Person(40000M) {FirstName = "Bob", LastName = "Jones", DateOfBirth = new DateTime(1969, 11, 23)},
                new Person(20000M) {FirstName = "Charlie", LastName = "Cox", DateOfBirth = new DateTime(1984, 5, 4),
                    Children = new HashSet<Person> 
                    {
                        new Person(0M) {FirstName = "Sally", LastName = "Cox", DateOfBirth = new DateTime(2000, 7, 12)}
                    }
                }
            };

            XmlSerializer xs = new XmlSerializer(typeof(List<Person>));
            string path = Path.Combine(Environment.CurrentDirectory, "people.xml");
            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, people);
            }

            WriteLine("Written {0:N0} bytes of XML to {1}",
                arg0: new FileInfo(path).Length,
                arg1: path
            );
            WriteLine();

            WriteLine(File.ReadAllText(path));

            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                List<Person> loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);
                foreach (Person item in loadedPeople)
                {
                    WriteLine("{0} has {1} children.", item.LastName, item.Children.Count);
                }
            }

            string jsonPath = Path.Combine(Environment.CurrentDirectory, "people.json");
            using (StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                Newtonsoft.Json.JsonSerializer jss = new Newtonsoft.Json.JsonSerializer();
                jss.Serialize(jsonStream, people);
            }
            WriteLine();
            WriteLine("Written {0:N0} bytes of JSON to {1}",
                arg0: new FileInfo(jsonPath).Length,
                arg1: jsonPath
            );
            WriteLine(File.ReadAllText(jsonPath));

            using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
            {
                List<Person> loadedPeople = 
                    (List<Person>)await NuJson.DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Person>));
                foreach (Person item in loadedPeople)
                {
                    WriteLine("{0} has {1} childeren.",
                        item.LastName,
                        item.Children?.Count ?? 0
                    );
                }
            }
        }
    }
}
