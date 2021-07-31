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
            var listOfShapes = new List<Shape>
                {
                new Circle { Colour = "Red", Radius = 25.5 },
                new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Colour = "Green", Radius = 8.0 },
                new Circle { Colour = "Purple", Radius = 12.3 },
                new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 },
                };

            string path = Path.Combine(Directory.GetCurrentDirectory(), "shapesFile.xml");
            FileStream stream = File.Create(path);


            var serializerXml = new XmlSerializer(typeof(List<Shape>));
            serializerXml.Serialize(stream, listOfShapes);
            stream.Close();

            using FileStream fileXml = File.OpenRead(path);

            List<Shape> loadedShapesXml =
              serializerXml.Deserialize(fileXml) as List<Shape>;
            foreach (Shape item in loadedShapesXml)
            {
                Console.WriteLine("{0} is {1} and has an area of {2:N2}",
                  item.GetType().Name, item.Colour, item.Area);
            }
        }
    }
}
