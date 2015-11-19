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

        # region Shaders
        //Shaders
        int shaderProgramHandle, vertexShaderHandle, fragmentShaderHandle;

        //int uniformScale;
        //float variableScale;

        //void CreateShaders(string vertexShaderSource, string fragmentShaderSource)
        //{
        //    shaderProgramHandle = GL.CreateProgram();

        //    vertexShaderHandle = GL.CreateShader(ShaderType.VertexShader);
        //    fragmentShaderHandle = GL.CreateShader(ShaderType.FragmentShader);

        //    GL.ShaderSource(vertexShaderHandle, vertexShaderSource);
        //    GL.ShaderSource(fragmentShaderHandle, fragmentShaderSource);

        //    GL.CompileShader(vertexShaderHandle);
        //    GL.CompileShader(fragmentShaderHandle);
        //    Common.Logger.Log("MainForm", "OpenGL", "CreateShaders", "VertexShader: " + GL.GetShaderInfoLog(vertexShaderHandle), false);
        //    Common.Logger.Log("MainForm", "OpenGL", "CreateShaders", "FragmentShader: " + GL.GetShaderInfoLog(fragmentShaderHandle), false);
        //    //Console.WriteLine(GL.GetShaderInfoLog(vertexShaderHandle));
        //    //Console.WriteLine(GL.GetShaderInfoLog(fragmentShaderHandle));
        //    Common.Logger.Log("MainForm", "OpenGL", "CreateShaders", "vertexShader>" + GL.GetShaderInfoLog(vertexShaderHandle), false);
        //    Common.Logger.Log("MainForm", "OpenGL", "CreateShaders", "fragShader>" + GL.GetShaderInfoLog(fragmentShaderHandle), false);

        //    GL.AttachShader(shaderProgramHandle, vertexShaderHandle);
        //    GL.AttachShader(shaderProgramHandle, fragmentShaderHandle);
        //    GL.LinkProgram(shaderProgramHandle);
        //    //Console.WriteLine(GL.GetProgramInfoLog(shaderProgramHandle));
        //    Common.Logger.Log("MainForm", "OpenGL", "CreateShaders", "ShaderProgram: " + GL.GetProgramInfoLog(shaderProgramHandle), false);
        //    GL.UseProgram(shaderProgramHandle);

        //    //uniformScale = GL.GetUniformLocation(shaderProgramHandle, "scale");
        //}
        #endregion

        #region Texture
        //int castTextureID;
        /*
        private int LoadTexture(string filename)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(filename);

            //GL.Enable(EnableCap.CullFace);
            //GL.Enable(EnableCap.Texture2D);
            //GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);
            //GL.ActiveTexture(TextureUnit.Texture0);
            //GL.BindTexture(TextureTarget.Texture2D, castTextureID);


            Bitmap bmp = new Bitmap(filename);
            BitmapData bmp_data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);            

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (float)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (float)TextureWrapMode.Repeat);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);
            bmp.UnlockBits(bmp_data);


            // We haven't uploaded mipmaps, so disable mipmapping (otherwise the texture will not appear).
            // On newer video cards, we can use GL.GenerateMipmaps() or GL.Ext.GenerateMipmaps() to create
            // mipmaps automatically. In that case, use TextureMinFilter.LinearMipmapLinear to enable them.
            //GL.TexEnv(TextureEnvTarget.TextureEnv, TextureEnvParameter.TextureEnvMode, (float)TextureEnvMode.Modulate);
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.LinearMipmapNearest); //?
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);//?
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (float)TextureWrapMode.Repeat);//?
            //GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (float)TextureWrapMode.Repeat);//?
            //GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            //GL.ActiveTexture(TextureUnit.Texture0);
            //GL.BindTexture(TextureTarget.Texture2D, castTextureID);
            //GL.Uniform1(GL.GetUniformLocation(shaderProgramHandle, "MyTexture0"), TextureUnit.Texture0 - TextureUnit.Texture0);

            return id;
        }
        private void _CreateTexture(out int texture, Bitmap bitmap)
        {
            // load texture 
            GL.GenTextures(1, out texture);

            //Still required else TexImage2D will be applyed on the last bound texture
            GL.BindTexture(TextureTarget.Texture2D, texture);

            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
            OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        }

        private void _BindTexture(ref int textureId, OpenTK.Graphics.OpenGL.TextureUnit textureUnit, string UniformName)
        {
            GL.ActiveTexture(textureUnit);
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.Uniform1(GL.GetUniformLocation(shaderProgramHandle, UniformName), textureUnit - TextureUnit.Texture0);
        }
         */

        /*private void InitTexture()
        {
            //Textures
            if (flags.TextureEnable)
            {
                castTextureID = LoadTexture("testtexture.png");
                //Bitmap bitmap0 = new Bitmap("blackwhite.bmp");
                //_CreateTexture(out castTextureID, bitmap0);
                //_BindTexture(ref castTextureID, TextureUnit.Texture0, "MyTexture0");
                //GL.EnableClientState(ArrayCap.TextureCoordArray);
                //m_pUVs = new TexCoordPointerType[verticesStats.Size];

                GL.TexGen(TextureCoordName.S, TextureGenParameter.TextureGenMode, (float)TextureGenMode.ObjectLinear);
                GL.TexGen(TextureCoordName.T, TextureGenParameter.TextureGenMode, (float)TextureGenMode.ObjectLinear);
                //GL.TexGen(TextureCoordName.Q, TextureGenParameter.TextureGenMode, (float)TextureGenMode.ObjectLinear);
                //GL.TexGen(TextureCoordName.R, TextureGenParameter.TextureGenMode, (float)TextureGenMode.ObjectLinear);
                
                GL.Enable(EnableCap.TextureGenT);
                GL.Enable(EnableCap.TextureGenS);
                //GL.Enable(EnableCap.TextureGenQ);
                //GL.Enable(EnableCap.TextureGenR);
                
            }
        }*/
        #endregion  
    }
}