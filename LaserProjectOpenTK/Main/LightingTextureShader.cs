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


namespace OrthoAid_3DSimulator
{
    public partial class MainForm
    {
        
        private void InitLighting()
        {            
            if (flags.LightingEnable)
            {
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                GL.Enable(EnableCap.Light1);
                GL.Enable(EnableCap.ColorMaterial); //keeping the current colors, else colors will be removed                

                float lightIntensity = config.lightIntensity;

                float[] ambientLight1 = new float[3] { lightIntensity, lightIntensity, lightIntensity };
                float[] lightPosition1 = new float[4] { -100, -500, 500, 1 };
                GL.Light(LightName.Light1, LightParameter.Diffuse, ambientLight1);
                //GL.Light(LightName.Light1, LightParameter.Position, lightPosition1);

                float[] ambientLight0 = new float[3] { lightIntensity ,lightIntensity ,lightIntensity };
                float[] lightPosition0 = new float[4] { 100, 500, 1000, 1 };
                GL.Light(LightName.Light0, LightParameter.Diffuse, ambientLight0);
                //GL.Light(LightName.Light0, LightParameter.Position, lightPosition0);
                //GL.LightModel(LightModelParameter.LightModelAmbient, ambientLight0);
            }
        }

        private void UpdateLighting()
        {            
            float lightIntensity = config.lightIntensity;

            float[] ambientLight1 = new float[3] { lightIntensity, lightIntensity, lightIntensity };            
            GL.Light(LightName.Light1, LightParameter.Diffuse, ambientLight1);            

            float[] ambientLight0 = new float[3] { lightIntensity, lightIntensity, lightIntensity };            
            GL.Light(LightName.Light0, LightParameter.Diffuse, ambientLight0);            
        }        
    }
}