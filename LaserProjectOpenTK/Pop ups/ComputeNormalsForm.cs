using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthoAid_3DSimulator
{
    public partial class ComputeNormalsForm : PopUpForm
    {
        MainForm f;
        Common.Vbo vbo;
        public string result { get; set; }

        public ComputeNormalsForm(MainForm f, Common.Vbo vbo)
        {
            InitializeComponent();
            this.f = f;
            this.vbo = vbo;

            foreach (Control control in this.Controls)
            {
                control.KeyDown += ComputeNormalsForm_KeyDown;                
            }
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            result = "cancel";
            this.Close();
        }

        private void b_computeNormals_Click(object sender, EventArgs e)
        {
            int k = (int)numericUpDown1.Value;
            string s;
            if ((s=f.ComputeNormals(ref vbo, k, cb_flipNormals.Checked))!="error")
                result = s;
            else
                result = "error";

            Close();            

        }

        private void ComputeNormalsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                b_computeNormals_Click(this, new EventArgs());
            else if (e.KeyCode == Keys.Escape)
            {
                result = "cancel";
                Close();
            }
        }


    }
}
