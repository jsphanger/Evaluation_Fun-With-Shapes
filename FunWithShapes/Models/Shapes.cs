using System;
using System.Drawing;

namespace FunWithShapes.Models
{
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        protected static readonly int Padding = 10;
    }

    public class Square : Shape
    {
        public Square() {
            Width = 100;
            Height = 100;
            Color = Color.Black;
        }
        public Square(Color color, int width = 100, int height = 100, int x = 0, int y = 0)
        {
            Color = color;
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }

        public Bitmap Draw()
        {
            Bitmap img = new Bitmap(Width, Height);
            Pen pen = new Pen(Color);
            pen.Width = 4;

            Graphics formGraphics = Graphics.FromImage(img);
            formGraphics.DrawRectangle(pen, new System.Drawing.Rectangle(X + Padding / 2, Y + Padding / 2, Width - Padding, Height - Padding));

            pen.Dispose();
            formGraphics.Dispose();

            return img;
        }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            Width = 100;
            Height = 100;
            Color = Color.Black;
        }
        public Circle(Color color, int width = 100, int height = 100, int x = 0, int y = 0)
        {
            Width = width;
            Height = height;
            Color = color;
            X = x;
            Y = y;
        }
        public Bitmap Draw()
        {
            Bitmap img = new Bitmap(Width, Height);
            Pen pen = new Pen(Color);
            pen.Width = 4;

            //draw
            Graphics formGraphics = Graphics.FromImage(img);
            formGraphics.DrawEllipse(pen, X + Padding / 2, Y + Padding / 2, Width - Padding, Height - Padding);

            //clean up
            pen.Dispose();
            formGraphics.Dispose();

            return img;
        }
    }

    public class Triangle : Shape
    {
        public Point[] Points { get; set; }

        public Triangle()
        {
            Width = 100;
            Height = 100;
            Color = Color.Black;
        }
        public Triangle(Color color, int width = 100, int height = 100, int x = 0, int y = 0) {

            Color = color;
            Points = new Point[3];

            Points[0].X = Padding;
            Points[0].Y = Height - Padding;

            Points[1].X = Width / 2;
            Points[1].Y = Padding;

            Points[2].X = Width - Padding;
            Points[2].Y = Height - Padding;
        }

        public Bitmap Draw() 
        {
            Bitmap img = new Bitmap(Width, Height);
            Pen pen = new Pen(Color);
            pen.Width = 4;

            //draw
            Graphics formGraphics = Graphics.FromImage(img);
            formGraphics.DrawPolygon(pen, Points);

            //clean up
            pen.Dispose();
            formGraphics.Dispose();

            return img;
        }
    }
}
