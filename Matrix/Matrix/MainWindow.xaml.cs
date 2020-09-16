using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Matrix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int middleX = 1097, middleY = 617, gridSpace = 50;
        public static int updown = 1;
        public static int ToGridX(int x) => middleX + x * gridSpace;
        public static int ToGridY(int y) => middleY + y * gridSpace * updown;
        public static Line Linie(Point a, Point b, SolidColorBrush colorBrush)
        {
            Line linie = new Line();
            linie.StrokeThickness = 2;
            linie.Stroke = colorBrush;
            linie.X1 = ToGridX(a.X);
            linie.X2 = ToGridX(b.X);
            linie.Y1 = ToGridY(a.Y);
            linie.Y2 = ToGridY(b.Y);
            return linie;
        }
        public Ellipse Circle(Point a, SolidColorBrush colorBrush)
        {
            Ellipse circle = new Ellipse();
            int diameter = 10;
            circle.Width = diameter;
            circle.Height = diameter;
            circle.Fill = Brushes.White;
            circle.Stroke = colorBrush;
            circle.StrokeThickness = 2;
            Canvas.SetLeft(circle, ToGridX(a.X) - diameter / 2);
            Canvas.SetTop(circle, ToGridY(a.Y) - diameter / 2);
            return circle;
        }
        public TextBlock Description(Point p, string s)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontSize = 22;
            Canvas.SetLeft(textBlock, ToGridX(p.X));
            Canvas.SetTop(textBlock, ToGridY(p.Y));
            return textBlock;
        }
        public void Triangle(Point a, Point b, Point c, SolidColorBrush colorBrush)
        {
            Zeichenfläche.Children.Add(Linie(a, b, colorBrush));
            Zeichenfläche.Children.Add(Linie(a, c, colorBrush));
            Zeichenfläche.Children.Add(Linie(c, b, colorBrush));
            Zeichenfläche.Children.Add(Circle(a, colorBrush));
            Zeichenfläche.Children.Add(Circle(b, colorBrush));
            Zeichenfläche.Children.Add(Circle(c, colorBrush));
            Zeichenfläche.Children.Add(Description(a, "A"));
            Zeichenfläche.Children.Add(Description(b, "B"));
            Zeichenfläche.Children.Add(Description(c, "C"));
        }
        public void Grid()
        {
            int rangeX = 22;
            for (int i = -rangeX; i < rangeX + 1; i++)
            {
                Line h = new Line();
                h.StrokeThickness = 1;
                h.Stroke = Brushes.Gray;
                h.Y1 = 0;
                h.Y2 = 1234;
                h.X1 = h.X2 = ToGridX(i);
                MeineKritzel.Children.Add(h);
            }

            for (int i = -rangeX; i < rangeX + 1; i++)
            {
                Line h = new Line();
                h.StrokeThickness = 2;
                h.Stroke = Brushes.Black;
                h.Y1 = middleY - 5;
                h.Y2 = middleY + 5;
                h.X1 = h.X2 = ToGridX(i);
                MeineKritzel.Children.Add(h);
            }
            int rangeY = 12;
            for (int i = -rangeY; i < rangeY + 1; i++)
            {
                Line v = new Line();
                v.StrokeThickness = 1;
                v.Stroke = Brushes.Gray;
                v.X1 = 0;
                v.X2 = 2194;
                v.Y1 = v.Y2 = ToGridY(i);
                MeineKritzel.Children.Add(v);
            }
            for (int i = -rangeY; i < rangeY + 1; i++)
            {
                Line v = new Line();
                v.StrokeThickness = 2;
                v.Stroke = Brushes.Black;
                v.X1 = middleX - 5;
                v.X2 = middleX + 5;
                v.Y1 = v.Y2 = ToGridY(i);
                MeineKritzel.Children.Add(v);
            }
            Line gridV = new Line();
            gridV.X1 = middleX;
            gridV.Y1 = 0;
            gridV.X2 = middleX;
            gridV.Y2 = 1234;
            gridV.StrokeThickness = 2;
            gridV.Stroke = Brushes.Black;
            Line gridH = new Line();
            gridH.X1 = 0;
            gridH.Y1 = middleY;
            gridH.X2 = 2194;
            gridH.Y2 = middleY;
            gridH.Stroke = Brushes.Black;
            gridH.StrokeThickness = 2;
            MeineKritzel.Children.Add(gridH);
            MeineKritzel.Children.Add(gridV);
            MeineKritzel.Children.Add(Description(new Point(1, 0), "1"));
            MeineKritzel.Children.Add(Description(new Point(0, 1), "1"));
        }
        public Window1 w;
        public MainWindow()
        {
            InitializeComponent();
            w = new Window1();
            w.WindowStyle = WindowStyle.ToolWindow;
            w.SizeToContent = SizeToContent.WidthAndHeight;
            w.Topmost = true;
            w.Show();
            Grid();
            //Triangle(Matrix.Zeichnen.a, Matrix.Zeichnen.b, Matrix.Zeichnen.c, Brushes.Black);
        }
    }
}
