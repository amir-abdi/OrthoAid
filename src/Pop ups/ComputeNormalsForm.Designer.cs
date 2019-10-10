using System.Windows.Forms;

namespace OrthoAid
{
    partial class ComputeNormalsForm : PopUpForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.b_computeNormals = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.cb_flipNormals = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Neighbours:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(129, 23);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // b_computeNormals
            // 
            this.b_computeNormals.Location = new System.Drawing.Point(15, 81);
            this.b_computeNormals.Name = "b_computeNormals";
            this.b_computeNormals.Size = new System.Drawing.Size(75, 23);
            this.b_computeNormals.TabIndex = 3;
            this.b_computeNormals.Text = "Compute Normals";
            this.b_computeNormals.UseVisualStyleBackColor = true;
            this.b_computeNormals.Click += new System.EventHandler(this.b_computeNormals_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(96, 81);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 4;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // cb_flipNormals
            // 
            this.cb_flipNormals.AutoSize = true;
            this.cb_flipNormals.Location = new System.Drawing.Point(16, 46);
            this.cb_flipNormals.Name = "cb_flipNormals";
            this.cb_flipNormals.Size = new System.Drawing.Size(83, 17);
            this.cb_flipNormals.TabIndex = 2;
            this.cb_flipNormals.Text = "Flip Normals";
            this.cb_flipNormals.UseVisualStyleBackColor = true;
            // 
            // ComputeNormalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 108);
            this.Controls.Add(this.cb_flipNormals);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_computeNormals);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Name = "ComputeNormalsForm";
            this.Text = "Compute Normals";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComputeNormalsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button b_computeNormals;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.CheckBox cb_flipNormals;
    }
}