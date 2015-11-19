using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using OpenTK.Input;
using MathNet.Numerics.LinearAlgebra;
using System.IO;

namespace Superimposer
{
    class Program
    {
        static float[] weights = new float[12] 
                                                //{ //9.35754189944134f,
                                                //    100,
                                                // //9.357541899441341f,
                                                // 100,
                                                // 7.9608938547486f,
                                                // 7.9608938547486f,
                                                // 7.82122905027933f, 
                                                // 7.82122905027933f,
                                                // 6.06145251396648f,
                                                // 6.06145251396648f,
                                                // 4.80446927374302f,
                                                // 4.80446927374302f,
                                                // 1.70391061452514f,
                                                // 1.70391061452514f };

                                                //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                                                { 0.935754189944134f, 
                                                 0.9357541899441341f,
                                                 0.79608938547486f,
                                                 0.79608938547486f,
                                                 0.782122905027933f, 
                                                 0.782122905027933f,
                                                 0.606145251396648f,
                                                 0.606145251396648f,
                                                 0.480446927374302f,
                                                 0.480446927374302f,
                                                 0.170391061452514f,
                                                 0.170391061452514f };

        static public void CalculateSuperimpositionTransformation_Mathnet(Vector3[] select1, Vector3[] select2,
            out float[,] rotationMat, out float[] translationMat, out float error)
        {
            int rows = select1.Length;
            var X = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(rows, 3);
            var Y = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(rows, 3);
            var weightArray = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                X[i, 0] = select1[i].X;
                X[i, 1] = select1[i].Y;
                X[i, 2] = select1[i].Z;

                Y[i, 0] = select2[i].X;
                Y[i, 1] = select2[i].Y;
                Y[i, 2] = select2[i].Z;

                if (i <= 12)
                    weightArray[i] = weights[i];
                else
                    weightArray[i] = 1;
            }

            var sumColX = X.ColumnSums();
            var mX = sumColX / rows;
            var sumColY = Y.ColumnSums();
            var mY = sumColY / rows;

            var mXMatrix = Matrix<double>.Build.DenseOfColumnVectors(mX);
            var mYMatrix = Matrix<double>.Build.DenseOfColumnVectors(mY);

            for (int i = 1; i < rows; i++)
            {
                mXMatrix = mXMatrix.Append(Matrix<double>.Build.DenseOfColumnVectors(mX));
                mYMatrix = mYMatrix.Append(Matrix<double>.Build.DenseOfColumnVectors(mY));
            }

            mXMatrix = mXMatrix.Transpose();
            mYMatrix = mYMatrix.Transpose();
            var X0 = X - mXMatrix;
            var Y0 = Y - mYMatrix;

            var normX = X0.FrobeniusNorm();
            var normY = Y0.FrobeniusNorm();

            var W = Matrix<double>.Build.DiagonalOfDiagonalArray(weightArray);

            var A = X0.Transpose() * W * W * Y0;
            var svd = A.Svd(true); // U, VT

            var L = svd.U;
            var D = svd.W;
            var MT = svd.VT;
            var T = (L * MT).ConjugateTranspose();
            var traceTA = D.Diagonal().Sum();

            var e = 1 + Math.Pow((normY / normX), 2) - 2 * traceTA * normY / normX;
            var c = mX - mY * T;

            error = (float)e;
            translationMat = c.Map(x => (float)x).ToArray();
            rotationMat = (T.Map(x => (float)x)).ToArray();
        }

        static Vector3[] TranslateRotate(Vector3[] points, float[,] rotationMat, float[] transformation)
        {
            Vector4[] rotv = new Vector4[4];
            for (int i = 0; i < 3; i++)
            {
                rotv[i] = new Vector4(rotationMat[i, 0], rotationMat[i, 1], rotationMat[i, 2], 0);
            }
            rotv[3] = new Vector4(0, 0, 0, 0);
            Matrix4 rotm = new Matrix4(rotv[0], rotv[1], rotv[2], rotv[3]);
            Vector3 transv = new Vector3(transformation[0], transformation[1], transformation[2]);

            Vector3[] newPoints = new Vector3[points.Length];            
            for (int i = 0; i < newPoints.Length; i++)
            {
                Matrix4 t = new Matrix4(new Vector4(points[i]),
                    new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
                t = Matrix4.Mult(t, rotm);

                newPoints[i] = t.Row0.Xyz + transv;
            }

            return newPoints;
        }

        static Vector3[] ReadSelectionFile(string fileAddress)
        {
            StreamReader sr = new StreamReader(fileAddress);
            try
            {
                string[] header1 = sr.ReadLine().Split(',');
                if (header1[0] != "OrthoAid - TXT Selection File" &&
                    header1[0] != "AHA OrthoAid - TXT Selection File")
                    throw new Exception("Selection calculation file was not in the correct format");

                string header2 = sr.ReadLine();
                if (header2 != "X,Y,Z,index")
                    throw new Exception("Selection calculation file was not in the correct format");
                
                //while (!sr.EndOfStream)
                //{
                //    string[] tokens = sr.ReadLine().Split(',');
                //    handle.selectedVertices.Add(uint.Parse(tokens[3]));
                //}

                string[] xyz = sr.ReadLine().Split(','); //SKIPPING XYZ DATA
                var points = new Vector3[13];
                for (int i=0; i<13; ++i)
                {
                    points[i] = new Vector3(float.Parse(xyz[i*3]), float.Parse(xyz[i*3 + 1]), float.Parse(xyz[i*3 + 2]));
                }
                var points2 = new Vector3[12];
                points2[0] = points[0];
                points2[1] = points[1];
                for (int i = 2; i < 12; ++i)
                    points2[i] = points[i + 1];
                //string[] tokens = sr.ReadLine().Split(',');
                //for (int i = 0; i < tokens.Length - 1; ++i) //-1 for the last comma
                //    handle.selectedVertices.Add(uint.Parse(tokens[i]));

                sr.Close();

                return points2;
            }
            catch (Exception err)
            {
                sr.Close();
                //Common.Logger.Log("MainForm", "ReadWriteFile", "ReadSelectionFile", err.ToString(), true);
                return null;
            }
        }


        static void WriteExcelSelectionFile(string filename, Vector3[] points1, Vector3[] points2)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            var workbook = excelApp.Workbooks.Add();
            var worksheet = workbook.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet;

            for (int i = 0; i < points1.Length; i++)
            {
                //modified for convenience
                Vector3 p = points1[i];
                //worksheet.Cells[i + 1, 1] = p.X.ToString();
                //worksheet.Cells[i + 1, 2] = p.Y.ToString();
                //worksheet.Cells[i + 1, 3] = p.Z.ToString();
                worksheet.Cells[1, i*3+1] = p.X.ToString();
                worksheet.Cells[1, i*3+2] = p.Y.ToString();
                worksheet.Cells[1, i*3+3] = p.Z.ToString();
                
            }

            for (int i = 0; i < points2.Length; i++)
            {
                //modified for convenience
                Vector3 p = points2[i];
                //worksheet.Cells[i + 1, 4] = p.X.ToString();
                //worksheet.Cells[i + 1, 5] = p.Y.ToString();
                //worksheet.Cells[i + 1, 6] = p.Z.ToString();
                worksheet.Cells[1, 36+ i * 3 + 1] = p.X.ToString();
                worksheet.Cells[1, 36 + i * 3 + 2] = p.Y.ToString();
                worksheet.Cells[1, 36 + i * 3 + 3] = p.Z.ToString();
            }

            try
            {
                workbook.SaveAs(filename);
                workbook.Close();
            }
            catch (Exception err)
            {
                workbook.Close();
            }
        }

        static void Main(string[] args)
        {            
            Console.Write("Wights: ");
            foreach (float item in weights) { Console.Write(item + ", "); }

            
            var directories = Directory.GetDirectories(Directory.GetCurrentDirectory());
            for (int i = 0; i < directories.Length; i++)
            {
                var selFiles = Directory.GetFiles(directories[i], "*.sel");

                Console.WriteLine("Sel Files: ");
                Console.WriteLine(selFiles[0]);
                Console.WriteLine(selFiles[1]);
                var points1 = ReadSelectionFile(selFiles[0]);
                Console.WriteLine("sel file 1 read");
                var points2 = ReadSelectionFile(selFiles[1]);
                Console.WriteLine("sel file 2 read");
                float[,] rotationMat = new float[3, 3];
                float[] translationMat = new float[3];
                float error;
                CalculateSuperimpositionTransformation_Mathnet(points1, points2, out rotationMat, out translationMat, out error);
                points2 = TranslateRotate(points2, rotationMat, translationMat);
                Console.WriteLine("Superimposed with error " + error);
                WriteExcelSelectionFile(directories[i] + "\\ExcelSelectionSingleLine.xlsx", points1, points2);
            }

            Console.Read();
        }
    }
}
