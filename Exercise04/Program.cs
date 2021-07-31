using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace Exercise04
{
    class Program
    {
        private static void Main()
        {
            // create a list of shapes 
            var listOfShapes = new List<Shape>
                {
                new Circle { Colour = "Red", Radius = 25.5 },
                new Rectangle { Colour = "Blue", Height = 20.0, Width = 100.0 },
                new Circle { Colour = "Green", Radius = 80.0 },
                new Circle { Colour = "Purple", Radius = 120.3 },
                new Rectangle { Colour = "Blue", Height = 485.0, Width = 18.0 },
                };

            // directory to store xml file
            string pathToFile = Path.Combine(Directory.GetCurrentDirectory(), "shapesFile.xml");

            // create xml file with specified directory
            FileStream streamWrite = File.Create(pathToFile);

            // initalize xml serializer class to serialize and deserialize  xml file
            var serializeXmlFile = new XmlSerializer(typeof(List<Shape>));

            // seriliaze file
            serializeXmlFile.Serialize(streamWrite, listOfShapes);

            // close stream to release resources
            streamWrite.Close();

            // open xml file for reading to be  deserialized
            using FileStream storedXMLFile = File.OpenRead(pathToFile);

            // loop through each item in the opened xml document and deserialize it
            List<Shape> shapesInXMLFile =
              serializeXmlFile.Deserialize(stream: storedXMLFile) as List<Shape>;
            foreach (Shape item in shapesInXMLFile)
            {
                Console.WriteLine("{0} is {1} and has an area of {2:N2}",
                  item.GetType().Name, item.Colour, item.Area);
            }
        }
    }
}
