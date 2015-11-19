using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;

namespace LaserProjectOpenTK
{
    public partial class MainForm 
    {
        float angleX = 45.0f, angleY = 45.0f, angleZ = 45.0f;
        Vector3 eyeOffset;
        Vector3 targetOffset;
        float boxRadius = 1.5f;
        float rotateValue = 10;
        const float slowRotateValue = 1;
        const float fastRoateValue = 10;
        float zoomValue = 5;
        const float slowZoomValue = 0.5f;
        const float fastZoomValue = 5;

        bool mouseDown = false;
        bool controlKeyDown = false, shiftKeyDown = false;
        int MouseX, MouseY;

        bool autoRotateFlag = false;

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard_Input(e);
        }

        private void glControlCast_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard_Input(e);
        }

        private void glControlCast_KeyUp(object sender, KeyEventArgs e)
        {
            Keyboard_Input(e);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            Keyboard_Input(e);
        }

        private void glControlCast_MouseDown(object sender, MouseEventArgs e)
        {
            //if (editMode == EditMode.Rotate)
                mouseDown = true;
            //else if (editMode == EditMode.Select)
            //{

            //}
            
        }
        
        private void glControlCast_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown)
            {
                MouseX = e.X;
                MouseY = e.Y;
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (editMode == EditMode.Rotate || (editMode == EditMode.Select && shiftKeyDown))
                {
                    angleX += (e.X - MouseX);
                    angleY -= (e.Y - MouseY);                 
                }
                //glControlCast.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                //eyeOffset.Z += ((e.X - prevMouseX) / 10.0f) * boxRadius;
                targetOffset.X += ((e.X - MouseX) / 10.0f) * boxRadius;
                targetOffset.Y += ((e.Y - MouseY) / 10.0f) * boxRadius;
                eyeOffset.X += ((e.X - MouseX) / 10.0f) * boxRadius;
                eyeOffset.Y += ((e.Y - MouseY) / 10.0f) * boxRadius;
                //glControlCast.Invalidate();
            }            
            else if (e.Button == MouseButtons.Middle)
            {
                //eyeOffset.X += (float)((boxRadius / 100.0) * (e.X - prevMouseX));
                //eyeOffset.Y -= (float)((boxRadius / 100.0) * (e.Y - prevMouseY));
                //glControlCast.Invalidate();

                angleZ += (e.X - MouseX);
                angleZ += (e.Y - MouseY);
                //glControlCast.Invalidate();
            }
            
            if (e.Delta != 0)
            {                
                //eyeOffset.Y -= e.Delta;
                //glControlCast.Invalidate();
            }

            MouseX = e.X;
            MouseY = e.Y;
            //UpdateUI();
        }

        private void glControlCast_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;            
        }

        private void glControlCast_SizeChanged(object sender, EventArgs e)
        {
            SetCamera();
        }

        private void SetCamera()
        {            
            GL.Viewport(ClientRectangle);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                glControlCast.Width / (float)glControlCast.Height, 0.1f, 1000.0f);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            Matrix4 lookat = Matrix4.LookAt(eyeOffset.X, eyeOffset.Y, eyeOffset.Z, 
                targetOffset.X, targetOffset.Y, targetOffset.Z, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Rotate(angleY, 1.0f, 0, 0);
            GL.Rotate(angleX, 0, 1.0f, 0);
            GL.Rotate(angleZ, 0, 0, 1.0f);
        }

        private void glControlCast_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (editMode == EditMode.Select && !shiftKeyDown)
                {
                    MarkAndInsertSelectedVertex(pointedVertexNumber);
                    InsertSelectedTrueVertex(pointedTrueVertexNumber);
                }
            }
        }

        private void Keyboard_Input(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift)
            {
                rotateValue = slowRotateValue;
                zoomValue = slowZoomValue;

                shiftKeyDown = true;
            }
            else
            {
                rotateValue = fastRoateValue;
                zoomValue = fastZoomValue;

                shiftKeyDown = false;
            }

            if (e.Modifiers == Keys.Control)
            {
                controlKeyDown = true;
            }
            else
            {
                controlKeyDown = false;
            }
            
            if (e.KeyCode == Keys.PageUp)
            {
                eyeOffset.Z -= zoomValue;
                UpdateUI();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                eyeOffset.Z += zoomValue;
                UpdateUI();
            }
            else if (e.KeyCode == Keys.A)
            {
                angleX += rotateValue;
                angleX %= 360;
                UpdateUI();
            }
            else if (e.KeyCode == Keys.D)
            {
                angleX -= rotateValue;  
                angleX %= 360;
                UpdateUI();
            }
            else if (e.KeyCode == Keys.S)
            {
                angleY -= rotateValue;
                angleY %= 360;
                UpdateUI();
            }
            else if (e.KeyCode == Keys.W)
            {
                angleY += rotateValue;
                angleY %= 360;
                UpdateUI();
            }
            else if (e.KeyCode == Keys.Q)
            {
                angleZ += rotateValue;
                angleZ %= 360;
                UpdateUI();
            }
            else if (e.KeyCode == Keys.E)
            {
                angleZ -= rotateValue;
                angleZ %= 360;
                UpdateUI();
            }

            else if (e.KeyCode == Keys.Escape)
                this.Close();
            //else if (e.KeyCode == Keys.ShiftKey)
            //{
            //    controlKeyDown = true;
            //}
            //else if (e.KeyCode == Keys.ControlKey)
            //{
            //    shiftKeyDown = true;
            //}
                        
            //glControlCast.Invalidate();
        }
    }
}
