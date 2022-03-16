using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARC_Studio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool UseAlt = false ;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (UseAlt)
            {
                if (args.Contains<string>("-d"))
                    Application.Run(new Forms.FormMainTest(1));
                else
                    Application.Run(new Forms.FormMainTest(0));
            }
            else
            {
                if (args.Contains<string>("-d"))
                    Application.Run(new Form1(1));
                else
                    Application.Run(new Form1(0));
            }
        }
    }
}
