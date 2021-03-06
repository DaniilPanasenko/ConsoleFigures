﻿using System;
using System.Text.Json.Serialization;
using СonsoleFigures.Enums;

namespace СonsoleFigures.Classes
{
    [Serializable]
    public class Circle : Figure
    {
        public Point Center { get; set; }

        public int Radius { get; set; }

        public override decimal Square => (decimal)Math.PI * Radius * Radius;

        public override decimal Perimetr => 2 * (decimal)Math.PI * Radius;

        public override Point Coordinates => new Point(Center.X - Radius, Center.Y - Radius);

        private bool[,] _matrix;

        public Circle() { }

        public Circle(Point center, int radius, bool isHollow) : base("Circle", isHollow)
        {
            Center = center;
            Radius = radius;
        }

        private bool[,] GetMatrix()
        {
            bool[,] result = new bool[Radius * 2 + 1, Radius * 2 + 1];
            Point center = new Point(Center.X - Coordinates.X, Center.Y - Coordinates.Y);
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = false;
                    if (IsHollow)
                    {
                        if (Math.Abs(Math.Sqrt(Math.Pow(j - center.X, 2) + Math.Pow(i - center.Y, 2)) - Radius) < 0.5)
                        {
                            result[i, j] = true;
                        }
                    }
                    else
                    {
                        if (Math.Sqrt(Math.Pow(j - center.X, 2) + Math.Pow(i - center.Y, 2))-Radius < 0.5)
                        {
                            result[i, j] = true;
                        }
                    }
                }
            }
            return result;
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
            return $"{Name}: Center = {Center} Radius = {Radius} {ToDimensionSring()}";
        }

        public override void ChangePosition(Direction direction)
        {
            Center.ChangePosition(direction);
        }
    }
}
