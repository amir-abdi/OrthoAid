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
using MathNet.Numerics.LinearAlgebra;


namespace OrthoAid_3DSimulator
{
    public partial class MainForm
    {
        private void TranslateRotate(Common.Vbo handle, float rx, float ry, float rz, float tx, float ty, float tz)
        {
            Matrix4 rotMatx = Matrix4.CreateRotationX(rx);
            Matrix4 rotMaty = Matrix4.CreateRotationY(ry);
            Matrix4 rotMatz = Matrix4.CreateRotationZ(rz);
            Vector3 transMat = new Vector3(tx, ty, tz);


            Vector3[] newPoints = new Vector3[handle.verticesData.vertices.Length];
            Vector3[] newNormals = new Vector3[handle.verticesData.normals.Length];
            for (int i = 0; i < newPoints.Length; i++)
            {
                Matrix4 t = new Matrix4(new Vector4(handle.verticesData.vertices[i]),
                    new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
                t = Matrix4.Mult(t, rotMatx);
                t = Matrix4.Mult(t, rotMaty);
                t = Matrix4.Mult(t, rotMatz);
                newPoints[i] = t.Row0.Xyz + transMat;

                t = new Matrix4(new Vector4(handle.verticesData.normals[i]),
                    new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
                t = Matrix4.Mult(t, rotMatx);
                t = Matrix4.Mult(t, rotMaty);
                t = Matrix4.Mult(t, rotMatz);
                //t = Matrix4.Mult(t, transMat);
                newNormals[i] = t.Row0.Xyz;

            }

            handle.verticesData.vertices = newPoints;
            handle.verticesData.normals = newNormals;


            ReLoadBuffer(BufferTarget.ArrayBuffer, handle.VboVertices, handle.verticesData.vertices);
            ReLoadBuffer(BufferTarget.ArrayBuffer, handle.VboNormals, handle.verticesData.normals);

        }

        private void TranslateRotate(Common.Vbo handle, float[,] rotationMat, float[] transformation)
        {
            Vector4[] rotv = new Vector4[4];
            for (int i = 0; i < 3; i++)
            {
                rotv[i] = new Vector4(rotationMat[i, 0], rotationMat[i, 1], rotationMat[i, 2], 0);
            }
            rotv[3] = new Vector4(0, 0, 0, 0);
            Matrix4 rotm = new Matrix4(rotv[0], rotv[1], rotv[2], rotv[3]);
            Vector3 transv = new Vector3(transformation[0], transformation[1], transformation[2]);

            Vector3[] newPoints = new Vector3[handle.verticesData.vertices.Length];
            Vector3[] newNormals = new Vector3[handle.verticesData.normals.Length];
            for (int i = 0; i < newPoints.Length; i++)
            {
                Matrix4 t = new Matrix4(new Vector4(handle.verticesData.vertices[i]),
                    new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
                t = Matrix4.Mult(t, rotm);
                
                newPoints[i] = t.Row0.Xyz + transv;

                t = new Matrix4(new Vector4(handle.verticesData.normals[i]),
                    new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0), new Vector4(0, 0, 0, 0));
                t = Matrix4.Mult(t, rotm);                
                newNormals[i] = t.Row0.Xyz;

            }

            handle.verticesData.vertices = newPoints;
            handle.verticesData.normals = newNormals;


            ReLoadBuffer(BufferTarget.ArrayBuffer, handle.VboVertices, handle.verticesData.vertices);
            ReLoadBuffer(BufferTarget.ArrayBuffer, handle.VboNormals, handle.verticesData.normals);

        }

        private void Superimpose()
        {
            Vector3[] select1 = new Vector3[vbo1.selectedVertices.Count];
            Vector3[] select2 = new Vector3[vbo2.selectedVertices.Count];
            for (int i = 0; i < vbo1.selectedVertices.Count; i++)
            {
                select1[i] = vbo1.verticesData.vertices[vbo1.selectedVertices[i]];
                select2[i] = vbo2.verticesData.vertices[vbo2.selectedVertices[i]];
            }

            //casts has to be fit manualy uppon each other before superimposition
            //select2 = RearrangeSelectedPointsToMatchPairs(select1, select2);
            if (select2 == null)
                return;

            float[,] rotationMat;
            float[] translationMat; 
            float error;
            CalculateSuperimpositionTransformation_Mathnet(select1, select2, out rotationMat, out translationMat, out error);
            TranslateRotate(vbo2, rotationMat, translationMat);

            status.Text = "Superimposition complete with (Error = " + error.ToString() + ")";
            UpdateUI();
        }

        private void CalculateSuperimpositionTransformation_Mathnet(Vector3[] select1, Vector3[] select2,
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

                if (i <= 11)
                    weightArray[i] = config.weights[i];
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

        private Vector3[] RearrangeSelectedPointsToMatchPairs(Vector3[] select1, Vector3[] select2)
        {
            Vector3[] newSelect2 = new Vector3[select2.Length];
            int[] newSelect2Index = new int[select2.Length];
            for (int i = 0; i < select2.Length; i++)
            {
                int npi = 0;
                float np = (select1[0] - select2[i]).LengthSquared;
                for (int j = 1; j < select1.Length; j++)
                {
                    if ((select1[j] - select2[i]).LengthSquared < np)
                    {
                        np = (select1[j] - select2[i]).LengthSquared;
                        npi = j;
                    }
                }
                newSelect2Index[i] = npi;
            }

            //check for error in finding nearest point
            for (int i = 0; i < newSelect2Index.Length - 1; i++)
            {
                for (int j = i + 1; j < newSelect2Index.Length; j++)
                {
                    if (newSelect2Index[i] == newSelect2Index[j])
                    {
                        MessageBox.Show("Couldn't pair up the selected points. Make sure you have pre-adjusted the casts appropriately and then Select again."
                            , "Superimposistion Error");
                        return null;                        
                    }
                }
            }

            for (int i = 0; i < newSelect2Index.Length; i++)
            {
                newSelect2[newSelect2Index[i]] = select2[i];
            }
            return newSelect2;
        }


    }
}
