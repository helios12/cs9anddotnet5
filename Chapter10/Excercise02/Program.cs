using System;
using System.IO;
using System.Xml.Linq;

using Packt.Shared;

using static System.Console;

namespace Excercise02
{
    class Program
    {
        static readonly string EncryptionPassword = "Pa$$w0rd";
        static readonly string Salt = "Salt";

        static void Main(string[] args)
        {
            Write("Enter your name: ");
            string name = ReadLine();
            Write("Enter your credit card number: ");
            string creditCardNumber = ReadLine();
            Write("Enter your password: ");
            string password = ReadLine();

            string encryptedCreditCardNumber = Protector.Encrypt(creditCardNumber, EncryptionPassword);
            string saltedAndHashedPassword = Protector.SaltAndHash(password, Salt);

            XElement customers = new XElement("Customers", new XElement("Customer"));
            XElement customer = customers.Element("Customer");
            customer.Add(new XElement("name", name));
            customer.Add(new XElement("creditcard", encryptedCreditCardNumber));
            customer.Add(new XElement("password", saltedAndHashedPassword));

            string xmlPath = Path.Combine(Environment.CurrentDirectory, Path.GetRandomFileName() + ".xml");
            using (StreamWriter stream = File.CreateText(xmlPath))
            {
                stream.Write(customers.ToString());
            }

            using (StreamReader stream = File.OpenText(xmlPath))
            {
                string cusomersString = stream.ReadToEnd();
                XDocument xml = XDocument.Parse(cusomersString);
                encryptedCreditCardNumber = xml.Element("Customers").Element("Customer").Element("creditcard").Value;
                creditCardNumber = Protector.Decrypt(encryptedCreditCardNumber, EncryptionPassword);
                WriteLine($"Decrypted credit card number: {creditCardNumber}");
            }
        }
    }
}
