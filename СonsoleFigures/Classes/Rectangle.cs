using System;
using СonsoleFigures.Enums;

namespace СonsoleFigures.Classes
{
    public class Rectangle : Figure
    {
        public Point LeftTopPoint { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public override Point Coordinates => LeftTopPoint;

        public override decimal Square => Width * Height;

        public override decimal Perimetr => 2 * Width + 2 * Height;

        private readonly bool[,] _matrix;

        public Rectangle(Point point, int width, int height, bool isHollow, string name = "Rectangle") : base(name, isHollow)
        {
            LeftTopPoint = point;
            Width = width;
            Height = height;
            _matrix = GetMatrix();
        }

        private bool[,] GetMatrix()
        {
            bool[,] result = new bool[Height, Width];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = true;
                }
            }
            if (IsHollow)
            {
                for (int i = 1; i < result.GetLength(0)-1; i++)
                {
                    for (int j = 1; j < result.GetLength(1)-1; j++)
                    {
                        result[i, j] = false;
                    }
                }
            }
            return result;
        }

        public override void ChangePosition(Direction direction)
        {
            LeftTopPoint.ChangePosition(direction);
        }

        public override bool[,] ToMatrix() => _matrix;

        public override string ToString()
        {
            return $"{Name}: Coodinates = {LeftTopPoint} Width = {Width} Height = {Height} {ToDimensionSring()}";
        }
    }
}
