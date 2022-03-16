using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace ARC_Studio.Classes
{
    class Network
    {
        static string Version = "2.1";
        public static bool Beta = true;
        public static bool NeedsUpdate = false;
        public static string MainURL = "http://pckstudio.xyz/";
        public static string BackURL = "http://phoenixarc.ddns.net/";
        static string UpdateURL = "studio/ARC/api/ARC_Center_update.txt";
        static string BetaUpdateURL = "studio/ARC/api/ARC_Center_updateB.txt";

        public static void CheckUpdate()
        {
            WebClient wc = new WebClient();
            string docuDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            try
            {
                switch (Beta)
                {
                    case false:
                        if (float.Parse(Version) < float.Parse(wc.DownloadString(MainURL + UpdateURL)))
                        {
                            if (MessageBox.Show("An update is available! do you want to update?\nYour Version:" + Version + "\nAvailable version:" + wc.DownloadString(MainURL + UpdateURL), "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Classes.Update.UpdateProgram(Beta);
                            }
                            else
                            {
                                NeedsUpdate = true;
                            }
                        }
                        break;
                    case true:
                        if (float.Parse(Version) < float.Parse(wc.DownloadString(MainURL + BetaUpdateURL)))
                        {
                            if (MessageBox.Show("An update is available! do you want to update?\nYour Version:" + Version + "\nAvailable version:" + wc.DownloadString(MainURL + BetaUpdateURL), "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Classes.Update.UpdateProgram(Beta);
                            }
                            else
                            {
                                NeedsUpdate = true;
                            }
                        }
                        break;
                }
            }
            catch
            {
                try
                {
                    switch (Beta)
                    {
                        case false:
                            if (float.Parse(Version) < float.Parse(wc.DownloadString(BackURL + UpdateURL)))
                            {
                                if (MessageBox.Show("An update is available! do you want to update?\nYour Version:" + Version + "\nAvailable version:" + wc.DownloadString(BackURL + UpdateURL), "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Classes.Update.UpdateProgram(Beta);
                                }
                                else
                                {
                                    NeedsUpdate = true;
                                }
                            }
                            break;
                        case true:
                            if (float.Parse(Version) < float.Parse(wc.DownloadString(BackURL + BetaUpdateURL)))
                            {
                                if (MessageBox.Show("An update is available! do you want to update?\nYour Version:" + Version + "\nAvailable version:" + wc.DownloadString(BackURL + UpdateURL), "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Classes.Update.UpdateProgram(Beta);
                                }
                                else
                                {
                                    NeedsUpdate = true;
                                }
                            }
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Server unavailabe", "Cannot connect to the server!");
                }
            }
        }


    }
}
