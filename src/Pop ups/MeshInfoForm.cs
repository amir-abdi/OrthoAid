using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrthoAid
{
    public partial class MeshInfoForm : PopUpForm
    {

        public MeshInfoForm(Common.VerticesStats cast1, Common.VerticesStats cast2)
        {
            InitializeComponent();

            if (cast1.name != null && cast1.name.ToLower() != "no mesh loaded")
            {
                lb_meshName1.Text = "Mesh: " + cast1.name;
                lb_numVertices1.Text = "Vertices: " + cast1.numVertices.ToString();
                lb_numFaces1.Text = "Faces: " + cast1.numFaces.ToString();
                lb_range1.Text = "Range: " +
                    "X(" + cast1.MinX.ToString("f2") + "  :  " + cast1.MaxX.ToString("f2") + ") " +
                    "Y(" + cast1.MinY.ToString("f2") + "  :  " + cast1.MaxY.ToString("f2") + ") " +
                    "Z(" + cast1.MinZ.ToString("f2") + "  :  " + cast1.MaxZ.ToString("f2") + ")";
                lb_mean1.Text = "Center of Mass: " +
                    cast1.Mean.X.ToString("f9") + " , " +
                    cast1.Mean.Y.ToString("f9") + " , " +
                    cast1.Mean.Z.ToString("f9");
                lb_averageVertexDistance1.Text = "Average Vertex Distance: " + cast1.averageVertexDistance.ToString("f2");

            }

            if (cast2.name != null && cast2.name.ToLower() != "no mesh loaded")
            {
                lb_meshName2.Text = "Mesh: " + cast2.name;
                lb_numVertices2.Text = "Vertices: " + cast2.numVertices.ToString();
                lb_numFaces2.Text = "Faces: " + cast2.numFaces.ToString();
                lb_range2.Text = "Range: " +
                    "X(" + cast2.MinX.ToString("f2") + "  :  " + cast2.MaxX.ToString("f2") + ") " +
                    "Y(" + cast2.MinY.ToString("f2") + "  :  " + cast2.MaxY.ToString("f2") + ") " +
                    "Z(" + cast2.MinZ.ToString("f2") + "  :  " + cast2.MaxZ.ToString("f2") + ")";
                lb_mean2.Text = "Center of Mass: " +
                    cast2.Mean.X.ToString("f9") + " , " +
                    cast2.Mean.Y.ToString("f9") + " , " +
                    cast2.Mean.Z.ToString("f9");
                lb_averageVertexDistance2.Text = "Average Vertex Distance: " + cast2.averageVertexDistance.ToString("f2");

            }
        }

        private void b_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
