namespace Excercise02
{
    public class Square : Shape
    {
        public Square() {}
        
        public Square(double width)
        {
            Width = width;
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
                return Width * Width;
            }
        }
    }
}