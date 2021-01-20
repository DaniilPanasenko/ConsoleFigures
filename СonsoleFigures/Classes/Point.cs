using System;
using СonsoleFigures.Enums;

namespace СonsoleFigures.Classes
{
    public class Point
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void ChangePosition(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    Y--;
                    break;
                case Direction.Down:
                    Y++;
                    break;
                case Direction.Left:
                    X--;
                    break;
                case Direction.Right:
                    X++;
                    break;
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
