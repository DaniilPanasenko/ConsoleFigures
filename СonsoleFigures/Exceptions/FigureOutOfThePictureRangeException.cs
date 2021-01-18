using System;
namespace СonsoleFigures.Exceptions
{
    public class FigureOutOfThePictureRangeException : Exception
    {
        public FigureOutOfThePictureRangeException(string message)
        : base(message)
        {
        }
    }
}
