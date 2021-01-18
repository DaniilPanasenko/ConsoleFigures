using System;
namespace СonsoleFigures.Classes
{
    public class Circle : Figure
    {
        public Point Center { get; private set; }

        public decimal Radius { get; private set; }

        public override decimal Square => (decimal)Math.PI * Radius * Radius;

        public override decimal Perimetr => 2 * (decimal)Math.PI * Radius;

        public override Point Coordinates => new Point(Center.X - Radius, Center.Y - Radius);

        public Circle(Point center, decimal radius) : base("Circle")
        {
            Center = center;
            Radius = radius;
        }

        public override int[,] ToMatrix()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}: Center = {Center} Radius = {Radius} {ToDimensionSring()}";
        }
    }
}
