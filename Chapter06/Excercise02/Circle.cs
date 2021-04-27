namespace Excercise02
{
    public class Circle : Shape
    {
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
            {
                throw new System.NotImplementedException("Define height via width.");
            }
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