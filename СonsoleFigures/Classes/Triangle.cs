using System;
using System.Linq;

namespace СonsoleFigures.Classes
{
    public class Triangle : Figure
    {
        public Point Point1 { get; private set; }

        public Point Point2 { get; private set; }

        public Point Point3 { get; private set; }

        private decimal A =>
            (decimal)Math.Sqrt((double)(
                (Point1.X - Point2.X) * (Point1.X - Point2.X) +
                (Point1.Y - Point2.Y) * (Point1.Y - Point2.Y)
            ));

        private decimal B =>
            (decimal)Math.Sqrt((double)(
                (Point1.X - Point3.X) * (Point1.X - Point3.X) +
                (Point1.Y - Point3.Y) * (Point1.Y - Point3.Y)
            ));

        private decimal C =>
            (decimal)Math.Sqrt((double)(
                (Point3.X - Point2.X) * (Point3.X - Point2.X) +
                (Point3.Y - Point2.Y) * (Point3.Y - Point2.Y)
            ));

        public override decimal Square =>
            (decimal)Math.Sqrt((double)(
                Perimetr / 2 *
                (Perimetr / 2 - A) *
                (Perimetr / 2 - B) *
                (Perimetr / 2 - C)
            ));

        public override decimal Perimetr => A + B + C;

        public override Point Coordinates =>
            new Point(
                new decimal[] { Point1.X, Point2.X, Point3.X }.Min(),
                new decimal[] { Point1.Y, Point2.Y, Point3.Y }.Min()
            );


        public Triangle(Point point1, Point point2, Point point3) : base("Triangle")
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public override int[,] ToMatrix()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}: Point 1 = {Point1}, Point 2 = {Point2} Point 3 = {Point3}  {ToDimensionSring()}";
        }
    }
}
