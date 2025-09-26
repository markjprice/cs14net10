using Packt.Shared; // To use Circle, Rectangle, Shape.
using System.Xml.Serialization; // To use XmlSerializer.

using static System.Environment;
using static System.IO.Path;

// Create a file path to write to.
string path = Combine(CurrentDirectory, "shapes.xml");

// Create a list of Shape objects to serialize.
List<Shape> listOfShapes = new()
{
  new Circle { Color = "Red", Radius = 2.5 },
  new Rectangle { Color = "Blue", Height = 20.0, Width = 10.0 },
  new Circle { Color = "Green", Radius = 8 },
  new Circle { Color = "Purple", Radius = 12.3 },
  new Rectangle { Color = "Blue", Height = 45.0, Width = 18.0 }
};

// Create an object that knows how to serialize and deserialize 
// a list of Shape objects.
XmlSerializer serializerXml = new(listOfShapes.GetType());

WriteLine("Saving shapes to XML file:");

using (FileStream fileXml = File.Create(path))
{
  serializerXml.Serialize(fileXml, listOfShapes);
}

WriteLine("Loading shapes from XML file:");
List<Shape>? loadedShapesXml = null;

using (FileStream fileXml = File.Open(path, FileMode.Open))
{
  loadedShapesXml =
    serializerXml.Deserialize(fileXml) as List<Shape>;
}

if (loadedShapesXml == null)
{
  WriteLine($"{nameof(loadedShapesXml)} is empty.");
}
else
{
  foreach (Shape item in loadedShapesXml)
  {
    WriteLine($"{item.GetType().Name} is {item.Color} and has an area of {item.Area:N2}");
  }
}
