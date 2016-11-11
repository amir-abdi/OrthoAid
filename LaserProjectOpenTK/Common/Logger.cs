    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace OrthoAid_3DSimulator.Common
{
    public static class Logger
    {
        static private bool firstRun = true;
        static private StreamWriter sw;
        static public void Log(string className, string fileName, string methodName, string msg, bool errorMsg = true)
        {            
            if (firstRun)
            {
                createLogFile();
                firstRun = false;
            }
            if (errorMsg)
                sw.Write("ERROR--> ");
            sw.WriteLine(className+';'+fileName+';'+methodName+';'+ msg);
            sw.Flush();
        }

        static public void Log(string stackTrace, string message)
        {
            sw.Write("CatchedException--> ");
            sw.WriteLine("StackTrace= " + stackTrace + " ; Message= " + message);
            sw.Flush();
        }

        static private void createLogFile()
        {
            MainForm.DirectoryCheck("Log");
            char[] logChars = { 'L', 'o', 'g' };
            var files = Directory.GetFiles("Log");
            int lastFileNumber = 0;
            if (files.Length > 0)
            {
                lastFileNumber = Int32.Parse((files[files.Length-1].Split('_'))[1]);
            }
            string filename = @"Log\" + "Log_" + (lastFileNumber+1).ToString() + "_Date&Time-" + DateTime.Now.Year.ToString() + '-' +
                                                DateTime.Now.Month.ToString() + '-' +
                                                DateTime.Now.Day.ToString() + '-' +
                                                DateTime.Now.ToLongTimeString() + ".log";
            filename = filename.Replace(':', '.');
            sw = new StreamWriter(File.Create(filename));
        }

        static public void Log_GLError(string className, string fileName, string methodName)
        {
            ErrorCode err = GL.GetError();
            if (err != ErrorCode.NoError)
                Logger.Log(className, fileName, methodName, err.ToString(), true);
            else
            {
                //Common.Logger.Log(className, fileName, methodName, err.ToString(), false);
            }
            
        }

        static public void CloseLog()
        {
            if (!firstRun)
                sw.Close();
        }
    }
}
