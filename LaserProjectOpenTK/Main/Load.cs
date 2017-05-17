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
using System.Threading;
using OrthoAid_3DSimulator.Common;

namespace OrthoAid_3DSimulator
{
    public partial class MainForm
    {        
        Common.Vbo reduceDensityVbo;
        Common.Vbo vbo2;
        Common.Vbo vbo1;
        Common.Flags flags;                
        Random randColor;
        bool openGLInitiated = false;
        const float SPUR_DISTANCE_THREASHOLD = 40;

        private void GLControlCast_Load(object sender, EventArgs e)
        {

            InitVBO(ref vbo1, "vbo1");
            InitVBO(ref vbo2, "vbo2");
            InitVBO(ref reduceDensityVbo, "reduceDensityVbo");

            randColor = new Random();

            InitOpenGL();
        }

        private void InitVBO(ref Common.Vbo handle, string name)
        {
            handle = new Vbo()
            {
                vboName = name
            };
        }

        private void InitOpenGL()
        {
            flags.LightingEnable = true;
            flags.RandomColorEnable = true;
            flags.TextureEnable = false;
            flags.showPoints_MeshMode = false;

            SetViewPort();

            OpenTK.Graphics.GraphicsContext.CurrentContext.VSync = true;
            //string version = GL.GetString(StringName.Version);
            //int major = (int)version[0];
            //int minor = (int)version[2];
            //used for version check and support of older versions...
            //Application.Idle += Application_Idle;

            GL.ClearColor(Color.Black);//Color.DarkSlateBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace); //when enabled, objects are not 2 sided!
            GL.DepthFunc(DepthFunction.Less);
            
            GL.Enable(EnableCap.Normalize);
            GL.ShadeModel(ShadingModel.Smooth);

            //failed to make it look better (all these values had no effect!)
            //GL.Enable(EnableCap.PolygonSmooth);
            //GL.Enable(EnableCap.PointSmooth);
            //GL.Enable(EnableCap.LineSmooth);                       
            //GL.Enable(EnableCap.PointSprite);
            //GL.Enable(EnableCap.LineStipple);
            //GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);
            //GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
            //GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);            

            
            GL.BlendFunc((BlendingFactorSrc)768, BlendingFactorDest.OneMinusDstColor);  

            InitLighting();

            eyeOffset = new Vector3(0, 0, 150);
            targetOffset = new Vector3()
            {
                Z = 0
            };            

            //CreateShaders(ResourceShader.VertexShader, ResourceShader.FragmentShader);

            //InitTexture();

            //if (flags.RandomColorEnable == true)
            //    GL.EnableClientState(ArrayCap.ColorArray);
            GL.EnableClientState(ArrayCap.VertexArray);


            //Select            
            //selectBuffer = new uint[selectBufferSize];
            //initBackFrameBuffer();


            openGLInitiated = true;
            Common.Logger.Log_GLError("MainForm", "OpenGL", "GLControlCast_Load");
        }

        private void InitVerticesStats(ref Common.Vbo handle)
        {
            if (handle.validVertices)
            {
                handle.verticesStats.numVertices = handle.verticesData.vertices.Length;
                if (handle.vboName == "vbo1")
                    handle.verticesStats.name = config.lastLoadedMeshName1;
                else if (handle.vboName == "vbo2")
                    handle.verticesStats.name = config.lastLoadedMeshName2;

                Vector3 meanPoint;
                meanPoint = Vector3.Zero;

                handle.verticesStats.MaxX = int.MinValue;
                handle.verticesStats.MinX = int.MaxValue;
                handle.verticesStats.MaxY = int.MinValue;
                handle.verticesStats.MinY = int.MaxValue;
                handle.verticesStats.MaxZ = int.MinValue;
                handle.verticesStats.MinZ = int.MaxValue;

                for (int i = 0; i < handle.verticesData.vertices.Length; ++i)
                {
                    meanPoint = Vector3.Add(meanPoint, handle.verticesData.vertices[i]);
                    if (handle.verticesData.vertices[i].X > handle.verticesStats.MaxX)
                        handle.verticesStats.MaxX = handle.verticesData.vertices[i].X;
                    if (handle.verticesData.vertices[i].X < handle.verticesStats.MinX)
                        handle.verticesStats.MinX = handle.verticesData.vertices[i].X;
                    if (handle.verticesData.vertices[i].Y > handle.verticesStats.MaxY)
                        handle.verticesStats.MaxY = handle.verticesData.vertices[i].Y;
                    if (handle.verticesData.vertices[i].Y < handle.verticesStats.MinY)
                        handle.verticesStats.MinY = handle.verticesData.vertices[i].Y;
                    if (handle.verticesData.vertices[i].Z > handle.verticesStats.MaxZ)
                        handle.verticesStats.MaxZ = handle.verticesData.vertices[i].Z;
                    if (handle.verticesData.vertices[i].Z < handle.verticesStats.MinZ)
                        handle.verticesStats.MinZ = handle.verticesData.vertices[i].Z;
                }
                handle.verticesStats.Mean = Vector3.Divide(meanPoint, handle.verticesData.vertices.Length);

                if (handle.validMesh)
                {
                    handle.verticesStats.numFaces = handle.verticesData.indices.Length / 3;
                    float dist = 0;
                    for (int i = 0; i < handle.verticesData.indices.Length; i += 3)
                    {
                        dist += (handle.verticesData.vertices[handle.verticesData.indices[i]] -
                            handle.verticesData.vertices[handle.verticesData.indices[i + 1]]).Length;
                        dist += (handle.verticesData.vertices[handle.verticesData.indices[i + 1]] -
                            handle.verticesData.vertices[handle.verticesData.indices[i + 2]]).Length;
                        dist += (handle.verticesData.vertices[handle.verticesData.indices[i + 2]] -
                            handle.verticesData.vertices[handle.verticesData.indices[i]]).Length;
                    }
                    handle.verticesStats.averageVertexDistance = (dist / handle.verticesData.indices.Length);
                }
                else
                {
                    handle.verticesStats.numFaces = 0;
                    handle.verticesStats.averageVertexDistance = 0;
                }
            }
            else
            {
                handle.verticesStats.numVertices = 0;
                handle.verticesStats.name = "No Mesh Loaded";

                handle.verticesStats.MaxX = 0;
                handle.verticesStats.MinX = 0;
                handle.verticesStats.MaxY = 0;
                handle.verticesStats.MinY = 0;
                handle.verticesStats.MaxZ = 0;
                handle.verticesStats.MinZ = 0;

                handle.verticesStats.Mean = new Vector3(0,0,0);
            }


            
        }

        bool ReLoadBuffer<T>(BufferTarget bufferTarget, int ID, T[] data) where T : struct
        {
            try
            {
                int size;
                
                GL.BindBuffer(bufferTarget, ID);
                GL.BufferData(bufferTarget, (IntPtr)(data.Length * BlittableValueType.StrideOf(data)), data,
                              BufferUsageHint.StaticDraw);
                GL.GetBufferParameter(bufferTarget, BufferParameterName.BufferSize, out size);
                if (data.Length * BlittableValueType.StrideOf(data) != size)
                    throw new ApplicationException("Data not uploaded correctly");
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                return true;
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "Load", "LoadBuffer", e.Message, true);
                return false;
            }

        }

        bool LoadBuffer<T>(BufferTarget bufferTarget, ref int ID, T[] data) where T : struct
        {
            try
            {
                int size;

                GL.GenBuffers(1, out ID);
                GL.BindBuffer(bufferTarget, ID);
                GL.BufferData(bufferTarget, (IntPtr)(data.Length * BlittableValueType.StrideOf(data)), data,
                              BufferUsageHint.StaticDraw);

                GL.GetBufferParameter(bufferTarget, BufferParameterName.BufferSize, out size);
                if (data.Length * BlittableValueType.StrideOf(data) != size)
                    throw new ApplicationException("Data not uploaded correctly");
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                return true;
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "Load", "LoadBuffer", e.Message, true);
                return false;
            }
            

        }

        void LoadVertices_Normals(ref Common.Vbo handle, Vector3[] vertices, Vector3[] normals)
        {
            try
            {
                if (LoadBuffer<Vector3>(BufferTarget.ArrayBuffer, ref handle.VboVertices, vertices))
                    handle.validVertices = true;
                else
                    throw new ApplicationException("Vertex data not uploaded correctly");

                flags.verticesSelectionType = Common.VerticesSelectionType.vertices;

                if (normals != null && normals.Length > 0)
                {
                    if (LoadBuffer<Vector3>(BufferTarget.ArrayBuffer, ref handle.VboNormals, normals))
                        handle.validNormals = true;
                }
                else
                    GL.GenBuffers(1, out handle.VboNormals);

                SetColor(ref handle);
                
                if (flags.RandomColorEnable)
                {
                    Vector3[] colors = new Vector3[vertices.Length];
                    for (int i = 0; i < colors.Length; i++)
                    {
                        float d = (float)randColor.NextDouble() / 20;
                        colors[i] = new Vector3(d, d, d) + handle.color;
                    }

                    if (LoadBuffer<Vector3>(BufferTarget.ArrayBuffer, ref handle.VboColor, colors))
                        handle.validColor = true;
                }


                handle.verticesData.vertices = vertices;
                handle.verticesData.normals = normals;

                Common.Logger.Log("MainForm", "Load", "LoadVertices_Normals", "Vertices and Normals loaded", false);
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "Load", "LoadVertices_Normals", e.Message, true);
            }
            config.viewMode = Common.ViewMode.Points;
            UpdateUI();
        }

        private void SetColor(ref Vbo handle)
        {
            //Color            
            float rcolor = 0;
            float gcolor = 0;
            float bcolor = 0;
            if (handle.vboName == "vbo1")
            {
                rcolor = 80.0f / 255f;
                gcolor = 100.0f / 255f;
                bcolor = 150.0f / 255f;
            }
            else if (handle.vboName == "vbo2")
            {
                rcolor = 255f / 255f;
                gcolor = 200f / 255f;
                bcolor = 74f / 255f;
            }
            //handle.color = new Vector3(rcolor, gcolor, bcolor);
            Color c = Color.Bisque;
            handle.color = new Vector3((float) c.R/255f, (float) c.G / 255f, (float) c.B / 255f);
            ;
        }

        void LoadIndices(ref Common.Vbo handle, UInt32[] indices)
        {
            try
            {

                //Index of Triangulation
                if (LoadBuffer<uint>(BufferTarget.ElementArrayBuffer, ref handle.TriEID, indices))
                {
                    handle.validMesh = true;
                    handle.NumTriElements = indices.Length;
                }

                //Index of WireFrame            
                uint[] wire = new uint[indices.Length * 2];
                int count = 0;
                for (int i = 0; i < indices.Length; i += 3)
                {
                    wire[count++] = indices[i];
                    wire[count++] = indices[i + 1];
                    wire[count++] = indices[i + 1];
                    wire[count++] = indices[i + 2];
                    wire[count++] = indices[i + 2];
                    wire[count++] = indices[i];
                }

                if (LoadBuffer<uint>(BufferTarget.ElementArrayBuffer, ref handle.WireframeEID, wire))
                {
                    handle.validWireframe = true;
                    handle.NumWireElements = wire.Length;
                }

                handle.verticesData.indices = indices;

                Common.Logger.Log("MainForm", "Load", "LoadIndices", "indices loaded.", false);
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "Load", "LoadIndices", e.Message, true);
            }
                
            config.viewMode = Common.ViewMode.Mesh;            
            UpdateUI();
        }

        private void UnBindOpenGL()
        {                        
            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.CullFace);
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.Disable(EnableCap.PointSmooth);            
        }

        private void UnBindLighting()
        {
            GL.Disable(EnableCap.Lighting);
            GL.Disable(EnableCap.Light0);
            GL.Disable(EnableCap.ColorMaterial);
            GL.Disable(EnableCap.Light1);
        }

        void DeleteVBO(ref Common.Vbo handle)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindTexture(TextureTarget.Texture2D, 0);

            if (handle.validVertices)
            {
                GL.DeleteBuffers(1, ref handle.VboVertices);
                GL.DeleteBuffers(1, ref handle.VboNormals);
                GL.DeleteBuffers(1, ref handle.VboColor);
                handle.VboColor = 0;
                handle.VboNormals = 0;
                handle.VboVertices = 0;

                handle.validVertices = false;
                handle.validNormals = false;
                handle.validColor = false;

                handle.NumTriElements = 0;
                handle.NumWireElements = 0;
            }

            if (handle.validMesh)
            {
                GL.DeleteBuffers(1, ref handle.TriEID);
                GL.DeleteBuffers(1, ref handle.WireframeEID);
                handle.TriEID = 0;
                handle.WireframeEID = 0;

                handle.validMesh = false;
                handle.validWireframe = false;
                
            }
        }

        void ClearArrays(ref Common.VerticesData verticesData)
        {
            verticesData.vertices = null;
            verticesData.indices = null;
            verticesData.normals = null;  
          
        }

        private void LoadPointCloud(string FileName, Common.Vbo handle)
        {
            Reset(ref handle);

            Vector3[] vertices;
            Vector3[] normals;
            //ReadXYZNInputFile(FileName, out vertices, out normals);
            ReadPointCloudInputFile(FileName, out vertices, out normals);
            LoadVertices_Normals(ref handle, vertices, normals);
            UpdateFileRelatedConfiguration(ref handle, FileName, "point cloud");
            handle.show = true;

            InitVerticesStats(ref handle);
            b_previewReduceDensity.Enabled = true;

            CentralizeCast(GetSelectedVBO());
        }

        private void LoadMesh(string FileName, Common.Vbo handle)
        {
            Reset(ref handle);

            Vector3[] vertices;
            Vector3[] normals;
            UInt32[] indices;

            ReadMeshInputFile(FileName, out vertices, out normals, out indices); //@"tri\inputBigMeshLabGUIBallPivoting_1.tri"); 
            LoadVertices_Normals(ref handle, vertices, normals);
            LoadIndices(ref handle, indices);
            UpdateFileRelatedConfiguration(ref handle, FileName, "mesh");

            handle.show = true;
            InitVerticesStats(ref handle);
            b_previewReduceDensity.Enabled = true;

            CentralizeCast(GetSelectedVBO());
        }

        private void Reset(ref Common.Vbo handle)
        {
            Application.Idle -= Application_Idle;

            Thread.Sleep(100);
            //UnBindOpenGL();
            DeleteVBO(ref handle);
            ClearArrays(ref handle.verticesData);
            handle.selectedVertices.Clear();
            if (!vbo1.validVertices && !vbo2.validVertices)
                InitOpenGL();
            Application.Idle += Application_Idle;

            InitVerticesStats(ref handle);
            //InitTeethBoxes();

            if (handle.vboName == "vbo1")
            {
                config.lastLoadedMeshFileAddress1 = "empty";
                config.lastLoadedMeshName1 = "No Mesh loaded";
                config.lastLoadedMeshType1 = "empty";
            }
            else if (handle.vboName == "vbo2")
            {
                config.lastLoadedMeshFileAddress2 = "empty";
                config.lastLoadedMeshName2 = "No Mesh loaded";
                config.lastLoadedMeshType2 = "empty";
            }

            ClearSelection(handle);
            UpdateUI();
        }

        #region oldLoadVBO
        /*
        Common.Vbo LoadVBO()
        {
            Common.Vbo handle = new Common.Vbo();
            int size;

            //Vertices
            LoadBuffer<Vector3>(BufferTarget.ArrayBuffer, ref handle.VboVertices, vertices);
            flags.verticesSelectionType = Common.VerticesSelectionType.vertices;

            //True Vertices
            //LoadBuffer<Vector3>(BufferTarget.ArrayBuffer, ref handle.VboTrueVertices, trueVertices);

            #region Selection VBO
            ////VBO test
            //VBO_Array = new Vertex[vertices.Length];
            //int TriangleCounter = -1;
            //for (int i = 0; i < vertices.Length; i++)
            //{
            //    // Position
            //    VBO_Array[i].Position = vertices[i];

            //    // Index

            //    TriangleCounter++;
            //    VBO_Array[i].Color = new Byte4(BitConverter.GetBytes(TriangleCounter));
            //}
            //GL.GenBuffers(1, out VBO_Handle);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, VBO_Handle);
            //GL.BufferData<Vertex>(BufferTarget.ArrayBuffer, (IntPtr)(VBO_Array.Length * Vertex.SizeInBytes), VBO_Array, BufferUsageHint.StaticDraw);
            //GL.InterleavedArrays(InterleavedArrayFormat.C4ubV3f, 0, IntPtr.Zero);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            ////VBO Copy for selection
            //GL.GenBuffers(1, out handle.VboSelectID);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboSelectID);
            //GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * BlittableValueType.StrideOf(vertices)), vertices,
            //              BufferUsageHint.StaticDraw);
            //GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out size);
            //if (vertices.Length * BlittableValueType.StrideOf(vertices) != size)
            //    throw new ApplicationException("Vertex data not uploaded correctly");
            //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            ////Color for selection
            //Byte4[] colorSelection = new Byte4[vertices.Length];
            //for (uint i = 0; i < vertices.Length; i++)
            //{                
            //    Byte4 b = new Byte4(BitConverter.GetBytes(i));
            //    b.A = 100;
            //    colorSelection[i] = b;
            //}

            //uint t = colorSelection[3].ToUInt32();

            //GL.GenBuffers(1, out handle.VboColorSelectionID);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboColorSelectionID);
            //GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(colorSelection.Length * BlittableValueType.StrideOf(colorSelection)), colorSelection,
            //              BufferUsageHint.StaticDraw);
            //GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out size);
            //if (colorSelection.Length * BlittableValueType.StrideOf(colorSelection) != size)
            //    throw new ApplicationException("Vertex data not uploaded correctly");


            //byte[] readData = new byte[16];
            //GL.GetBufferSubData(BufferTarget.ArrayBuffer, (IntPtr)0, (IntPtr)16, readData);

            //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            #endregion

            //Color
            if (flags.RandomColorEnable)
            {
                Vector3[] colors = new Vector3[vertices.Length];
                for (int i = 0; i < colors.Length; i++)
                {
                    float d = (float)randColor.NextDouble() / 20 + 0.6f;
                    colors[i] = new Vector3(d, d, d);
                }

                LoadBuffer<Vector3>(BufferTarget.ArrayBuffer, ref handle.VboColor, colors);
            }

            #region Texture
            ////Texture
            //if (flags.TextureEnable)
            //{
            //    Random rand = new Random();
            //    Vector2[] textures = new Vector2[vertices.Length];
            //    for (int i = 0; i < textures.Length; i++)
            //    {
            //        textures[i] = new Vector2((float)rand.NextDouble(), (float)rand.NextDouble());
            //    }
            //    GL.GenBuffers(1, out handle.VboTextureCoordID);
            //    GL.BindBuffer(BufferTarget.ArrayBuffer, handle.VboTextureCoordID);
            //    GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(textures.Length * BlittableValueType.StrideOf(textures)), textures,
            //                  BufferUsageHint.StaticDraw);
            //    GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out size);
            //    if (textures.Length * BlittableValueType.StrideOf(textures) != size)
            //        throw new ApplicationException("Vertex data not uploaded correctly");
            //    GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //}
            #endregion

            //Index of Triangulation
            LoadBuffer<uint>(BufferTarget.ElementArrayBuffer, ref handle.TriEID, indices);
            handle.NumTriElements = indices.Length;

            //Index of WireFrame            
            uint[] wire = new uint[indices.Length * 2];
            int count = 0;
            for (int i = 0; i < indices.Length; i += 3)
            {
                wire[count++] = indices[i];
                wire[count++] = indices[i + 1];
                wire[count++] = indices[i + 1];
                wire[count++] = indices[i + 2];
                wire[count++] = indices[i + 2];
                wire[count++] = indices[i];
            }

            LoadBuffer<uint>(BufferTarget.ElementArrayBuffer, ref handle.WireframeEID, wire);
            handle.NumWireElements = wire.Length;

            if (flags.NormalAvailable)
                LoadBuffer<Vector3>(BufferTarget.ArrayBuffer, ref handle.VboNormals, normals);

            handle.validMesh = true;
            return handle;
        }
         */
        #endregion
    }
}