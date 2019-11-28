using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using System.Threading;
using System.Runtime.InteropServices;
using System.Resources;

namespace OrthoAid
{
    public partial class MainForm : Form
    {
        public static Common.Configuration config = new Common.Configuration();

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Common.Logger.Log(e.Exception.StackTrace, e.Exception.Message);
        }

        public MainForm()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            InitializeComponent();

            foreach (Control control in this.Controls)
            {
                if (control.GetType().FullName != "System.Windows.Forms.TextBox")
                {
                    control.KeyDown += MainForm_KeyDown;
                    control.KeyUp += MainForm_KeyUp;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitTeethBoxes();

            Plane_CB1.Add(OCCLUSALPLANE_INDEX, 33);
            Plane_CB1.Add(SAGITALPLANE_INDEX, 34);
            Plane_CB1.Add(CURVEPLANE_INDEX, 37);
            Plane_CB2.Add(OCCLUSALPLANE_INDEX, 35);
            Plane_CB2.Add(SAGITALPLANE_INDEX, 36);
            Plane_CB2.Add(CURVEPLANE_INDEX, 38);
            Plane_CB = new List<Dictionary<int, int>>() { Plane_CB1, Plane_CB2 };

            WirePolynomials[0] = new Common.PolynomialParametric2DCurve[7]; //mandible
            WirePolynomials[1] = new Common.PolynomialParametric2DCurve[7]; //maxilla

            toolStripMenu.ImageScalingSize = new Size(32, 32);

            this.MouseWheel += MouseWheel_UpDown;

            cb_showCast1.Enabled = false;
            cb_showCast2.Enabled = false;


            Application.Idle += Application_Idle;

            angleX = 0;
            angleY = 0;
            angleZ = 0;
            UpdateUI();

            if (openGLInitiated)
            {
                AutoLoadFiles();
            }

            vScroll_lightIntensity.Value = 100 - (int)(config.lightIntensity * 100);

            Common.ViewMode tempViewModeToSaveTheCorrectState = config.viewMode;
            config.viewMode = tempViewModeToSaveTheCorrectState;

            UpdateUI();

            this.BringToFront();
            this.Focus();
            this.KeyPreview = true;

            SetFeatureToAllControls(this.Controls);

        }

        private void SetFeatureToAllControls(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Control control in cc)
                {
                    control.PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
                    SetFeatureToAllControls(control.Controls);

                }
            }
        }

        void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;

            }
        }

        private void GlControlCast_OnPaint(object sender, PaintEventArgs e)
        {
            DrawAll();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if (glControlCast.IsIdle)
                DrawAll();
        }

        private void Rb_Points_CheckedChanged(object sender, EventArgs e)
        {
            UpdateViewMode();
        }

        private void Rb_WireFrame_CheckedChanged(object sender, EventArgs e)
        {
            UpdateViewMode();
        }

        private void Rb_Mesh_CheckedChanged(object sender, EventArgs e)
        {
            UpdateViewMode();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to exit the application?", "Exiting OrthoAid", MessageBoxButtons.YesNo);

            if (dr == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
            //Common.Logger.CloseLog();
            config.SaveConfig();
            timer_10mill.Stop();
        }

        private void UpdateViewMode()
        {
            if (rb_viewMesh.Checked == true)
            {
                config.viewMode = Common.ViewMode.Mesh;
                cb_showPoints.Enabled = true;
            }
            else if (rb_viewPoints.Checked == true)
            {
                cb_showPoints.Enabled = false;
                config.viewMode = Common.ViewMode.Points;
            }
            else if (rb_viewWireFrame.Checked == true)
            {
                cb_showPoints.Enabled = false;
                config.viewMode = Common.ViewMode.WireFrame;
            }

            //Render();
        }

        private void UpdateUI()
        {
            lbox_selectCast.SelectedIndex = SelectedCast;
            tstrip_lockSelection.Checked = lockSelection;

            tx_cameraAngleX.Text = angleX.ToString();
            tx_cameraAngleY.Text = angleY.ToString();
            tx_cameraAngleZ.Text = angleZ.ToString();

            switch (config.editMode)
            {
                case OrthoAid.Common.EditMode.Hand:
                    tstrip_Hand.Checked = true;
                    tstrip_Ruler.Checked = false;
                    tstrip_Select.Checked = false;
                    glControlCast.Cursor = Cursors.Hand;
                    IndiscriminateSelectedVertex(GetSelectedVBO(), pointedVertexNumber);
                    break;
                case OrthoAid.Common.EditMode.Select:
                    tstrip_Hand.Checked = false;
                    tstrip_Ruler.Checked = false;
                    tstrip_Select.Checked = true;
                    glControlCast.Cursor = Cursors.Arrow;
                    break;
                case OrthoAid.Common.EditMode.Ruler:
                    tstrip_Hand.Checked = false;
                    tstrip_Select.Checked = false;
                    tstrip_Ruler.Checked = true;
                    glControlCast.Cursor = new Cursor(Properties.Resources.ruler_cursor_icon.GetHicon());
                    break;
                default:
                    break;
            }

            switch (config.viewMode)
            {
                case Common.ViewMode.Mesh:
                    rb_viewMesh.Checked = true;
                    break;
                case Common.ViewMode.Points:
                    rb_viewPoints.Checked = true;
                    break;
                case Common.ViewMode.WireFrame:
                    rb_viewWireFrame.Checked = true;
                    break;
            }

            switch (config.bbpChoice)
            {
                case OrthoAid.Common.BBPChoice.User:
                    rb_BBPuser.Checked = true;
                    break;
                case OrthoAid.Common.BBPChoice.AutoMiddle:
                    rb_BBCmiddle.Checked = true;
                    break;
            }

            if (vbo1 != null && vbo2 != null && reduceDensityVbo != null)
            {

                lb_selectedPoints1.Text = vbo1.selectedVertices.Count.ToString();
                lb_selectedPoints2.Text = vbo2.selectedVertices.Count.ToString();


                rb_viewPoints.Enabled = (vbo1.validVertices | vbo2.validVertices);
                rb_viewWireFrame.Enabled = vbo1.validWireframe | vbo2.validWireframe;
                rb_viewMesh.Enabled = vbo1.validMesh | vbo2.validMesh;

                if (vbo1.validVertices)
                {
                    lb_numVertices1.Visible = true;
                    lb_numFaces1.Visible = true;
                    lb_meshName1.Visible = true;
                    gb_cast1.Visible = true;

                    if (vbo1.validVertices)
                        lb_numVertices1.Text = "Vertices: " + vbo1.verticesData.vertices.Length.ToString();
                    else
                        lb_numVertices1.Text = "Vertices: 0";
                    if (vbo1.validMesh)
                        lb_numFaces1.Text = "Faces: " + ((int)(vbo1.verticesData.indices.Length / 3)).ToString();
                    else
                        lb_numFaces1.Text = "Faces: 0";
                    lb_meshName1.Text = config.lastLoadedMeshName1;
                }
                else
                {
                    lb_numVertices1.Visible = false;
                    lb_numFaces1.Visible = false;
                    lb_meshName1.Visible = false;
                    gb_cast1.Visible = false;
                }

                if (vbo2.validVertices)
                {
                    lb_numVertices2.Visible = true;
                    lb_numFaces2.Visible = true;
                    lb_meshName2.Visible = true;
                    gb_cast2.Visible = true;

                    if (vbo2.validVertices)
                        lb_numVertices2.Text = "Vertices: " + vbo2.verticesData.vertices.Length.ToString();
                    else
                        lb_numVertices2.Text = "Vertices: 0";
                    if (vbo2.validMesh)
                        lb_numFaces2.Text = "Faces: " + ((int)(vbo2.verticesData.indices.Length / 3)).ToString();
                    else
                        lb_numFaces2.Text = "Faces: 0";
                    lb_meshName2.Text = config.lastLoadedMeshName2;
                }
                else
                {
                    lb_numVertices2.Visible = false;
                    lb_numFaces2.Visible = false;
                    lb_meshName2.Visible = false;
                    gb_cast2.Visible = false;
                }

                if (vbo1.validVertices)
                {
                    cb_showCast1.Enabled = true;
                    cb_showCast1.Checked = vbo1.show;
                    showCast1ToolStripMenuItem.Enabled = true;
                    showCast1ToolStripMenuItem.Checked = vbo1.show;
                    lbox_selectCast.Items[0] = "Cast 1";
                }
                else
                {
                    cb_showCast1.Enabled = false;
                    cb_showCast1.Checked = false;
                    showCast1ToolStripMenuItem.Checked = false;
                    showCast1ToolStripMenuItem.Enabled = false;
                    lbox_selectCast.Items[0] = "Empty";
                }

                if (vbo2.validVertices)
                {
                    cb_showCast2.Enabled = true;
                    cb_showCast2.Checked = vbo2.show;
                    showCast2ToolStripMenuItem.Enabled = true;
                    showCast2ToolStripMenuItem.Checked = vbo2.show;
                    lbox_selectCast.Items[1] = "Cast 2";
                }
                else
                {
                    cb_showCast2.Enabled = false;
                    cb_showCast2.Checked = false;
                    showCast2ToolStripMenuItem.Checked = false;
                    showCast2ToolStripMenuItem.Enabled = false;
                    lbox_selectCast.Items[1] = "Empty";
                }

                InsertSelectedPointsInListBox(lview_selectedPoints1, vbo1);
                InsertSelectedPointsInListBox(lview_selectedPoints2, vbo2);
            }

            for (int i = 0; i < 12; ++i)
                weightTextBoxex[i].Text = config.weights[i].ToString();

            nUpDown_order.Value = config.polynomialFitOrder;

            switch (config.fitFunction)
            {
                case Common.FitFunction.polynomial:
                    rb_fitPoly.Checked = true;
                    break;
                case Common.FitFunction.noroozi:
                    rb_fitNoroozi.Checked = true;
                    break;
            }
        }

        private void InsertSelectedPointsInListBox(ListView lbox_selectedPoints, Common.Vbo handle)
        {

            lbox_selectedPoints.Items.Clear();
            for (int i = 0; i < handle.selectedVertices.Count; i++)
            {
                Vector3 p = handle.verticesData.vertices[handle.selectedVertices[i]];
                string s = "";
                if (p.X > 0)
                    s += p.X.ToString(" 00.00");
                else
                    s += p.X.ToString("00.00");
                s += " | ";
                if (p.Y > 0)
                    s += p.Y.ToString(" 00.00");
                else
                    s += p.Y.ToString("00.00");
                s += " | ";
                if (p.Z > 0)
                    s += p.Z.ToString(" 00.00");
                else
                    s += p.Z.ToString("00.00");
                lbox_selectedPoints.Items.Add(s);

                if (i <= 12)
                    lbox_selectedPoints.Items[i].ForeColor = Common.Common.SelectColor[i];
                else
                    lbox_selectedPoints.Items[i].ForeColor = Color.Red;
                //lbox_selectedPoints.Items[i].Font.Height = 2;

            }
        }

        private void UpdateViewByValueInput()
        {
            try
            {
                angleX = float.Parse(tx_cameraAngleX.Text);
                angleY = float.Parse(tx_cameraAngleY.Text);
                angleZ = float.Parse(tx_cameraAngleZ.Text);
            }
            catch (FormatException e)
            {
                Common.Logger.Log("MainForm", "MainForm.cs", "UpdateViewByValueInput",
                    e.Message);
                tx_cameraAngleX.Text = angleX.ToString();
                tx_cameraAngleY.Text = angleY.ToString();
                tx_cameraAngleZ.Text = angleZ.ToString();
            }
        }

        private void B_UpdateRotation_Click(object sender, EventArgs e)
        {
            UpdateViewByValueInput();
            //glControlCast.Invalidate();
        }

        private void Tx_CameraAngleXYZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //    B_UpdateRotation_Click(sender, e);
                UpdateViewByValueInput();
                b_UpdateCameraRotation.Focus();
                e.Handled = true;
            }
        }

        private void Tx_RotateTranslate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //    B_UpdateRotation_Click(sender, e);
                B_RotateTranslate_Click(sender, e);
                b_RotateTranslate.Focus();
                e.Handled = true;
            }
        }

        private void Cb_AutoRotate_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_autoRotate.Checked)
                autoRotateFlag = true;
            else
                autoRotateFlag = false;
            UpdateUI();
        }

        private void Timer_10mill_Tick(object sender, EventArgs e)
        {
            if (autoRotateFlag)
            {
                angleZ += 1;
                angleZ %= 360;
            }
            //UpdateUI();
        }

        private void Cb_ShowPoints_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showPoints.Checked && rb_viewMesh.Checked)
            {
                flags.showPoints_MeshMode = true;
            }
            else
                flags.showPoints_MeshMode = false;
        }

        private void StopUpdatingUI()
        {
            timer_10mill.Stop();
        }

        private void StartUpdatingUI()
        {
            timer_10mill.Start();
        }

        private void Tx_AngleXYZ_Enter(object sender, EventArgs e)
        {
            StopUpdatingUI();
        }

        private void Tx_AngleXYZ_Leave(object sender, EventArgs e)
        {
            UpdateViewByValueInput();
            StartUpdatingUI();
        }

        private void ToolStripMI_TriangulatePointCloud_Click(object sender, EventArgs e)
        {
            if (GetSelectedVBO().validMesh)
            {
                MessageBox.Show("The Point Cloud is already triangulated.", "Triangulation Error");
                return;
            }

            status.Text = "Triangulating the Point Cloud...     (This may take several minutes)";

            Common.Vbo vbo = null;
            string inputFileAddress = "";

            switch (GetSelectedVbOIndex())
            {
                case 1:
                    vbo = vbo1;
                    inputFileAddress = config.lastLoadedMeshFileAddress1;
                    break;
                case 2:
                    vbo = vbo2;
                    inputFileAddress = config.lastLoadedMeshFileAddress2;
                    break;
            }


            string inputFileName = Path.GetFileName(inputFileAddress);
            if (vbo.validVertices)
            {
                if (vbo.validMesh)
                {
                    DialogResult res = MessageBox.Show("The Mesh " + inputFileName + " is already triangulated.", "Triangulation Warning");
                }
                else
                {
                    string outputMeshFile;
                    string tempFileName = inputFileAddress;
                    tempFileName = tempFileName.Replace(inputFileName, "temp.ply");//
                    WritePlyFile(tempFileName, vbo);
                    if ((outputMeshFile = Triangulate_MarchingCube_MeshLab(tempFileName, vbo, inputFileAddress)) != "error")
                    {
                        status.Text = "Triangulation completed successfully. New Mesh file: " + Path.GetFileName(outputMeshFile);
                        DialogResult res = MessageBox.Show("Do you want to load the new Mesh file: " + Path.GetFileName(outputMeshFile),
                            "Triangulation Complete",
                            MessageBoxButtons.YesNo);
                        if (res == System.Windows.Forms.DialogResult.Yes)
                        {
                            LoadMesh(outputMeshFile, GetSelectedVBO());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Triangulation encountered an error.", "Triangulation not successful!");
                        status.Text = "Trianulation was terminated due to an error.";
                    }
                    File.Delete(tempFileName);//
                }
            }
            else
                MessageBox.Show("There is no Point Cloud to triangulate. Load a Point Cloud first", "No Point Cloud");
        }

        private void VScroll_LightIntensity_OnScroll(object sender, ScrollEventArgs e)
        {
            config.lightIntensity = (float)(100 - vScroll_lightIntensity.Value) / 100;
            UpdateLighting();
        }

        private void B_Calculate_Click(object sender, EventArgs e)
        {

            switch (tab_Maintab.SelectedIndex)
            {
                case 0: // planes
                    int vboind = GetSelectedVbOIndex();
                    if (SelectedIndex == OCCLUSALPLANE_INDEX)
                    {
                        if (DefineOcclusalPlane(GetSelectedVBO(), ref Planes[vboind - 1][SelectedIndex], SelectedIndex))
                        {
                            UpdateTeethAndPlanesUI();
                            tcb[Plane_CB[vboind - 1][OCCLUSALPLANE_INDEX]].Checked = true;
                        }
                    }
                    else if (SelectedIndex == SAGITALPLANE_INDEX)
                    {
                        if (DefineSagitalPlane(GetSelectedVBO(), ref Planes[vboind - 1][SelectedIndex], SelectedIndex, Planes[vboind - 1][OCCLUSALPLANE_INDEX]))
                        {
                            UpdateTeethAndPlanesUI();
                            tcb[Plane_CB[vboind - 1][SAGITALPLANE_INDEX]].Checked = true;
                        }
                    }
                    break;
                case 5:
                    //Curve Fit
                    int num = GetSelectedVBO().selectedVertices.Count;
                    if (num < 2)
                    {
                        MessageBox.Show("At least 2 points needs to be selected in order to fit a polynomial curve.", "Error in Curve Fitting");
                        return;
                    }
                    CalculateCurveFit(GetSelectedVBO());
                    break;
                case 1: //Inclination
                case 2: //dislocation
                case 3: //distance to plane
                case 4: //superimposed Inclination                   
                    if (SelectedIndex < 1 || SelectedIndex > 34)
                    {
                        MessageBox.Show("No Tooth or Plane Selected. Select a tooth or plane first.", "Error in Calculation");
                        return;
                    }

                    if (SelectedIndex >= 1 && SelectedIndex <= 32)
                    {
                        switch (tab_Maintab.SelectedIndex)
                        {
                            case 1:
                            case 4:
                                //Inclination
                                if (GetSelectedVbOIndex() == 1)
                                {
                                    if (DefineTeethPlaneAndTangentLine(GetSelectedVBO(), ref Planes[0][SelectedIndex], SelectedIndex, Planes[0]))
                                        tcb[SelectedIndex].Checked = true;
                                }
                                else if (GetSelectedVbOIndex() == 2)
                                {
                                    if (DefineTeethPlaneAndTangentLine(GetSelectedVBO(), ref Planes[1][SelectedIndex], SelectedIndex, Planes[1]))
                                        tcb[SelectedIndex].Checked = true;

                                    if (Planes[0][OCCLUSALPLANE_INDEX] != null && Planes[0][OCCLUSALPLANE_INDEX].valid)
                                        DefineTeethPlaneAndTangentLine(GetSelectedVBO(), ref Planes[2][SelectedIndex], SelectedIndex, Planes[0]);
                                }

                                break;
                            case 2:
                                //Dislocation
                                CalculateDisLocation(this.SelectedIndex);
                                break;
                            case 3:
                                //Distance to Plane
                                CalculateDistanceToPlane(GetSelectedVBO(), this.SelectedIndex);
                                break;
                                /*case 3:
                                    //Superimposed Inclination
                                    if (GetSelectedVbOIndex() == 1)
                                    {
                                        DefineTeethPlaneAndTangentLine(GetSelectedVBO(), ref Planes[0][SelectedIndex], SelectedIndex, ref Planes[0]);

                                    }
                                    else if (GetSelectedVbOIndex() == 2)
                                    {
                                        DefineTeethPlaneAndTangentLine(GetSelectedVBO(), ref Planes[1][SelectedIndex], SelectedIndex, ref Planes[1]);

                                        if (Planes[0][OCCLUSALPLANE_INDEX] != null && Planes[0][OCCLUSALPLANE_INDEX].valid)
                                            DefineTeethPlaneAndTangentLine(GetSelectedVBO(), ref Planes[2][SelectedIndex], SelectedIndex, ref Planes[0]);                            
                                    }
                                    break;*/

                        }
                    }
                    break; //case 3
            }
            UpdateTeethAndPlanesUI();
        }
        
        #region LoadSave
        //LoadSave
        private void LoadPointCloud_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryCheck("XYZ");

            try
            {
                OpenFileDialog lfd = new OpenFileDialog()
                {
                    InitialDirectory = Directory.GetCurrentDirectory() + "\\XYZ",
                    AddExtension = true,
                    DefaultExt = ".xyz"
                };


                DialogResult result = lfd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && lfd.FileName != "")
                {
                    LoadPointCloud(lfd.FileName, GetSelectedVBO());
                }
                Common.Logger.Log("MainForm", "MainForm", "LoadPointCloud_ToolStripMenuItem_Click", "Point Cloud file loaded", false);
                status.Text = "Point Cloud loaded: " + Path.GetFileName(lfd.FileName);
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "MainForm", "LoadPointCloud_ToolStripMenuItem_Click", err.Message, true);
                MessageBox.Show("Point Cloud file was not in the correct format.", "Error loading Point Cloud");
            }


        }

        private void LoadMesh_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryCheck("Mesh");

            try
            {
                OpenFileDialog lfd = new OpenFileDialog()
                {
                    InitialDirectory = Directory.GetCurrentDirectory() + "\\Mesh",
                    //FileName = inputTriFileName,
                    AddExtension = true
                };


                DialogResult result = lfd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && lfd.FileName != "")
                {
                    LoadMesh(lfd.FileName, GetSelectedVBO());
                }
                Common.Logger.Log("MainForm", "MainForm", "LoadMesh_ToolStripMenuItem_Click", "Mesh file loaded", false);
                status.Text = "Mesh loaded: " + Path.GetFileName(lfd.FileName);
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "MainForm", "LoadMesh_ToolStripMenuItem_Click", err.Message, true);
                MessageBox.Show("Mesh file was not in the correct format.", "Error loading Mesh");
            }
        }

        private void ToolStripMI_SaveMesh_Click(object sender, EventArgs e)
        {
            if (!GetSelectedVBO().validVertices)
                return;
            try
            {
                Common.Vbo vbo = null;
                string directory;
                string saveFileName = "";
                string addr = "";
                switch (GetSelectedVbOIndex())
                {
                    case 1:
                        vbo = vbo1;
                        saveFileName = config.lastLoadedMeshName1;
                        addr = config.lastLoadedMeshFileAddress1;
                        break;
                    case 2:
                        vbo = vbo2;
                        saveFileName = config.lastLoadedMeshName2;
                        addr = config.lastLoadedMeshFileAddress2;
                        break;
                }

                //changed the next line, so that the saving directory would be the same as the loaded directory of the mesh file.
                if (true)
                {
                    directory = Directory.GetParent(addr).FullName;
                }
                else
                {
#pragma warning disable CS0162 // Unreachable code detected
                    if (vbo.validMesh)
#pragma warning restore CS0162 // Unreachable code detected
                        directory = Directory.GetCurrentDirectory() + "\\" + "Mesh";
                    else
                        directory = Directory.GetCurrentDirectory() + "\\" + "XYZ";
                }

                DirectoryCheck(directory);

                SaveFileDialog sfd = new SaveFileDialog()
                {
                    InitialDirectory = directory,
                    FileName = saveFileName,
                    AddExtension = true,
                    DefaultExt = "ply",
                    Filter = "PLY 3D File|*.ply"
                };

                DialogResult result = sfd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    WritePlyFile(sfd.FileName, vbo);
                    if (vbo.validMesh)
                        UpdateFileRelatedConfiguration(ref vbo, sfd.FileName, "mesh");
                    else if (vbo.validVertices)
                        UpdateFileRelatedConfiguration(ref vbo, sfd.FileName, "point cloud");
                }
                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_SaveMesh_Click", "Mesh file saved", false);
                status.Text = "Mesh file saved: " + Path.GetFileName(sfd.FileName);
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_SaveMesh_Click", err.Message, true);
                MessageBox.Show("Mesh file was not saved successfully.", "Error saving the Mesh file");
            }

        }

        private void New_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset(ref vbo1);
            Reset(ref vbo2);
            Reset(ref reduceDensityVbo);
        }

        private void ToolStripMI_SaveCalculations_Click(object sender, EventArgs e)
        {
            //DirectoryCheck("Calculations");

            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                //sfd.InitialDirectory = Directory.GetCurrentDirectory() + "\\Calculations";
                string addr = config.lastLoadedMeshFileAddress1;
                sfd.InitialDirectory = Directory.GetParent(addr).FullName;
                /*switch (GetSelectedVbOIndex())
                {
                    case 1:
                        sfd.FileName = config.lastLoadedMeshName1;
                        break;
                    case 2:
                        sfd.FileName = config.lastLoadedMeshName2;
                        break;
                    default:
                        sfd.FileName = "calculationFile";
                        break;
                }*/

                sfd.AddExtension = true;
                sfd.DefaultExt = "caltxt";
                sfd.Filter = "Cal and Text File|*.cal,*.txt|OrthoAid Calculation File|*.cal|Text File|*.txt";

                //if (Path.GetExtension(sfd.FileName) == ".caltxt")
                {

                    if (vbo1.validMesh)
                    {
                        sfd.FileName = config.lastLoadedMeshName1;
                        sfd.Title = "Save Cast1 Calculations as...";
                        DialogResult result = sfd.ShowDialog();
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            WriteCalculationResults_Cal(sfd.FileName.Replace(".caltxt", ".cal"), 1);
                        }
                    }

                    if (vbo2.validMesh)
                    {
                        sfd.FileName = config.lastLoadedMeshName2;
                        sfd.Title = "Save Cast2 Calculations as...";
                        DialogResult result = sfd.ShowDialog();
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            WriteCalculationResults_Cal(sfd.FileName.Replace(".caltxt", ".cal"), 2);
                        }
                    }
                    WriteCalculationResults_txt(sfd.FileName.Replace(".caltxt", ".txt"));
                }

                /*DialogResult result = sfd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (Path.GetExtension(sfd.FileName) == ".caltxt")
                    {
                        if (vbo1.validMesh)
                        {
                            sfd.FileName = config.lastLoadedMeshName1;
                            WriteCalculationResults_Cal(config.lastLoadedMeshName1+ ".cal", 1);                            
                        }
                        if (vbo2.validMesh)
                        {
                            sfd.FileName = config.lastLoadedMeshName2;
                            WriteCalculationResults_Cal(config.lastLoadedMeshName2+ ".cal", 2);                            
                        }

                        WriteCalculationResults_txt(sfd.FileName.Replace(".caltxt", ".txt"));                        
                    }

                    else if (Path.GetExtension(sfd.FileName) == ".cal")
                    {
                        if (vbo1.validMesh)
                        {
                            WriteCalculationResults_Cal(config.lastLoadedMeshName1 + ".cal", 1);
                        }
                        if (vbo2.validMesh)
                        {
                            WriteCalculationResults_Cal(config.lastLoadedMeshName2 + ".cal", 2);
                        }
                    }
                    else if (Path.GetExtension(sfd.FileName) == ".txt")
                        WriteCalculationResults_txt(sfd.FileName.Replace(".caltxt", ".txt"));
                }*/

                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_SaveCalculations_Click", "Calculation file saved", false);
                status.Text = "Calculation file saved: " + Path.GetFileName(sfd.FileName);
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_SaveCalculations_Click", err.Message, true);
                MessageBox.Show("Calculation file was not saved successfully.", "Error saving the calculation file");
            }
        }

        private void ToolStripMI_LoadCalculations_Click(object sender, EventArgs e)
        {
            //DirectoryCheck("Calculations");

            try
            {
                OpenFileDialog lfd = new OpenFileDialog();
                //lfd.InitialDirectory = Directory.GetCurrentDirectory() + "\\Calculations";
                string addr = config.lastLoadedMeshFileAddress1;
                lfd.InitialDirectory = Directory.GetParent(addr).FullName;

                switch (GetSelectedVbOIndex())
                {
                    case 1:
                        lfd.FileName = config.lastLoadedMeshName1;
                        break;
                    case 2:
                        lfd.FileName = config.lastLoadedMeshName2;
                        break;
                    default:
                        lfd.FileName = "calculationFile";
                        break;
                }

                lfd.AddExtension = true;
                lfd.DefaultExt = "cal";
                lfd.Multiselect = true;
                lfd.Filter = "OrthoAid Calculation File|*.cal"; //|Text File|*.txt"; not supporting reading text files anymore

                DialogResult result = lfd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (Path.GetExtension(lfd.FileName) == ".cal")
                        ReadCalculationResults_Cal(lfd.FileName);
                    //if (Path.GetExtension(lfd.FileName) == ".txt")
                    //ReadCalculationResults_txt(lfd.FileName);
                }



                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_LoadCalculations_Click", "Calculation file loaded", false);
                status.Text = "Calculation file loaded: " + Path.GetFileName(lfd.FileName);
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_LoadCalculations_Click", err.Message, true);
                MessageBox.Show("Calculation file not loaded successfully.", "Error loading the calculation file");
            }
        }

        private void ToolStripMI_SaveSelection_Click(object sender, EventArgs e)
        {
            //DirectoryCheck("Selection");

            if (GetSelectedVBO().selectedVertices.Count == 0)
            {
                MessageBox.Show("No point selected to save", "Error Saving Selection File");
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog();

                // save in selection directory
                //sfd.InitialDirectory = Directory.GetCurrentDirectory() + "\\Selection";

                //save in the MeshFile_1 directory
                string addr = config.lastLoadedMeshFileAddress1;
                sfd.InitialDirectory = Directory.GetParent(addr).FullName;

                sfd.AddExtension = true;
                sfd.DefaultExt = "sel";
                sfd.Filter = "OrthoAid Selection File|*.sel";


                if (vbo1.selectedVertices.Count > 0)
                {
                    sfd.FileName = config.lastLoadedMeshName1;
                    sfd.Title = "Save Cast1 Selection as...";
                    DialogResult result = sfd.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        WriteSelectionFile(sfd.FileName, vbo1);
                    }
                }

                if (vbo2.selectedVertices.Count > 0)
                {
                    sfd.FileName = config.lastLoadedMeshName2;
                    sfd.Title = "Save Cast2 Selection as...";
                    DialogResult result = sfd.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        WriteSelectionFile(sfd.FileName, vbo2);
                    }
                }

                if (vbo1.selectedVertices.Count > 0 && vbo2.selectedVertices.Count > 0)
                {
                    sfd.AddExtension = true;
                    sfd.DefaultExt = "xlsx";
                    sfd.Filter = "Excel File|*.xlsx";

                    sfd.FileName = config.lastLoadedMeshName1;//"ExcelSelectionFile";
                    sfd.Title = "Save Cast1 and Cast2 Selection as Excel file";
                    DialogResult result = sfd.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        WriteExcelSelectionFile(sfd.FileName);
                    }
                }

                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_SaveSelection_Click", "Selection file saved", false);
                status.Text = "Selection file saved: " + Path.GetFileName(sfd.FileName);


                ////Extra for simplifying the difference of landmarks
                //if (vbo1.validVertices && vbo2.validVertices &&
                //    vbo1.selectedVertices.Count == vbo2.selectedVertices.Count)
                //{
                //    TextWriter tw = new StreamWriter(File.Create(sfd.FileName + "D"));

                //    for (int i = 0; i < vbo1.selectedVertices.Count; i++)
                //    {
                //        Vector3 p = (vbo1.verticesData.vertices[vbo1.selectedVertices[i]] -
                //            (vbo2.verticesData.vertices[vbo2.selectedVertices[i]]));
                //        tw.Write(p.X.ToString() + ',' + p.Y.ToString() + ',' + p.Z.ToString() +
                //                    ",");
                //    }
                //    tw.Close();
                //}
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_SaveSelection_Click", err.Message, true);
                MessageBox.Show("Selection file was not saved successfully.", "Error saving the selection file");
            }
        }

        private void ToolStripMI_LoadSelection_Click(object sender, EventArgs e)
        {
            //DirectoryCheck("Selection");

            if (!GetSelectedVBO().validVertices)
            {
                MessageBox.Show("The mesh does not own any vertices to load the selection.", "Error Loading Selection File");
                return;
            }

            try
            {
                OpenFileDialog lfd = new OpenFileDialog();

                // load in selection directory
                //lfd.InitialDirectory = Directory.GetCurrentDirectory() + "\\Selection";

                //save in the MeshFile_1 directory
                string addr;



                switch (GetSelectedVbOIndex())
                {
                    case 1:
                        lfd.FileName = config.lastLoadedMeshName1;
                        addr = config.lastLoadedMeshFileAddress1;
                        break;
                    case 2:
                        lfd.FileName = config.lastLoadedMeshName2;
                        addr = config.lastLoadedMeshFileAddress2;
                        break;
                    default:
                        lfd.FileName = "selectionFile";
                        addr = Directory.GetCurrentDirectory() + "\\Selection";
                        break;
                }
                lfd.InitialDirectory = Directory.GetParent(addr).FullName;

                lfd.AddExtension = true;
                lfd.DefaultExt = "sel";
                lfd.Multiselect = true;
                lfd.Filter = "OrthoAid Selection File|*.sel";

                DialogResult result = lfd.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {

                    ReadSelectionFile(lfd.FileName, GetSelectedVBO());
                }

                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_LoadSelection_Click", "Selection file loaded", false);
                status.Text = "Selection file loaded: " + Path.GetFileName(lfd.FileName);
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "MainForm", "ToolStripMI_LoadSelection_Click", err.Message, true);
                MessageBox.Show("Selection file not loaded successfully.", "Error loading the selection file");
            }
        }
        //End of LoadSave
        #endregion            

        private void B_PreviewReduceDensity_Click(object sender, EventArgs e)
        {
            status.Text = "Reducing Point Cloud density to " + config.ReduceDensityThreshold.ToString() + "...";

            Application.DoEvents();

            Vector3[] newNormals;
            Vector3[] newVertices;
            if (ReducePointDensity(GetSelectedVBO().verticesData.vertices, GetSelectedVBO().verticesData.normals,
                out newVertices, out newNormals))
            {
                Reset(ref reduceDensityVbo);
                LoadVertices_Normals(ref reduceDensityVbo, newVertices, newNormals);

                vbo2.show = false;
                vbo1.show = false;
                reduceDensityVbo.show = true;


                rb_viewPoints.Checked = true;

            }

            status.Text = "Reduced Point Cloud preview is ready.";
        }

        private void B_ApplyReduceDensity_Click(object sender, EventArgs e)
        {
            DirectoryCheck("XYZ");
            SaveFileDialog sfd = new SaveFileDialog()
            {
                InitialDirectory = Directory.GetCurrentDirectory() + "\\XYZ",
                FileName =
                    config.lastLoadedMeshName1 + "_DensityReduced" + config.ReduceDensityThreshold.ToString("f2"),
                AddExtension = true,
                DefaultExt = "xyz"
            };

            DialogResult result = sfd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                WriteXYZFile(sfd.FileName, reduceDensityVbo.verticesData.vertices, reduceDensityVbo.verticesData.normals);
                config.lastLoadedMeshName1 = config.lastLoadedMeshName1 + "_DensityReduced";
                config.lastLoadedMeshType1 = "point cloud";
                config.lastLoadedMeshFileAddress1 = sfd.FileName;

                Reset(ref reduceDensityVbo);
                LoadPointCloud(sfd.FileName, GetSelectedVBO());
            }
            else
            {
                //MessageBox.Show("New Point Cloud was not saved", "Point Cloud not saved");
            }

            UpdateUI();
        }

        private void B_CancelReduceDensity_Click(object sender, EventArgs e)
        {
            reduceDensityVbo.show = false;
            Reset(ref reduceDensityVbo);


            if (vbo1.validVertices)
                vbo1.show = true;
            if (vbo2.validVertices)
                vbo2.show = true;

            UpdateUI();
        }

        private void UpdateFileRelatedConfiguration(ref Common.Vbo handle, string fileAddress, string mesh_point)
        {
            if (handle.vboName == "vbo1")
            {
                config.lastLoadedMeshName1 = Path.GetFileNameWithoutExtension(fileAddress);
                config.lastLoadedMeshFileAddress1 = fileAddress;
                config.lastLoadedMeshType1 = mesh_point;
            }
            else if (handle.vboName == "vbo2")
            {
                config.lastLoadedMeshName2 = Path.GetFileNameWithoutExtension(fileAddress);
                config.lastLoadedMeshFileAddress2 = fileAddress;
                config.lastLoadedMeshType2 = mesh_point;
            }
        }

        private void MeshInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MeshInfoForm form = new MeshInfoForm(vbo1.verticesStats, vbo2.verticesStats);
                form.ShowDialog();
                Common.Logger.Log("MainForm", "MainForm", "MeshInfoToolStripMenuItem_Click", "meshinfo viewed", false);
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "MainForm", "MeshInfoToolStripMenuItem_Click", err.Message, true);
            }

        }

        private void ToolStripMI_DeleteNoisyPoints_Click(object sender, EventArgs e)
        {
            status.Text = "Deleting Noisy Points";
            int numDels;
            if (GetSelectedVBO().validMesh)
            {
                MessageBox.Show("The Point Cloud is already triangulated and can't delete any points.", "Deleting Noisy Points Error");
                return;
            }
            numDels = DeleteNoisyPoints(GetSelectedVBO());
            status.Text = numDels.ToString() + " points were considered noisy and deleted.";
        }

        private void GlControlCast_SizeChanged(object sender, EventArgs e)
        {
            SetViewPort();
            SetCamera();
        }

        private void ToolStripMI_ComputeNormals_Click(object sender, EventArgs e)
        {
            if (GetSelectedVBO().validMesh)
            {
                MessageBox.Show("The Point Cloud is already triangulated and the normals are ready to use.", "Normal Estimation Error");
                return;
            }

            ComputeNormalsForm f;

            f = new ComputeNormalsForm(this, GetSelectedVBO());

            f.ShowDialog();
            switch (f.result)
            {
                case "cancel":
                    status.Text = "Normals calculation canceled.";
                    break;
                case "error":
                    MessageBox.Show("An error occured in computing the normals for the Point Cloud", "Error in Normal Calculation");
                    status.Text = "Normals calculation failed.";
                    break;
                default:
                    if (File.Exists(f.result))
                    {
                        status.Text = "Normals computed for the Point Cloud.";
                        LoadPointCloud(f.result, GetSelectedVBO());
                    }
                    break;
            }

        }

        private void Rb_BBPuser_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_BBPuser.Checked)
                config.bbpChoice = Common.BBPChoice.User;
        }

        private void Rb_BBCmiddle_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_BBCmiddle.Checked)
                config.bbpChoice = Common.BBPChoice.AutoMiddle;
        }

        private void LabelSelect(object sender, EventArgs e)
        {
            DeselectAllLabelsAndButtons();
            SelectedIndex = int.Parse(((Label)sender).Tag.ToString());
            ((Label)sender).BorderStyle = BorderStyle.FixedSingle;

            //if (DefineTangentFBB(selectedToothIndex))
            //{
            //    tcb[selectedToothIndex].Checked = true;

            //}
        }

        #region RotateTranslateCast
        //Rotate and Translate Cast
        private void B_RotateTranslate_Click(object sender, EventArgs e)
        {
            float rx, ry, rz, tx, ty, tz;
            try
            {
                rx = float.Parse(tx_rotateAngleX.Text) / 180 * (float)Math.PI;
            }
            catch
            {
                rx = 0;
            }
            try
            {
                ry = float.Parse(tx_rotateAngleY.Text) / 180 * (float)Math.PI;
            }
            catch
            {
                ry = 0;
            }
            try
            {
                rz = float.Parse(tx_rotateAngleZ.Text) / 180 * (float)Math.PI;
            }
            catch
            {
                rz = 0;
            }
            try
            {
                tx = float.Parse(tx_translateX.Text);
            }
            catch
            {
                tx = 0;
            }
            try
            {
                ty = float.Parse(tx_translateY.Text);
            }
            catch
            {
                ty = 0;
            }
            try
            {
                tz = float.Parse(tx_translateZ.Text);
            }
            catch
            {
                tz = 0;
            }

            tx_rotateAngleX.Text = "0";
            tx_rotateAngleY.Text = "0";
            tx_rotateAngleZ.Text = "0";
            tx_translateX.Text = "0";
            tx_translateY.Text = "0";
            tx_translateZ.Text = "0";
            //}
            //catch (Exception err)
            //{
            //    Common.Logger.Log("MainForm", "MainForm", "B_RotateTranslate_Click", err.Message, true);
            //    return;
            //}

            TranslateRotate(GetSelectedVBO(), rx, ry, rz, tx, ty, tz);
            UpdateUI();
        }

        private void CentralizeCast(Common.Vbo handle)
        {

            for (int i = 0; i < handle.verticesData.vertices.Length; i++)
            {
                handle.verticesData.vertices[i] -= handle.verticesStats.Mean;
            }

            ReLoadBuffer(BufferTarget.ArrayBuffer, handle.VboVertices, handle.verticesData.vertices);
            InitVerticesStats(ref handle);
        }
        //
        #endregion

        private void Tx_Enter(object sender, EventArgs e)
        {
            //this.KeyDown -= MainForm_KeyDown;
        }

        private void Tx_LeaveFocus(object sender, EventArgs e)
        {
            //this.KeyDown += MainForm_KeyDown;
        }

        private void Cb_ShowCast1_CheckedChanged(object sender, EventArgs e)
        {
            vbo1.show = cb_showCast1.Checked;
            UpdateUI();
        }

        private void Cb_ShowCast2_CheckedChanged(object sender, EventArgs e)
        {
            vbo2.show = cb_showCast2.Checked;
            UpdateUI();
        }

        private void TStrip_Ruler_Click(object sender, EventArgs e)
        {
            Ruler_PointAIndex = NO_VERTEX_INDEX;
            Ruler_PointBIndex = NO_VERTEX_INDEX;
            status.Text = "Choose 2 points to calculate the distance";
            config.editMode = Common.EditMode.Ruler;
            UpdateUI();
        }

        private void TStrip_Hand_Click(object sender, EventArgs e)
        {
            config.editMode = Common.EditMode.Hand;
            UpdateUI();
        }

        private void Tstrip_Select_Click(object sender, EventArgs e)
        {
            config.editMode = Common.EditMode.Select;
            UpdateUI();
        }

        private void B_SuperImpose_Click(object sender, EventArgs e)
        {
            if (vbo1.selectedVertices.Count != vbo2.selectedVertices.Count)
            {
                MessageBox.Show("Same number of reference points needs to be selected to perform superimposition.", "Superimposition Error");
                return;
            }
            else if (vbo1.selectedVertices.Count < 3)
            {
                MessageBox.Show("You need at least 3 points to perform superimposition.", "Superimposition Error");
                return;
            }

            Superimpose();
        }

        private void ToolStripMI_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TStrip_LockSelection_Click(object sender, EventArgs e)
        {
            //tstrip_lockSelection.Checked = !tstrip_lockSelection.Checked;
            if (tstrip_lockSelection.Checked)
            {
                lockSelection = true;
            }
            else
                lockSelection = false;
        }

        private void ToolStripMI_ShowCast1_Click(object sender, EventArgs e)
        {
            vbo1.show = showCast1ToolStripMenuItem.Checked;
            UpdateUI();
        }

        private void ToolStripMI_ShowCast_Click(object sender, EventArgs e)
        {
            vbo2.show = showCast2ToolStripMenuItem.Checked;
            UpdateUI();
        }

        private void ToolStripMI_InverseCastShow_Click(object sender, EventArgs e)
        {
            vbo1.show = !vbo1.show;
            vbo2.show = !vbo2.show;
            if ((vbo1.show && vbo2.show) || (!vbo1.show && !vbo2.show))
                SelectedCast = (1 - SelectedCast);
            else
            {
                if (vbo1.show)
                    SelectedCast = 0;
                else
                    SelectedCast = 1;
            }

            UpdateUI();
        }

        private void B_ClearSelection_Click(object sender, EventArgs e)
        {
            ClearSelection(vbo1);
            ClearSelection(vbo2);
        }

        private void B_ClearCalculations_Click(object sender, EventArgs e)
        {

            for (int i = 1; i <= 34; i++)
            {
                Planes[0][i] = null;
                Planes[1][i] = null;
                Planes[2][i] = null;
            }

            UpdateTeethAndPlanesUI();

            for (int i = 1; i <= 32; i++)
            {
                Dislocations[i].valid = false;
                Distance2OcclusalPlane1[i].valid = false;
                Distance2SagitalPlane1[i].valid = false;
                Distance2OcclusalPlane2[i].valid = false;
                Distance2SagitalPlane2[i].valid = false;
            }
        }

        private void LBox_SelectCast_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCast = lbox_selectCast.SelectedIndex;
            UpdateTeethAndPlanesUI();
        }

        private void DigitTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.'
                && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void LView_SelectedPoints_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Common.Vbo vbo;
                if (((ListView)sender).Name == "lview_selectedPoints1")
                    vbo = vbo1;
                else
                    vbo = vbo2;
                ListView.SelectedIndexCollection indexes = ((ListView)sender).SelectedIndices;
                for (int i = indexes.Count - 1; i >= 0; i--)
                {
                    UnmarkSelectedVertex(ref vbo, vbo.selectedVertices[indexes[i]]);
                    vbo.selectedVertices.RemoveAt(indexes[i]);
                }
                UpdateUI();
            }
        }

        private void ToolStripMI_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
@"To superimpose two casts follow the 3 steps:
1) Both casts need to be rotated so that they are exactly aligned by the coordination axes
        X-Axis (Red Line)   --> Transverse Direction
        Y-Axis (Green Line) --> AnteroPosterior Direction
        Z-Axis (Blue)       --> Vertical Direction
2) Same number of points need to be selected on both casts.
3) Click on Superimpose button.


To calculate the Inclination of teeth follow the steps:
1) Define the occlusal plane (A.Select three points on occlusal plane, B.Click on OcclusalPlane button, C.Click on Calculate button)
2) Select three points on the buccal side of the tooth on this order:
        First point  --> Most gingivally (on mid CEJ)
        Second point --> On the middle (on buccal bracket point)
        Third point  --> On the mid incisal/occlusal 
3) Click on Calculate button", "Help on OrthoAid");
        }

        private void ToolStripMI_AboutOrthoAid_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
@"The application is designed and implemented by Amir H. Abdi under supervision of Prof. Mahtab Nouri.
Permission to use, copy, modify, and distribute this software for educational, research, and commercial purposes, without a signed licensing agreement is prohibited.

Contact: amir.h.abdi@gmail.com

All Rights Preserved.", "OrthoAid V11.4");
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                LoadMesh(files[0], GetSelectedVBO());
                Common.Logger.Log("MainForm", "MainForm", "MainForm_DragDrop", "Mesh file loaded", false);
                status.Text = "Mesh loaded: " + Path.GetFileName(files[0]);
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "MainForm", "MainForm_DragDrop", err.Message, true);
                MessageBox.Show("Mesh file was not in the correct format.", "Error loading Mesh");
            }

        }

        private void Tx_Weight_TextChanged(object sender, EventArgs e)
        {

            try
            {
                config.weights[int.Parse(((TextBox)sender).Tag.ToString())] = double.Parse(((TextBox)sender).Text);
            }
            catch (Exception err)
            {
                Common.Logger.Log("MainForm", "Mainform.cs", "Tx_Weight_TextChanged",
                    err.Message, true);
                config.weights[int.Parse(((TextBox)sender).Tag.ToString())] = 1;
            }

        }

        private void B_Expand_Click(object sender, EventArgs e)
        {
            toolboxPanel_p.Visible = true;
        }

        private void B_Collapse_Click(object sender, EventArgs e)
        {
            toolboxPanel_p.Visible = false;
        }

        private void Tab_Maintab_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tab_Maintab.SelectedIndex)
            {
                case 0: //planes
                case 5: //curve fit
                    gb_teeh.Visible = false;
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    gb_teeh.Visible = true;
                    break;
            }
        }

        private void B_CleftProj_Click(object sender, EventArgs e)
        {
            Vector3 TL = vbo1.verticesData.vertices[vbo1.selectedVertices[0]];
            Vector3 TR = vbo1.verticesData.vertices[vbo1.selectedVertices[1]];
            Vector3 CLL = vbo1.verticesData.vertices[vbo1.selectedVertices[2]];
            Vector3 CLR = vbo1.verticesData.vertices[vbo1.selectedVertices[3]];
            Vector3 P = vbo1.verticesData.vertices[vbo1.selectedVertices[4]];

            Vector3 T = (TL + TR) / 2;
            Common.Plane sagPlane = new Common.Plane(TL - TR, T);
            float PTP = sagPlane.Angle2Vector(P - T);
        }

        private void NumUD_Order_ValueChanged(object sender, EventArgs e)
        {
            config.polynomialFitOrder = nUpDown_order.Value;
        }

        private void Rb_FitFunction_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_fitPoly.Checked)
                config.fitFunction = Common.FitFunction.polynomial;
            else if (rb_fitNoroozi.Checked)
                config.fitFunction = Common.FitFunction.noroozi;
        }        
    }
}
