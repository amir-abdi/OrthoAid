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


namespace OrthoAid_3DSimulator
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

            //Common.Line3D[] lines3D = new Common.Line3D[select.Length];
            //float[] distLine2meanP = new float[select.Length];
            //for (int i = 0; i < select.Length-1; i++)
            //{
            //    lines3D[i] = new Common.Line3D(select[i], select[i + 1]);
            //    distLine2meanP[i] = lines3D[i].Distance2PointSquared(meanP);
            //}
            //lines3D[select.Length - 1] = new Common.Line3D(select[select.Length - 1], select[0]);
            //distLine2meanP[select.Length - 1] = lines3D[select.Length - 1].Distance2PointSquared(meanP);
            
            for (uint i = 0; i < handle.verticesData.vertices.Length; i++)
            {
                //int nearSelectIndex = 0;
                //float dnear = (select[0] - handle.verticesData.vertices[i]).LengthSquared;
                ////float dnear = lines[0].Distance2PointSquared(handle.verticesData.vertices[i]);
                //for (int s = 1; s < select.Length; s++)
                //{
                //    float d = (select[s] - handle.verticesData.vertices[i]).LengthSquared;
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
                //    select[nearSelectIndex] - handle.verticesData.vertices[i]) > (float)Math.PI / 2)
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
            for (int i = 0; i < select.Length-1; i++)
            {
                lines[i] = new Common.Segment2D(horizSelectPoints[i].Xy, horizSelectPoints[i+1].Xy);
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

        private void select(ref Common.Vbo handle)
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
            OpenTK.Graphics.Glu.UnProject((double)MouseX, viewport[3] - (double)MouseY - heightDiff, (double)z_cursor,
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

        Predicate<uint> indexFinder2(int index)
        {
            return delegate(uint i)
            {
                return i == index;
            };
        }

        void IndiscriminateSelectedVertex(Common.Vbo handle, uint vertexNumber)
        {
            Vector3 color;
            if (handle == null)
                return;
            if (handle.selectedVertices.Contains(vertexNumber))
            {
                int index = handle.selectedVertices.FindIndex(x=> x == vertexNumber);
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

        private void rb_reconstructedVertices_CheckedChanged(object sender, EventArgs e)
        {
            flags.verticesSelectionType = Common.VerticesSelectionType.vertices;
        }

        private void rb_realVertices_CheckedChanged(object sender, EventArgs e)
        {
            flags.verticesSelectionType = Common.VerticesSelectionType.trueVertices;
        }

        #region selectObject
        uint[] selectBuffer;
        int selectBufferSize = 512;
        void startPicking()
        {


            //Selecting Mode
            GL.SelectBuffer(selectBufferSize, selectBuffer);
            GL.RenderMode(RenderingMode.Select);

            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();

            OpenTK.Graphics.Glu.PickMatrix(MouseX, viewport[3] - MouseY, 5, 5, viewport);
            OpenTK.Graphics.Glu.Perspective(45, 1, 0.1, 1000);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.InitNames();
        } //not used

        void stopPicking()
        {

            int hits;

            // restoring the original projection matrix
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.Flush(); //WHY?

            // returning to normal rendering mode
            hits = GL.RenderMode(RenderingMode.Render);

            // if there are hits process them
            if (hits != 0)
            {
                processHits(hits, selectBuffer);

            }
        } //not used

        private void processHits(int hits, uint[] selectBuffer)
        {
            for (int i = 0; i < hits; ++i)
            {

            }
        } //not used
        #endregion

        #region select vertex by color
        //uint backFrameBufferID, colorRenderBufferID, depthRenderBufferID, textureBufferID;        
        //struct Byte4
        //{
        //    public byte R, G, B, A;

        //    public Byte4(byte[] input)
        //    {
        //        R = input[0];
        //        G = input[1];
        //        B = input[2];
        //        A = input[3];
        //    }

        //    public uint ToUInt32()
        //    {
        //        byte[] temp = new byte[] { this.R, this.G, this.B, this.A };
        //        return BitConverter.ToUInt32(temp, 0);
        //    }

        //    public override string ToString()
        //    {
        //        return this.R + ", " + this.G + ", " + this.B + ", " + this.A;
        //    }
        //}

        //void initBackFrameBuffer()
        //{
        //    GL.GenFramebuffers(1, out backFrameBufferID);
        //    GL.GenRenderbuffers(1, out colorRenderBufferID);
        //    GL.GenRenderbuffers(1, out depthRenderBufferID);
        //    GL.GenTextures(1, out textureBufferID);

        //    GL.BindFramebuffer(FramebufferTarget.Framebuffer, backFrameBufferID);

        //    GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, colorRenderBufferID);
        //    //GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0,
        //    //    RenderbufferTarget.Renderbuffer, colorRenderBufferID);
        //    GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer, RenderbufferStorage.Rgba8, viewport[2], viewport[3]);

        //    //GL.BindRenderbuffer(RenderbufferTarget.Renderbuffer, depthRenderBufferID);
        //    ////GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment,
        //    ////    RenderbufferTarget.Renderbuffer, depthRenderBufferID);
        //    //GL.RenderbufferStorage(RenderbufferTarget.Renderbuffer, RenderbufferStorage.DepthComponent16, viewport[2], viewport[3]);

        //    //Bitmap bmp = new Bitmap(viewport[2], viewport[3]);
        //    //BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly,
        //    //    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //    //GL.BindTexture(TextureTarget.Texture2D, textureBufferID);
        //    //GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, viewport[2], viewport[3], 0,
        //    //    OpenTK.Graphics.OpenGL.PixelFormat.Rgba, PixelType.UnsignedByte, bmp_data.Scan0);
        //    //GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, textureBufferID, 0);
        //    //GL.BindTexture(TextureTarget.Texture2D, 0);

        //    GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        //}

        //struct Vertex
        //{
        //    public Byte4 Color; // 4 bytes
        //    public Vector3 Position; // 12 bytes

        //    public const byte SizeInBytes = 16;
        //}
        //Vertex[] VBO_Array;
        //uint VBO_Handle;

        //void selectVertex(Common.Vbo handle)
        //{
        //    //GL.BindFramebuffer(FramebufferTarget.Framebuffer, backFrameBufferID);

        //    //SetCamera();

        //    //GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0,
        //    //    RenderbufferTarget.Renderbuffer, colorRenderBufferID);
        //    ////GL.FramebufferRenderbuffer(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment,
        //    ////    RenderbufferTarget.Renderbuffer, depthRenderBufferID);
        //    ////GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.ColorAttachment0, textureBufferID, 0);

        //    ////DrawBuffersEnum[] bufs = new DrawBuffersEnum[] { DrawBuffersEnum.ColorAttachment0, DrawBuffersEnum.ColorAttachment1 };
        //    ////GL.DrawBuffers(2, bufs);

        //    //DrawBuffersEnum buf = DrawBuffersEnum.ColorAttachment0;
        //    //GL.DrawBuffers(1, ref buf);

        //    //GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboID);
        //    //GL.VertexPointer(3, VertexPointerType.Float, 0, new IntPtr(0));//BlittableValueType.StrideOf(vertices)

        //    //GL.EnableClientState(ArrayCap.ColorArray);
        //    //GL.Enable(EnableCap.ColorArray);
        //    //GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboColorSelectionID);
        //    //GL.ColorPointer(4, ColorPointerType.UnsignedByte, 0, new IntPtr(0));

        //    //GL.DrawArrays(BeginMode.Points, 0, vertices.Length);

        //    GL.Color3(Color.White);
        //    GL.Enable(EnableCap.ColorArray);
        //    GL.ClearColor(1f, 1f, 1f, 1f); // clears to uint.MaxValue
        //    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        //    SetCamera();

        //    GL.BindBuffer(BufferTarget.ArrayBuffer, VBO_Handle);
        //    GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, IntPtr.Zero);
        //    GL.DrawArrays(BeginMode.Points, 0, VBO_Array.Length);

        //    byte[] readData = new byte[16];
        //    GL.GetBufferSubData(BufferTarget.ArrayBuffer, (IntPtr)0, (IntPtr)16, readData);

        //    int selectW_H = 3;
        //    Byte4[] Pixels = new Byte4[selectW_H * selectW_H];
        //    //byte[] Pixels = new byte[selectW_H * selectW_H * 3];
        //    GL.ReadPixels(MouseX, viewport[3] - MouseY
        //        , selectW_H, selectW_H, OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
        //        PixelType.UnsignedByte, Pixels);

        //    this.Text = MouseX.ToString() + ":" + (viewport[3] - MouseY).ToString();

        //    uint selectedVertex = NO_VERTEX;
        //    for (int i = 0; i < Pixels.Length; ++i)
        //    {
        //        if (Pixels[i].A != 255)
        //        {
        //            Byte4 t = Pixels[i];
        //            //t.A = 0;
        //            selectedVertex = t.ToUInt32();
        //            break;
        //        }
        //    }

        //    if (selectedVertex != NO_VERTEX)
        //    {
        //        //markSelectedVertex(selectedVertex);
        //    }

        //    //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        //    //FramebufferErrorCode e = GL.CheckFramebufferStatus(FramebufferTarget.Framebuffer);
        //    //GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

        //}

        #endregion

    }
}
