using System.Xml.Serialization;

namespace Excercise02
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Square))]
    public class Shape
    {
        public virtual double Height { get; set; }
        public virtual double Width { get; set; }
        public virtual string Color { get; set; }
        public virtual double Area { get; }
    }
}