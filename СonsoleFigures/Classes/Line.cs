using System;
namespace СonsoleFigures.Classes
{
    public class Line : Figure
    {
        public Point Point1 { get; private set; }

        public Point Point2 { get; private set; }

        public override decimal Square => 0;

        public override decimal Perimetr => (decimal)Math.Sqrt((double)(
                    (Point1.X - Point2.X) * (Point1.X - Point2.X) +
                    (Point1.Y - Point2.Y) * (Point1.Y - Point2.Y)));

        public override Point Coordinates => new Point(
                    Math.Min(Point1.X, Point2.X),
                    Math.Min(Point1.Y, Point2.Y));


        public Line(Point point1, Point point2) : base("Line", false)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public override bool[,] ToMatrix()
        {
            bool[,] result = new bool[Math.Abs(Point1.Y - Point2.Y) + 1, Math.Abs(Point1.X - Point2.X) + 1];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = false;
                }
            }
            if (result.GetLength(0) >= result.GetLength(1))
            {
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    Point p1 = new Point(Point1.X - Coordinates.X, Point1.Y - Coordinates.Y);
                    Point p2 = new Point(Point2.X - Coordinates.X, Point2.Y - Coordinates.Y);
                    int j = p1.Y == p2.Y ?
                        0 : (int)Math.Round((decimal)(i - p1.Y) / (p2.Y - p1.Y) * (p2.X - p1.X) + p1.X);
                    result[i, j] = true;
                }
            }
            else 
            {
                for (int i = 0; i < result.GetLength(1); i++)
                {
                    Point p1 = new Point(Point1.X - Coordinates.X, Point1.Y - Coordinates.Y);
                    Point p2 = new Point(Point2.X - Coordinates.X, Point2.Y - Coordinates.Y);
                    int j = p1.X == p2.X ?
                        0 : (int)Math.Round((decimal)(i - p1.X) / (p2.X - p1.X) * (p2.Y - p1.Y) + p1.Y);
                    result[j, i] = true;
                }
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Name}: Point 1 = {Point1}, Point 2 = {Point2}  {ToDimensionSring()}";
        }
    }
}
