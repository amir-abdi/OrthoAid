using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;

namespace OrthoAid
{
    public partial class MainForm
    {
        float boxRadius = 1.5f;
        bool mouseDown = false;
        bool controlKeyDown = false, shiftKeyDown = false, lockSelection = false;
        int MouseX, MouseY;

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == this)
                Keyboard_Input(e);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
                Keyboard_Input(e);
        }

        private void glControlCast_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Left &&
                config.editMode == Common.EditMode.Ruler && !shiftKeyDown)
            {
                MarkAndInsertSelectedVertex(GetSelectedVBO(), pointedVertexNumber);
                Ruler_PointAIndex = pointedVertexNumber;
            }
            UpdateUI();
        }

        private void glControlCast_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown)
            {
                MouseX = e.X;
                MouseY = e.Y;
                //this.Text = MouseX.ToString() + " "  + MouseY.ToString();
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (config.editMode == Common.EditMode.Hand ||
                    (config.editMode == Common.EditMode.Select && shiftKeyDown) ||
                    (config.editMode == Common.EditMode.Ruler && shiftKeyDown))
                {
                    //if (e.X > 3*glControlCast.Width / 4 || e.X < glControlCast.Width / 4 )
                    //{
                    //    if (eyeOffset.Z > 0)
                    //        angleZ -= (e.Y - MouseY);                           
                    //    else
                    //        angleZ += (e.Y - MouseY);                           
                    //}                    
                    //else
                    {
                        angleX += (e.X - MouseX);
                        angleY -= (e.Y - MouseY);
                    }
                }
                //glControlCast.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                //eyeOffset.Z += ((e.X - prevMouseX) / 10.0f) * boxRadius;
                targetOffset.X -= ((e.X - MouseX) / 10.0f) * boxRadius;
                targetOffset.Y += ((e.Y - MouseY) / 10.0f) * boxRadius;
                eyeOffset.X -= ((e.X - MouseX) / 10.0f) * boxRadius;
                eyeOffset.Y += ((e.Y - MouseY) / 10.0f) * boxRadius;
                //glControlCast.Invalidate();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                angleZ += (e.X - MouseX);
                angleZ += (e.Y - MouseY);

            }

            MouseX = e.X;
            MouseY = e.Y;
            //UpdateUI();
        }

        private void glControlCast_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (config.editMode == Common.EditMode.Ruler)
            {
                float d = Ruler_ComputeDistance(GetSelectedVBO());
                if (d != 0)
                    status.Text = "Distance = " + d.ToString() + " mm";
                else
                    status.Text = "";
            }
            UpdateUI();
        }

        private void glControlCast_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (config.editMode == Common.EditMode.Select && !shiftKeyDown)
                    MarkAndInsertSelectedVertex(GetSelectedVBO(), pointedVertexNumber);
                else if (config.editMode == Common.EditMode.Ruler)
                {
                    //MarkAndInsertSelectedVertex(GetSelectedVBO(), pointedVertexNumber);
                    Ruler_PointBIndex = pointedVertexNumber;
                }
            }
            UpdateUI();
        }

        private void glControlCast_DoubleClick(object sender, EventArgs e)
        {
            //didn't work as planed

            //if (pointedVertexNumber != NO_VERTEX_INDEX && GetSelectedVBO().show)
            //{
            //    Vector3 vectorEye2Target = eyeOffset - targetOffset;
            //    targetOffset = GetSelectedVBO().verticesData.vertices[pointedVertexNumber];
            //    eyeOffset = targetOffset + vectorEye2Target;
            //}

            //UpdateUI();
        }

        private void MouseWheel_UpDown(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                ZoomIn();
            else
                ZoomOut();
            UpdateUI();
        }

        private void Keyboard_Input(KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift)
            {
                rotateValue = slowRotateValue;
                ZOOMVALUE = slowZoomValue;

                shiftKeyDown = true;
            }
            else
            {
                rotateValue = fastRoateValue;
                ZOOMVALUE = fastZoomValue;

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
                ZoomIn();
                UpdateUI();
            }
            else if (e.KeyCode == Keys.PageDown)
            {

                ZoomOut();
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
            else if (e.KeyCode == Keys.D1)
            {
                if (e.Modifiers == Keys.Control)
                {
                    //lbox_selectCast.SelectedIndex = 0;
                    SelectedCast = 0;
                    UpdateUI();
                }
            }
            else if (e.KeyCode == Keys.D2)
            {
                if (e.Modifiers == Keys.Control)
                {
                    //lbox_selectCast.SelectedIndex = 1;
                    SelectedCast = 1;
                    UpdateUI();
                }
            }
            else if (e.KeyCode == Keys.I)
            {
                B_Calculate_Click(this, new EventArgs());
                UpdateUI();
            }
            else if (e.KeyCode == Keys.L && e.Modifiers == Keys.Control)
            {
                lockSelection = !lockSelection;
                UpdateUI();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (lview_selectedPoints1.SelectedItems.Count != 0 ||
                    lview_selectedPoints2.SelectedItems.Count != 0)
                    return;
                targetOffset.Y += 2;
                eyeOffset.Y += 2;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (lview_selectedPoints1.SelectedItems.Count != 0 ||
                    lview_selectedPoints2.SelectedItems.Count != 0)
                    return;
                targetOffset.Y -= 2;
                eyeOffset.Y -= 2;
            }
            else if (e.KeyCode == Keys.Left)
            {
                targetOffset.X -= 2;
                eyeOffset.X -= 2;
            }
            else if (e.KeyCode == Keys.Right)
            {
                targetOffset.X += 2;
                eyeOffset.X += 2;
            }

        }
    }
}
