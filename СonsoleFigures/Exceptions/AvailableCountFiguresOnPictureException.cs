using System;
namespace СonsoleFigures.Exceptions
{
    public class AvailableCountFiguresOnPictureException : Exception
    {
        public AvailableCountFiguresOnPictureException(string message)
        : base(message)
        {
        }
    }
}
