using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using СonsoleFigures.Enums;

namespace СonsoleFigures.Classes
{
    [Serializable]
    public class Triangle : Figure
    {
        public Point Point1 { get; set; }

        public Point Point2 { get; set; }

        public Point Point3 { get; set; }

        private List<Line> Lines =>
            new List<Line>() {
                new Line(Point1, Point2),
                new Line(Point1, Point3),
                new Line(Point3, Point2)
            };

        public override decimal Square =>
            (decimal)Math.Sqrt((double)(
                Perimetr / 2 *
                (Perimetr / 2 - Lines[0].Perimetr) *
                (Perimetr / 2 - Lines[1].Perimetr) *
                (Perimetr / 2 - Lines[2].Perimetr)
            ));

        public override decimal Perimetr => Lines.Select(x=>x.Perimetr).Sum();

        public override Point Coordinates =>
            new Point(
                new int[] { Point1.X, Point2.X, Point3.X }.Min(),
                new int[] { Point1.Y, Point2.Y, Point3.Y }.Min()
            );

        private bool[,] _matrix;

        public Triangle() { }

        public Triangle(Point point1, Point point2, Point point3, bool isHollow) : base("Triangle", isHollow)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        private bool[,] GetMatrix()
        {
            int maxX = new int[] { Point1.X, Point2.X, Point3.X }.Max();
            int maxY = new int[] { Point1.Y, Point2.Y, Point3.Y }.Max();
            int width = maxX - Coordinates.X + 1;
            int height = maxY - Coordinates.Y + 1;
            bool[,] result = new bool[height, width];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = false;
                }
            }
            foreach (var line in Lines)
            {
                int differenceX = line.Coordinates.X-Coordinates.X;
                int differenceY = line.Coordinates.Y-Coordinates.Y;
                var matrix = line.ToMatrix();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j])
                        {
                            result[i + differenceY, j + differenceX] = true;
                        }
                    }
                }
            }
            if (!IsHollow)
            {
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    int start = -1;
                    int end = -1;
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        if (result[i, j])
                        {
                            end = j;
                            if (start == -1)
                            {
                                start = j;
                            }
                        }
                    }
                    for (int j = start; j <= end; j++)
                    {
                        result[i, j] = true;
                    }
                }
            }
            return result;
        }

        public override void ChangePosition(Direction direction)
        {
            Point1.ChangePosition(direction);
            Point2.ChangePosition(direction);
            Point3.ChangePosition(direction);
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
            return $"{Name}: Point 1 = {Point1}, Point 2 = {Point2} Point 3 = {Point3}  {ToDimensionSring()}";
        }
    }
}
