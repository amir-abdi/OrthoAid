using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using System.IO;
using System.Xml.Serialization;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace OrthoAid_3DSimulator.Common
{
    public enum ViewMode { Points, WireFrame, Mesh };
    public enum EditMode { Hand, Select, Ruler };
    public enum VerticesSelectionType { vertices, trueVertices };
    public enum BBPChoice { User, AutoMiddle };
    public enum SuperimposeChoise { Order, YDir, Equal };

    public struct CalculationResults
    {
        public Dislocation[] dislocation;
        public Plane[] planes;
        public Plane[] rplanes;
        public DistanceToPlane[] distanceToOccPlane;
        public DistanceToPlane[] distanceToSagPlane;
        public CalculationResults(Plane[] p, Dislocation[] d, Plane[] r, DistanceToPlane[] dO, DistanceToPlane[] dS)
        { dislocation = d; planes = p; rplanes = r; distanceToOccPlane = dO; distanceToSagPlane = dS; }        
    }

    public struct Dislocation
    {
        public Vector3 dislocation;
        public float length;
        public bool valid;
    }

    public struct DistanceToPlane
    {
        public float length;
        public bool valid;
    }

    public class Vbo
    {
        public int VboVertices, TriEID, WireframeEID, VboColor,             
               VboNormals, NumTriElements, NumWireElements;        
        public bool validVertices, validNormals, validMesh, validWireframe, validColor;
        public VerticesData verticesData;
        public VerticesStats verticesStats;

        public List<uint> selectedVertices = new List<uint>();
        public Vector3 color;
        public bool show;
        public string vboName;
    }

    public struct VerticesData
    {
        public Vector3[] vertices;
        public UInt32[] indices;
        public Vector3[] normals;
    }

    public struct Flags
    {
        public bool RandomColorEnable,
                 TextureEnable,
                 LightingEnable,                 
                 showPoints_MeshMode;
        public VerticesSelectionType verticesSelectionType;

    }    

    public struct VerticesStats
    {
        public Vector3 Mean;
        public float MinX, MinY, MaxX, MaxY, MinZ, MaxZ;
        public int numVertices;
        public int numFaces;
        public float averageVertexDistance;
        public string name;
    }

    public class Segment2D
    {
        private Vector2 A, B;

        public Segment2D(Vector2 point1, Vector2 point2)
        {
            A = point1; B = point2;
        }

        public int PointSide(Vector2 point)
        {
            float t = (B.X - A.X) * (point.Y - A.Y) - (B.Y - A.Y) * (point.X - A.X);
            if (t > 0)
                return 1;
            else if (t < 0)
                return -1;
            else
                return 0;
        }
    }


    public class Line2D
    {
        private float a, b, c;
        public Line2D(Vector2 p0, Vector2 p1)
        {
            a = (p1.Y - p0.Y) / (p1.X - p0.X);
            b = -1;
            c = (p1.X * p0.Y - p0.X * p1.Y) / (p1.X - p0.X);
        }

        public float DistanceToPoint(Vector2 p)
        {
            float dist = Math.Abs(a * p.X + b * p.Y + c) / (new Vector2(a, b)).Length;
            return dist;
        }

        public float PerpendicularMu()
        {
            float mu = -a / b;
            return -1 / a;
        }

        public Line2D(Vector2 point, float mu)
        {
            b = -1;
            a = mu;
            c = -point.X * a - point.Y * b;
        }

        public float CalculateYAtPoint(float x)
        {
            return ( (-c-a*x)/b );
        }

        public Vector2[] CrosspointWithCurve(double[] coeffs)
        {
            Vector2[] result = null;
            float la = 0;
            float lb = 0;
            float lc = -a / b;
            float ld = -c / b;

            double A = coeffs[3] - la;
            double B = coeffs[2] - lb;
            double C = coeffs[1] - lc;
            double D = coeffs[0] - ld;


            double[] crossXs = Common.SolveCubic_NonComplex2(A, B, C, D);
            if (crossXs.Length == 0)
                throw new Exception("SolveCubic_NonComplex didn't find any answer");
            result = new Vector2[crossXs.Length];
            for (int i = 0; i < crossXs.Length; i++)
            {
                result[i] = new Vector2((float)crossXs[i], CalculateYAtPoint((float)crossXs[i]));
            }

            return result;
        }
    }

    public class Line3D
    {
        private Vector3 pointOnLine;
        private Vector3 direction;

        public Line3D(Vector3 pointOnLine1, Vector3 pointOnLine2)
        {
            this.pointOnLine = pointOnLine1;
            this.direction = pointOnLine2 - pointOnLine1;
        }

        public float Distance2Point(Vector3 point)
        {
            //d = |(point-pointOnLine)X(direction)|/|direction|
            float d = (Vector3.Cross((point - pointOnLine), direction)).Length / direction.Length;

            return d;
        }

        public float Distance2PointSquared(Vector3 point)
        {
            //d = |(point-pointOnLine)X(direction)|/|direction|
            float d = (Vector3.Cross((point - pointOnLine), direction)).LengthSquared / direction.LengthSquared;

            return d;
        }
        
    }


    public class Plane
    {        
        public float a, b, c, d;
        string name;
        public Vector3[] pointsForDraw; //not used
        public bool valid; //not used
        public bool validInclination = false;
        public Vector3 center, lowestPoint, highestPoint; //not used (albate used, vali mishe baresh dasht FindAndSortPointsOnBuccalSide
        public float radius; //not used
        public Vector3 centerForDraw;        
        public Vector3[] tangentPoints; 
        public Vector3[] projectedPointsOnAxisPlane; //not used
        public float inclination { get; set; }

        public Plane(Vector3 point1, Vector3 point2, Vector3 point3, string _name, float _radius)
        {
            a = (point2.Y - point1.Y) * (point3.Z - point1.Z) - (point3.Y - point1.Y) * (point2.Z - point1.Z);
            b = (point2.Z - point1.Z) * (point3.X - point1.X) - (point3.Z - point1.Z) * (point2.X - point1.X);
            c = (point2.X - point1.X) * (point3.Y - point1.Y) - (point3.X - point1.X) * (point2.Y - point1.Y);
            d = -(a * point1.X + b * point1.Y + c * point1.Z);


            #region Cramer's Equation Solving Rule
            //float D = point1.X * point2.Y * point3.Z +
            //            point3.X * point1.Y * point2.Z +
            //            point2.X * point3.Y * point1.Z -
            //            point3.X * point2.Y * point1.Z -
            //            point2.X * point1.Y * point3.Z -
            //            point1.X * point3.Y * point2.Z;
            //d = -1000;
            //a = point2.Y * point3.Z + point1.Y * point2.Z + point1.Z * point3.Y
            //    - point1.Z * point2.Y - point1.Y * point3.Z - point2.Z * point3.Y;
            //a *= (d/D);

            //b = point1.X * point3.Z + point2.Z * point3.X + point1.Z * point2.X
            //    - point1.Z * point3.X - point2.X * point3.Z - point1.X * point2.Z;
            //b *= (d / D);

            //c = point1.X * point2.Y + point1.Y * point3.X + point2.X * point3.Y
            //    - point2.Y * point3.X - point1.Y * point2.X - point1.X * point3.Y;
            //c *= (d / D);
            #endregion


            //pointsForDraw = new Vector3[3];            
            //pointsForDraw[0] = point1;
            //pointsForDraw[1] = point2;
            //pointsForDraw[2] = point3;

            radius = _radius;
            name = _name;
            valid = true;
            lowestPoint = point1;
            center = point2;
            highestPoint = point3;
            centerForDraw = (point1 + point2 + point3) / 3;

            pointsForDraw = new Vector3[4];
            GeneratePointsForDraw();
        }

        public Plane(float a, float b, float c, float d, string _name, 
            float lx, float ly, float lz, 
            float cx, float cy, float cz,
            float hx, float hy, float hz,
            float _radius)
        {
            name = _name;

            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;

            valid = true;

            radius = _radius;

            lowestPoint = new Vector3(lx,ly,lz);
            center = new Vector3(cx, cy, cz);                        
            highestPoint = new Vector3(hx,hy,hz);


            pointsForDraw = new Vector3[4];
            GeneratePointsForDraw();

            //how to give value to "pointsForDraw"
            //gotta change pointsForDraw! that was an awful idea from the beginning!
            //a center and a radius (constant) sounds nice
            //finding center is always easy and it's easy to write it in a file
            //radius is constant, so nothing to worry there.
            //but how to calc 4 points with these 2 params?
            //...hmmm!

            //should find 2 perpendicular vectors lying on the plane(a,b,c,d)
            //then find 2 points on each vector with distance r to center.

            //solution: project vector (1,0,0) on the plane (check if length == 0, project (0,1,0) instead) --> v1
            //cross product the above vector with normal vector (a,b,c) --> v2
            //and that's it! u have your 2 perpendicular vectors.

            //p1 = center+v1*r
            //p2 = center+v2*r
            //p3 = center-v1*r
            //p4 = center-v2*r
        }

        public Plane(Vector3 point1, Vector3 point2, Vector3 vector)
        {
            //point1 and point2 are on the plane
            //vector is on the plane

            Vector3 vector2 = point1-point2;
            Vector3 normal = Vector3.Cross(vector, vector2);

            a = normal.X;
            b = normal.Y;
            c = normal.Z;
            d = -(normal.X * point1.X + normal.Y * point1.Y + normal.Z * point1.Z);

            valid = true;

            radius = 50; //const float PLANE_DRAW_RADIUS_OTHER = 50;
            centerForDraw = point1;
            pointsForDraw = new Vector3[4];
            GeneratePointsForDraw();
        }

        public Plane(Vector3 point1, Vector3 point2, Vector3 point3, Vector3 vector1, Vector3 vector2, 
            string _name, float _radius)
        {
            //one point is enough to define plane, why using 3 points?
            // points 3 is not used! just sending it :) (but used to be used as calculation for center!)
            // point2 is center
            //two vectors are on the plane

            Vector3 normal = Vector3.Cross(vector1, vector2);
            a = normal.X;
            b = normal.Y;
            c = normal.Z;
            d = -(normal.X * point1.X + normal.Y * point1.Y + normal.Z * point1.Z);

            name = _name;

            valid = true;

            radius = _radius;
            center = point2; //new Vector3((point1 + point2) / 2);
            lowestPoint = point1;
            highestPoint = point3;

            pointsForDraw = new Vector3[4];
            GeneratePointsForDraw();
        }

        public Plane(Vector3 normal, Vector3 point)
        {
            normal.Normalize();
            a = normal.X;
            b = normal.Y;
            c = normal.Z;
            d = -(normal.X * point.X + normal.Y * point.Y + normal.Z * point.Z);
                                    
            valid = true;

            radius = 50; //const float PLANE_DRAW_RADIUS_OTHER = 50;
            centerForDraw = point;
            pointsForDraw = new Vector3[4];
            GeneratePointsForDraw();
        }

        public Plane()
        {
        }

        private void GeneratePointsForDraw()
        {            
            Vector3 c,v1;
            ProjectVectorOnPlane(centerForDraw, new Vector3(1,1,0), out c, out v1);
            if (v1.Length == 0)
                ProjectVectorOnPlane(centerForDraw, new Vector3(0,1,1), out c, out v1);
            
            Vector3 v2 = Vector3.Cross(v1, GetNormal());

            v1.Normalize();
            v2.Normalize();
            
            pointsForDraw = new Vector3[4];            
            pointsForDraw[0] = centerForDraw+v1*radius;
            pointsForDraw[1] = centerForDraw + v2 * radius;
            pointsForDraw[2] = centerForDraw - v1 * radius;
            pointsForDraw[3] = centerForDraw - v2 * radius;
        }

        public float Angle2Vector(Vector3 v)
        {
            Vector3 t = new Vector3(a, b, c);
            float angle = (float)Math.Asin(Math.Abs(a * v.X + b * v.Y + c * v.Z) / (t.Length * v.Length));
            return angle;
        }
        
        public double Angle2Plane(Plane p)
        {
            double t = Math.Acos(Vector3.Dot(GetNormal(), p.GetNormal()))*180/Math.PI;
            if (t > 90)
                t = Math.Abs(t - 180);
            return t;

        }

        public void GetFourExtremePoints(out Vector3[] points, VerticesStats vs)
        {
            float extraExtension = 3;
            Vector3 p1 = new Vector3(vs.MinX - extraExtension, vs.MinY - extraExtension, vs.MinZ - extraExtension);
            Vector3 p2 = new Vector3(vs.MinX - extraExtension, vs.MaxY + extraExtension, vs.MaxZ + extraExtension);
            Vector3 p3 = new Vector3(vs.MaxX + extraExtension, vs.MaxY + extraExtension, vs.MaxZ + extraExtension);
            Vector3 p4 = new Vector3(vs.MaxX + extraExtension, vs.MinY - extraExtension, vs.MinZ - extraExtension);

            //project p1-p4 on the plane and set "points" to them
            points = new Vector3[4];
            points[0] = new Vector3(ProjectPointOnPlane(p1));
            points[1] = new Vector3(ProjectPointOnPlane(p2));
            points[2] = new Vector3(ProjectPointOnPlane(p3));
            points[3] = new Vector3(ProjectPointOnPlane(p4));
        }

        public Vector3 ProjectPointOnPlane(Vector3 point)
        {
            float u = point.X;
            float v = point.Y;
            float w = point.Z;

            float x0 = u - a * ((a * u + b * v + c * w + d) / (a * a + b * b + c * c));
            float y0 = v - b * ((a * u + b * v + c * w + d) / (a * a + b * b + c * c));
            float z0 = w - c * ((a * u + b * v + c * w + d) / (a * a + b * b + c * c));

            return new Vector3(x0, y0, z0);
        }

        public Vector3[] ProjectPointOnPlane(Vector3[] points)
        {
            Vector3[] result = new Vector3[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = ProjectPointOnPlane(points[i]);
            }
            return result;
        }

        private void ProjectVectorOnPlane(Vector3 startPoint, Vector3 vector, out Vector3 startPointOnPlane, out Vector3 vectorOnPlane)
        {
            startPointOnPlane = ProjectPointOnPlane(startPoint);
            Vector3 endPoint = startPoint+vector;
            Vector3 endPointOnPlane = ProjectPointOnPlane(endPoint);
            vectorOnPlane = endPointOnPlane - startPointOnPlane;
        }

        public double Distance2Point(Vector3 p)
        {
            float u = p.X;
            float v = p.Y;
            float w = p.Z;

            double dist = Math.Abs(a * u + b * v + c * w + d) / Math.Sqrt(a * a + b * b + c * c);
            return dist;
        }

        public Vector3 GetNormal()
        {
            Vector3 n = new Vector3(a, b, c);
            n.Normalize();
            return n;
        }

        public  Vector3[] RotatePointsToNewPlane(Vector3[] projectedPointsOnThisPlane, Vector3 newPlaneNormal) //doesn't work, unless newPlaneNormal = Vector3.unitZ
        {
            //doesn't work, unless newPlaneNormal = Vector3.unitZ

            Vector3 normal2CurrentPlane = this.GetNormal();
            //Vector3 normal2NewPlane = newPlane.GetNormal();
            float cosT = Vector3.Dot(normal2CurrentPlane, newPlaneNormal);//Vector3.UnitZ);
            //float sinT = float(Math.Sqrt(1-cosT*cosT));

            //??? shayad mikhastam faghat ye vector dakhele plane be dast biaram!
            Vector3 u = Vector3.Cross(normal2CurrentPlane, newPlaneNormal);//Vector3.UnitZ);
            u.Normalize();

            //Matrix4 rotMat = new Matrix4(new Vector4(cosT+u.X*u.X*(1-cosT),u.X*u.Y*(1-cosT)-u.Z*sinT, u.X*u.Z*(1-cosT)+u.Y*sinT,0),
            //                            new Vector4(u.Y*u.X*(1-cosT)+u.Z*sinT, cosT*u.Y*u.Y*(1-cosT), u.Y*u.Z*(1-cosT)-u.X*sinT,0),
            //                                new Vector4(u.Z*u.X*(1-cosT)-u.Y*sinT, u.Z*u.Y*(1-cosT)+u.X*sinT, cosT+u.Z*u.Z*(1-cosT),0),
            //                                new Vector4(0,0,0,1)
            //                                );

            Matrix4 rotMat = Matrix4.Rotate(u, (float)Math.Acos(cosT));

            
            Vector3[] newPoints = new Vector3[projectedPointsOnThisPlane.Length];
            for (int i = 0; i < newPoints.Length; i++)
            {
                Matrix4 t = new Matrix4(new Vector4(projectedPointsOnThisPlane[i]), 
                    new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
                t = Matrix4.Mult(t, rotMat);
                newPoints[i] = t.Row0.Xyz;
            }
            
            return newPoints;
        }

        public static Vector3[] RotatePointsAroundAxis(Vector3[] points, Vector3 Axis, float degreeInRadian)
        {
            Matrix4 rotMat = Matrix4.Rotate(Axis, degreeInRadian);


            Vector3[] newPoints = new Vector3[points.Length];
            for (int i = 0; i < newPoints.Length; i++)
            {
                Matrix4 t = new Matrix4(new Vector4(points[i]), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
                t = Matrix4.Mult(t, rotMat);
                newPoints[i] = t.Row0.Xyz;
            }

            return newPoints;
        }

        public void RotationAxisAndDegreeToMakePlaneHorizontal(out Vector3 RotationAxis, out float degree)
        {
            Vector3 normal2CurrentPlane = this.GetNormal();
            //Vector3 normal2NewPlane = newPlane.GetNormal();
            float cosT = Vector3.Dot(normal2CurrentPlane, Vector3.UnitZ);
            degree = (float)Math.Acos(cosT);
            //float sinT = float(Math.Sqrt(1-cosT*cosT));

            //??? shayad mikhastam faghat ye vector dakhele plane be dast biaram!
            RotationAxis = Vector3.Cross(normal2CurrentPlane, Vector3.UnitZ);
            RotationAxis.Normalize();
        }

        public int PointSide(Vector3 point)
        {
            float t = a * point.X + b * point.Y + c * point.Z + d;
            if (t > 0)
                return 1;
            else if (t < 0)
                return -1;
            else
                return 0;
        }
    }

    public class PolynominalRegression
    {
        private int _order;
        private MathNet.Numerics.LinearAlgebra.Vector<double> _coefs;
        private MathNet.Numerics.LinearAlgebra.Vector<double> _coefsDer;

        public PolynominalRegression(DenseVector xData, DenseVector yData, int order)
        {
            _order = order;
            int n = xData.Count;

            var vandMatrix = new DenseMatrix(xData.Count, order + 1);
            for (int i = 0; i < n; i++)
                vandMatrix.SetRow(i, VandermondeRow(xData[i], _order));

            // var vandMatrixT = vandMatrix.Transpose();
            // 1 variant:
            //_coefs = (vandMatrixT * vandMatrix).Inverse() * vandMatrixT * yData;
            // 2 variant:
            //_coefs = (vandMatrixT * vandMatrix).LU().Solve(vandMatrixT * yData);
            // 3 variant (most fast I think. Possible LU decomposion also can be replaced with one triangular matrix):
            _coefs = vandMatrix.TransposeThisAndMultiply(vandMatrix).LU().Solve(TransposeAndMult(vandMatrix, yData));
            _coefsDer = new MathNet.Numerics.LinearAlgebra.Double.DenseVector(order);
            for (int i = 0; i < order; i++)
            {

                _coefsDer[i] = _coefs[i + 1] * (i + 1);
            }
        }

        private Vector VandermondeRow(double x, int order)
        {
            double[] result = new double[order + 1];
            double mult = 1;
            for (int i = 0; i <= order; i++)
            {
                result[i] = mult;
                mult *= x;
            }
            return new DenseVector(result);
        }

        private static DenseVector TransposeAndMult(Matrix m, Vector v)
        {
            var result = new DenseVector(m.ColumnCount);
            for (int j = 0; j < m.RowCount; j++)
                for (int i = 0; i < m.ColumnCount; i++)
                    result[i] += m[j, i] * v[j];
            return result;
        }

        public double Calculate(double x)
        {
            return VandermondeRow(x, _order) * _coefs;
        }

        public double DerivativeAtPoint(double x)
        {
            return VandermondeRow(x, _order-1) * _coefsDer;
        }

        public double[] GetCoefficients()
        {
            return _coefs.ToArray();
        }
    }
    
}
