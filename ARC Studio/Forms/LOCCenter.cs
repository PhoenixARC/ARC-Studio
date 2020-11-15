using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Net;
using System.IO;

namespace ARC_Studio.Forms
{
    public partial class LOCCenter : MetroForm
    {
        public LOCCenter()
        {
            InitializeComponent();
            reload(ps3Loaded);
        }

        string[] mods;
        string loadDirectory = ARC_Studio.Form1.url + "/ARC/loc/ps3List.txt";
        string appData = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ARC Studio/";
        string cacheDir;

        bool ps3Loaded = true;
        bool xb360Loaded = true;
        bool WiiULoaded = true;


        private void reload(bool checkNeeded)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        if ((client.DownloadString(ARC_Studio.Form1.url + "/ARC/loc/locCenterAvailable.txt")) == "1")
                        {
                        }
                        else if ((client.DownloadString(ARC_Studio.Form1.url + "/ARC/loc/locCenterAvailable.txt")) == "0")
                        {
                            MessageBox.Show("LOC Center is currently down for maintenance, sorry for any inconveniences");
                            radioButtonMine.Checked = true;
                            return;
                        }
                        else
                        {

                        }
                    }
                    catch (Exception connect)
                    {
                        MessageBox.Show(connect.ToString());
                    }
                }

                using (WebClient client = new WebClient())
                {
                    string parseContent = client.DownloadString(loadDirectory);
                    Console.WriteLine(loadDirectory);
                    string id = "";
                    mods = parseContent.Split('\n');

                    int controlCount = pckLayout.Controls.Count;
                    for (int i = controlCount - 1; i >= 0; i--)
                    {
                        Control control = pckLayout.Controls[i];

                        pckLayout.Controls.Remove(control);
                        control.Dispose();
                    }

                    foreach (string mod in mods)
                    {
                        if (File.Exists(cacheDir + mod + ".png") && checkNeeded == true)
                        {
                            //image cache
                            Console.WriteLine(ARC_Studio.Form1.url + "/mod/locs/" + mod + ".png");
                            HttpWebRequest textureFile = (HttpWebRequest)WebRequest.Create(ARC_Studio.Form1.url + "/mod/locs/" + mod + ".png");
                            HttpWebResponse textureFileResponse = (HttpWebResponse)textureFile.GetResponse();

                            DateTime localImageModifiedTime = File.GetLastWriteTime(cacheDir + mod + ".png");
                            DateTime onlineImageModifiedTime = textureFileResponse.LastModified;
                            textureFileResponse.Dispose();
                            if (localImageModifiedTime >= onlineImageModifiedTime)
                            {

                            }
                            else
                            {
                                client.DownloadFile(ARC_Studio.Form1.url + "/mod/locs/" + mod + ".png", cacheDir + mod + ".png");
                            }
                        }
                        else if (mod.Length == 0) { }
                        else if (File.Exists(cacheDir + mod + ".png") && checkNeeded == false)
                        {

                        }
                        else
                        {
                            // MessageBox.Show(mod + ".png");
                            Console.WriteLine(ARC_Studio.Form1.url + "/mod/locs/" + mod + ".png", cacheDir + mod + ".png");
                            client.DownloadFile(ARC_Studio.Form1.url + "/mod/locs/" + mod + ".png", cacheDir + mod + ".png");
                        }

                        if (File.Exists(cacheDir + mod + ".desc") && checkNeeded == true)
                        {
                            //desc cache
                            HttpWebRequest descFile = (HttpWebRequest)WebRequest.Create(ARC_Studio.Form1.url + "/mod/locs/" + mod + ".desc");
                            HttpWebResponse descFileResponse = (HttpWebResponse)descFile.GetResponse();

                            DateTime localDescModifiedTime = File.GetLastWriteTime(cacheDir + mod + ".desc");
                            DateTime onlineDescModifiedTime = descFileResponse.LastModified;
                            descFileResponse.Dispose();

                            if (localDescModifiedTime >= onlineDescModifiedTime)
                            {

                            }
                            else
                            {
                                client.DownloadFile(ARC_Studio.Form1.url + "/mod/locs/" + mod + ".desc", cacheDir + mod + ".desc");
                            }
                        }
                        else if (File.Exists(cacheDir + mod + ".png") && checkNeeded == false)
                        {

                        }
                        else if (mod.Length == 0) { }
                        else
                        {
                            client.DownloadFile(ARC_Studio.Form1.url + "/mod/locs/" + mod + ".desc", cacheDir + mod + ".desc");
                        }
                        if (mod.Length != 0)
                        {
                            string[] parseDesc = File.ReadAllText(cacheDir + mod + ".desc").Split('\n');
                            Bitmap bmp = new Bitmap(Image.FromFile(cacheDir + mod + ".png"));
                            string pckName = parseDesc[0];
                            string author = parseDesc[1];
                            string desc = parseDesc[2];
                            string direct = parseDesc[3];
                            string ad = parseDesc[4];

                            PckPreview pckPreview = new PckPreview(pckName, author, desc, direct, ad, bmp, 0, mod, null);
                            pckLayout.Controls.Add(pckPreview);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Couldn't connect to loc Center servers.. \n" + err.Message.ToString() + "\n" + err.ToString());
            }
        }


        private void radioButtonPS3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonPS3.Checked == true)
            {
                try
                {
                    loadDirectory = ARC_Studio.Form1.url + "/ARC/loc/ps3List.txt";
                    Console.WriteLine(loadDirectory);
                    if (new WebClient().DownloadString(loadDirectory) != " ")
                    {
                        Console.Write(new WebClient().DownloadString(loadDirectory));
                        reload(ps3Loaded);
                        ps3Loaded = false;
                    }
                    else { MessageBox.Show("No Packs Avaliable!"); }
                }
                catch
                {

                }
            }
        }

        private void radioButtonXBox360_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonXBox360.Checked == true)
            {
                try
                {
                    loadDirectory = ARC_Studio.Form1.url + "/ARC/loc/xb360List.txt";
                    if (new WebClient().DownloadString(loadDirectory) != " ")
                    {
                        reload(ps3Loaded);
                        xb360Loaded = false;
                    }
                    else { MessageBox.Show("No Packs Avaliable!"); }
                }
                catch
                {

                }
            }
        }

        private void radioButtonWiiU_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWiiU.Checked == true)
            {
                try
                {
                    loadDirectory = ARC_Studio.Form1.url + "/ARC/loc/wiiuList.txt";
                    if (new WebClient().DownloadString(loadDirectory) != " ")
                    {
                        reload(ps3Loaded);
                        WiiULoaded = false;
                    }
                    else { MessageBox.Show("No Packs Avaliable!"); }
                }
                catch
                {

                }
            }
        }

        private void radioButtonMine_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonMine.Checked == true)
            {
                loadCollectdion();
            }
        }


        private void loadCollectdion()
        {
            int controlCount = pckLayout.Controls.Count;
            for (int i = controlCount - 1; i >= 0; i--)
            {
                Control control = pckLayout.Controls[i];

                pckLayout.Controls.Remove(control);
                control.Dispose();
            }

            pckLayout.Enabled = false;
            Directory.CreateDirectory(appData + "/loc Center/mylocs/");
            List<string> pckFiles = Directory.GetFiles(appData + "/loc Center/mylocs/", "*.*", SearchOption.AllDirectories).Where(file => new string[] { ".loc" }.Contains(Path.GetExtension(file))).ToList();
            foreach (string pck in pckFiles)
            {
                int line = 0;
                string pckName = "";
                string author = "";
                string desc = "";
                string direct = "";
                string ad = "";

                string mod = Path.GetFileName(pck);
                mod = Path.GetFileNameWithoutExtension(mod);

                string[] parseDesc = File.ReadAllText(appData + "/loc Center/mylocs/" + mod.Split(new[] { "__" }, StringSplitOptions.None)[0] + ".desc").Split('\n');
                pckName += parseDesc[0];
                author += parseDesc[1];
                desc += parseDesc[2];
                direct += parseDesc[3];
                ad += parseDesc[4];


                string filename = appData + "/loc Center/mylocs/" + mod.Split(new[] { "__" }, StringSplitOptions.None)[0] + ".png";

                Bitmap bmp = null;
                using (FileStream memStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    bmp = (Bitmap)Image.FromStream(memStream);
                }

                PckPreview pckPreview = new PckPreview(pckName, author, desc, direct, ad, bmp, 1, mod.Split(new[] { "__" }, StringSplitOptions.None)[0], loadCollectdion);
                pckLayout.Controls.Add(pckPreview);
            }
            pckLayout.Enabled = true;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:felix.millerarc@gmail.com?subject=LOC%20Submission&body=Name%3A%0ACreator%3A");
        }
    }
}

