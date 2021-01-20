using System;
namespace СonsoleFigures.Classes
{
    [Serializable]
    public class Square : Rectangle
    {
        public Square() { }

        public Square(Point point, int width, bool isHollow) : base(point, width, width, isHollow, "Square")
        {
        }

        public override string ToString()
        {
            return $"{Name}: Coodinates = {LeftTopPoint} Width = {Width}  {ToDimensionSring()}";
        }
    }
}
