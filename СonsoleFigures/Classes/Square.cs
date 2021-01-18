using System;
namespace СonsoleFigures.Classes
{
    public class Square : Rectangle
    {
        public Square(Point point, decimal width) : base(point, width, width, "Square")
        {
        }

        public override string ToString()
        {
            return $"{Name}: Coodinates = {LeftTopPoint} Width = {Width}  {ToDimensionSring()}";
        }
    }
}
