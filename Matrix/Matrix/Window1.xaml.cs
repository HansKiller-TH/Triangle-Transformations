using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Matrix
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //public static List<MyMatrix> Sammlung = new List<MyMatrix>();
        MainWindow main = Application.Current.MainWindow as MainWindow;
        public Window1()
        {
            InitializeComponent();
            Homogen.Text = Zeichnen.homogen.ToString();
        }

        private void Translation_Button_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(Translation_Box_X.Text,out int x);
            int.TryParse(Translation_Box_Y.Text, out int y);
            Zeichnen.Sammlung.Add(MyMatrix.Translation(x,y));
            Zeichnen.Homogen();
            Homogen.Text = Zeichnen.homogen.ToString();
            Zeichnen.MatrizenZeigen();
        }

        private void Skalierungs_Button_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(Skalierungs_Box_X.Text, out int x);
            int.TryParse(Skalierungs_Box_Y.Text, out int y);
            Zeichnen.Sammlung.Add(MyMatrix.Scalar(x, y));
            Zeichnen.Homogen();
            Homogen.Text = Zeichnen.homogen.ToString();
            Zeichnen.MatrizenZeigen();
        }

        private void Rotations_Button_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(Rotations_Box.Text, out double theta);
            Zeichnen.Sammlung.Add(MyMatrix.Rotation(theta));
            Zeichnen.Homogen();
            Homogen.Text = Zeichnen.homogen.ToString();
            Zeichnen.MatrizenZeigen();
        }

        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            Zeichnen.TransformedTriangle();
        }
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Zeichnen.Sammlung.Clear();
            main.Zeichenfläche.Children.Clear();
            Zeichnen.homogen = MyMatrix.Unity();
            Matrix1.Text = "";
            Matrix2.Text = "";
            Matrix3.Text = "";
            Matrix4.Text = "";
            Matrix5.Text = "";
            Homogen.Text = Zeichnen.homogen.ToString();
        }

        private void Rotations_Box_GotFocus(object sender, RoutedEventArgs e)
        {
            Rotations_Box.SelectAll();
        }

        private void Rotations_Box_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Rotations_Box.SelectAll();
        }

        private void Rotations_Box_GotMouseCapture(object sender, MouseEventArgs e)
        {
            Rotations_Box.SelectAll();
        }

        private void Translation_Box_X_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Translation_Box_X.SelectAll();
        }

        private void Translation_Box_X_GotMouseCapture(object sender, MouseEventArgs e)
        {
            Translation_Box_X.SelectAll();
        }

        private void Translation_Box_Y_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Translation_Box_Y.SelectAll();
        }

        private void Translation_Box_Y_GotMouseCapture(object sender, MouseEventArgs e)
        {
            Translation_Box_Y.SelectAll();
        }

        private void Skalierungs_Box_X_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Skalierungs_Box_X.SelectAll();
        }

        private void Skalierungs_Box_X_GotMouseCapture(object sender, MouseEventArgs e)
        {
            Skalierungs_Box_X.SelectAll();
        }

        private void Skalierungs_Box_Y_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Skalierungs_Box_Y.SelectAll();
        }

        private void Skalierungs_Box_Y_GotMouseCapture(object sender, MouseEventArgs e)
        {
            Skalierungs_Box_Y.SelectAll();
        }

        private void A_X_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            A_X.SelectAll();
        }

        private void A_X_GotMouseCapture(object sender, MouseEventArgs e)
        {
            A_X.SelectAll();
        }

        private void A_Y_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            A_Y.SelectAll();
        }

        private void A_Y_GotMouseCapture(object sender, MouseEventArgs e)
        {
            A_Y.SelectAll();
        }

        private void B_X_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            B_X.SelectAll();
        }

        private void B_X_GotMouseCapture(object sender, MouseEventArgs e)
        {
            B_X.SelectAll();
        }

        private void B_Y_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            B_Y.SelectAll();
        }

        private void B_Y_GotMouseCapture(object sender, MouseEventArgs e)
        {
            B_Y.SelectAll();
        }

        private void C_X_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            C_X.SelectAll();
        }

        private void C_X_GotMouseCapture(object sender, MouseEventArgs e)
        {
            C_X.SelectAll();
        }

        private void C_Y_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            C_Y.SelectAll();
        }

        private void C_Y_GotMouseCapture(object sender, MouseEventArgs e)
        {
            C_Y.SelectAll();
        }

        private void Triangle_Print_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(A_X.Text,out int z);
            Zeichnen.a.X = z;
            int.TryParse(A_Y.Text, out z);
            Zeichnen.a.Y = z;
            int.TryParse(B_X.Text, out z);
            Zeichnen.b.X = z;
            int.TryParse(B_Y.Text, out z);
            Zeichnen.b.Y = z;
            int.TryParse(C_X.Text, out z);
            Zeichnen.c.X = z;
            int.TryParse(C_Y.Text, out z);
            Zeichnen.c.Y = z;
            main.Zeichenfläche.Children.Clear();
            main.Triangle(Zeichnen.a, Zeichnen.b, Zeichnen.c,Brushes.Black);
        }

        private void UpDown_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.updown *= -1;
            main.MeineKritzel.Children.Clear();
            main.Grid();
            main.Zeichenfläche.Children.Clear();
        }
    }
}
