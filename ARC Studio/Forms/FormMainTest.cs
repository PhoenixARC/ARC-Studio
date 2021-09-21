using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using ARC_Studio.Workers;
using System.Drawing.Drawing2D;

namespace ARC_Studio.Forms
{
    public partial class FormMainTest : Form
    {
        public FormMainTest(int debug)
        {
            InitializeComponent();

            #region if debugging :: developer build label shown

            if (debug == 0)
            {
                DEVELOPERLABEL.Visible = false;
            }
            else
            {
                DEVELOPERLABEL.Visible = true;
            }
            if(IsDark)
            {
                TextColor = Color.FromArgb(255, 255, 255, 255);
                NormalBG = Color.FromArgb(255, 12, 12, 12);
                SlightTintBG = Color.FromArgb(255, 64, 64, 64);
            }

            #endregion
        }

        #region Variables

        #region GUI
        Color TextColor = Color.FromArgb(255, 0, 0, 0);
        Color NormalBG = Color.FromArgb(255, 255, 255, 255);
        Color SlightTintBG = Color.FromArgb(255, 224, 224, 224);
        #endregion

        public string arcfile = "";
        public string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ARC_Data\\Media\\";
        public static string url = "http://pckstudio.tk/studio/ARC/api";
        string version = "1.9";

        bool IsPortable = false;
        bool IsDark = true;

        string saveLocation;//Save location for pck file
        int fileCount = 0;//variable for number of minefiles
        PCK.MineFile mf;//Template minefile variable
        PCK currentPCK;//currently opened pck
        PCK.MineFile mfLoc;//LOC minefile
        Dictionary<int, string> types;//Template list for metadata of a individual minefiles metadata
        PCK.MineFile file;//template for a selected minefile
        bool needsUpdate = false;
        bool saved = true;

        #endregion


        #region Loading form

        private void Form1_Load(object sender, EventArgs e)
        {
            try // Extract Files
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\BinkMan");
                File.WriteAllBytes(Environment.CurrentDirectory + "\\BinkMan\\BinkMan.exe", Properties.Resources.BinkMan);
                File.WriteAllText(Environment.CurrentDirectory + "\\BinkMan\\files.txt", Properties.Resources.files);
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\FUIEditor");
                File.WriteAllBytes(Environment.CurrentDirectory + "\\FUIEditor\\FUI Studio.exe", Properties.Resources.FUI_Studio);
                File.WriteAllBytes(Environment.CurrentDirectory + "\\FUIEditor\\Mojangles.ttf", Properties.Resources.Mojangles);
                File.WriteAllBytes(Environment.CurrentDirectory + "\\FUIEditor\\updater.exe", Properties.Resources.updaterFUIStudio);
                File.WriteAllText(Environment.CurrentDirectory + "\\FUIEditor\\change.log", Properties.Resources.change);
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\NBTEditor");
                File.WriteAllBytes(Environment.CurrentDirectory + "\\NBTEditor\\NBTExplorer.exe", Properties.Resources.NBTExplorer);
                File.WriteAllBytes(Environment.CurrentDirectory + "\\NBTEditor\\NBTModel.dll", Properties.Resources.NBTModel);
                File.WriteAllBytes(Environment.CurrentDirectory + "\\NBTEditor\\Substrate.dll", Properties.Resources.Substrate);
                File.WriteAllBytes(Environment.CurrentDirectory + "\\ARCUpdater.exe", Properties.Resources.ARCUpdater);
                if (!File.Exists(Environment.CurrentDirectory + "\\settings.ini"))
                    File.WriteAllText(Environment.CurrentDirectory + "\\settings.ini", "**Settings** \nyou can change a variable here!\n**true / false does not accept capitals, 'True' and 'TRUE' do not work, ony 'true'\nIsPortable=" + IsPortable.ToString().Replace("T", "t").Replace("F", "f"));
                //Directory.CreateDirectory(Environment.CurrentDirectory + "\\Resources");
                //File.WriteAllBytes(Environment.CurrentDirectory + "\\Resources\\FUI_Studio", Properties.Resources.FUI_Studio);
                //File.WriteAllBytes(Environment.CurrentDirectory + "\\Resources\\Mojangles", Properties.Resources.Mojangles);
                //File.WriteAllBytes(Environment.CurrentDirectory + "\\Resources\\updaterFUIStudio", Properties.Resources.updaterFUIStudio);
                //File.WriteAllText(Environment.CurrentDirectory + "\\Resources\\change", Properties.Resources.change);
                //File.WriteAllBytes(Environment.CurrentDirectory + "\\Resources\\BinkMan", Properties.Resources.BinkMan);
                //File.WriteAllText(Environment.CurrentDirectory + "\\Resources\\files", Properties.Resources.files);
                //File.WriteAllBytes(Environment.CurrentDirectory + "\\Resources\\NBTExplorer", Properties.Resources.NBTExplorer);
                //File.WriteAllBytes(Environment.CurrentDirectory + "\\Resources\\NBTModel", Properties.Resources.NBTModel);
                //File.WriteAllBytes(Environment.CurrentDirectory + "\\Resources\\Substrate", Properties.Resources.Substrate);
                //File.WriteAllBytes(Environment.CurrentDirectory + "\\Resources\\ARCUpdater", Properties.Resources.ARCUpdater);
            }
            catch { }
            try // Checks if portable flag is checked in settings
            {
                string Data = File.ReadAllText(Environment.CurrentDirectory + "\\settings.ini");
                string[] Lines = Data.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                foreach (string Line in Lines)
                {
                    try
                    {
                        string Param = Line.Split('=')[0];
                        string Value = Line.Split('=')[1];
                        Console.WriteLine(Param + "=" + Value);
                        switch (Param)
                        {
                            case ("IsPortable"):
                                IsPortable = (Value == "true");
                                break;
                        }
                    }
                    catch { }

                }
            }
            catch { }
            try // Determine Location based on portable status
            {
                if (!IsPortable)
                    appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ARC_Data\\Media\\";
                else
                    appdata = Environment.CurrentDirectory + "\\ARC_Data\\Media\\";
            }
            catch
            {

            }
            try //Create Folders
            {
                if (!Directory.Exists(appdata))
                    Directory.CreateDirectory(appdata);
            }
            catch { }
            VersionLabel.Text = "Version: " + version;
            try
            {
                new System.Net.WebClient().DownloadString("http://www.pckstudio.tk/studio/ARC/api");
                System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\url.txt", "http://www.pckstudio.tk/studio/ARC/api");
            }
            catch
            {
                System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\url.txt", "http://phoenixarc.github.io/pckstudio.tk/studio/ARC/api");
                url = "http://phoenixarc.github.io/pckstudio.tk/studio/ARC/api";
            }
            try
            {
                if (float.Parse(new System.Net.WebClient().DownloadString(url + "/ARC_Center_update.txt")) > float.Parse(version))
                {

                    if (MessageBox.Show("Update Avaliable\nDownload?", "Alert!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\ARCUpdater.exe");
                    }
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("Servers Offline!\nOnline services have been disabled!");
                openLOCCenterToolStripMenuItem.Enabled = false;
                openNBTCenterToolStripMenuItem.Enabled = false;
                openToolStripMenuItem1.Enabled = false;
            }
            ReloadColors();
        }

        public void ReloadColors()
        {
            try
            {
                 //Normal Text
                openToolStripMenuItem.ForeColor = TextColor;
                extractToolStripMenuItem1.ForeColor = TextColor;
                saveToolStripMenuItem1.ForeColor = TextColor;
                saveToolStripMenuItem.ForeColor = TextColor;
                fileToolStripMenuItem.ForeColor = TextColor;
                helpToolStripMenuItem.ForeColor = TextColor;
                storeToolStripMenuItem.ForeColor = TextColor;
                openToolStripMenuItem1.ForeColor = TextColor;
                openLOCCenterToolStripMenuItem.ForeColor = TextColor;
                openNBTCenterToolStripMenuItem.ForeColor = TextColor;
                donateToolStripMenuItem.ForeColor = TextColor;
                gUIConfigToolStripMenuItem.ForeColor = TextColor;
                programInfoToolStripMenuItem.ForeColor = TextColor;
                reportABugToolStripMenuItem.ForeColor = TextColor;
                SizeLabel.ForeColor = TextColor;
                VersionLabel.ForeColor = TextColor;
                tabControl1.ForeColor = TextColor;
                EntryList.ForeColor = TextColor;
                tabPage1.ForeColor = TextColor;
                richTextBox1.ForeColor = TextColor;

                //WhiteBG
                openToolStripMenuItem.BackColor = NormalBG;
                extractToolStripMenuItem1.BackColor = NormalBG;
                saveToolStripMenuItem1.BackColor = NormalBG;
                saveToolStripMenuItem.BackColor = NormalBG;
                fileToolStripMenuItem.BackColor = NormalBG;
                helpToolStripMenuItem.BackColor = NormalBG;
                storeToolStripMenuItem.BackColor = NormalBG;
                openToolStripMenuItem1.BackColor = NormalBG;
                openLOCCenterToolStripMenuItem.BackColor = NormalBG;
                openNBTCenterToolStripMenuItem.BackColor = NormalBG;
                donateToolStripMenuItem.BackColor = NormalBG;
                gUIConfigToolStripMenuItem.BackColor = NormalBG;
                programInfoToolStripMenuItem.BackColor = NormalBG;
                reportABugToolStripMenuItem.BackColor = NormalBG;
                SizeLabel.BackColor = NormalBG;
                VersionLabel.BackColor = NormalBG;
                tabControl1.BackColor = NormalBG;
                EntryList.BackColor = NormalBG;
                tabPage1.BackColor = NormalBG;
                richTextBox1.BackColor = NormalBG;
                menuStrip.BackColor = NormalBG;
                DEVELOPERLABEL.BackColor = NormalBG;
                this.BackColor = NormalBG;

                //SlightTintBG
                EntryList.BackColor = SlightTintBG;
            }
            catch { }
        }

        #endregion


        private void gUIConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadColors();
        }
    }
}
