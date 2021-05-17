namespace Excercise02
{
    public class Circle : Shape
    {
        public Circle() {}

        public Circle(double radius)
        {
            Width = 2 * radius;
        }

        public override double Height 
        {
            get
            {
                return Width;
            }
            set
            { }
        }

        public override double Area
        {
            get
            {
                return 0.25 * System.Math.PI * Width * Width;
            }
        }
    }
}