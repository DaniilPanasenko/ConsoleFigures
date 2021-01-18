using System;
using СonsoleFigures.Interfaces;

namespace СonsoleFigures.Classes
{
    abstract public class Figure : IFigure
    {
        public string Name { get; set; }

        public abstract decimal Square { get; }

        public abstract decimal Perimetr { get; }

        public abstract Point Coordinates { get; }

        public Figure(string name)
        {
            Name = name;
        }

        public abstract int[,] ToMatrix();

        public abstract override string ToString();

        public string ToDimensionSring()
        {
            return $"Square = {Square} Perimetr = {Perimetr}";
        }
    }
}
