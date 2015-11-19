using System.Windows.Forms;

namespace OrthoAid_3DSimulator
{
    partial class MeshInfoForm : PopUpForm
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
            this.gb_cast1 = new System.Windows.Forms.GroupBox();
            this.lb_meshName1 = new System.Windows.Forms.Label();
            this.lb_numVertices1 = new System.Windows.Forms.Label();
            this.lb_numFaces1 = new System.Windows.Forms.Label();
            this.lb_range1 = new System.Windows.Forms.Label();
            this.lb_mean1 = new System.Windows.Forms.Label();
            this.lb_averageVertexDistance1 = new System.Windows.Forms.Label();
            this.gb_cast2 = new System.Windows.Forms.GroupBox();
            this.lb_averageVertexDistance2 = new System.Windows.Forms.Label();
            this.lb_mean2 = new System.Windows.Forms.Label();
            this.lb_range2 = new System.Windows.Forms.Label();
            this.lb_meshName2 = new System.Windows.Forms.Label();
            this.lb_numVertices2 = new System.Windows.Forms.Label();
            this.lb_numFaces2 = new System.Windows.Forms.Label();
            this.b_OK = new System.Windows.Forms.Button();
            this.gb_cast1.SuspendLayout();
            this.gb_cast2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_cast1
            // 
            this.gb_cast1.BackColor = System.Drawing.Color.Transparent;
            this.gb_cast1.Controls.Add(this.lb_averageVertexDistance1);
            this.gb_cast1.Controls.Add(this.lb_mean1);
            this.gb_cast1.Controls.Add(this.lb_range1);
            this.gb_cast1.Controls.Add(this.lb_meshName1);
            this.gb_cast1.Controls.Add(this.lb_numVertices1);
            this.gb_cast1.Controls.Add(this.lb_numFaces1);
            this.gb_cast1.Location = new System.Drawing.Point(12, 3);
            this.gb_cast1.Name = "gb_cast1";
            this.gb_cast1.Size = new System.Drawing.Size(519, 114);
            this.gb_cast1.TabIndex = 87;
            this.gb_cast1.TabStop = false;
            this.gb_cast1.Text = "Cast1";
            // 
            // lb_meshName1
            // 
            this.lb_meshName1.AutoSize = true;
            this.lb_meshName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_meshName1.Location = new System.Drawing.Point(0, 18);
            this.lb_meshName1.Name = "lb_meshName1";
            this.lb_meshName1.Size = new System.Drawing.Size(137, 13);
            this.lb_meshName1.TabIndex = 71;
            this.lb_meshName1.Text = "Mesh: No Mesh loaded";
            // 
            // lb_numVertices1
            // 
            this.lb_numVertices1.AutoSize = true;
            this.lb_numVertices1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numVertices1.Location = new System.Drawing.Point(-1, 33);
            this.lb_numVertices1.Name = "lb_numVertices1";
            this.lb_numVertices1.Size = new System.Drawing.Size(68, 13);
            this.lb_numVertices1.TabIndex = 69;
            this.lb_numVertices1.Text = "Vertices: 0";
            // 
            // lb_numFaces1
            // 
            this.lb_numFaces1.AutoSize = true;
            this.lb_numFaces1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numFaces1.Location = new System.Drawing.Point(0, 48);
            this.lb_numFaces1.Name = "lb_numFaces1";
            this.lb_numFaces1.Size = new System.Drawing.Size(56, 13);
            this.lb_numFaces1.TabIndex = 70;
            this.lb_numFaces1.Text = "Faces: 0";
            // 
            // lb_range1
            // 
            this.lb_range1.AutoSize = true;
            this.lb_range1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_range1.Location = new System.Drawing.Point(0, 63);
            this.lb_range1.Name = "lb_range1";
            this.lb_range1.Size = new System.Drawing.Size(162, 13);
            this.lb_range1.TabIndex = 72;
            this.lb_range1.Text = "Range: X(0-0) Y(0-0) Z(0-0)";
            // 
            // lb_mean1
            // 
            this.lb_mean1.AutoSize = true;
            this.lb_mean1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mean1.Location = new System.Drawing.Point(0, 78);
            this.lb_mean1.Name = "lb_mean1";
            this.lb_mean1.Size = new System.Drawing.Size(91, 13);
            this.lb_mean1.TabIndex = 73;
            this.lb_mean1.Text = "Mean: 0 , 0 , 0";
            // 
            // lb_averageVertexDistance1
            // 
            this.lb_averageVertexDistance1.AutoSize = true;
            this.lb_averageVertexDistance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_averageVertexDistance1.Location = new System.Drawing.Point(0, 93);
            this.lb_averageVertexDistance1.Name = "lb_averageVertexDistance1";
            this.lb_averageVertexDistance1.Size = new System.Drawing.Size(163, 13);
            this.lb_averageVertexDistance1.TabIndex = 74;
            this.lb_averageVertexDistance1.Text = "Average Vertex Distance: 0";
            // 
            // gb_cast2
            // 
            this.gb_cast2.BackColor = System.Drawing.Color.Transparent;
            this.gb_cast2.Controls.Add(this.lb_averageVertexDistance2);
            this.gb_cast2.Controls.Add(this.lb_mean2);
            this.gb_cast2.Controls.Add(this.lb_range2);
            this.gb_cast2.Controls.Add(this.lb_meshName2);
            this.gb_cast2.Controls.Add(this.lb_numVertices2);
            this.gb_cast2.Controls.Add(this.lb_numFaces2);
            this.gb_cast2.Location = new System.Drawing.Point(14, 123);
            this.gb_cast2.Name = "gb_cast2";
            this.gb_cast2.Size = new System.Drawing.Size(519, 114);
            this.gb_cast2.TabIndex = 88;
            this.gb_cast2.TabStop = false;
            this.gb_cast2.Text = "Cast2";
            // 
            // lb_averageVertexDistance2
            // 
            this.lb_averageVertexDistance2.AutoSize = true;
            this.lb_averageVertexDistance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_averageVertexDistance2.Location = new System.Drawing.Point(0, 93);
            this.lb_averageVertexDistance2.Name = "lb_averageVertexDistance2";
            this.lb_averageVertexDistance2.Size = new System.Drawing.Size(163, 13);
            this.lb_averageVertexDistance2.TabIndex = 74;
            this.lb_averageVertexDistance2.Text = "Average Vertex Distance: 0";
            // 
            // lb_mean2
            // 
            this.lb_mean2.AutoSize = true;
            this.lb_mean2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mean2.Location = new System.Drawing.Point(0, 78);
            this.lb_mean2.Name = "lb_mean2";
            this.lb_mean2.Size = new System.Drawing.Size(91, 13);
            this.lb_mean2.TabIndex = 73;
            this.lb_mean2.Text = "Mean: 0 , 0 , 0";
            // 
            // lb_range2
            // 
            this.lb_range2.AutoSize = true;
            this.lb_range2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_range2.Location = new System.Drawing.Point(0, 63);
            this.lb_range2.Name = "lb_range2";
            this.lb_range2.Size = new System.Drawing.Size(162, 13);
            this.lb_range2.TabIndex = 72;
            this.lb_range2.Text = "Range: X(0-0) Y(0-0) Z(0-0)";
            // 
            // lb_meshName2
            // 
            this.lb_meshName2.AutoSize = true;
            this.lb_meshName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_meshName2.Location = new System.Drawing.Point(0, 18);
            this.lb_meshName2.Name = "lb_meshName2";
            this.lb_meshName2.Size = new System.Drawing.Size(137, 13);
            this.lb_meshName2.TabIndex = 71;
            this.lb_meshName2.Text = "Mesh: No Mesh loaded";
            // 
            // lb_numVertices2
            // 
            this.lb_numVertices2.AutoSize = true;
            this.lb_numVertices2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numVertices2.Location = new System.Drawing.Point(-1, 33);
            this.lb_numVertices2.Name = "lb_numVertices2";
            this.lb_numVertices2.Size = new System.Drawing.Size(68, 13);
            this.lb_numVertices2.TabIndex = 69;
            this.lb_numVertices2.Text = "Vertices: 0";
            // 
            // lb_numFaces2
            // 
            this.lb_numFaces2.AutoSize = true;
            this.lb_numFaces2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numFaces2.Location = new System.Drawing.Point(0, 48);
            this.lb_numFaces2.Name = "lb_numFaces2";
            this.lb_numFaces2.Size = new System.Drawing.Size(56, 13);
            this.lb_numFaces2.TabIndex = 70;
            this.lb_numFaces2.Text = "Faces: 0";
            // 
            // b_OK
            // 
            this.b_OK.Font = new System.Drawing.Font("a_CalyxOtl", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_OK.Location = new System.Drawing.Point(536, 12);
            this.b_OK.Name = "b_OK";
            this.b_OK.Size = new System.Drawing.Size(53, 225);
            this.b_OK.TabIndex = 89;
            this.b_OK.Text = "OK";
            this.b_OK.UseVisualStyleBackColor = true;
            this.b_OK.Click += new System.EventHandler(this.b_OK_Click);
            // 
            // MeshInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 244);            
            this.Controls.Add(this.b_OK);
            this.Controls.Add(this.gb_cast2);
            this.Controls.Add(this.gb_cast1);
            this.Name = "MeshInfo";            
            this.Text = "Mesh Information";                        
            this.gb_cast1.ResumeLayout(false);
            this.gb_cast1.PerformLayout();
            this.gb_cast2.ResumeLayout(false);
            this.gb_cast2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_cast1;
        private System.Windows.Forms.Label lb_meshName1;
        private System.Windows.Forms.Label lb_numVertices1;
        private System.Windows.Forms.Label lb_numFaces1;
        private System.Windows.Forms.Label lb_averageVertexDistance1;
        private System.Windows.Forms.Label lb_mean1;
        private System.Windows.Forms.Label lb_range1;
        private System.Windows.Forms.GroupBox gb_cast2;
        private System.Windows.Forms.Label lb_averageVertexDistance2;
        private System.Windows.Forms.Label lb_mean2;
        private System.Windows.Forms.Label lb_range2;
        private System.Windows.Forms.Label lb_meshName2;
        private System.Windows.Forms.Label lb_numVertices2;
        private System.Windows.Forms.Label lb_numFaces2;
        private System.Windows.Forms.Button b_OK;

    }
}