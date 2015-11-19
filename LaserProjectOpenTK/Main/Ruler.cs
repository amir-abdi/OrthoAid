using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;

namespace OrthoAid_3DSimulator
{
    public partial class MainForm
    {
        uint Ruler_PointAIndex, Ruler_PointBIndex;
        Vector3 Ruler_PointA = new Vector3(-100, -100, -100), Ruler_PointB = new Vector3(-100, -100, -100);
        Vector3 NO_VERTEX = new Vector3(-100, -100, -100);

        private float Ruler_ComputeDistance(Common.Vbo handle)
        {
            if (Ruler_PointAIndex != NO_VERTEX_INDEX && Ruler_PointBIndex != NO_VERTEX_INDEX)
            {
                Ruler_PointA = handle.verticesData.vertices[Ruler_PointAIndex];
                Ruler_PointB = handle.verticesData.vertices[Ruler_PointBIndex];
                float f = (Ruler_PointA-Ruler_PointB).Length;

                return f;
            }

            else
                return 0;
        }


    }
}
