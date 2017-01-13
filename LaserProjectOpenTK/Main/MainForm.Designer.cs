using System.IO;
namespace OrthoAid_3DSimulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.glControlCast = new OpenTK.GLControl();
            this.gb_viewMode = new System.Windows.Forms.GroupBox();
            this.cb_showPoints = new System.Windows.Forms.CheckBox();
            this.rb_viewMesh = new System.Windows.Forms.RadioButton();
            this.rb_viewWireFrame = new System.Windows.Forms.RadioButton();
            this.rb_viewPoints = new System.Windows.Forms.RadioButton();
            this.tx_cameraAngleX = new System.Windows.Forms.TextBox();
            this.tx_cameraAngleY = new System.Windows.Forms.TextBox();
            this.tx_cameraAngleZ = new System.Windows.Forms.TextBox();
            this.lb_ViewAngleX = new System.Windows.Forms.Label();
            this.lb_ViewAngleY = new System.Windows.Forms.Label();
            this.lb_ViewangleZ = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_UpdateCameraRotation = new System.Windows.Forms.Button();
            this.cb_autoRotate = new System.Windows.Forms.CheckBox();
            this.timer_10mill = new System.Windows.Forms.Timer(this.components);
            this.lb_selectedPoints1 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadPointCloudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMeshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMeshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadCalculationFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCalculationFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.loadSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangulatePointCloudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meshInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteNoisyPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computeNormalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.showCast1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCast2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverseCastShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutOrthoAidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_numVertices1 = new System.Windows.Forms.Label();
            this.lb_numFaces1 = new System.Windows.Forms.Label();
            this.lb_meshName1 = new System.Windows.Forms.Label();
            this.numUD_densityReduceThreshold = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.b_cancelReduceDensity = new System.Windows.Forms.Button();
            this.b_previewReduceDensity = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.b_applyReduceDensity = new System.Windows.Forms.Button();
            this.lb_meshName2 = new System.Windows.Forms.Label();
            this.lb_numFaces2 = new System.Windows.Forms.Label();
            this.lb_numVertices2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbox_selectCast = new System.Windows.Forms.ListBox();
            this.cb_showCast2 = new System.Windows.Forms.CheckBox();
            this.cb_showCast1 = new System.Windows.Forms.CheckBox();
            this.gb_cast1 = new System.Windows.Forms.GroupBox();
            this.gb_cast2 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.b_RotateTranslate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tx_translateX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tx_translateY = new System.Windows.Forms.TextBox();
            this.tx_translateZ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tx_rotateAngleX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tx_rotateAngleY = new System.Windows.Forms.TextBox();
            this.tx_rotateAngleZ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_selectedPoints2 = new System.Windows.Forms.Label();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tstrip_Hand = new System.Windows.Forms.ToolStripButton();
            this.tstrip_Select = new System.Windows.Forms.ToolStripButton();
            this.tstrip_Ruler = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tstrip_lockSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.lview_selectedPoints1 = new System.Windows.Forms.ListView();
            this.Selected_Points1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lview_selectedPoints2 = new System.Windows.Forms.ListView();
            this.Selected_Points2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.b_Calculate = new System.Windows.Forms.Button();
            this.b_clearSelection = new System.Windows.Forms.Button();
            this.b_superImpose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.vScroll_lightIntensity = new System.Windows.Forms.VScrollBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.b_clearCalculations = new System.Windows.Forms.Button();
            this.tab_Maintab = new System.Windows.Forms.TabControl();
            this.tab_Planes = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.lb_occlusalPlanesAngle = new System.Windows.Forms.Label();
            this.lb_saggitalPlane = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_saggitalPlane1 = new System.Windows.Forms.CheckBox();
            this.cb_occlusalPlane2 = new System.Windows.Forms.CheckBox();
            this.cb_saggitalPlane2 = new System.Windows.Forms.CheckBox();
            this.cb_occlusalPlane1 = new System.Windows.Forms.CheckBox();
            this.lb_occlusalPlane = new System.Windows.Forms.Label();
            this.tab_Inclination = new System.Windows.Forms.TabPage();
            this.cb_t16 = new System.Windows.Forms.CheckBox();
            this.cb_t15 = new System.Windows.Forms.CheckBox();
            this.cb_t14 = new System.Windows.Forms.CheckBox();
            this.cb_t13 = new System.Windows.Forms.CheckBox();
            this.cb_t12 = new System.Windows.Forms.CheckBox();
            this.cb_t11 = new System.Windows.Forms.CheckBox();
            this.cb_t10 = new System.Windows.Forms.CheckBox();
            this.cb_t9 = new System.Windows.Forms.CheckBox();
            this.cb_t8 = new System.Windows.Forms.CheckBox();
            this.cb_t7 = new System.Windows.Forms.CheckBox();
            this.cb_t6 = new System.Windows.Forms.CheckBox();
            this.cb_t5 = new System.Windows.Forms.CheckBox();
            this.cb_t4 = new System.Windows.Forms.CheckBox();
            this.cb_t3 = new System.Windows.Forms.CheckBox();
            this.cb_t2 = new System.Windows.Forms.CheckBox();
            this.cb_t1 = new System.Windows.Forms.CheckBox();
            this.cb_t17 = new System.Windows.Forms.CheckBox();
            this.cb_t18 = new System.Windows.Forms.CheckBox();
            this.cb_t19 = new System.Windows.Forms.CheckBox();
            this.cb_t20 = new System.Windows.Forms.CheckBox();
            this.cb_t21 = new System.Windows.Forms.CheckBox();
            this.cb_t22 = new System.Windows.Forms.CheckBox();
            this.cb_t23 = new System.Windows.Forms.CheckBox();
            this.cb_t24 = new System.Windows.Forms.CheckBox();
            this.cb_t25 = new System.Windows.Forms.CheckBox();
            this.cb_t26 = new System.Windows.Forms.CheckBox();
            this.cb_t27 = new System.Windows.Forms.CheckBox();
            this.cb_t32 = new System.Windows.Forms.CheckBox();
            this.cb_t31 = new System.Windows.Forms.CheckBox();
            this.cb_t30 = new System.Windows.Forms.CheckBox();
            this.cb_t28 = new System.Windows.Forms.CheckBox();
            this.cb_t29 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rb_BBCmiddle = new System.Windows.Forms.RadioButton();
            this.rb_BBPuser = new System.Windows.Forms.RadioButton();
            this.v1t17 = new System.Windows.Forms.Label();
            this.v1t18 = new System.Windows.Forms.Label();
            this.v1t25 = new System.Windows.Forms.Label();
            this.v1t26 = new System.Windows.Forms.Label();
            this.v1t19 = new System.Windows.Forms.Label();
            this.v1t27 = new System.Windows.Forms.Label();
            this.v1t20 = new System.Windows.Forms.Label();
            this.v1t28 = new System.Windows.Forms.Label();
            this.v1t21 = new System.Windows.Forms.Label();
            this.v1t29 = new System.Windows.Forms.Label();
            this.v1t22 = new System.Windows.Forms.Label();
            this.v1t30 = new System.Windows.Forms.Label();
            this.v1t32 = new System.Windows.Forms.Label();
            this.v1t23 = new System.Windows.Forms.Label();
            this.v1t31 = new System.Windows.Forms.Label();
            this.v1t24 = new System.Windows.Forms.Label();
            this.v1t16 = new System.Windows.Forms.Label();
            this.v1t15 = new System.Windows.Forms.Label();
            this.v1t8 = new System.Windows.Forms.Label();
            this.v1t1 = new System.Windows.Forms.Label();
            this.v1t7 = new System.Windows.Forms.Label();
            this.v1t9 = new System.Windows.Forms.Label();
            this.v1t14 = new System.Windows.Forms.Label();
            this.v1t2 = new System.Windows.Forms.Label();
            this.v1t6 = new System.Windows.Forms.Label();
            this.v1t10 = new System.Windows.Forms.Label();
            this.v1t13 = new System.Windows.Forms.Label();
            this.v1t3 = new System.Windows.Forms.Label();
            this.v1t5 = new System.Windows.Forms.Label();
            this.v1t12 = new System.Windows.Forms.Label();
            this.v1t4 = new System.Windows.Forms.Label();
            this.v1t11 = new System.Windows.Forms.Label();
            this.tab_Dislocation = new System.Windows.Forms.TabPage();
            this.v2t16 = new System.Windows.Forms.Label();
            this.v2t15 = new System.Windows.Forms.Label();
            this.v2t8 = new System.Windows.Forms.Label();
            this.v2t7 = new System.Windows.Forms.Label();
            this.v2t14 = new System.Windows.Forms.Label();
            this.v2t1 = new System.Windows.Forms.Label();
            this.v2t17 = new System.Windows.Forms.Label();
            this.v2t18 = new System.Windows.Forms.Label();
            this.v2t25 = new System.Windows.Forms.Label();
            this.v2t6 = new System.Windows.Forms.Label();
            this.v2t9 = new System.Windows.Forms.Label();
            this.v2t26 = new System.Windows.Forms.Label();
            this.v2t13 = new System.Windows.Forms.Label();
            this.v2t19 = new System.Windows.Forms.Label();
            this.v2t2 = new System.Windows.Forms.Label();
            this.v2t27 = new System.Windows.Forms.Label();
            this.v2t20 = new System.Windows.Forms.Label();
            this.v2t5 = new System.Windows.Forms.Label();
            this.v2t12 = new System.Windows.Forms.Label();
            this.v2t28 = new System.Windows.Forms.Label();
            this.v2t21 = new System.Windows.Forms.Label();
            this.v2t10 = new System.Windows.Forms.Label();
            this.v2t4 = new System.Windows.Forms.Label();
            this.v2t29 = new System.Windows.Forms.Label();
            this.v2t3 = new System.Windows.Forms.Label();
            this.v2t22 = new System.Windows.Forms.Label();
            this.v2t11 = new System.Windows.Forms.Label();
            this.v2t32 = new System.Windows.Forms.Label();
            this.v2t24 = new System.Windows.Forms.Label();
            this.v2t30 = new System.Windows.Forms.Label();
            this.v2t23 = new System.Windows.Forms.Label();
            this.v2t31 = new System.Windows.Forms.Label();
            this.tab_Distance2Plane = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.v4t17 = new System.Windows.Forms.Label();
            this.v4t18 = new System.Windows.Forms.Label();
            this.v4t25 = new System.Windows.Forms.Label();
            this.v4t26 = new System.Windows.Forms.Label();
            this.v4t19 = new System.Windows.Forms.Label();
            this.v4t27 = new System.Windows.Forms.Label();
            this.v4t20 = new System.Windows.Forms.Label();
            this.v4t28 = new System.Windows.Forms.Label();
            this.v4t21 = new System.Windows.Forms.Label();
            this.v4t29 = new System.Windows.Forms.Label();
            this.v4t22 = new System.Windows.Forms.Label();
            this.v4t30 = new System.Windows.Forms.Label();
            this.v4t32 = new System.Windows.Forms.Label();
            this.v4t23 = new System.Windows.Forms.Label();
            this.v4t31 = new System.Windows.Forms.Label();
            this.v4t24 = new System.Windows.Forms.Label();
            this.v4t16 = new System.Windows.Forms.Label();
            this.v4t15 = new System.Windows.Forms.Label();
            this.v4t8 = new System.Windows.Forms.Label();
            this.v4t1 = new System.Windows.Forms.Label();
            this.v4t7 = new System.Windows.Forms.Label();
            this.v4t9 = new System.Windows.Forms.Label();
            this.v4t14 = new System.Windows.Forms.Label();
            this.v4t2 = new System.Windows.Forms.Label();
            this.v4t6 = new System.Windows.Forms.Label();
            this.v4t10 = new System.Windows.Forms.Label();
            this.v4t13 = new System.Windows.Forms.Label();
            this.v4t3 = new System.Windows.Forms.Label();
            this.v4t5 = new System.Windows.Forms.Label();
            this.v4t12 = new System.Windows.Forms.Label();
            this.v4t4 = new System.Windows.Forms.Label();
            this.v4t11 = new System.Windows.Forms.Label();
            this.v3t17 = new System.Windows.Forms.Label();
            this.v3t18 = new System.Windows.Forms.Label();
            this.v3t25 = new System.Windows.Forms.Label();
            this.v3t26 = new System.Windows.Forms.Label();
            this.v3t19 = new System.Windows.Forms.Label();
            this.v3t27 = new System.Windows.Forms.Label();
            this.v3t20 = new System.Windows.Forms.Label();
            this.v3t28 = new System.Windows.Forms.Label();
            this.v3t21 = new System.Windows.Forms.Label();
            this.v3t29 = new System.Windows.Forms.Label();
            this.v3t22 = new System.Windows.Forms.Label();
            this.v3t30 = new System.Windows.Forms.Label();
            this.v3t32 = new System.Windows.Forms.Label();
            this.v3t23 = new System.Windows.Forms.Label();
            this.v3t31 = new System.Windows.Forms.Label();
            this.v3t24 = new System.Windows.Forms.Label();
            this.v3t16 = new System.Windows.Forms.Label();
            this.v3t15 = new System.Windows.Forms.Label();
            this.v3t8 = new System.Windows.Forms.Label();
            this.v3t1 = new System.Windows.Forms.Label();
            this.v3t7 = new System.Windows.Forms.Label();
            this.v3t9 = new System.Windows.Forms.Label();
            this.v3t14 = new System.Windows.Forms.Label();
            this.v3t2 = new System.Windows.Forms.Label();
            this.v3t6 = new System.Windows.Forms.Label();
            this.v3t10 = new System.Windows.Forms.Label();
            this.v3t13 = new System.Windows.Forms.Label();
            this.v3t3 = new System.Windows.Forms.Label();
            this.v3t5 = new System.Windows.Forms.Label();
            this.v3t12 = new System.Windows.Forms.Label();
            this.v3t4 = new System.Windows.Forms.Label();
            this.v3t11 = new System.Windows.Forms.Label();
            this.tab_SuperInclin = new System.Windows.Forms.TabPage();
            this.v7t17 = new System.Windows.Forms.Label();
            this.v7t18 = new System.Windows.Forms.Label();
            this.v7t25 = new System.Windows.Forms.Label();
            this.v7t32 = new System.Windows.Forms.Label();
            this.v7t26 = new System.Windows.Forms.Label();
            this.v7t24 = new System.Windows.Forms.Label();
            this.v7t19 = new System.Windows.Forms.Label();
            this.v7t31 = new System.Windows.Forms.Label();
            this.v7t27 = new System.Windows.Forms.Label();
            this.v7t23 = new System.Windows.Forms.Label();
            this.v7t20 = new System.Windows.Forms.Label();
            this.v7t30 = new System.Windows.Forms.Label();
            this.v7t28 = new System.Windows.Forms.Label();
            this.v7t21 = new System.Windows.Forms.Label();
            this.v7t29 = new System.Windows.Forms.Label();
            this.v7t22 = new System.Windows.Forms.Label();
            this.v6t17 = new System.Windows.Forms.Label();
            this.v6t18 = new System.Windows.Forms.Label();
            this.v6t25 = new System.Windows.Forms.Label();
            this.v6t32 = new System.Windows.Forms.Label();
            this.v6t26 = new System.Windows.Forms.Label();
            this.v6t24 = new System.Windows.Forms.Label();
            this.v6t19 = new System.Windows.Forms.Label();
            this.v6t31 = new System.Windows.Forms.Label();
            this.v6t27 = new System.Windows.Forms.Label();
            this.v6t23 = new System.Windows.Forms.Label();
            this.v6t20 = new System.Windows.Forms.Label();
            this.v6t30 = new System.Windows.Forms.Label();
            this.v6t28 = new System.Windows.Forms.Label();
            this.v6t21 = new System.Windows.Forms.Label();
            this.v6t29 = new System.Windows.Forms.Label();
            this.v6t22 = new System.Windows.Forms.Label();
            this.v5t17 = new System.Windows.Forms.Label();
            this.v5t18 = new System.Windows.Forms.Label();
            this.v5t25 = new System.Windows.Forms.Label();
            this.v5t32 = new System.Windows.Forms.Label();
            this.v5t26 = new System.Windows.Forms.Label();
            this.v5t24 = new System.Windows.Forms.Label();
            this.v5t19 = new System.Windows.Forms.Label();
            this.v5t31 = new System.Windows.Forms.Label();
            this.v5t27 = new System.Windows.Forms.Label();
            this.v5t23 = new System.Windows.Forms.Label();
            this.v5t20 = new System.Windows.Forms.Label();
            this.v5t30 = new System.Windows.Forms.Label();
            this.v5t28 = new System.Windows.Forms.Label();
            this.v5t21 = new System.Windows.Forms.Label();
            this.v5t29 = new System.Windows.Forms.Label();
            this.v5t22 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.v7t16 = new System.Windows.Forms.Label();
            this.v7t15 = new System.Windows.Forms.Label();
            this.v7t8 = new System.Windows.Forms.Label();
            this.v7t1 = new System.Windows.Forms.Label();
            this.v7t7 = new System.Windows.Forms.Label();
            this.v7t9 = new System.Windows.Forms.Label();
            this.v7t14 = new System.Windows.Forms.Label();
            this.v7t2 = new System.Windows.Forms.Label();
            this.v7t6 = new System.Windows.Forms.Label();
            this.v7t10 = new System.Windows.Forms.Label();
            this.v7t13 = new System.Windows.Forms.Label();
            this.v7t3 = new System.Windows.Forms.Label();
            this.v7t5 = new System.Windows.Forms.Label();
            this.v7t12 = new System.Windows.Forms.Label();
            this.v7t4 = new System.Windows.Forms.Label();
            this.v7t11 = new System.Windows.Forms.Label();
            this.v6t16 = new System.Windows.Forms.Label();
            this.v6t15 = new System.Windows.Forms.Label();
            this.v6t8 = new System.Windows.Forms.Label();
            this.v6t1 = new System.Windows.Forms.Label();
            this.v6t7 = new System.Windows.Forms.Label();
            this.v6t9 = new System.Windows.Forms.Label();
            this.v6t14 = new System.Windows.Forms.Label();
            this.v6t2 = new System.Windows.Forms.Label();
            this.v6t6 = new System.Windows.Forms.Label();
            this.v6t10 = new System.Windows.Forms.Label();
            this.v6t13 = new System.Windows.Forms.Label();
            this.v6t3 = new System.Windows.Forms.Label();
            this.v6t5 = new System.Windows.Forms.Label();
            this.v6t12 = new System.Windows.Forms.Label();
            this.v6t4 = new System.Windows.Forms.Label();
            this.v6t11 = new System.Windows.Forms.Label();
            this.v5t16 = new System.Windows.Forms.Label();
            this.v5t15 = new System.Windows.Forms.Label();
            this.v5t8 = new System.Windows.Forms.Label();
            this.v5t1 = new System.Windows.Forms.Label();
            this.v5t7 = new System.Windows.Forms.Label();
            this.v5t9 = new System.Windows.Forms.Label();
            this.v5t14 = new System.Windows.Forms.Label();
            this.v5t2 = new System.Windows.Forms.Label();
            this.v5t6 = new System.Windows.Forms.Label();
            this.v5t10 = new System.Windows.Forms.Label();
            this.v5t13 = new System.Windows.Forms.Label();
            this.v5t3 = new System.Windows.Forms.Label();
            this.v5t5 = new System.Windows.Forms.Label();
            this.v5t12 = new System.Windows.Forms.Label();
            this.v5t4 = new System.Windows.Forms.Label();
            this.v5t11 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.tab_CurveFit = new System.Windows.Forms.TabPage();
            this.lv_wires = new System.Windows.Forms.ListView();
            this.lb_curve2occlusalPlane = new System.Windows.Forms.Label();
            this.pl_wireMatch = new System.Windows.Forms.Panel();
            this.cb_curvePlane2 = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.b_matchingWire = new System.Windows.Forms.Button();
            this.rb_maxilla = new System.Windows.Forms.RadioButton();
            this.rb_mandible = new System.Windows.Forms.RadioButton();
            this.lb_curvefit_rmse_z = new System.Windows.Forms.Label();
            this.lb_curvefit_rmse_xy = new System.Windows.Forms.Label();
            this.cb_curvePlane1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_fitPoly = new System.Windows.Forms.RadioButton();
            this.rb_fitNoroozi = new System.Windows.Forms.RadioButton();
            this.nUpDown_order = new System.Windows.Forms.NumericUpDown();
            this.pl_curveFit = new System.Windows.Forms.Panel();
            this.gb_teeh = new System.Windows.Forms.GroupBox();
            this.t32 = new System.Windows.Forms.Label();
            this.t31 = new System.Windows.Forms.Label();
            this.t29 = new System.Windows.Forms.Label();
            this.t9 = new System.Windows.Forms.Label();
            this.t8 = new System.Windows.Forms.Label();
            this.t10 = new System.Windows.Forms.Label();
            this.t7 = new System.Windows.Forms.Label();
            this.t11 = new System.Windows.Forms.Label();
            this.t6 = new System.Windows.Forms.Label();
            this.t21 = new System.Windows.Forms.Label();
            this.t12 = new System.Windows.Forms.Label();
            this.t5 = new System.Windows.Forms.Label();
            this.t20 = new System.Windows.Forms.Label();
            this.t13 = new System.Windows.Forms.Label();
            this.t4 = new System.Windows.Forms.Label();
            this.t19 = new System.Windows.Forms.Label();
            this.t14 = new System.Windows.Forms.Label();
            this.t3 = new System.Windows.Forms.Label();
            this.t18 = new System.Windows.Forms.Label();
            this.t15 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.Label();
            this.t17 = new System.Windows.Forms.Label();
            this.t16 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.Label();
            this.t24 = new System.Windows.Forms.Label();
            this.t25 = new System.Windows.Forms.Label();
            this.t23 = new System.Windows.Forms.Label();
            this.t26 = new System.Windows.Forms.Label();
            this.t22 = new System.Windows.Forms.Label();
            this.t27 = new System.Windows.Forms.Label();
            this.t28 = new System.Windows.Forms.Label();
            this.t30 = new System.Windows.Forms.Label();
            this.lb_numVerticesReduced = new System.Windows.Forms.Label();
            this.lb_RDCastLabel = new System.Windows.Forms.Label();
            this.w1_tb = new System.Windows.Forms.TextBox();
            this.w2_tb = new System.Windows.Forms.TextBox();
            this.w3_tb = new System.Windows.Forms.TextBox();
            this.w4_tb = new System.Windows.Forms.TextBox();
            this.w5_tb = new System.Windows.Forms.TextBox();
            this.w6_tb = new System.Windows.Forms.TextBox();
            this.w7_tb = new System.Windows.Forms.TextBox();
            this.w8_tb = new System.Windows.Forms.TextBox();
            this.w9_tb = new System.Windows.Forms.TextBox();
            this.w10_tb = new System.Windows.Forms.TextBox();
            this.w11_tb = new System.Windows.Forms.TextBox();
            this.w12_tb = new System.Windows.Forms.TextBox();
            this.gb_weight = new System.Windows.Forms.GroupBox();
            this.toolboxPanel_p = new System.Windows.Forms.Panel();
            this.collapse_b = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.expand_b = new System.Windows.Forms.Button();
            this.gb_viewMode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_densityReduceThreshold)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gb_cast1.SuspendLayout();
            this.gb_cast2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tab_Maintab.SuspendLayout();
            this.tab_Planes.SuspendLayout();
            this.tab_Inclination.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tab_Dislocation.SuspendLayout();
            this.tab_Distance2Plane.SuspendLayout();
            this.tab_SuperInclin.SuspendLayout();
            this.tab_CurveFit.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown_order)).BeginInit();
            this.gb_teeh.SuspendLayout();
            this.gb_weight.SuspendLayout();
            this.toolboxPanel_p.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControlCast
            // 
            this.glControlCast.AllowDrop = true;
            this.glControlCast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControlCast.BackColor = System.Drawing.Color.Black;
            this.glControlCast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glControlCast.Location = new System.Drawing.Point(1, 57);
            this.glControlCast.Name = "glControlCast";
            this.glControlCast.Size = new System.Drawing.Size(906, 337);
            this.glControlCast.TabIndex = 0;
            this.glControlCast.VSync = false;
            this.glControlCast.Load += new System.EventHandler(this.glControlCast_Load);
            this.glControlCast.SizeChanged += new System.EventHandler(this.glControlCast_SizeChanged);
            this.glControlCast.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.glControlCast.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.glControlCast.Paint += new System.Windows.Forms.PaintEventHandler(this.glControlCast_Paint);
            this.glControlCast.DoubleClick += new System.EventHandler(this.glControlCast_DoubleClick);
            this.glControlCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControlCast_MouseClick);
            this.glControlCast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControlCast_MouseDown);
            this.glControlCast.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControlCast_MouseMove);
            this.glControlCast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControlCast_MouseUp);
            // 
            // gb_viewMode
            // 
            this.gb_viewMode.Controls.Add(this.cb_showPoints);
            this.gb_viewMode.Controls.Add(this.rb_viewMesh);
            this.gb_viewMode.Controls.Add(this.rb_viewWireFrame);
            this.gb_viewMode.Controls.Add(this.rb_viewPoints);
            this.gb_viewMode.Location = new System.Drawing.Point(68, 334);
            this.gb_viewMode.Name = "gb_viewMode";
            this.gb_viewMode.Size = new System.Drawing.Size(91, 109);
            this.gb_viewMode.TabIndex = 2;
            this.gb_viewMode.TabStop = false;
            this.gb_viewMode.Text = "View Mode";
            // 
            // cb_showPoints
            // 
            this.cb_showPoints.AutoSize = true;
            this.cb_showPoints.Location = new System.Drawing.Point(6, 86);
            this.cb_showPoints.Name = "cb_showPoints";
            this.cb_showPoints.Size = new System.Drawing.Size(85, 17);
            this.cb_showPoints.TabIndex = 3;
            this.cb_showPoints.Text = "Show Points";
            this.cb_showPoints.UseVisualStyleBackColor = true;
            this.cb_showPoints.CheckedChanged += new System.EventHandler(this.cb_showPoints_CheckedChanged);
            // 
            // rb_viewMesh
            // 
            this.rb_viewMesh.AutoSize = true;
            this.rb_viewMesh.Checked = true;
            this.rb_viewMesh.Location = new System.Drawing.Point(6, 65);
            this.rb_viewMesh.Name = "rb_viewMesh";
            this.rb_viewMesh.Size = new System.Drawing.Size(51, 17);
            this.rb_viewMesh.TabIndex = 2;
            this.rb_viewMesh.TabStop = true;
            this.rb_viewMesh.Text = "Mesh";
            this.rb_viewMesh.UseVisualStyleBackColor = true;
            this.rb_viewMesh.CheckedChanged += new System.EventHandler(this.rb_mesh_CheckedChanged);
            // 
            // rb_viewWireFrame
            // 
            this.rb_viewWireFrame.AutoSize = true;
            this.rb_viewWireFrame.Location = new System.Drawing.Point(6, 42);
            this.rb_viewWireFrame.Name = "rb_viewWireFrame";
            this.rb_viewWireFrame.Size = new System.Drawing.Size(76, 17);
            this.rb_viewWireFrame.TabIndex = 1;
            this.rb_viewWireFrame.Text = "WireFrame";
            this.rb_viewWireFrame.UseVisualStyleBackColor = true;
            this.rb_viewWireFrame.CheckedChanged += new System.EventHandler(this.rb_wireFrame_CheckedChanged);
            // 
            // rb_viewPoints
            // 
            this.rb_viewPoints.AutoSize = true;
            this.rb_viewPoints.Location = new System.Drawing.Point(6, 19);
            this.rb_viewPoints.Name = "rb_viewPoints";
            this.rb_viewPoints.Size = new System.Drawing.Size(54, 17);
            this.rb_viewPoints.TabIndex = 0;
            this.rb_viewPoints.Text = "Points";
            this.rb_viewPoints.UseVisualStyleBackColor = true;
            this.rb_viewPoints.CheckedChanged += new System.EventHandler(this.rb_points_CheckedChanged);
            // 
            // tx_cameraAngleX
            // 
            this.tx_cameraAngleX.Location = new System.Drawing.Point(18, 16);
            this.tx_cameraAngleX.Name = "tx_cameraAngleX";
            this.tx_cameraAngleX.Size = new System.Drawing.Size(39, 20);
            this.tx_cameraAngleX.TabIndex = 3;
            this.tx_cameraAngleX.Enter += new System.EventHandler(this.tx_Enter);
            this.tx_cameraAngleX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_CameraAngleXYZ_KeyDown);
            this.tx_cameraAngleX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            this.tx_cameraAngleX.Leave += new System.EventHandler(this.tx_Leave);
            // 
            // tx_cameraAngleY
            // 
            this.tx_cameraAngleY.Location = new System.Drawing.Point(18, 37);
            this.tx_cameraAngleY.Name = "tx_cameraAngleY";
            this.tx_cameraAngleY.Size = new System.Drawing.Size(39, 20);
            this.tx_cameraAngleY.TabIndex = 4;
            this.tx_cameraAngleY.Enter += new System.EventHandler(this.tx_Enter);
            this.tx_cameraAngleY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_CameraAngleXYZ_KeyDown);
            this.tx_cameraAngleY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            this.tx_cameraAngleY.Leave += new System.EventHandler(this.tx_Leave);
            // 
            // tx_cameraAngleZ
            // 
            this.tx_cameraAngleZ.Location = new System.Drawing.Point(18, 58);
            this.tx_cameraAngleZ.Name = "tx_cameraAngleZ";
            this.tx_cameraAngleZ.Size = new System.Drawing.Size(39, 20);
            this.tx_cameraAngleZ.TabIndex = 5;
            this.tx_cameraAngleZ.Enter += new System.EventHandler(this.tx_Enter);
            this.tx_cameraAngleZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_CameraAngleXYZ_KeyDown);
            this.tx_cameraAngleZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            this.tx_cameraAngleZ.Leave += new System.EventHandler(this.tx_Leave);
            // 
            // lb_ViewAngleX
            // 
            this.lb_ViewAngleX.AutoSize = true;
            this.lb_ViewAngleX.Location = new System.Drawing.Point(3, 19);
            this.lb_ViewAngleX.Name = "lb_ViewAngleX";
            this.lb_ViewAngleX.Size = new System.Drawing.Size(14, 13);
            this.lb_ViewAngleX.TabIndex = 6;
            this.lb_ViewAngleX.Text = "X";
            // 
            // lb_ViewAngleY
            // 
            this.lb_ViewAngleY.AutoSize = true;
            this.lb_ViewAngleY.Location = new System.Drawing.Point(3, 44);
            this.lb_ViewAngleY.Name = "lb_ViewAngleY";
            this.lb_ViewAngleY.Size = new System.Drawing.Size(14, 13);
            this.lb_ViewAngleY.TabIndex = 7;
            this.lb_ViewAngleY.Text = "Y";
            // 
            // lb_ViewangleZ
            // 
            this.lb_ViewangleZ.AutoSize = true;
            this.lb_ViewangleZ.Location = new System.Drawing.Point(3, 65);
            this.lb_ViewangleZ.Name = "lb_ViewangleZ";
            this.lb_ViewangleZ.Size = new System.Drawing.Size(14, 13);
            this.lb_ViewangleZ.TabIndex = 8;
            this.lb_ViewangleZ.Text = "Z";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_UpdateCameraRotation);
            this.groupBox1.Controls.Add(this.tx_cameraAngleX);
            this.groupBox1.Controls.Add(this.lb_ViewangleZ);
            this.groupBox1.Controls.Add(this.tx_cameraAngleY);
            this.groupBox1.Controls.Add(this.lb_ViewAngleY);
            this.groupBox1.Controls.Add(this.tx_cameraAngleZ);
            this.groupBox1.Controls.Add(this.lb_ViewAngleX);
            this.groupBox1.Location = new System.Drawing.Point(3, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(60, 112);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera";
            // 
            // b_UpdateCameraRotation
            // 
            this.b_UpdateCameraRotation.Location = new System.Drawing.Point(13, 82);
            this.b_UpdateCameraRotation.Name = "b_UpdateCameraRotation";
            this.b_UpdateCameraRotation.Size = new System.Drawing.Size(38, 23);
            this.b_UpdateCameraRotation.TabIndex = 6;
            this.b_UpdateCameraRotation.Text = "Go";
            this.b_UpdateCameraRotation.UseVisualStyleBackColor = true;
            this.b_UpdateCameraRotation.Click += new System.EventHandler(this.b_UpdateRotation_Click);
            // 
            // cb_autoRotate
            // 
            this.cb_autoRotate.AutoSize = true;
            this.cb_autoRotate.Location = new System.Drawing.Point(76, 97);
            this.cb_autoRotate.Name = "cb_autoRotate";
            this.cb_autoRotate.Size = new System.Drawing.Size(83, 17);
            this.cb_autoRotate.TabIndex = 12;
            this.cb_autoRotate.Text = "Auto Rotate";
            this.cb_autoRotate.UseVisualStyleBackColor = true;
            this.cb_autoRotate.CheckedChanged += new System.EventHandler(this.cb_autoRotate_CheckedChanged);
            // 
            // timer_10mill
            // 
            this.timer_10mill.Enabled = true;
            this.timer_10mill.Interval = 10;
            this.timer_10mill.Tick += new System.EventHandler(this.timer_10mill_Tick);
            // 
            // lb_selectedPoints1
            // 
            this.lb_selectedPoints1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_selectedPoints1.AutoSize = true;
            this.lb_selectedPoints1.BackColor = System.Drawing.Color.AliceBlue;
            this.lb_selectedPoints1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_selectedPoints1.ForeColor = System.Drawing.Color.DarkBlue;
            this.lb_selectedPoints1.Location = new System.Drawing.Point(973, 62);
            this.lb_selectedPoints1.Name = "lb_selectedPoints1";
            this.lb_selectedPoints1.Size = new System.Drawing.Size(15, 16);
            this.lb_selectedPoints1.TabIndex = 16;
            this.lb_selectedPoints1.Text = "0";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip.Location = new System.Drawing.Point(0, 640);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1139, 22);
            this.statusStrip.TabIndex = 67;
            this.statusStrip.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.meshToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1139, 24);
            this.menuStrip.TabIndex = 68;
            this.menuStrip.Text = "Test";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadPointCloudToolStripMenuItem,
            this.loadMeshToolStripMenuItem,
            this.saveMeshToolStripMenuItem,
            this.toolStripSeparator2,
            this.loadCalculationFileToolStripMenuItem,
            this.saveCalculationFileToolStripMenuItem,
            this.toolStripSeparator3,
            this.loadSelectionToolStripMenuItem,
            this.saveSelectionToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.New_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(256, 6);
            // 
            // loadPointCloudToolStripMenuItem
            // 
            this.loadPointCloudToolStripMenuItem.Name = "loadPointCloudToolStripMenuItem";
            this.loadPointCloudToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadPointCloudToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.loadPointCloudToolStripMenuItem.Text = "Load Point Cloud";
            this.loadPointCloudToolStripMenuItem.Click += new System.EventHandler(this.LoadPointCloud_ToolStripMenuItem_Click);
            // 
            // loadMeshToolStripMenuItem
            // 
            this.loadMeshToolStripMenuItem.Name = "loadMeshToolStripMenuItem";
            this.loadMeshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.loadMeshToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.loadMeshToolStripMenuItem.Text = "Load Mesh";
            this.loadMeshToolStripMenuItem.Click += new System.EventHandler(this.LoadMesh_ToolStripMenuItem_Click);
            // 
            // saveMeshToolStripMenuItem
            // 
            this.saveMeshToolStripMenuItem.Name = "saveMeshToolStripMenuItem";
            this.saveMeshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMeshToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.saveMeshToolStripMenuItem.Text = "Save Mesh";
            this.saveMeshToolStripMenuItem.Click += new System.EventHandler(this.saveMeshToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(256, 6);
            // 
            // loadCalculationFileToolStripMenuItem
            // 
            this.loadCalculationFileToolStripMenuItem.Name = "loadCalculationFileToolStripMenuItem";
            this.loadCalculationFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.loadCalculationFileToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.loadCalculationFileToolStripMenuItem.Text = "Load Calculation File";
            this.loadCalculationFileToolStripMenuItem.Click += new System.EventHandler(this.loadCalculations_ToolStripMenuItem_Click);
            // 
            // saveCalculationFileToolStripMenuItem
            // 
            this.saveCalculationFileToolStripMenuItem.Name = "saveCalculationFileToolStripMenuItem";
            this.saveCalculationFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveCalculationFileToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.saveCalculationFileToolStripMenuItem.Text = "Save Calculation File";
            this.saveCalculationFileToolStripMenuItem.Click += new System.EventHandler(this.saveCalculations_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(256, 6);
            // 
            // loadSelectionToolStripMenuItem
            // 
            this.loadSelectionToolStripMenuItem.Name = "loadSelectionToolStripMenuItem";
            this.loadSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.loadSelectionToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.loadSelectionToolStripMenuItem.Text = "Load Selection";
            this.loadSelectionToolStripMenuItem.Click += new System.EventHandler(this.loadSelectionToolStripMenuItem_Click);
            // 
            // saveSelectionToolStripMenuItem
            // 
            this.saveSelectionToolStripMenuItem.Name = "saveSelectionToolStripMenuItem";
            this.saveSelectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.saveSelectionToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.saveSelectionToolStripMenuItem.Text = "Save Selection";
            this.saveSelectionToolStripMenuItem.Click += new System.EventHandler(this.saveSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(256, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // meshToolStripMenuItem
            // 
            this.meshToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.triangulatePointCloudToolStripMenuItem,
            this.meshInfoToolStripMenuItem,
            this.deleteNoisyPointsToolStripMenuItem,
            this.computeNormalsToolStripMenuItem});
            this.meshToolStripMenuItem.Name = "meshToolStripMenuItem";
            this.meshToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.meshToolStripMenuItem.Text = "Mesh";
            // 
            // triangulatePointCloudToolStripMenuItem
            // 
            this.triangulatePointCloudToolStripMenuItem.Name = "triangulatePointCloudToolStripMenuItem";
            this.triangulatePointCloudToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.triangulatePointCloudToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.triangulatePointCloudToolStripMenuItem.Text = "Triangulate Point Cloud";
            this.triangulatePointCloudToolStripMenuItem.Click += new System.EventHandler(this.triangulatePointCloudToolStripMenuItem_Click);
            // 
            // meshInfoToolStripMenuItem
            // 
            this.meshInfoToolStripMenuItem.Name = "meshInfoToolStripMenuItem";
            this.meshInfoToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.meshInfoToolStripMenuItem.Text = "Mesh info";
            this.meshInfoToolStripMenuItem.Click += new System.EventHandler(this.meshInfoToolStripMenuItem_Click);
            // 
            // deleteNoisyPointsToolStripMenuItem
            // 
            this.deleteNoisyPointsToolStripMenuItem.Name = "deleteNoisyPointsToolStripMenuItem";
            this.deleteNoisyPointsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.deleteNoisyPointsToolStripMenuItem.Text = "Delete Noisy Points";
            this.deleteNoisyPointsToolStripMenuItem.Click += new System.EventHandler(this.deleteNoisyPointsToolStripMenuItem_Click);
            // 
            // computeNormalsToolStripMenuItem
            // 
            this.computeNormalsToolStripMenuItem.Name = "computeNormalsToolStripMenuItem";
            this.computeNormalsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.computeNormalsToolStripMenuItem.Text = "Compute Normals";
            this.computeNormalsToolStripMenuItem.Click += new System.EventHandler(this.computeNormalsToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.showCast1ToolStripMenuItem,
            this.showCast2ToolStripMenuItem,
            this.inverseCastShowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(204, 6);
            // 
            // showCast1ToolStripMenuItem
            // 
            this.showCast1ToolStripMenuItem.CheckOnClick = true;
            this.showCast1ToolStripMenuItem.Name = "showCast1ToolStripMenuItem";
            this.showCast1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D1)));
            this.showCast1ToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.showCast1ToolStripMenuItem.Text = "Show Cast1";
            this.showCast1ToolStripMenuItem.Click += new System.EventHandler(this.showCast1ToolStripMenuItem_Click);
            // 
            // showCast2ToolStripMenuItem
            // 
            this.showCast2ToolStripMenuItem.CheckOnClick = true;
            this.showCast2ToolStripMenuItem.Name = "showCast2ToolStripMenuItem";
            this.showCast2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D2)));
            this.showCast2ToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.showCast2ToolStripMenuItem.Text = "Show Cast2";
            this.showCast2ToolStripMenuItem.Click += new System.EventHandler(this.showCast2ToolStripMenuItem_Click);
            // 
            // inverseCastShowToolStripMenuItem
            // 
            this.inverseCastShowToolStripMenuItem.Name = "inverseCastShowToolStripMenuItem";
            this.inverseCastShowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.inverseCastShowToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.inverseCastShowToolStripMenuItem.Text = "Inverse Cast Show";
            this.inverseCastShowToolStripMenuItem.Click += new System.EventHandler(this.inverseCastShowToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutOrthoAidToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutOrthoAidToolStripMenuItem
            // 
            this.aboutOrthoAidToolStripMenuItem.Name = "aboutOrthoAidToolStripMenuItem";
            this.aboutOrthoAidToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.aboutOrthoAidToolStripMenuItem.Text = "About OrthoAid";
            this.aboutOrthoAidToolStripMenuItem.Click += new System.EventHandler(this.aboutOrthoAidToolStripMenuItem_Click);
            // 
            // lb_numVertices1
            // 
            this.lb_numVertices1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_numVertices1.AutoSize = true;
            this.lb_numVertices1.Location = new System.Drawing.Point(-1, 24);
            this.lb_numVertices1.Name = "lb_numVertices1";
            this.lb_numVertices1.Size = new System.Drawing.Size(57, 13);
            this.lb_numVertices1.TabIndex = 69;
            this.lb_numVertices1.Text = "Vertices: 0";
            // 
            // lb_numFaces1
            // 
            this.lb_numFaces1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_numFaces1.AutoSize = true;
            this.lb_numFaces1.Location = new System.Drawing.Point(0, 36);
            this.lb_numFaces1.Name = "lb_numFaces1";
            this.lb_numFaces1.Size = new System.Drawing.Size(48, 13);
            this.lb_numFaces1.TabIndex = 70;
            this.lb_numFaces1.Text = "Faces: 0";
            // 
            // lb_meshName1
            // 
            this.lb_meshName1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_meshName1.AutoSize = true;
            this.lb_meshName1.Location = new System.Drawing.Point(0, 11);
            this.lb_meshName1.Name = "lb_meshName1";
            this.lb_meshName1.Size = new System.Drawing.Size(117, 13);
            this.lb_meshName1.TabIndex = 71;
            this.lb_meshName1.Text = "Mesh: No Mesh loaded";
            // 
            // numUD_densityReduceThreshold
            // 
            this.numUD_densityReduceThreshold.DecimalPlaces = 2;
            this.numUD_densityReduceThreshold.Location = new System.Drawing.Point(51, 14);
            this.numUD_densityReduceThreshold.Name = "numUD_densityReduceThreshold";
            this.numUD_densityReduceThreshold.Size = new System.Drawing.Size(47, 20);
            this.numUD_densityReduceThreshold.TabIndex = 75;
            this.numUD_densityReduceThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUD_densityReduceThreshold.ValueChanged += new System.EventHandler(this.numUD_densityReduceThreshold_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.b_cancelReduceDensity);
            this.groupBox3.Controls.Add(this.b_previewReduceDensity);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.b_applyReduceDensity);
            this.groupBox3.Controls.Add(this.numUD_densityReduceThreshold);
            this.groupBox3.Location = new System.Drawing.Point(549, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 60);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reduce Density";
            this.groupBox3.Visible = false;
            // 
            // b_cancelReduceDensity
            // 
            this.b_cancelReduceDensity.Location = new System.Drawing.Point(4, 36);
            this.b_cancelReduceDensity.Name = "b_cancelReduceDensity";
            this.b_cancelReduceDensity.Size = new System.Drawing.Size(68, 22);
            this.b_cancelReduceDensity.TabIndex = 79;
            this.b_cancelReduceDensity.Text = "Cancel";
            this.b_cancelReduceDensity.UseVisualStyleBackColor = true;
            this.b_cancelReduceDensity.Click += new System.EventHandler(this.b_cancelReduceDensity_Click);
            // 
            // b_previewReduceDensity
            // 
            this.b_previewReduceDensity.Location = new System.Drawing.Point(97, 12);
            this.b_previewReduceDensity.Name = "b_previewReduceDensity";
            this.b_previewReduceDensity.Size = new System.Drawing.Size(54, 22);
            this.b_previewReduceDensity.TabIndex = 78;
            this.b_previewReduceDensity.Text = "Preview";
            this.b_previewReduceDensity.UseVisualStyleBackColor = true;
            this.b_previewReduceDensity.Click += new System.EventHandler(this.b_previewReduceDensity_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Distance:";
            // 
            // b_applyReduceDensity
            // 
            this.b_applyReduceDensity.Location = new System.Drawing.Point(78, 36);
            this.b_applyReduceDensity.Name = "b_applyReduceDensity";
            this.b_applyReduceDensity.Size = new System.Drawing.Size(64, 22);
            this.b_applyReduceDensity.TabIndex = 76;
            this.b_applyReduceDensity.Text = "Apply";
            this.b_applyReduceDensity.UseVisualStyleBackColor = true;
            this.b_applyReduceDensity.Click += new System.EventHandler(this.b_applyReduceDensity_Click);
            // 
            // lb_meshName2
            // 
            this.lb_meshName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_meshName2.AutoSize = true;
            this.lb_meshName2.Location = new System.Drawing.Point(0, 11);
            this.lb_meshName2.Name = "lb_meshName2";
            this.lb_meshName2.Size = new System.Drawing.Size(117, 13);
            this.lb_meshName2.TabIndex = 79;
            this.lb_meshName2.Text = "Mesh: No Mesh loaded";
            // 
            // lb_numFaces2
            // 
            this.lb_numFaces2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_numFaces2.AutoSize = true;
            this.lb_numFaces2.Location = new System.Drawing.Point(1, 36);
            this.lb_numFaces2.Name = "lb_numFaces2";
            this.lb_numFaces2.Size = new System.Drawing.Size(48, 13);
            this.lb_numFaces2.TabIndex = 78;
            this.lb_numFaces2.Text = "Faces: 0";
            // 
            // lb_numVertices2
            // 
            this.lb_numVertices2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_numVertices2.AutoSize = true;
            this.lb_numVertices2.Location = new System.Drawing.Point(0, 24);
            this.lb_numVertices2.Name = "lb_numVertices2";
            this.lb_numVertices2.Size = new System.Drawing.Size(57, 13);
            this.lb_numVertices2.TabIndex = 77;
            this.lb_numVertices2.Text = "Vertices: 0";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbox_selectCast);
            this.groupBox4.Controls.Add(this.cb_showCast2);
            this.groupBox4.Controls.Add(this.cb_showCast1);
            this.groupBox4.Location = new System.Drawing.Point(2, 58);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(84, 55);
            this.groupBox4.TabIndex = 82;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Show";
            // 
            // lbox_selectCast
            // 
            this.lbox_selectCast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbox_selectCast.FormattingEnabled = true;
            this.lbox_selectCast.ItemHeight = 16;
            this.lbox_selectCast.Items.AddRange(new object[] {
            "Cast 1",
            "Cast 2"});
            this.lbox_selectCast.Location = new System.Drawing.Point(33, 15);
            this.lbox_selectCast.Name = "lbox_selectCast";
            this.lbox_selectCast.Size = new System.Drawing.Size(47, 36);
            this.lbox_selectCast.TabIndex = 2;
            this.lbox_selectCast.SelectedIndexChanged += new System.EventHandler(this.lbox_selectCast_SelectedIndexChanged);
            // 
            // cb_showCast2
            // 
            this.cb_showCast2.AutoSize = true;
            this.cb_showCast2.Location = new System.Drawing.Point(10, 35);
            this.cb_showCast2.Name = "cb_showCast2";
            this.cb_showCast2.Size = new System.Drawing.Size(29, 17);
            this.cb_showCast2.TabIndex = 4;
            this.cb_showCast2.Text = " ";
            this.toolTip1.SetToolTip(this.cb_showCast2, "( Ctrl + Shift + 2 )");
            this.cb_showCast2.UseVisualStyleBackColor = true;
            this.cb_showCast2.CheckedChanged += new System.EventHandler(this.cb_showCast2_CheckedChanged);
            // 
            // cb_showCast1
            // 
            this.cb_showCast1.AutoSize = true;
            this.cb_showCast1.Location = new System.Drawing.Point(10, 17);
            this.cb_showCast1.Name = "cb_showCast1";
            this.cb_showCast1.Size = new System.Drawing.Size(29, 17);
            this.cb_showCast1.TabIndex = 3;
            this.cb_showCast1.Text = " ";
            this.toolTip1.SetToolTip(this.cb_showCast1, "( Ctrl + Shift + 1 )");
            this.cb_showCast1.UseVisualStyleBackColor = true;
            this.cb_showCast1.CheckedChanged += new System.EventHandler(this.cb_showCast1_CheckedChanged);
            // 
            // gb_cast1
            // 
            this.gb_cast1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_cast1.BackColor = System.Drawing.Color.Beige;
            this.gb_cast1.Controls.Add(this.lb_meshName1);
            this.gb_cast1.Controls.Add(this.lb_numVertices1);
            this.gb_cast1.Controls.Add(this.lb_numFaces1);
            this.gb_cast1.Location = new System.Drawing.Point(3, 292);
            this.gb_cast1.Name = "gb_cast1";
            this.gb_cast1.Size = new System.Drawing.Size(129, 49);
            this.gb_cast1.TabIndex = 85;
            this.gb_cast1.TabStop = false;
            this.gb_cast1.Text = "Cast1";
            // 
            // gb_cast2
            // 
            this.gb_cast2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_cast2.BackColor = System.Drawing.Color.Beige;
            this.gb_cast2.Controls.Add(this.lb_meshName2);
            this.gb_cast2.Controls.Add(this.lb_numVertices2);
            this.gb_cast2.Controls.Add(this.lb_numFaces2);
            this.gb_cast2.Location = new System.Drawing.Point(3, 343);
            this.gb_cast2.Name = "gb_cast2";
            this.gb_cast2.Size = new System.Drawing.Size(129, 49);
            this.gb_cast2.TabIndex = 86;
            this.gb_cast2.TabStop = false;
            this.gb_cast2.Text = "Cast2";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.b_RotateTranslate);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.tx_translateX);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.tx_translateY);
            this.groupBox7.Controls.Add(this.tx_translateZ);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.tx_rotateAngleX);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.tx_rotateAngleY);
            this.groupBox7.Controls.Add(this.tx_rotateAngleZ);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Location = new System.Drawing.Point(3, 188);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(156, 143);
            this.groupBox7.TabIndex = 89;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Rotate and Translate Cast";
            // 
            // b_RotateTranslate
            // 
            this.b_RotateTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_RotateTranslate.Location = new System.Drawing.Point(24, 114);
            this.b_RotateTranslate.Name = "b_RotateTranslate";
            this.b_RotateTranslate.Size = new System.Drawing.Size(117, 23);
            this.b_RotateTranslate.TabIndex = 22;
            this.b_RotateTranslate.Text = "Go";
            this.b_RotateTranslate.UseVisualStyleBackColor = true;
            this.b_RotateTranslate.Click += new System.EventHandler(this.b_RotateTranslate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(81, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Translate";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Rotate";
            // 
            // tx_translateX
            // 
            this.tx_translateX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_translateX.Location = new System.Drawing.Point(102, 42);
            this.tx_translateX.Name = "tx_translateX";
            this.tx_translateX.Size = new System.Drawing.Size(39, 20);
            this.tx_translateX.TabIndex = 19;
            this.tx_translateX.Text = "0";
            this.tx_translateX.Enter += new System.EventHandler(this.tx_Enter);
            this.tx_translateX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_RotateTranslate_KeyDown);
            this.tx_translateX.Leave += new System.EventHandler(this.tx_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Z";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "X";
            // 
            // tx_translateY
            // 
            this.tx_translateY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_translateY.Location = new System.Drawing.Point(102, 63);
            this.tx_translateY.Name = "tx_translateY";
            this.tx_translateY.Size = new System.Drawing.Size(39, 20);
            this.tx_translateY.TabIndex = 20;
            this.tx_translateY.Text = "0";
            this.tx_translateY.Enter += new System.EventHandler(this.tx_Enter);
            this.tx_translateY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_RotateTranslate_KeyDown);
            this.tx_translateY.Leave += new System.EventHandler(this.tx_Leave);
            // 
            // tx_translateZ
            // 
            this.tx_translateZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_translateZ.Location = new System.Drawing.Point(102, 84);
            this.tx_translateZ.Name = "tx_translateZ";
            this.tx_translateZ.Size = new System.Drawing.Size(39, 20);
            this.tx_translateZ.TabIndex = 21;
            this.tx_translateZ.Text = "0";
            this.tx_translateZ.Enter += new System.EventHandler(this.tx_Enter);
            this.tx_translateZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_RotateTranslate_KeyDown);
            this.tx_translateZ.Leave += new System.EventHandler(this.tx_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Y";
            // 
            // tx_rotateAngleX
            // 
            this.tx_rotateAngleX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_rotateAngleX.Location = new System.Drawing.Point(27, 42);
            this.tx_rotateAngleX.Name = "tx_rotateAngleX";
            this.tx_rotateAngleX.Size = new System.Drawing.Size(39, 20);
            this.tx_rotateAngleX.TabIndex = 13;
            this.tx_rotateAngleX.Text = "0";
            this.tx_rotateAngleX.Enter += new System.EventHandler(this.tx_Enter);
            this.tx_rotateAngleX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_RotateTranslate_KeyDown);
            this.tx_rotateAngleX.Leave += new System.EventHandler(this.tx_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Z";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "X";
            // 
            // tx_rotateAngleY
            // 
            this.tx_rotateAngleY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_rotateAngleY.Location = new System.Drawing.Point(27, 63);
            this.tx_rotateAngleY.Name = "tx_rotateAngleY";
            this.tx_rotateAngleY.Size = new System.Drawing.Size(39, 20);
            this.tx_rotateAngleY.TabIndex = 14;
            this.tx_rotateAngleY.Text = "0";
            this.tx_rotateAngleY.Enter += new System.EventHandler(this.tx_Enter);
            this.tx_rotateAngleY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_RotateTranslate_KeyDown);
            this.tx_rotateAngleY.Leave += new System.EventHandler(this.tx_Leave);
            // 
            // tx_rotateAngleZ
            // 
            this.tx_rotateAngleZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tx_rotateAngleZ.Location = new System.Drawing.Point(27, 84);
            this.tx_rotateAngleZ.Name = "tx_rotateAngleZ";
            this.tx_rotateAngleZ.Size = new System.Drawing.Size(39, 20);
            this.tx_rotateAngleZ.TabIndex = 15;
            this.tx_rotateAngleZ.Text = "0";
            this.tx_rotateAngleZ.Enter += new System.EventHandler(this.tx_Enter);
            this.tx_rotateAngleZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_RotateTranslate_KeyDown);
            this.tx_rotateAngleZ.Leave += new System.EventHandler(this.tx_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Y";
            // 
            // lb_selectedPoints2
            // 
            this.lb_selectedPoints2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_selectedPoints2.AutoSize = true;
            this.lb_selectedPoints2.BackColor = System.Drawing.Color.AliceBlue;
            this.lb_selectedPoints2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_selectedPoints2.ForeColor = System.Drawing.Color.DarkBlue;
            this.lb_selectedPoints2.Location = new System.Drawing.Point(973, 344);
            this.lb_selectedPoints2.Name = "lb_selectedPoints2";
            this.lb_selectedPoints2.Size = new System.Drawing.Size(15, 16);
            this.lb_selectedPoints2.TabIndex = 91;
            this.lb_selectedPoints2.Text = "0";
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.AutoSize = false;
            this.toolStripMenu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.toolStripMenu.GripMargin = new System.Windows.Forms.Padding(4);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrip_Hand,
            this.tstrip_Select,
            this.tstrip_Ruler,
            this.toolStripSeparator5,
            this.tstrip_lockSelection,
            this.toolStripSeparator7});
            this.toolStripMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripMenu.Location = new System.Drawing.Point(0, 24);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1139, 33);
            this.toolStripMenu.Stretch = true;
            this.toolStripMenu.TabIndex = 92;
            this.toolStripMenu.Text = "toolStripMenu";
            // 
            // tstrip_Hand
            // 
            this.tstrip_Hand.AutoSize = false;
            this.tstrip_Hand.BackColor = System.Drawing.Color.Transparent;
            this.tstrip_Hand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstrip_Hand.Image = global::OrthoAid_3DSimulator.Properties.Resources.hand___mainSize;
            this.tstrip_Hand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrip_Hand.Margin = new System.Windows.Forms.Padding(0);
            this.tstrip_Hand.Name = "tstrip_Hand";
            this.tstrip_Hand.Size = new System.Drawing.Size(35, 33);
            this.tstrip_Hand.Text = "Rotate View";
            this.tstrip_Hand.Click += new System.EventHandler(this.tstrip_Hand_Click);
            // 
            // tstrip_Select
            // 
            this.tstrip_Select.AutoSize = false;
            this.tstrip_Select.BackColor = System.Drawing.Color.Transparent;
            this.tstrip_Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstrip_Select.Image = global::OrthoAid_3DSimulator.Properties.Resources.whiteCurser___mainSize;
            this.tstrip_Select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrip_Select.Margin = new System.Windows.Forms.Padding(0);
            this.tstrip_Select.Name = "tstrip_Select";
            this.tstrip_Select.Size = new System.Drawing.Size(35, 33);
            this.tstrip_Select.Text = "Select Vertex";
            this.tstrip_Select.Click += new System.EventHandler(this.tstrip_Select_Click);
            // 
            // tstrip_Ruler
            // 
            this.tstrip_Ruler.AutoSize = false;
            this.tstrip_Ruler.BackColor = System.Drawing.Color.Transparent;
            this.tstrip_Ruler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstrip_Ruler.Image = global::OrthoAid_3DSimulator.Properties.Resources.ruler_icon;
            this.tstrip_Ruler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrip_Ruler.Margin = new System.Windows.Forms.Padding(0);
            this.tstrip_Ruler.Name = "tstrip_Ruler";
            this.tstrip_Ruler.Size = new System.Drawing.Size(35, 33);
            this.tstrip_Ruler.Text = "Ruler";
            this.tstrip_Ruler.Click += new System.EventHandler(this.tstrip_Ruler_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // tstrip_lockSelection
            // 
            this.tstrip_lockSelection.AutoSize = false;
            this.tstrip_lockSelection.CheckOnClick = true;
            this.tstrip_lockSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tstrip_lockSelection.Image = ((System.Drawing.Image)(resources.GetObject("tstrip_lockSelection.Image")));
            this.tstrip_lockSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrip_lockSelection.Name = "tstrip_lockSelection";
            this.tstrip_lockSelection.Size = new System.Drawing.Size(87, 33);
            this.tstrip_lockSelection.Text = "Lock Selection";
            this.tstrip_lockSelection.Click += new System.EventHandler(this.tstrip_lockSelection_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // lview_selectedPoints1
            // 
            this.lview_selectedPoints1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lview_selectedPoints1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Selected_Points1});
            this.lview_selectedPoints1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lview_selectedPoints1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lview_selectedPoints1.Location = new System.Drawing.Point(913, 57);
            this.lview_selectedPoints1.Name = "lview_selectedPoints1";
            this.lview_selectedPoints1.Size = new System.Drawing.Size(137, 277);
            this.lview_selectedPoints1.TabIndex = 93;
            this.lview_selectedPoints1.UseCompatibleStateImageBehavior = false;
            this.lview_selectedPoints1.View = System.Windows.Forms.View.Details;
            this.lview_selectedPoints1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lview_selectedPoints_KeyDown);
            // 
            // Selected_Points1
            // 
            this.Selected_Points1.Text = "Cast 1";
            this.Selected_Points1.Width = 116;
            // 
            // lview_selectedPoints2
            // 
            this.lview_selectedPoints2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lview_selectedPoints2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Selected_Points2});
            this.lview_selectedPoints2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lview_selectedPoints2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lview_selectedPoints2.Location = new System.Drawing.Point(913, 338);
            this.lview_selectedPoints2.Name = "lview_selectedPoints2";
            this.lview_selectedPoints2.Size = new System.Drawing.Size(137, 276);
            this.lview_selectedPoints2.TabIndex = 94;
            this.lview_selectedPoints2.UseCompatibleStateImageBehavior = false;
            this.lview_selectedPoints2.View = System.Windows.Forms.View.Details;
            this.lview_selectedPoints2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lview_selectedPoints_KeyDown);
            // 
            // Selected_Points2
            // 
            this.Selected_Points2.Text = "Cast 2";
            this.Selected_Points2.Width = 117;
            // 
            // b_Calculate
            // 
            this.b_Calculate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.b_Calculate.BackgroundImage = global::OrthoAid_3DSimulator.Properties.Resources.bottomControl;
            this.b_Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.b_Calculate.Location = new System.Drawing.Point(815, 181);
            this.b_Calculate.Name = "b_Calculate";
            this.b_Calculate.Size = new System.Drawing.Size(63, 29);
            this.b_Calculate.TabIndex = 61;
            this.b_Calculate.Text = "Calculate";
            this.toolTip1.SetToolTip(this.b_Calculate, "( I )");
            this.b_Calculate.UseVisualStyleBackColor = true;
            this.b_Calculate.Click += new System.EventHandler(this.b_Calculate_Click);
            // 
            // b_clearSelection
            // 
            this.b_clearSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_clearSelection.BackgroundImage = global::OrthoAid_3DSimulator.Properties.Resources.bottomControl;
            this.b_clearSelection.Location = new System.Drawing.Point(929, 615);
            this.b_clearSelection.Name = "b_clearSelection";
            this.b_clearSelection.Size = new System.Drawing.Size(107, 22);
            this.b_clearSelection.TabIndex = 95;
            this.b_clearSelection.Text = "Clear Selection";
            this.b_clearSelection.UseVisualStyleBackColor = true;
            this.b_clearSelection.Click += new System.EventHandler(this.b_clearSelection_Click);
            // 
            // b_superImpose
            // 
            this.b_superImpose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_superImpose.BackgroundImage = global::OrthoAid_3DSimulator.Properties.Resources.bottomControl;
            this.b_superImpose.Location = new System.Drawing.Point(10, 75);
            this.b_superImpose.Name = "b_superImpose";
            this.b_superImpose.Size = new System.Drawing.Size(49, 69);
            this.b_superImpose.TabIndex = 88;
            this.b_superImpose.Text = "Super Impose";
            this.b_superImpose.UseVisualStyleBackColor = true;
            this.b_superImpose.Click += new System.EventHandler(this.b_superImpose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = global::OrthoAid_3DSimulator.Properties.Resources.LightScroll;
            this.groupBox2.Controls.Add(this.vScroll_lightIntensity);
            this.groupBox2.Location = new System.Drawing.Point(3, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(44, 157);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Light";
            // 
            // vScroll_lightIntensity
            // 
            this.vScroll_lightIntensity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.vScroll_lightIntensity.Location = new System.Drawing.Point(26, 17);
            this.vScroll_lightIntensity.Name = "vScroll_lightIntensity";
            this.vScroll_lightIntensity.Size = new System.Drawing.Size(16, 138);
            this.vScroll_lightIntensity.TabIndex = 72;
            this.vScroll_lightIntensity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScroll_lightIntensity_Scroll);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.BackColor = System.Drawing.Color.Lavender;
            this.groupBox6.BackgroundImage = global::OrthoAid_3DSimulator.Properties.Resources.bottomControl;
            this.groupBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox6.Controls.Add(this.b_clearCalculations);
            this.groupBox6.Controls.Add(this.b_Calculate);
            this.groupBox6.Controls.Add(this.tab_Maintab);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox6.Location = new System.Drawing.Point(3, 397);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(906, 240);
            this.groupBox6.TabIndex = 88;
            this.groupBox6.TabStop = false;
            // 
            // b_clearCalculations
            // 
            this.b_clearCalculations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.b_clearCalculations.BackgroundImage = global::OrthoAid_3DSimulator.Properties.Resources.bottomControl;
            this.b_clearCalculations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.b_clearCalculations.Location = new System.Drawing.Point(815, 208);
            this.b_clearCalculations.Name = "b_clearCalculations";
            this.b_clearCalculations.Size = new System.Drawing.Size(63, 25);
            this.b_clearCalculations.TabIndex = 88;
            this.b_clearCalculations.Text = "Clear All";
            this.b_clearCalculations.UseVisualStyleBackColor = true;
            this.b_clearCalculations.Click += new System.EventHandler(this.b_clearCalculations_Click);
            // 
            // tab_Maintab
            // 
            this.tab_Maintab.Controls.Add(this.tab_Planes);
            this.tab_Maintab.Controls.Add(this.tab_Inclination);
            this.tab_Maintab.Controls.Add(this.tab_Dislocation);
            this.tab_Maintab.Controls.Add(this.tab_Distance2Plane);
            this.tab_Maintab.Controls.Add(this.tab_SuperInclin);
            this.tab_Maintab.Controls.Add(this.tab_CurveFit);
            this.tab_Maintab.Location = new System.Drawing.Point(0, 3);
            this.tab_Maintab.Name = "tab_Maintab";
            this.tab_Maintab.SelectedIndex = 0;
            this.tab_Maintab.Size = new System.Drawing.Size(796, 237);
            this.tab_Maintab.TabIndex = 89;
            this.tab_Maintab.SelectedIndexChanged += new System.EventHandler(this.tab_Maintab_SelectedIndexChanged);
            // 
            // tab_Planes
            // 
            this.tab_Planes.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tab_Planes.Controls.Add(this.label13);
            this.tab_Planes.Controls.Add(this.lb_occlusalPlanesAngle);
            this.tab_Planes.Controls.Add(this.lb_saggitalPlane);
            this.tab_Planes.Controls.Add(this.label12);
            this.tab_Planes.Controls.Add(this.cb_saggitalPlane1);
            this.tab_Planes.Controls.Add(this.cb_occlusalPlane2);
            this.tab_Planes.Controls.Add(this.cb_saggitalPlane2);
            this.tab_Planes.Controls.Add(this.cb_occlusalPlane1);
            this.tab_Planes.Controls.Add(this.lb_occlusalPlane);
            this.tab_Planes.Location = new System.Drawing.Point(4, 22);
            this.tab_Planes.Name = "tab_Planes";
            this.tab_Planes.Size = new System.Drawing.Size(788, 211);
            this.tab_Planes.TabIndex = 5;
            this.tab_Planes.Text = "Planes";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(59, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 96;
            this.label13.Text = "Show";
            // 
            // lb_occlusalPlanesAngle
            // 
            this.lb_occlusalPlanesAngle.AutoSize = true;
            this.lb_occlusalPlanesAngle.Location = new System.Drawing.Point(274, 41);
            this.lb_occlusalPlanesAngle.Name = "lb_occlusalPlanesAngle";
            this.lb_occlusalPlanesAngle.Size = new System.Drawing.Size(13, 13);
            this.lb_occlusalPlanesAngle.TabIndex = 95;
            this.lb_occlusalPlanesAngle.Text = "0";
            this.lb_occlusalPlanesAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_saggitalPlane
            // 
            this.lb_saggitalPlane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_saggitalPlane.BackColor = System.Drawing.Color.AliceBlue;
            this.lb_saggitalPlane.Location = new System.Drawing.Point(5, 81);
            this.lb_saggitalPlane.MaximumSize = new System.Drawing.Size(50, 100);
            this.lb_saggitalPlane.Name = "lb_saggitalPlane";
            this.lb_saggitalPlane.Size = new System.Drawing.Size(50, 42);
            this.lb_saggitalPlane.TabIndex = 2;
            this.lb_saggitalPlane.Tag = "34";
            this.lb_saggitalPlane.Text = "Saggital Plane";
            this.lb_saggitalPlane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_saggitalPlane.UseCompatibleTextRendering = true;
            this.lb_saggitalPlane.Click += new System.EventHandler(this.LabelSelect);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(108, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 13);
            this.label12.TabIndex = 94;
            this.label12.Text = "Angle between Occlusal Planes: ";
            // 
            // cb_saggitalPlane1
            // 
            this.cb_saggitalPlane1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_saggitalPlane1.AutoSize = true;
            this.cb_saggitalPlane1.Enabled = false;
            this.cb_saggitalPlane1.Location = new System.Drawing.Point(65, 84);
            this.cb_saggitalPlane1.Name = "cb_saggitalPlane1";
            this.cb_saggitalPlane1.Size = new System.Drawing.Size(15, 14);
            this.cb_saggitalPlane1.TabIndex = 20;
            this.cb_saggitalPlane1.UseVisualStyleBackColor = true;
            // 
            // cb_occlusalPlane2
            // 
            this.cb_occlusalPlane2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_occlusalPlane2.AutoSize = true;
            this.cb_occlusalPlane2.Enabled = false;
            this.cb_occlusalPlane2.Location = new System.Drawing.Point(66, 51);
            this.cb_occlusalPlane2.Name = "cb_occlusalPlane2";
            this.cb_occlusalPlane2.Size = new System.Drawing.Size(15, 14);
            this.cb_occlusalPlane2.TabIndex = 93;
            this.cb_occlusalPlane2.UseVisualStyleBackColor = true;
            // 
            // cb_saggitalPlane2
            // 
            this.cb_saggitalPlane2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_saggitalPlane2.AutoSize = true;
            this.cb_saggitalPlane2.Enabled = false;
            this.cb_saggitalPlane2.Location = new System.Drawing.Point(65, 107);
            this.cb_saggitalPlane2.Name = "cb_saggitalPlane2";
            this.cb_saggitalPlane2.Size = new System.Drawing.Size(15, 14);
            this.cb_saggitalPlane2.TabIndex = 20;
            this.cb_saggitalPlane2.UseVisualStyleBackColor = true;
            // 
            // cb_occlusalPlane1
            // 
            this.cb_occlusalPlane1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_occlusalPlane1.AutoSize = true;
            this.cb_occlusalPlane1.Enabled = false;
            this.cb_occlusalPlane1.Location = new System.Drawing.Point(66, 30);
            this.cb_occlusalPlane1.Name = "cb_occlusalPlane1";
            this.cb_occlusalPlane1.Size = new System.Drawing.Size(15, 14);
            this.cb_occlusalPlane1.TabIndex = 18;
            this.cb_occlusalPlane1.UseVisualStyleBackColor = true;
            // 
            // lb_occlusalPlane
            // 
            this.lb_occlusalPlane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_occlusalPlane.BackColor = System.Drawing.Color.AliceBlue;
            this.lb_occlusalPlane.Location = new System.Drawing.Point(5, 26);
            this.lb_occlusalPlane.MaximumSize = new System.Drawing.Size(50, 100);
            this.lb_occlusalPlane.Name = "lb_occlusalPlane";
            this.lb_occlusalPlane.Size = new System.Drawing.Size(50, 42);
            this.lb_occlusalPlane.TabIndex = 60;
            this.lb_occlusalPlane.Tag = "33";
            this.lb_occlusalPlane.Text = "Occlusal Plane";
            this.lb_occlusalPlane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_occlusalPlane.UseCompatibleTextRendering = true;
            this.lb_occlusalPlane.Click += new System.EventHandler(this.LabelSelect);
            // 
            // tab_Inclination
            // 
            this.tab_Inclination.Controls.Add(this.cb_t16);
            this.tab_Inclination.Controls.Add(this.cb_t15);
            this.tab_Inclination.Controls.Add(this.cb_t14);
            this.tab_Inclination.Controls.Add(this.cb_t13);
            this.tab_Inclination.Controls.Add(this.cb_t12);
            this.tab_Inclination.Controls.Add(this.cb_t11);
            this.tab_Inclination.Controls.Add(this.cb_t10);
            this.tab_Inclination.Controls.Add(this.cb_t9);
            this.tab_Inclination.Controls.Add(this.cb_t8);
            this.tab_Inclination.Controls.Add(this.cb_t7);
            this.tab_Inclination.Controls.Add(this.cb_t6);
            this.tab_Inclination.Controls.Add(this.cb_t5);
            this.tab_Inclination.Controls.Add(this.cb_t4);
            this.tab_Inclination.Controls.Add(this.cb_t3);
            this.tab_Inclination.Controls.Add(this.cb_t2);
            this.tab_Inclination.Controls.Add(this.cb_t1);
            this.tab_Inclination.Controls.Add(this.cb_t17);
            this.tab_Inclination.Controls.Add(this.cb_t18);
            this.tab_Inclination.Controls.Add(this.cb_t19);
            this.tab_Inclination.Controls.Add(this.cb_t20);
            this.tab_Inclination.Controls.Add(this.cb_t21);
            this.tab_Inclination.Controls.Add(this.cb_t22);
            this.tab_Inclination.Controls.Add(this.cb_t23);
            this.tab_Inclination.Controls.Add(this.cb_t24);
            this.tab_Inclination.Controls.Add(this.cb_t25);
            this.tab_Inclination.Controls.Add(this.cb_t26);
            this.tab_Inclination.Controls.Add(this.cb_t27);
            this.tab_Inclination.Controls.Add(this.cb_t32);
            this.tab_Inclination.Controls.Add(this.cb_t31);
            this.tab_Inclination.Controls.Add(this.cb_t30);
            this.tab_Inclination.Controls.Add(this.cb_t28);
            this.tab_Inclination.Controls.Add(this.cb_t29);
            this.tab_Inclination.Controls.Add(this.groupBox5);
            this.tab_Inclination.Controls.Add(this.v1t17);
            this.tab_Inclination.Controls.Add(this.v1t18);
            this.tab_Inclination.Controls.Add(this.v1t25);
            this.tab_Inclination.Controls.Add(this.v1t26);
            this.tab_Inclination.Controls.Add(this.v1t19);
            this.tab_Inclination.Controls.Add(this.v1t27);
            this.tab_Inclination.Controls.Add(this.v1t20);
            this.tab_Inclination.Controls.Add(this.v1t28);
            this.tab_Inclination.Controls.Add(this.v1t21);
            this.tab_Inclination.Controls.Add(this.v1t29);
            this.tab_Inclination.Controls.Add(this.v1t22);
            this.tab_Inclination.Controls.Add(this.v1t30);
            this.tab_Inclination.Controls.Add(this.v1t32);
            this.tab_Inclination.Controls.Add(this.v1t23);
            this.tab_Inclination.Controls.Add(this.v1t31);
            this.tab_Inclination.Controls.Add(this.v1t24);
            this.tab_Inclination.Controls.Add(this.v1t16);
            this.tab_Inclination.Controls.Add(this.v1t15);
            this.tab_Inclination.Controls.Add(this.v1t8);
            this.tab_Inclination.Controls.Add(this.v1t1);
            this.tab_Inclination.Controls.Add(this.v1t7);
            this.tab_Inclination.Controls.Add(this.v1t9);
            this.tab_Inclination.Controls.Add(this.v1t14);
            this.tab_Inclination.Controls.Add(this.v1t2);
            this.tab_Inclination.Controls.Add(this.v1t6);
            this.tab_Inclination.Controls.Add(this.v1t10);
            this.tab_Inclination.Controls.Add(this.v1t13);
            this.tab_Inclination.Controls.Add(this.v1t3);
            this.tab_Inclination.Controls.Add(this.v1t5);
            this.tab_Inclination.Controls.Add(this.v1t12);
            this.tab_Inclination.Controls.Add(this.v1t4);
            this.tab_Inclination.Controls.Add(this.v1t11);
            this.tab_Inclination.Location = new System.Drawing.Point(4, 22);
            this.tab_Inclination.Name = "tab_Inclination";
            this.tab_Inclination.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Inclination.Size = new System.Drawing.Size(788, 211);
            this.tab_Inclination.TabIndex = 1;
            this.tab_Inclination.Text = "Inclination";
            this.tab_Inclination.UseVisualStyleBackColor = true;
            // 
            // cb_t16
            // 
            this.cb_t16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t16.AutoSize = true;
            this.cb_t16.Location = new System.Drawing.Point(753, 25);
            this.cb_t16.Name = "cb_t16";
            this.cb_t16.Size = new System.Drawing.Size(15, 14);
            this.cb_t16.TabIndex = 234;
            this.cb_t16.UseVisualStyleBackColor = true;
            // 
            // cb_t15
            // 
            this.cb_t15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t15.AutoSize = true;
            this.cb_t15.Location = new System.Drawing.Point(692, 25);
            this.cb_t15.Name = "cb_t15";
            this.cb_t15.Size = new System.Drawing.Size(15, 14);
            this.cb_t15.TabIndex = 233;
            this.cb_t15.UseVisualStyleBackColor = true;
            // 
            // cb_t14
            // 
            this.cb_t14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t14.AutoSize = true;
            this.cb_t14.Location = new System.Drawing.Point(640, 25);
            this.cb_t14.Name = "cb_t14";
            this.cb_t14.Size = new System.Drawing.Size(15, 14);
            this.cb_t14.TabIndex = 232;
            this.cb_t14.UseVisualStyleBackColor = true;
            // 
            // cb_t13
            // 
            this.cb_t13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t13.AutoSize = true;
            this.cb_t13.Location = new System.Drawing.Point(594, 25);
            this.cb_t13.Name = "cb_t13";
            this.cb_t13.Size = new System.Drawing.Size(15, 14);
            this.cb_t13.TabIndex = 231;
            this.cb_t13.UseVisualStyleBackColor = true;
            // 
            // cb_t12
            // 
            this.cb_t12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t12.AutoSize = true;
            this.cb_t12.Location = new System.Drawing.Point(554, 25);
            this.cb_t12.Name = "cb_t12";
            this.cb_t12.Size = new System.Drawing.Size(15, 14);
            this.cb_t12.TabIndex = 230;
            this.cb_t12.UseVisualStyleBackColor = true;
            // 
            // cb_t11
            // 
            this.cb_t11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t11.AutoSize = true;
            this.cb_t11.Location = new System.Drawing.Point(517, 25);
            this.cb_t11.Name = "cb_t11";
            this.cb_t11.Size = new System.Drawing.Size(15, 14);
            this.cb_t11.TabIndex = 229;
            this.cb_t11.UseVisualStyleBackColor = true;
            // 
            // cb_t10
            // 
            this.cb_t10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t10.AutoSize = true;
            this.cb_t10.Location = new System.Drawing.Point(480, 25);
            this.cb_t10.Name = "cb_t10";
            this.cb_t10.Size = new System.Drawing.Size(15, 14);
            this.cb_t10.TabIndex = 228;
            this.cb_t10.UseVisualStyleBackColor = true;
            // 
            // cb_t9
            // 
            this.cb_t9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t9.AutoSize = true;
            this.cb_t9.Location = new System.Drawing.Point(442, 25);
            this.cb_t9.Name = "cb_t9";
            this.cb_t9.Size = new System.Drawing.Size(15, 14);
            this.cb_t9.TabIndex = 227;
            this.cb_t9.UseVisualStyleBackColor = true;
            // 
            // cb_t8
            // 
            this.cb_t8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t8.AutoSize = true;
            this.cb_t8.Location = new System.Drawing.Point(405, 25);
            this.cb_t8.Name = "cb_t8";
            this.cb_t8.Size = new System.Drawing.Size(15, 14);
            this.cb_t8.TabIndex = 226;
            this.cb_t8.UseVisualStyleBackColor = true;
            // 
            // cb_t7
            // 
            this.cb_t7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t7.AutoSize = true;
            this.cb_t7.Location = new System.Drawing.Point(367, 25);
            this.cb_t7.Name = "cb_t7";
            this.cb_t7.Size = new System.Drawing.Size(15, 14);
            this.cb_t7.TabIndex = 225;
            this.cb_t7.UseVisualStyleBackColor = true;
            // 
            // cb_t6
            // 
            this.cb_t6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t6.AutoSize = true;
            this.cb_t6.Location = new System.Drawing.Point(332, 25);
            this.cb_t6.Name = "cb_t6";
            this.cb_t6.Size = new System.Drawing.Size(15, 14);
            this.cb_t6.TabIndex = 224;
            this.cb_t6.UseVisualStyleBackColor = true;
            // 
            // cb_t5
            // 
            this.cb_t5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t5.AutoSize = true;
            this.cb_t5.Location = new System.Drawing.Point(294, 25);
            this.cb_t5.Name = "cb_t5";
            this.cb_t5.Size = new System.Drawing.Size(15, 14);
            this.cb_t5.TabIndex = 223;
            this.cb_t5.UseVisualStyleBackColor = true;
            // 
            // cb_t4
            // 
            this.cb_t4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t4.AutoSize = true;
            this.cb_t4.Location = new System.Drawing.Point(253, 25);
            this.cb_t4.Name = "cb_t4";
            this.cb_t4.Size = new System.Drawing.Size(15, 14);
            this.cb_t4.TabIndex = 222;
            this.cb_t4.UseVisualStyleBackColor = true;
            // 
            // cb_t3
            // 
            this.cb_t3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t3.AutoSize = true;
            this.cb_t3.Location = new System.Drawing.Point(207, 25);
            this.cb_t3.Name = "cb_t3";
            this.cb_t3.Size = new System.Drawing.Size(15, 14);
            this.cb_t3.TabIndex = 221;
            this.cb_t3.UseVisualStyleBackColor = true;
            // 
            // cb_t2
            // 
            this.cb_t2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t2.AutoSize = true;
            this.cb_t2.Location = new System.Drawing.Point(154, 25);
            this.cb_t2.Name = "cb_t2";
            this.cb_t2.Size = new System.Drawing.Size(15, 14);
            this.cb_t2.TabIndex = 220;
            this.cb_t2.UseVisualStyleBackColor = true;
            // 
            // cb_t1
            // 
            this.cb_t1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_t1.AutoSize = true;
            this.cb_t1.Location = new System.Drawing.Point(96, 25);
            this.cb_t1.Name = "cb_t1";
            this.cb_t1.Size = new System.Drawing.Size(15, 14);
            this.cb_t1.TabIndex = 235;
            this.cb_t1.UseVisualStyleBackColor = true;
            // 
            // cb_t17
            // 
            this.cb_t17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t17.AutoSize = true;
            this.cb_t17.Location = new System.Drawing.Point(752, 178);
            this.cb_t17.Name = "cb_t17";
            this.cb_t17.Size = new System.Drawing.Size(15, 14);
            this.cb_t17.TabIndex = 204;
            this.cb_t17.UseVisualStyleBackColor = true;
            // 
            // cb_t18
            // 
            this.cb_t18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t18.AutoSize = true;
            this.cb_t18.Location = new System.Drawing.Point(690, 178);
            this.cb_t18.Name = "cb_t18";
            this.cb_t18.Size = new System.Drawing.Size(15, 14);
            this.cb_t18.TabIndex = 218;
            this.cb_t18.UseVisualStyleBackColor = true;
            // 
            // cb_t19
            // 
            this.cb_t19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t19.AutoSize = true;
            this.cb_t19.Location = new System.Drawing.Point(638, 178);
            this.cb_t19.Name = "cb_t19";
            this.cb_t19.Size = new System.Drawing.Size(15, 14);
            this.cb_t19.TabIndex = 217;
            this.cb_t19.UseVisualStyleBackColor = true;
            // 
            // cb_t20
            // 
            this.cb_t20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t20.AutoSize = true;
            this.cb_t20.Location = new System.Drawing.Point(592, 178);
            this.cb_t20.Name = "cb_t20";
            this.cb_t20.Size = new System.Drawing.Size(15, 14);
            this.cb_t20.TabIndex = 216;
            this.cb_t20.UseVisualStyleBackColor = true;
            // 
            // cb_t21
            // 
            this.cb_t21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t21.AutoSize = true;
            this.cb_t21.Location = new System.Drawing.Point(552, 178);
            this.cb_t21.Name = "cb_t21";
            this.cb_t21.Size = new System.Drawing.Size(15, 14);
            this.cb_t21.TabIndex = 215;
            this.cb_t21.UseVisualStyleBackColor = true;
            // 
            // cb_t22
            // 
            this.cb_t22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t22.AutoSize = true;
            this.cb_t22.Location = new System.Drawing.Point(515, 178);
            this.cb_t22.Name = "cb_t22";
            this.cb_t22.Size = new System.Drawing.Size(15, 14);
            this.cb_t22.TabIndex = 214;
            this.cb_t22.UseVisualStyleBackColor = true;
            // 
            // cb_t23
            // 
            this.cb_t23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t23.AutoSize = true;
            this.cb_t23.Location = new System.Drawing.Point(478, 178);
            this.cb_t23.Name = "cb_t23";
            this.cb_t23.Size = new System.Drawing.Size(15, 14);
            this.cb_t23.TabIndex = 213;
            this.cb_t23.UseVisualStyleBackColor = true;
            // 
            // cb_t24
            // 
            this.cb_t24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t24.AutoSize = true;
            this.cb_t24.Location = new System.Drawing.Point(440, 178);
            this.cb_t24.Name = "cb_t24";
            this.cb_t24.Size = new System.Drawing.Size(15, 14);
            this.cb_t24.TabIndex = 212;
            this.cb_t24.UseVisualStyleBackColor = true;
            // 
            // cb_t25
            // 
            this.cb_t25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t25.AutoSize = true;
            this.cb_t25.Location = new System.Drawing.Point(403, 178);
            this.cb_t25.Name = "cb_t25";
            this.cb_t25.Size = new System.Drawing.Size(15, 14);
            this.cb_t25.TabIndex = 211;
            this.cb_t25.UseVisualStyleBackColor = true;
            // 
            // cb_t26
            // 
            this.cb_t26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t26.AutoSize = true;
            this.cb_t26.Location = new System.Drawing.Point(365, 178);
            this.cb_t26.Name = "cb_t26";
            this.cb_t26.Size = new System.Drawing.Size(15, 14);
            this.cb_t26.TabIndex = 210;
            this.cb_t26.UseVisualStyleBackColor = true;
            // 
            // cb_t27
            // 
            this.cb_t27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t27.AutoSize = true;
            this.cb_t27.Location = new System.Drawing.Point(330, 178);
            this.cb_t27.Name = "cb_t27";
            this.cb_t27.Size = new System.Drawing.Size(15, 14);
            this.cb_t27.TabIndex = 209;
            this.cb_t27.UseVisualStyleBackColor = true;
            // 
            // cb_t32
            // 
            this.cb_t32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t32.AutoSize = true;
            this.cb_t32.Location = new System.Drawing.Point(96, 178);
            this.cb_t32.Name = "cb_t32";
            this.cb_t32.Size = new System.Drawing.Size(15, 14);
            this.cb_t32.TabIndex = 219;
            this.cb_t32.UseVisualStyleBackColor = true;
            // 
            // cb_t31
            // 
            this.cb_t31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t31.AutoSize = true;
            this.cb_t31.Location = new System.Drawing.Point(154, 178);
            this.cb_t31.Name = "cb_t31";
            this.cb_t31.Size = new System.Drawing.Size(15, 14);
            this.cb_t31.TabIndex = 205;
            this.cb_t31.UseVisualStyleBackColor = true;
            // 
            // cb_t30
            // 
            this.cb_t30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t30.AutoSize = true;
            this.cb_t30.Location = new System.Drawing.Point(205, 178);
            this.cb_t30.Name = "cb_t30";
            this.cb_t30.Size = new System.Drawing.Size(15, 14);
            this.cb_t30.TabIndex = 206;
            this.cb_t30.UseVisualStyleBackColor = true;
            // 
            // cb_t28
            // 
            this.cb_t28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t28.AutoSize = true;
            this.cb_t28.Location = new System.Drawing.Point(292, 178);
            this.cb_t28.Name = "cb_t28";
            this.cb_t28.Size = new System.Drawing.Size(15, 14);
            this.cb_t28.TabIndex = 208;
            this.cb_t28.UseVisualStyleBackColor = true;
            // 
            // cb_t29
            // 
            this.cb_t29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_t29.AutoSize = true;
            this.cb_t29.Location = new System.Drawing.Point(251, 178);
            this.cb_t29.Name = "cb_t29";
            this.cb_t29.Size = new System.Drawing.Size(15, 14);
            this.cb_t29.TabIndex = 207;
            this.cb_t29.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.rb_BBCmiddle);
            this.groupBox5.Controls.Add(this.rb_BBPuser);
            this.groupBox5.Location = new System.Drawing.Point(-2, 73);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(84, 48);
            this.groupBox5.TabIndex = 92;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "BBP Choice";
            // 
            // rb_BBCmiddle
            // 
            this.rb_BBCmiddle.AutoSize = true;
            this.rb_BBCmiddle.Location = new System.Drawing.Point(6, 28);
            this.rb_BBCmiddle.Name = "rb_BBCmiddle";
            this.rb_BBCmiddle.Size = new System.Drawing.Size(47, 17);
            this.rb_BBCmiddle.TabIndex = 1;
            this.rb_BBCmiddle.TabStop = true;
            this.rb_BBCmiddle.Text = "Auto";
            this.rb_BBCmiddle.UseVisualStyleBackColor = true;
            this.rb_BBCmiddle.CheckedChanged += new System.EventHandler(this.rb_BBCmiddle_CheckedChanged);
            // 
            // rb_BBPuser
            // 
            this.rb_BBPuser.AutoSize = true;
            this.rb_BBPuser.Location = new System.Drawing.Point(6, 13);
            this.rb_BBPuser.Name = "rb_BBPuser";
            this.rb_BBPuser.Size = new System.Drawing.Size(60, 17);
            this.rb_BBPuser.TabIndex = 0;
            this.rb_BBPuser.TabStop = true;
            this.rb_BBPuser.Text = "Manual";
            this.rb_BBPuser.UseVisualStyleBackColor = true;
            this.rb_BBPuser.CheckedChanged += new System.EventHandler(this.rb_BBPuser_CheckedChanged);
            // 
            // v1t17
            // 
            this.v1t17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t17.AutoSize = true;
            this.v1t17.Location = new System.Drawing.Point(753, 195);
            this.v1t17.Name = "v1t17";
            this.v1t17.Size = new System.Drawing.Size(13, 13);
            this.v1t17.TabIndex = 80;
            this.v1t17.Text = "0";
            this.v1t17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t18
            // 
            this.v1t18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t18.AutoSize = true;
            this.v1t18.Location = new System.Drawing.Point(692, 195);
            this.v1t18.Name = "v1t18";
            this.v1t18.Size = new System.Drawing.Size(13, 13);
            this.v1t18.TabIndex = 85;
            this.v1t18.Text = "0";
            this.v1t18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t25
            // 
            this.v1t25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t25.AutoSize = true;
            this.v1t25.Location = new System.Drawing.Point(405, 195);
            this.v1t25.Name = "v1t25";
            this.v1t25.Size = new System.Drawing.Size(13, 13);
            this.v1t25.TabIndex = 86;
            this.v1t25.Text = "0";
            this.v1t25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t26
            // 
            this.v1t26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t26.AutoSize = true;
            this.v1t26.Location = new System.Drawing.Point(367, 195);
            this.v1t26.Name = "v1t26";
            this.v1t26.Size = new System.Drawing.Size(13, 13);
            this.v1t26.TabIndex = 84;
            this.v1t26.Text = "0";
            this.v1t26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t19
            // 
            this.v1t19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t19.AutoSize = true;
            this.v1t19.Location = new System.Drawing.Point(638, 195);
            this.v1t19.Name = "v1t19";
            this.v1t19.Size = new System.Drawing.Size(13, 13);
            this.v1t19.TabIndex = 82;
            this.v1t19.Text = "0";
            this.v1t19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t27
            // 
            this.v1t27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t27.AutoSize = true;
            this.v1t27.Location = new System.Drawing.Point(332, 195);
            this.v1t27.Name = "v1t27";
            this.v1t27.Size = new System.Drawing.Size(13, 13);
            this.v1t27.TabIndex = 83;
            this.v1t27.Text = "0";
            this.v1t27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t20
            // 
            this.v1t20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t20.AutoSize = true;
            this.v1t20.Location = new System.Drawing.Point(594, 195);
            this.v1t20.Name = "v1t20";
            this.v1t20.Size = new System.Drawing.Size(13, 13);
            this.v1t20.TabIndex = 90;
            this.v1t20.Text = "0";
            this.v1t20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t28
            // 
            this.v1t28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t28.AutoSize = true;
            this.v1t28.Location = new System.Drawing.Point(294, 195);
            this.v1t28.Name = "v1t28";
            this.v1t28.Size = new System.Drawing.Size(13, 13);
            this.v1t28.TabIndex = 91;
            this.v1t28.Text = "0";
            this.v1t28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t21
            // 
            this.v1t21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t21.AutoSize = true;
            this.v1t21.Location = new System.Drawing.Point(554, 195);
            this.v1t21.Name = "v1t21";
            this.v1t21.Size = new System.Drawing.Size(13, 13);
            this.v1t21.TabIndex = 89;
            this.v1t21.Text = "0";
            this.v1t21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t29
            // 
            this.v1t29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t29.AutoSize = true;
            this.v1t29.Location = new System.Drawing.Point(253, 195);
            this.v1t29.Name = "v1t29";
            this.v1t29.Size = new System.Drawing.Size(13, 13);
            this.v1t29.TabIndex = 87;
            this.v1t29.Text = "0";
            this.v1t29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t22
            // 
            this.v1t22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t22.AutoSize = true;
            this.v1t22.Location = new System.Drawing.Point(517, 195);
            this.v1t22.Name = "v1t22";
            this.v1t22.Size = new System.Drawing.Size(13, 13);
            this.v1t22.TabIndex = 88;
            this.v1t22.Text = "0";
            this.v1t22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t30
            // 
            this.v1t30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t30.AutoSize = true;
            this.v1t30.Location = new System.Drawing.Point(207, 195);
            this.v1t30.Name = "v1t30";
            this.v1t30.Size = new System.Drawing.Size(13, 13);
            this.v1t30.TabIndex = 79;
            this.v1t30.Text = "0";
            this.v1t30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t32
            // 
            this.v1t32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t32.AutoSize = true;
            this.v1t32.Location = new System.Drawing.Point(96, 195);
            this.v1t32.Name = "v1t32";
            this.v1t32.Size = new System.Drawing.Size(13, 13);
            this.v1t32.TabIndex = 77;
            this.v1t32.Text = "0";
            this.v1t32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t23
            // 
            this.v1t23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t23.AutoSize = true;
            this.v1t23.Location = new System.Drawing.Point(480, 195);
            this.v1t23.Name = "v1t23";
            this.v1t23.Size = new System.Drawing.Size(13, 13);
            this.v1t23.TabIndex = 81;
            this.v1t23.Text = "0";
            this.v1t23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t31
            // 
            this.v1t31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t31.AutoSize = true;
            this.v1t31.Location = new System.Drawing.Point(154, 195);
            this.v1t31.Name = "v1t31";
            this.v1t31.Size = new System.Drawing.Size(13, 13);
            this.v1t31.TabIndex = 78;
            this.v1t31.Text = "0";
            this.v1t31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t24
            // 
            this.v1t24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v1t24.AutoSize = true;
            this.v1t24.Location = new System.Drawing.Point(442, 195);
            this.v1t24.Name = "v1t24";
            this.v1t24.Size = new System.Drawing.Size(13, 13);
            this.v1t24.TabIndex = 76;
            this.v1t24.Text = "0";
            this.v1t24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t16
            // 
            this.v1t16.AutoSize = true;
            this.v1t16.Location = new System.Drawing.Point(753, 8);
            this.v1t16.Name = "v1t16";
            this.v1t16.Size = new System.Drawing.Size(13, 13);
            this.v1t16.TabIndex = 61;
            this.v1t16.Text = "0";
            this.v1t16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t15
            // 
            this.v1t15.AutoSize = true;
            this.v1t15.Location = new System.Drawing.Point(692, 8);
            this.v1t15.Name = "v1t15";
            this.v1t15.Size = new System.Drawing.Size(13, 13);
            this.v1t15.TabIndex = 72;
            this.v1t15.Text = "0";
            this.v1t15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t8
            // 
            this.v1t8.AutoSize = true;
            this.v1t8.Location = new System.Drawing.Point(405, 8);
            this.v1t8.Name = "v1t8";
            this.v1t8.Size = new System.Drawing.Size(13, 13);
            this.v1t8.TabIndex = 71;
            this.v1t8.Text = "0";
            this.v1t8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t1
            // 
            this.v1t1.AutoSize = true;
            this.v1t1.Location = new System.Drawing.Point(96, 8);
            this.v1t1.Name = "v1t1";
            this.v1t1.Size = new System.Drawing.Size(13, 13);
            this.v1t1.TabIndex = 59;
            this.v1t1.Text = "0";
            this.v1t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t7
            // 
            this.v1t7.AutoSize = true;
            this.v1t7.Location = new System.Drawing.Point(367, 8);
            this.v1t7.Name = "v1t7";
            this.v1t7.Size = new System.Drawing.Size(13, 13);
            this.v1t7.TabIndex = 70;
            this.v1t7.Text = "0";
            this.v1t7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t9
            // 
            this.v1t9.AutoSize = true;
            this.v1t9.Location = new System.Drawing.Point(442, 8);
            this.v1t9.Name = "v1t9";
            this.v1t9.Size = new System.Drawing.Size(13, 13);
            this.v1t9.TabIndex = 60;
            this.v1t9.Text = "0";
            this.v1t9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t14
            // 
            this.v1t14.AutoSize = true;
            this.v1t14.Location = new System.Drawing.Point(638, 8);
            this.v1t14.Name = "v1t14";
            this.v1t14.Size = new System.Drawing.Size(13, 13);
            this.v1t14.TabIndex = 69;
            this.v1t14.Text = "0";
            this.v1t14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t2
            // 
            this.v1t2.AutoSize = true;
            this.v1t2.Location = new System.Drawing.Point(154, 8);
            this.v1t2.Name = "v1t2";
            this.v1t2.Size = new System.Drawing.Size(13, 13);
            this.v1t2.TabIndex = 68;
            this.v1t2.Text = "0";
            this.v1t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t6
            // 
            this.v1t6.AutoSize = true;
            this.v1t6.Location = new System.Drawing.Point(332, 8);
            this.v1t6.Name = "v1t6";
            this.v1t6.Size = new System.Drawing.Size(13, 13);
            this.v1t6.TabIndex = 67;
            this.v1t6.Text = "0";
            this.v1t6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t10
            // 
            this.v1t10.AutoSize = true;
            this.v1t10.Location = new System.Drawing.Point(480, 8);
            this.v1t10.Name = "v1t10";
            this.v1t10.Size = new System.Drawing.Size(13, 13);
            this.v1t10.TabIndex = 66;
            this.v1t10.Text = "0";
            this.v1t10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t13
            // 
            this.v1t13.AutoSize = true;
            this.v1t13.Location = new System.Drawing.Point(594, 8);
            this.v1t13.Name = "v1t13";
            this.v1t13.Size = new System.Drawing.Size(13, 13);
            this.v1t13.TabIndex = 65;
            this.v1t13.Text = "0";
            this.v1t13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t3
            // 
            this.v1t3.AutoSize = true;
            this.v1t3.Location = new System.Drawing.Point(207, 8);
            this.v1t3.Name = "v1t3";
            this.v1t3.Size = new System.Drawing.Size(13, 13);
            this.v1t3.TabIndex = 64;
            this.v1t3.Text = "0";
            this.v1t3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t5
            // 
            this.v1t5.AutoSize = true;
            this.v1t5.Location = new System.Drawing.Point(294, 8);
            this.v1t5.Name = "v1t5";
            this.v1t5.Size = new System.Drawing.Size(13, 13);
            this.v1t5.TabIndex = 63;
            this.v1t5.Text = "0";
            this.v1t5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t12
            // 
            this.v1t12.AutoSize = true;
            this.v1t12.Location = new System.Drawing.Point(554, 8);
            this.v1t12.Name = "v1t12";
            this.v1t12.Size = new System.Drawing.Size(13, 13);
            this.v1t12.TabIndex = 62;
            this.v1t12.Text = "0";
            this.v1t12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t4
            // 
            this.v1t4.AutoSize = true;
            this.v1t4.Location = new System.Drawing.Point(253, 8);
            this.v1t4.Name = "v1t4";
            this.v1t4.Size = new System.Drawing.Size(13, 13);
            this.v1t4.TabIndex = 73;
            this.v1t4.Text = "0";
            this.v1t4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v1t11
            // 
            this.v1t11.AutoSize = true;
            this.v1t11.Location = new System.Drawing.Point(517, 8);
            this.v1t11.Name = "v1t11";
            this.v1t11.Size = new System.Drawing.Size(13, 13);
            this.v1t11.TabIndex = 74;
            this.v1t11.Text = "0";
            this.v1t11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tab_Dislocation
            // 
            this.tab_Dislocation.Controls.Add(this.v2t16);
            this.tab_Dislocation.Controls.Add(this.v2t15);
            this.tab_Dislocation.Controls.Add(this.v2t8);
            this.tab_Dislocation.Controls.Add(this.v2t7);
            this.tab_Dislocation.Controls.Add(this.b_superImpose);
            this.tab_Dislocation.Controls.Add(this.v2t14);
            this.tab_Dislocation.Controls.Add(this.v2t1);
            this.tab_Dislocation.Controls.Add(this.v2t17);
            this.tab_Dislocation.Controls.Add(this.v2t18);
            this.tab_Dislocation.Controls.Add(this.v2t25);
            this.tab_Dislocation.Controls.Add(this.v2t6);
            this.tab_Dislocation.Controls.Add(this.v2t9);
            this.tab_Dislocation.Controls.Add(this.v2t26);
            this.tab_Dislocation.Controls.Add(this.v2t13);
            this.tab_Dislocation.Controls.Add(this.v2t19);
            this.tab_Dislocation.Controls.Add(this.v2t2);
            this.tab_Dislocation.Controls.Add(this.v2t27);
            this.tab_Dislocation.Controls.Add(this.v2t20);
            this.tab_Dislocation.Controls.Add(this.v2t5);
            this.tab_Dislocation.Controls.Add(this.v2t12);
            this.tab_Dislocation.Controls.Add(this.v2t28);
            this.tab_Dislocation.Controls.Add(this.v2t21);
            this.tab_Dislocation.Controls.Add(this.v2t10);
            this.tab_Dislocation.Controls.Add(this.v2t4);
            this.tab_Dislocation.Controls.Add(this.v2t29);
            this.tab_Dislocation.Controls.Add(this.v2t3);
            this.tab_Dislocation.Controls.Add(this.v2t22);
            this.tab_Dislocation.Controls.Add(this.v2t11);
            this.tab_Dislocation.Controls.Add(this.v2t32);
            this.tab_Dislocation.Controls.Add(this.v2t24);
            this.tab_Dislocation.Controls.Add(this.v2t30);
            this.tab_Dislocation.Controls.Add(this.v2t23);
            this.tab_Dislocation.Controls.Add(this.v2t31);
            this.tab_Dislocation.Location = new System.Drawing.Point(4, 22);
            this.tab_Dislocation.Name = "tab_Dislocation";
            this.tab_Dislocation.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Dislocation.Size = new System.Drawing.Size(788, 211);
            this.tab_Dislocation.TabIndex = 0;
            this.tab_Dislocation.Text = "Dislocation";
            this.tab_Dislocation.UseVisualStyleBackColor = true;
            // 
            // v2t16
            // 
            this.v2t16.AutoSize = true;
            this.v2t16.Location = new System.Drawing.Point(754, 19);
            this.v2t16.Name = "v2t16";
            this.v2t16.Size = new System.Drawing.Size(13, 13);
            this.v2t16.TabIndex = 25;
            this.v2t16.Text = "0";
            this.v2t16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t15
            // 
            this.v2t15.AutoSize = true;
            this.v2t15.Location = new System.Drawing.Point(693, 19);
            this.v2t15.Name = "v2t15";
            this.v2t15.Size = new System.Drawing.Size(13, 13);
            this.v2t15.TabIndex = 25;
            this.v2t15.Text = "0";
            this.v2t15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t8
            // 
            this.v2t8.AutoSize = true;
            this.v2t8.Location = new System.Drawing.Point(406, 19);
            this.v2t8.Name = "v2t8";
            this.v2t8.Size = new System.Drawing.Size(13, 13);
            this.v2t8.TabIndex = 25;
            this.v2t8.Text = "0";
            this.v2t8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t7
            // 
            this.v2t7.AutoSize = true;
            this.v2t7.Location = new System.Drawing.Point(368, 19);
            this.v2t7.Name = "v2t7";
            this.v2t7.Size = new System.Drawing.Size(13, 13);
            this.v2t7.TabIndex = 25;
            this.v2t7.Text = "0";
            this.v2t7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t14
            // 
            this.v2t14.AutoSize = true;
            this.v2t14.Location = new System.Drawing.Point(639, 19);
            this.v2t14.Name = "v2t14";
            this.v2t14.Size = new System.Drawing.Size(13, 13);
            this.v2t14.TabIndex = 25;
            this.v2t14.Text = "0";
            this.v2t14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t1
            // 
            this.v2t1.AutoSize = true;
            this.v2t1.Location = new System.Drawing.Point(97, 19);
            this.v2t1.Name = "v2t1";
            this.v2t1.Size = new System.Drawing.Size(13, 13);
            this.v2t1.TabIndex = 23;
            this.v2t1.Text = "0";
            this.v2t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t17
            // 
            this.v2t17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t17.AutoSize = true;
            this.v2t17.Location = new System.Drawing.Point(754, 180);
            this.v2t17.Name = "v2t17";
            this.v2t17.Size = new System.Drawing.Size(13, 13);
            this.v2t17.TabIndex = 38;
            this.v2t17.Text = "0";
            this.v2t17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t18
            // 
            this.v2t18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t18.AutoSize = true;
            this.v2t18.Location = new System.Drawing.Point(693, 180);
            this.v2t18.Name = "v2t18";
            this.v2t18.Size = new System.Drawing.Size(13, 13);
            this.v2t18.TabIndex = 40;
            this.v2t18.Text = "0";
            this.v2t18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t25
            // 
            this.v2t25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t25.AutoSize = true;
            this.v2t25.Location = new System.Drawing.Point(406, 180);
            this.v2t25.Name = "v2t25";
            this.v2t25.Size = new System.Drawing.Size(13, 13);
            this.v2t25.TabIndex = 39;
            this.v2t25.Text = "0";
            this.v2t25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t6
            // 
            this.v2t6.AutoSize = true;
            this.v2t6.Location = new System.Drawing.Point(333, 19);
            this.v2t6.Name = "v2t6";
            this.v2t6.Size = new System.Drawing.Size(13, 13);
            this.v2t6.TabIndex = 25;
            this.v2t6.Text = "0";
            this.v2t6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t9
            // 
            this.v2t9.AutoSize = true;
            this.v2t9.Location = new System.Drawing.Point(443, 19);
            this.v2t9.Name = "v2t9";
            this.v2t9.Size = new System.Drawing.Size(13, 13);
            this.v2t9.TabIndex = 23;
            this.v2t9.Text = "0";
            this.v2t9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t26
            // 
            this.v2t26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t26.AutoSize = true;
            this.v2t26.Location = new System.Drawing.Point(368, 180);
            this.v2t26.Name = "v2t26";
            this.v2t26.Size = new System.Drawing.Size(13, 13);
            this.v2t26.TabIndex = 41;
            this.v2t26.Text = "0";
            this.v2t26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t13
            // 
            this.v2t13.AutoSize = true;
            this.v2t13.Location = new System.Drawing.Point(595, 19);
            this.v2t13.Name = "v2t13";
            this.v2t13.Size = new System.Drawing.Size(13, 13);
            this.v2t13.TabIndex = 25;
            this.v2t13.Text = "0";
            this.v2t13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t19
            // 
            this.v2t19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t19.AutoSize = true;
            this.v2t19.Location = new System.Drawing.Point(639, 180);
            this.v2t19.Name = "v2t19";
            this.v2t19.Size = new System.Drawing.Size(13, 13);
            this.v2t19.TabIndex = 43;
            this.v2t19.Text = "0";
            this.v2t19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t2
            // 
            this.v2t2.AutoSize = true;
            this.v2t2.Location = new System.Drawing.Point(155, 19);
            this.v2t2.Name = "v2t2";
            this.v2t2.Size = new System.Drawing.Size(13, 13);
            this.v2t2.TabIndex = 25;
            this.v2t2.Text = "0";
            this.v2t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t27
            // 
            this.v2t27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t27.AutoSize = true;
            this.v2t27.Location = new System.Drawing.Point(333, 180);
            this.v2t27.Name = "v2t27";
            this.v2t27.Size = new System.Drawing.Size(13, 13);
            this.v2t27.TabIndex = 32;
            this.v2t27.Text = "0";
            this.v2t27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t20
            // 
            this.v2t20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t20.AutoSize = true;
            this.v2t20.Location = new System.Drawing.Point(595, 180);
            this.v2t20.Name = "v2t20";
            this.v2t20.Size = new System.Drawing.Size(13, 13);
            this.v2t20.TabIndex = 33;
            this.v2t20.Text = "0";
            this.v2t20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t5
            // 
            this.v2t5.AutoSize = true;
            this.v2t5.Location = new System.Drawing.Point(295, 19);
            this.v2t5.Name = "v2t5";
            this.v2t5.Size = new System.Drawing.Size(13, 13);
            this.v2t5.TabIndex = 25;
            this.v2t5.Text = "0";
            this.v2t5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t12
            // 
            this.v2t12.AutoSize = true;
            this.v2t12.Location = new System.Drawing.Point(555, 19);
            this.v2t12.Name = "v2t12";
            this.v2t12.Size = new System.Drawing.Size(13, 13);
            this.v2t12.TabIndex = 25;
            this.v2t12.Text = "0";
            this.v2t12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t28
            // 
            this.v2t28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t28.AutoSize = true;
            this.v2t28.Location = new System.Drawing.Point(295, 180);
            this.v2t28.Name = "v2t28";
            this.v2t28.Size = new System.Drawing.Size(13, 13);
            this.v2t28.TabIndex = 36;
            this.v2t28.Text = "0";
            this.v2t28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t21
            // 
            this.v2t21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t21.AutoSize = true;
            this.v2t21.Location = new System.Drawing.Point(555, 180);
            this.v2t21.Name = "v2t21";
            this.v2t21.Size = new System.Drawing.Size(13, 13);
            this.v2t21.TabIndex = 37;
            this.v2t21.Text = "0";
            this.v2t21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t10
            // 
            this.v2t10.AutoSize = true;
            this.v2t10.Location = new System.Drawing.Point(481, 19);
            this.v2t10.Name = "v2t10";
            this.v2t10.Size = new System.Drawing.Size(13, 13);
            this.v2t10.TabIndex = 25;
            this.v2t10.Text = "0";
            this.v2t10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t4
            // 
            this.v2t4.AutoSize = true;
            this.v2t4.Location = new System.Drawing.Point(254, 19);
            this.v2t4.Name = "v2t4";
            this.v2t4.Size = new System.Drawing.Size(13, 13);
            this.v2t4.TabIndex = 25;
            this.v2t4.Text = "0";
            this.v2t4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t29
            // 
            this.v2t29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t29.AutoSize = true;
            this.v2t29.Location = new System.Drawing.Point(254, 180);
            this.v2t29.Name = "v2t29";
            this.v2t29.Size = new System.Drawing.Size(13, 13);
            this.v2t29.TabIndex = 34;
            this.v2t29.Text = "0";
            this.v2t29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t3
            // 
            this.v2t3.AutoSize = true;
            this.v2t3.Location = new System.Drawing.Point(208, 19);
            this.v2t3.Name = "v2t3";
            this.v2t3.Size = new System.Drawing.Size(13, 13);
            this.v2t3.TabIndex = 25;
            this.v2t3.Text = "0";
            this.v2t3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t22
            // 
            this.v2t22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t22.AutoSize = true;
            this.v2t22.Location = new System.Drawing.Point(518, 180);
            this.v2t22.Name = "v2t22";
            this.v2t22.Size = new System.Drawing.Size(13, 13);
            this.v2t22.TabIndex = 35;
            this.v2t22.Text = "0";
            this.v2t22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t11
            // 
            this.v2t11.AutoSize = true;
            this.v2t11.Location = new System.Drawing.Point(518, 19);
            this.v2t11.Name = "v2t11";
            this.v2t11.Size = new System.Drawing.Size(13, 13);
            this.v2t11.TabIndex = 25;
            this.v2t11.Text = "0";
            this.v2t11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t32
            // 
            this.v2t32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t32.AutoSize = true;
            this.v2t32.Location = new System.Drawing.Point(97, 180);
            this.v2t32.Name = "v2t32";
            this.v2t32.Size = new System.Drawing.Size(13, 13);
            this.v2t32.TabIndex = 27;
            this.v2t32.Text = "0";
            this.v2t32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t24
            // 
            this.v2t24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t24.AutoSize = true;
            this.v2t24.Location = new System.Drawing.Point(443, 180);
            this.v2t24.Name = "v2t24";
            this.v2t24.Size = new System.Drawing.Size(13, 13);
            this.v2t24.TabIndex = 26;
            this.v2t24.Text = "0";
            this.v2t24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t30
            // 
            this.v2t30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t30.AutoSize = true;
            this.v2t30.Location = new System.Drawing.Point(208, 180);
            this.v2t30.Name = "v2t30";
            this.v2t30.Size = new System.Drawing.Size(13, 13);
            this.v2t30.TabIndex = 31;
            this.v2t30.Text = "0";
            this.v2t30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t23
            // 
            this.v2t23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t23.AutoSize = true;
            this.v2t23.Location = new System.Drawing.Point(481, 180);
            this.v2t23.Name = "v2t23";
            this.v2t23.Size = new System.Drawing.Size(13, 13);
            this.v2t23.TabIndex = 30;
            this.v2t23.Text = "0";
            this.v2t23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v2t31
            // 
            this.v2t31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v2t31.AutoSize = true;
            this.v2t31.Location = new System.Drawing.Point(155, 180);
            this.v2t31.Name = "v2t31";
            this.v2t31.Size = new System.Drawing.Size(13, 13);
            this.v2t31.TabIndex = 42;
            this.v2t31.Text = "0";
            this.v2t31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tab_Distance2Plane
            // 
            this.tab_Distance2Plane.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tab_Distance2Plane.Controls.Add(this.label8);
            this.tab_Distance2Plane.Controls.Add(this.label11);
            this.tab_Distance2Plane.Controls.Add(this.label77);
            this.tab_Distance2Plane.Controls.Add(this.label74);
            this.tab_Distance2Plane.Controls.Add(this.v4t17);
            this.tab_Distance2Plane.Controls.Add(this.v4t18);
            this.tab_Distance2Plane.Controls.Add(this.v4t25);
            this.tab_Distance2Plane.Controls.Add(this.v4t26);
            this.tab_Distance2Plane.Controls.Add(this.v4t19);
            this.tab_Distance2Plane.Controls.Add(this.v4t27);
            this.tab_Distance2Plane.Controls.Add(this.v4t20);
            this.tab_Distance2Plane.Controls.Add(this.v4t28);
            this.tab_Distance2Plane.Controls.Add(this.v4t21);
            this.tab_Distance2Plane.Controls.Add(this.v4t29);
            this.tab_Distance2Plane.Controls.Add(this.v4t22);
            this.tab_Distance2Plane.Controls.Add(this.v4t30);
            this.tab_Distance2Plane.Controls.Add(this.v4t32);
            this.tab_Distance2Plane.Controls.Add(this.v4t23);
            this.tab_Distance2Plane.Controls.Add(this.v4t31);
            this.tab_Distance2Plane.Controls.Add(this.v4t24);
            this.tab_Distance2Plane.Controls.Add(this.v4t16);
            this.tab_Distance2Plane.Controls.Add(this.v4t15);
            this.tab_Distance2Plane.Controls.Add(this.v4t8);
            this.tab_Distance2Plane.Controls.Add(this.v4t1);
            this.tab_Distance2Plane.Controls.Add(this.v4t7);
            this.tab_Distance2Plane.Controls.Add(this.v4t9);
            this.tab_Distance2Plane.Controls.Add(this.v4t14);
            this.tab_Distance2Plane.Controls.Add(this.v4t2);
            this.tab_Distance2Plane.Controls.Add(this.v4t6);
            this.tab_Distance2Plane.Controls.Add(this.v4t10);
            this.tab_Distance2Plane.Controls.Add(this.v4t13);
            this.tab_Distance2Plane.Controls.Add(this.v4t3);
            this.tab_Distance2Plane.Controls.Add(this.v4t5);
            this.tab_Distance2Plane.Controls.Add(this.v4t12);
            this.tab_Distance2Plane.Controls.Add(this.v4t4);
            this.tab_Distance2Plane.Controls.Add(this.v4t11);
            this.tab_Distance2Plane.Controls.Add(this.v3t17);
            this.tab_Distance2Plane.Controls.Add(this.v3t18);
            this.tab_Distance2Plane.Controls.Add(this.v3t25);
            this.tab_Distance2Plane.Controls.Add(this.v3t26);
            this.tab_Distance2Plane.Controls.Add(this.v3t19);
            this.tab_Distance2Plane.Controls.Add(this.v3t27);
            this.tab_Distance2Plane.Controls.Add(this.v3t20);
            this.tab_Distance2Plane.Controls.Add(this.v3t28);
            this.tab_Distance2Plane.Controls.Add(this.v3t21);
            this.tab_Distance2Plane.Controls.Add(this.v3t29);
            this.tab_Distance2Plane.Controls.Add(this.v3t22);
            this.tab_Distance2Plane.Controls.Add(this.v3t30);
            this.tab_Distance2Plane.Controls.Add(this.v3t32);
            this.tab_Distance2Plane.Controls.Add(this.v3t23);
            this.tab_Distance2Plane.Controls.Add(this.v3t31);
            this.tab_Distance2Plane.Controls.Add(this.v3t24);
            this.tab_Distance2Plane.Controls.Add(this.v3t16);
            this.tab_Distance2Plane.Controls.Add(this.v3t15);
            this.tab_Distance2Plane.Controls.Add(this.v3t8);
            this.tab_Distance2Plane.Controls.Add(this.v3t1);
            this.tab_Distance2Plane.Controls.Add(this.v3t7);
            this.tab_Distance2Plane.Controls.Add(this.v3t9);
            this.tab_Distance2Plane.Controls.Add(this.v3t14);
            this.tab_Distance2Plane.Controls.Add(this.v3t2);
            this.tab_Distance2Plane.Controls.Add(this.v3t6);
            this.tab_Distance2Plane.Controls.Add(this.v3t10);
            this.tab_Distance2Plane.Controls.Add(this.v3t13);
            this.tab_Distance2Plane.Controls.Add(this.v3t3);
            this.tab_Distance2Plane.Controls.Add(this.v3t5);
            this.tab_Distance2Plane.Controls.Add(this.v3t12);
            this.tab_Distance2Plane.Controls.Add(this.v3t4);
            this.tab_Distance2Plane.Controls.Add(this.v3t11);
            this.tab_Distance2Plane.Location = new System.Drawing.Point(4, 22);
            this.tab_Distance2Plane.Name = "tab_Distance2Plane";
            this.tab_Distance2Plane.Size = new System.Drawing.Size(788, 211);
            this.tab_Distance2Plane.TabIndex = 2;
            this.tab_Distance2Plane.Text = "Distance to Plane";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 160;
            this.label8.Text = "Sagittal Plane";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 159;
            this.label11.Text = "Occlusal Plane";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(1, 26);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(72, 13);
            this.label77.TabIndex = 158;
            this.label77.Text = "Sagittal Plane";
            this.label77.Click += new System.EventHandler(this.label77_Click);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(0, 11);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(78, 13);
            this.label74.TabIndex = 156;
            this.label74.Text = "Occlusal Plane";
            // 
            // v4t17
            // 
            this.v4t17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t17.AutoSize = true;
            this.v4t17.Location = new System.Drawing.Point(753, 194);
            this.v4t17.Name = "v4t17";
            this.v4t17.Size = new System.Drawing.Size(13, 13);
            this.v4t17.TabIndex = 144;
            this.v4t17.Text = "0";
            this.v4t17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t18
            // 
            this.v4t18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t18.AutoSize = true;
            this.v4t18.Location = new System.Drawing.Point(692, 194);
            this.v4t18.Name = "v4t18";
            this.v4t18.Size = new System.Drawing.Size(13, 13);
            this.v4t18.TabIndex = 149;
            this.v4t18.Text = "0";
            this.v4t18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t25
            // 
            this.v4t25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t25.AutoSize = true;
            this.v4t25.Location = new System.Drawing.Point(405, 194);
            this.v4t25.Name = "v4t25";
            this.v4t25.Size = new System.Drawing.Size(13, 13);
            this.v4t25.TabIndex = 150;
            this.v4t25.Text = "0";
            this.v4t25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t26
            // 
            this.v4t26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t26.AutoSize = true;
            this.v4t26.Location = new System.Drawing.Point(367, 194);
            this.v4t26.Name = "v4t26";
            this.v4t26.Size = new System.Drawing.Size(13, 13);
            this.v4t26.TabIndex = 148;
            this.v4t26.Text = "0";
            this.v4t26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t19
            // 
            this.v4t19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t19.AutoSize = true;
            this.v4t19.Location = new System.Drawing.Point(638, 194);
            this.v4t19.Name = "v4t19";
            this.v4t19.Size = new System.Drawing.Size(13, 13);
            this.v4t19.TabIndex = 146;
            this.v4t19.Text = "0";
            this.v4t19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t27
            // 
            this.v4t27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t27.AutoSize = true;
            this.v4t27.Location = new System.Drawing.Point(332, 194);
            this.v4t27.Name = "v4t27";
            this.v4t27.Size = new System.Drawing.Size(13, 13);
            this.v4t27.TabIndex = 147;
            this.v4t27.Text = "0";
            this.v4t27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t20
            // 
            this.v4t20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t20.AutoSize = true;
            this.v4t20.Location = new System.Drawing.Point(594, 194);
            this.v4t20.Name = "v4t20";
            this.v4t20.Size = new System.Drawing.Size(13, 13);
            this.v4t20.TabIndex = 154;
            this.v4t20.Text = "0";
            this.v4t20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t28
            // 
            this.v4t28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t28.AutoSize = true;
            this.v4t28.Location = new System.Drawing.Point(294, 194);
            this.v4t28.Name = "v4t28";
            this.v4t28.Size = new System.Drawing.Size(13, 13);
            this.v4t28.TabIndex = 155;
            this.v4t28.Text = "0";
            this.v4t28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t21
            // 
            this.v4t21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t21.AutoSize = true;
            this.v4t21.Location = new System.Drawing.Point(554, 194);
            this.v4t21.Name = "v4t21";
            this.v4t21.Size = new System.Drawing.Size(13, 13);
            this.v4t21.TabIndex = 153;
            this.v4t21.Text = "0";
            this.v4t21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t29
            // 
            this.v4t29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t29.AutoSize = true;
            this.v4t29.Location = new System.Drawing.Point(253, 194);
            this.v4t29.Name = "v4t29";
            this.v4t29.Size = new System.Drawing.Size(13, 13);
            this.v4t29.TabIndex = 151;
            this.v4t29.Text = "0";
            this.v4t29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t22
            // 
            this.v4t22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t22.AutoSize = true;
            this.v4t22.Location = new System.Drawing.Point(517, 194);
            this.v4t22.Name = "v4t22";
            this.v4t22.Size = new System.Drawing.Size(13, 13);
            this.v4t22.TabIndex = 152;
            this.v4t22.Text = "0";
            this.v4t22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t30
            // 
            this.v4t30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t30.AutoSize = true;
            this.v4t30.Location = new System.Drawing.Point(207, 194);
            this.v4t30.Name = "v4t30";
            this.v4t30.Size = new System.Drawing.Size(13, 13);
            this.v4t30.TabIndex = 143;
            this.v4t30.Text = "0";
            this.v4t30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t32
            // 
            this.v4t32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t32.AutoSize = true;
            this.v4t32.Location = new System.Drawing.Point(96, 194);
            this.v4t32.Name = "v4t32";
            this.v4t32.Size = new System.Drawing.Size(13, 13);
            this.v4t32.TabIndex = 141;
            this.v4t32.Text = "0";
            this.v4t32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t23
            // 
            this.v4t23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t23.AutoSize = true;
            this.v4t23.Location = new System.Drawing.Point(480, 194);
            this.v4t23.Name = "v4t23";
            this.v4t23.Size = new System.Drawing.Size(13, 13);
            this.v4t23.TabIndex = 145;
            this.v4t23.Text = "0";
            this.v4t23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t31
            // 
            this.v4t31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t31.AutoSize = true;
            this.v4t31.Location = new System.Drawing.Point(154, 194);
            this.v4t31.Name = "v4t31";
            this.v4t31.Size = new System.Drawing.Size(13, 13);
            this.v4t31.TabIndex = 142;
            this.v4t31.Text = "0";
            this.v4t31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t24
            // 
            this.v4t24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v4t24.AutoSize = true;
            this.v4t24.Location = new System.Drawing.Point(442, 194);
            this.v4t24.Name = "v4t24";
            this.v4t24.Size = new System.Drawing.Size(13, 13);
            this.v4t24.TabIndex = 140;
            this.v4t24.Text = "0";
            this.v4t24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t16
            // 
            this.v4t16.AutoSize = true;
            this.v4t16.Location = new System.Drawing.Point(753, 26);
            this.v4t16.Name = "v4t16";
            this.v4t16.Size = new System.Drawing.Size(13, 13);
            this.v4t16.TabIndex = 126;
            this.v4t16.Text = "0";
            this.v4t16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t15
            // 
            this.v4t15.AutoSize = true;
            this.v4t15.Location = new System.Drawing.Point(692, 26);
            this.v4t15.Name = "v4t15";
            this.v4t15.Size = new System.Drawing.Size(13, 13);
            this.v4t15.TabIndex = 137;
            this.v4t15.Text = "0";
            this.v4t15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t8
            // 
            this.v4t8.AutoSize = true;
            this.v4t8.Location = new System.Drawing.Point(405, 26);
            this.v4t8.Name = "v4t8";
            this.v4t8.Size = new System.Drawing.Size(13, 13);
            this.v4t8.TabIndex = 136;
            this.v4t8.Text = "0";
            this.v4t8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t1
            // 
            this.v4t1.AutoSize = true;
            this.v4t1.Location = new System.Drawing.Point(96, 26);
            this.v4t1.Name = "v4t1";
            this.v4t1.Size = new System.Drawing.Size(13, 13);
            this.v4t1.TabIndex = 124;
            this.v4t1.Text = "0";
            this.v4t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t7
            // 
            this.v4t7.AutoSize = true;
            this.v4t7.Location = new System.Drawing.Point(367, 26);
            this.v4t7.Name = "v4t7";
            this.v4t7.Size = new System.Drawing.Size(13, 13);
            this.v4t7.TabIndex = 135;
            this.v4t7.Text = "0";
            this.v4t7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t9
            // 
            this.v4t9.AutoSize = true;
            this.v4t9.Location = new System.Drawing.Point(442, 26);
            this.v4t9.Name = "v4t9";
            this.v4t9.Size = new System.Drawing.Size(13, 13);
            this.v4t9.TabIndex = 125;
            this.v4t9.Text = "0";
            this.v4t9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t14
            // 
            this.v4t14.AutoSize = true;
            this.v4t14.Location = new System.Drawing.Point(638, 26);
            this.v4t14.Name = "v4t14";
            this.v4t14.Size = new System.Drawing.Size(13, 13);
            this.v4t14.TabIndex = 134;
            this.v4t14.Text = "0";
            this.v4t14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t2
            // 
            this.v4t2.AutoSize = true;
            this.v4t2.Location = new System.Drawing.Point(154, 26);
            this.v4t2.Name = "v4t2";
            this.v4t2.Size = new System.Drawing.Size(13, 13);
            this.v4t2.TabIndex = 133;
            this.v4t2.Text = "0";
            this.v4t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t6
            // 
            this.v4t6.AutoSize = true;
            this.v4t6.Location = new System.Drawing.Point(332, 26);
            this.v4t6.Name = "v4t6";
            this.v4t6.Size = new System.Drawing.Size(13, 13);
            this.v4t6.TabIndex = 132;
            this.v4t6.Text = "0";
            this.v4t6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t10
            // 
            this.v4t10.AutoSize = true;
            this.v4t10.Location = new System.Drawing.Point(480, 26);
            this.v4t10.Name = "v4t10";
            this.v4t10.Size = new System.Drawing.Size(13, 13);
            this.v4t10.TabIndex = 131;
            this.v4t10.Text = "0";
            this.v4t10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t13
            // 
            this.v4t13.AutoSize = true;
            this.v4t13.Location = new System.Drawing.Point(594, 26);
            this.v4t13.Name = "v4t13";
            this.v4t13.Size = new System.Drawing.Size(13, 13);
            this.v4t13.TabIndex = 130;
            this.v4t13.Text = "0";
            this.v4t13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t3
            // 
            this.v4t3.AutoSize = true;
            this.v4t3.Location = new System.Drawing.Point(207, 26);
            this.v4t3.Name = "v4t3";
            this.v4t3.Size = new System.Drawing.Size(13, 13);
            this.v4t3.TabIndex = 129;
            this.v4t3.Text = "0";
            this.v4t3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t5
            // 
            this.v4t5.AutoSize = true;
            this.v4t5.Location = new System.Drawing.Point(294, 26);
            this.v4t5.Name = "v4t5";
            this.v4t5.Size = new System.Drawing.Size(13, 13);
            this.v4t5.TabIndex = 128;
            this.v4t5.Text = "0";
            this.v4t5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t12
            // 
            this.v4t12.AutoSize = true;
            this.v4t12.Location = new System.Drawing.Point(554, 26);
            this.v4t12.Name = "v4t12";
            this.v4t12.Size = new System.Drawing.Size(13, 13);
            this.v4t12.TabIndex = 127;
            this.v4t12.Text = "0";
            this.v4t12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t4
            // 
            this.v4t4.AutoSize = true;
            this.v4t4.Location = new System.Drawing.Point(253, 26);
            this.v4t4.Name = "v4t4";
            this.v4t4.Size = new System.Drawing.Size(13, 13);
            this.v4t4.TabIndex = 138;
            this.v4t4.Text = "0";
            this.v4t4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v4t11
            // 
            this.v4t11.AutoSize = true;
            this.v4t11.Location = new System.Drawing.Point(517, 26);
            this.v4t11.Name = "v4t11";
            this.v4t11.Size = new System.Drawing.Size(13, 13);
            this.v4t11.TabIndex = 139;
            this.v4t11.Text = "0";
            this.v4t11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t17
            // 
            this.v3t17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t17.AutoSize = true;
            this.v3t17.Location = new System.Drawing.Point(753, 176);
            this.v3t17.Name = "v3t17";
            this.v3t17.Size = new System.Drawing.Size(13, 13);
            this.v3t17.TabIndex = 112;
            this.v3t17.Text = "0";
            this.v3t17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t18
            // 
            this.v3t18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t18.AutoSize = true;
            this.v3t18.Location = new System.Drawing.Point(692, 176);
            this.v3t18.Name = "v3t18";
            this.v3t18.Size = new System.Drawing.Size(13, 13);
            this.v3t18.TabIndex = 117;
            this.v3t18.Text = "0";
            this.v3t18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t25
            // 
            this.v3t25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t25.AutoSize = true;
            this.v3t25.Location = new System.Drawing.Point(405, 176);
            this.v3t25.Name = "v3t25";
            this.v3t25.Size = new System.Drawing.Size(13, 13);
            this.v3t25.TabIndex = 118;
            this.v3t25.Text = "0";
            this.v3t25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t26
            // 
            this.v3t26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t26.AutoSize = true;
            this.v3t26.Location = new System.Drawing.Point(367, 176);
            this.v3t26.Name = "v3t26";
            this.v3t26.Size = new System.Drawing.Size(13, 13);
            this.v3t26.TabIndex = 116;
            this.v3t26.Text = "0";
            this.v3t26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t19
            // 
            this.v3t19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t19.AutoSize = true;
            this.v3t19.Location = new System.Drawing.Point(638, 176);
            this.v3t19.Name = "v3t19";
            this.v3t19.Size = new System.Drawing.Size(13, 13);
            this.v3t19.TabIndex = 114;
            this.v3t19.Text = "0";
            this.v3t19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t27
            // 
            this.v3t27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t27.AutoSize = true;
            this.v3t27.Location = new System.Drawing.Point(332, 176);
            this.v3t27.Name = "v3t27";
            this.v3t27.Size = new System.Drawing.Size(13, 13);
            this.v3t27.TabIndex = 115;
            this.v3t27.Text = "0";
            this.v3t27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t20
            // 
            this.v3t20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t20.AutoSize = true;
            this.v3t20.Location = new System.Drawing.Point(594, 176);
            this.v3t20.Name = "v3t20";
            this.v3t20.Size = new System.Drawing.Size(13, 13);
            this.v3t20.TabIndex = 122;
            this.v3t20.Text = "0";
            this.v3t20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t28
            // 
            this.v3t28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t28.AutoSize = true;
            this.v3t28.Location = new System.Drawing.Point(294, 176);
            this.v3t28.Name = "v3t28";
            this.v3t28.Size = new System.Drawing.Size(13, 13);
            this.v3t28.TabIndex = 123;
            this.v3t28.Text = "0";
            this.v3t28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t21
            // 
            this.v3t21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t21.AutoSize = true;
            this.v3t21.Location = new System.Drawing.Point(554, 176);
            this.v3t21.Name = "v3t21";
            this.v3t21.Size = new System.Drawing.Size(13, 13);
            this.v3t21.TabIndex = 121;
            this.v3t21.Text = "0";
            this.v3t21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t29
            // 
            this.v3t29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t29.AutoSize = true;
            this.v3t29.Location = new System.Drawing.Point(253, 176);
            this.v3t29.Name = "v3t29";
            this.v3t29.Size = new System.Drawing.Size(13, 13);
            this.v3t29.TabIndex = 119;
            this.v3t29.Text = "0";
            this.v3t29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t22
            // 
            this.v3t22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t22.AutoSize = true;
            this.v3t22.Location = new System.Drawing.Point(517, 176);
            this.v3t22.Name = "v3t22";
            this.v3t22.Size = new System.Drawing.Size(13, 13);
            this.v3t22.TabIndex = 120;
            this.v3t22.Text = "0";
            this.v3t22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t30
            // 
            this.v3t30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t30.AutoSize = true;
            this.v3t30.Location = new System.Drawing.Point(207, 176);
            this.v3t30.Name = "v3t30";
            this.v3t30.Size = new System.Drawing.Size(13, 13);
            this.v3t30.TabIndex = 111;
            this.v3t30.Text = "0";
            this.v3t30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t32
            // 
            this.v3t32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t32.AutoSize = true;
            this.v3t32.Location = new System.Drawing.Point(96, 176);
            this.v3t32.Name = "v3t32";
            this.v3t32.Size = new System.Drawing.Size(13, 13);
            this.v3t32.TabIndex = 109;
            this.v3t32.Text = "0";
            this.v3t32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t23
            // 
            this.v3t23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t23.AutoSize = true;
            this.v3t23.Location = new System.Drawing.Point(480, 176);
            this.v3t23.Name = "v3t23";
            this.v3t23.Size = new System.Drawing.Size(13, 13);
            this.v3t23.TabIndex = 113;
            this.v3t23.Text = "0";
            this.v3t23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t31
            // 
            this.v3t31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t31.AutoSize = true;
            this.v3t31.Location = new System.Drawing.Point(154, 176);
            this.v3t31.Name = "v3t31";
            this.v3t31.Size = new System.Drawing.Size(13, 13);
            this.v3t31.TabIndex = 110;
            this.v3t31.Text = "0";
            this.v3t31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t24
            // 
            this.v3t24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.v3t24.AutoSize = true;
            this.v3t24.Location = new System.Drawing.Point(442, 176);
            this.v3t24.Name = "v3t24";
            this.v3t24.Size = new System.Drawing.Size(13, 13);
            this.v3t24.TabIndex = 108;
            this.v3t24.Text = "0";
            this.v3t24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t16
            // 
            this.v3t16.AutoSize = true;
            this.v3t16.Location = new System.Drawing.Point(753, 9);
            this.v3t16.Name = "v3t16";
            this.v3t16.Size = new System.Drawing.Size(13, 13);
            this.v3t16.TabIndex = 94;
            this.v3t16.Text = "0";
            this.v3t16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t15
            // 
            this.v3t15.AutoSize = true;
            this.v3t15.Location = new System.Drawing.Point(692, 9);
            this.v3t15.Name = "v3t15";
            this.v3t15.Size = new System.Drawing.Size(13, 13);
            this.v3t15.TabIndex = 105;
            this.v3t15.Text = "0";
            this.v3t15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t8
            // 
            this.v3t8.AutoSize = true;
            this.v3t8.Location = new System.Drawing.Point(405, 9);
            this.v3t8.Name = "v3t8";
            this.v3t8.Size = new System.Drawing.Size(13, 13);
            this.v3t8.TabIndex = 104;
            this.v3t8.Text = "0";
            this.v3t8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t1
            // 
            this.v3t1.AutoSize = true;
            this.v3t1.Location = new System.Drawing.Point(96, 9);
            this.v3t1.Name = "v3t1";
            this.v3t1.Size = new System.Drawing.Size(13, 13);
            this.v3t1.TabIndex = 92;
            this.v3t1.Text = "0";
            this.v3t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t7
            // 
            this.v3t7.AutoSize = true;
            this.v3t7.Location = new System.Drawing.Point(367, 9);
            this.v3t7.Name = "v3t7";
            this.v3t7.Size = new System.Drawing.Size(13, 13);
            this.v3t7.TabIndex = 103;
            this.v3t7.Text = "0";
            this.v3t7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t9
            // 
            this.v3t9.AutoSize = true;
            this.v3t9.Location = new System.Drawing.Point(442, 9);
            this.v3t9.Name = "v3t9";
            this.v3t9.Size = new System.Drawing.Size(13, 13);
            this.v3t9.TabIndex = 93;
            this.v3t9.Text = "0";
            this.v3t9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t14
            // 
            this.v3t14.AutoSize = true;
            this.v3t14.Location = new System.Drawing.Point(638, 9);
            this.v3t14.Name = "v3t14";
            this.v3t14.Size = new System.Drawing.Size(13, 13);
            this.v3t14.TabIndex = 102;
            this.v3t14.Text = "0";
            this.v3t14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t2
            // 
            this.v3t2.AutoSize = true;
            this.v3t2.Location = new System.Drawing.Point(154, 9);
            this.v3t2.Name = "v3t2";
            this.v3t2.Size = new System.Drawing.Size(13, 13);
            this.v3t2.TabIndex = 101;
            this.v3t2.Text = "0";
            this.v3t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t6
            // 
            this.v3t6.AutoSize = true;
            this.v3t6.Location = new System.Drawing.Point(332, 9);
            this.v3t6.Name = "v3t6";
            this.v3t6.Size = new System.Drawing.Size(13, 13);
            this.v3t6.TabIndex = 100;
            this.v3t6.Text = "0";
            this.v3t6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t10
            // 
            this.v3t10.AutoSize = true;
            this.v3t10.Location = new System.Drawing.Point(480, 9);
            this.v3t10.Name = "v3t10";
            this.v3t10.Size = new System.Drawing.Size(13, 13);
            this.v3t10.TabIndex = 99;
            this.v3t10.Text = "0";
            this.v3t10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t13
            // 
            this.v3t13.AutoSize = true;
            this.v3t13.Location = new System.Drawing.Point(594, 9);
            this.v3t13.Name = "v3t13";
            this.v3t13.Size = new System.Drawing.Size(13, 13);
            this.v3t13.TabIndex = 98;
            this.v3t13.Text = "0";
            this.v3t13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t3
            // 
            this.v3t3.AutoSize = true;
            this.v3t3.Location = new System.Drawing.Point(207, 9);
            this.v3t3.Name = "v3t3";
            this.v3t3.Size = new System.Drawing.Size(13, 13);
            this.v3t3.TabIndex = 97;
            this.v3t3.Text = "0";
            this.v3t3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t5
            // 
            this.v3t5.AutoSize = true;
            this.v3t5.Location = new System.Drawing.Point(294, 9);
            this.v3t5.Name = "v3t5";
            this.v3t5.Size = new System.Drawing.Size(13, 13);
            this.v3t5.TabIndex = 96;
            this.v3t5.Text = "0";
            this.v3t5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t12
            // 
            this.v3t12.AutoSize = true;
            this.v3t12.Location = new System.Drawing.Point(554, 9);
            this.v3t12.Name = "v3t12";
            this.v3t12.Size = new System.Drawing.Size(13, 13);
            this.v3t12.TabIndex = 95;
            this.v3t12.Text = "0";
            this.v3t12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t4
            // 
            this.v3t4.AutoSize = true;
            this.v3t4.Location = new System.Drawing.Point(253, 9);
            this.v3t4.Name = "v3t4";
            this.v3t4.Size = new System.Drawing.Size(13, 13);
            this.v3t4.TabIndex = 106;
            this.v3t4.Text = "0";
            this.v3t4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v3t11
            // 
            this.v3t11.AutoSize = true;
            this.v3t11.Location = new System.Drawing.Point(517, 9);
            this.v3t11.Name = "v3t11";
            this.v3t11.Size = new System.Drawing.Size(13, 13);
            this.v3t11.TabIndex = 107;
            this.v3t11.Text = "0";
            this.v3t11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tab_SuperInclin
            // 
            this.tab_SuperInclin.Controls.Add(this.v7t17);
            this.tab_SuperInclin.Controls.Add(this.v7t18);
            this.tab_SuperInclin.Controls.Add(this.v7t25);
            this.tab_SuperInclin.Controls.Add(this.v7t32);
            this.tab_SuperInclin.Controls.Add(this.v7t26);
            this.tab_SuperInclin.Controls.Add(this.v7t24);
            this.tab_SuperInclin.Controls.Add(this.v7t19);
            this.tab_SuperInclin.Controls.Add(this.v7t31);
            this.tab_SuperInclin.Controls.Add(this.v7t27);
            this.tab_SuperInclin.Controls.Add(this.v7t23);
            this.tab_SuperInclin.Controls.Add(this.v7t20);
            this.tab_SuperInclin.Controls.Add(this.v7t30);
            this.tab_SuperInclin.Controls.Add(this.v7t28);
            this.tab_SuperInclin.Controls.Add(this.v7t21);
            this.tab_SuperInclin.Controls.Add(this.v7t29);
            this.tab_SuperInclin.Controls.Add(this.v7t22);
            this.tab_SuperInclin.Controls.Add(this.v6t17);
            this.tab_SuperInclin.Controls.Add(this.v6t18);
            this.tab_SuperInclin.Controls.Add(this.v6t25);
            this.tab_SuperInclin.Controls.Add(this.v6t32);
            this.tab_SuperInclin.Controls.Add(this.v6t26);
            this.tab_SuperInclin.Controls.Add(this.v6t24);
            this.tab_SuperInclin.Controls.Add(this.v6t19);
            this.tab_SuperInclin.Controls.Add(this.v6t31);
            this.tab_SuperInclin.Controls.Add(this.v6t27);
            this.tab_SuperInclin.Controls.Add(this.v6t23);
            this.tab_SuperInclin.Controls.Add(this.v6t20);
            this.tab_SuperInclin.Controls.Add(this.v6t30);
            this.tab_SuperInclin.Controls.Add(this.v6t28);
            this.tab_SuperInclin.Controls.Add(this.v6t21);
            this.tab_SuperInclin.Controls.Add(this.v6t29);
            this.tab_SuperInclin.Controls.Add(this.v6t22);
            this.tab_SuperInclin.Controls.Add(this.v5t17);
            this.tab_SuperInclin.Controls.Add(this.v5t18);
            this.tab_SuperInclin.Controls.Add(this.v5t25);
            this.tab_SuperInclin.Controls.Add(this.v5t32);
            this.tab_SuperInclin.Controls.Add(this.v5t26);
            this.tab_SuperInclin.Controls.Add(this.v5t24);
            this.tab_SuperInclin.Controls.Add(this.v5t19);
            this.tab_SuperInclin.Controls.Add(this.v5t31);
            this.tab_SuperInclin.Controls.Add(this.v5t27);
            this.tab_SuperInclin.Controls.Add(this.v5t23);
            this.tab_SuperInclin.Controls.Add(this.v5t20);
            this.tab_SuperInclin.Controls.Add(this.v5t30);
            this.tab_SuperInclin.Controls.Add(this.v5t28);
            this.tab_SuperInclin.Controls.Add(this.v5t21);
            this.tab_SuperInclin.Controls.Add(this.v5t29);
            this.tab_SuperInclin.Controls.Add(this.v5t22);
            this.tab_SuperInclin.Controls.Add(this.label63);
            this.tab_SuperInclin.Controls.Add(this.label64);
            this.tab_SuperInclin.Controls.Add(this.label65);
            this.tab_SuperInclin.Controls.Add(this.v7t16);
            this.tab_SuperInclin.Controls.Add(this.v7t15);
            this.tab_SuperInclin.Controls.Add(this.v7t8);
            this.tab_SuperInclin.Controls.Add(this.v7t1);
            this.tab_SuperInclin.Controls.Add(this.v7t7);
            this.tab_SuperInclin.Controls.Add(this.v7t9);
            this.tab_SuperInclin.Controls.Add(this.v7t14);
            this.tab_SuperInclin.Controls.Add(this.v7t2);
            this.tab_SuperInclin.Controls.Add(this.v7t6);
            this.tab_SuperInclin.Controls.Add(this.v7t10);
            this.tab_SuperInclin.Controls.Add(this.v7t13);
            this.tab_SuperInclin.Controls.Add(this.v7t3);
            this.tab_SuperInclin.Controls.Add(this.v7t5);
            this.tab_SuperInclin.Controls.Add(this.v7t12);
            this.tab_SuperInclin.Controls.Add(this.v7t4);
            this.tab_SuperInclin.Controls.Add(this.v7t11);
            this.tab_SuperInclin.Controls.Add(this.v6t16);
            this.tab_SuperInclin.Controls.Add(this.v6t15);
            this.tab_SuperInclin.Controls.Add(this.v6t8);
            this.tab_SuperInclin.Controls.Add(this.v6t1);
            this.tab_SuperInclin.Controls.Add(this.v6t7);
            this.tab_SuperInclin.Controls.Add(this.v6t9);
            this.tab_SuperInclin.Controls.Add(this.v6t14);
            this.tab_SuperInclin.Controls.Add(this.v6t2);
            this.tab_SuperInclin.Controls.Add(this.v6t6);
            this.tab_SuperInclin.Controls.Add(this.v6t10);
            this.tab_SuperInclin.Controls.Add(this.v6t13);
            this.tab_SuperInclin.Controls.Add(this.v6t3);
            this.tab_SuperInclin.Controls.Add(this.v6t5);
            this.tab_SuperInclin.Controls.Add(this.v6t12);
            this.tab_SuperInclin.Controls.Add(this.v6t4);
            this.tab_SuperInclin.Controls.Add(this.v6t11);
            this.tab_SuperInclin.Controls.Add(this.v5t16);
            this.tab_SuperInclin.Controls.Add(this.v5t15);
            this.tab_SuperInclin.Controls.Add(this.v5t8);
            this.tab_SuperInclin.Controls.Add(this.v5t1);
            this.tab_SuperInclin.Controls.Add(this.v5t7);
            this.tab_SuperInclin.Controls.Add(this.v5t9);
            this.tab_SuperInclin.Controls.Add(this.v5t14);
            this.tab_SuperInclin.Controls.Add(this.v5t2);
            this.tab_SuperInclin.Controls.Add(this.v5t6);
            this.tab_SuperInclin.Controls.Add(this.v5t10);
            this.tab_SuperInclin.Controls.Add(this.v5t13);
            this.tab_SuperInclin.Controls.Add(this.v5t3);
            this.tab_SuperInclin.Controls.Add(this.v5t5);
            this.tab_SuperInclin.Controls.Add(this.v5t12);
            this.tab_SuperInclin.Controls.Add(this.v5t4);
            this.tab_SuperInclin.Controls.Add(this.v5t11);
            this.tab_SuperInclin.Controls.Add(this.label46);
            this.tab_SuperInclin.Controls.Add(this.label45);
            this.tab_SuperInclin.Controls.Add(this.label44);
            this.tab_SuperInclin.Location = new System.Drawing.Point(4, 22);
            this.tab_SuperInclin.Name = "tab_SuperInclin";
            this.tab_SuperInclin.Size = new System.Drawing.Size(788, 211);
            this.tab_SuperInclin.TabIndex = 3;
            this.tab_SuperInclin.Text = "Superimposed Inclination";
            this.tab_SuperInclin.UseVisualStyleBackColor = true;
            // 
            // v7t17
            // 
            this.v7t17.AutoSize = true;
            this.v7t17.Location = new System.Drawing.Point(745, 198);
            this.v7t17.Name = "v7t17";
            this.v7t17.Size = new System.Drawing.Size(13, 13);
            this.v7t17.TabIndex = 257;
            this.v7t17.Text = "0";
            this.v7t17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t18
            // 
            this.v7t18.AutoSize = true;
            this.v7t18.Location = new System.Drawing.Point(684, 198);
            this.v7t18.Name = "v7t18";
            this.v7t18.Size = new System.Drawing.Size(13, 13);
            this.v7t18.TabIndex = 268;
            this.v7t18.Text = "0";
            this.v7t18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t25
            // 
            this.v7t25.AutoSize = true;
            this.v7t25.Location = new System.Drawing.Point(397, 198);
            this.v7t25.Name = "v7t25";
            this.v7t25.Size = new System.Drawing.Size(13, 13);
            this.v7t25.TabIndex = 267;
            this.v7t25.Text = "0";
            this.v7t25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t32
            // 
            this.v7t32.AutoSize = true;
            this.v7t32.Location = new System.Drawing.Point(88, 198);
            this.v7t32.Name = "v7t32";
            this.v7t32.Size = new System.Drawing.Size(13, 13);
            this.v7t32.TabIndex = 255;
            this.v7t32.Text = "0";
            this.v7t32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t26
            // 
            this.v7t26.AutoSize = true;
            this.v7t26.Location = new System.Drawing.Point(359, 198);
            this.v7t26.Name = "v7t26";
            this.v7t26.Size = new System.Drawing.Size(13, 13);
            this.v7t26.TabIndex = 266;
            this.v7t26.Text = "0";
            this.v7t26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t24
            // 
            this.v7t24.AutoSize = true;
            this.v7t24.Location = new System.Drawing.Point(434, 198);
            this.v7t24.Name = "v7t24";
            this.v7t24.Size = new System.Drawing.Size(13, 13);
            this.v7t24.TabIndex = 256;
            this.v7t24.Text = "0";
            this.v7t24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t19
            // 
            this.v7t19.AutoSize = true;
            this.v7t19.Location = new System.Drawing.Point(630, 198);
            this.v7t19.Name = "v7t19";
            this.v7t19.Size = new System.Drawing.Size(13, 13);
            this.v7t19.TabIndex = 265;
            this.v7t19.Text = "0";
            this.v7t19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t31
            // 
            this.v7t31.AutoSize = true;
            this.v7t31.Location = new System.Drawing.Point(146, 198);
            this.v7t31.Name = "v7t31";
            this.v7t31.Size = new System.Drawing.Size(13, 13);
            this.v7t31.TabIndex = 264;
            this.v7t31.Text = "0";
            this.v7t31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t27
            // 
            this.v7t27.AutoSize = true;
            this.v7t27.Location = new System.Drawing.Point(324, 198);
            this.v7t27.Name = "v7t27";
            this.v7t27.Size = new System.Drawing.Size(13, 13);
            this.v7t27.TabIndex = 263;
            this.v7t27.Text = "0";
            this.v7t27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t23
            // 
            this.v7t23.AutoSize = true;
            this.v7t23.Location = new System.Drawing.Point(472, 198);
            this.v7t23.Name = "v7t23";
            this.v7t23.Size = new System.Drawing.Size(13, 13);
            this.v7t23.TabIndex = 262;
            this.v7t23.Text = "0";
            this.v7t23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t20
            // 
            this.v7t20.AutoSize = true;
            this.v7t20.Location = new System.Drawing.Point(586, 198);
            this.v7t20.Name = "v7t20";
            this.v7t20.Size = new System.Drawing.Size(13, 13);
            this.v7t20.TabIndex = 261;
            this.v7t20.Text = "0";
            this.v7t20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t30
            // 
            this.v7t30.AutoSize = true;
            this.v7t30.Location = new System.Drawing.Point(199, 198);
            this.v7t30.Name = "v7t30";
            this.v7t30.Size = new System.Drawing.Size(13, 13);
            this.v7t30.TabIndex = 260;
            this.v7t30.Text = "0";
            this.v7t30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t28
            // 
            this.v7t28.AutoSize = true;
            this.v7t28.Location = new System.Drawing.Point(286, 198);
            this.v7t28.Name = "v7t28";
            this.v7t28.Size = new System.Drawing.Size(13, 13);
            this.v7t28.TabIndex = 259;
            this.v7t28.Text = "0";
            this.v7t28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t21
            // 
            this.v7t21.AutoSize = true;
            this.v7t21.Location = new System.Drawing.Point(546, 198);
            this.v7t21.Name = "v7t21";
            this.v7t21.Size = new System.Drawing.Size(13, 13);
            this.v7t21.TabIndex = 258;
            this.v7t21.Text = "0";
            this.v7t21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t29
            // 
            this.v7t29.AutoSize = true;
            this.v7t29.Location = new System.Drawing.Point(245, 198);
            this.v7t29.Name = "v7t29";
            this.v7t29.Size = new System.Drawing.Size(13, 13);
            this.v7t29.TabIndex = 269;
            this.v7t29.Text = "0";
            this.v7t29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t22
            // 
            this.v7t22.AutoSize = true;
            this.v7t22.Location = new System.Drawing.Point(509, 198);
            this.v7t22.Name = "v7t22";
            this.v7t22.Size = new System.Drawing.Size(13, 13);
            this.v7t22.TabIndex = 270;
            this.v7t22.Text = "0";
            this.v7t22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t17
            // 
            this.v6t17.AutoSize = true;
            this.v6t17.Location = new System.Drawing.Point(745, 184);
            this.v6t17.Name = "v6t17";
            this.v6t17.Size = new System.Drawing.Size(13, 13);
            this.v6t17.TabIndex = 241;
            this.v6t17.Text = "0";
            this.v6t17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t18
            // 
            this.v6t18.AutoSize = true;
            this.v6t18.Location = new System.Drawing.Point(684, 184);
            this.v6t18.Name = "v6t18";
            this.v6t18.Size = new System.Drawing.Size(13, 13);
            this.v6t18.TabIndex = 252;
            this.v6t18.Text = "0";
            this.v6t18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t25
            // 
            this.v6t25.AutoSize = true;
            this.v6t25.Location = new System.Drawing.Point(397, 184);
            this.v6t25.Name = "v6t25";
            this.v6t25.Size = new System.Drawing.Size(13, 13);
            this.v6t25.TabIndex = 251;
            this.v6t25.Text = "0";
            this.v6t25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t32
            // 
            this.v6t32.AutoSize = true;
            this.v6t32.Location = new System.Drawing.Point(88, 184);
            this.v6t32.Name = "v6t32";
            this.v6t32.Size = new System.Drawing.Size(13, 13);
            this.v6t32.TabIndex = 239;
            this.v6t32.Text = "0";
            this.v6t32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t26
            // 
            this.v6t26.AutoSize = true;
            this.v6t26.Location = new System.Drawing.Point(359, 184);
            this.v6t26.Name = "v6t26";
            this.v6t26.Size = new System.Drawing.Size(13, 13);
            this.v6t26.TabIndex = 250;
            this.v6t26.Text = "0";
            this.v6t26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t24
            // 
            this.v6t24.AutoSize = true;
            this.v6t24.Location = new System.Drawing.Point(434, 184);
            this.v6t24.Name = "v6t24";
            this.v6t24.Size = new System.Drawing.Size(13, 13);
            this.v6t24.TabIndex = 240;
            this.v6t24.Text = "0";
            this.v6t24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t19
            // 
            this.v6t19.AutoSize = true;
            this.v6t19.Location = new System.Drawing.Point(630, 184);
            this.v6t19.Name = "v6t19";
            this.v6t19.Size = new System.Drawing.Size(13, 13);
            this.v6t19.TabIndex = 249;
            this.v6t19.Text = "0";
            this.v6t19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t31
            // 
            this.v6t31.AutoSize = true;
            this.v6t31.Location = new System.Drawing.Point(146, 184);
            this.v6t31.Name = "v6t31";
            this.v6t31.Size = new System.Drawing.Size(13, 13);
            this.v6t31.TabIndex = 248;
            this.v6t31.Text = "0";
            this.v6t31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t27
            // 
            this.v6t27.AutoSize = true;
            this.v6t27.Location = new System.Drawing.Point(324, 184);
            this.v6t27.Name = "v6t27";
            this.v6t27.Size = new System.Drawing.Size(13, 13);
            this.v6t27.TabIndex = 247;
            this.v6t27.Text = "0";
            this.v6t27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t23
            // 
            this.v6t23.AutoSize = true;
            this.v6t23.Location = new System.Drawing.Point(472, 184);
            this.v6t23.Name = "v6t23";
            this.v6t23.Size = new System.Drawing.Size(13, 13);
            this.v6t23.TabIndex = 246;
            this.v6t23.Text = "0";
            this.v6t23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t20
            // 
            this.v6t20.AutoSize = true;
            this.v6t20.Location = new System.Drawing.Point(586, 184);
            this.v6t20.Name = "v6t20";
            this.v6t20.Size = new System.Drawing.Size(13, 13);
            this.v6t20.TabIndex = 245;
            this.v6t20.Text = "0";
            this.v6t20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t30
            // 
            this.v6t30.AutoSize = true;
            this.v6t30.Location = new System.Drawing.Point(199, 184);
            this.v6t30.Name = "v6t30";
            this.v6t30.Size = new System.Drawing.Size(13, 13);
            this.v6t30.TabIndex = 244;
            this.v6t30.Text = "0";
            this.v6t30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t28
            // 
            this.v6t28.AutoSize = true;
            this.v6t28.Location = new System.Drawing.Point(286, 184);
            this.v6t28.Name = "v6t28";
            this.v6t28.Size = new System.Drawing.Size(13, 13);
            this.v6t28.TabIndex = 243;
            this.v6t28.Text = "0";
            this.v6t28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t21
            // 
            this.v6t21.AutoSize = true;
            this.v6t21.Location = new System.Drawing.Point(546, 184);
            this.v6t21.Name = "v6t21";
            this.v6t21.Size = new System.Drawing.Size(13, 13);
            this.v6t21.TabIndex = 242;
            this.v6t21.Text = "0";
            this.v6t21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t29
            // 
            this.v6t29.AutoSize = true;
            this.v6t29.Location = new System.Drawing.Point(245, 184);
            this.v6t29.Name = "v6t29";
            this.v6t29.Size = new System.Drawing.Size(13, 13);
            this.v6t29.TabIndex = 253;
            this.v6t29.Text = "0";
            this.v6t29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t22
            // 
            this.v6t22.AutoSize = true;
            this.v6t22.Location = new System.Drawing.Point(509, 184);
            this.v6t22.Name = "v6t22";
            this.v6t22.Size = new System.Drawing.Size(13, 13);
            this.v6t22.TabIndex = 254;
            this.v6t22.Text = "0";
            this.v6t22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t17
            // 
            this.v5t17.AutoSize = true;
            this.v5t17.Location = new System.Drawing.Point(745, 171);
            this.v5t17.Name = "v5t17";
            this.v5t17.Size = new System.Drawing.Size(13, 13);
            this.v5t17.TabIndex = 225;
            this.v5t17.Text = "0";
            this.v5t17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t18
            // 
            this.v5t18.AutoSize = true;
            this.v5t18.Location = new System.Drawing.Point(684, 171);
            this.v5t18.Name = "v5t18";
            this.v5t18.Size = new System.Drawing.Size(13, 13);
            this.v5t18.TabIndex = 236;
            this.v5t18.Text = "0";
            this.v5t18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t25
            // 
            this.v5t25.AutoSize = true;
            this.v5t25.Location = new System.Drawing.Point(397, 171);
            this.v5t25.Name = "v5t25";
            this.v5t25.Size = new System.Drawing.Size(13, 13);
            this.v5t25.TabIndex = 235;
            this.v5t25.Text = "0";
            this.v5t25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t32
            // 
            this.v5t32.AutoSize = true;
            this.v5t32.Location = new System.Drawing.Point(88, 171);
            this.v5t32.Name = "v5t32";
            this.v5t32.Size = new System.Drawing.Size(13, 13);
            this.v5t32.TabIndex = 223;
            this.v5t32.Text = "0";
            this.v5t32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t26
            // 
            this.v5t26.AutoSize = true;
            this.v5t26.Location = new System.Drawing.Point(359, 171);
            this.v5t26.Name = "v5t26";
            this.v5t26.Size = new System.Drawing.Size(13, 13);
            this.v5t26.TabIndex = 234;
            this.v5t26.Text = "0";
            this.v5t26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t24
            // 
            this.v5t24.AutoSize = true;
            this.v5t24.Location = new System.Drawing.Point(434, 171);
            this.v5t24.Name = "v5t24";
            this.v5t24.Size = new System.Drawing.Size(13, 13);
            this.v5t24.TabIndex = 224;
            this.v5t24.Text = "0";
            this.v5t24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t19
            // 
            this.v5t19.AutoSize = true;
            this.v5t19.Location = new System.Drawing.Point(630, 171);
            this.v5t19.Name = "v5t19";
            this.v5t19.Size = new System.Drawing.Size(13, 13);
            this.v5t19.TabIndex = 233;
            this.v5t19.Text = "0";
            this.v5t19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t31
            // 
            this.v5t31.AutoSize = true;
            this.v5t31.Location = new System.Drawing.Point(146, 171);
            this.v5t31.Name = "v5t31";
            this.v5t31.Size = new System.Drawing.Size(13, 13);
            this.v5t31.TabIndex = 232;
            this.v5t31.Text = "0";
            this.v5t31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t27
            // 
            this.v5t27.AutoSize = true;
            this.v5t27.Location = new System.Drawing.Point(324, 171);
            this.v5t27.Name = "v5t27";
            this.v5t27.Size = new System.Drawing.Size(13, 13);
            this.v5t27.TabIndex = 231;
            this.v5t27.Text = "0";
            this.v5t27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t23
            // 
            this.v5t23.AutoSize = true;
            this.v5t23.Location = new System.Drawing.Point(472, 171);
            this.v5t23.Name = "v5t23";
            this.v5t23.Size = new System.Drawing.Size(13, 13);
            this.v5t23.TabIndex = 230;
            this.v5t23.Text = "0";
            this.v5t23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t20
            // 
            this.v5t20.AutoSize = true;
            this.v5t20.Location = new System.Drawing.Point(586, 171);
            this.v5t20.Name = "v5t20";
            this.v5t20.Size = new System.Drawing.Size(13, 13);
            this.v5t20.TabIndex = 229;
            this.v5t20.Text = "0";
            this.v5t20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t30
            // 
            this.v5t30.AutoSize = true;
            this.v5t30.Location = new System.Drawing.Point(199, 171);
            this.v5t30.Name = "v5t30";
            this.v5t30.Size = new System.Drawing.Size(13, 13);
            this.v5t30.TabIndex = 228;
            this.v5t30.Text = "0";
            this.v5t30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t28
            // 
            this.v5t28.AutoSize = true;
            this.v5t28.Location = new System.Drawing.Point(286, 171);
            this.v5t28.Name = "v5t28";
            this.v5t28.Size = new System.Drawing.Size(13, 13);
            this.v5t28.TabIndex = 227;
            this.v5t28.Text = "0";
            this.v5t28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t21
            // 
            this.v5t21.AutoSize = true;
            this.v5t21.Location = new System.Drawing.Point(546, 171);
            this.v5t21.Name = "v5t21";
            this.v5t21.Size = new System.Drawing.Size(13, 13);
            this.v5t21.TabIndex = 226;
            this.v5t21.Text = "0";
            this.v5t21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t29
            // 
            this.v5t29.AutoSize = true;
            this.v5t29.Location = new System.Drawing.Point(245, 171);
            this.v5t29.Name = "v5t29";
            this.v5t29.Size = new System.Drawing.Size(13, 13);
            this.v5t29.TabIndex = 237;
            this.v5t29.Text = "0";
            this.v5t29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t22
            // 
            this.v5t22.AutoSize = true;
            this.v5t22.Location = new System.Drawing.Point(509, 171);
            this.v5t22.Name = "v5t22";
            this.v5t22.Size = new System.Drawing.Size(13, 13);
            this.v5t22.TabIndex = 238;
            this.v5t22.Text = "0";
            this.v5t22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(2, 198);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(70, 13);
            this.label63.TabIndex = 222;
            this.label63.Text = "Cast1 - Cast2";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(22, 184);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(34, 13);
            this.label64.TabIndex = 221;
            this.label64.Text = "Cast2";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(22, 171);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(34, 13);
            this.label65.TabIndex = 220;
            this.label65.Text = "Cast1";
            // 
            // v7t16
            // 
            this.v7t16.AutoSize = true;
            this.v7t16.Location = new System.Drawing.Point(745, 27);
            this.v7t16.Name = "v7t16";
            this.v7t16.Size = new System.Drawing.Size(13, 13);
            this.v7t16.TabIndex = 206;
            this.v7t16.Text = "0";
            this.v7t16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t15
            // 
            this.v7t15.AutoSize = true;
            this.v7t15.Location = new System.Drawing.Point(684, 27);
            this.v7t15.Name = "v7t15";
            this.v7t15.Size = new System.Drawing.Size(13, 13);
            this.v7t15.TabIndex = 217;
            this.v7t15.Text = "0";
            this.v7t15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t8
            // 
            this.v7t8.AutoSize = true;
            this.v7t8.Location = new System.Drawing.Point(397, 27);
            this.v7t8.Name = "v7t8";
            this.v7t8.Size = new System.Drawing.Size(13, 13);
            this.v7t8.TabIndex = 216;
            this.v7t8.Text = "0";
            this.v7t8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t1
            // 
            this.v7t1.AutoSize = true;
            this.v7t1.Location = new System.Drawing.Point(88, 27);
            this.v7t1.Name = "v7t1";
            this.v7t1.Size = new System.Drawing.Size(13, 13);
            this.v7t1.TabIndex = 204;
            this.v7t1.Text = "0";
            this.v7t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t7
            // 
            this.v7t7.AutoSize = true;
            this.v7t7.Location = new System.Drawing.Point(359, 27);
            this.v7t7.Name = "v7t7";
            this.v7t7.Size = new System.Drawing.Size(13, 13);
            this.v7t7.TabIndex = 215;
            this.v7t7.Text = "0";
            this.v7t7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t9
            // 
            this.v7t9.AutoSize = true;
            this.v7t9.Location = new System.Drawing.Point(434, 27);
            this.v7t9.Name = "v7t9";
            this.v7t9.Size = new System.Drawing.Size(13, 13);
            this.v7t9.TabIndex = 205;
            this.v7t9.Text = "0";
            this.v7t9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t14
            // 
            this.v7t14.AutoSize = true;
            this.v7t14.Location = new System.Drawing.Point(630, 27);
            this.v7t14.Name = "v7t14";
            this.v7t14.Size = new System.Drawing.Size(13, 13);
            this.v7t14.TabIndex = 214;
            this.v7t14.Text = "0";
            this.v7t14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t2
            // 
            this.v7t2.AutoSize = true;
            this.v7t2.Location = new System.Drawing.Point(146, 27);
            this.v7t2.Name = "v7t2";
            this.v7t2.Size = new System.Drawing.Size(13, 13);
            this.v7t2.TabIndex = 213;
            this.v7t2.Text = "0";
            this.v7t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t6
            // 
            this.v7t6.AutoSize = true;
            this.v7t6.Location = new System.Drawing.Point(324, 27);
            this.v7t6.Name = "v7t6";
            this.v7t6.Size = new System.Drawing.Size(13, 13);
            this.v7t6.TabIndex = 212;
            this.v7t6.Text = "0";
            this.v7t6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t10
            // 
            this.v7t10.AutoSize = true;
            this.v7t10.Location = new System.Drawing.Point(472, 27);
            this.v7t10.Name = "v7t10";
            this.v7t10.Size = new System.Drawing.Size(13, 13);
            this.v7t10.TabIndex = 211;
            this.v7t10.Text = "0";
            this.v7t10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t13
            // 
            this.v7t13.AutoSize = true;
            this.v7t13.Location = new System.Drawing.Point(586, 27);
            this.v7t13.Name = "v7t13";
            this.v7t13.Size = new System.Drawing.Size(13, 13);
            this.v7t13.TabIndex = 210;
            this.v7t13.Text = "0";
            this.v7t13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t3
            // 
            this.v7t3.AutoSize = true;
            this.v7t3.Location = new System.Drawing.Point(199, 27);
            this.v7t3.Name = "v7t3";
            this.v7t3.Size = new System.Drawing.Size(13, 13);
            this.v7t3.TabIndex = 209;
            this.v7t3.Text = "0";
            this.v7t3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t5
            // 
            this.v7t5.AutoSize = true;
            this.v7t5.Location = new System.Drawing.Point(286, 27);
            this.v7t5.Name = "v7t5";
            this.v7t5.Size = new System.Drawing.Size(13, 13);
            this.v7t5.TabIndex = 208;
            this.v7t5.Text = "0";
            this.v7t5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t12
            // 
            this.v7t12.AutoSize = true;
            this.v7t12.Location = new System.Drawing.Point(546, 27);
            this.v7t12.Name = "v7t12";
            this.v7t12.Size = new System.Drawing.Size(13, 13);
            this.v7t12.TabIndex = 207;
            this.v7t12.Text = "0";
            this.v7t12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t4
            // 
            this.v7t4.AutoSize = true;
            this.v7t4.Location = new System.Drawing.Point(245, 27);
            this.v7t4.Name = "v7t4";
            this.v7t4.Size = new System.Drawing.Size(13, 13);
            this.v7t4.TabIndex = 218;
            this.v7t4.Text = "0";
            this.v7t4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v7t11
            // 
            this.v7t11.AutoSize = true;
            this.v7t11.Location = new System.Drawing.Point(509, 27);
            this.v7t11.Name = "v7t11";
            this.v7t11.Size = new System.Drawing.Size(13, 13);
            this.v7t11.TabIndex = 219;
            this.v7t11.Text = "0";
            this.v7t11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t16
            // 
            this.v6t16.AutoSize = true;
            this.v6t16.Location = new System.Drawing.Point(745, 13);
            this.v6t16.Name = "v6t16";
            this.v6t16.Size = new System.Drawing.Size(13, 13);
            this.v6t16.TabIndex = 190;
            this.v6t16.Text = "0";
            this.v6t16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t15
            // 
            this.v6t15.AutoSize = true;
            this.v6t15.Location = new System.Drawing.Point(684, 13);
            this.v6t15.Name = "v6t15";
            this.v6t15.Size = new System.Drawing.Size(13, 13);
            this.v6t15.TabIndex = 201;
            this.v6t15.Text = "0";
            this.v6t15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t8
            // 
            this.v6t8.AutoSize = true;
            this.v6t8.Location = new System.Drawing.Point(397, 13);
            this.v6t8.Name = "v6t8";
            this.v6t8.Size = new System.Drawing.Size(13, 13);
            this.v6t8.TabIndex = 200;
            this.v6t8.Text = "0";
            this.v6t8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t1
            // 
            this.v6t1.AutoSize = true;
            this.v6t1.Location = new System.Drawing.Point(88, 13);
            this.v6t1.Name = "v6t1";
            this.v6t1.Size = new System.Drawing.Size(13, 13);
            this.v6t1.TabIndex = 188;
            this.v6t1.Text = "0";
            this.v6t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t7
            // 
            this.v6t7.AutoSize = true;
            this.v6t7.Location = new System.Drawing.Point(359, 13);
            this.v6t7.Name = "v6t7";
            this.v6t7.Size = new System.Drawing.Size(13, 13);
            this.v6t7.TabIndex = 199;
            this.v6t7.Text = "0";
            this.v6t7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t9
            // 
            this.v6t9.AutoSize = true;
            this.v6t9.Location = new System.Drawing.Point(434, 13);
            this.v6t9.Name = "v6t9";
            this.v6t9.Size = new System.Drawing.Size(13, 13);
            this.v6t9.TabIndex = 189;
            this.v6t9.Text = "0";
            this.v6t9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t14
            // 
            this.v6t14.AutoSize = true;
            this.v6t14.Location = new System.Drawing.Point(630, 13);
            this.v6t14.Name = "v6t14";
            this.v6t14.Size = new System.Drawing.Size(13, 13);
            this.v6t14.TabIndex = 198;
            this.v6t14.Text = "0";
            this.v6t14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t2
            // 
            this.v6t2.AutoSize = true;
            this.v6t2.Location = new System.Drawing.Point(146, 13);
            this.v6t2.Name = "v6t2";
            this.v6t2.Size = new System.Drawing.Size(13, 13);
            this.v6t2.TabIndex = 197;
            this.v6t2.Text = "0";
            this.v6t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t6
            // 
            this.v6t6.AutoSize = true;
            this.v6t6.Location = new System.Drawing.Point(324, 13);
            this.v6t6.Name = "v6t6";
            this.v6t6.Size = new System.Drawing.Size(13, 13);
            this.v6t6.TabIndex = 196;
            this.v6t6.Text = "0";
            this.v6t6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t10
            // 
            this.v6t10.AutoSize = true;
            this.v6t10.Location = new System.Drawing.Point(472, 13);
            this.v6t10.Name = "v6t10";
            this.v6t10.Size = new System.Drawing.Size(13, 13);
            this.v6t10.TabIndex = 195;
            this.v6t10.Text = "0";
            this.v6t10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t13
            // 
            this.v6t13.AutoSize = true;
            this.v6t13.Location = new System.Drawing.Point(586, 13);
            this.v6t13.Name = "v6t13";
            this.v6t13.Size = new System.Drawing.Size(13, 13);
            this.v6t13.TabIndex = 194;
            this.v6t13.Text = "0";
            this.v6t13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t3
            // 
            this.v6t3.AutoSize = true;
            this.v6t3.Location = new System.Drawing.Point(199, 13);
            this.v6t3.Name = "v6t3";
            this.v6t3.Size = new System.Drawing.Size(13, 13);
            this.v6t3.TabIndex = 193;
            this.v6t3.Text = "0";
            this.v6t3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t5
            // 
            this.v6t5.AutoSize = true;
            this.v6t5.Location = new System.Drawing.Point(286, 13);
            this.v6t5.Name = "v6t5";
            this.v6t5.Size = new System.Drawing.Size(13, 13);
            this.v6t5.TabIndex = 192;
            this.v6t5.Text = "0";
            this.v6t5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t12
            // 
            this.v6t12.AutoSize = true;
            this.v6t12.Location = new System.Drawing.Point(546, 13);
            this.v6t12.Name = "v6t12";
            this.v6t12.Size = new System.Drawing.Size(13, 13);
            this.v6t12.TabIndex = 191;
            this.v6t12.Text = "0";
            this.v6t12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t4
            // 
            this.v6t4.AutoSize = true;
            this.v6t4.Location = new System.Drawing.Point(245, 13);
            this.v6t4.Name = "v6t4";
            this.v6t4.Size = new System.Drawing.Size(13, 13);
            this.v6t4.TabIndex = 202;
            this.v6t4.Text = "0";
            this.v6t4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v6t11
            // 
            this.v6t11.AutoSize = true;
            this.v6t11.Location = new System.Drawing.Point(509, 13);
            this.v6t11.Name = "v6t11";
            this.v6t11.Size = new System.Drawing.Size(13, 13);
            this.v6t11.TabIndex = 203;
            this.v6t11.Text = "0";
            this.v6t11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t16
            // 
            this.v5t16.AutoSize = true;
            this.v5t16.Location = new System.Drawing.Point(745, 0);
            this.v5t16.Name = "v5t16";
            this.v5t16.Size = new System.Drawing.Size(13, 13);
            this.v5t16.TabIndex = 174;
            this.v5t16.Text = "0";
            this.v5t16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t15
            // 
            this.v5t15.AutoSize = true;
            this.v5t15.Location = new System.Drawing.Point(684, 0);
            this.v5t15.Name = "v5t15";
            this.v5t15.Size = new System.Drawing.Size(13, 13);
            this.v5t15.TabIndex = 185;
            this.v5t15.Text = "0";
            this.v5t15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t8
            // 
            this.v5t8.AutoSize = true;
            this.v5t8.Location = new System.Drawing.Point(397, 0);
            this.v5t8.Name = "v5t8";
            this.v5t8.Size = new System.Drawing.Size(13, 13);
            this.v5t8.TabIndex = 184;
            this.v5t8.Text = "0";
            this.v5t8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t1
            // 
            this.v5t1.AutoSize = true;
            this.v5t1.Location = new System.Drawing.Point(88, 0);
            this.v5t1.Name = "v5t1";
            this.v5t1.Size = new System.Drawing.Size(13, 13);
            this.v5t1.TabIndex = 172;
            this.v5t1.Text = "0";
            this.v5t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t7
            // 
            this.v5t7.AutoSize = true;
            this.v5t7.Location = new System.Drawing.Point(359, 0);
            this.v5t7.Name = "v5t7";
            this.v5t7.Size = new System.Drawing.Size(13, 13);
            this.v5t7.TabIndex = 183;
            this.v5t7.Text = "0";
            this.v5t7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t9
            // 
            this.v5t9.AutoSize = true;
            this.v5t9.Location = new System.Drawing.Point(434, 0);
            this.v5t9.Name = "v5t9";
            this.v5t9.Size = new System.Drawing.Size(13, 13);
            this.v5t9.TabIndex = 173;
            this.v5t9.Text = "0";
            this.v5t9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t14
            // 
            this.v5t14.AutoSize = true;
            this.v5t14.Location = new System.Drawing.Point(630, 0);
            this.v5t14.Name = "v5t14";
            this.v5t14.Size = new System.Drawing.Size(13, 13);
            this.v5t14.TabIndex = 182;
            this.v5t14.Text = "0";
            this.v5t14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t2
            // 
            this.v5t2.AutoSize = true;
            this.v5t2.Location = new System.Drawing.Point(146, 0);
            this.v5t2.Name = "v5t2";
            this.v5t2.Size = new System.Drawing.Size(13, 13);
            this.v5t2.TabIndex = 181;
            this.v5t2.Text = "0";
            this.v5t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t6
            // 
            this.v5t6.AutoSize = true;
            this.v5t6.Location = new System.Drawing.Point(324, 0);
            this.v5t6.Name = "v5t6";
            this.v5t6.Size = new System.Drawing.Size(13, 13);
            this.v5t6.TabIndex = 180;
            this.v5t6.Text = "0";
            this.v5t6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t10
            // 
            this.v5t10.AutoSize = true;
            this.v5t10.Location = new System.Drawing.Point(472, 0);
            this.v5t10.Name = "v5t10";
            this.v5t10.Size = new System.Drawing.Size(13, 13);
            this.v5t10.TabIndex = 179;
            this.v5t10.Text = "0";
            this.v5t10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t13
            // 
            this.v5t13.AutoSize = true;
            this.v5t13.Location = new System.Drawing.Point(586, 0);
            this.v5t13.Name = "v5t13";
            this.v5t13.Size = new System.Drawing.Size(13, 13);
            this.v5t13.TabIndex = 178;
            this.v5t13.Text = "0";
            this.v5t13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t3
            // 
            this.v5t3.AutoSize = true;
            this.v5t3.Location = new System.Drawing.Point(199, 0);
            this.v5t3.Name = "v5t3";
            this.v5t3.Size = new System.Drawing.Size(13, 13);
            this.v5t3.TabIndex = 177;
            this.v5t3.Text = "0";
            this.v5t3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t5
            // 
            this.v5t5.AutoSize = true;
            this.v5t5.Location = new System.Drawing.Point(286, 0);
            this.v5t5.Name = "v5t5";
            this.v5t5.Size = new System.Drawing.Size(13, 13);
            this.v5t5.TabIndex = 176;
            this.v5t5.Text = "0";
            this.v5t5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t12
            // 
            this.v5t12.AutoSize = true;
            this.v5t12.Location = new System.Drawing.Point(546, 0);
            this.v5t12.Name = "v5t12";
            this.v5t12.Size = new System.Drawing.Size(13, 13);
            this.v5t12.TabIndex = 175;
            this.v5t12.Text = "0";
            this.v5t12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t4
            // 
            this.v5t4.AutoSize = true;
            this.v5t4.Location = new System.Drawing.Point(245, 0);
            this.v5t4.Name = "v5t4";
            this.v5t4.Size = new System.Drawing.Size(13, 13);
            this.v5t4.TabIndex = 186;
            this.v5t4.Text = "0";
            this.v5t4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v5t11
            // 
            this.v5t11.AutoSize = true;
            this.v5t11.Location = new System.Drawing.Point(509, 0);
            this.v5t11.Name = "v5t11";
            this.v5t11.Size = new System.Drawing.Size(13, 13);
            this.v5t11.TabIndex = 187;
            this.v5t11.Text = "0";
            this.v5t11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(2, 27);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(70, 13);
            this.label46.TabIndex = 0;
            this.label46.Text = "Cast2 to OP1";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(22, 13);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(34, 13);
            this.label45.TabIndex = 0;
            this.label45.Text = "Cast2";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(22, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(34, 13);
            this.label44.TabIndex = 0;
            this.label44.Text = "Cast1";
            // 
            // tab_CurveFit
            // 
            this.tab_CurveFit.Controls.Add(this.lv_wires);
            this.tab_CurveFit.Controls.Add(this.lb_curve2occlusalPlane);
            this.tab_CurveFit.Controls.Add(this.pl_wireMatch);
            this.tab_CurveFit.Controls.Add(this.cb_curvePlane2);
            this.tab_CurveFit.Controls.Add(this.groupBox8);
            this.tab_CurveFit.Controls.Add(this.lb_curvefit_rmse_z);
            this.tab_CurveFit.Controls.Add(this.lb_curvefit_rmse_xy);
            this.tab_CurveFit.Controls.Add(this.cb_curvePlane1);
            this.tab_CurveFit.Controls.Add(this.panel1);
            this.tab_CurveFit.Controls.Add(this.pl_curveFit);
            this.tab_CurveFit.Location = new System.Drawing.Point(4, 22);
            this.tab_CurveFit.Name = "tab_CurveFit";
            this.tab_CurveFit.Padding = new System.Windows.Forms.Padding(3);
            this.tab_CurveFit.Size = new System.Drawing.Size(788, 211);
            this.tab_CurveFit.TabIndex = 4;
            this.tab_CurveFit.Text = "Curve Fit";
            this.tab_CurveFit.UseVisualStyleBackColor = true;
            // 
            // lv_wires
            // 
            this.lv_wires.Location = new System.Drawing.Point(189, 68);
            this.lv_wires.Name = "lv_wires";
            this.lv_wires.Size = new System.Drawing.Size(119, 124);
            this.lv_wires.TabIndex = 3;
            this.lv_wires.UseCompatibleStateImageBehavior = false;
            this.lv_wires.View = System.Windows.Forms.View.Details;
            this.lv_wires.SelectedIndexChanged += new System.EventHandler(this.lv_wires_SelectedIndexChanged);
            // 
            // lb_curve2occlusalPlane
            // 
            this.lb_curve2occlusalPlane.AutoSize = true;
            this.lb_curve2occlusalPlane.Location = new System.Drawing.Point(189, 48);
            this.lb_curve2occlusalPlane.Name = "lb_curve2occlusalPlane";
            this.lb_curve2occlusalPlane.Size = new System.Drawing.Size(10, 13);
            this.lb_curve2occlusalPlane.TabIndex = 98;
            this.lb_curve2occlusalPlane.Text = "-";
            // 
            // pl_wireMatch
            // 
            this.pl_wireMatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pl_wireMatch.Location = new System.Drawing.Point(565, 9);
            this.pl_wireMatch.Name = "pl_wireMatch";
            this.pl_wireMatch.Size = new System.Drawing.Size(218, 195);
            this.pl_wireMatch.TabIndex = 1;
            // 
            // cb_curvePlane2
            // 
            this.cb_curvePlane2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_curvePlane2.AutoSize = true;
            this.cb_curvePlane2.Enabled = false;
            this.cb_curvePlane2.Location = new System.Drawing.Point(5, 192);
            this.cb_curvePlane2.Name = "cb_curvePlane2";
            this.cb_curvePlane2.Size = new System.Drawing.Size(92, 17);
            this.cb_curvePlane2.TabIndex = 96;
            this.cb_curvePlane2.Text = "Show Plane 2";
            this.cb_curvePlane2.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.b_matchingWire);
            this.groupBox8.Controls.Add(this.rb_maxilla);
            this.groupBox8.Controls.Add(this.rb_mandible);
            this.groupBox8.Location = new System.Drawing.Point(6, 62);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(177, 111);
            this.groupBox8.TabIndex = 97;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Matching Wire";
            // 
            // b_matchingWire
            // 
            this.b_matchingWire.Location = new System.Drawing.Point(2, 70);
            this.b_matchingWire.Name = "b_matchingWire";
            this.b_matchingWire.Size = new System.Drawing.Size(67, 35);
            this.b_matchingWire.TabIndex = 2;
            this.b_matchingWire.Text = "Find Best Wire";
            this.b_matchingWire.UseVisualStyleBackColor = true;
            this.b_matchingWire.Click += new System.EventHandler(this.b_matchingWire_Click);
            // 
            // rb_maxilla
            // 
            this.rb_maxilla.AutoSize = true;
            this.rb_maxilla.Location = new System.Drawing.Point(7, 39);
            this.rb_maxilla.Name = "rb_maxilla";
            this.rb_maxilla.Size = new System.Drawing.Size(57, 17);
            this.rb_maxilla.TabIndex = 1;
            this.rb_maxilla.Text = "Maxilla";
            this.rb_maxilla.UseVisualStyleBackColor = true;
            // 
            // rb_mandible
            // 
            this.rb_mandible.Checked = true;
            this.rb_mandible.Location = new System.Drawing.Point(7, 19);
            this.rb_mandible.Name = "rb_mandible";
            this.rb_mandible.Size = new System.Drawing.Size(82, 24);
            this.rb_mandible.TabIndex = 0;
            this.rb_mandible.TabStop = true;
            this.rb_mandible.Text = "Mandible";
            this.rb_mandible.UseVisualStyleBackColor = true;
            // 
            // lb_curvefit_rmse_z
            // 
            this.lb_curvefit_rmse_z.AutoSize = true;
            this.lb_curvefit_rmse_z.Location = new System.Drawing.Point(189, 30);
            this.lb_curvefit_rmse_z.Name = "lb_curvefit_rmse_z";
            this.lb_curvefit_rmse_z.Size = new System.Drawing.Size(10, 13);
            this.lb_curvefit_rmse_z.TabIndex = 8;
            this.lb_curvefit_rmse_z.Text = "-";
            // 
            // lb_curvefit_rmse_xy
            // 
            this.lb_curvefit_rmse_xy.AutoSize = true;
            this.lb_curvefit_rmse_xy.Location = new System.Drawing.Point(189, 11);
            this.lb_curvefit_rmse_xy.Name = "lb_curvefit_rmse_xy";
            this.lb_curvefit_rmse_xy.Size = new System.Drawing.Size(10, 13);
            this.lb_curvefit_rmse_xy.TabIndex = 7;
            this.lb_curvefit_rmse_xy.Text = "-";
            // 
            // cb_curvePlane1
            // 
            this.cb_curvePlane1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_curvePlane1.AutoSize = true;
            this.cb_curvePlane1.Enabled = false;
            this.cb_curvePlane1.Location = new System.Drawing.Point(5, 175);
            this.cb_curvePlane1.Name = "cb_curvePlane1";
            this.cb_curvePlane1.Size = new System.Drawing.Size(92, 17);
            this.cb_curvePlane1.TabIndex = 96;
            this.cb_curvePlane1.Text = "Show Plane 1";
            this.cb_curvePlane1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_fitPoly);
            this.panel1.Controls.Add(this.rb_fitNoroozi);
            this.panel1.Controls.Add(this.nUpDown_order);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 51);
            this.panel1.TabIndex = 6;
            // 
            // rb_fitPoly
            // 
            this.rb_fitPoly.AutoSize = true;
            this.rb_fitPoly.Checked = true;
            this.rb_fitPoly.Location = new System.Drawing.Point(8, 6);
            this.rb_fitPoly.Name = "rb_fitPoly";
            this.rb_fitPoly.Size = new System.Drawing.Size(104, 17);
            this.rb_fitPoly.TabIndex = 4;
            this.rb_fitPoly.TabStop = true;
            this.rb_fitPoly.Text = "Polynomial Order";
            this.rb_fitPoly.UseVisualStyleBackColor = true;
            this.rb_fitPoly.CheckedChanged += new System.EventHandler(this.rb_fitFunction_CheckedChanged);
            // 
            // rb_fitNoroozi
            // 
            this.rb_fitNoroozi.AutoSize = true;
            this.rb_fitNoroozi.Location = new System.Drawing.Point(8, 28);
            this.rb_fitNoroozi.Name = "rb_fitNoroozi";
            this.rb_fitNoroozi.Size = new System.Drawing.Size(115, 17);
            this.rb_fitNoroozi.TabIndex = 5;
            this.rb_fitNoroozi.Text = "Noroozi B-Function";
            this.rb_fitNoroozi.UseVisualStyleBackColor = true;
            this.rb_fitNoroozi.CheckedChanged += new System.EventHandler(this.rb_fitFunction_CheckedChanged);
            // 
            // nUpDown_order
            // 
            this.nUpDown_order.Location = new System.Drawing.Point(118, 5);
            this.nUpDown_order.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nUpDown_order.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUpDown_order.Name = "nUpDown_order";
            this.nUpDown_order.Size = new System.Drawing.Size(51, 20);
            this.nUpDown_order.TabIndex = 1;
            this.nUpDown_order.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nUpDown_order.ValueChanged += new System.EventHandler(this.nUpDown_order_ValueChanged);
            // 
            // pl_curveFit
            // 
            this.pl_curveFit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pl_curveFit.Location = new System.Drawing.Point(341, 9);
            this.pl_curveFit.Name = "pl_curveFit";
            this.pl_curveFit.Size = new System.Drawing.Size(218, 195);
            this.pl_curveFit.TabIndex = 0;
            // 
            // gb_teeh
            // 
            this.gb_teeh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gb_teeh.BackgroundImage = global::OrthoAid_3DSimulator.Properties.Resources.teeth_tabled;
            this.gb_teeh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gb_teeh.Controls.Add(this.t32);
            this.gb_teeh.Controls.Add(this.t31);
            this.gb_teeh.Controls.Add(this.t29);
            this.gb_teeh.Controls.Add(this.t9);
            this.gb_teeh.Controls.Add(this.t8);
            this.gb_teeh.Controls.Add(this.t10);
            this.gb_teeh.Controls.Add(this.t7);
            this.gb_teeh.Controls.Add(this.t11);
            this.gb_teeh.Controls.Add(this.t6);
            this.gb_teeh.Controls.Add(this.t21);
            this.gb_teeh.Controls.Add(this.t12);
            this.gb_teeh.Controls.Add(this.t5);
            this.gb_teeh.Controls.Add(this.t20);
            this.gb_teeh.Controls.Add(this.t13);
            this.gb_teeh.Controls.Add(this.t4);
            this.gb_teeh.Controls.Add(this.t19);
            this.gb_teeh.Controls.Add(this.t14);
            this.gb_teeh.Controls.Add(this.t3);
            this.gb_teeh.Controls.Add(this.t18);
            this.gb_teeh.Controls.Add(this.t15);
            this.gb_teeh.Controls.Add(this.t2);
            this.gb_teeh.Controls.Add(this.t17);
            this.gb_teeh.Controls.Add(this.t16);
            this.gb_teeh.Controls.Add(this.t1);
            this.gb_teeh.Controls.Add(this.t24);
            this.gb_teeh.Controls.Add(this.t25);
            this.gb_teeh.Controls.Add(this.t23);
            this.gb_teeh.Controls.Add(this.t26);
            this.gb_teeh.Controls.Add(this.t22);
            this.gb_teeh.Controls.Add(this.t27);
            this.gb_teeh.Controls.Add(this.t28);
            this.gb_teeh.Controls.Add(this.t30);
            this.gb_teeh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gb_teeh.Location = new System.Drawing.Point(82, 460);
            this.gb_teeh.Margin = new System.Windows.Forms.Padding(0);
            this.gb_teeh.Name = "gb_teeh";
            this.gb_teeh.Size = new System.Drawing.Size(711, 135);
            this.gb_teeh.TabIndex = 92;
            this.gb_teeh.TabStop = false;
            this.gb_teeh.Visible = false;
            // 
            // t32
            // 
            this.t32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t32.BackColor = System.Drawing.Color.Transparent;
            this.t32.Location = new System.Drawing.Point(8, 74);
            this.t32.MaximumSize = new System.Drawing.Size(50, 50);
            this.t32.Name = "t32";
            this.t32.Size = new System.Drawing.Size(40, 46);
            this.t32.TabIndex = 0;
            this.t32.UseCompatibleTextRendering = true;
            this.t32.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t31
            // 
            this.t31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t31.BackColor = System.Drawing.Color.Transparent;
            this.t31.Location = new System.Drawing.Point(62, 74);
            this.t31.MaximumSize = new System.Drawing.Size(50, 50);
            this.t31.Name = "t31";
            this.t31.Size = new System.Drawing.Size(42, 50);
            this.t31.TabIndex = 0;
            this.t31.UseCompatibleTextRendering = true;
            this.t31.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t29
            // 
            this.t29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t29.BackColor = System.Drawing.Color.Transparent;
            this.t29.Location = new System.Drawing.Point(166, 75);
            this.t29.MaximumSize = new System.Drawing.Size(50, 50);
            this.t29.Name = "t29";
            this.t29.Size = new System.Drawing.Size(35, 50);
            this.t29.TabIndex = 0;
            this.t29.UseCompatibleTextRendering = true;
            this.t29.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t9
            // 
            this.t9.BackColor = System.Drawing.Color.Transparent;
            this.t9.Location = new System.Drawing.Point(361, 16);
            this.t9.MaximumSize = new System.Drawing.Size(50, 50);
            this.t9.Name = "t9";
            this.t9.Size = new System.Drawing.Size(27, 50);
            this.t9.TabIndex = 0;
            this.t9.UseCompatibleTextRendering = true;
            this.t9.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t8
            // 
            this.t8.BackColor = System.Drawing.Color.Transparent;
            this.t8.Location = new System.Drawing.Point(323, 17);
            this.t8.MaximumSize = new System.Drawing.Size(50, 50);
            this.t8.Name = "t8";
            this.t8.Size = new System.Drawing.Size(27, 50);
            this.t8.TabIndex = 0;
            this.t8.UseCompatibleTextRendering = true;
            this.t8.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t10
            // 
            this.t10.BackColor = System.Drawing.Color.Transparent;
            this.t10.Location = new System.Drawing.Point(399, 17);
            this.t10.MaximumSize = new System.Drawing.Size(50, 50);
            this.t10.Name = "t10";
            this.t10.Size = new System.Drawing.Size(27, 50);
            this.t10.TabIndex = 0;
            this.t10.UseCompatibleTextRendering = true;
            this.t10.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t7
            // 
            this.t7.BackColor = System.Drawing.Color.Transparent;
            this.t7.Location = new System.Drawing.Point(286, 20);
            this.t7.MaximumSize = new System.Drawing.Size(50, 50);
            this.t7.Name = "t7";
            this.t7.Size = new System.Drawing.Size(27, 45);
            this.t7.TabIndex = 0;
            this.t7.UseCompatibleTextRendering = true;
            this.t7.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t11
            // 
            this.t11.BackColor = System.Drawing.Color.Transparent;
            this.t11.Location = new System.Drawing.Point(436, 13);
            this.t11.MaximumSize = new System.Drawing.Size(50, 50);
            this.t11.Name = "t11";
            this.t11.Size = new System.Drawing.Size(27, 50);
            this.t11.TabIndex = 0;
            this.t11.UseCompatibleTextRendering = true;
            this.t11.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t6
            // 
            this.t6.BackColor = System.Drawing.Color.Transparent;
            this.t6.Location = new System.Drawing.Point(248, 14);
            this.t6.MaximumSize = new System.Drawing.Size(50, 50);
            this.t6.Name = "t6";
            this.t6.Size = new System.Drawing.Size(27, 50);
            this.t6.TabIndex = 0;
            this.t6.UseCompatibleTextRendering = true;
            this.t6.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t21
            // 
            this.t21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t21.BackColor = System.Drawing.Color.Transparent;
            this.t21.Location = new System.Drawing.Point(472, 76);
            this.t21.MaximumSize = new System.Drawing.Size(50, 50);
            this.t21.Name = "t21";
            this.t21.Size = new System.Drawing.Size(27, 50);
            this.t21.TabIndex = 0;
            this.t21.UseCompatibleTextRendering = true;
            this.t21.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t12
            // 
            this.t12.BackColor = System.Drawing.Color.Transparent;
            this.t12.Location = new System.Drawing.Point(475, 15);
            this.t12.MaximumSize = new System.Drawing.Size(50, 50);
            this.t12.Name = "t12";
            this.t12.Size = new System.Drawing.Size(27, 50);
            this.t12.TabIndex = 0;
            this.t12.UseCompatibleTextRendering = true;
            this.t12.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t5
            // 
            this.t5.BackColor = System.Drawing.Color.Transparent;
            this.t5.Location = new System.Drawing.Point(210, 14);
            this.t5.MaximumSize = new System.Drawing.Size(50, 50);
            this.t5.Name = "t5";
            this.t5.Size = new System.Drawing.Size(27, 50);
            this.t5.TabIndex = 0;
            this.t5.UseCompatibleTextRendering = true;
            this.t5.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t20
            // 
            this.t20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t20.BackColor = System.Drawing.Color.Transparent;
            this.t20.Location = new System.Drawing.Point(510, 76);
            this.t20.MaximumSize = new System.Drawing.Size(50, 50);
            this.t20.Name = "t20";
            this.t20.Size = new System.Drawing.Size(35, 50);
            this.t20.TabIndex = 0;
            this.t20.UseCompatibleTextRendering = true;
            this.t20.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t13
            // 
            this.t13.BackColor = System.Drawing.Color.Transparent;
            this.t13.Location = new System.Drawing.Point(515, 15);
            this.t13.MaximumSize = new System.Drawing.Size(50, 50);
            this.t13.Name = "t13";
            this.t13.Size = new System.Drawing.Size(28, 50);
            this.t13.TabIndex = 0;
            this.t13.UseCompatibleTextRendering = true;
            this.t13.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t4
            // 
            this.t4.BackColor = System.Drawing.Color.Transparent;
            this.t4.Location = new System.Drawing.Point(166, 15);
            this.t4.MaximumSize = new System.Drawing.Size(50, 50);
            this.t4.Name = "t4";
            this.t4.Size = new System.Drawing.Size(35, 50);
            this.t4.TabIndex = 0;
            this.t4.UseCompatibleTextRendering = true;
            this.t4.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t19
            // 
            this.t19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t19.BackColor = System.Drawing.Color.Transparent;
            this.t19.Location = new System.Drawing.Point(549, 73);
            this.t19.MaximumSize = new System.Drawing.Size(50, 50);
            this.t19.Name = "t19";
            this.t19.Size = new System.Drawing.Size(44, 47);
            this.t19.TabIndex = 0;
            this.t19.UseCompatibleTextRendering = true;
            this.t19.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t14
            // 
            this.t14.BackColor = System.Drawing.Color.Transparent;
            this.t14.Location = new System.Drawing.Point(549, 15);
            this.t14.MaximumSize = new System.Drawing.Size(50, 50);
            this.t14.Name = "t14";
            this.t14.Size = new System.Drawing.Size(44, 50);
            this.t14.TabIndex = 0;
            this.t14.UseCompatibleTextRendering = true;
            this.t14.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t3
            // 
            this.t3.BackColor = System.Drawing.Color.Transparent;
            this.t3.Location = new System.Drawing.Point(119, 13);
            this.t3.MaximumSize = new System.Drawing.Size(50, 50);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(44, 50);
            this.t3.TabIndex = 0;
            this.t3.Tag = "3";
            this.t3.UseCompatibleTextRendering = true;
            this.t3.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t18
            // 
            this.t18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t18.BackColor = System.Drawing.Color.Transparent;
            this.t18.Location = new System.Drawing.Point(607, 73);
            this.t18.MaximumSize = new System.Drawing.Size(50, 50);
            this.t18.Name = "t18";
            this.t18.Size = new System.Drawing.Size(42, 47);
            this.t18.TabIndex = 0;
            this.t18.UseCompatibleTextRendering = true;
            this.t18.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t15
            // 
            this.t15.BackColor = System.Drawing.Color.Transparent;
            this.t15.Location = new System.Drawing.Point(599, 14);
            this.t15.MaximumSize = new System.Drawing.Size(50, 50);
            this.t15.Name = "t15";
            this.t15.Size = new System.Drawing.Size(50, 48);
            this.t15.TabIndex = 0;
            this.t15.UseCompatibleTextRendering = true;
            this.t15.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t2
            // 
            this.t2.BackColor = System.Drawing.Color.Transparent;
            this.t2.Location = new System.Drawing.Point(63, 11);
            this.t2.MaximumSize = new System.Drawing.Size(50, 50);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(50, 50);
            this.t2.TabIndex = 0;
            this.t2.Tag = "2";
            this.t2.UseCompatibleTextRendering = true;
            this.t2.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t17
            // 
            this.t17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t17.BackColor = System.Drawing.Color.Transparent;
            this.t17.Location = new System.Drawing.Point(663, 74);
            this.t17.MaximumSize = new System.Drawing.Size(50, 50);
            this.t17.Name = "t17";
            this.t17.Size = new System.Drawing.Size(41, 43);
            this.t17.TabIndex = 0;
            this.t17.UseCompatibleTextRendering = true;
            this.t17.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t16
            // 
            this.t16.BackColor = System.Drawing.Color.Transparent;
            this.t16.Location = new System.Drawing.Point(658, 11);
            this.t16.MaximumSize = new System.Drawing.Size(50, 50);
            this.t16.Name = "t16";
            this.t16.Size = new System.Drawing.Size(50, 50);
            this.t16.TabIndex = 0;
            this.t16.UseCompatibleTextRendering = true;
            this.t16.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t1
            // 
            this.t1.BackColor = System.Drawing.Color.Transparent;
            this.t1.Location = new System.Drawing.Point(4, 11);
            this.t1.MaximumSize = new System.Drawing.Size(50, 50);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(50, 50);
            this.t1.TabIndex = 0;
            this.t1.Tag = "1";
            this.t1.UseCompatibleTextRendering = true;
            this.t1.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t24
            // 
            this.t24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t24.BackColor = System.Drawing.Color.Transparent;
            this.t24.Location = new System.Drawing.Point(362, 76);
            this.t24.MaximumSize = new System.Drawing.Size(50, 50);
            this.t24.Name = "t24";
            this.t24.Size = new System.Drawing.Size(27, 50);
            this.t24.TabIndex = 0;
            this.t24.UseCompatibleTextRendering = true;
            this.t24.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t25
            // 
            this.t25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t25.BackColor = System.Drawing.Color.Transparent;
            this.t25.Location = new System.Drawing.Point(322, 76);
            this.t25.MaximumSize = new System.Drawing.Size(50, 50);
            this.t25.Name = "t25";
            this.t25.Size = new System.Drawing.Size(27, 50);
            this.t25.TabIndex = 0;
            this.t25.UseCompatibleTextRendering = true;
            this.t25.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t23
            // 
            this.t23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t23.BackColor = System.Drawing.Color.Transparent;
            this.t23.Location = new System.Drawing.Point(399, 76);
            this.t23.MaximumSize = new System.Drawing.Size(50, 50);
            this.t23.Name = "t23";
            this.t23.Size = new System.Drawing.Size(27, 50);
            this.t23.TabIndex = 0;
            this.t23.UseCompatibleTextRendering = true;
            this.t23.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t26
            // 
            this.t26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t26.BackColor = System.Drawing.Color.Transparent;
            this.t26.Location = new System.Drawing.Point(286, 76);
            this.t26.MaximumSize = new System.Drawing.Size(50, 50);
            this.t26.Name = "t26";
            this.t26.Size = new System.Drawing.Size(27, 50);
            this.t26.TabIndex = 0;
            this.t26.UseCompatibleTextRendering = true;
            this.t26.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t22
            // 
            this.t22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t22.BackColor = System.Drawing.Color.Transparent;
            this.t22.Location = new System.Drawing.Point(436, 77);
            this.t22.MaximumSize = new System.Drawing.Size(50, 50);
            this.t22.Name = "t22";
            this.t22.Size = new System.Drawing.Size(27, 50);
            this.t22.TabIndex = 0;
            this.t22.UseCompatibleTextRendering = true;
            this.t22.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t27
            // 
            this.t27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t27.BackColor = System.Drawing.Color.Transparent;
            this.t27.Location = new System.Drawing.Point(251, 74);
            this.t27.MaximumSize = new System.Drawing.Size(50, 50);
            this.t27.Name = "t27";
            this.t27.Size = new System.Drawing.Size(27, 50);
            this.t27.TabIndex = 0;
            this.t27.UseCompatibleTextRendering = true;
            this.t27.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t28
            // 
            this.t28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t28.BackColor = System.Drawing.Color.Transparent;
            this.t28.Location = new System.Drawing.Point(212, 75);
            this.t28.MaximumSize = new System.Drawing.Size(50, 50);
            this.t28.Name = "t28";
            this.t28.Size = new System.Drawing.Size(27, 50);
            this.t28.TabIndex = 0;
            this.t28.UseCompatibleTextRendering = true;
            this.t28.Click += new System.EventHandler(this.LabelSelect);
            // 
            // t30
            // 
            this.t30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.t30.BackColor = System.Drawing.Color.Transparent;
            this.t30.Location = new System.Drawing.Point(118, 75);
            this.t30.MaximumSize = new System.Drawing.Size(50, 50);
            this.t30.Name = "t30";
            this.t30.Size = new System.Drawing.Size(44, 45);
            this.t30.TabIndex = 0;
            this.t30.UseCompatibleTextRendering = true;
            this.t30.Click += new System.EventHandler(this.LabelSelect);
            // 
            // lb_numVerticesReduced
            // 
            this.lb_numVerticesReduced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_numVerticesReduced.AutoSize = true;
            this.lb_numVerticesReduced.Location = new System.Drawing.Point(631, 288);
            this.lb_numVerticesReduced.Name = "lb_numVerticesReduced";
            this.lb_numVerticesReduced.Size = new System.Drawing.Size(57, 13);
            this.lb_numVerticesReduced.TabIndex = 83;
            this.lb_numVerticesReduced.Text = "Vertices: 0";
            this.lb_numVerticesReduced.Visible = false;
            // 
            // lb_RDCastLabel
            // 
            this.lb_RDCastLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_RDCastLabel.AutoSize = true;
            this.lb_RDCastLabel.Location = new System.Drawing.Point(605, 258);
            this.lb_RDCastLabel.Name = "lb_RDCastLabel";
            this.lb_RDCastLabel.Size = new System.Drawing.Size(113, 13);
            this.lb_RDCastLabel.TabIndex = 84;
            this.lb_RDCastLabel.Text = "Reduced Density Cast";
            this.lb_RDCastLabel.Visible = false;
            // 
            // w1_tb
            // 
            this.w1_tb.Location = new System.Drawing.Point(6, 26);
            this.w1_tb.Name = "w1_tb";
            this.w1_tb.Size = new System.Drawing.Size(48, 20);
            this.w1_tb.TabIndex = 96;
            this.w1_tb.Tag = "0";
            this.w1_tb.Text = "1.0";
            this.w1_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w1_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w2_tb
            // 
            this.w2_tb.Location = new System.Drawing.Point(6, 49);
            this.w2_tb.Name = "w2_tb";
            this.w2_tb.Size = new System.Drawing.Size(48, 20);
            this.w2_tb.TabIndex = 97;
            this.w2_tb.Tag = "1";
            this.w2_tb.Text = "1.0";
            this.w2_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w2_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w3_tb
            // 
            this.w3_tb.Location = new System.Drawing.Point(6, 72);
            this.w3_tb.Name = "w3_tb";
            this.w3_tb.Size = new System.Drawing.Size(48, 20);
            this.w3_tb.TabIndex = 98;
            this.w3_tb.Tag = "2";
            this.w3_tb.Text = "1.0";
            this.w3_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w3_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w4_tb
            // 
            this.w4_tb.Location = new System.Drawing.Point(6, 95);
            this.w4_tb.Name = "w4_tb";
            this.w4_tb.Size = new System.Drawing.Size(48, 20);
            this.w4_tb.TabIndex = 99;
            this.w4_tb.Tag = "3";
            this.w4_tb.Text = "1.0";
            this.w4_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w4_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w5_tb
            // 
            this.w5_tb.Location = new System.Drawing.Point(6, 116);
            this.w5_tb.Name = "w5_tb";
            this.w5_tb.Size = new System.Drawing.Size(48, 20);
            this.w5_tb.TabIndex = 100;
            this.w5_tb.Tag = "4";
            this.w5_tb.Text = "1.0";
            this.w5_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w5_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w6_tb
            // 
            this.w6_tb.Location = new System.Drawing.Point(6, 139);
            this.w6_tb.Name = "w6_tb";
            this.w6_tb.Size = new System.Drawing.Size(48, 20);
            this.w6_tb.TabIndex = 101;
            this.w6_tb.Tag = "5";
            this.w6_tb.Text = "1.0";
            this.w6_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w6_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w7_tb
            // 
            this.w7_tb.Location = new System.Drawing.Point(6, 162);
            this.w7_tb.Name = "w7_tb";
            this.w7_tb.Size = new System.Drawing.Size(48, 20);
            this.w7_tb.TabIndex = 102;
            this.w7_tb.Tag = "6";
            this.w7_tb.Text = "1.0";
            this.w7_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w7_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w8_tb
            // 
            this.w8_tb.Location = new System.Drawing.Point(6, 185);
            this.w8_tb.Name = "w8_tb";
            this.w8_tb.Size = new System.Drawing.Size(48, 20);
            this.w8_tb.TabIndex = 103;
            this.w8_tb.Tag = "7";
            this.w8_tb.Text = "1.0";
            this.w8_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w8_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w9_tb
            // 
            this.w9_tb.Location = new System.Drawing.Point(6, 207);
            this.w9_tb.Name = "w9_tb";
            this.w9_tb.Size = new System.Drawing.Size(48, 20);
            this.w9_tb.TabIndex = 104;
            this.w9_tb.Tag = "8";
            this.w9_tb.Text = "1.0";
            this.w9_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w9_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w10_tb
            // 
            this.w10_tb.Location = new System.Drawing.Point(6, 230);
            this.w10_tb.Name = "w10_tb";
            this.w10_tb.Size = new System.Drawing.Size(48, 20);
            this.w10_tb.TabIndex = 105;
            this.w10_tb.Tag = "9";
            this.w10_tb.Text = "1.0";
            this.w10_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w10_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w11_tb
            // 
            this.w11_tb.Location = new System.Drawing.Point(6, 253);
            this.w11_tb.Name = "w11_tb";
            this.w11_tb.Size = new System.Drawing.Size(48, 20);
            this.w11_tb.TabIndex = 106;
            this.w11_tb.Tag = "10";
            this.w11_tb.Text = "1.0";
            this.w11_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w11_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // w12_tb
            // 
            this.w12_tb.Location = new System.Drawing.Point(6, 273);
            this.w12_tb.Name = "w12_tb";
            this.w12_tb.Size = new System.Drawing.Size(48, 20);
            this.w12_tb.TabIndex = 107;
            this.w12_tb.Tag = "11";
            this.w12_tb.Text = "1.0";
            this.w12_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.w12_tb.TextChanged += new System.EventHandler(this.weight_TextChanged);
            // 
            // gb_weight
            // 
            this.gb_weight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_weight.Controls.Add(this.w12_tb);
            this.gb_weight.Controls.Add(this.w1_tb);
            this.gb_weight.Controls.Add(this.w11_tb);
            this.gb_weight.Controls.Add(this.w2_tb);
            this.gb_weight.Controls.Add(this.w8_tb);
            this.gb_weight.Controls.Add(this.w5_tb);
            this.gb_weight.Controls.Add(this.w7_tb);
            this.gb_weight.Controls.Add(this.w3_tb);
            this.gb_weight.Controls.Add(this.w10_tb);
            this.gb_weight.Controls.Add(this.w9_tb);
            this.gb_weight.Controls.Add(this.w4_tb);
            this.gb_weight.Controls.Add(this.w6_tb);
            this.gb_weight.Location = new System.Drawing.Point(1051, 57);
            this.gb_weight.Name = "gb_weight";
            this.gb_weight.Size = new System.Drawing.Size(60, 295);
            this.gb_weight.TabIndex = 97;
            this.gb_weight.TabStop = false;
            this.gb_weight.Text = "Weights";
            // 
            // toolboxPanel_p
            // 
            this.toolboxPanel_p.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolboxPanel_p.Controls.Add(this.collapse_b);
            this.toolboxPanel_p.Controls.Add(this.gb_viewMode);
            this.toolboxPanel_p.Controls.Add(this.groupBox1);
            this.toolboxPanel_p.Controls.Add(this.cb_autoRotate);
            this.toolboxPanel_p.Controls.Add(this.groupBox2);
            this.toolboxPanel_p.Controls.Add(this.groupBox7);
            this.toolboxPanel_p.Location = new System.Drawing.Point(976, 56);
            this.toolboxPanel_p.Name = "toolboxPanel_p";
            this.toolboxPanel_p.Size = new System.Drawing.Size(163, 584);
            this.toolboxPanel_p.TabIndex = 98;
            this.toolboxPanel_p.Visible = false;
            // 
            // collapse_b
            // 
            this.collapse_b.Font = new System.Drawing.Font("Symbol", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapse_b.Location = new System.Drawing.Point(0, -11);
            this.collapse_b.Name = "collapse_b";
            this.collapse_b.Size = new System.Drawing.Size(163, 28);
            this.collapse_b.TabIndex = 90;
            this.collapse_b.Text = "---------->";
            this.collapse_b.UseVisualStyleBackColor = true;
            this.collapse_b.Click += new System.EventHandler(this.collapse_b_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.expand_b);
            this.panel2.Location = new System.Drawing.Point(1117, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 594);
            this.panel2.TabIndex = 99;
            // 
            // expand_b
            // 
            this.expand_b.Font = new System.Drawing.Font("Symbol", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expand_b.Location = new System.Drawing.Point(-5, -12);
            this.expand_b.Name = "expand_b";
            this.expand_b.Size = new System.Drawing.Size(41, 29);
            this.expand_b.TabIndex = 91;
            this.expand_b.Text = "<---";
            this.expand_b.UseVisualStyleBackColor = true;
            this.expand_b.Click += new System.EventHandler(this.expand_b_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 662);
            this.Controls.Add(this.gb_teeh);
            this.Controls.Add(this.toolboxPanel_p);
            this.Controls.Add(this.gb_weight);
            this.Controls.Add(this.lb_selectedPoints2);
            this.Controls.Add(this.lb_selectedPoints1);
            this.Controls.Add(this.lb_RDCastLabel);
            this.Controls.Add(this.b_clearSelection);
            this.Controls.Add(this.lview_selectedPoints2);
            this.Controls.Add(this.lview_selectedPoints1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.gb_cast2);
            this.Controls.Add(this.gb_cast1);
            this.Controls.Add(this.lb_numVerticesReduced);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.glControlCast);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1155, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrthoAid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.gb_viewMode.ResumeLayout(false);
            this.gb_viewMode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_densityReduceThreshold)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gb_cast1.ResumeLayout(false);
            this.gb_cast1.PerformLayout();
            this.gb_cast2.ResumeLayout(false);
            this.gb_cast2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tab_Maintab.ResumeLayout(false);
            this.tab_Planes.ResumeLayout(false);
            this.tab_Planes.PerformLayout();
            this.tab_Inclination.ResumeLayout(false);
            this.tab_Inclination.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tab_Dislocation.ResumeLayout(false);
            this.tab_Dislocation.PerformLayout();
            this.tab_Distance2Plane.ResumeLayout(false);
            this.tab_Distance2Plane.PerformLayout();
            this.tab_SuperInclin.ResumeLayout(false);
            this.tab_SuperInclin.PerformLayout();
            this.tab_CurveFit.ResumeLayout(false);
            this.tab_CurveFit.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown_order)).EndInit();
            this.gb_teeh.ResumeLayout(false);
            this.gb_weight.ResumeLayout(false);
            this.gb_weight.PerformLayout();
            this.toolboxPanel_p.ResumeLayout(false);
            this.toolboxPanel_p.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControlCast;
        private System.Windows.Forms.GroupBox gb_viewMode;
        private System.Windows.Forms.RadioButton rb_viewMesh;
        private System.Windows.Forms.RadioButton rb_viewWireFrame;
        private System.Windows.Forms.RadioButton rb_viewPoints;
        private System.Windows.Forms.TextBox tx_cameraAngleX;
        private System.Windows.Forms.TextBox tx_cameraAngleY;
        private System.Windows.Forms.TextBox tx_cameraAngleZ;
        private System.Windows.Forms.Label lb_ViewAngleX;
        private System.Windows.Forms.Label lb_ViewAngleY;
        private System.Windows.Forms.Label lb_ViewangleZ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_UpdateCameraRotation;
        private System.Windows.Forms.CheckBox cb_autoRotate;
        private System.Windows.Forms.Timer timer_10mill;
        private System.Windows.Forms.CheckBox cb_showPoints;
        private System.Windows.Forms.Label lb_selectedPoints1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPointCloudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMeshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCalculationFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCalculationFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangulatePointCloudToolStripMenuItem;
        private System.Windows.Forms.Label lb_numVertices1;
        private System.Windows.Forms.Label lb_numFaces1;
        private System.Windows.Forms.Label lb_meshName1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.VScrollBar vScroll_lightIntensity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numUD_densityReduceThreshold;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button b_applyReduceDensity;
        private System.Windows.Forms.Button b_previewReduceDensity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_meshName2;
        private System.Windows.Forms.Label lb_numFaces2;
        private System.Windows.Forms.Label lb_numVertices2;
        private System.Windows.Forms.Button b_cancelReduceDensity;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.GroupBox gb_cast1;
        private System.Windows.Forms.GroupBox gb_cast2;
        private System.Windows.Forms.ToolStripMenuItem saveMeshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meshInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteNoisyPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computeNormalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button b_RotateTranslate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tx_translateX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tx_translateY;
        private System.Windows.Forms.TextBox tx_translateZ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tx_rotateAngleX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tx_rotateAngleY;
        private System.Windows.Forms.TextBox tx_rotateAngleZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbox_selectCast;
        private System.Windows.Forms.CheckBox cb_showCast2;
        private System.Windows.Forms.CheckBox cb_showCast1;
        private System.Windows.Forms.Label lb_selectedPoints2;
        private System.Windows.Forms.ToolStripButton tstrip_Ruler;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tstrip_Hand;
        private System.Windows.Forms.ToolStripButton tstrip_Select;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Button b_superImpose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem loadSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tstrip_lockSelection;
        private System.Windows.Forms.ListView lview_selectedPoints1;
        private System.Windows.Forms.ListView lview_selectedPoints2;
        private System.Windows.Forms.ColumnHeader Selected_Points1;
        private System.Windows.Forms.ColumnHeader Selected_Points2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem showCast1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showCast2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverseCastShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Button b_clearSelection;
        private System.Windows.Forms.RadioButton rb_BBPuser;
        private System.Windows.Forms.RadioButton rb_BBCmiddle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabControl tab_Maintab;
        private System.Windows.Forms.TabPage tab_Inclination;
        private System.Windows.Forms.Label v1t17;
        private System.Windows.Forms.Label v1t18;
        private System.Windows.Forms.Label v1t25;
        private System.Windows.Forms.Label v1t26;
        private System.Windows.Forms.Label v1t19;
        private System.Windows.Forms.Label v1t27;
        private System.Windows.Forms.Label v1t20;
        private System.Windows.Forms.Label v1t28;
        private System.Windows.Forms.Label v1t21;
        private System.Windows.Forms.Label v1t29;
        private System.Windows.Forms.Label v1t22;
        private System.Windows.Forms.Label v1t30;
        private System.Windows.Forms.Label v1t32;
        private System.Windows.Forms.Label v1t23;
        private System.Windows.Forms.Label v1t31;
        private System.Windows.Forms.Label v1t24;
        private System.Windows.Forms.Label v1t16;
        private System.Windows.Forms.Label v1t15;
        private System.Windows.Forms.Label v1t8;
        private System.Windows.Forms.Label v1t1;
        private System.Windows.Forms.Label v1t7;
        private System.Windows.Forms.Label v1t9;
        private System.Windows.Forms.Label v1t14;
        private System.Windows.Forms.Label v1t2;
        private System.Windows.Forms.Label v1t6;
        private System.Windows.Forms.Label v1t10;
        private System.Windows.Forms.Label v1t13;
        private System.Windows.Forms.Label v1t3;
        private System.Windows.Forms.Label v1t5;
        private System.Windows.Forms.Label v1t12;
        private System.Windows.Forms.Label v1t4;
        private System.Windows.Forms.Label v1t11;
        private System.Windows.Forms.TabPage tab_Dislocation;
        private System.Windows.Forms.Label v2t16;
        private System.Windows.Forms.Label v2t15;
        private System.Windows.Forms.Label v2t8;
        private System.Windows.Forms.Label v2t7;
        private System.Windows.Forms.Label v2t14;
        private System.Windows.Forms.Label v2t1;
        private System.Windows.Forms.Label v2t17;
        private System.Windows.Forms.Label v2t18;
        private System.Windows.Forms.Label v2t25;
        private System.Windows.Forms.Label v2t6;
        private System.Windows.Forms.Label v2t9;
        private System.Windows.Forms.Label v2t26;
        private System.Windows.Forms.Label v2t13;
        private System.Windows.Forms.Label v2t19;
        private System.Windows.Forms.Label v2t2;
        private System.Windows.Forms.Label v2t27;
        private System.Windows.Forms.Label v2t20;
        private System.Windows.Forms.Label v2t5;
        private System.Windows.Forms.Label v2t12;
        private System.Windows.Forms.Label v2t28;
        private System.Windows.Forms.Label v2t21;
        private System.Windows.Forms.Label v2t10;
        private System.Windows.Forms.Label v2t4;
        private System.Windows.Forms.Label v2t29;
        private System.Windows.Forms.Label v2t3;
        private System.Windows.Forms.Label v2t22;
        private System.Windows.Forms.Label v2t11;
        private System.Windows.Forms.Label v2t32;
        private System.Windows.Forms.Label v2t24;
        private System.Windows.Forms.Label v2t30;
        private System.Windows.Forms.Label v2t23;
        private System.Windows.Forms.Label v2t31;
        private System.Windows.Forms.TabPage tab_Distance2Plane;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label v4t17;
        private System.Windows.Forms.Label v4t18;
        private System.Windows.Forms.Label v4t25;
        private System.Windows.Forms.Label v4t26;
        private System.Windows.Forms.Label v4t19;
        private System.Windows.Forms.Label v4t27;
        private System.Windows.Forms.Label v4t20;
        private System.Windows.Forms.Label v4t28;
        private System.Windows.Forms.Label v4t21;
        private System.Windows.Forms.Label v4t29;
        private System.Windows.Forms.Label v4t22;
        private System.Windows.Forms.Label v4t30;
        private System.Windows.Forms.Label v4t32;
        private System.Windows.Forms.Label v4t23;
        private System.Windows.Forms.Label v4t31;
        private System.Windows.Forms.Label v4t24;
        private System.Windows.Forms.Label v4t16;
        private System.Windows.Forms.Label v4t15;
        private System.Windows.Forms.Label v4t8;
        private System.Windows.Forms.Label v4t1;
        private System.Windows.Forms.Label v4t7;
        private System.Windows.Forms.Label v4t9;
        private System.Windows.Forms.Label v4t14;
        private System.Windows.Forms.Label v4t2;
        private System.Windows.Forms.Label v4t6;
        private System.Windows.Forms.Label v4t10;
        private System.Windows.Forms.Label v4t13;
        private System.Windows.Forms.Label v4t3;
        private System.Windows.Forms.Label v4t5;
        private System.Windows.Forms.Label v4t12;
        private System.Windows.Forms.Label v4t4;
        private System.Windows.Forms.Label v4t11;
        private System.Windows.Forms.Label v3t17;
        private System.Windows.Forms.Label v3t18;
        private System.Windows.Forms.Label v3t25;
        private System.Windows.Forms.Label v3t26;
        private System.Windows.Forms.Label v3t19;
        private System.Windows.Forms.Label v3t27;
        private System.Windows.Forms.Label v3t20;
        private System.Windows.Forms.Label v3t28;
        private System.Windows.Forms.Label v3t21;
        private System.Windows.Forms.Label v3t29;
        private System.Windows.Forms.Label v3t22;
        private System.Windows.Forms.Label v3t30;
        private System.Windows.Forms.Label v3t32;
        private System.Windows.Forms.Label v3t23;
        private System.Windows.Forms.Label v3t31;
        private System.Windows.Forms.Label v3t24;
        private System.Windows.Forms.Label v3t16;
        private System.Windows.Forms.Label v3t15;
        private System.Windows.Forms.Label v3t8;
        private System.Windows.Forms.Label v3t1;
        private System.Windows.Forms.Label v3t7;
        private System.Windows.Forms.Label v3t9;
        private System.Windows.Forms.Label v3t14;
        private System.Windows.Forms.Label v3t2;
        private System.Windows.Forms.Label v3t6;
        private System.Windows.Forms.Label v3t10;
        private System.Windows.Forms.Label v3t13;
        private System.Windows.Forms.Label v3t3;
        private System.Windows.Forms.Label v3t5;
        private System.Windows.Forms.Label v3t12;
        private System.Windows.Forms.Label v3t4;
        private System.Windows.Forms.Label v3t11;
        private System.Windows.Forms.CheckBox cb_saggitalPlane1;
        private System.Windows.Forms.CheckBox cb_occlusalPlane1;
        private System.Windows.Forms.Label lb_saggitalPlane;
        private System.Windows.Forms.Label lb_occlusalPlane;
        private System.Windows.Forms.Button b_Calculate;
        private System.Windows.Forms.Button b_clearCalculations;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cb_t16;
        private System.Windows.Forms.CheckBox cb_t15;
        private System.Windows.Forms.CheckBox cb_t14;
        private System.Windows.Forms.CheckBox cb_t13;
        private System.Windows.Forms.CheckBox cb_t12;
        private System.Windows.Forms.CheckBox cb_t11;
        private System.Windows.Forms.CheckBox cb_t10;
        private System.Windows.Forms.CheckBox cb_t9;
        private System.Windows.Forms.CheckBox cb_t8;
        private System.Windows.Forms.CheckBox cb_t7;
        private System.Windows.Forms.CheckBox cb_t6;
        private System.Windows.Forms.CheckBox cb_t5;
        private System.Windows.Forms.CheckBox cb_t4;
        private System.Windows.Forms.CheckBox cb_t3;
        private System.Windows.Forms.CheckBox cb_t2;
        private System.Windows.Forms.CheckBox cb_t1;
        private System.Windows.Forms.CheckBox cb_t17;
        private System.Windows.Forms.CheckBox cb_t18;
        private System.Windows.Forms.CheckBox cb_t19;
        private System.Windows.Forms.CheckBox cb_t20;
        private System.Windows.Forms.CheckBox cb_t21;
        private System.Windows.Forms.CheckBox cb_t22;
        private System.Windows.Forms.CheckBox cb_t23;
        private System.Windows.Forms.CheckBox cb_t24;
        private System.Windows.Forms.CheckBox cb_t25;
        private System.Windows.Forms.CheckBox cb_t26;
        private System.Windows.Forms.CheckBox cb_t27;
        private System.Windows.Forms.CheckBox cb_t32;
        private System.Windows.Forms.CheckBox cb_t31;
        private System.Windows.Forms.CheckBox cb_t30;
        private System.Windows.Forms.CheckBox cb_t28;
        private System.Windows.Forms.CheckBox cb_t29;
        private System.Windows.Forms.GroupBox gb_teeh;
        private System.Windows.Forms.Label t32;
        private System.Windows.Forms.Label t31;
        private System.Windows.Forms.Label t29;
        private System.Windows.Forms.Label t9;
        private System.Windows.Forms.Label t8;
        private System.Windows.Forms.Label t10;
        private System.Windows.Forms.Label t7;
        private System.Windows.Forms.Label t11;
        private System.Windows.Forms.Label t6;
        private System.Windows.Forms.Label t21;
        private System.Windows.Forms.Label t12;
        private System.Windows.Forms.Label t5;
        private System.Windows.Forms.Label t20;
        private System.Windows.Forms.Label t13;
        private System.Windows.Forms.Label t4;
        private System.Windows.Forms.Label t19;
        private System.Windows.Forms.Label t14;
        private System.Windows.Forms.Label t3;
        private System.Windows.Forms.Label t18;
        private System.Windows.Forms.Label t15;
        private System.Windows.Forms.Label t2;
        private System.Windows.Forms.Label t17;
        private System.Windows.Forms.Label t16;
        private System.Windows.Forms.Label t1;
        private System.Windows.Forms.Label t24;
        private System.Windows.Forms.Label t25;
        private System.Windows.Forms.Label t23;
        private System.Windows.Forms.Label t26;
        private System.Windows.Forms.Label t22;
        private System.Windows.Forms.Label t27;
        private System.Windows.Forms.Label t28;
        private System.Windows.Forms.Label t30;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tab_SuperInclin;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label v7t16;
        private System.Windows.Forms.Label v7t15;
        private System.Windows.Forms.Label v7t8;
        private System.Windows.Forms.Label v7t1;
        private System.Windows.Forms.Label v7t7;
        private System.Windows.Forms.Label v7t9;
        private System.Windows.Forms.Label v7t14;
        private System.Windows.Forms.Label v7t2;
        private System.Windows.Forms.Label v7t6;
        private System.Windows.Forms.Label v7t10;
        private System.Windows.Forms.Label v7t13;
        private System.Windows.Forms.Label v7t3;
        private System.Windows.Forms.Label v7t5;
        private System.Windows.Forms.Label v7t12;
        private System.Windows.Forms.Label v7t4;
        private System.Windows.Forms.Label v7t11;
        private System.Windows.Forms.Label v6t16;
        private System.Windows.Forms.Label v6t15;
        private System.Windows.Forms.Label v6t8;
        private System.Windows.Forms.Label v6t1;
        private System.Windows.Forms.Label v6t7;
        private System.Windows.Forms.Label v6t9;
        private System.Windows.Forms.Label v6t14;
        private System.Windows.Forms.Label v6t2;
        private System.Windows.Forms.Label v6t6;
        private System.Windows.Forms.Label v6t10;
        private System.Windows.Forms.Label v6t13;
        private System.Windows.Forms.Label v6t3;
        private System.Windows.Forms.Label v6t5;
        private System.Windows.Forms.Label v6t12;
        private System.Windows.Forms.Label v6t4;
        private System.Windows.Forms.Label v6t11;
        private System.Windows.Forms.Label v5t16;
        private System.Windows.Forms.Label v5t15;
        private System.Windows.Forms.Label v5t8;
        private System.Windows.Forms.Label v5t1;
        private System.Windows.Forms.Label v5t7;
        private System.Windows.Forms.Label v5t9;
        private System.Windows.Forms.Label v5t14;
        private System.Windows.Forms.Label v5t2;
        private System.Windows.Forms.Label v5t6;
        private System.Windows.Forms.Label v5t10;
        private System.Windows.Forms.Label v5t13;
        private System.Windows.Forms.Label v5t3;
        private System.Windows.Forms.Label v5t5;
        private System.Windows.Forms.Label v5t12;
        private System.Windows.Forms.Label v5t4;
        private System.Windows.Forms.Label v5t11;
        private System.Windows.Forms.Label v7t17;
        private System.Windows.Forms.Label v7t18;
        private System.Windows.Forms.Label v7t25;
        private System.Windows.Forms.Label v7t32;
        private System.Windows.Forms.Label v7t26;
        private System.Windows.Forms.Label v7t24;
        private System.Windows.Forms.Label v7t19;
        private System.Windows.Forms.Label v7t31;
        private System.Windows.Forms.Label v7t27;
        private System.Windows.Forms.Label v7t23;
        private System.Windows.Forms.Label v7t20;
        private System.Windows.Forms.Label v7t30;
        private System.Windows.Forms.Label v7t28;
        private System.Windows.Forms.Label v7t21;
        private System.Windows.Forms.Label v7t29;
        private System.Windows.Forms.Label v7t22;
        private System.Windows.Forms.Label v6t17;
        private System.Windows.Forms.Label v6t18;
        private System.Windows.Forms.Label v6t25;
        private System.Windows.Forms.Label v6t32;
        private System.Windows.Forms.Label v6t26;
        private System.Windows.Forms.Label v6t24;
        private System.Windows.Forms.Label v6t19;
        private System.Windows.Forms.Label v6t31;
        private System.Windows.Forms.Label v6t27;
        private System.Windows.Forms.Label v6t23;
        private System.Windows.Forms.Label v6t20;
        private System.Windows.Forms.Label v6t30;
        private System.Windows.Forms.Label v6t28;
        private System.Windows.Forms.Label v6t21;
        private System.Windows.Forms.Label v6t29;
        private System.Windows.Forms.Label v6t22;
        private System.Windows.Forms.Label v5t17;
        private System.Windows.Forms.Label v5t18;
        private System.Windows.Forms.Label v5t25;
        private System.Windows.Forms.Label v5t32;
        private System.Windows.Forms.Label v5t26;
        private System.Windows.Forms.Label v5t24;
        private System.Windows.Forms.Label v5t19;
        private System.Windows.Forms.Label v5t31;
        private System.Windows.Forms.Label v5t27;
        private System.Windows.Forms.Label v5t23;
        private System.Windows.Forms.Label v5t20;
        private System.Windows.Forms.Label v5t30;
        private System.Windows.Forms.Label v5t28;
        private System.Windows.Forms.Label v5t21;
        private System.Windows.Forms.Label v5t29;
        private System.Windows.Forms.Label v5t22;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.CheckBox cb_occlusalPlane2;
        private System.Windows.Forms.CheckBox cb_saggitalPlane2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutOrthoAidToolStripMenuItem;
        private System.Windows.Forms.Label lb_occlusalPlanesAngle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lb_numVerticesReduced;
        private System.Windows.Forms.Label lb_RDCastLabel;
        private System.Windows.Forms.TextBox w1_tb;
        private System.Windows.Forms.TextBox w2_tb;
        private System.Windows.Forms.TextBox w3_tb;
        private System.Windows.Forms.TextBox w4_tb;
        private System.Windows.Forms.TextBox w5_tb;
        private System.Windows.Forms.TextBox w6_tb;
        private System.Windows.Forms.TextBox w7_tb;
        private System.Windows.Forms.TextBox w8_tb;
        private System.Windows.Forms.TextBox w9_tb;
        private System.Windows.Forms.TextBox w10_tb;
        private System.Windows.Forms.TextBox w11_tb;
        private System.Windows.Forms.TextBox w12_tb;
        private System.Windows.Forms.GroupBox gb_weight;
        private System.Windows.Forms.Panel toolboxPanel_p;
        private System.Windows.Forms.Button collapse_b;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button expand_b;
        private System.Windows.Forms.TabPage tab_CurveFit;
        private System.Windows.Forms.Panel pl_curveFit;
        private System.Windows.Forms.NumericUpDown nUpDown_order;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_fitPoly;
        private System.Windows.Forms.RadioButton rb_fitNoroozi;
        private System.Windows.Forms.Label lb_curvefit_rmse_z;
        private System.Windows.Forms.Label lb_curvefit_rmse_xy;
        private System.Windows.Forms.CheckBox cb_curvePlane2;
        private System.Windows.Forms.CheckBox cb_curvePlane1;
        private System.Windows.Forms.Button b_matchingWire;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton rb_maxilla;
        private System.Windows.Forms.RadioButton rb_mandible;
        private System.Windows.Forms.Panel pl_wireMatch;
        private System.Windows.Forms.Label lb_curve2occlusalPlane;
        private System.Windows.Forms.TabPage tab_Planes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView lv_wires;
    }
}

