using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;
using System.Runtime.InteropServices;
namespace OrthoAid_3DSimulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void eh(object sender, ThreadExceptionEventArgs e)
        //{
        //}

        //static void eh2(object sender, UnhandledExceptionEventArgs e)
        //{
        //}

        static void Main()
        {
            
            MainForm.config = Common.Configuration.LoadConfig();            
            

            bool debug = false;            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());

            //commented for debug        
            
        }

        

        
    }
}
