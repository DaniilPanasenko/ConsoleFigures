using System;
using СonsoleFigures.Interfaces;

namespace СonsoleFigures.Classes
{
    abstract public class Figure : IFigure
    {
        public string Name { get; private set; }

        public abstract decimal Square { get; }

        public abstract decimal Perimetr { get; }

        public abstract Point Coordinates { get; }

        public bool IsHollow { get; private set; }

        public Figure(string name, bool isHollow)
        {
            Name = name;
            IsHollow = isHollow;
        }

        public abstract bool[,] ToMatrix();

        public abstract override string ToString();

        public string ToDimensionSring()
        {
            return $"Square = {Square} Perimetr = {Perimetr}";
        }
    }
}
