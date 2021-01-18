using System;
using System.Linq;

namespace СonsoleFigures.Classes
{
    public class Triangle : Figure
    {
        public Point Point1 { get; private set; }

        public Point Point2 { get; private set; }

        public Point Point3 { get; private set; }

        public override decimal Square =>
            (decimal)Math.Sqrt((double)(
                Perimetr / 2 *
                (Perimetr / 2 - new Line(Point1, Point2).Perimetr) *
                (Perimetr / 2 - new Line(Point1, Point3).Perimetr) *
                (Perimetr / 2 - new Line(Point3, Point2).Perimetr)
            ));

        public override decimal Perimetr =>
            new Line(Point1, Point2).Perimetr +
            new Line(Point1, Point3).Perimetr +
            new Line(Point3, Point2).Perimetr;

        public override Point Coordinates =>
            new Point(
                new int[] { Point1.X, Point2.X, Point3.X }.Min(),
                new int[] { Point1.Y, Point2.Y, Point3.Y }.Min()
            );


        public Triangle(Point point1, Point point2, Point point3, bool isHollow) : base("Triangle", isHollow)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public override bool[,] ToMatrix()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}: Point 1 = {Point1}, Point 2 = {Point2} Point 3 = {Point3}  {ToDimensionSring()}";
        }
    }
}
