using System;
namespace СonsoleFigures.Classes
{
    public class Point
    {
        public decimal X { get; private set; }

        public decimal Y { get; private set; }

        public Point(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
