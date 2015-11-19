using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;


namespace OrthoAid_3DSimulator
{
    public partial class MainForm : Form
    {        
        static public void DirectoryCheck(string dir)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        private void AutoLoadFiles()
        {
            if (config.lastLoadedMeshFileAddress1 != "empty" && File.Exists(config.lastLoadedMeshFileAddress1))
            {
                switch (config.lastLoadedMeshType1)
                {
                    case "point cloud":
                        LoadPointCloud(config.lastLoadedMeshFileAddress1, vbo1);
                        break;
                    case "mesh":
                        LoadMesh(config.lastLoadedMeshFileAddress1, vbo1);
                        
                        string selectionFileAddress = Directory.GetCurrentDirectory() + "\\Selection\\" 
                            + Path.GetFileNameWithoutExtension(config.lastLoadedMeshFileAddress1) + ".sel";
                        string selectionFileAddressMain = Directory.GetParent(config.lastLoadedMeshFileAddress1).FullName +
                            "\\" + Path.GetFileNameWithoutExtension(config.lastLoadedMeshFileAddress1) + ".sel";
                        
                        if (File.Exists(selectionFileAddressMain))                            
                            ReadSelectionFile(selectionFileAddressMain, vbo1);
                        else if (File.Exists(selectionFileAddress))
                        {
                            ReadSelectionFile(selectionFileAddress, vbo1);
                        }
                        //string calculationFileAddress = Directory.GetCurrentDirectory() + "\\Calculation"
                        //    + Path.GetFileNameWithoutExtension(config.lastLoadedMeshFileAddress1) + ".cal";
                        //if (File.Exists(calculationFileAddress))
                        //    ReadCalculationResults_Cal(calculationFileAddress);
                        break;
                }
            }
            else
            {
                config.lastLoadedMeshFileAddress1 = "empty";
                config.lastLoadedMeshName1 = "No Mesh loaded";
                config.lastLoadedMeshType1 = "empty";
            }


            if (config.lastLoadedMeshFileAddress2 != "empty" && File.Exists(config.lastLoadedMeshFileAddress2))
            {
                switch (config.lastLoadedMeshType2)
                {
                    case "point cloud":
                        LoadPointCloud(config.lastLoadedMeshFileAddress2, vbo2);
                        break;
                    case "mesh":
                        LoadMesh(config.lastLoadedMeshFileAddress2, vbo2);

                        string selectionFileAddress = Directory.GetCurrentDirectory() + "\\Selection\\" 
                            + Path.GetFileNameWithoutExtension(config.lastLoadedMeshFileAddress2) + ".sel";
                        string selectionFileAddressMain = Directory.GetParent(config.lastLoadedMeshFileAddress2).FullName +
                            "\\" + Path.GetFileNameWithoutExtension(config.lastLoadedMeshFileAddress2) + ".sel";
                        
                        if (File.Exists(selectionFileAddressMain))                            
                            ReadSelectionFile(selectionFileAddressMain, vbo2);
                        else if (File.Exists(selectionFileAddress))
                        {
                            ReadSelectionFile(selectionFileAddress, vbo2);
                        }
                        break;
                }
            }
            else
            {
                config.lastLoadedMeshFileAddress2 = "empty";
                config.lastLoadedMeshName2 = "No Mesh loaded";
                config.lastLoadedMeshType2 = "empty";
            }
        }        

        private void ReadPointCloudInputFile(string FileName, out Vector3[] vertices, out Vector3[] normals)
        {
            StreamReader tr = new StreamReader(FileName);
            try
            {
                if ((char)tr.Peek() == 'p')
                {
                    //Vector3[] v;
                    //Vector3[] n;
                    uint[] i;
                    string header = tr.ReadLine();
                    tr.BaseStream.Position = header.Length + 1;
                    ReadPlyInputFile(tr, out vertices, out normals, out i); //we throw i away!!!
                }
                else
                {
                    ReadXYZNInputFile(tr, out vertices, out normals);
                }

                tr.Close();
            }
            catch (Exception err)
            {
                tr.Close();
                throw err;
            }
        }

        void ReadXYZNInputFile(StreamReader tr, out Vector3[] vertices, out Vector3[] normals)
        {
            //input file:
            //x y z [nx ny nz]
            //x y z [nx ny nz]
            //...
            
            //if (String.IsNullOrEmpty(xyznFileAddress))
            //    throw new ArgumentException(xyznFileAddress);          
            
            //TextReader tr = new StreamReader(File.OpenRead(xyznFileAddress));
            List<Vector3> verticesL = new List<Vector3>();
            List<Vector3>  normalsL = new List<Vector3>();
            while (tr.Peek() != -1)
            {
                string line = tr.ReadLine();
                string[] xyz = line.Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                OpenTK.Vector3 v;
                v.X = float.Parse(xyz[0]);
                v.Y = float.Parse(xyz[1]);
                v.Z = float.Parse(xyz[2]);
                verticesL.Add(v);

                if (xyz.Length > 3)
                {
                    Vector3 n;
                    n.X = float.Parse(xyz[3]);
                    n.Y = float.Parse(xyz[4]);
                    n.Z = float.Parse(xyz[5]);
                    normalsL.Add(n);                    
                }
            }            

            //if (normals.Count>0)
            //    flags.NormalAvailable = true;
            //else
            //    flags.NormalAvailable = false;

            vertices = verticesL.ToArray();
            if (normalsL.Count > 0)
                normals = normalsL.ToArray();
            else
                normals = null;

            tr.Close();            
        }

        void ReadIndicesFromOffFile(string OffFileAddress, int numPoints, out UInt32[] indices)
        {
            StreamReader sr = new StreamReader(File.Open(OffFileAddress, FileMode.Open));
            if (sr.ReadLine() != "OFF")
            {
                Common.Logger.Log("MainForm", "ReadInput", "ReadIndicesFromOffFile", "ERROR: something wrong with OFF file format!", true);
                indices = null;
                return;
            }


            string[] header = sr.ReadLine().Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
            if (UInt32.Parse(header[0]) != numPoints)
            {
                Common.Logger.Log("MainForm", "ReadInput", "ReadIndicesFromOffFile", "ERROR: Number of points in xyzn and off files mismatch!", true);
                indices = null;
                return;
            }

            int numIndices = int.Parse(header[1]);

            for (int i = 0; i < numPoints+1; ++i)
            {
                sr.ReadLine();
            }

            indices = new UInt32[numIndices * 3];
            for (int i = 0; i < numIndices*3 ; i+=3)
            {
                string[] line = sr.ReadLine().Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);

                indices[i] = UInt32.Parse(line[1]);
                indices[i + 1] = UInt32.Parse(line[2]);
                indices[i + 2] = UInt32.Parse(line[3]);
            }

            sr.Close();
            
        }

        string CreateTriFile(string mainFileAddress, Vector3[] _vertices, Vector3[] _normals, UInt32[] _indices,
            List<Vector3> _trueVertices )
        {
            //verticesCount
            //indicesCount
            //trueVerticesCount
            //x y z nx ny nz
            //...
            //x y z nx ny nz
            //p1 p2 p3
            //...
            //p1 p2 p3
            //x y z
            //...
            //x y z

            string fileName = Path.GetFileNameWithoutExtension(mainFileAddress);
            DirectoryCheck("Tri");
            string triFileAddress = @"Tri\" + fileName + ".tri";

            if (File.Exists(triFileAddress))
            {
                DialogResult dr = MessageBox.Show(fileName + ".tri already exists.\nDo you want to replace it?", ".tri File over write",
                    MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Delete(triFileAddress);
                }

                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    for (int i = 1; ; ++i)
                    {
                        if (!File.Exists(@"Tri\" + fileName + i.ToString() + ".tri"))
                        {
                            fileName += i.ToString();
                            triFileAddress = @"Tri\" + fileName+ ".tri";
                            break;
                        }
                    }
                }

            }

            StreamWriter sw = new StreamWriter(File.Create(triFileAddress));
            sw.WriteLine(_vertices.Length);
            sw.WriteLine(_indices.Length / 3);
            sw.WriteLine(_trueVertices.Count);
            
            for (int i = 0; i < _vertices.Length; ++i)
            {
                sw.Write(_vertices[i].X); sw.Write(' ');
                sw.Write(_vertices[i].Y); sw.Write(' ');
                sw.Write(_vertices[i].Z); sw.Write(' ');
                sw.Write(_normals[i].X); sw.Write(' ');
                sw.Write(_normals[i].Y); sw.Write(' ');
                sw.Write(_normals[i].Z); sw.Write("\n");
            }

            for (int i = 0; i < _indices.Length; i += 3)
            {
                sw.Write(_indices[i]); sw.Write(' ');
                sw.Write(_indices[i + 1]); sw.Write(' ');
                sw.Write(_indices[i + 2]); sw.Write("\n");
            }

            for (int i = 0; i < _trueVertices.Count; ++i)
            {
                sw.Write(_trueVertices[i].X); sw.Write(' ');
                sw.Write(_trueVertices[i].Y); sw.Write(' ');
                sw.Write(_trueVertices[i].Z); sw.Write(' ');
                sw.Write("\n");
            }
            
            sw.Close();

            //vertices = _vertices.ToArray();            
            //normals = _normals.ToArray();
            //indices = _indices;

            return triFileAddress;
        }

        void ReadTriInputFile(StreamReader tr, out Vector3[] vertices, out Vector3[] normals, out UInt32[] indices)
        {
            tr.BaseStream.Position = 1024; //GOD!!!
            int numVertices = int.Parse(tr.ReadLine());
            int numIndices = int.Parse(tr.ReadLine());
            int numTrueVertices = int.Parse(tr.ReadLine());

            vertices = new Vector3[numVertices];
            normals = new Vector3[numVertices];
            indices = new UInt32[numIndices*3];
            //trueVertices = new Vector3[numTrueVertices];

            for (int i = 0; i < numVertices; ++i)
            {
                string line = tr.ReadLine();
                string[] xyzn = line.Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);                
                vertices[i].X = float.Parse(xyzn[0]);
                vertices[i].Y = float.Parse(xyzn[1]);
                vertices[i].Z = float.Parse(xyzn[2]);

                normals[i].X = float.Parse(xyzn[3]);
                normals[i].Y = float.Parse(xyzn[4]);
                normals[i].Z = float.Parse(xyzn[5]);

            }

            for (int i = 0; i < numIndices*3; i+=3)
            {
                string[] line = tr.ReadLine().Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);

                indices[i] = UInt32.Parse(line[0]);
                indices[i + 1] = UInt32.Parse(line[1]);
                indices[i + 2] = UInt32.Parse(line[2]);                
            }

            //for (int i = 0; i < numTrueVertices; ++i)
            //{
            //    string line = tr.ReadLine();
            //    string[] xyzn = line.Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
            //    trueVertices[i].X = float.Parse(xyzn[0]);
            //    trueVertices[i].Y = float.Parse(xyzn[1]);
            //    trueVertices[i].Z = float.Parse(xyzn[2]);
            //}
            //trueVertices = (Vector3[])vertices.Clone();
        }

        void ReadPlyInputFile(StreamReader tr, out Vector3[] vertices, out Vector3[] normals, out UInt32[] indices)
        {
            string format = tr.ReadLine();
            tr.BaseStream.Position += format.Length + 1;
            int numVertices = 0;
            int numIndices = 0;
            //flags.NormalAvailable = false;
            bool haveNormals = false;

            string s;
            do
            {
                s = tr.ReadLine();
                tr.BaseStream.Position += s.Length + 1;
                string[] tokens = s.Split(" ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "comment")
                    continue;
                else if (tokens[0] == "element")
                {
                    if (tokens[1] == "vertex")
                    {
                        numVertices = int.Parse(tokens[2]);
                    }
                    else if (tokens[1] == "face")
                    {
                        numIndices = int.Parse(tokens[2]);
                    }
                }
                else if (tokens[0] == "property")
                {
                    if (tokens[2] == "nx")
                        haveNormals = true;
                    continue;

                }

            } while (s != "end_header");
            vertices = new Vector3[numVertices];
            if (haveNormals)
                normals = new Vector3[numVertices];
            else
                normals = null;
            indices = new uint[numIndices * 3];

            switch (format)
            {
                case "format ascii 1.0":
                    tr.BaseStream.Position = 1024; //GOD!!!
                    for (int i = 0; i < numVertices; i++)
                    {
                        s = tr.ReadLine();
                        //tr.BaseStream.Position += s.Length + 2;
                        string[] tokens = s.Split(" ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                        vertices[i].X = float.Parse(tokens[0]);
                        vertices[i].Y = float.Parse(tokens[1]);
                        vertices[i].Z = float.Parse(tokens[2]);

                        if (haveNormals)
                        {                            
                            normals[i].X = float.Parse(tokens[3]);
                            normals[i].Y = float.Parse(tokens[4]);
                            normals[i].Z = float.Parse(tokens[5]);
                        }
                    }

                    for (int i = 0; i < numIndices*3; i+=3)
                    {
                        s = tr.ReadLine();
                        //tr.BaseStream.Position += s.Length + 2;
                        string[] tokens = s.Split(" ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);

                        if (tokens[0] == "3")
                        {
                            indices[i] = uint.Parse(tokens[1]);
                            indices[i+1] = uint.Parse(tokens[2]);
                            indices[i+2] = uint.Parse(tokens[3]);
                        }
                        else
                            throw(new Exception("in ply file format, face indices lines did not start with 3"));
                    }

                    break;
                case "format binary_little_endian 1.0":

                    BinaryReader br = new BinaryReader(tr.BaseStream);
                    
                    
                    for (int i = 0; i < numVertices; i++)
                    {
                        //s = tr.ReadLine();
                        //string[] tokens = s.Split(" ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                        vertices[i].X = br.ReadSingle();
                        vertices[i].Y = br.ReadSingle();
                        vertices[i].Z = br.ReadSingle();

                        if (haveNormals)
                        {
                            normals[i].X = br.ReadSingle();
                            normals[i].Y = br.ReadSingle();
                            normals[i].Z = br.ReadSingle();
                        }
                    }
                    
                    for (int i = 0; i < numIndices*3; i+=3)
                    {
                        //s = tr.ReadLine();
                        //string[] tokens = s.Split(" ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);

                        byte c = br.ReadByte();
                        if (c== 3)
                        {
                            indices[i] = (uint)br.ReadInt32();
                            indices[i + 1] = (uint)br.ReadInt32();
                            indices[i + 2] = (uint)br.ReadInt32();
                        }
                        else
                            throw(new Exception("in ply file format, face indices lines did not start with 3"));
                    }

                    break;                    
                case "format binary_big_endian 1.0":
                    vertices = null;
                    normals = null;
                    indices = null;
                    break;
                default:
                    vertices = null;
                    normals = null;
                    indices = null;
                    break;
            }
        }

        void ReadMeshInputFile(string triFileAddress, out Vector3[] vertices, out Vector3[] normals, out UInt32[] indices)
        {
            if (String.IsNullOrEmpty(triFileAddress))
                throw new ArgumentException(triFileAddress);

            string inputTriFileName = Path.GetFileNameWithoutExtension(triFileAddress);

            //flags.NormalAvailable = true;

            string extension = Path.GetExtension(triFileAddress);

            StreamReader tr = new StreamReader(new FileStream(triFileAddress, FileMode.Open)); //File.OpenRead(triFileAddress));
            try
            {

                string header = tr.ReadLine();
                tr.BaseStream.Position = header.Length + 1;

                switch (header.ToLower())
                //switch (extension.ToLower())
                {
                    case "orthoaid - tri file":
                        //case "tri":
                        ReadTriInputFile(tr, out vertices, out normals, out indices);
                        break;
                    case "ply":
                        ReadPlyInputFile(tr, out vertices, out normals, out indices);
                        break;
                    case "stl":
                        ReadSTLInputFile(tr, out vertices, out normals, out indices);
                        break;
                    default:
                        vertices = null;
                        normals = null;
                        indices = null;
                        break;
                }

                tr.Close();
            }
            catch (Exception err)
            {
                tr.Close();
                throw err;
            }
        }

        private void ReadSTLInputFile(StreamReader tr, out Vector3[] vertices, out Vector3[] normals, out uint[] indices)
        {
            //decided to use meshlab instead!
            throw new NotImplementedException();
        }

        private void WriteCalculationResults_Cal(string CalculationsFileAddress, int handleID)
        {
            Common.CalculationResults temp;
            if (handleID == 1)
                temp = new Common.CalculationResults(Planes1, Dislocations, PlanesRelative,
                    Distance2OcclusalPlane1, Distance2SagitalPlane1);
            else
                temp = new Common.CalculationResults(Planes2, Dislocations, PlanesRelative,
                    Distance2OcclusalPlane2, Distance2SagitalPlane2);

            MemoryStream ms = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(temp.GetType());
            serializer.Serialize(ms, temp);
            ms.Position = 0;
            StreamWriter sr = new StreamWriter(CalculationsFileAddress);
            byte[] buffer = new byte[ms.Length];
            ms.Read(buffer, 0, buffer.Length);
            string result = System.Text.Encoding.UTF8.GetString(buffer);
            sr.Write(result);

            sr.Close();
        }

        private void WriteCalculationResults_txt(string fileaddress)
        {
            TextWriter tw = null;
            try
            {
                tw = new StreamWriter(File.Create(fileaddress));
                tw.Write("OrthoAid - TXT Calculation File");
                tw.Write("\n");

                Common.Plane[] P;
                
                //used to write calculation files separately. now I write only one txt calculation file
                /*if (GetSelectedVbOIndex() == 1)
                    P = Planes1;
                else
                    P = Planes2;*/          
                
                //The following is commented, because reading the txt file seemed like a bad idea.
                /*if (P[OCCLUSALPLANE_INDEX] != null && P[OCCLUSALPLANE_INDEX].valid)
                    tw.Write("," + P[OCCLUSALPLANE_INDEX].centerForDraw.X.ToString() + "," +
                                P[OCCLUSALPLANE_INDEX].centerForDraw.Y.ToString() + "," +
                                P[OCCLUSALPLANE_INDEX].centerForDraw.Z.ToString() + "," +
                                P[OCCLUSALPLANE_INDEX].GetNormal().X.ToString() + "," +
                                P[OCCLUSALPLANE_INDEX].GetNormal().Y.ToString() + "," +
                                P[OCCLUSALPLANE_INDEX].GetNormal().Z.ToString() + "\n");
                else
                    tw.Write("\n");*/


                //Inclinations of Cast1
                tw.Write("\n");
                tw.WriteLine("Inclinations of Cast1");
                tw.Write("ToothNo,inclination\n");                                
                P = Planes1;
                for (int i = 1; i <= 32; i++)
                {
                    if (P[i] != null && P[i].validInclination)
                    {
                        tw.Write(i.ToString() + "," + P[i].inclination.ToString() + "\n");
                    }
                }

                //Inclinations of Cast2
                tw.Write("\n");
                tw.WriteLine("Inclinations of Cast2");
                tw.Write("ToothNo,inclination\n");
                P = Planes2;
                for (int i = 1; i <= 32; i++)
                {
                    if (P[i] != null && P[i].validInclination)
                    {
                        tw.Write(i.ToString() + "," + P[i].inclination.ToString() + "\n");
                    }
                }
                
                //Superimpsoed Inclination
                tw.Write("\n");
                tw.WriteLine("Superimposed Inclination");
                tw.Write("ToothNo,inclination\n");
                for (int i = 1; i <= 32; i++)
                {
                    if (PlanesRelative[i] != null && PlanesRelative[i].validInclination)
                    {
                        tw.Write(i.ToString() + "," + PlanesRelative[i].inclination.ToString() + "\n");
                    }
                }

                //Dislocation

                tw.Write("\n");
                tw.WriteLine("Dislocations");
                tw.WriteLine("ToothNo,Dislocation_X,Dislocation_Y,Dislocation_Z,Dislocation_Total");
                for (int i = 1; i <= 32; i++)
                {
                    if (Dislocations[i].valid)
                        tw.WriteLine(i.ToString() + "," +
                            Dislocations[i].dislocation.X.ToString() + "," +
                            Dislocations[i].dislocation.Y.ToString() + "," +
                                Dislocations[i].dislocation.Z.ToString() + "," +
                                    Dislocations[i].length.ToString());
                }

                //Distance to Plane1
                tw.Write("\n");
                tw.WriteLine("Distance to Planes1");
                tw.WriteLine("ToothNo,Distance_Occlusal,Distance_Sagital");
                for (int i = 1; i <= 32; i++)
                {
                    if (Distance2OcclusalPlane1[i].valid)
                    {
                        tw.Write(i.ToString() + "," +
                                        Distance2OcclusalPlane1[i].length.ToString());
                    
                        if (Distance2SagitalPlane1[i].valid)
                            tw.Write(Distance2SagitalPlane1[i].length.ToString() + "\n");
                        else
                            tw.Write("\n");
                    }
                }

                //Distance to Plane2
                tw.Write("\n");
                tw.WriteLine("Distance to Planes2");
                tw.WriteLine("ToothNo,Distance_Occlusal,Distance_Sagital");
                for (int i = 1; i <= 32; i++)
                {
                    if (Distance2OcclusalPlane2[i].valid)
                    {
                        tw.Write(i.ToString() + "," +
                                        Distance2OcclusalPlane2[i].length.ToString());
                    
                        if (Distance2SagitalPlane2[i].valid)
                            tw.Write(Distance2SagitalPlane2[i].length.ToString() + "\n");
                        else
                            tw.Write("\n");
                    }
                }

                //Angle between Occlusal Planes
                tw.Write("\n");
                tw.WriteLine("Angle between occlusal planes in degrees");
                if (Planes1[OCCLUSALPLANE_INDEX] != null && Planes2[OCCLUSALPLANE_INDEX] != null)
                    tw.WriteLine(Planes1[OCCLUSALPLANE_INDEX].Angle2Plane(Planes2[OCCLUSALPLANE_INDEX]));

                tw.Close();
                
            }
            catch (Exception e)
            {
                if (tw != null)
                    tw.Close();
            }
        }

        private void ReadCalculationResults_Cal(string calculationFileAddress)
        {                        
            FileStream fs = new FileStream(calculationFileAddress, FileMode.Open);
            
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Common.CalculationResults));
                Common.CalculationResults temp = (Common.CalculationResults)serializer.Deserialize(fs);
                serializer = null;

                if (GetSelectedVbOIndex() == 1)
                {
                    Planes1 = temp.planes;
                    for (int i = 0; i < Planes1.Length; i++)
                    {
                        if (Planes1[i] != null && Planes1[i].valid)
                            Planes1[i].validInclination = true;                        
                    }
                    Distance2OcclusalPlane1 = temp.distanceToOccPlane;
                    Distance2SagitalPlane1 = temp.distanceToSagPlane;
                }
                else
                {
                    Planes2 = temp.planes;
                    for (int i = 0; i < Planes2.Length; i++)
                    {
                        if (Planes2[i] != null && Planes2[i].valid)
                            Planes2[i].validInclination = true;                        
                    }
                    Distance2OcclusalPlane2 = temp.distanceToOccPlane;
                    Distance2SagitalPlane2 = temp.distanceToSagPlane;
                }

                PlanesRelative = temp.rplanes;
                for (int i = 0; i < PlanesRelative.Length; i++)
                {
                    if (PlanesRelative[i] != null && PlanesRelative[i].valid)
                        PlanesRelative[i].validInclination = true;
                }

                Dislocations = temp.dislocation;
                
                fs.Close();

                DisableAllCheckBoxes();
                UpdateTeethAndPlanesUI();
            }
            catch (Exception err)
            {
                fs.Close();
                throw err;
            }
        }

        private void ReadCalculationResults_txt(string fileAddress) //out of use
        {
            // This function was not a good idea and I will stop supporting it.
            StreamReader sr = new StreamReader(fileAddress);
            try
            {
                Common.Plane[] P;
                if (GetSelectedVbOIndex() == 1)
                    P = Planes1;
                else
                    P = Planes2;

                string[] header1 = sr.ReadLine().Split(',');
                if (header1[0] != "OrthoAid - TXT Calculation File")
                    throw new Exception("txt calculation file was not in the correct format");
                else
                {
                    if (header1.Length > 1)
                    {
                        Vector3 centerDraw = new Vector3(float.Parse(header1[1]), float.Parse(header1[2]), float.Parse(header1[3]));
                        Vector3 normal = new Vector3(float.Parse(header1[4]), float.Parse(header1[5]), float.Parse(header1[6]));

                        P[OCCLUSALPLANE_INDEX] = new Common.Plane(normal, centerDraw);
                    }
                }

                string header2 = sr.ReadLine();
                if (header2 != "ToothNo,inclination")
                    throw new Exception("txt calculation file was not in the correct format");

                

                string[] tokens;
                while(true)
                {
                    tokens = sr.ReadLine().Split(',');
                    if (tokens.Length < 2)
                        break;
                    int toothNo = int.Parse(tokens[0]);
                    float inclination = float.Parse(tokens[1]);
                    P[toothNo] = new Common.Plane();                    
                    P[toothNo].inclination = inclination;
                    P[toothNo].validInclination = true;
                }
                
                string header3 = sr.ReadLine();
                if (header3 != "ToothNo,inclination")
                    throw new Exception("txt calculation file was not in the correct format");                
                while (true)
                {
                    tokens = sr.ReadLine().Split(',');
                    if (tokens.Length < 2)
                        break;
                    int toothNo = int.Parse(tokens[0]);
                    float inclination = float.Parse(tokens[1]);
                    PlanesRelative[toothNo] = new Common.Plane();
                    PlanesRelative[toothNo].inclination = inclination;
                    PlanesRelative[toothNo].validInclination = true;
                }

                string header4 = sr.ReadLine();
                if (header4 != "ToothNo,Dislocation_X,Dislocation_Y,Dislocation_Z,Dislocation_Total")
                    throw new Exception("txt calculation file was not in the correct format");

                while (!sr.EndOfStream)
                {
                    tokens = sr.ReadLine().Split(',');
                    int toothNo = int.Parse(tokens[0]);
                    Dislocations[toothNo].dislocation = new Vector3(float.Parse(tokens[1]),
                        float.Parse(tokens[2]),
                        float.Parse(tokens[3]));
                    Dislocations[toothNo].length = float.Parse(tokens[4]);
                    Dislocations[toothNo].valid = true;
                }

                sr.Close();
                DisableAllCheckBoxes();
                UpdateTeethAndPlanesUI();
            }
            catch (Exception err)
            {
                sr.Close();
                throw err;
            }            
        }

        private void WriteXYZFile(string XYZFileAddress, Vector3[] vertices, Vector3[] normals)
        {
            TextWriter tw = new StreamWriter(File.Create(XYZFileAddress));

            for (int i = 0; i < vertices.Length; i++)
            {
                if (normals != null && normals.Length > 0)
                    tw.WriteLine(vertices[i].X.ToString() + ' ' +
                        vertices[i].Y.ToString() + ' ' +
                        vertices[i].Z.ToString() + ' ' +
                        normals[i].X.ToString() + ' ' +
                        normals[i].Y.ToString() + ' ' +
                        normals[i].Z.ToString());
                else
                    tw.WriteLine(vertices[i].X.ToString() + ' ' +
                        vertices[i].Y.ToString() + ' ' +
                        vertices[i].Z.ToString());
            }

            tw.Close();
        }

        private void WritePlyFile(string p, Common.Vbo vbo)
        {
            TextWriter tw = new StreamWriter(p);
            tw.WriteLine("ply");
            tw.WriteLine("format ascii 1.0");
            tw.WriteLine("comment OrthoAid Generated");

            if (vbo.validVertices)
            {
                tw.WriteLine("element vertex " + vbo.verticesData.vertices.Length.ToString());
                tw.WriteLine("property float x");
                tw.WriteLine("property float y");
                tw.WriteLine("property float z");

                if (vbo.validNormals)
                {
                    tw.WriteLine("property float nx");
                    tw.WriteLine("property float ny");
                    tw.WriteLine("property float nz");
                }

            }
            if (vbo.validMesh)
            {
                tw.WriteLine("element face " + (vbo.verticesData.indices.Length / 3).ToString());
                tw.WriteLine("property list uchar int vertex_indices");
            }

            tw.WriteLine("end_header");

            if (vbo.validVertices)
            {
                if (vbo.validNormals)
                for (int i = 0; i < vbo.verticesData.vertices.Length; i++)
                {
                    tw.WriteLine(
                        vbo.verticesData.vertices[i].X.ToString() + ' ' +
                        vbo.verticesData.vertices[i].Y.ToString() + ' ' +
                        vbo.verticesData.vertices[i].Z.ToString() + ' ' +
                        vbo.verticesData.normals[i].X.ToString() + ' ' +
                        vbo.verticesData.normals[i].Y.ToString() + ' ' +
                        vbo.verticesData.normals[i].Z.ToString()
                        );
                }
                else
                    for (int i = 0; i < vbo.verticesData.vertices.Length; i++)
                    {
                        tw.WriteLine(
                            vbo.verticesData.vertices[i].X.ToString() + ' ' +
                            vbo.verticesData.vertices[i].Y.ToString() + ' ' +
                            vbo.verticesData.vertices[i].Z.ToString()                            
                            );
                    }
            }
            if (vbo.validMesh)
            {
                for (int i = 0; i < vbo.verticesData.indices.Length; i+=3)
                {
                    tw.WriteLine(
                        "3 " +
                        vbo.verticesData.indices[i].ToString() + ' ' +
                        vbo.verticesData.indices[i + 1].ToString() + ' ' +
                        vbo.verticesData.indices[i + 2].ToString()
                        );

                }
            }

            tw.Close();
        }

        private void WriteSelectionFile(string fileAddress, Common.Vbo handle)
        {
            TextWriter tw = new StreamWriter(File.Create(fileAddress));
            tw.WriteLine("OrthoAid - TXT Selection File");
            
            tw.Write("X,Y,Z,index\n");
            for (int i = 0; i < handle.selectedVertices.Count; i++)
            {
                //modified for convenience
                Vector3 p = handle.verticesData.vertices[handle.selectedVertices[i]];
                tw.WriteLine(p.X.ToString() + ',' + p.Y.ToString() + ',' + p.Z.ToString() +
                            "," + handle.selectedVertices[i].ToString());

                //new one for better excel import
                //Vector3 p = handle.verticesData.vertices[handle.selectedVertices[i]];
                //tw.Write(p.X.ToString() + ',' + p.Y.ToString() + ',' + p.Z.ToString() +
                //            ",");
            }

            //new one for better excel import
            //tw.WriteLine();
            //for (int i = 0; i < handle.selectedVertices.Count; i++)
            //{
            //    tw.Write(handle.selectedVertices[i].ToString()+',');
            //}

            tw.Close();
        }

        private void ReadSelectionFile(string fileAddress, Common.Vbo handle)
        {
            StreamReader sr = new StreamReader(fileAddress);
            try
            {
                string[] header1 = sr.ReadLine().Split(',');
                if (header1[0] != "OrthoAid - TXT Selection File" && 
                    header1[0] != "AHA OrthoAid - TXT Selection File" )
                    throw new Exception("Selection calculation file was not in the correct format");                

                string header2 = sr.ReadLine();
                if (header2 != "X,Y,Z,index")
                    throw new Exception("Selection calculation file was not in the correct format");

                handle.selectedVertices.Clear();

                //while (!sr.EndOfStream)
                //{
                //    string[] tokens = sr.ReadLine().Split(',');
                //    handle.selectedVertices.Add(uint.Parse(tokens[3]));
                //}

                sr.ReadLine(); //SKIPPING XYZ DATA
                string[] tokens = sr.ReadLine().Split(',');
                for (int i = 0; i < tokens.Length - 1; ++i) //-1 for the last comma
                    handle.selectedVertices.Add(uint.Parse(tokens[i]));

                sr.Close();
                UpdateUI();
            }
            catch (Exception err)
            {
                sr.Close();
                Common.Logger.Log("MainForm", "ReadWriteFile", "ReadSelectionFile", err.ToString(), true);                
            }           
        }

        private void WriteExcelSelectionFile(string filename)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            var workbook = excelApp.Workbooks.Add();
            var worksheet = workbook.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet;        

            for (int i = 0; i < vbo1.selectedVertices.Count; i++)
            {
                //modified for convenience
                Vector3 p = vbo1.verticesData.vertices[vbo1.selectedVertices[i]];
                worksheet.Cells[i+1, 1] = p.X.ToString();
                worksheet.Cells[i+1, 2] = p.Y.ToString();
                worksheet.Cells[i+1, 3] = p.Z.ToString();                
            }

            for (int i = 0; i < vbo2.selectedVertices.Count; i++)
            {
                //modified for convenience
                Vector3 p = vbo2.verticesData.vertices[vbo2.selectedVertices[i]];
                worksheet.Cells[i+1, 4] = p.X.ToString();
                worksheet.Cells[i+1, 5] = p.Y.ToString();
                worksheet.Cells[i+1, 6] = p.Z.ToString();
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
    }
}


