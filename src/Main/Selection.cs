using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OpenTK;
//using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;


namespace OrthoAid
{
    public partial class MainForm
    {
        uint pointedVertexNumber = NO_VERTEX_INDEX;
        const uint NO_VERTEX_INDEX = uint.MaxValue;
        Vector3 SELECTCOLOR = new Vector3(.7f, 0.1f, 0.1f);
        Vector3 DISCRIMINATECOLOR = new Vector3(0, 0f, 1f);

        private int _SelectedCast = 0;
        public int SelectedCast
        {
            get { return _SelectedCast; }
            set
            {
                IndiscriminateSelectedVertex(GetSelectedVBO(), pointedVertexNumber);
                _SelectedCast = value;
                lbox_selectCast.SelectedIndex = value;
            }
        }

        private void ClearSelection(Common.Vbo handle)
        {
            for (int i = 0; i < handle.selectedVertices.Count; ++i)
            {
                UnmarkSelectedVertex(ref handle, handle.selectedVertices[i]);
            }
            handle.selectedVertices.Clear();

            UpdateUI();
        }

        private uint[] FindPointsOnSurface(Common.Vbo handle)
        {
            List<uint> pointsOnSurface_approx_index = new List<uint>();

            //mean point of selected points
            Vector3 meanP = new Vector3(0, 0, 0);
            Vector3[] select = new Vector3[handle.selectedVertices.Count];
            for (int i = 0; i < handle.selectedVertices.Count; i++)
            {
                select[i] = handle.verticesData.vertices[handle.selectedVertices[i]];
                meanP += select[i];
            }
            meanP /= handle.selectedVertices.Count;

            float[] distSelect2meanP = new float[select.Length];
            for (int i = 0; i < select.Length; i++)
            {
                distSelect2meanP[i] = (meanP - select[i]).LengthSquared;
            }

            //farthest slelected point distance to mean
            int generalFarSelectIndex = 0;
            for (int i = 1; i < select.Length; i++)
            {
                if (distSelect2meanP[i] > distSelect2meanP[generalFarSelectIndex])
                    generalFarSelectIndex = i;
            }

            //Common.Line3D[] lines3D = new Common.Line3D[Select.Length];
            //float[] distLine2meanP = new float[Select.Length];
            //for (int i = 0; i < Select.Length-1; i++)
            //{
            //    lines3D[i] = new Common.Line3D(Select[i], Select[i + 1]);
            //    distLine2meanP[i] = lines3D[i].Distance2PointSquared(meanP);
            //}
            //lines3D[Select.Length - 1] = new Common.Line3D(Select[Select.Length - 1], Select[0]);
            //distLine2meanP[Select.Length - 1] = lines3D[Select.Length - 1].Distance2PointSquared(meanP);

            for (uint i = 0; i < handle.verticesData.vertices.Length; i++)
            {
                //int nearSelectIndex = 0;
                //float dnear = (Select[0] - handle.verticesData.vertices[i]).LengthSquared;
                ////float dnear = lines[0].Distance2PointSquared(handle.verticesData.vertices[i]);
                //for (int s = 1; s < Select.Length; s++)
                //{
                //    float d = (Select[s] - handle.verticesData.vertices[i]).LengthSquared;
                //    //float d = lines[s].Distance2PointSquared(handle.verticesData.vertices[i]);
                //    if (d < dnear)
                //    {
                //        dnear = d;
                //        nearSelectIndex = s;
                //    }
                //}

                if ((meanP - handle.verticesData.vertices[i]).LengthSquared < distSelect2meanP[generalFarSelectIndex] + 100)
                    //if ((meanP - handle.verticesData.vertices[i]).LengthSquared < distLine2meanP[nearSelectIndex])
                    //if (Vector3.CalculateAngle(meanP - handle.verticesData.vertices[i],
                    //    Select[nearSelectIndex] - handle.verticesData.vertices[i]) > (float)Math.PI / 2)
                    pointsOnSurface_approx_index.Add(i);
            }

            //return pointsOnSurface_approx_index.ToArray();
            Vector3[] pointsOnSurface_approx_projected = new Vector3[pointsOnSurface_approx_index.Count];
            for (int i = 0; i < pointsOnSurface_approx_index.Count; i++)
            {
                pointsOnSurface_approx_projected[i] = Planes[0][OCCLUSALPLANE_INDEX].ProjectPointOnPlane
                    (handle.verticesData.vertices[pointsOnSurface_approx_index[i]]);
            }

            Vector3 rotationAxis_Horizontal;
            float rotationDegree;
            Planes[0][OCCLUSALPLANE_INDEX].RotationAxisAndDegreeToMakePlaneHorizontal(out rotationAxis_Horizontal, out rotationDegree);

            Vector3[] horizPoints = Common.Plane.RotatePointsAroundAxis(pointsOnSurface_approx_projected,
                rotationAxis_Horizontal, rotationDegree);

            Vector3[] selectProjected = Planes[0][OCCLUSALPLANE_INDEX].ProjectPointOnPlane(select);
            Vector3[] horizSelectPoints = Common.Plane.RotatePointsAroundAxis(selectProjected,
                rotationAxis_Horizontal, rotationDegree);


            Common.Segment2D[] lines = new Common.Segment2D[select.Length];
            for (int i = 0; i < select.Length - 1; i++)
            {
                lines[i] = new Common.Segment2D(horizSelectPoints[i].Xy, horizSelectPoints[i + 1].Xy);
            }
            lines[select.Length - 1] = new Common.Segment2D(horizSelectPoints[select.Length - 1].Xy, horizSelectPoints[0].Xy);

            bool[] insideSelectedArea = Common.Common.InsidePolygon2D(lines, horizPoints);
            List<uint> PointsOnSurface = new List<uint>();
            for (int i = 0; i < horizPoints.Length; i++)
            {
                if (insideSelectedArea[i])
                    PointsOnSurface.Add(pointsOnSurface_approx_index[i]);
            }

            return PointsOnSurface.ToArray();
        }

        private int GetSelectedVbOIndex()
        {
            if (SelectedCast == 0)
                return 1;
            else if (SelectedCast == 1)
                return 2;
            else
                return 0;
        }

        private Common.Vbo GetSelectedVBO()
        {
            switch (GetSelectedVbOIndex())
            {
                case 1:
                    return vbo1;
                case 2:
                    return vbo2;
                default:
                    return null;
            }
        }

        private void Select(ref Common.Vbo handle)
        {

            //GL.GetInteger(GetPName.Viewport, viewport);
            int heightDiff = 0;// this.Height - glControlCast.Height - 38;

            double[] modelview = new double[16];
            double[] projection = new double[16];

            //viewport[2] = 711;
            //viewport[3] = 600;
            GL.GetDouble(GetPName.ModelviewMatrix, modelview);
            GL.GetDouble(GetPName.ProjectionMatrix, projection);

            // obtain the Z position (not world coordinates but in range 0 - 1)
            float z_cursor = 0;
            GL.ReadPixels(MouseX, viewport[3] - MouseY - heightDiff, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.DepthComponent
                , PixelType.Float, ref z_cursor);

            // obtain the world coordinates
            double[] x, y, z;
            x = new double[1];
            y = new double[1];
            z = new double[1];
#pragma warning disable CS0618 // 'Glu' is obsolete: 'Use OpenTK math functions instead.'
            OpenTK.Graphics.Glu.UnProject((double)MouseX, viewport[3] - (double)MouseY - heightDiff, (double)z_cursor,
#pragma warning restore CS0618 // 'Glu' is obsolete: 'Use OpenTK math functions instead.'
                                            modelview, projection, viewport,
                                            x, y, z);

            //this.Text = x[0].ToString().Substring(0,5) + " : " + y[0].ToString().Substring(0,5) + " : " + z[0].ToString().Substring(0,5);
            //this.Text = MouseX + " : " + MouseY;
            uint vertexNumber = FindNearestVertex(ref handle, x[0], y[0], z[0]);
            //uint trueVertexNumber = FindNearestTrueVertex(x[0], y[0], z[0]);
            if (vertexNumber != NO_VERTEX_INDEX)
            {
                if (pointedVertexNumber != vertexNumber)
                {
                    if (pointedVertexNumber != NO_VERTEX_INDEX)
                        IndiscriminateSelectedVertex(handle, pointedVertexNumber);
                    DiscriminateSelectedVertex(ref handle, vertexNumber);
                    pointedVertexNumber = vertexNumber;
                }
            }
            else
            {
                if (pointedVertexNumber != NO_VERTEX_INDEX)
                {
                    IndiscriminateSelectedVertex(handle, pointedVertexNumber);
                }
                pointedVertexNumber = vertexNumber;
            }
        }

        private uint FindNearestVertex(ref Common.Vbo handle, double x, double y, double z)
        {
            double minDist = double.MaxValue;
            uint minIndex = NO_VERTEX_INDEX;
            Vector3 v = new Vector3((float)x, (float)y, (float)z);
            for (uint i = 0; i < handle.verticesData.vertices.Length; ++i)
            {
                float mag = (handle.verticesData.vertices[i] - v).Length;
                if (mag < minDist &&
                    mag < (handle.verticesStats.MaxX - handle.verticesStats.MinX) / 3)
                {
                    minDist = mag;
                    minIndex = i;
                }
            }


            return minIndex;
        }

        private bool VertexColorChange(ref Common.Vbo handle, uint vertexNumber, Vector3 color)
        {
            try
            {
                //Vector3 color = new Vector3(0.7f, 0, 0f);
                GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboColor);
                GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)((vertexNumber) * 12), (IntPtr)(BlittableValueType.StrideOf(color)),
                     ref color);
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                return true;
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "Selection", "VertexColorChange",
                    e.Message, true);
                return false;
            }


        }

        void MarkInsertedVertices(Common.Vbo handle)
        {
            for (int i = 0; i < handle.selectedVertices.Count; i++)
            {
                Vector3 color;
                if (i <= 12)
                    color = Common.Common.ColorRGB2Float(Common.Common.SelectColor[i]);
                else
                    color = SELECTCOLOR;

                if (!VertexColorChange(ref handle, handle.selectedVertices[i], color))
                    return;
            }

        }

        void MarkAndInsertSelectedVertex(Common.Vbo handle, uint vertexNumber)
        {
            //this.Text += "+ " + vertexNumber.ToString();    
            if (!handle.show)
                return;

            if (controlKeyDown || lockSelection)
            {
                if (!handle.selectedVertices.Contains(vertexNumber))
                {
                    if (vertexNumber != NO_VERTEX_INDEX)
                        handle.selectedVertices.Add(vertexNumber);
                }
                else
                {
                    handle.selectedVertices.Remove(vertexNumber);
                    UnmarkSelectedVertex(ref handle, vertexNumber);
                }
            }
            else
            {
                for (int i = 0; i < handle.selectedVertices.Count; ++i)
                {
                    UnmarkSelectedVertex(ref handle, handle.selectedVertices[i]);
                }
                handle.selectedVertices.Clear();

                if (vertexNumber != NO_VERTEX_INDEX)
                    handle.selectedVertices.Add(vertexNumber);
            }
        }

        void UnmarkSelectedVertex(ref Common.Vbo handle, uint vertexNumber)
        {
            Vector3 color;

            float d = (float)randColor.NextDouble() / 20;
            color = new Vector3(d, d, d) + handle.color;

            if (!VertexColorChange(ref handle, vertexNumber, color))
                return;
        }

        void DiscriminateSelectedVertex(ref Common.Vbo handle, uint vertexNumber)
        {


            if (!VertexColorChange(ref handle, vertexNumber, DISCRIMINATECOLOR))
                return;
        }

        void IndiscriminateSelectedVertex(Common.Vbo handle, uint vertexNumber)
        {
            Vector3 color;
            if (handle == null)
                return;
            if (handle.selectedVertices.Contains(vertexNumber))
            {
                int index = handle.selectedVertices.FindIndex(x => x == vertexNumber);
                if (index <= 12)
                    color = Common.Common.ColorRGB2Float(Common.Common.SelectColor[index]);
                else
                    color = SELECTCOLOR;
            }
            else
            {
                float d = (float)randColor.NextDouble() / 20;
                color = new Vector3(d, d, d);
                color = color + handle.color;
            }

            if (!VertexColorChange(ref handle, vertexNumber, color))
                return;
        }

        private void Rb_ReconstructedVertices_CheckedChanged(object sender, EventArgs e)
        {
            flags.verticesSelectionType = Common.VerticesSelectionType.vertices;
        }

        private void Rb_RealVertices_CheckedChanged(object sender, EventArgs e)
        {
            flags.verticesSelectionType = Common.VerticesSelectionType.trueVertices;
        }
    }
}
