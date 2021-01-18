using System;
using СonsoleFigures.Classes;

namespace СonsoleFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = new Rectangle(new Point(10, 10), 20, 10, true);
            Square square = new Square(new Point(7, 7), 20, true);
            Picture picture = new Picture(50, 50);
            picture.AddFigure(rect1);
            picture.AddFigure(square);
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
