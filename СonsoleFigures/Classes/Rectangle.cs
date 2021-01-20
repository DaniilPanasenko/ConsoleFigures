using System;
using System.Text.Json.Serialization;
using СonsoleFigures.Enums;

namespace СonsoleFigures.Classes
{
    [Serializable]
    public class Rectangle : Figure
    {
        public Point LeftTopPoint { get;  set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public override Point Coordinates => LeftTopPoint;

        public override decimal Square => Width * Height;

        public override decimal Perimetr => 2 * Width + 2 * Height;

        private bool[,] _matrix;

        public Rectangle() { }

        public Rectangle(Point point, int width, int height, bool isHollow, string name = "Rectangle") : base(name, isHollow)
        {
            LeftTopPoint = point;
            Width = width;
            Height = height;
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

        public override bool[,] ToMatrix()
        {
            if (_matrix == null)
            {
                _matrix = GetMatrix();
            }
            return _matrix;
        }

        public override string ToString()
        {
            return $"{Name}: Coodinates = {LeftTopPoint} Width = {Width} Height = {Height} {ToDimensionSring()}";
        }
    }
}
