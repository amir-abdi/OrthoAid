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
        private void DrawAll()
        {
            if (!openGLInitiated)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //DrawBackground();
            SetCamera();


            DrawCoords();

            //GL.Enable(EnableCap.Blend);
            if (vbo1.validVertices && vbo1.show)
            {
                Render(vbo1);
                MarkInsertedVertices(vbo1);
            }
            if (vbo2.validVertices && vbo2.show)
            {
                Render(vbo2);
                MarkInsertedVertices(vbo2);
            }

            if (reduceDensityVbo.validVertices && reduceDensityVbo.show)
                Render(reduceDensityVbo);
            //GL.Disable(EnableCap.Blend);

            Common.Vbo vbo = GetSelectedVBO();

            if (vbo != null && vbo.validMesh && vbo.show)
                if (config.editMode == Common.EditMode.Select || config.editMode == Common.EditMode.Ruler)
                    select(ref vbo);

            if (vbo1.validVertices && vbo1.show)
            {
                for (int i = 1; i < OCCLUSALPLANE_INDEX; ++i)
                    if (tcb[i].Checked && Planes[0][i] != null && Planes[0][i].valid)
                    {
                        //DrawPlane(Planes[0][i], Color.Pink);
                        //DrawProjectedPoints(Planes[0][i].projectedPointsOnAxisPlane, Color.Yellow);
                        DrawTangentLine(Planes[0][i].tangentPoints, Color.BlueViolet);
                    }

                for (int i = OCCLUSALPLANE_INDEX; i <= CURVEPLANE_INDEX; ++i)
                    if (tcb[Plane_CB1[i]].Checked && Planes[0][i] != null && Planes[0][i].valid)
                        DrawPlane(Planes[0][i], Color.Blue);
            }
            if (vbo2.validVertices && vbo2.show)
            {
                for (int i = 1; i < OCCLUSALPLANE_INDEX; ++i)
                    if (tcb[i].Checked && Planes[1][i]!=null && Planes[1][i].valid)
                    {
                        //DrawPlane(Planes[1][i], Color.Pink);
                        //DrawProjectedPoints(Planes[1][i].projectedPointsOnAxisPlane, Color.Yellow);
                        DrawTangentLine(Planes[1][i].tangentPoints, Color.YellowGreen);
                    }
                for (int i = OCCLUSALPLANE_INDEX; i <= CURVEPLANE_INDEX; ++i)
                    if (tcb[Plane_CB2[i]].Checked && Planes[1][i] != null && Planes[1][i].valid)
                        DrawPlane(Planes[1][i], Color.Yellow);
            }

            if (config.editMode == Common.EditMode.Ruler)
                DrawRulerLine(Color.BlueViolet);

            glControlCast.SwapBuffers();
        }

        void DrawBackground()
        {
            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.Red);
            GL.Vertex2(-1, -1);
            GL.Vertex2(-1, 1);
            GL.Vertex2(1, 1);
            GL.Vertex2(1, -1);
            GL.End();
            GL.Color3(Color.White);
        }

        private void DrawRulerLine(Color color)
        {
            if (Ruler_PointA != NO_VERTEX && Ruler_PointB != NO_VERTEX)
            {
                GL.Color3(color);
                GL.Enable(EnableCap.ProgramPointSize);
                GL.LineWidth(3);
                GL.Begin(BeginMode.Lines);

                GL.Vertex3(Ruler_PointA);
                GL.Vertex3(Ruler_PointB);

                GL.End();
                GL.LineWidth(1);

                GL.Color3(Color.White);
            }
        }

        private void Render(Common.Vbo handle)
        {
            try
            {
                //GL.BindTexture(TextureTarget.Texture2D, castTextureID);

                GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboVertices);
                GL.VertexPointer(3, VertexPointerType.Float, 0, new IntPtr(0));//BlittableValueType.StrideOf(vertices)

                if (flags.LightingEnable)
                    GL.Enable(EnableCap.Lighting);
                else
                    GL.Disable(EnableCap.Lighting);


                if (flags.RandomColorEnable)
                {
                    GL.EnableClientState(ArrayCap.ColorArray);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboColor);
                    GL.ColorPointer(3, ColorPointerType.Float, 0, new IntPtr(0));
                }
                else
                    GL.DisableClientState(ArrayCap.ColorArray);

                if (handle.validNormals)
                {

                    GL.EnableClientState(ArrayCap.NormalArray);
                    GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboNormals);
                    GL.NormalPointer(NormalPointerType.Float, 0, new IntPtr(0));

                }
                else
                    GL.DisableClientState(ArrayCap.NormalArray);

                //WireFrame
                if (handle.validWireframe && config.viewMode == Common.ViewMode.WireFrame)
                {
                    //GL.LineWidth(10);
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, handle.WireframeEID);
                    GL.DrawElements(BeginMode.Lines, handle.NumWireElements, DrawElementsType.UnsignedInt, IntPtr.Zero);
                }
                //Triangulation
                else if (handle.validMesh && config.viewMode == Common.ViewMode.Mesh)
                {
                    GL.BindBuffer(BufferTarget.ElementArrayBuffer, handle.TriEID);
                    GL.DrawElements(BeginMode.Triangles, handle.NumTriElements, DrawElementsType.UnsignedInt, IntPtr.Zero);

                    if (flags.showPoints_MeshMode)
                    {
                        if (flags.verticesSelectionType == Common.VerticesSelectionType.vertices)
                            GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboVertices);
                        //else if (flags.verticesSelectionType == Common.VerticesSelectionType.trueVertices)
                        //    GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboTrueVertices);

                        GL.VertexPointer(3, VertexPointerType.Float, 0, new IntPtr(0));

                        GL.DisableClientState(ArrayCap.ColorArray);
                        GL.Color3(Color.Green);
                        GL.PointSize(3);

                        if (flags.verticesSelectionType == Common.VerticesSelectionType.vertices)
                            GL.DrawArrays(BeginMode.Points, 0, handle.verticesData.vertices.Length);
                        //else if (flags.verticesSelectionType == Common.VerticesSelectionType.trueVertices)
                        //    GL.DrawArrays(BeginMode.Points, 0, trueVertices.Length);

                        GL.Color3(Color.White);

                    }
                }
                //Points
                else if (handle.validVertices && config.viewMode == Common.ViewMode.Points)
                {
                    //int a,b,c,d;
                    //GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferAccess, out a);
                    //GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferMapped, out b);
                    //GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out c);
                    //GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferUsage, out d);
                    GL.DrawArrays(BeginMode.Points, 0, handle.verticesData.vertices.Length);
                }


                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
                GL.BindTexture(TextureTarget.Texture2D, 0);
            }
            catch (Exception e)
            {
                Common.Logger.Log_GLError("MainForm", "Draw", "Render");
                Common.Logger.Log("MainForm", "Draw", "Render", e.Message, true);
            }
        }

        private void DrawTangentLine(Vector3[] list, Color color)
        {
            GL.Color3(color);
            GL.Enable(EnableCap.ProgramPointSize);                        
            GL.LineWidth(3);
            GL.Begin(BeginMode.Lines);            

            for (int i = 0; i < list.Length; i++)
            {
                GL.Vertex3(list[i]);
            }

            GL.End();
            GL.LineWidth(1);

            GL.Color3(Color.White);
        }

        private void DrawProjectedPoints(Vector3[] list, Color c)
        {
            GL.Color3(c);
            GL.Enable(EnableCap.ProgramPointSize);
            //GL.Enable(EnableCap.VertexProgramPointSize);
            GL.PointSize(2);
            GL.LineWidth(3);
            GL.Begin(BeginMode.Points);
            
            for (int i = 0; i < list.Length; i++)    
            {
                GL.Vertex3(list[i]);
            }
            
            GL.End();
            GL.LineWidth(1);
            GL.PointSize(1);

            GL.Color3(Color.White);
        }

        private void DrawPlane(Common.Plane p, Color c)
        {
            GL.Enable(EnableCap.Blend);
            //GL.BlendFunc(BlendingFactorSrc.OneMinusConstantColor, BlendingFactorDest.OneMinusConstantColor);                                    

            GL.Color3(c);
            GL.Disable(EnableCap.CullFace);
            GL.Begin(BeginMode.Polygon);
            for (int i = 0; i < p.pointsForDraw.Length; ++i)            
                GL.Vertex3(p.pointsForDraw[i]);            
            GL.End();
            GL.Enable(EnableCap.CullFace);

            GL.Color3(Color.White);

            GL.Disable(EnableCap.Blend);
        }

        private void DrawCoords()
        {
            float coordsArrowLength = 20;
            DrawLine_Origin2xyz(coordsArrowLength, 0, 0, Color.Red);
            DrawLine_Origin2xyz(0, coordsArrowLength, 0, Color.Green);
            DrawLine_Origin2xyz(0, 0, coordsArrowLength, Color.Blue);            
        }

        private void DrawLine_Origin2xyz(double x, double y, double z, Color c)
        {
            GL.Begin(BeginMode.Lines);
            GL.Color3(c);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(x, y, z);
            GL.End();

            GL.Color3(Color.White);
        }
    }
}
