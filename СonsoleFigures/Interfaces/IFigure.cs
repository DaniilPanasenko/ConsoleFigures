using System;
using СonsoleFigures.Classes;

namespace СonsoleFigures.Interfaces
{
    public interface IFigure
    {
        public string Name { get; set; }

        public decimal Square { get; }

        public decimal Perimetr { get; }

        public Point Coordinates { get; }

        public int[,] ToMatrix();

        public string ToString();
    }
}
