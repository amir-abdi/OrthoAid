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


namespace LaserProjectOpenTK
{
    public partial class MainForm : Form
    {
        bool newFile = false;
        void ReadXYZInputFile_and_Insert(string xyzFileAddress, bool haveNormals)
        {
            //input file:
            //x y z [nx ny nz]
            //x y z [nx ny nz]
            //...
            verticesStats.Min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            verticesStats.Max = new Vector3(float.MinValue, float.MinValue, float.MinValue);            

            if (String.IsNullOrEmpty(xyzFileAddress))
                throw new ArgumentException(xyzFileAddress);

            List<Vector3> _vertices = new List<Vector3>();
            List<Vector3> _normals = new List<Vector3>();
            if (haveNormals)
                flags.NormalAvailable = true;
            else
                flags.NormalAvailable = false;
            
            Vector3 meanPoint;
            meanPoint = Vector3.Zero;
            TextReader tr = new StreamReader(File.OpenRead(xyzFileAddress));
            while (tr.Peek()!=-1)
            {
                string line = tr.ReadLine();
                string[] xyz = line.Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                OpenTK.Vector3 v;
                v.X = float.Parse(xyz[0]);
                v.Y = float.Parse(xyz[1]);
                v.Z = float.Parse(xyz[2]);
                _vertices.Add(v);

                if (haveNormals)
                {
                    Vector3 n;
                    n.X = float.Parse(xyz[3]);
                    n.Y = float.Parse(xyz[4]);
                    n.Z = float.Parse(xyz[5]);
                    _normals.Add(n);
                }
                meanPoint = Vector3.Add(meanPoint, v);
                
                if (v.X < verticesStats.Min.X)
                    verticesStats.Min.X = v.X;
                if (v.Y < verticesStats.Min.Y)
                    verticesStats.Min.Y = v.Y;
                if (v.Z < verticesStats.Min.Z)
                    verticesStats.Min.Z = v.Z;
                if (v.X > verticesStats.Max.X)
                    verticesStats.Max.X = v.X;
                if (v.Y > verticesStats.Max.Y)
                    verticesStats.Max.Y = v.Y;
                if (v.Z > verticesStats.Max.Z)
                    verticesStats.Max.Z = v.Z;
            }

            tr.Close();
            meanPoint = Vector3.Divide(meanPoint, _vertices.Count);
            verticesStats.Mean = meanPoint;
            verticesStats.Size = _vertices.Count;

            Logger.Log("MainForm", "ReadInput", "ReadXYZInputFile", ".xyz input file (" + xyzFileAddress + ") read successfully", false);

            vertices = _vertices.ToArray();
            if (haveNormals)
                normals = _normals.ToArray();
            //return vertices.ToArray();
        }

        string TriangulatePCL(string pcdFileAddress)
        {
            string filename = Path.GetFileNameWithoutExtension(pcdFileAddress);
            string nodeFolder = Path.GetDirectoryName(pcdFileAddress);
            DirectoryCheck("TriPCD");
            string triFileAddress = @"TriPCD\" + filename + ".tri";

            //remove comment after debug
            if (newFile == false)
            if (File.Exists(triFileAddress))
            {
                Logger.Log("MainForm", "ReadInput", "TriangulatePCL", ".tri file (" + triFileAddress + ") already exists", false);
                return triFileAddress;
            }
            Process p = new Process();
            try
            {
                //comment after debug
                if (newFile == true)
                if (File.Exists("TriPCD" + "\\" + filename + ".tri"))
                    File.Delete("TriPCD" + "\\" + filename + ".tri");

                //1-->fileName
                //2-->Search (normal)
                //3-->SearchRadius
                //4-->sMu
                //5-->MaxNN
                //6-->MaxSurfaceAngle
                //7-->MinTriAngle (noGuarantee)
                //8-->MaxTriAngle (Guaranteed)

                //worked values:
                //20 5 2.5 100 M_PI/4 M_PI/18 2*M_PI/3
                //20 5 2.5 100 0.785398 0.174532 2.094395
                
                p.StartInfo.FileName = "PCL.exe";          //2 3  4   5       6       7       8
                p.StartInfo.Arguments = @pcdFileAddress + " 20 5 2.5 100 0.785398 0.174532 2.094395";
                p.StartInfo.RedirectStandardOutput = true;  
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                Logger.Log("MainForm", "ReadInput", "TetGenCall", p.StandardOutput.ReadToEnd(), false);

                if (File.Exists("TriPCD" + "\\" + filename + ".tri"))
                    Logger.Log("MainForm", "ReadInput", "TriangulatePCL", ".tri file (" + triFileAddress + ") created successfully.", false);
                else
                    Logger.Log("MainForm", "ReadInput", "TriangulatePCL", "ERROR: TetGen didn't work!", true);

            }
            catch (Exception e)
            {
                Logger.Log("MainForm", "ReadInput", "TriangulatePCL", e.Message);
            }

            return triFileAddress;
        }

        static public void DirectoryCheck(string dir)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        string ReformatXYZ2pcd(Vector3[] vertices, string xyzFileAddress)
        {
            //input:
            //vertices

            //output file:
            /*@"VERSION 1.6
            FIELDS x y z
            SIZE 4 4 4
            TYPE F F F
            COUNT 1 1 1
            WIDTH vertices.length
            HEIGHT 1
            POINTS vertices.length
            DATA ascii
            x y z
            x y z
            ...
             */
            



            string fileName = Path.GetFileNameWithoutExtension(xyzFileAddress);
            DirectoryCheck("TriPCD");
            string pcdFileAddress = @"TriPCD\" + fileName + ".pcd";
            //remove comment after debug (message show to user)
            if (File.Exists(pcdFileAddress))
            {
                Logger.Log("MainForm", "ReadInput", "ReformatXYZ2pcd", ".pcd file (" + pcdFileAddress + ") already exists", false);
                return pcdFileAddress;
            }
            StreamWriter sw = new StreamWriter(File.Create(pcdFileAddress));
            sw.Write(@"VERSION 1.6
FIELDS x y z
SIZE 4 4 4
TYPE F F F
COUNT 1 1 1
WIDTH ");
            sw.WriteLine(vertices.Length.ToString());
            sw.Write(@"HEIGHT 1
POINTS ");
            sw.WriteLine(vertices.Length.ToString());
            sw.WriteLine("DATA ascii");

            for (int i = 0; i < vertices.Length; i++)
                sw.WriteLine(
                    vertices[i].X.ToString() + "  " +
                    vertices[i].Y.ToString() + "  " +
                    vertices[i].Z.ToString());

            sw.Close();

            Logger.Log("MainForm", "ReadInput", "ReformatXYZ2pcd", ".gcd file (" + pcdFileAddress + ") created successfully.", false);
            return pcdFileAddress;
        }

        UInt32[] ReadIndicesInputFile(string indicesFileAddress)
        {
            //input file:
            //Indices Count
            //p1 p2 p3
            //p1 p2 p3
            //...

            if (String.IsNullOrEmpty(indicesFileAddress))
                throw new ArgumentException(indicesFileAddress);

            const int t = 3;
            StreamReader sr = new StreamReader(File.Open(indicesFileAddress, FileMode.Open));
            int count = int.Parse(sr.ReadLine());
            UInt32[] indices = new UInt32[count * t];

            for (int i = 0; i < count * t; i+=t)
            {
                string[] line = sr.ReadLine().Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                if (line.Length > 4)
                    break;
                indices[i] = UInt32.Parse(line[0]);
                indices[i + 1] = UInt32.Parse(line[1]);
                indices[i + 2] = UInt32.Parse(line[2]);               
            }

            sr.Close();
            Logger.Log("MainForm", "ReadInput", "ReadIndicesInputFile", ".indices input file (" + indicesFileAddress + ") read and indices created successfully.", false);
            return indices;
        }

        void Read_XYZ_or_XYZN_to_XYZN_and_off_using_PoissonSurfRec(string xyzFileAddress, bool haveNormals)
        {
            if (String.IsNullOrEmpty(xyzFileAddress))
                throw new ArgumentException(xyzFileAddress);

            try
            {
                //Process p = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "poisson_reconstruction.exe";
                startInfo.Arguments = @xyzFileAddress + " -sm_radius 20 -sm_distance 0.1";
                if (haveNormals)
                    startInfo.Arguments += " -norm 1";
                startInfo.RedirectStandardOutput = false;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = false;
                startInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                //p.Start();

                try
                {
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                        //exeProcess.Kill();
                        exeProcess.Close();
                        //Logger.Log("MainForm", "ReadInput", "Read_XYZ_or_XYZN_to_XYZN_and_off_using_PoissonSurfRec",
                        //exeProcess.StandardOutput.ReadToEnd(), false);        
                    }
                }
                catch (Exception e)
                {
                    Logger.Log("MainForm", "ReadInput", "Poisson_Reconstruction.exe", e.Message);
                }

                //p.WaitForExit();


                if (File.Exists("off") && File.Exists("xyzn"))
                    Logger.Log("MainForm", "ReadInput", "Read_XYZ_or_XYZN_to_XYZN_and_off_using_PoissonSurfRec",
                        "xyzn and off files created successfully.", false);
                else
                    Logger.Log("MainForm", "ReadInput", "Read_XYZ_or_XYZN_to_XYZN_and_off_using_PoissonSurfRec",
                        "xyzn and off files not created. Poisson_Reconstruction.exe didn't work!", false);

                List<Vector3> _vertices = new List<Vector3>();
                List<Vector3> _normals = new List<Vector3>();
                List<Vector3> _trueVertices = new List<Vector3>();
                ReadXYZNInputFile("xyzn", _vertices, _normals);
                File.Delete("xyzn");

                UInt32[] _indices;
                ReadIndicesFromOffFile("off", _vertices.Count, out _indices);
                File.Delete("off");

                ReadTrueXYZInputFile(xyzFileAddress, _trueVertices);
                string triFileAddress = CreateTriFile(xyzFileAddress, _vertices, _normals, _indices, _trueVertices);

                DialogResult dr_loadFile = MessageBox.Show("Do you want to load the new mesh file " + 
                    Path.GetFileNameWithoutExtension(triFileAddress) + ".tri?", "Mesh Generation Complete",
                    MessageBoxButtons.YesNo);
                if (dr_loadFile == System.Windows.Forms.DialogResult.Yes)
                {
                    ReadTriFile_and_Insert(triFileAddress);
                }
                else if (dr_loadFile == System.Windows.Forms.DialogResult.No)
                {
                    //Do nothing
                }
            }
            catch (Exception e)
            {
                Logger.Log("MainForm", "ReadInput", "Read_XYZ_or_XYZN_to_XYZN_and_off_using_PoissonSurfRec", e.Message);
            }

        }

        private void ReadTrueXYZInputFile(string xyzFileAddress, List<Vector3> _trueVertices)
        {
            StreamReader sr = new StreamReader(File.OpenRead(xyzFileAddress));
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();
                string[] xyz = line.Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                OpenTK.Vector3 v;
                v.X = float.Parse(xyz[0]);
                v.Y = float.Parse(xyz[1]);
                v.Z = float.Parse(xyz[2]);
                _trueVertices.Add(v);   
            }
            sr.Close();
        }

        void ReadXYZNInputFile(string xyznFileAddress, List<Vector3> vertices, List<Vector3> normals)
        {
            //input file:
            //x y z nx ny nz
            //x y z nx ny nz
            //...
            
            if (String.IsNullOrEmpty(xyznFileAddress))
                throw new ArgumentException(xyznFileAddress);          
            
            TextReader tr = new StreamReader(File.OpenRead(xyznFileAddress));
            while (tr.Peek() != -1)
            {
                string line = tr.ReadLine();
                string[] xyz = line.Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                OpenTK.Vector3 v;
                v.X = float.Parse(xyz[0]);
                v.Y = float.Parse(xyz[1]);
                v.Z = float.Parse(xyz[2]);
                vertices.Add(v);

                Vector3 n;
                n.X = float.Parse(xyz[3]);
                n.Y = float.Parse(xyz[4]);
                n.Z = float.Parse(xyz[5]);
                normals.Add(n);
                                

                if (v.X < verticesStats.Min.X)
                    verticesStats.Min.X = v.X;
                if (v.Y < verticesStats.Min.Y)
                    verticesStats.Min.Y = v.Y;
                if (v.Z < verticesStats.Min.Z)
                    verticesStats.Min.Z = v.Z;
                if (v.X > verticesStats.Max.X)
                    verticesStats.Max.X = v.X;
                if (v.Y > verticesStats.Max.Y)
                    verticesStats.Max.Y = v.Y;
                if (v.Z > verticesStats.Max.Z)
                    verticesStats.Max.Z = v.Z;
            }

            tr.Close();            
        }

        void ReadIndicesFromOffFile(string OffFileAddress, int numPoints, out UInt32[] indices)
        {
            StreamReader sr = new StreamReader(File.Open(OffFileAddress, FileMode.Open));
            if (sr.ReadLine() != "OFF")
            {
                Logger.Log("MainForm", "ReadInput", "ReadIndicesFromOffFile", "ERROR: something wrong with OFF file format!", true);
                indices = null;
                return;
            }


            string[] header = sr.ReadLine().Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
            if (UInt32.Parse(header[0]) != numPoints)
            {
                Logger.Log("MainForm", "ReadInput", "ReadIndicesFromOffFile", "ERROR: Number of points in xyzn and off files mismatch!", true);
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

        string CreateTriFile(string mainFileAddress, List<Vector3> _vertices, List<Vector3> _normals, UInt32[] _indices,
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
            sw.WriteLine(_vertices.Count);
            sw.WriteLine(_indices.Length / 3);
            sw.WriteLine(_trueVertices.Count);
            
            for (int i = 0; i < _vertices.Count; ++i)
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

        void ReadTriFile_and_Insert(string triFileAddress)
        {
            if (String.IsNullOrEmpty(triFileAddress))
                throw new ArgumentException(triFileAddress);

            flags.NormalAvailable = true;
            Vector3 meanPoint;
            meanPoint = Vector3.Zero;
            

            TextReader tr = new StreamReader(File.OpenRead(triFileAddress));
            int numVertices = int.Parse(tr.ReadLine());
            int numIndices = int.Parse(tr.ReadLine());
            int numTrueVertices = int.Parse(tr.ReadLine());

            vertices = new Vector3[numVertices];
            normals = new Vector3[numVertices];
            indices = new UInt32[numIndices*3];
            trueVertices = new Vector3[numTrueVertices];

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

                meanPoint = Vector3.Add(meanPoint, vertices[i]);
            }
            verticesStats.Mean = Vector3.Divide(meanPoint, vertices.Length);
            verticesStats.Size = vertices.Length;            

            for (int i = 0; i < numIndices*3; i+=3)
            {
                string[] line = tr.ReadLine().Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);

                indices[i] = UInt32.Parse(line[0]);
                indices[i + 1] = UInt32.Parse(line[1]);
                indices[i + 2] = UInt32.Parse(line[2]);                
            }

            for (int i = 0; i < numTrueVertices; ++i)
            {
                string line = tr.ReadLine();
                string[] xyzn = line.Split("\t ".ToArray<char>(), StringSplitOptions.RemoveEmptyEntries);
                trueVertices[i].X = float.Parse(xyzn[0]);
                trueVertices[i].Y = float.Parse(xyzn[1]);
                trueVertices[i].Z = float.Parse(xyzn[2]);
            }

            tr.Close();

        }
    }
}
