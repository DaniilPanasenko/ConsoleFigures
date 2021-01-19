using System;
using СonsoleFigures.Classes;

namespace СonsoleFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rectangle rect1 = new Rectangle(new Point(10, 10), 20, 10, true);
            //Square square = new Square(new Point(7, 7), 20, true);
            //Line line1 = new Line(new Point(30, 30), new Point(37, 49));
            //Line line2 = new Line(new Point(5, 20), new Point(20, 5));
            //Line line3 = new Line(new Point(10, 30), new Point(10, 49));
            //Line line4 = new Line(new Point(20, 6), new Point(6,20 ));
            Circle circle = new Circle(new Point(20, 20), 15, false);
            Circle circle0 = new Circle(new Point(10, 10), 10, true);
            Triangle triangle = new Triangle(new Point(1, 30), new Point(47, 0), new Point(40, 45), false);
            Picture picture = new Picture(50, 50);
            picture.AddFigure(circle);
            picture.AddFigure(circle0);
            picture.AddFigure(triangle);
            var output = picture.ToMatrix();
            for (int i = 0; i < output.GetLength(0); i++) 
            {
                for (int j = 0; j < output.GetLength(1); j++)
                {
                    Console.Write(output[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
