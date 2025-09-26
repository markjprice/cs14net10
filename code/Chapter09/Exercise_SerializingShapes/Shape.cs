using System.Xml.Serialization; // To use [XmlInclude] attribute.

namespace Packt.Shared;

[XmlInclude(typeof(Circle))]
[XmlInclude(typeof(Rectangle))]
public abstract class Shape
{
  public string? Color { get; set; }
  public abstract double Area { get; }
}
