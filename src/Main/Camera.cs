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
        int[] viewport = new int[4];
        float angleX = 45.0f, angleY = 45.0f, angleZ = 45.0f;
        Vector3 eyeOffset;
        Vector3 targetOffset;
        float ZOOMVALUE = 5;
        float rotateValue = 10;
        const float slowRotateValue = 1;
        const float fastRoateValue = 10;
        const float slowZoomValue = 0.5f;
        const float fastZoomValue = 5;
        bool autoRotateFlag = false;

        private void SetCamera()
        {
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(viewport[0], viewport[1], viewport[2], viewport[3]);

#pragma warning disable CS0618 // 'GL' is obsolete: 'Use OpenTK.Graphics.OpenGL or one of the specific profiles instead.'
            GL.Viewport(r);
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
#pragma warning restore CS0618 // 'GL' is obsolete: 'Use OpenTK.Graphics.OpenGL or one of the specific profiles instead.'
        }

        private void SetViewPort()
        {
            viewport[0] = 0;// this.glControlCast.Location.X;
            viewport[1] = 0;//this.glControlCast.Location.Y;
            viewport[2] = glControlCast.Width;
            viewport[3] = glControlCast.Height;
        }

        private void ZoomIn()
        {
            Vector3 movingDirection = (targetOffset - eyeOffset);
            if (movingDirection.Length < 8)
                return;
            movingDirection.Normalize();
            eyeOffset += movingDirection * ZOOMVALUE;
        }

        private void ZoomOut()
        {
            Vector3 movingDirection = (targetOffset - eyeOffset);
            if (movingDirection.Length > 200)
                return;
            movingDirection.Normalize();
            eyeOffset -= movingDirection * ZOOMVALUE;
        }
    }
}