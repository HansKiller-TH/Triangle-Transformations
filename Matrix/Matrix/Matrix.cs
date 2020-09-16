using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Text;

namespace Matrix
{
    public class MyMatrix
    {
        private int[,] data = new int[3, 3];
        public int this[int z, int s] { get { return data[z, s]; } private set { data[z, s] = value; } }
        public MyMatrix() { }
        /// <summary>
        /// Erzeugt Matrix aus übergebenem 3x3 Int-Feld
        /// </summary>
        /// <param name="data">2D-Int-Feld</param>
        public MyMatrix(int[,] data)
        {
            if (data.GetLength(0) != 3 || data.GetLength(1) != 3)
                throw new ArgumentException("Nimmt nur 3x3-Feld an");
            for (int i = 0; i < this.data.GetLength(0); i++)
            {
                for (int k = 0; k < this.data.GetLength(1); k++)
                {
                    this.data[i, k] = data[i, k];
                }
            }
        }
        public static MyMatrix Scalar(int x, int y)
        {
            int[,] data = new int[3, 3];
            data[0, 0] = x;
            data[1, 1] = y;
            data[2, 2] = 1;
            return new MyMatrix(data);
        }
        public static MyMatrix Scalar(int xy)
        {
            int[,] data = new int[3, 3];
            data[0, 0] = xy;
            data[1, 1] = xy;
            data[2, 2] = 1;
            return new MyMatrix(data);
        }
        public static MyMatrix Translation(int x, int y)
        {
            int[,] data = new int[3, 3];
            data[0, 2] = x;
            data[1, 2] = y;
            data[0, 0] = 1;
            data[1, 1] = 1;
            data[2, 2] = 1;
            return new MyMatrix(data);
        }
        public static MyMatrix Translation(int xy)
        {
            int[,] data = new int[3, 3];
            data[0, 2] = xy;
            data[1, 2] = xy;
            data[0, 0] = 1;
            data[1, 1] = 1;
            data[2, 2] = 1;
            return new MyMatrix(data);
        }
        public static MyMatrix Rotation(double theta)
        {
            int[,] data = new int[3, 3];
            theta = theta / 180.0 * Math.PI;
            int cos = Convert.ToInt32(Math.Cos(theta));
            int sin = Convert.ToInt32(Math.Sin(theta));
            data[0, 0] = cos;
            data[0, 1] = -sin;
            data[1, 0] = sin;
            data[1, 1] = cos;
            data[2, 2] = 1;
            return new MyMatrix(data);
        }
        public static MyMatrix Unity()
        {
            int[,] data = new int[3, 3];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                data[i, i] = 1;
            }
            return new MyMatrix(data);
        }
        /// <summary>
        /// ToString-Methode wird überschrieben für Console.WriteLine-Ausgabe z.B.
        /// </summary>
        /// <returns>Alle Elemente formatiert als String</returns>
        public override string ToString()
        {
            string str = "";
            int zaehler;
            for (int z = 0; z < this.data.GetLength(0); z++)
            {
                zaehler = 0;
                for (int s = 0; s < this.data.GetLength(1); s++)
                {
                    str += $" {this.data[z, s],3}";
                    zaehler++;
                    if (zaehler >= this.data.GetLength(1))
                    {
                        str += " \n";
                        break;
                    }
                    //str += " ";
                }
            }
            return str;
        }
        /// <summary>
        /// Addiert zwei Matrizen bzw. 2D-Felder
        /// </summary>
        /// <param name="a">Die eine Matrix</param>
        /// <param name="b">Die andere Matrix</param>
        /// <returns>Ergebnismatrix</returns>
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            MyMatrix erg = new MyMatrix();
            for (int z = 0; z < a.data.GetLength(0); z++)
            {
                for (int s = 0; s < a.data.GetLength(1); s++)
                {
                    erg[z, s] = a.data[z, s] + b.data[z, s];
                }
            }
            return erg;
        }
        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            MyMatrix erg = new MyMatrix();
            for (int z = 0; z < a.data.GetLength(0); z++)
            {
                for (int s = 0; s < a.data.GetLength(1); s++)
                {
                    erg[z, s] = a.data[z, s] - b.data[z, s];
                }
            }
            return erg;
        }
        /// <summary>
        /// Skalarmultiplikation
        /// </summary>
        /// <param name="lambda">Skalar</param>
        /// <param name="a">Matrix</param>
        /// <returns>Ergebnismatrix</returns>
        public static MyMatrix operator *(int lambda, MyMatrix a)
        {
            MyMatrix erg = new MyMatrix();
            for (int z = 0; z < a.data.GetLength(0); z++)
            {
                for (int s = 0; s < a.data.GetLength(1); s++)
                {
                    erg[z, s] = a.data[z, s] * lambda;
                }
            }
            return erg;
        }
        /// <summary>
        /// Matrixmultiplikation
        /// </summary>
        /// <param name="mya">Die eine Matrix</param>
        /// <param name="myb">Die andere Matrix</param>
        /// <returns>Ergebnismatrix</returns>
        public static MyMatrix operator *(MyMatrix mya, MyMatrix myb)
        {
            MyMatrix erg = new MyMatrix();
            for (int a = 0; a < mya.data.GetLength(0); a++)
            {
                for (int b = 0; b < myb.data.GetLength(1); b++)
                {
                    for (int c = 0; c < myb.data.GetLength(0); c++)
                    {
                        erg[a, b] += mya[a, c] * myb[c, b];
                    }
                }
            }
            return erg;
        }
        
        /// <summary>
        /// Überladt den Vergleichsoperator für MyMatrix-Objekte
        /// </summary>
        /// <param name="mya">Die eine Matrix</param>
        /// <param name="myb">Die andere Matrix</param>
        /// <returns>true oder false</returns>
        public static bool operator ==(MyMatrix mya, MyMatrix myb)
        {
            for (int a = 0; a < mya.data.GetLength(0); a++)
            {
                for (int b = 0; b < mya.data.GetLength(1); b++)
                {
                    if (mya[a, b] != myb[a, b])
                        return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Überlädt den Nicht-Gleich-Operator für Matrix-Objekte
        /// </summary>
        /// <param name="mya"></param>
        /// <param name="myb"></param>
        /// <returns>true oder false</returns>
        public static bool operator !=(MyMatrix mya, MyMatrix myb)
        {
            for (int a = 0; a < mya.data.GetLength(0); a++)
            {
                for (int b = 0; b < myb.data.GetLength(1); b++)
                {
                    if (mya[a, b] != myb[a, b])
                        return true;

                }
            }
            return false;
        }
        /// <summary>
        /// Überlädt den Operator zur expliziten Konvertierung in Double
        /// </summary>
        /// <param name="a">Die Matrix</param>
        public static explicit operator double(MyMatrix a)
        {
            double d = 0;
            for (int z = 0; z < a.data.GetLength(0); z++)
            {
                for (int s = 0; s < a.data.GetLength(1); s++)
                {
                    d += Math.Pow(a.data[z, s], 2);
                }
            }
            return Math.Sqrt(d);
        }
    }
    public class MyVector
    {
        private int[] data = new int[3];
        public int this[int i] { get { return data[i]; } private set { data[i] = value; } }
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public MyVector() //benutze ich bei der Matrix-Vektor-Multiplikation
        {

        }
        public MyVector(Point point)
        {
            data[0] = point.X;
            data[1] = point.Y;
            data[2] = 1;
        }
        public MyVector(int[] data)
        {
            for (int e = 0; e < this.data.Length; e++)
                this.data[e] = data[e];
        }
        /// <summary>
        /// Matrix-Vektor-Multiplikation
        /// </summary>
        /// <param name="myM"> Die Matrix </param>
        /// <param name="myV"> Der Vektor </param>
        /// <returns>MyVector-Objekt</returns>
        public static MyVector operator *(MyMatrix myM, MyVector myV)
        {
            MyVector erg = new MyVector(); 
            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                    erg[a] += myM[a, b] * myV[b];
            }
            return erg;
        }
        /// <summary>
        /// Schreibt die drei Elemente untereinander
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            string str = "";
            foreach (int item in this.data)
                str += $"{item,2}\n";
            return str;
        }
    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point(MyVector vector)
        {
            X = vector[0];
            Y = vector[1];
        }
        public override string ToString()
        {
            return $"({X}/{Y})";
        }
        public static Point operator *(MyMatrix m,Point p)
        {
            return new Point(m * new MyVector(p));
        }
    }
    public static class Zeichnen
    {
        public static List<MyMatrix> Sammlung = new List<MyMatrix>();
        // Hier x- und y-Werte der Punkte eintragen
        public static Point a = new Point(2, 4);
        public static Point b = new Point(4, 6);
        public static Point c = new Point(4, 4);
        public static MyMatrix homogen = MyMatrix.Unity();
        public static void Homogen()
        {
            homogen = MyMatrix.Unity();
            for (int i = Sammlung.Count - 1; i >= 0; i--)
            {
                homogen *= Sammlung[i];
            }
        }
        public static void TransformedTriangle()
        {
            (Application.Current.MainWindow as MainWindow).Triangle(homogen * a, homogen * b, homogen * c, Brushes.Red);
        }
        public static void MatrizenZeigen()
        {
            if (Sammlung.Count > 0)
                (Application.Current.MainWindow as MainWindow).w.Matrix1.Text = Sammlung[0].ToString();
            if (Sammlung.Count > 1)
                (Application.Current.MainWindow as MainWindow).w.Matrix2.Text = Sammlung[1].ToString();
            if (Sammlung.Count > 2)
                (Application.Current.MainWindow as MainWindow).w.Matrix3.Text = Sammlung[2].ToString();
            if (Sammlung.Count > 3)
                (Application.Current.MainWindow as MainWindow).w.Matrix4.Text = Sammlung[3].ToString();
            if (Sammlung.Count > 4)
                (Application.Current.MainWindow as MainWindow).w.Matrix5.Text = Sammlung[4].ToString();
        }
    }
}
