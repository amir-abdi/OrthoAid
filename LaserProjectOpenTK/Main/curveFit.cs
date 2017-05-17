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
using MathNet.Numerics.Differentiation;
using MathNet.Numerics.LinearAlgebra.Double;
using OrthoAid_3DSimulator.Common;


namespace OrthoAid_3DSimulator
{
    public partial class MainForm
    {
        Common.PolynomialParametric2DCurve[][] WirePolynomials = new PolynomialParametric2DCurve[2][];
        Common.PolynomialParametric2DCurve[] CurveFit = new PolynomialParametric2DCurve[2];
        Tuple<Tuple<DenseVector, DenseVector>, double, int>[] CurveFits = new Tuple<Tuple<DenseVector, DenseVector>, double, int>[config.NumWires];

        void CalculateCurveFit(Common.Vbo handle)
        {            
            int num = handle.selectedVertices.Count;            
            var pointsMat = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(num, 3);
            var points = new Vector3[num];

            //get selected points
            for (int i = 0; i < num; i++)
            {
                pointsMat[i, 0] = handle.verticesData.vertices[handle.selectedVertices[i]].X;
                pointsMat[i, 1] = handle.verticesData.vertices[handle.selectedVertices[i]].Y;
                pointsMat[i, 2] = handle.verticesData.vertices[handle.selectedVertices[i]].Z;

                points[i] = handle.verticesData.vertices[handle.selectedVertices[i]];
            }

            //find the plane which holds the least distance to all ponits using SVD
            Common.Plane curve_plane = NormalPlane(pointsMat);
            curve_plane.valid = true;
            Planes[GetSelectedVbOIndex()-1][CURVEPLANE_INDEX] = curve_plane;

            if (Planes[GetSelectedVbOIndex()-1][OCCLUSALPLANE_INDEX] != null &&
                Planes[GetSelectedVbOIndex()-1][OCCLUSALPLANE_INDEX].valid)
            {
                double angle = Planes[GetSelectedVbOIndex()-1][CURVEPLANE_INDEX].Angle2Plane(Planes[0][OCCLUSALPLANE_INDEX]);
                lb_curve2occlusalPlane.Text = "Angle to Occlusal Plane: " + angle.ToString("F2");
            }            

            //calculate sum of distances to this plane
            double sumOfSquaredDistances = 0;
            for (int i= 0; i<num; ++i)
            {
                sumOfSquaredDistances += Math.Pow(curve_plane.Distance2Point(points[i]),2);
            }
            double rmse_z = Math.Sqrt(sumOfSquaredDistances / num);

            // find the x and y direction on the plane             
            var p0 = new Vector3(curve_plane.ProjectPointOnPlane(new Vector3(0, 0, 0)));
            var px = new Vector3(curve_plane.ProjectPointOnPlane(points[num-1] - points[0])); //new Vector3(1, 0, 0)));
            var py = new Vector3(curve_plane.ProjectPointOnPlane(Vector3.Cross(curve_plane.GetNormal(), px))); //new Vector3(0, 1, 0)));
            var pvx = (px - p0);
            var pvy = (py - p0);
            pvx.Normalize();
            pvy.Normalize();


            //project 3D points on the plane and create a 2D point set  
            var xdata = new double[num];
            var ydata = new double[num];
            
            for (int i=0; i< num; ++i)
            {                
                xdata[i] = Vector3.Dot(pvx, points[i] - p0);
                ydata[i] = Vector3.Dot(pvy, points[i] - p0);
            }


            //check and fix inverse y mode
            //fiiiiiiiiix.... r u fiiix? --> by yasaman, the best developer in Acadia
            if (ydata[0] < ydata[ydata.Length / 2])
                ydata = ydata.Select(el => -el).ToArray();

            //move points to fit on the screen
            var xMin = xdata.Min();
            var yMin = ydata.Min();            
            for (int i=0; i<num; ++i)
            {
                xdata[i] -= xMin;
                ydata[i] -= yMin;

                xdata[i] += 10;
                ydata[i] += 10;
            }
            
            
            //drawing projected points
            var graphics = pl_curveFit.CreateGraphics();
            graphics.Clear(Color.White);
            for (int i = 0; i < num; ++i)
            {
                DrawPoint2DOnControl(graphics, new PointF((float)xdata[i], (float)ydata[i]), Color.Black, 4);
            }
            //DrawPoint2DOnControl(graphics, new PointF((float)10, (float)20), Color.Red, 10);

            //change of parameter
            var diffx = Diff(xdata);
            var diffy = Diff(ydata);
            diffx= diffx.Select(el => el * el).ToArray();
            diffy = diffy.Select(el => el * el).ToArray();
            double[] t = new double[num];
            for (int i = 0; i< num; ++i)
            {
                if (i > 0)
                    t[i] = Math.Sqrt(diffx[i] + diffy[i]) + t[i - 1];
                else
                    t[i] = Math.Sqrt(diffx[i] + diffy[i]);
            }

            //fit curve params
            int deg = (int)nUpDown_order.Value;
            FitFunction fitFunction = config.fitFunction;

            //fit x and y to t
            DenseVector Wx;
            DenseVector Wy;
            try
            {
                //f = Fit.Polynomial(xdata, ydata, order);
                Wx = FitLeastSquaresBasis(t, xdata, fitFunction, deg);
                Wy = FitLeastSquaresBasis(t, ydata, fitFunction, deg);
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "curveFit.cs", "CalculateCurveFit",
                    e.Message);
                MessageBox.Show("The order of polynomial is too high and " +
                                "results are unstable. Please use a lower " +
                                "degree polynomial.", 
                    "Error in Curve Fitting");
                return;
            }

            // create polynomial curve struct (for later to match to the wire brackets)            
            CurveFit[GetSelectedVbOIndex()-1].CoeffsX = Wx;
            CurveFit[GetSelectedVbOIndex()-1].CoeffsY = Wy;
            CurveFit[GetSelectedVbOIndex()-1].degree = deg;
            CurveFit[GetSelectedVbOIndex()-1].minT = t.Min();
            CurveFit[GetSelectedVbOIndex()-1].maxT = t.Max();
            CurveFit[GetSelectedVbOIndex()-1].fitFunction = fitFunction;

            //calculate xx and yy
            //const double stepSize = 0.01;
            //double mint = t.Min();
            //double maxt = t.Max();
            //int numCurve = (int)((maxt - mint) / stepSize);
            //double[] tt = new double[numCurve];
            //for (int i = 0; i < numCurve; i++)
            //{
            //    tt[i] = mint + stepSize * i;
            //}

            //var TT = MakeBasis(tt, fitFunction, deg);
            //var XX = TT * Wx;
            //var YY = TT * Wy;
            
            Tuple<DenseVector, DenseVector> tempTuple = ParametricPolynomial_to_2DPoints(CurveFit[GetSelectedVbOIndex()-1]);
            DenseVector XX = tempTuple.Item1;
            DenseVector YY = tempTuple.Item2;

            DrawCurve(graphics, XX, YY, Color.Blue);

            //least squares

            //DenseVector W;
            //try
            //{
            //    //f = Fit.Polynomial(xdata, ydata, order);
            //    W = FitLeastSquaresBasis(xdata, ydata, fitFunction, deg);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("The order of polynomial is too high and results are unstable. Please use a lower degree polynomial.", "Error in Curve Fitting");
            //    return;
            //}


            //draw the blue curve
            //DrawCurve(graphics, W, xdata.Min()-4, xdata.Max()+4, fitFunction, deg);

            //calculate Error
            //var rmse_xy = CalculatePerpendicularDistancePointToCurve(xdata, ydata, W, fitFunction, deg, graphics);
            var rmse_xy = CalculatePerpendicularDistancePointToCurve(xdata, ydata, XX, YY, graphics);


            status.Text = "Polynomial order " + deg.ToString() +
                " was fit. Root Mean Square Error = " + rmse_xy.ToString("F2");
            lb_curvefit_rmse_xy.Text = "in-plane RMS Error:   " + rmse_xy.ToString("F2");
            lb_curvefit_rmse_z.Text = "off-plane RMS Error:  " + rmse_z.ToString("F2");

        }

        private double[] Diff(double[] points)
        {
            int num = points.Length;
            double[] diff = new double[num];
            diff[0] = 0;
            for (int i = 1;i<num; ++i)
            {
                diff[i] = points[i] - points[i - 1];
            }
            return diff;
        }

        private Plane NormalPlane(DenseMatrix pointsMat)
        {
            int num = pointsMat.RowCount;
            var centroid = pointsMat.ColumnSums() / num;

            for (int i = 0; i < num; i++)
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
            return p;
        }

        double CalculatePerpendicularDistancePointToCurve(double[] xdata, double[] ydata, DenseVector W, 
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
            var PlotX = MakeBasis(plotX, basis, deg);
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

                s += minDist; //sum of squared error

                //draw the perpendicular line
                g.DrawLine(new Pen(new SolidBrush(Color.Red)), new PointF((float)xdata[i] * 3, (float)ydata[i] * 3),
                        new PointF((float)plotX[minIndex]*3, (float)PlotY[minIndex]*3));
            }

            double error = Math.Sqrt(s / n); //root mean squared error

            return error;
        }

        double CalculatePerpendicularDistancePointToCurve(double[] xdata, double[] ydata, 
            DenseVector PlotX, DenseVector PlotY, Graphics g)
        {            
            int numCurve = PlotX.Count;            
            int num = xdata.Length;            
            
            double s = 0;
            for (int i = 0; i < num; i++)
            {
                double minDist = double.MaxValue;
                int minIndex = -1;

                for (int j = 0; j < numCurve; j++)
                {
                    var d = Math.Pow(xdata[i] - PlotX[j], 2) + Math.Pow(ydata[i] - PlotY[j], 2);

                    if (d < minDist)
                    {
                        minDist = d;
                        minIndex = j;
                    }
                }

                s += minDist; //sum of squared error

                //draw the perpendicular line
                g.DrawLine(new Pen(new SolidBrush(Color.Red)), new PointF((float)xdata[i] * 3, (float)ydata[i] * 3),
                        new PointF((float)PlotX[minIndex] * 3, (float)PlotY[minIndex] * 3));
            }

            double error = Math.Sqrt(s / num); //root mean squared error

            return error;
        }

        void DrawCurve(Graphics g, DenseVector W, double minX, double maxX, FitFunction basis, int deg=0)
        {
            const double stepSize = 0.1;
            int n = (int)((maxX - minX) / stepSize);
            double[] xdata = new double[n];
            for (int i = 0; i < n; i++)
            {
                xdata[i] = minX + stepSize * i;
            }
            var X = MakeBasis(xdata, basis, deg);
            var Y = X * W;

            for (int i = 0; i < n; i++)
            {
                DrawPoint2DOnControl(g, new PointF((float)xdata[i], (float)Y[i]), Color.Blue, 1);
            }
        }

        void DrawCurve(Graphics g, DenseVector xdata, DenseVector ydata,  Color color)
        {
            int num = xdata.Count;
            for (int i = 0; i < num; i++)
            {
                DrawPoint2DOnControl(g, new PointF((float)xdata[i], (float)ydata[i]), color, 1);
            }
        }

        void DrawPoint2DOnControl(Graphics g, PointF point, Color color, int size)
        {
            //point.Y = -point.Y;            
            //point.X += 30;
            //point.Y += 30;
            point.X *= 3;
            point.Y *= 3;
            g.DrawEllipse(new Pen(new SolidBrush(color)),
                new RectangleF((float)point.X, (float)point.Y, size, size));

        }
        
        DenseVector FitLeastSquaresBasis(double[] xdata, double[] ydata, FitFunction basis, int deg=1)
        {   
            var X = MakeBasis(xdata, basis, deg);
            var Y = new DenseVector(ydata);
            var A = (DenseMatrix)X.Transpose() * X;
            var B = (DenseVector)(X.Transpose() * Y);
            var W = (DenseVector)(A.Solve(B));

            return W;
        }


        DenseMatrix MakeBasis(double[] xdata, FitFunction basis, int deg)
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


        private void B_MatchingWire_Clicked(object sender, EventArgs e)
        {
            if ((GetSelectedVbOIndex() == 1 && (Planes[0][CURVEPLANE_INDEX] == null || !Planes[0][CURVEPLANE_INDEX].valid)) ||
                (GetSelectedVbOIndex() == 2 && (Planes[1][CURVEPLANE_INDEX] == null || !Planes[1][CURVEPLANE_INDEX].valid)))
            {
                MessageBox.Show("To find the matching arch wire, first Select some bracket points and fit a curve onto the selected points.", "No curve fitted");
                return;
            }

            int index_mandible_maxilla;
            if (rb_mandible.Checked)
                index_mandible_maxilla = 0;
            else if (rb_maxilla.Checked)
                index_mandible_maxilla = 1;
            else
            {
                MessageBox.Show("Either Select mandible or maxilla.");
                return;
            }
            
            double[] errs = new double[config.NumWires];
            int[] indices = new int[config.NumWires];
            var CurveFits_temp = new Tuple <Tuple<DenseVector, DenseVector>, double, int>[config.NumWires];
            for (int i = 0; i < config.NumWires; i++)
            {
                var wire = WirePolynomials[index_mandible_maxilla][i];
                CurveFits_temp[i] = new Tuple<Tuple<DenseVector, DenseVector>, double, int>(
                    RegisterCurveOnWire(wire, CurveFit[GetSelectedVbOIndex()-1]).Item1,
                    RegisterCurveOnWire(wire, CurveFit[GetSelectedVbOIndex() - 1]).Item2, i+1);
                errs[i] = CurveFits_temp[i].Item2;                
                indices[i] = i;
            }

            // sort results and put into CurveFits
            Array.Sort(errs, indices);
            for (int i = 0; i < config.NumWires; i++)
            {
                int t = indices[i];
                CurveFits[i] = CurveFits_temp[t];
            }

            //insert items into listview
            lv_wires.Clear();
            lv_wires.Columns.Add("RMSE", 50, HorizontalAlignment.Center);
            lv_wires.Columns.Add("Wire No.", 60, HorizontalAlignment.Center);
            for (int i = 0; i < config.NumWires; i++)        
                lv_wires.Items.Add(new ListViewItem(new String[] { (    (double)CurveFits[i].Item2).ToString("F2"),
                                                                        ((int)CurveFits[i].Item3).ToString()}   ));
            
            

            //lv_wires.Sorting = SortOrder.Ascending;
            lv_wires.Items[0].Selected = true;

            //if (least_error_index != -1)
            //{
            //    //lb_bestWire.Text = "Best Arch Wire:  No. " + (least_error_index + 1).ToString() + 
            //    //    "\n                           RMSE: " + least_error.ToString("F2");

            //    // draw best match 
            //    var wirePoints = registeration.Item1;
            //    var curvePoints = ParametricPolynomial_to_2DPoints(CurveFit[GetSelectedVbOIndex() - 1]);
            //    //var new_wirePoints = TranslatePoints(wirePoints, 30.0, 0);
            //    //var new_curvePoints = TranslatePoints(wirePoints, 30.0, 0);
            //    //DenseVector wirePointsX = (DenseVector)wirePoints.Item1.Add(60);
            //    //DenseVector curvePointsX = (DenseVector)curvePoints.Item1.Add(60);

            //    var graphics = pl_wireMatch.CreateGraphics();
            //    graphics.Clear(Color.White);
            //    DrawCurve(graphics, curvePoints.Item1, curvePoints.Item2, Color.Blue);
            //    DrawCurve(graphics, wirePoints.Item1, wirePoints.Item2, Color.Green);

            //}
        }


        private void LV_Wires_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_wires.SelectedIndices.Count > 0)
            {
                var registeration = CurveFits[lv_wires.SelectedIndices[0]];
                var wirePoints = registeration.Item1;
                var curvePoints = ParametricPolynomial_to_2DPoints(CurveFit[GetSelectedVbOIndex() - 1]);

                var graphics = pl_wireMatch.CreateGraphics();
                graphics.Clear(Color.White);
                DrawCurve(graphics, curvePoints.Item1, curvePoints.Item2, Color.Blue);
                DrawCurve(graphics, wirePoints.Item1, wirePoints.Item2, Color.Green);
            }
        }

        private Tuple<DenseVector, DenseVector> TranslatePoints(Tuple<DenseVector, DenseVector> wirePoints, double dx, double dy)
        {
            return new Tuple<DenseVector, DenseVector>(wirePoints.Item1.Select(el => el - dx).ToArray(),
                                                        wirePoints.Item2.Select(el => el - dy).ToArray());
        }

        private Tuple<Tuple<DenseVector, DenseVector>, double> RegisterCurveOnWire(PolynomialParametric2DCurve wire, PolynomialParametric2DCurve curve)
        {
            var graphics = pl_curveFit.CreateGraphics();
            var wirePoints = ParametricPolynomial_to_2DPoints(wire);
            var curvePoints = ParametricPolynomial_to_2DPoints(curve);
            

            int minYindex_wire = wirePoints.Item2.MinimumIndex();            
            int minYindex_curve = curvePoints.Item2.MinimumIndex();
            double[] point1_wire = { wirePoints.Item1[minYindex_wire], wirePoints.Item2[minYindex_wire] };
            double[] point1_curve = { curvePoints.Item1[minYindex_curve], curvePoints.Item2[minYindex_curve] };

            // second point is not necessary as I have already pre-aligned everything
            //int maxXindex_wire = wirePoints.Item1.MaximumIndex();
            //int maxXindex_curve = curvePoints.Item1.MaximumIndex();
            //int minXindex_wire = wirePoints.Item1.MinimumIndex();
            //int minXindex_curve = curvePoints.Item1.MinimumIndex();
            //double[] point2_wire = { (wirePoints.Item1[maxXindex_wire] + wirePoints.Item1[minXindex_wire])/2,
            //        (wirePoints.Item2[maxXindex_wire] + wirePoints.Item2[minXindex_wire])/2 };
            //double[] point2_curve = { (curvePoints.Item1[maxXindex_curve] + curvePoints.Item1[minXindex_curve])/2,
            //        (curvePoints.Item2[maxXindex_curve] + curvePoints.Item2[minXindex_curve])/2 };

            //translate wire points to match the front of the curve
            double[] translation = { (point1_wire[0] - point1_curve[0]), (point1_wire[1] - point1_curve[1]) };

            // translate points
            wirePoints = TranslatePoints(wirePoints, translation[0], translation[1]);
            //wirePoints.Item1.Subtract(translation[0]);
            //wirePoints.Item2.Subtract(translation[1]);

            // test draw
            //DrawCurve(graphics, wirePoints.Item1, wirePoints.Item2, Color.Green);

            // HOW TO SHIFT THE CURVE USING ITS PARAMETRIC EQUATION?!
            //wire.CoeffsX[0] += translation[0];
            //wire.CoeffsY[0] += translation[1];
            //wirePoints = ParametricPolynomial_to_2DPoints_matlab(wire);
            //DrawCurve(graphics, wirePoints.Item1, wirePoints.Item2, Color.Green);

            //Calculate error point-based

            // // left and right side of arch
            var curvePointsLeft = new Tuple<DenseVector, DenseVector>((DenseVector)curvePoints.Item1.SubVector(0, minYindex_curve),
                                                                      (DenseVector)curvePoints.Item2.SubVector(0, minYindex_curve));
            var curvePointsRight = new Tuple<DenseVector, DenseVector>((DenseVector)curvePoints.Item1.SubVector(minYindex_curve, curvePoints.Item1.Count- minYindex_curve),
                                                                      (DenseVector)curvePoints.Item2.SubVector(minYindex_curve, curvePoints.Item1.Count - minYindex_curve));
            var wirePointsLeft = new Tuple<DenseVector, DenseVector>((DenseVector)wirePoints.Item1.SubVector(0, minYindex_wire),
                                                                      (DenseVector)wirePoints.Item2.SubVector(0, minYindex_wire));
            var wirePointsRight = new Tuple<DenseVector, DenseVector>((DenseVector)wirePoints.Item1.SubVector(minYindex_wire, wirePoints.Item1.Count - minYindex_wire),
                                                                      (DenseVector)wirePoints.Item2.SubVector(minYindex_wire, wirePoints.Item1.Count - minYindex_wire));

            int maxYindex_curveLeft = curvePointsLeft.Item2.MaximumIndex();
            int maxYindex_curveRight = curvePointsRight.Item2.MaximumIndex();
            double[] maxY_curveLeft = { curvePointsLeft.Item1[maxYindex_curveLeft], curvePointsLeft.Item2[maxYindex_curveLeft] };            
            double[] maxY_curveRight = { curvePointsRight.Item1[maxYindex_curveRight], curvePointsRight.Item2[maxYindex_curveRight] };



            // // get rid of point beyond maxY_curve
            var closestLeft = FindClosestToPoint(wirePointsLeft, maxY_curveLeft);
            var closestRight = FindClosestToPoint(wirePointsRight, maxY_curveRight);
            wirePointsLeft = new Tuple<DenseVector, DenseVector>((DenseVector)wirePointsLeft.Item1.SubVector(closestLeft.Item1, wirePointsLeft.Item1.Count - closestLeft.Item1),
                                                                      (DenseVector)wirePointsLeft.Item2.SubVector(closestLeft.Item1, wirePointsLeft.Item1.Count - closestLeft.Item1));
            wirePointsRight = new Tuple<DenseVector, DenseVector>((DenseVector)wirePointsRight.Item1.SubVector(0, closestRight.Item1),
                                                                      (DenseVector)wirePointsRight.Item2.SubVector(0, closestRight.Item1));

            //test draw
            //DrawCurve(graphics, wirePointsLeft.Item1, wirePointsLeft.Item2, Color.Purple);
            //DrawCurve(graphics, wirePointsRight.Item1, wirePointsRight.Item2, Color.Purple);

            //RMSE
            double sumOfSquares = 0;
            for (int i = 0; i < curvePointsLeft.Item1.Count; i++)
            {
                var closest = FindClosestToPoint(wirePointsLeft, new double[] { curvePointsLeft.Item1[i], curvePointsLeft.Item2[i] });
                sumOfSquares += closest.Item2;
            }
            for (int i = 0; i < curvePointsRight.Item1.Count; i++)
            {
                var closest = FindClosestToPoint(wirePointsRight, new double[] { curvePointsRight.Item1[i], curvePointsRight.Item2[i] });
                sumOfSquares += closest.Item2;
            }
            double rmse = Math.Sqrt(sumOfSquares / (curvePointsRight.Item1.Count + curvePointsLeft.Item1.Count));

            // merge left and right wires
            var finalWire = new Tuple<DenseVector, DenseVector>(new DenseVector(wirePointsLeft.Item1.ToArray().Concat(wirePointsRight.Item1.ToArray()).ToArray()),
                                                                new DenseVector(wirePointsLeft.Item2.ToArray().Concat(wirePointsRight.Item2.ToArray()).ToArray()));

            return new Tuple<Tuple<DenseVector, DenseVector>, double>(finalWire, rmse);
        }

        private Tuple<int, double> FindClosestToPoint(Tuple<DenseVector, DenseVector> line, double[] point)
        {
            //maybe make this better with binary search (or break if distance started to increase)
            double minDist = double.MaxValue;
            int minDistIndex = -1;
            for (int i = 0; i< line.Item1.Count; ++i)
            {
                double dist = ((line.Item1[i] - point[0]) * (line.Item1[i] - point[0])) + ((line.Item2[i] - point[1]) * (line.Item2[i] - point[1]));
                if (dist < minDist) { minDist = dist; minDistIndex = i; }                
            }

            return new Tuple<int, double>(minDistIndex, minDist);
        }

        private Tuple<DenseVector, DenseVector> ParametricPolynomial_to_2DPoints(Common.PolynomialParametric2DCurve curve)
        {
            const double stepSize = 0.1;
            double mint = curve.minT;
            double maxt = curve.maxT;
            int numCurve = (int)((maxt - mint) / stepSize);
            double[] tt = new double[numCurve];
            for (int i = 0; i < numCurve; i++)
            {
                tt[i] = mint + stepSize * i;
            }
            
            var TT = MakeBasis(tt, curve.fitFunction, curve.degree);
            var XX = TT * curve.CoeffsX;
            var YY = TT * curve.CoeffsY;
            
            return new Tuple<DenseVector, DenseVector>(XX, YY);
        }
        
    }
}
