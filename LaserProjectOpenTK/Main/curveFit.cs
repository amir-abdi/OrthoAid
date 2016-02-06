using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Runtime.InteropServices;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using OrthoAid_3DSimulator.Common;


namespace OrthoAid_3DSimulator
{
    public partial class MainForm
    {
        void CalculateCurveFit(Common.Vbo handle)
        {
            int num = handle.selectedVertices.Count;
            if (num < 2)
            {
                MessageBox.Show("At least 2 points needs to be selected in order to fit a polynomial curve.", "Error in Curve Fitting");
                return;
            }
            var pointsMat = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(num, 3);
            var points = new Vector3[num];

            for (int i = 0; i < num; i++)
            {
                pointsMat[i, 0] = handle.verticesData.vertices[handle.selectedVertices[i]].X;
                pointsMat[i, 1] = handle.verticesData.vertices[handle.selectedVertices[i]].Y;
                pointsMat[i, 2] = handle.verticesData.vertices[handle.selectedVertices[i]].Z;

                points[i] = handle.verticesData.vertices[handle.selectedVertices[i]];
            }

            var centroid = pointsMat.ColumnSums() / num;
            
            for (int i=0; i< num; i++)
            {
                pointsMat[i, 0] -= centroid[0];
                pointsMat[i, 1] -= centroid[1];
                pointsMat[i, 2] -= centroid[2];
            }

            var svd = pointsMat.Transpose().Svd(true);
            var singularValues = svd.S;

            var normalVec = new MathNet.Numerics.LinearAlgebra.Double.DenseVector(3);
            svd.U.Column(2, normalVec);

            Vector3 normalVec3 = new Vector3((float)normalVec[0], (float)normalVec[1], (float)normalVec[2]);
            Vector3 centroid3 = new Vector3((float)centroid[0], (float)centroid[1], (float)centroid[2]);
            Common.Plane p = new Common.Plane(normalVec3, centroid3);

            //var projectedPoints = p.ProjectPointOnPlane(points);
            
            var p0 = new Vector3(p.ProjectPointOnPlane(new Vector3(0, 0, 0)));
            var px = new Vector3(p.ProjectPointOnPlane(points[num-1] - points[0])); //new Vector3(1, 0, 0)));
            var py = new Vector3(p.ProjectPointOnPlane(Vector3.Cross(normalVec3, px))); //new Vector3(0, 1, 0)));
            var pvx = (px - p0);
            var pvy = (py - p0);
            pvx.Normalize();
            pvy.Normalize();
            
            var xdata = new double[num];
            var ydata = new double[num];
            
            for (int i=0; i< num; ++i)
            {                
                xdata[i] = Vector3.Dot(pvx, points[i] - p0);
                ydata[i] = Vector3.Dot(pvy, points[i] - p0);
            }

            var xMin = xdata.Min();
            var yMin = ydata.Min();            
            for (int i=0; i<num; ++i)
            {
                xdata[i] -= xMin;
                ydata[i] -= yMin;

                xdata[i] += 10;
                ydata[i] += 10;
            }

            //drawing original points
            var graphics = pl_curveFit.CreateGraphics();
            graphics.Clear(Color.White);

            for (int i = 0; i < num; ++i)
            {
                drawPoint2DOnControl(graphics, new PointF((float)xdata[i]-2/3, (float)ydata[i]-2/3), Color.Black, 4);
            }

            //least squares
            int deg = (int)nUpDown_order.Value;
            FitFunction fitFunction = config.fitFunction;
            DenseVector W;
            try
            {
                //f = Fit.Polynomial(xdata, ydata, order);
                W = fitLeastSquaresBasis(xdata, ydata, fitFunction, deg);
            }
            catch (Exception e)
            {
                MessageBox.Show("The order of polynomial is too high and results are unstable. Please use a lower degree polynomial.", "Error in Curve Fitting");
                return;
            }

            //draw the blue curve
            drawCurve(graphics, W, xdata.Min()-4, xdata.Max()+4, fitFunction, deg);

            //calculate Error
            var rmse = calculatePerpendicularDistancePointToCurve(xdata, ydata, W, 
                fitFunction, deg, graphics);
            

            status.Text = "Polynomial order " + deg.ToString() + 
                " was fit. Root Mean Square Error = " + rmse.ToString("F3");
        }

        double calculatePerpendicularDistancePointToCurve(double[] xdata, double[] ydata, DenseVector W, 
            FitFunction basis, int deg, Graphics g)
        {
            const double stepSize = 0.01;
            double minX = xdata.Min()-20;
            double maxX = xdata.Max()+20;
            int nCurve = (int)((maxX - minX) / stepSize);
            int n = xdata.Length;
            double[] plotX = new double[nCurve];
            for (int i = 0; i < nCurve; i++)
            {
                plotX[i] = minX + i * stepSize;
            }
            var PlotX = makeBasis(plotX, basis, deg);
            var PlotY = PlotX * W;

            double s = 0;
            for (int i = 0; i < n; i++)
            {
                double minDist = double.MaxValue;
                int minIndex = -1;

                for (int j = 0; j < nCurve; j++)
                {
                    var d = Math.Pow(xdata[i] - plotX[j], 2) + Math.Pow(ydata[i]-PlotY[j], 2);
                                               
                    if (d<minDist)
                    {
                        minDist = d;
                        minIndex = j;
                    }                    
                }

                s += minDist;

                //draw the perpendicular line
                g.DrawLine(new Pen(new SolidBrush(Color.Red)), new PointF((float)xdata[i] * 3, (float)ydata[i] * 3),
                        new PointF((float)plotX[minIndex]*3, (float)PlotY[minIndex]*3));
            }

            double error = Math.Sqrt(s / n);

            return error;
        }

        void drawCurve(Graphics g, DenseVector W, double minX, double maxX, FitFunction basis, int deg=0)
        {
            const double stepSize = 0.1;
            int n = (int)((maxX - minX) / stepSize);
            double[] xdata = new double[n];
            for (int i = 0; i < n; i++)
            {
                xdata[i] = minX + stepSize * i;
            }
            var X = makeBasis(xdata, basis, deg);
            var Y = X * W;

            for (int i = 0; i < n; i++)
            {
                drawPoint2DOnControl(g, new PointF((float)xdata[i], (float)Y[i]), Color.Blue, 1);
            }
        }

        void drawPoint2DOnControl(Graphics g, PointF point, Color color, int size)
        {
            //point.Y = -point.Y;            
            //point.X += 30;
            //point.Y += 30;
            point.X *= 3;
            point.Y *= 3;
            g.DrawEllipse(new Pen(new SolidBrush(color)),
                new RectangleF((float)point.X, (float)point.Y, size, size));

        }

        
        DenseVector fitLeastSquaresBasis(double[] xdata, double[] ydata, FitFunction basis, int deg=1)
        {   
            var X = makeBasis(xdata, basis, deg);
            var Y = new MathNet.Numerics.LinearAlgebra.Double.DenseVector(ydata);
            var A = (DenseMatrix)X.Transpose() * X;
            var B = (DenseVector)(X.Transpose() * Y);
            var W = (DenseVector)(A.Solve(B));

            return W;
        }

        DenseMatrix makeBasis(double[] xdata, FitFunction basis, int deg)
        {
            int n = xdata.Length;
            int columns = 0;
            if (basis == FitFunction.polynomial)
                columns = deg+1;
            else if (basis == FitFunction.noroozi)
                columns = 3;
            var X = new DenseMatrix(n, columns);

            switch (basis)
            {
                case FitFunction.polynomial:
                    for (int j = 0; j <= deg; j++)
                    {                        
                        for (int i = 0; i < n; i++)                        
                            X[i,j] = Math.Pow(xdata[i], j);                        
                    }

                    break;
                case FitFunction.noroozi:
                    int t;
                    t = 0;
                    for (int i = 0; i < n; i++)
                        X[i, 0] = Math.Pow(xdata[i], t);
                    t = 2;
                    for (int i = 0; i < n; i++)
                        X[i, 1] = Math.Pow(xdata[i], t);
                    t = 6;
                    for (int i = 0; i < n; i++)
                        X[i, 2] = Math.Pow(xdata[i], t);
                    break;
                default:
                    break;
            }

            return X;

        }

    }
}


//deleted

//graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black)),
//    new RectangleF(10, 10, 10, 10));

//var sqe = GoodnessOfFit.RSquared(xdata.Select(x => f[0] + f[1] * x + f[2] * x * x), ydata);
//double sqe = 0;
//for (int i=0; i< num; ++i)
//{
//    double t = 0;
//    for (int o = 0; o <= deg; ++o)
//    {
//        t += (f[o]* Math.Pow(xdata[i], o));
//    }

//    double err = ((ydata[i] - t) * (ydata[i] - t));
//    sqe += err;
//}
//var rmse = Math.Sqrt(sqe/num);



//var minX = (int)(xdata.Min());
//var maxX = (int)(xdata.Max()+1);
//var numCurvePoints = maxX - minX;
//var ydataHat = new double[numCurvePoints];
//for (double i=0; i< numCurvePoints; i+=0.5)
//{
//    double y = MathNet.Numerics.Evaluate.Polynomial(i+minX, f);
//    drawPoint2DOnControl(graphics, new Vector2d(i + minX, y), Color.Red, 2);
//}
