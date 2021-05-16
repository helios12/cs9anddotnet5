using System;
using System.IO;
using System.IO.Compression;
using System.Xml;

using static System.Console;

namespace WorkingWithStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            // WorkWithText();
            // WorkWithXml();
            WorkWithCompression();
            WorkWithCompression(false);
        }

        static string[] callsigns = 
            new string[] {"Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack"};

        static void WorkWithText()
        {
            string textFile = Path.Combine(Environment.CurrentDirectory, "streams.txt");
            StreamWriter text = File.CreateText(textFile);
            foreach (string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close();
            WriteLine("{0} contains {1:N0} bytes.",
                arg0: textFile,
                arg1: new FileInfo(textFile).Length
            );
            WriteLine(File.ReadAllText(textFile));
        }

        static void WorkWithXml()
        {
            FileStream xmlStream = null;
            XmlWriter xml = null;
            try
            {
                string xmlFile = Path.Combine(Environment.CurrentDirectory, "streams.xml");
                xmlStream = File.Create(xmlFile);
                xml = XmlWriter.Create(xmlStream, new XmlWriterSettings {Indent = true});
                xml.WriteStartDocument();
                xml.WriteStartElement("callsigns");
                foreach (string item in callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }
                xml.WriteEndElement();
                xml.Close();
                xmlStream.Close();
                WriteLine("{0} contains {1:N0} bytes.",
                    arg0: xmlFile,
                    arg1: new FileInfo(xmlFile).Length
                );
                WriteLine(File.ReadAllText(xmlFile));
            }
            catch(Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                }
                if (xmlStream != null)
                {
                    xmlStream.Dispose();
                    WriteLine("The file stream's unmanaged resources have beedn disposed.");
                }
            }

            using (FileStream file2 = File.OpenWrite(Path.Combine(Environment.CurrentDirectory, "file2.txt")))
            {
                using (StreamWriter writer2 = new StreamWriter(file2))
                {
                    try
                    {
                        writer2.WriteLine("Welcome, dotnet!");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"{ex.GetType()}: {ex.Message}");
                    }
                }
            }
        }

        static void WorkWithCompression(bool useBrotli = true)
        {
            string fileExtension = useBrotli ? "brotli" : "gzip";
            string gzipFilePath = Path.Combine(Environment.CurrentDirectory, $"streams.{fileExtension}");
            FileStream file = File.Create(gzipFilePath);
            Stream compressor = useBrotli ?
                new BrotliStream(file, CompressionMode.Compress) :
                new GZipStream(file, CompressionMode.Compress);
            using (compressor)
            {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("callsigns");
                    foreach (string item in callsigns)
                    {
                        xmlGzip.WriteElementString("callsign", item);
                    }                    
                }
            }

            WriteLine("{0} contains {1:N0} bytes.",
                arg0: gzipFilePath,
                arg1: new FileInfo(gzipFilePath).Length
            );
            WriteLine("The compressed contents:");
            WriteLine(File.ReadAllText(gzipFilePath));

            WriteLine("Reading the compresssed XML file:");
            file = File.Open(gzipFilePath, FileMode.Open);
            Stream decompressor = useBrotli ?
                new BrotliStream(file, CompressionMode.Decompress):
                new GZipStream(file, CompressionMode.Decompress);
            using (decompressor)
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                        {
                            reader.Read();
                            WriteLine(reader.Value);
                        }
                    }
                }
            }
        }
    }
}
