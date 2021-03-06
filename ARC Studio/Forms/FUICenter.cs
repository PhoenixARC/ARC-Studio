﻿using System;
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
    public partial class FUICenter : MetroForm
    {
        #region variables
        string[] mods;
        string loadDirectory = ARC_Studio.Form1.url + "/fui/ps3List.txt";
        string appData = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + " Studio/";
        string cacheDir = Environment.CurrentDirectory + "\\cache\\FUI\\";

        bool ps3Loaded = true;
        bool xb360Loaded = true;
        bool WiiULoaded = true;
        #endregion

        public FUICenter()
        {
            InitializeComponent();
            Directory.CreateDirectory(cacheDir);
            crosscheckfiles();
            reload(ps3Loaded);
        }

        #region load data to List

        private void reload(bool checkNeeded)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        if ((client.DownloadString(ARC_Studio.Form1.url + "/fui/fuiCenterAvailable.txt")) == "1")
                        {
                        }
                        else if ((client.DownloadString(ARC_Studio.Form1.url + "/fui/fuiCenterAvailable.txt")) == "0")
                        {
                            MessageBox.Show("FUI Center is currently down for maintenance, sorry for any inconveniences");
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
                            HttpWebRequest textureFile = (HttpWebRequest)WebRequest.Create(ARC_Studio.Form1.url + "/mod/fuis/" + mod + ".png");
                            HttpWebResponse textureFileResponse = (HttpWebResponse)textureFile.GetResponse();

                            DateTime localImageModifiedTime = File.GetLastWriteTime(cacheDir + mod + ".png");
                            DateTime onlineImageModifiedTime = textureFileResponse.LastModified;
                            textureFileResponse.Dispose();
                            if (localImageModifiedTime >= onlineImageModifiedTime)
                            {

                            }
                            else
                            {
                                client.DownloadFile(ARC_Studio.Form1.url + "/mod/fuis/" + mod + ".png", cacheDir + mod + ".png");
                            }
                        }
                        else if (mod.Length == 0) { }
                        else if (File.Exists(cacheDir + mod + ".png") && checkNeeded == false)
                        {

                        }
                        else
                        {
                            // MessageBox.Show(mod + ".png");
                            Console.WriteLine(ARC_Studio.Form1.url + "/mod/fuis/" + mod + ".png", cacheDir + mod + ".png");
                            client.DownloadFile(ARC_Studio.Form1.url + "/mod/fuis/" + mod + ".png", cacheDir + mod + ".png");
                        }

                        if (File.Exists(cacheDir + mod + ".desc") && checkNeeded == true)
                        {
                            //desc cache
                            HttpWebRequest descFile = (HttpWebRequest)WebRequest.Create(ARC_Studio.Form1.url + "/mod/fuis/" + mod + ".desc");
                            HttpWebResponse descFileResponse = (HttpWebResponse)descFile.GetResponse();

                            DateTime localDescModifiedTime = File.GetLastWriteTime(cacheDir + mod + ".desc");
                            DateTime onlineDescModifiedTime = descFileResponse.LastModified;
                            descFileResponse.Dispose();

                            if (localDescModifiedTime >= onlineDescModifiedTime)
                            {

                            }
                            else
                            {
                                client.DownloadFile(ARC_Studio.Form1.url + "/mod/fuis/" + mod + ".desc", cacheDir + mod + ".desc");
                            }
                        }
                        else if (File.Exists(cacheDir + mod + ".png") && checkNeeded == false)
                        {

                        }
                        else if (mod.Length == 0) { }
                        else
                        {
                            client.DownloadFile(ARC_Studio.Form1.url + "/mod/fuis/" + mod + ".desc", cacheDir + mod + ".desc");
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
                MessageBox.Show("Couldn't connect to FUI Center servers.. \n" + err.Message.ToString() + "\n" + err.ToString());
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
                        foreach(string file in Directory.GetFiles(cacheDir))
                        if (!client.DownloadString(loadDirectory).Contains(Path.GetFileNameWithoutExtension(file)) && Path.GetExtension(file) == ".desc")
                        {
                                deleteList.Add(file);
                        }
                        foreach(string file in deleteList)
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

        #endregion

        #region Menus

        private void radioButtonPS3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonPS3.Checked == true)
            {
                try
                {
                    loadDirectory = ARC_Studio.Form1.url + "/fui/ps3List.txt";
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
                        loadDirectory = ARC_Studio.Form1.url + "/fui/xb360List.txt";
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
                    loadDirectory = ARC_Studio.Form1.url + "/fui/wiiuList.txt";
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

        #endregion

        #region load local files

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
            Directory.CreateDirectory(appData + "/FUI Center/myFuis/");
            List<string> pckFiles = Directory.GetFiles(appData + "/FUI Center/myFuis/", "*.*", SearchOption.AllDirectories).Where(file => new string[] { ".fui" }.Contains(Path.GetExtension(file))).ToList();
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

                string[] parseDesc = File.ReadAllText(appData + "/FUI Center/myFuis/" + mod.Split(new[] { "__" }, StringSplitOptions.None)[0] + ".desc").Split('\n');
                pckName += parseDesc[0];
                author += parseDesc[1];
                desc += parseDesc[2];
                direct += parseDesc[3];
                ad += parseDesc[4];


                string filename = appData + "/FUI Center/myFuis/" + mod.Split(new[] { "__" }, StringSplitOptions.None)[0] + ".png";

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

        #endregion

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:felix.millerarc@gmail.com?subject=FUI%20Submission&body=Name%3A%0ACreator%3A%0AOriginal%20FUI%20Name%3A");
        }

        private void FUICenter_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(cacheDir);
        }
    }


    public class PckPreview : UserControl
    {
        string name;
        string author;
        string desc;
        string direct;
        string ad;
        int mode;
        string mod;

        Bitmap icon;

        PictureBox iconBox = new PictureBox();
        public MyNameLabel nameLabel = new MyNameLabel();
        MyTablePanel layout = new MyTablePanel();
        MethodInvoker reloader;


        public class MyTablePanel : TableLayoutPanel
        {
            public PckPreview parentPreview;

            protected override void OnMouseEnter(EventArgs e)
            {
            }
            protected override void OnMouseLeave(EventArgs e)
            {
            }
            protected override void OnMouseClick(MouseEventArgs e)
            {
            }
            protected override void OnMouseDoubleClick(MouseEventArgs e)
            {
            }
        }

        public class MyNameLabel : Label
        {
            public PckPreview parentPreview;

            protected override void OnMouseEnter(EventArgs e)
            {
                parentPreview.setHover(true);
                base.OnMouseEnter(e);
            }
            protected override void OnMouseLeave(EventArgs e)
            {
                parentPreview.setHover(false);
                base.OnMouseLeave(e);
            }
            protected override void OnMouseClick(MouseEventArgs e)
            {
                parentPreview.onClick();
                base.OnMouseClick(e);
            }
        }

        public PckPreview(string name, string author, string desc, string direct, string ad, Bitmap icon, int mode, string mod, MethodInvoker Reloader) : base()
        {
            this.reloader = Reloader;
            nameLabel.parentPreview = this;
            layout.parentPreview = this;
            this.name = name;
            this.author = author;
            this.desc = desc;
            this.direct = direct;
            this.ad = ad;
            this.mode = mode;
            this.mod = mod;
            this.icon = icon;
            layout.BackColor = Color.White;
            this.Size = new Size(250, 280);
            nameLabel.Dock = DockStyle.Fill;
            nameLabel.Location = new Point(0, 0);
            nameLabel.Size = new Size(230, 30);
            iconBox.Image = icon;
            //iconBox.Dock = DockStyle.Fill;
            iconBox.Anchor = AnchorStyles.None;
            nameLabel.Text = name;
            iconBox.SizeMode = PictureBoxSizeMode.StretchImage;
            iconBox.Size = new Size(230, 230);
            layout.Margin = new Padding(0, 0, 0, 0);
            this.Margin = new Padding(20, 15, 20, 15);
            nameLabel.ForeColor = Color.Black;
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            layout.Controls.Add(iconBox, 0, 1);
            layout.Controls.Add(nameLabel, 0, 0);
            layout.Parent = this;
            layout.Dock = DockStyle.Fill;
            iconBox.Enabled = false;

        }

        public void setHover(bool hover)
        {
            if (hover)
            {
                layout.BackColor = Color.LightGray;
            }
            else
            {
                layout.BackColor = Color.White;
            }
            layout.Refresh();
        }
        public void onClick()
        {
            layout.BackColor = Color.Gray;
            layout.Refresh();
           Forms.FUICenterOpen openPck = new Forms.FUICenterOpen(name, author, desc, direct, ad, icon, mode, mod, reloader);
            openPck.ShowDialog();
        }
        public void onDoubleClick()
        {

        }
    }
}
