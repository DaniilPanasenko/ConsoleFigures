using System;
using СonsoleFigures.Enums;

namespace СonsoleFigures.Classes
{
    [Serializable]
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point() { }

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
