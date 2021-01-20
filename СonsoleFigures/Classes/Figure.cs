using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using СonsoleFigures.Enums;
using СonsoleFigures.Interfaces;

namespace СonsoleFigures.Classes
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Square))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [Serializable]
    abstract public class Figure : IFigure
    {
        public string Name { get; set; }

        public abstract decimal Square { get; }

        public abstract decimal Perimetr { get; }

        public abstract Point Coordinates { get; }

        public bool IsHollow { get; set; }

        public Figure() { }

        public Figure(string name, bool isHollow)
        {
            Name = name;
            IsHollow = isHollow;
        }

        public abstract void ChangePosition(Direction direction);

        public abstract bool[,] ToMatrix();

        public abstract override string ToString();

        public string ToDimensionSring()
        {
            return $"Square = {Square} Perimetr = {Perimetr}";
        }
    }
}
