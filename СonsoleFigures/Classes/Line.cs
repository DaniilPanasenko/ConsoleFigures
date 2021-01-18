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


        public Line(Point point1, Point point2) : base("Line")
        {
            Point1 = point1;
            Point2 = point2;
        }

        public override int[,] ToMatrix()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}: Point 1 = {Point1}, Point 2 = {Point2}  {ToDimensionSring()}";
        }
    }
}
