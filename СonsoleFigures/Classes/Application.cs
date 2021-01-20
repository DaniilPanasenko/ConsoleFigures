using System;
using System.Collections.Generic;
using System.Linq;
using СonsoleFigures.Enums;
using СonsoleFigures.Exceptions;

namespace СonsoleFigures.Classes
{
    public class Application
    {
        private const string rules =
            "rule\n" +
            "rule\n" +
            "rule\n" +
            "rule\n";

        private Stack<string> Menu { get; set; }
        
        private Picture Picture { get; set; }

        public Application()
        {
            Menu = new Stack<string>();
            Menu.Push("For tansition to command line menu press SPACE");
        }

        private void ClearRows(int n)
        {
            for(int i=0; i<n; i++)
            {
                Menu.Pop();
            }

        }

        private void Welcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello, you are welcome in Console Figures Drawer, designed by Daniil Panasenko\n\n");
            Console.ResetColor();
            Console.WriteLine("To use this application: please read the rules:\n");
            Console.WriteLine(rules);
            Console.WriteLine("If you have read the rules press enter.");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        private void RedrawPicture()
        {
            Console.SetCursorPosition(0, 0);
            Picture.Print();
            Console.WriteLine(new String(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop-1);
            if (Picture.ActiveFigure != null)
            {
                Console.WriteLine(Picture.ActiveFigure);
            }
            Console.WriteLine();
        }

        private void RedrawMenu()
        {
            Console.SetCursorPosition(0, Picture.Height+3);
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(new String(' ', Console.BufferWidth));
            }
            Console.SetCursorPosition(0, Picture.Height + 4);
            var menuList = Menu.ToList();
            menuList.Reverse();
            foreach (var menuItem in menuList) 
            {
                Console.WriteLine(menuItem);
            }
        }

        private bool TryChangeFigure(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return Picture.TryChangeFigurePosition(Direction.Up);
                case ConsoleKey.DownArrow:
                    return Picture.TryChangeFigurePosition(Direction.Down);
                case ConsoleKey.RightArrow:
                    return Picture.TryChangeFigurePosition(Direction.Right);
                case ConsoleKey.LeftArrow:
                    return Picture.TryChangeFigurePosition(Direction.Left);
                case ConsoleKey.Backspace:
                case ConsoleKey.Delete:
                    return Picture.TryDeleteActiveFigure();
            }
            return false;
        }

        private bool TryChangeActive(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Q:
                    Picture.UpActive();
                    return true;
                case ConsoleKey.W:
                    Picture.DownActive();
                    return true;
            }
            return false;
        }

        private void Help()
        {
            Menu.Push("Rules:");
            Menu.Push(rules);
            Menu.Push("Press any key to return to editing picture");
            RedrawMenu();
            Console.ReadKey();
        }

        private int InputInt(string parametr,int min, int max=int.MaxValue)
        {
            string maxString = max==int.MaxValue ? "∞" : max.ToString();
            Menu.Push($"Enter {parametr} [{min},{maxString}]: ");
            RedrawMenu();
            int value = -1;
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                RedrawMenu();
            }
            Menu.Pop();
            return value;
        }

        private bool InputIsHollow()
        {
            Menu.Push("Enter 1 - Hollow figure 2 - Fill figure:");
            RedrawMenu();
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < 1 || value > 2)
            {
                RedrawMenu();
            }
            Menu.Pop();
            return value == 1;
        }

        private void AddRectangle()
        {
            Rectangle rectangle;
            do
            {
                Menu.Push("Adding rectangle:");
                Menu.Push("Enter coordinates of left top point:");
                int x = InputInt("X", 0, Picture.Width - 1);
                int y = InputInt("Y", 0, Picture.Height - 1);
                Menu.Pop();
                int width = InputInt("width", 0);
                int height = InputInt("height", 0);
                bool isHollow = InputIsHollow();
                rectangle = new Rectangle(new Point(x, y), width, height, isHollow);
                Menu.Pop();
            }
            while (!AddFigure(rectangle));
        }

        private void AddSquare()
        {
            Square square;
            do
            {
                Menu.Push("Adding square:");
                Menu.Push("Enter coordinates of left top point:");
                int x = InputInt("X", 0, Picture.Width - 1);
                int y = InputInt("Y", 0, Picture.Height - 1);
                Menu.Pop();
                int width = InputInt("width", 0);
                bool isHollow = InputIsHollow();
                square = new Square(new Point(x, y), width, isHollow);
                Menu.Pop();
            }
            while (!AddFigure(square));
        }

        private void AddLine()
        {
            Line line;
            do
            {
                Menu.Push("Adding line:");
                Menu.Push("Enter coordinates of first point:");
                int x1 = InputInt("X", 0, Picture.Width - 1);
                int y1 = InputInt("Y", 0, Picture.Height - 1);
                Menu.Pop();
                Menu.Push("Enter coordinates of second point:");
                int x2 = InputInt("X", 0, Picture.Width - 1);
                int y2 = InputInt("Y", 0, Picture.Height - 1);
                Menu.Pop();
                line = new Line(new Point(x1, y1), new Point(x2, y2));
                Menu.Pop();
            }
            while (!AddFigure(line));
        }

        private void AddTriangle()
        {
            Triangle triangle;
            do
            {
                Menu.Push("Adding triangle:");
                Menu.Push("Enter coordinates of first point:");
                int x1 = InputInt("X", 0, Picture.Width - 1);
                int y1 = InputInt("Y", 0, Picture.Height - 1);
                Menu.Pop();
                Menu.Push("Enter coordinates of second point:");
                int x2 = InputInt("X", 0, Picture.Width - 1);
                int y2 = InputInt("Y", 0, Picture.Height - 1);
                Menu.Pop();
                Menu.Push("Enter coordinates of third point:");
                int x3 = InputInt("X", 0, Picture.Width - 1);
                int y3 = InputInt("Y", 0, Picture.Height - 1);
                Menu.Pop();
                bool isHollow = InputIsHollow();
                triangle = new Triangle(new Point(x1, y1), new Point(x2, y2), new Point(x3,y3), isHollow);
                Menu.Pop();
            }
            while (!AddFigure(triangle));
        }

        private void AddCircle()
        {
            Circle circle;
            do
            {
                Menu.Push("Adding circle:");
                Menu.Push("Enter coordinates of center:");
                int x = InputInt("X", 0, Picture.Width - 1);
                int y = InputInt("Y", 0, Picture.Height - 1);
                Menu.Pop();
                int radius = InputInt("radius", 0);
                bool isHollow = InputIsHollow();
                circle = new Circle(new Point(x, y), radius, isHollow);
                Menu.Pop();
            }
            while (!AddFigure(circle));
        }

        private bool AddFigure(Figure figure)
        {
            try
            {
                Picture.AddFigure(figure);
            }
            catch (Exception ex)
            {
                Menu.Push(ex.Message);
                Menu.Push("Press any key to restart adding");
                Menu.Push("Press ENTER to editing picture");
                RedrawMenu();
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    ClearRows(3);
                    return false;
                }
            }
            return true;
        }

        private void AddFigureMenu()
        {
            Menu.Push("Figures:");
            Menu.Push("1 - Rectangle");
            Menu.Push("2 - Square");
            Menu.Push("3 - Triangle");
            Menu.Push("4 - Line");
            Menu.Push("5 - Circle");
            RedrawMenu();
            int input = InputInt("command", 1, 5);
            Menu.Clear();
            switch (input)
            {
                case 1:
                    AddRectangle();
                    break;
                case 2:
                    AddSquare();
                    break;
                case 3:
                    AddTriangle();
                    break;
                case 4:
                    AddLine();
                    break;
                case 5:
                    AddCircle();
                    break;
            }
        }

        private bool RunMenu()
        {
            Menu.Clear();
            Menu.Push("Menu:");
            Menu.Push("1 - Add new figure");
            Menu.Push("2 - Save");
            Menu.Push("3 - Upload");
            Menu.Push("4 - Sort");
            Menu.Push("5 - Help");
            Menu.Push("6 - Return to editing picture");
            Menu.Push("7 - Exit");
            RedrawMenu();
            int input = InputInt("command", 1, 6);
            Menu.Clear();
            switch (input)
            {
                case 1:
                    AddFigureMenu();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    Help();
                    break;
                case 6:
                    return true;
                case 7:
                    return false;
            }
            return true;
        }

        public void Run()
        {
            Welcome();
            Picture = new Picture(Console.WindowWidth, Console.WindowHeight - 13);
            while (true)
            {
                RedrawPicture();
                Menu.Clear();
                Menu.Push("For tansition to command line menu press SPACE");
                RedrawMenu();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                while (keyInfo.Key != ConsoleKey.Spacebar)
                {
                    Console.SetCursorPosition(0, Console.CursorLeft);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(0, Console.CursorLeft);
                    if (TryChangeActive(keyInfo.Key))
                    {
                        RedrawPicture();
                    }
                    if (TryChangeFigure(keyInfo.Key))
                    {
                        RedrawPicture();
                    }
                    keyInfo = Console.ReadKey();
                }
                if (!RunMenu())
                {
                    return;
                }
            }
        }
    }
}