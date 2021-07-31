using System.Xml.Serialization;

namespace Exercise04
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Circle))]
    public abstract class Shape
    {
        // specify what has to be serilaized 
        [XmlAttribute("colour")]
        public string Colour;
        [XmlAttribute("area")]
        // read only property of area
        public abstract double Area { get; }
    }

    [XmlInclude(typeof(Square))]
    public class Rectangle : Shape
    {
        [XmlAttribute("height")]
        public double Height { get; set; }
        [XmlAttribute("width")]
        public double Width { get; set; }
        public override double Area => Height * Width;
        public Rectangle()
        {
        }
        public Rectangle(double s)
        {
            this.Height = s;
            this.Width = s;
        }
        public Rectangle(double s, double w)
        {
            this.Height = s;
            this.Width = w;
        }
        public Rectangle(double s, string col)
        {
            this.Height = s;
            this.Width = s;
            this.Colour = col;
        }
        public Rectangle(double s, double w, string col)
        {
            this.Height = s;
            this.Width = w;
            this.Colour = col;
        }
    }

    public class Square : Rectangle
    {
        public Square() { }
        public Square(double side)
        {
            this.Height = side;
            this.Width = side;
        }
    }
    public class Circle : Shape
    {
        [XmlAttribute("radius")]
        public double Radius;
        public override double Area => System.Math.PI * this.Radius * this.Radius;
        public Circle()
        {
        }
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public Circle(double radius, string col)
        {
            this.Radius = radius;
            this.Colour = col;

        }
    }
}