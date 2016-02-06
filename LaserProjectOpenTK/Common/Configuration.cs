using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace OrthoAid_3DSimulator.Common
{
    public class Configuration
    {
        public FitFunction fitFunction = FitFunction.polynomial;        
        public decimal polynomialFitOrder = 4;

        public double[] weights = new double[13];

        public int windowHeight = 700;
        public int windowWidth = 1000;
        
        public bool autoRotate = false;

        public ViewMode viewMode = ViewMode.Mesh;
        public EditMode editMode = EditMode.Hand;

        public string lastLoadedMeshName1 = "No Mesh loaded";
        public string lastLoadedMeshFileAddress1 = "empty";
        public string lastLoadedMeshType1 = "empty";

        public string lastLoadedMeshName2 = "No Mesh loaded";
        public string lastLoadedMeshFileAddress2 = "empty";
        public string lastLoadedMeshType2 = "empty";

        public float lightIntensity = 0.5f;
        public float reduceDensityThreshold { get; set; }
        //public bool showCast1, showCast2;

        public BBPChoice bbpChoice = BBPChoice.AutoMiddle;
        public SuperimposeChoise superimposeChoice = SuperimposeChoise.Order;

        public void SaveConfig()
        {
            try
            {                
                MemoryStream ms = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(ms, this);
                ms.Position = 0;

                StreamWriter sr = new StreamWriter("Config.cfg");
                byte[] buffer = new byte[ms.Length];
                ms.Read(buffer, 0, buffer.Length);
                string result = System.Text.Encoding.UTF8.GetString(buffer);
                sr.Write(result);
                sr.Flush();
                sr.Close();
                Logger.Log("Configuration", "Configuration", "SaveConfig", "Config file:Config.cfg Saved", false);
            }
            catch (Exception e)
            {
                Logger.Log("Configuration", "Configuration", "SaveConfig", e.Message, true);
            }
        }
        public static Configuration LoadConfig()
        {
            try
            {
                if (!File.Exists("Config.cfg"))
                    return new Configuration();
                FileStream fs = new FileStream("Config.cfg", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                Configuration config = (Configuration)serializer.Deserialize(fs);

                fs.Close();
                fs = null;
                serializer = null;
                Logger.Log("Configuration", "Configuration", "LoadConfig", "Config File:Config.cfg loaded", false);
                return config;
            }
            catch (Exception e)
            {
                Logger.Log("Configuration", "Configuration", "LoadConfig", e.Message, true);
                Configuration config = new Configuration();
                return config;
            }
        }

        
    }
}
