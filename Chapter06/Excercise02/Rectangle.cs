namespace Excercise02
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Area 
        { 
            get
            {
                return Width * Height;
            }
        }
    }
}