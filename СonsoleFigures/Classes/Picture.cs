using System;
using System.Collections.Generic;
using System.Linq;
using СonsoleFigures.Enums;
using СonsoleFigures.Exceptions;

namespace СonsoleFigures.Classes
{
    public class Picture
    {
        private static char[] levels = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        private List<Figure> _figures = new List<Figure>();

        public IReadOnlyList<Figure> Figures => _figures;

        public int Width { get; private set; }

        public int Height { get; private set; }

        private int Active { get; set; }

        public Figure ActiveFigure => Figures.Count == 0 ? null : Figures[Active];

        public Picture(int width, int height)
        {
            Width = width-2;
            Height = height-2;
            Active = -1;
        }

        public void AddFigure(Figure figure)
        {
            if (_figures.Count == levels.Length)
            {
                throw new AvailableCountFiguresOnPictureException($"Maximum available count of figures on picture is {levels.Length}");
            }
            if (figure == null)
            {
                throw new ArgumentNullException();
            }
            if (figure.Coordinates.X < 0)
            {
                throw new FigureOutOfThePictureRangeException("Figure out of the picture right bound");
            }
            if (figure.Coordinates.X + figure.ToMatrix().GetLength(1) > Width)
            {
                throw new FigureOutOfThePictureRangeException("Figure out of the picture left bound");
            }
            if (figure.Coordinates.Y < 0)
            {
                throw new FigureOutOfThePictureRangeException("Figure out of the picture top bound");
            }
            if (figure.Coordinates.Y + figure.ToMatrix().GetLength(0) > Height)
            {
                Console.WriteLine(figure.ToMatrix().GetLength(0));
                throw new FigureOutOfThePictureRangeException("Figure out of the picture bottom bound");
            }
            _figures.Add(figure);
            Active = Figures.Count - 1;
        }

        public bool TryDeleteActiveFigure()
        {
            if (ActiveFigure != null)
            {
                _figures.Remove(ActiveFigure);
                if (Active == Figures.Count)
                {
                    Active--;
                }
                return true;
            }
            return false;
        }

        public void UpActive()
        {
            Active = Math.Min(Figures.Count - 1, ++Active);
        }

        public void DownActive()
        {
            Active = Math.Max(0, --Active);
        }

        public bool TryChangeFigurePosition(Direction direction)
        {
            if (ActiveFigure != null)
            {
                switch (direction)
                {
                    case Direction.Up:
                        if (ActiveFigure.Coordinates.Y == 0) return  false;
                        break;
                    case Direction.Left:
                        if (ActiveFigure.Coordinates.X == 0) return false;
                        break;
                    case Direction.Down:
                        if (ActiveFigure.Coordinates.Y + ActiveFigure.ToMatrix().GetLength(0) == Height) return false;
                        break;
                    case Direction.Right:
                        if (ActiveFigure.Coordinates.X + ActiveFigure.ToMatrix().GetLength(1) == Width) return false;
                        break;
                }
                ActiveFigure.ChangePosition(direction);
                return true;
            }
            return false;
        }

        private char[,] ToMatrix()
        {
            char[,] result = new char[Height + 2, Width + 2];
            for(int i=0; i<result.GetLength(0); i++)
            {
                for(int j=0; j< result.GetLength(1); j++)
                {
                    result[i, j] = ' ';
                }
            }
            for (int i = 0; i < result.GetLength(0); i++)
            {
                result[i, 0] = '#';
                result[i, result.GetLength(1)-1] = '#';
            }
            for (int i = 0; i < result.GetLength(1); i++)
            {
                result[0, i] = '#';
                result[result.GetLength(0) - 1, i] = '#';
            }
            var figures = Figures.ToArray();
            for(int i=0; i<figures.Length; i++)
            {
                var figureMatrix = figures[i].ToMatrix();
                for (int l = 0; l < figureMatrix.GetLength(0); l++)
                {
                    for (int k = 0; k < figureMatrix.GetLength(1); k++)
                    {
                        if (figureMatrix[l, k])
                        {
                            result[l + (int)figures[i].Coordinates.Y + 1, k + (int)figures[i].Coordinates.X + 1] = levels[i];
                        }
                    }
                }
            }
            return result;
        }

        public void Print()
        {
            var matrix = ToMatrix();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Active>=0 && matrix[i, j] == levels[Active])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(matrix[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(matrix[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
