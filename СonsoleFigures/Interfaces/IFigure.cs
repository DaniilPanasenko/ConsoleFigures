﻿using System;
using СonsoleFigures.Classes;

namespace СonsoleFigures.Interfaces
{
    public interface IFigure
    {
        public string Name { get; }

        public decimal Square { get; }

        public decimal Perimetr { get; }

        public Point Coordinates { get; }

        public bool IsHollow { get; }

        public bool[,] ToMatrix();

        public string ToString();
    }
}
