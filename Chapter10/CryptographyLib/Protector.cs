using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;

namespace Packt.Shared
{
    public static class Protector
    {
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");
        private static readonly int iterations = 2000;

        public static string PublicKey;

        public static string Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            Aes aes = GetAes(password);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cryptoText, string password)
        {
            byte[] plainBytes;
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            Aes aes = GetAes(password);
            
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                plainBytes = ms.ToArray();
            }

            return Encoding.Unicode.GetString(plainBytes);
        }

        public static string SaltAndHash(string value, string salt)
        {
            SHA256 sha = SHA256.Create();
            string saltedValue = value + salt;
            byte[] hash = sha.ComputeHash(Encoding.Unicode.GetBytes(saltedValue));
            return Convert.ToBase64String(hash);
        }

        public static string ToXmlStringExt(this RSA rsa, bool includePrivateParameters)
        {
            RSAParameters p = rsa.ExportParameters(includePrivateParameters);
            XElement xml = new XElement("RSAKeyValue",
                new XElement("Modulus", Convert.ToBase64String(p.Modulus)),
                new XElement("Exponent", Convert.ToBase64String(p.Exponent)));
            if (includePrivateParameters)
            {
                xml.Add(new XElement("P", Convert.ToBase64String(p.P)));
                xml.Add(new XElement("Q", Convert.ToBase64String(p.Q)));
                xml.Add(new XElement("DP", Convert.ToBase64String(p.DP)));
                xml.Add(new XElement("DQ", Convert.ToBase64String(p.DQ)));
                xml.Add(new XElement("InverseQ", Convert.ToBase64String(p.InverseQ)));
            }
            return xml?.ToString();
        }

        public static void FromXmlStringExt(this RSA rsa, string parametersAsXml)
        {
            XDocument xml = XDocument.Parse(parametersAsXml);
            XElement root = xml.Element("RSAKeyValue");
            RSAParameters p = new RSAParameters
            {
                Modulus = Convert.FromBase64String(root.Element("Modulus").Value),
                Exponent = Convert.FromBase64String(root.Element("Exponent").Value)
            };
            if (root.Element("P") != null)
            {
                p.P = Convert.FromBase64String(root.Element("P").Value);
                p.Q = Convert.FromBase64String(root.Element("Q").Value);
                p.DP = Convert.FromBase64String(root.Element("DP").Value);
                p.DQ = Convert.FromBase64String(root.Element("DQ").Value);
                p.InverseQ = Convert.FromBase64String(root.Element("InverseQ").Value);
            }
            rsa.ImportParameters(p);
        }

        public static string GenerateSignature(string data)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            SHA256 sha = SHA256.Create();
            byte[] hashedData = sha.ComputeHash(dataBytes);
            RSA rsa = RSA.Create();
            PublicKey = rsa.ToXmlStringExt(false);
            byte[] signedData = rsa.SignHash(hashedData, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            return Convert.ToBase64String(signedData);
        }

        public static bool ValidateSignature(string data, string signature)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            SHA256 sha = SHA256.Create();
            byte[] hashedData = sha.ComputeHash(dataBytes);
            byte[] signatureBytes = Convert.FromBase64String(signature);
            RSA rsa = RSA.Create();
            rsa.FromXmlStringExt(PublicKey);
            return rsa.VerifyHash(hashedData, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }

        private static Aes GetAes(string password)
        {
            Aes aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            return aes;
        }

    }
}
