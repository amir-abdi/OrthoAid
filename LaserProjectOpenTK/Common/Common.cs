using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using OpenTK;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace OrthoAid_3DSimulator.Common
{
    static public class Common
    {
        public static Color[] SelectColor = 
        //{ Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red, Color.Red };
        {Color.OrangeRed, Color.Green, Color.Gold, Color.MediumTurquoise,
                                              Color.Yellow, Color.Red,   Color.Tomato, Color.Teal,
                                              Color.DarkViolet, Color.Aqua, Color.DarkSlateGray, Color.DeepPink,
                                              Color.Brown};
        public static Vector3 ColorRGB2Float(Color c)
        {            
            return new Vector3((float)c.R / 255, (float)c.G / 255, (float)c.B / 255);
        }

        public static bool[] InsidePolygon2D(Segment2D[] polyg, Vector2[] points)
        {
            bool[] result = new bool[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                result[i] = InsidePolygon2D(polyg, points[i]);
            }
            return result;
        }

        public static bool[] InsidePolygon2D(Segment2D[] polyg, Vector3[] points)
        {
            //disregards z coordinate of points
            bool[] result = new bool[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                result[i] = InsidePolygon2D(polyg, points[i].Xy);
            }
            return result;
        }

        public static bool InsidePolygon2D(Segment2D[] polyg, Vector2 point)
        {
            bool inside = true;
            int side = polyg[0].PointSide(point);
            for (int i = 1; i < polyg.Length; i++)
            {
                if (side != polyg[i].PointSide(point))
                {
                    inside = false;
                    break;
                }
            }

            return inside;
        }

        public static double[] SolveCubic_NonComplex1(double A, double B, double C, double D)
        {
            double[] result = null;

            double f = (((3 * C) / A) - ((B * B) / (A * A))) / 3;
            double g = (((2 * (Math.Pow(B, 3))) / (Math.Pow(A, 3))) - ((9 * B * C) / (Math.Pow(A, 2))) + ((27 * D) / A)) / 27;
            double h = ((Math.Pow(g, 2)) / 4) + ((Math.Pow(f, 3)) / 27);

            if (h <= 0)
            {
                double i = (((Math.Pow(g, 2)) / 4) - h);
                double i2 = Math.Pow(i, 0.5);
                double j = (Math.Pow(i2, 0.333333333333333333333333));
                double k = ((Math.Acos(0 - (g / (2 * i2)))));
                double l = (j * (0 - 1));
                double m = ((Math.Cos(k / 3)));
                double n = ((Math.Pow(3, 0.5)) * Math.Sin(k / 3));
                double p = ((B / (3 * A)) * (0 - 1));

                double x = ((2 * j) * (Math.Cos(k / 3)) - (B / (3 * A)));
                double y = (l * (m + n) + p);
                double z = (l * (m - n) + p);

                result = new double[3];
                result[0] = x;
                result[1] = y;
                result[2] = z;
            }
            if (h > 0)
            {

                double u = 0 - g;
                double r = (u / 2) + (Math.Pow(h, 0.5));
                if (r >= 0)
                {
                    double s6 = (Math.Pow(r, 0.333333333333333333333333333));
                    double s8 = s6;
                    double t8 = (u / 2) - (Math.Pow(h, 0.5));
                    double help8 = (1.0 / 3);
                    string help9 = help8.ToString();
                    if (t8 < 0)
                    {
                        double v7 = (Math.Pow((0 - t8), 0.33333333333333333333));
                        double v8 = (v7);
                        double x3 = (s8 - v8) - (B / (3 * A));
                        double y3 = ((0 - (s8 - v8)) / 2) - (B / (3 * A));
                        double y4 = ((s8 + v8) * (Math.Sqrt(3) / 2));
                        double z3 = ((0 - (s8 - v8)) / 2) - (B / (3 * A));
                        double z4 = ((s8 + v8) * (Math.Sqrt(3)) / 2);

                        result = new double[3];
                        result[0] = x3;
                    }
                    if (t8 >= 0)
                    {
                        double v6 = (Math.Pow((0 - (0 - t8)), 0.33333333333333333333));
                        double v5 = (v6);
                        double x3 = (s8 + v5) - (B / (3 * A));
                        double y3 = ((0 - (s8 + v5)) / 2) - (B / (3 * A));
                        double y4 = ((s8 - v5) * (Math.Sqrt(3) / 2));
                        double z3 = ((0 - (s8 + v5)) / 2) - (B / (3 * A));
                        double z4 = ((s8 - v5) * (Math.Sqrt(3)) / 2);

                        result = new double[3];
                        result[0] = x3;
                    }
                }
                if (r < 0)
                {
                    double s3 = (Math.Pow((0 - r), 0.333333333333333333333333333));
                    double s = (0 - s3);
                    double t = (u / 2) - (Math.Pow(h, 0.5));                    
                    if (t < 0)
                    {
                        double v = (Math.Pow((0 - t), 0.33333333333333333333));
                        double v2 = (v);
                        double x3 = (s - v2) - (B / (3 * A));
                        double y3 = ((0 - (s - v2)) / 2) - (B / (3 * A));
                        double y4 = ((s + v2) * (Math.Sqrt(3) / 2));
                        double z3 = ((0 - (s - v2)) / 2) - (B / (3 * A));
                        double z4 = ((s + v2) * (Math.Sqrt(3)) / 2);

                        result = new double[3];
                        result[0] = x3;
                    }
                    if (t >= 0)
                    {
                        double v = (Math.Pow((0 - (0 - t)), 0.33333333333333333333));
                        double v2 = (v);
                        double x3 = (s + v2) - (B / (3 * A));
                        double y3 = ((0 - (s + v2)) / 2) - (B / (3 * A));
                        double y4 = ((s - v2) * (Math.Sqrt(3) / 2));
                        double z3 = ((0 - (s + v2)) / 2) - (B / (3 * A));
                        double z4 = ((s - v2) * (Math.Sqrt(3)) / 2);

                        result = new double[3];
                        result[0] = x3;
                    }
                }
            }



            if (h == 0 && f == 0 && g == 0)
            {


                double x5 = ((Math.Pow((D / A), 0.3333333333333333333))) * (0 - 1);

                result = new double[3];
                result[0] = x5;
            }

            return result;
        }

        public static double[] SolveCubic_NonComplex2(double a, double b, double c, double d)
        {

            if (IsEquald(a, 0.0d))
            {

                return SolveQuadratic(b, c, d).ToArray();

            }



            var discriminant = 18.0 * a * b * c * d - 4.0 * b * b * b * d + b * b * c * c - 4.0 * a * c * c * c - 27.0 * a * a * d * d;

            var delta0 = b * b - 3.0 * a * c;



            if (IsEquald(discriminant, 0.0d))
            {

                if (IsEquald(delta0, 0.0d))
                {

                    // three roots are equal

                    return new List<double>(1) { -b / (3.0 * a) }.ToArray();

                }

                // two roots

                var root12 = (9.0 * a * d - b * c) / (2.0 * delta0);

                var root3d = (4.0 * a * b * c - 9.0 * a * a * d - b * b * b) / (a * delta0);

                return new List<double>(2) { root12, root3d }.ToArray();

            }



            var delta1 = 2.0 * b * b * b - 9.0 * a * b * c + 27.0 * a * a * d;

            var inner = new Complex(-27.0 * a * a * discriminant, 0.0);

            inner = Complex.Sqrt(inner);



            var top = delta1 + inner;

            if (IsEquald(delta0, 0.0d) && IsEquald(top.Real, 0.0d) && IsEquald(top.Imaginary, 0.0d))

                top = delta1 - inner;

            top *= 0.5;

            var C = Complex.Pow(top, 1.0 / 3.0);

            var front = -1.0 / (3.0 * a);

            var roots = new List<double>(3);



            var root1 = front * (b + C + delta0 / C);

            if (IsEquald(root1.Imaginary, 0.0d))

                roots.Add(root1.Real);



            var u2 = new Complex(-1.0, SQRT3) * 0.5;

            var root2 = front * (b + u2 * C + delta0 / (u2 * C));

            if (IsEquald(root2.Imaginary, 0.0d))

                roots.Add(root2.Real);



            var u3 = new Complex(-1.0, -SQRT3) * 0.5;

            var root3 = front * (b + u3 * C + delta0 / (u3 * C));

            if (IsEquald(root3.Imaginary, 0.0d))

                roots.Add(root3.Real);



            return roots.ToArray();

        }

        private static List<double> SolveQuadratic(double a, double b, double c)
        {

            if (IsEquald(a, 0.0d))
            {

                // solve linear:

                return new List<double> { -c / b };

            }

            // quadratic:

            var qr = b * b - 4.0 * a * c;

            var sqr = Complex.Sqrt(new Complex(qr, 0.0));

            var roots = new List<double>(2);

            var root1 = (-b + sqr) / (2.0 * a);

            if (IsEquald(root1.Imaginary,0.0d))

                roots.Add(root1.Real);

            var root2 = (-b - sqr) / (2.0 * a);

            if (IsEquald( root2.Imaginary,0.0d))

                roots.Add(root2.Real);



            return roots;

        }

        private static bool IsEquald(double a, double b)
        {
            return Math.Abs(a - b) < 0.0000001;
        }

        private static readonly double SQRT3 = Math.Sqrt(3.0);
    }
}
