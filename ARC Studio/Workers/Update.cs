﻿using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ARC_Studio.Classes
{
    class Update
    {
        static string UpdateURL = "Download/setup/ARCStudio-Setup.msi";
        static string BetaUpdateURL = "Download/setup/beta/ARCStudioBeta-Setup.msi";

        public static void UpdateProgram(bool Beta)
        {
            Forms.FakeProgressBar fb = new Forms.FakeProgressBar();
            Thread thr = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                fb.ShowDialog();
            });
                string DLPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\";
            try
            {
                switch (Beta)
                {
                    case true:
                        thr.Start();
                        try
                        {
                            DownloadFile(DLPath + Path.GetFileName(Classes.Network.MainURL + BetaUpdateURL), Classes.Network.MainURL + BetaUpdateURL);
                            Process.Start(DLPath + Path.GetFileName(Classes.Network.MainURL + BetaUpdateURL));
                            Application.Exit();
                        }
                        catch(WebException ex)
                        {
                            Console.WriteLine(ex.Message);
                            DownloadFile(DLPath + Path.GetFileName(Classes.Network.BackURL + BetaUpdateURL), Classes.Network.BackURL + BetaUpdateURL);
                            Process.Start(DLPath + Path.GetFileName(Classes.Network.BackURL + BetaUpdateURL));
                            Application.Exit();
                        }
                        break;
                    case false:
                        thr.Start();
                        try
                        {
                            DownloadFile(DLPath + Path.GetFileName(Classes.Network.MainURL + UpdateURL), Classes.Network.MainURL + UpdateURL);
                            Process.Start(DLPath + Path.GetFileName(Classes.Network.MainURL + UpdateURL));
                            Application.Exit();
                        }
                        catch
                        {
                            DownloadFile(DLPath + Path.GetFileName(Classes.Network.BackURL + UpdateURL), Classes.Network.BackURL + UpdateURL);
                            Process.Start(DLPath + Path.GetFileName(Classes.Network.BackURL + UpdateURL));
                            Application.Exit();
                        }
                        break;
                }
            }
            catch
            {
                thr.Abort();
                MessageBox.Show("Could not update!");
            }
        }

        static void DownloadFile(string FillePath, string URL)
        {
            string remoteUri = Path.GetDirectoryName(URL);

            WebClient myWebClient = new WebClient();

            //Console.WriteLine("myWebClient.DownloadFile("+URL+", "+FillePath+");");
            myWebClient.DownloadFile(URL, FillePath);
        }
    }
}
