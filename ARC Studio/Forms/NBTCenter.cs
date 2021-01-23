using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ARC_Studio.Forms
{
    public partial class NBTCenter : MetroForm
    {
        public NBTCenter()
        {
            InitializeComponent();
            Directory.CreateDirectory(cacheDir);
            crosscheckfiles();
            reload(ps3Loaded);
        }

        string[] mods;
        string loadDirectory = ARC_Studio.Form1.url + "/ARC/nbt/mainList.txt";
        string appData = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ARC Studio/";
        string cacheDir = Environment.CurrentDirectory + "\\cache\\NBT\\";

        bool ps3Loaded = true;


        private void reload(bool checkNeeded)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        if ((client.DownloadString(ARC_Studio.Form1.url + "/ARC/nbt/locCenterAvailable.txt")) == "1")
                        {
                        }
                        else if ((client.DownloadString(ARC_Studio.Form1.url + "/ARC/nbt/locCenterAvailable.txt")) == "0")
                        {
                            MessageBox.Show("NBT Center is currently down for maintenance, sorry for any inconveniences");
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
                            Console.WriteLine(ARC_Studio.Form1.url + "/mod/nbts/" + mod + ".png");
                            HttpWebRequest textureFile = (HttpWebRequest)WebRequest.Create(ARC_Studio.Form1.url + "/mod/nbts/" + mod + ".png");
                            HttpWebResponse textureFileResponse = (HttpWebResponse)textureFile.GetResponse();

                            DateTime localImageModifiedTime = File.GetLastWriteTime(cacheDir + mod + ".png");
                            DateTime onlineImageModifiedTime = textureFileResponse.LastModified;
                            textureFileResponse.Dispose();
                            if (localImageModifiedTime >= onlineImageModifiedTime)
                            {

                            }
                            else
                            {
                                client.DownloadFile(ARC_Studio.Form1.url + "/mod/nbts/" + mod + ".png", cacheDir + mod + ".png");
                            }
                        }
                        else if (mod.Length == 0) { }
                        else if (File.Exists(cacheDir + mod + ".png") && checkNeeded == false)
                        {

                        }
                        else
                        {
                            // MessageBox.Show(mod + ".png");
                            Console.WriteLine(ARC_Studio.Form1.url + "/mod/nbts/" + mod + ".png", cacheDir + mod + ".png");
                            client.DownloadFile(ARC_Studio.Form1.url + "/mod/nbts/" + mod + ".png", cacheDir + mod + ".png");
                        }

                        if (File.Exists(cacheDir + mod + ".desc") && checkNeeded == true)
                        {
                            //desc cache
                            HttpWebRequest descFile = (HttpWebRequest)WebRequest.Create(ARC_Studio.Form1.url + "/mod/nbts/" + mod + ".desc");
                            HttpWebResponse descFileResponse = (HttpWebResponse)descFile.GetResponse();

                            DateTime localDescModifiedTime = File.GetLastWriteTime(cacheDir + mod + ".desc");
                            DateTime onlineDescModifiedTime = descFileResponse.LastModified;
                            descFileResponse.Dispose();

                            if (localDescModifiedTime >= onlineDescModifiedTime)
                            {

                            }
                            else
                            {
                                client.DownloadFile(ARC_Studio.Form1.url + "/mod/nbts/" + mod + ".desc", cacheDir + mod + ".desc");
                            }
                        }
                        else if (File.Exists(cacheDir + mod + ".png") && checkNeeded == false)
                        {

                        }
                        else if (mod.Length == 0) { }
                        else
                        {
                            client.DownloadFile(ARC_Studio.Form1.url + "/mod/nbts/" + mod + ".desc", cacheDir + mod + ".desc");
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
                MessageBox.Show("Couldn't connect to nbtCenter servers.. \n" + err.Message.ToString() + "\n" + err.ToString());
            }
        }


        public void crosscheckfiles()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        List<string> deleteList = new List<string>();
                        foreach (string file in Directory.GetFiles(cacheDir))
                            if (!client.DownloadString(loadDirectory).Contains(Path.GetFileNameWithoutExtension(file)) && Path.GetExtension(file) == ".desc")
                            {
                                deleteList.Add(file);
                            }
                        foreach (string file in deleteList)
                        {
                            File.Delete(file);
                            File.Delete(Path.GetFileNameWithoutExtension(file) + ".png");
                        }

                    }
                    catch (Exception connect)
                    {
                        MessageBox.Show(connect.ToString());
                    }
                }
            }
            catch { }
        }


        private void radioButtonPS3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonPS3.Checked == true)
            {
                try
                {
                    loadDirectory = ARC_Studio.Form1.url + "/ARC/nbt/mainList.txt";
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
            Directory.CreateDirectory(appData + "/nbtCenter/mynbts/");
            List<string> pckFiles = Directory.GetFiles(appData + "/nbtCenter/mynbts/", "*.*", SearchOption.AllDirectories).Where(file => new string[] { ".nbt" }.Contains(Path.GetExtension(file))).ToList();
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

                string[] parseDesc = File.ReadAllText(appData + "/nbtCenter/mynbts/" + mod.Split(new[] { "__" }, StringSplitOptions.None)[0] + ".desc").Split('\n');
                pckName += parseDesc[0];
                author += parseDesc[1];
                desc += parseDesc[2];
                direct += parseDesc[3];
                ad += parseDesc[4];


                string filename = appData + "/nbtCenter/mynbts/" + mod.Split(new[] { "__" }, StringSplitOptions.None)[0] + ".png";

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
            System.Diagnostics.Process.Start("mailto:felix.millerarc@gmail.com?subject=NBT%20Submission&body=Name%3A%0ACreator%3A%0AOriginal%20Structure%20Name%3A");
        }

        private void NBTCenter_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(cacheDir);
        }
    }
}
