using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using static System.Console;

namespace Excercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> listOfShapes = new List<Shape>
            {
                new Circle(radius: 2.5) {Color = "Red"},
                new Rectangle(height: 20, width: 10) {Color = "Blue"},
                new Circle(radius: 8) {Color = "Green"},
                new Circle(radius: 12.3) {Color = "Purple"},
                new Rectangle(height: 45, width: 18) {Color = "Blue"}
            };

            string path = Path.Combine(Environment.CurrentDirectory, "shapes.xml");
            XmlSerializer xs = new XmlSerializer(typeof(List<Shape>));
            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, listOfShapes);
            }

            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                List<Shape> loadedShapes = xs.Deserialize(xmlLoad) as List<Shape>;
                foreach (Shape item in loadedShapes)
                {
                    WriteLine("{0} is {1} and has an area of {2:N2}.",
                        arg0: item.GetType().Name,
                        arg1: item.Color,
                        arg2: item.Area
                    );
                }
            }
        }
    }
}
