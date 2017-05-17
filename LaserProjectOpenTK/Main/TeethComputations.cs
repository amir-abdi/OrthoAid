using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OpenTK;
//using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Runtime.InteropServices;
using MathNet.Numerics.LinearAlgebra;

namespace OrthoAid_3DSimulator
{
    public partial class MainForm
    {
        Label[] tvalues1;
        Label[] tvalues2;
        Label[] tvalues3;
        Label[] tvalues4;
        Label[] tvalues5;
        Label[] tvalues6;
        Label[] tvalues7;
        CheckBox[] tcb;
        Label[] t;
        TextBox[] weightTextBoxex;
        
        Common.Plane[] Planes1; //TeethAxisPlane + OcclusalPlane + SagitalPlane
        Common.Plane[] Planes2; //TeethAxisPlane + OcclusalPlane + SagitalPlane
        List<Common.Plane[]> Planes;
        Common.Plane[] PlanesRelative;
        const int OCCLUSALPLANE_INDEX = 33;
        const int SAGITALPLANE_INDEX = 34;
        const int CURVEPLANE_INDEX = 35;
        const float TANGENT_LINE_LENGTH = 20;
        const int NUM_CHECKBOXES = 39;               
        const float PLANE_DRAW_RADIUS_TOOTH = 10;
        const float PLANE_DRAW_RADIUS_OTHER = 50;
        const float TANGENT_VECTOR_LENGTH = 7;
        Dictionary<int, int> Plane_CB1 = new Dictionary<int, int>();
        Dictionary<int, int> Plane_CB2 = new Dictionary<int, int>();
        List<Dictionary<int, int>> Plane_CB;

        Common.Dislocation[] Dislocations;
        Common.DistanceToPlane[] Distance2OcclusalPlane1;
        Common.DistanceToPlane[] Distance2SagitalPlane1;
        Common.DistanceToPlane[] Distance2OcclusalPlane2;
        Common.DistanceToPlane[] Distance2SagitalPlane2;
        List<Common.DistanceToPlane[]> Distance2SagitalPlane;
        List<Common.DistanceToPlane[]> Distance2OcclusalPlane;

        private void CalculateDisLocation(int selectedToothIndex)
        {
            if (vbo1.selectedVertices.Count != 1 ||
                vbo2.selectedVertices.Count != 1)
            {
                MessageBox.Show("To calculate Tooth Dislocation, after performing superimposition, you need to Select one point on each cast as reference.", "Wrong number of points");
                return;
            }

            Vector3 p1 = vbo1.verticesData.vertices[vbo1.selectedVertices[0]];
            Vector3 p2 = vbo2.verticesData.vertices[vbo2.selectedVertices[0]];

            Dislocations[selectedToothIndex].dislocation = p2 - p1;
            Dislocations[selectedToothIndex].length = (p2 - p1).Xy.Length; //just xy for this project
            Dislocations[selectedToothIndex].valid = true;
            tvalues2[selectedToothIndex].Text = Dislocations[selectedToothIndex].length.ToString("f2");
        }

        private bool DefineTeethPlaneAndTangentLine(Common.Vbo handle, ref Common.Plane toothAxisPlane, 
            int selectedToothIndex,  Common.Plane[] Planes)
        {
            try
            {
                List<uint> sel;
                Vector3[] verts;

                sel = handle.selectedVertices;
                verts = handle.verticesData.vertices;

                if (sel.Count != 3)
                {
                    MessageBox.Show("Exactly 3 points must be selected to define the tooth axis", "Wrong number of points");
                    return false;
                }
                
                if (Planes[OCCLUSALPLANE_INDEX]==null || !Planes[OCCLUSALPLANE_INDEX].valid)
                {
                    MessageBox.Show("Occlusal Plane should be defined prior to calculatin tooth Inclination.", "No Occlusal Plane");
                    return false;
                }

                Vector3 point1 = verts[sel[0]];
                Vector3 point2 = verts[sel[1]];
                Vector3 point3 = verts[sel[2]];

                //making sure points are in correct order--> lowest:point1, middle: point2, top: point3            
                //cause occulsal plane sometimes goes lower than the upper and even middle point, 
                //couldn't find a solution at the moment and decided to go with this:
                //the operator should Select the points in the correct order: lowest=first, highest=last
                //Sort3PointsBasedOnDistanceToOcclusalPlane(ref point1, ref point2, ref point3, Planes[OCCLUSALPLANE_INDEX]);

                toothAxisPlane = DefineAxisPlane(point1, point2, point3, Planes[OCCLUSALPLANE_INDEX]);
                Vector3[] projectedPoints = ProjectToothOnAxisPlane(handle, toothAxisPlane, Planes[OCCLUSALPLANE_INDEX]);
                Vector3[] projectedPointsOnBuccal = FindAndSortPointsOnBuccalSide(projectedPoints, toothAxisPlane, Planes[OCCLUSALPLANE_INDEX]);

                Vector3 BBPUser = point2;
                Vector3 projectedBBPUser = toothAxisPlane.ProjectPointOnPlane(point2);

                toothAxisPlane.projectedPointsOnAxisPlane = projectedPointsOnBuccal;
                toothAxisPlane.tangentPoints = CalculateTangentLine(projectedPointsOnBuccal, toothAxisPlane, projectedBBPUser);

                Vector3 tangentVector = toothAxisPlane.tangentPoints[1] - toothAxisPlane.tangentPoints[0];
                toothAxisPlane.Inclination = Planes[OCCLUSALPLANE_INDEX].Angle2Vector(tangentVector); //radian
                toothAxisPlane.Inclination = (toothAxisPlane.Inclination / (float)Math.PI) * 180;
                toothAxisPlane.Inclination = CorrectInclination_BiggerORSmallerThan90(toothAxisPlane, point1, Planes[OCCLUSALPLANE_INDEX]);
                toothAxisPlane.validInclination = true;

                return true;
            }
            catch (Exception e)
            {
                Common.Logger.Log("MainForm", "TeethComputations", "DefineTeethPlaneAndTangentLine", e.Message, true);
                return false;
            }
        }

        private float CorrectInclination_BiggerORSmallerThan90(Common.Plane toothAxisPlane, Vector3 lowestPoint, Common.Plane occlusalPlane)
        {
            Vector3 upperP, lowerP;
            int lowestSide = occlusalPlane.PointSide(lowestPoint);


            if (occlusalPlane.PointSide(toothAxisPlane.tangentPoints[0]) == lowestSide &&
                occlusalPlane.PointSide(toothAxisPlane.tangentPoints[1]) != lowestSide)
            {
                upperP = toothAxisPlane.tangentPoints[1];
                lowerP = toothAxisPlane.tangentPoints[0];
            }
            else if (occlusalPlane.PointSide(toothAxisPlane.tangentPoints[0]) != lowestSide &&
                occlusalPlane.PointSide(toothAxisPlane.tangentPoints[1]) == lowestSide)
            {
                upperP = toothAxisPlane.tangentPoints[0];
                lowerP = toothAxisPlane.tangentPoints[1];
            }
            else //error
            {
                upperP = toothAxisPlane.tangentPoints[1];
                lowerP = toothAxisPlane.tangentPoints[0];
                Common.Logger.Log("MainForm", "TeethComputations", "CorrectInclination_BiggerORSmallerThan90",
                    "Logical Error: both points of toothAxisPlane.tangentPoints were located on the same of the plane", true);
            }

            Vector3 upperPProj = occlusalPlane.ProjectPointOnPlane(upperP);
            Vector3 lowerPProj = occlusalPlane.ProjectPointOnPlane(lowerP);

            float distUpperPProj2Center = (upperPProj - occlusalPlane.centerForDraw).LengthSquared;
            float distLowerPProj2Center = (lowerPProj - occlusalPlane.centerForDraw).LengthSquared;

            if (distUpperPProj2Center < distLowerPProj2Center)
                return toothAxisPlane.Inclination - 90;
            else
                return (90 - toothAxisPlane.Inclination);

        }

        int selectedToothIndex_BackStore = -1;
        public int selectedIndex
        {
            get { return selectedToothIndex_BackStore; }
            set
            {
                selectedToothIndex_BackStore = value;
            }            
            
        }
        
        private void InitTeethBoxes()
        {                      
            t = new Label[37];
            tcb = new CheckBox[NUM_CHECKBOXES];
            tvalues1 = new Label[33];
            tvalues2 = new Label[33];
            tvalues3 = new Label[33];
            tvalues4 = new Label[33];
            tvalues5 = new Label[33];
            tvalues6 = new Label[33];
            tvalues7 = new Label[33];

            Planes1 = new Common.Plane[CURVEPLANE_INDEX+1];
            Planes2 = new Common.Plane[CURVEPLANE_INDEX+1];
            PlanesRelative = new Common.Plane[CURVEPLANE_INDEX+1];
            Planes = new List<Common.Plane[]>() { Planes1, Planes2, PlanesRelative };

            Dislocations = new Common.Dislocation[33];
            Distance2OcclusalPlane1 = new Common.DistanceToPlane[33];
            Distance2SagitalPlane1 = new Common.DistanceToPlane[33];
            Distance2OcclusalPlane2 = new Common.DistanceToPlane[33];
            Distance2SagitalPlane2 = new Common.DistanceToPlane[33];
            Distance2SagitalPlane = new List<Common.DistanceToPlane[]>() { Distance2SagitalPlane1, Distance2SagitalPlane2 };
            Distance2OcclusalPlane = new List<Common.DistanceToPlane[]>() { Distance2OcclusalPlane1, Distance2OcclusalPlane2 };

            weightTextBoxex = new TextBox[12];

            t[1] = t1; t[2] = t2; t[3] = t3; t[4] = t4; t[5] = t5; t[6] = t6; t[7] = t7; t[8] = t8; t[9] = t9; t[10] = t10;
            t[11] = t11; t[12] = t12; t[13] = t13; t[14] = t14; t[15] = t15; t[16] = t16; t[17] = t17; t[18] = t18; t[19] = t19; t[20] = t20;
            t[21] = t21; t[22] = t22; t[23] = t23; t[24] = t24; t[25] = t25; t[26] = t26; t[27] = t27; t[28] = t28; t[29] = t29; t[30] = t30;
            t[31] = t31; t[32] = t32;
            t[33] = lb_occlusalPlane;
            t[34] = lb_saggitalPlane;            

            tcb[1] = cb_t1; tcb[2] = cb_t2; tcb[3] = cb_t3; tcb[4] = cb_t4; tcb[5] = cb_t5; tcb[6] = cb_t6; tcb[7] = cb_t7; tcb[8] = cb_t8; tcb[9] = cb_t9; tcb[10] = cb_t10;
            tcb[11] = cb_t11; tcb[12] = cb_t12; tcb[13] = cb_t13; tcb[14] = cb_t14; tcb[15] = cb_t15; tcb[16] = cb_t16; tcb[17] = cb_t17; tcb[18] = cb_t18; tcb[19] = cb_t19; tcb[20] = cb_t20;
            tcb[21] = cb_t21; tcb[22] = cb_t22; tcb[23] = cb_t23; tcb[24] = cb_t24; tcb[25] = cb_t25; tcb[26] = cb_t26; tcb[27] = cb_t27; tcb[28] = cb_t28; tcb[29] = cb_t29; tcb[30] = cb_t30;
            tcb[31] = cb_t31; tcb[32] = cb_t32;
            tcb[33] = cb_occlusalPlane1;
            tcb[34] = cb_saggitalPlane1;
            tcb[35] = cb_occlusalPlane2;
            tcb[36] = cb_saggitalPlane2;
            tcb[37] = cb_curvePlane1;
            tcb[38] = cb_curvePlane2;

            //Inclication
            tvalues1[1] = v1t1; tvalues1[2] = v1t2; tvalues1[3] = v1t3; tvalues1[4] = v1t4; tvalues1[5] = v1t5; tvalues1[6] = v1t6; tvalues1[7] = v1t7; tvalues1[8] = v1t8; tvalues1[9] = v1t9; tvalues1[10] = v1t10;
            tvalues1[11] = v1t11; tvalues1[12] = v1t12; tvalues1[13] = v1t13; tvalues1[14] = v1t14; tvalues1[15] = v1t15; tvalues1[16] = v1t16; tvalues1[17] = v1t17; tvalues1[18] = v1t18; tvalues1[19] = v1t19; tvalues1[20] = v1t20;
            tvalues1[21] = v1t21; tvalues1[22] = v1t22; tvalues1[23] = v1t23; tvalues1[24] = v1t24; tvalues1[25] = v1t25; tvalues1[26] = v1t26; tvalues1[27] = v1t27; tvalues1[28] = v1t28; tvalues1[29] = v1t29; tvalues1[30] = v1t30;
            tvalues1[31] = v1t31; tvalues1[32] = v1t32;

            //Dislocation
            tvalues2[1] = v2t1; tvalues2[2] = v2t2; tvalues2[3] = v2t3; tvalues2[4] = v2t4; tvalues2[5] = v2t5; tvalues2[6] = v2t6; tvalues2[7] = v2t7; tvalues2[8] = v2t8; tvalues2[9] = v2t9; tvalues2[10] = v2t10;
            tvalues2[11] = v2t11; tvalues2[12] = v2t12; tvalues2[13] = v2t13; tvalues2[14] = v2t14; tvalues2[15] = v2t15; tvalues2[16] = v2t16; tvalues2[17] = v2t17; tvalues2[18] = v2t18; tvalues2[19] = v2t19; tvalues2[20] = v2t20;
            tvalues2[21] = v2t21; tvalues2[22] = v2t22; tvalues2[23] = v2t23; tvalues2[24] = v2t24; tvalues2[25] = v2t25; tvalues2[26] = v2t26; tvalues2[27] = v2t27; tvalues2[28] = v2t28; tvalues2[29] = v2t29; tvalues2[30] = v2t30;
            tvalues2[31] = v2t31; tvalues2[32] = v2t32;

            //Distance to Occlusal Plane
            tvalues3[1] = v3t1; tvalues3[2] = v3t2; tvalues3[3] = v3t3; tvalues3[4] = v3t4; tvalues3[5] = v3t5; tvalues3[6] = v3t6; tvalues3[7] = v3t7; tvalues3[8] = v3t8; tvalues3[9] = v3t9; tvalues3[10] = v3t10;
            tvalues3[11] = v3t11; tvalues3[12] = v3t12; tvalues3[13] = v3t13; tvalues3[14] = v3t14; tvalues3[15] = v3t15; tvalues3[16] = v3t16; tvalues3[17] = v3t17; tvalues3[18] = v3t18; tvalues3[19] = v3t19; tvalues3[20] = v3t20;
            tvalues3[21] = v3t21; tvalues3[22] = v3t22; tvalues3[23] = v3t23; tvalues3[24] = v3t24; tvalues3[25] = v3t25; tvalues3[26] = v3t26; tvalues3[27] = v3t27; tvalues3[28] = v3t28; tvalues3[29] = v3t29; tvalues3[30] = v3t30;
            tvalues3[31] = v3t31; tvalues3[32] = v3t32;

            //Distance to Sagital Plane
            tvalues4[1] = v4t1; tvalues4[2] = v4t2; tvalues4[3] = v4t3; tvalues4[4] = v4t4; tvalues4[5] = v4t5; tvalues4[6] = v4t6; tvalues4[7] = v4t7; tvalues4[8] = v4t8; tvalues4[9] = v4t9; tvalues4[10] = v4t10;
            tvalues4[11] = v4t11; tvalues4[12] = v4t12; tvalues4[13] = v4t13; tvalues4[14] = v4t14; tvalues4[15] = v4t15; tvalues4[16] = v4t16; tvalues4[17] = v4t17; tvalues4[18] = v4t18; tvalues4[19] = v4t19; tvalues4[20] = v4t20;
            tvalues4[21] = v4t21; tvalues4[22] = v4t22; tvalues4[23] = v4t23; tvalues4[24] = v4t24; tvalues4[25] = v4t25; tvalues4[26] = v4t26; tvalues4[27] = v4t27; tvalues4[28] = v4t28; tvalues4[29] = v4t29; tvalues4[30] = v4t30;
            tvalues4[31] = v4t31; tvalues4[32] = v4t32;

            //Inclination Cast1
            tvalues5[1] = v5t1; tvalues5[2] = v5t2; tvalues5[3] = v5t3; tvalues5[4] = v5t4; tvalues5[5] = v5t5; tvalues5[6] = v5t6; tvalues5[7] = v5t7; tvalues5[8] = v5t8; tvalues5[9] = v5t9; tvalues5[10] = v5t10;
            tvalues5[11] = v5t11; tvalues5[12] = v5t12; tvalues5[13] = v5t13; tvalues5[14] = v5t14; tvalues5[15] = v5t15; tvalues5[16] = v5t16; tvalues5[17] = v5t17; tvalues5[18] = v5t18; tvalues5[19] = v5t19; tvalues5[20] = v5t20;
            tvalues5[21] = v5t21; tvalues5[22] = v5t22; tvalues5[23] = v5t23; tvalues5[24] = v5t24; tvalues5[25] = v5t25; tvalues5[26] = v5t26; tvalues5[27] = v5t27; tvalues5[28] = v5t28; tvalues5[29] = v5t29; tvalues5[30] = v5t30;
            tvalues5[31] = v5t31; tvalues5[32] = v5t32;

            //Inclination Cast2
            tvalues6[1] = v6t1; tvalues6[2] = v6t2; tvalues6[3] = v6t3; tvalues6[4] = v6t4; tvalues6[5] = v6t5; tvalues6[6] = v6t6; tvalues6[7] = v6t7; tvalues6[8] = v6t8; tvalues6[9] = v6t9; tvalues6[10] = v6t10;
            tvalues6[11] = v6t11; tvalues6[12] = v6t12; tvalues6[13] = v6t13; tvalues6[14] = v6t14; tvalues6[15] = v6t15; tvalues6[16] = v6t16; tvalues6[17] = v6t17; tvalues6[18] = v6t18; tvalues6[19] = v6t19; tvalues6[20] = v6t20;
            tvalues6[21] = v6t21; tvalues6[22] = v6t22; tvalues6[23] = v6t23; tvalues6[24] = v6t24; tvalues6[25] = v6t25; tvalues6[26] = v6t26; tvalues6[27] = v6t27; tvalues6[28] = v6t28; tvalues6[29] = v6t29; tvalues6[30] = v6t30;
            tvalues6[31] = v6t31; tvalues6[32] = v6t32;

            //Inclination diff
            tvalues7[1] = v7t1; tvalues7[2] = v7t2; tvalues7[3] = v7t3; tvalues7[4] = v7t4; tvalues7[5] = v7t5; tvalues7[6] = v7t6; tvalues7[7] = v7t7; tvalues7[8] = v7t8; tvalues7[9] = v7t9; tvalues7[10] = v7t10;
            tvalues7[11] = v7t11; tvalues7[12] = v7t12; tvalues7[13] = v7t13; tvalues7[14] = v7t14; tvalues7[15] = v7t15; tvalues7[16] = v7t16; tvalues7[17] = v7t17; tvalues7[18] = v7t18; tvalues7[19] = v7t19; tvalues7[20] = v7t20;
            tvalues7[21] = v7t21; tvalues7[22] = v7t22; tvalues7[23] = v7t23; tvalues7[24] = v7t24; tvalues7[25] = v7t25; tvalues7[26] = v7t26; tvalues7[27] = v7t27; tvalues7[28] = v7t28; tvalues7[29] = v7t29; tvalues7[30] = v7t30;
            tvalues7[31] = v7t31; tvalues7[32] = v7t32;

            for (int i = 1; i <= 32; ++i)
            {
                t[i].Tag = i.ToString();
            }

            DisableAllCheckBoxes();

            //projectedPointsOnAxisPlane = new List<Vector3>[33];
            //tangentLinePoints = new List<Vector3>[33];

            for (int i = 0; i <= CURVEPLANE_INDEX; i++)
            {
                Planes[0][i] = null;
                Planes[1][i] = null;
                Planes[2][i] = null;
            }
            

            //for (int i = 0; i < OCCLUSALPLANE_INDEX; i++)
            //{
            //    projectedPointsOnAxisPlane[i] = null;
            //    tangentLinePoints[i] = null;
            //}

            for (int i = 1; i < OCCLUSALPLANE_INDEX; i++)
            {
                tvalues1[i].Text = "0";
                tvalues2[i].Text = "0";
                tvalues3[i].Text = "0";
                tvalues4[i].Text = "0";
                tvalues5[i].Text = "0";
                tvalues6[i].Text = "0";
                tvalues7[i].Text = "0";
            }

            //Weight Text boxes
            weightTextBoxex[0] = w1_tb;
            weightTextBoxex[1] = w2_tb;
            weightTextBoxex[2] = w3_tb;
            weightTextBoxex[3] = w4_tb;
            weightTextBoxex[4] = w5_tb;
            weightTextBoxex[5] = w6_tb;
            weightTextBoxex[6] = w7_tb;
            weightTextBoxex[7] = w8_tb;
            weightTextBoxex[8] = w9_tb;
            weightTextBoxex[9] = w10_tb;
            weightTextBoxex[10] = w11_tb;
            weightTextBoxex[11] = w12_tb;            
        }

        private void DeselectAllLabelsAndButtons()
        {
            for (int i = 1; i <= 34; ++i)
            {
                t[i].BorderStyle = BorderStyle.None;
            }
        }

        private void Sort3PointsBasedOnDistanceToOcclusalPlane(ref Vector3 point1, ref Vector3 point2, ref Vector3 point3, Common.Plane occlusalP)
        {
            double dist1 = occlusalP.Distance2Point(point1);
            double dist2 = occlusalP.Distance2Point(point2);
            double dist3 = occlusalP.Distance2Point(point3);

            if (dist1 > dist2 && dist2 > dist3)
            {
                //points are in correct order
            }
            else
            {
                if (dist1 < dist2)
                {
                    Vector3 t = point1;
                    point1 = point2;
                    point2 = t;

                    double d = dist1;
                    dist1 = dist2;
                    dist2 = d;
                }

                if (dist2 < dist3)
                {
                    Vector3 t = point3;
                    point3 = point2;
                    point2 = t;

                    double d = dist3;
                    dist3 = dist2;
                    dist2 = d;
                }

                if (dist1 < dist2)
                {
                    Vector3 t = point1;
                    point1 = point2;
                    point2 = t;

                    double d = dist1;
                    dist1 = dist2;
                    dist2 = d;
                }
            }
        }        

        private Vector3[] CalculateTangentLine(Vector3[] projectedPointsOnBuccal, Common.Plane axisPlane, 
            Vector3 BBPSelectedByUser)
        {
            Vector3 rotationAxis_Horizontal;
            float rotationDegree;
            axisPlane.RotationAxisAndDegreeToMakePlaneHorizontal(out rotationAxis_Horizontal, out rotationDegree);
            Vector3[] rotatedPoints = Common.Plane.RotatePointsAroundAxis(projectedPointsOnBuccal.ToArray(), 
                rotationAxis_Horizontal, rotationDegree);
            Vector3[] points = rotatedPoints;
            //Testing rotation:
            //Vector3[] oldpoints = Common.Plane.RotatePointsAroundAxis(rotatedPoints, rotationAxis_Horizontal, -rotationDegree);            

            //projected user BBP
            Vector3 rotatedBBPUser = Common.Plane.RotatePointsAroundAxis(new Vector3[] { BBPSelectedByUser }, 
                rotationAxis_Horizontal, rotationDegree)[0];

            #region commented and moved to new function
            //int numPoints = points.Length;
            //Vector2 first = points[0].Xy;
            //Vector2 last = points[points.Length - 1].Xy;
            //Vector2 midOfFirstLast = (first + last) / 2;

            //Common.Line FLLine = new Common.Line(first, last);
            //Common.Line midPerpLine = new Common.Line(midOfFirstLast, FLLine.PerpendicularMu());
            
            ////int minDistToMidPerpLineIndex = -1;
            ////float minDistToMidPerpLine = float.MaxValue;
            ////for (int i = 0; i < points.Length; i++)
            ////{
            ////    if (midPerpLine.DistanceToPoint(points[i].Xy) < minDistToMidPerpLine)
            ////    {
            ////        minDistToMidPerpLine= midPerpLine.DistanceToPoint(points[i].Xy);
            ////        minDistToMidPerpLineIndex = i;
            ////    }
            ////}
            
            ////float[] x = new float[points.Length];
            ////float[] y = new float[points.Length];
            //double[] xd = new double[points.Length];
            //double[] yd = new double[points.Length];
            
            ////checking if the points are actualy spread over X-axis.
            ////other wise I swap the X-Y axises to make te polyfit function of matlab work.
            //bool invereseXY = false;
            //if (Math.Abs(first.X - last.X) < Math.Abs(first.Y - last.Y))
            //    invereseXY = true;
            
            //if (!invereseXY)
            //    for (int i = 0; i < points.Length; i++)
            //    {
            //        //x[i] = points[i].X;
            //        //y[i] = points[i].Y;
            //        xd[i] = points[i].X;
            //        yd[i] = points[i].Y;
            //    }
            //else
            //    for (int i = 0; i < points.Length; i++)
            //    {
            //        //y[i] = points[i].X;
            //        //x[i] = points[i].Y;
            //        xd[i] = points[i].Y;
            //        yd[i] = points[i].X;
            //    }

            ////Vector3 midPoint = points[minDistToMidPerpLineIndex];//points[numPoints / 2];
            //Vector2d midPoint = new Vector2d(xd[minDistToMidPerpLineIndex], yd[minDistToMidPerpLineIndex]);
            #endregion

            //float mu = PolynomialRegressionAndDerivative_MATLAB(x, y, midPoint);                    
            Vector2 midpoint = rotatedBBPUser.Xy;
            float mu = (float)PolynomialRegressionAndDerivativeAtMidPoint_MathNet(points, ref midpoint);            

            Vector3[] tangentLinePoints = new Vector3[2];
            tangentLinePoints[0] = new Vector3();            
            tangentLinePoints[0].X = midpoint.X + TANGENT_VECTOR_LENGTH / 2;
            tangentLinePoints[0].Y = TANGENT_VECTOR_LENGTH / 2 * mu + midpoint.Y;
            tangentLinePoints[0].Z = points[0].Z;
            tangentLinePoints[1] = new Vector3();
            tangentLinePoints[1].X = midpoint.X - TANGENT_VECTOR_LENGTH / 2;
            tangentLinePoints[1].Y = midpoint.Y - TANGENT_VECTOR_LENGTH / 2 * mu;
            tangentLinePoints[1].Z = points[0].Z;

            Vector3[] tangentLinePoints3D = Common.Plane.RotatePointsAroundAxis(tangentLinePoints, rotationAxis_Horizontal, -rotationDegree);
            
            //fixing the length
            Vector3 mid3D = (tangentLinePoints3D[0] + tangentLinePoints3D[1])/2;
            Vector3 lengthVector = (tangentLinePoints3D[0]-mid3D);
            lengthVector.Normalize();
            tangentLinePoints3D[0] = mid3D + lengthVector * TANGENT_LINE_LENGTH;
            tangentLinePoints3D[1] = mid3D - lengthVector * TANGENT_LINE_LENGTH;
            
            return tangentLinePoints3D;
        }

        private double PolynomialRegressionAndDerivativeAtMidPoint_MathNet(Vector3[] points, ref Vector2 midPoint) 
        {
            int numPoints = points.Length;
            
            double[] xd = new double[points.Length];
            double[] yd = new double[points.Length];

            //checking if the points are actualy spread over X-axis.
            //other wise I swap the X-Y axises to make te polyfit function of matlab work.
            
            Vector2 first = points[0].Xy;
            Vector2 last = points[points.Length - 1].Xy;
            bool invereseXY = false;
            if (Math.Abs(first.X - last.X) < Math.Abs(first.Y - last.Y))
                invereseXY = true;

            if (invereseXY)
            {
                first = new Vector2(first.Y, first.X);
                last = new Vector2(last.Y, last.X);
            }
            Vector2 midOfFirstLast = (first + last) / 2;
            Common.Line2D FLLine = new Common.Line2D(first, last);
            Common.Line2D midPerpLine = new Common.Line2D(midOfFirstLast, FLLine.PerpendicularMu());

            if (!invereseXY)
                for (int i = 0; i < points.Length; i++)
                {
                    xd[i] = points[i].X;
                    yd[i] = points[i].Y;
                }
            else
                for (int i = 0; i < points.Length; i++)
                {
                    xd[i] = points[i].Y;
                    yd[i] = points[i].X;
                }

            
            //Vector2d midPoint = new Vector2d(xd[minDistToMidPerpLineIndex], yd[minDistToMidPerpLineIndex]);

            var vx = new MathNet.Numerics.LinearAlgebra.Double.DenseVector(xd);
            var vy = new MathNet.Numerics.LinearAlgebra.Double.DenseVector(yd);

            Common.PolynominalRegression poly = new Common.PolynominalRegression(vx, vy, 3);



            switch (config.bbpChoice)
            {
                case OrthoAid_3DSimulator.Common.BBPChoice.User:
                    if (invereseXY)
                        midPoint = new Vector2(midPoint.Y, midPoint.X);
                    break;
                case OrthoAid_3DSimulator.Common.BBPChoice.AutoMiddle:
                    Vector2[] crossPoints = midPerpLine.CrosspointWithCurve(poly.GetCoefficients());
                    if (crossPoints.Length == 1)
                        midPoint = crossPoints[0];
                    else
                    {
                        midPoint = crossPoints[0];
                        for (int i = 1; i < crossPoints.Length; i++)
                        {
                            if ((crossPoints[i] - midOfFirstLast).LengthSquared <
                                (midPoint - midOfFirstLast).LengthSquared)
                                midPoint = crossPoints[i];
                        }
                    }
                    break;
                default:
                    break;
            }
            

            double mu = poly.DerivativeAtPoint(midPoint.X);
            //var t = new MathNet.Numerics.Interpolation.Algorithms.LinearSplineInterpolation(            


            if (invereseXY)
            {
                mu = 1 / mu;
                midPoint = new Vector2(midPoint.Y, midPoint.X);
            }
            

            return mu;
        }

        private Vector3[] FindAndSortPointsOnBuccalSide(Vector3[] projectedPoints, Common.Plane AxisPlane, Common.Plane OcclusalPlane)
        {            
            Vector3 center = AxisPlane.center;
            Vector3 highest = AxisPlane.highestPoint;
            Vector3 lowest = AxisPlane.lowestPoint;

            //projectedPoints.sor
            tempOcclusalPlaneForPointCompareSort = OcclusalPlane;
            System.Comparison<Vector3> comp = new Comparison<Vector3>(pointCompareOnDistanceToOcclusalPlane);
            Array.Sort<Vector3>(projectedPoints, comp);            

            //plane which cut the tooth in half in vertical (medio-lateral)
            Vector3 point3 = new Vector3(highest);
            point3 += AxisPlane.GetNormal();
            Common.Plane halfPlaneOfTooth = new Common.Plane(highest, lowest, point3, "halfPlane", PLANE_DRAW_RADIUS_TOOTH);
            
            //Testing the halfPlane
            //Planes[SAGITALPLANE_INDEX] = halfPlaneOfTooth;
            //Planes[SAGITALPLANE_INDEX].valid = true;
            //tcb[SAGITALPLANE_INDEX].Enabled = true;
            //tcb[SAGITALPLANE_INDEX].Checked = true;

            int centerSide = halfPlaneOfTooth.PointSide(center);


            List<Vector3> newPoints = new List<Vector3>();

            for (int i = 0; i < projectedPoints.Length; i++)
            {
                //if ((center - highest).Length > (center - projectedPoints[i]).Length) //meaning point is on buccal!
                if (halfPlaneOfTooth.PointSide(projectedPoints[i]) == centerSide)
                    newPoints.Add(projectedPoints[i]);
            }

            //this.Text = newPoints.Count.ToString();
            return newPoints.ToArray();
        }

        Common.Plane tempOcclusalPlaneForPointCompareSort;
        public int pointCompareOnDistanceToOcclusalPlane(Vector3 a, Vector3 b)
        {
            double da = tempOcclusalPlaneForPointCompareSort.Distance2Point(a);
            double db = tempOcclusalPlaneForPointCompareSort.Distance2Point(b);
            if (da > db)
                return -1;
            else if (da == db)
                return 0;
            else
                return 1;
        }

        private Vector3[] ProjectToothOnAxisPlane(Common.Vbo handle, Common.Plane axisP, Common.Plane occlusalP)
        {            
            const float dist2CenterTh = 5;
            const float dist2PlaneTh = 0.2f;
            List<Vector3> projectedPoints = new List<Vector3>();
            double distanceToLowest = occlusalP.Distance2Point(axisP.lowestPoint);
            double distanceToHighest = occlusalP.Distance2Point(axisP.highestPoint);

            //int sideLowest = occlusalP.PointSide

            for (int i = 0; i < handle.verticesData.vertices.Length; i++)
            {
                if (axisP.Distance2Point(handle.verticesData.vertices[i]) < dist2PlaneTh &&
                    (handle.verticesData.vertices[i] - axisP.center).Length < dist2CenterTh &&
                    //occlusalP.Distance2Point(handle.verticesData.vertices[i]) < distanceToLowest &&
                    //occlusalP.Distance2Point(handle.verticesData.vertices[i]) > distanceToHighest            
                    handle.verticesData.vertices[i].Z > axisP.lowestPoint.Z && // ASSUMING CAST IS FACED UPWARD = Z
                    handle.verticesData.vertices[i].Z < axisP.highestPoint.Z //ASSUMING CAST IS FACED UPWARD = Z
                    )
                    projectedPoints.Add(axisP.ProjectPointOnPlane(handle.verticesData.vertices[i]));
            }

            return projectedPoints.ToArray();//projectedPointsOnAxisPlane[selectedToothIndex].ToArray(); ;
        }

        private Common.Plane DefineAxisPlane( Vector3 point1, Vector3 point2, Vector3 point3, Common.Plane occlusalPlane)
        {
            Vector3 normalToOcclucal = occlusalPlane.GetNormal();
           
            Vector3 toothAxis = point1 - point3;
            //Common.Plane axisPlane = new Common.Plane(point1, point2, point3, toothAxis, normalToOcclucal, 
            //    "Axial "+selectedIndex.ToString(), PLANE_DRAW_RADIUS_TOOTH);

            Common.Plane axisPlane2 = new Common.Plane(point1, point2, point3,
                "Axial " + selectedIndex.ToString(), PLANE_DRAW_RADIUS_TOOTH);

            return axisPlane2;
        }

        bool DefineOcclusalPlane(Common.Vbo handle, ref Common.Plane plane, int planeNumber)
        {
            List<uint> sel;
            Vector3[] verts;

            sel = handle.selectedVertices;
            verts = handle.verticesData.vertices;

            if (sel.Count != 3)
            {
                MessageBox.Show("Exactly 3 points must be selected to define the Occlusal Plane", "Wrong number of points");
                return false;
            }

            plane = new Common.Plane(verts[sel[0]], verts[sel[1]], verts[sel[2]], "occlusal " + planeNumber.ToString(), PLANE_DRAW_RADIUS_OTHER);
            plane.valid = true;
            return true;
        }

        private void SelectButton(Button b)
        {
            b.BackColor = Color.Silver;
        }

        private void lb_saggitalPlane_Click(object sender, EventArgs e)
        {
            //if (DefinePlane(ref saggitalPlane))
            //{
            //    cb_saggitalPlane.Checked = true;
            //    cb_saggitalPlane.Enabled = true;
            //}
            //b_saggitalPlane.BackColor = Color.Silver;
        }

        private void lb_occlusalPlane_Click(object sender, EventArgs e)
        {
            //if (DefinePlane(ref occlusalPlane))
            //{
            //    cb_occlusalPlane.Checked = true;
            //    cb_occlusalPlane.Enabled = true;

            //}
        }

        private void DisableAllCheckBoxes()
        {
            for (int i = 1; i < NUM_CHECKBOXES; ++i)
            {
                tcb[i].Enabled = false;
                tcb[i].Checked = false;
            }
        }

        private void UpdateTeethAndPlanesUI()
        {
            //angle between occlusal planes
            if (Planes[0][OCCLUSALPLANE_INDEX] != null && Planes[1][OCCLUSALPLANE_INDEX] != null)
                lb_occlusalPlanesAngle.Text = Planes[0][OCCLUSALPLANE_INDEX].Angle2Plane(Planes[1][OCCLUSALPLANE_INDEX]).ToString("f2");

            //Inclination Tab --> CheckBoxes
            int vboind = GetSelectedVbOIndex();
            if (vboind == 0)
                return;

            for (int i = 1; i <= 32; ++i)
            {
                if (Planes[vboind-1][i] != null && Planes[vboind-1][i].valid)
                {
                    tcb[i].Enabled = true;
                    tcb[i].Checked = true;
                }
                else
                {
                    tcb[i].Enabled = false;
                    tcb[i].Checked = false;
                }
            }

            //Handling Occlusal/Sagital Checkboxes separately because of the index numbers in the arrays!
            if (Planes[vboind-1][OCCLUSALPLANE_INDEX] != null && Planes[vboind-1][OCCLUSALPLANE_INDEX].valid)
                tcb[Plane_CB[vboind-1][OCCLUSALPLANE_INDEX]].Enabled = true;
            else
            {
                tcb[Plane_CB[vboind-1][OCCLUSALPLANE_INDEX]].Enabled = false;
                tcb[Plane_CB[vboind-1][OCCLUSALPLANE_INDEX]].Checked = false;
            }
            
            if (Planes[vboind-1][SAGITALPLANE_INDEX] != null && Planes[vboind-1][SAGITALPLANE_INDEX].valid)
                tcb[Plane_CB[vboind-1][SAGITALPLANE_INDEX]].Enabled = true;
            else
            {
                tcb[Plane_CB[vboind-1][SAGITALPLANE_INDEX]].Enabled = false;
                tcb[Plane_CB[vboind-1][SAGITALPLANE_INDEX]].Checked = false;
            }
            if (Planes[vboind-1][CURVEPLANE_INDEX] != null && Planes[vboind-1][CURVEPLANE_INDEX].valid)
                tcb[Plane_CB[vboind-1][CURVEPLANE_INDEX]].Enabled = true;
            else
            {
                tcb[Plane_CB[vboind-1][CURVEPLANE_INDEX]].Enabled = false;
                tcb[Plane_CB[vboind-1][CURVEPLANE_INDEX]].Checked = false;
            }
            

            //Inclination Tab --> Values
            if (GetSelectedVbOIndex() == 2)
            {
                for (int i = 1; i < OCCLUSALPLANE_INDEX; ++i)
                {
                    if (Planes[1][i] != null && Planes[1][i].validInclination)
                    {
                        tvalues1[i].Text = Planes[1][i].Inclination.ToString("f2");
                    }
                    else
                        tvalues1[i].Text = "0";
                }
            }
            else if (GetSelectedVbOIndex() == 1)
            {
                for (int i = 1; i < OCCLUSALPLANE_INDEX; ++i)
                {
                    if (Planes[0][i] != null && Planes[0][i].validInclination)
                    {
                        tvalues1[i].Text = Planes[0][i].Inclination.ToString("f2");
                    }
                    else
                        tvalues1[i].Text = "0";
                }
            }

            ///Dislocation tab
            for (int i = 1; i <= 32; i++)
            {
                if (Dislocations[i].valid)
                    tvalues2[i].Text = Dislocations[i].length.ToString("f2");
                else
                    tvalues2[i].Text = "0";
            }

            //Distance to Plane tab
            if (GetSelectedVbOIndex() == 1)
            {
                for (int i = 1; i <= 32; i++)
                {
                    if (Distance2OcclusalPlane1[i].valid)
                        tvalues3[i].Text = Distance2OcclusalPlane1[i].length.ToString("f2");
                    else
                        tvalues3[i].Text = "0";
                }

                for (int i = 1; i <= 32; i++)
                {
                    if (Distance2SagitalPlane1[i].valid)
                        tvalues4[i].Text = Distance2SagitalPlane1[i].length.ToString("f2");
                    else
                        tvalues4[i].Text = "0";
                }
            }
            else if (GetSelectedVbOIndex() == 2)
            {
                for (int i = 1; i <= 32; i++)
                {
                    if (Distance2OcclusalPlane2[i].valid)
                        tvalues3[i].Text = Distance2OcclusalPlane2[i].length.ToString("f2");
                    else
                        tvalues3[i].Text = "0";
                }

                for (int i = 1; i <= 32; i++)
                {
                    if (Distance2SagitalPlane2[i].valid)
                        tvalues4[i].Text = Distance2SagitalPlane2[i].length.ToString("f2");
                    else
                        tvalues4[i].Text = "0";
                }
            }

            //Superimposed Inclination tab
            for (int i = 1; i <= 32; ++i)
            {
                if (Planes[0][i] != null && Planes[0][i].validInclination)                
                    tvalues5[i].Text = Planes[0][i].Inclination.ToString("f2");                
                else
                    tvalues5[i].Text = "0";
                if (Planes[1][i] != null && Planes[1][i].validInclination)
                    tvalues6[i].Text = Planes[1][i].Inclination.ToString("f2");
                else
                    tvalues6[i].Text = "0";

                if (Planes[0][OCCLUSALPLANE_INDEX] != null && Planes[0][OCCLUSALPLANE_INDEX].valid &&
                    Planes[1][i] != null && Planes[1][i].validInclination &&
                    Planes[2][i] != null && Planes[2][i].validInclination)
                    tvalues7[i].Text = Planes[2][i].Inclination.ToString("f2");
                else
                    tvalues7[i].Text = "0";
            }

        }

        private bool DefineSagitalPlane(Common.Vbo handle, ref Common.Plane plane, int selectedIndex, Common.Plane occlusalPlane)
        {
            if (occlusalPlane == null || !occlusalPlane.valid)
            {
                MessageBox.Show("Occlusal Plane should be defined prior to defining Sagital Plane.", "No Occlusal Plane");
                return false;
            }
            

            List<uint> sel;
            Vector3[] verts;
            sel = handle.selectedVertices;
            verts = handle.verticesData.vertices;

            if (sel.Count != 2)
            {
                MessageBox.Show("To define a Sagital Plane, first define the Occlusal Plane, then Select 2 points on the midline.", "Wrong number of selected points");
                return false;
            }
            plane = new Common.Plane(verts[sel[0]], verts[sel[1]], occlusalPlane.GetNormal());
            plane.valid = true;
            return true;
        }
        
        private void CalculateDistanceToPlane(Common.Vbo handle, int selectedIndex)
        {
            if ((handle.selectedVertices.Count != 1))
            {
                if ((selectedIndex == 1 && (Planes[0][OCCLUSALPLANE_INDEX] == null || Planes[0][SAGITALPLANE_INDEX] == null)) ||
                    (selectedIndex == 2 && (Planes[1][OCCLUSALPLANE_INDEX] == null || Planes[1][SAGITALPLANE_INDEX] == null)))
                {
                    MessageBox.Show("After defining the Occlusal/Sagital Plane, Select a tooth and a cusp tip to calculate the distance from the cusp tip to the defined plane.", "Wrong number of points");
                    return;
                }
            }

            List<uint> sel;
            Vector3[] verts;
            sel = handle.selectedVertices;
            verts = handle.verticesData.vertices;

            if (GetSelectedVbOIndex() == 1)
            {
                if (Planes[0][OCCLUSALPLANE_INDEX] != null && Planes[0][OCCLUSALPLANE_INDEX].valid)
                {
                    Distance2OcclusalPlane1[selectedIndex].length = (float)Planes[0][OCCLUSALPLANE_INDEX].Distance2Point(verts[sel[0]]);
                    Distance2OcclusalPlane1[selectedIndex].valid = true;
                }

                if (Planes[0][SAGITALPLANE_INDEX] != null && Planes[0][SAGITALPLANE_INDEX].valid)
                {
                    Distance2SagitalPlane1[selectedIndex].length = (float)Planes[0][SAGITALPLANE_INDEX].Distance2Point(verts[sel[0]]);
                    Distance2SagitalPlane1[selectedIndex].valid = true;
                }
            }
            else if (GetSelectedVbOIndex() == 2)
            {
                if (Planes[1][OCCLUSALPLANE_INDEX] != null && Planes[1][OCCLUSALPLANE_INDEX].valid)
                {
                    Distance2OcclusalPlane2[selectedIndex].length = (float)Planes[1][OCCLUSALPLANE_INDEX].Distance2Point(verts[sel[0]]);
                    Distance2OcclusalPlane2[selectedIndex].valid = true;
                }

                if (Planes[1][SAGITALPLANE_INDEX] != null && Planes[1][SAGITALPLANE_INDEX].valid)
                {
                    Distance2SagitalPlane2[selectedIndex].length = (float)Planes[1][SAGITALPLANE_INDEX].Distance2Point(verts[sel[0]]);
                    Distance2SagitalPlane2[selectedIndex].valid = true;
                }
            }
        }
    }
}