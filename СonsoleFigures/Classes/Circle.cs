using System;
namespace СonsoleFigures.Classes
{
    public class Circle : Figure
    {
        public Point Center { get; private set; }

        public int Radius { get; private set; }

        public override decimal Square => (decimal)Math.PI * Radius * Radius;

        public override decimal Perimetr => 2 * (decimal)Math.PI * Radius;

        public override Point Coordinates => new Point(Center.X - Radius, Center.Y - Radius);

        public Circle(Point center, int radius, bool isHollow) : base("Circle", isHollow)
        {
            Center = center;
            Radius = radius;
        }

        public override bool[,] ToMatrix()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}: Center = {Center} Radius = {Radius} {ToDimensionSring()}";
        }
    }
}
