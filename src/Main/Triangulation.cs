using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace OrthoAid
{
    public partial class MainForm
    {
        private string Triangulate_MarchingCube_MeshLab(string xyzFileAddress, Common.Vbo vbo, string proposedOutputNameAddress)
        {
            DirectoryCheck("Mesh");
            DirectoryCheck("XYZ");

            string outputMeshFile = proposedOutputNameAddress;
            outputMeshFile = outputMeshFile.Replace(".xyz", ".ply");
            outputMeshFile = outputMeshFile.Replace(@"\XYZ\", @"\Mesh\");
            //output[output.Length-1] = 'o';
            int c = 1;
            while (File.Exists(outputMeshFile))
            {
                string filename = Path.GetFileNameWithoutExtension(outputMeshFile);
                outputMeshFile = outputMeshFile.Replace(filename, filename + "(" + c.ToString() + ")");
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"MeshLabServer\meshlabserver.exe";
            startInfo.Arguments = "-i " + @xyzFileAddress +
                    " -o " + outputMeshFile;
            if (!vbo.validNormals)
            {
                startInfo.Arguments +=
                    " -s NormalEstimation_MarchingCubes(RIMLS).mlx";//NormalEstimation_BallPivoting.mlx";
                EditMLXFile_NormalK(startInfo.WorkingDirectory + @"\NormalEstimation_MarchingCubes(RIMLS).mlx", 50, false);
            }
            else
            {
                startInfo.Arguments += " -s MarchingCubes(RIMLS).mlx";//BallPivoting.mlx";
            }
            startInfo.Arguments += " -om vn";
            startInfo.RedirectStandardOutput = false;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false;
            startInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\MeshLabServer";

            try
            {
                Process exeProcess;
                using (exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    //exeProcess.Kill();

                    exeProcess.Close();
                }

                if (File.Exists(outputMeshFile))
                {
                    Common.Logger.Log("MainForm", "Triangulatoin", "Triangulate_MarchingCube_MeshLab", "Point cloud triangulated with MarchingCube algorithm", false);
                    return outputMeshFile;
                }
                else
                {
                    Common.Logger.Log("MainForm", "Triangulatoin", "Triangulate_MarchingCube_MeshLab", "Error triangulating using MarchingCubeAlgorithm", true);
                    return "error";
                }
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "Triangulatoin", "Triangulate_MarchingCube_MeshLab", e.Message, true);
                return "error";
            }
        }

        private bool ReducePointDensity(Vector3[] vertices, Vector3[] normals, out Vector3[] newVertices, out Vector3[] newNormals)
        {
            //float percent = 1f;
            //float distanceThres = ((verticesStats.RangeX / 100) * percent) * ((verticesStats.RangeX / 100) * percent);

            float distanceThres = config.ReduceDensityThreshold * config.ReduceDensityThreshold;

            List<Vector3> newPointsL = new List<Vector3>();//vertices.Length/2);
            List<Vector3> newNormalsL = new List<Vector3>();//vertices.Length/2);
                                                            //Vector3[] newPointsTemp = new Vector3[vertices.Length];
                                                            //Vector3[] newNormalsTemp;//
                                                            //if (normals != null)
                                                            //    newNormalsTemp = new Vector3[normals.Length];
                                                            //else
                                                            //    newNormalsTemp = null;

            //int newCounter = 0;

            for (int i = 0; i < vertices.Length - 1; i++)
            {
                bool nearNeighbourFound = false;
                for (int j = i + 1; j < vertices.Length; j++)
                {
                    if ((vertices[i] - vertices[j]).LengthSquared < distanceThres)
                    {
                        nearNeighbourFound = true;
                        break;
                    }
                }
                if (!nearNeighbourFound)
                {
                    newPointsL.Add(vertices[i]);
                    //newPointsTemp[newCounter] = vertices[i];

                    if (normals != null)
                        newNormalsL.Add(normals[i]);
                    //    newNormalsTemp[newCounter] = normals[i];
                    //newCounter++;
                }
            }

            newVertices = newPointsL.ToArray();
            newNormals = newNormalsL.ToArray();
            //newVertices = new Vector3[newCounter];
            //if (normals != null)
            //    newNormals = new Vector3[newCounter];
            //else
            //    newNormals = null;
            //for (int i = 0; i < newCounter; i++)
            //{
            //    newVertices[i] = newPointsTemp[i];
            //    if (normals != null)
            //        newNormals[i] = newNormalsTemp[i];
            //}

            return true;
        }

        private int DeleteNoisyPoints(Common.Vbo handle)
        {
            List<Vector3> v = new List<Vector3>();
            List<Vector3> n = new List<Vector3>();

            float threashold = SPUR_DISTANCE_THREASHOLD * SPUR_DISTANCE_THREASHOLD;
            for (int i = 0; i < handle.verticesStats.numVertices; i++)
            {
                if ((handle.verticesData.vertices[i] - handle.verticesStats.Mean).LengthSquared < threashold)
                {
                    v.Add(handle.verticesData.vertices[i]);
                    if (handle.validNormals)
                        n.Add(handle.verticesData.normals[i]);
                }
            }

            int dels = handle.verticesStats.numVertices - v.Count;

            //handle.verticesData.vertices = v.ToArray();
            //if (handle.validNormals)
            //    handle.verticesData.normals = n.ToArray();

            LoadVertices_Normals(ref handle, v.ToArray(), n.ToArray());
            InitVerticesStats(ref handle);

            return dels;
        }

        private void EditMLXFile_NormalK(string mlxFileAddress, int newK, bool flipNormals)
        {
            try
            {
                var doc = XDocument.Load(mlxFileAddress);
                var t = doc.Root;
                var Paramk = t.Element("filter").Element("Param");
                var attK = Paramk.Attribute("value");// 
                attK.Value = newK.ToString();

                var elems = Paramk.ElementsAfterSelf();
                var ParamFlip = elems.First<XElement>();
                var attFlip = ParamFlip.Attribute("value");
                attFlip.Value = flipNormals.ToString();

                doc.Save(mlxFileAddress);
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "Triangulation", "EditMLXFile_NormalK", e.Message, true);
                throw e;
            }
        }

        private string GenerateTempMeshName(string ext)
        {
            DirectoryCheck("TemporaryData");
            string outputMeshFile = Directory.GetCurrentDirectory() + @"\TemporaryData\Mesh";
            int c = 0;
            string test;
            do
            {
                test = outputMeshFile + c.ToString() + "." + ext;
                c++;
            } while (File.Exists(test));

            return test;
        }

        public string ComputeNormals(ref Common.Vbo handle, int k, bool flipNormals)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\MeshLabServer";
            string inputMeshFile = GenerateTempMeshName("xyz");
            string outputMeshFile = GenerateTempMeshName("ply");

            WriteXYZFile(inputMeshFile, handle.verticesData.vertices, null);

            startInfo.FileName = @"MeshLabServer\meshlabserver.exe";
            startInfo.Arguments = "-i " + @inputMeshFile +
                    " -o " + outputMeshFile;

            startInfo.Arguments += " -s NormalEstimation.mlx";//BallPivoting.mlx";

            startInfo.Arguments += " -om vn";
            startInfo.RedirectStandardOutput = false;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = false;

            try
            {
                EditMLXFile_NormalK(startInfo.WorkingDirectory + @"\NormalEstimation.mlx", k, flipNormals);
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "Triangulation.cs", "ComputeNormals",
                    e.Message, true);
                return e.Message;
            }

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    //exeProcess.Kill();

                    exeProcess.Close();
                }
                File.Delete(inputMeshFile);

                if (File.Exists(outputMeshFile))
                {
                    Common.Logger.Log("MainForm", "Triangulatoin", "ComputeNormals", "Point cloud normal calculated", false);
                    return outputMeshFile;
                }
                else
                {
                    Common.Logger.Log("MainForm", "Triangulatoin", "ComputeNormals", "Error in Point cloud normal calculation", true);
                    return "error"; ;
                }
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "Triangulatoin", "ComputeNormals", e.Message, true);
                return "error";
            }
        }
    }
}