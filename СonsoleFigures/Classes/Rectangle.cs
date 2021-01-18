using System;
namespace СonsoleFigures.Classes
{
    public class Rectangle : Figure
    {
        public Point LeftTopPoint { get; private set; }

        public decimal Width { get; private set; }

        public decimal Height { get; private set; }

        public override Point Coordinates => LeftTopPoint;

        public override decimal Square => Width * Height;

        public override decimal Perimetr => 2 * Width + 2 * Height;

        public Rectangle(Point point, decimal width, decimal height, string name = "Rectangle") : base(name)
        {
            LeftTopPoint = point;
            Width = width;
            Height = height;
        }

        public override int[,] ToMatrix()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}: Coodinates = {LeftTopPoint} Width = {Width} Height = {Height} {ToDimensionSring()}";
        }
    }
}
