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
using System.IO;
using System.Net;

namespace ARC_Studio.Forms
{
    public partial class FUICenterOpen : MetroForm
    {
        string name;
        string author;
        string desc;
        string direct;
        string origname;
        int mode = 0;
        string mod;
        string appData = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ARC Studio/";
        MethodInvoker reloader;

        public FUICenterOpen(string name, string authorIn, string descIn, string directIn, string adIn, Bitmap display, int mode, string mod, MethodInvoker reloader)
        {
            InitializeComponent();
            pictureBoxDisplay.Image = display;
            labelDesc.Text = descIn;

            this.reloader = reloader;
            this.mode = mode;
            this.mod = mod;
            this.reloader = reloader;

            this.name = name;
            author = authorIn;
            desc = descIn;
            direct = directIn;
            origname = adIn;
        }

        private void buttonDirect_Click(object sender, EventArgs e)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    if (direct.EndsWith(".fui"))
                    {
                    Console.WriteLine(direct);
                    Console.WriteLine(direct.Replace(".fui", ".desc"));
                    Console.WriteLine(direct.Replace(".fui", ".png"));
                        client.DownloadFile(direct, appData + "/FUI Center/myFuis/" + mod + "__" + origname + ".fui");
                        client.DownloadFile(direct.Replace(".fui", ".desc"), appData + "/FUI Center/myFuis/" + mod + ".desc");
                        client.DownloadFile(direct.Replace(".fui", ".png"), appData + "/FUI Center/myFuis/" + mod + ".png");
                    }
                    else if (direct.EndsWith(".loc"))
                    {
                        Console.WriteLine(direct);
                        Console.WriteLine(direct.Replace(".loc", ".desc"));
                        Console.WriteLine(direct.Replace(".loc", ".png"));
                        client.DownloadFile(direct, appData + "/LOC Center/myLocs/" + mod + "__" + origname + ".loc");
                        client.DownloadFile(direct.Replace(".loc", ".desc"), appData + "/LOC Center/myLocs/" + mod + ".desc");
                        client.DownloadFile(direct.Replace(".loc", ".png"), appData + "/LOC Center/myLocs/" + mod + ".png");
                    }
                    else if (direct.EndsWith(".nbt"))
                    {
                        Console.WriteLine(direct);
                        Console.WriteLine(direct.Replace(".nbt", ".desc"));
                        Console.WriteLine(direct.Replace(".nbt", ".png"));
                        client.DownloadFile(direct, appData + "/NBT Center/myNbts/" + mod + "__" + origname + ".nbt");
                        client.DownloadFile(direct.Replace(".nbt", ".desc"), appData + "/NBT Center/myNbts/" + mod + ".desc");
                        client.DownloadFile(direct.Replace(".nbt", ".png"), appData + "/NBT Center/myNbts/" + mod + ".png");
                    }

                    MessageBox.Show("Downloaded!");
                        this.Close();
                }
            }
            catch(WebException err)
            {
                MessageBox.Show(err.ToString());
            }
            
            catch
            {

            }
        }

        private void FUICenterOpen_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(appData + "/FUI Center/myFuis/");
            Directory.CreateDirectory(appData + "/LOC Center/myLocs/");
            Directory.CreateDirectory(appData + "/NBT Center/myNbts/");
            if (direct.EndsWith(".fui"))
            {
                if (File.Exists(appData + "/FUI Center/myFuis/" + mod + "__" + origname + ".fui") && File.Exists(appData + "/FUI Center/myFuis/" + mod + ".desc") && File.Exists(appData + "/FUI Center/myFuis/" + mod + ".png"))
                {
                    buttonDelete.Visible = true;
                    buttonExport.Visible = true;
                    buttonDirect.Visible = false;
                }
                else
                {
                    buttonDelete.Visible = false;
                    buttonExport.Visible = false;
                    buttonDirect.Visible = true;
                }
            }
            else if (direct.EndsWith(".loc"))
            {
                if (File.Exists(appData + "/LOC Center/myLocs/" + mod + "__" + origname + ".loc") && File.Exists(appData + "/LOC Center/myLocs/" + mod + ".desc") && File.Exists(appData + "/LOC Center/myLocs/" + mod + ".png"))
                {
                    buttonDelete.Visible = true;
                    buttonExport.Visible = true;
                    buttonDirect.Visible = false;
                }
                else
                {
                    buttonDelete.Visible = false;
                    buttonExport.Visible = false;
                    buttonDirect.Visible = true;
                }
            }
            else if (direct.EndsWith(".nbt"))
            {
                if (File.Exists(appData + "/NBT Center/myNbts/" + mod + "__" + origname + ".nbt") && File.Exists(appData + "/NBT Center/myNbts/" + mod + ".desc") && File.Exists(appData + "/NBT Center/myNbts/" + mod + ".png"))
                {
                    buttonDelete.Visible = true;
                    buttonExport.Visible = true;
                    buttonDirect.Visible = false;
                }
                else
                {
                    buttonDelete.Visible = false;
                    buttonExport.Visible = false;
                    buttonDirect.Visible = true;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (direct.EndsWith(".fui"))
            {
                File.Delete(appData + "/FUI Center/myFuis/" + mod + ".desc");
                File.Delete(appData + "/FUI Center/myFuis/" + mod + ".png");
                File.Delete(appData + "/FUI Center/myFuis/" + mod + "__" + origname + ".fui");
            }
            else if (direct.EndsWith(".loc"))
            {
                File.Delete(appData + "/LOC Center/myLocs/" + mod + ".desc");
                File.Delete(appData + "/LOC Center/myLocs/" + mod + ".png");
                File.Delete(appData + "/LOC Center/myLocs/" + mod + "__" + origname + ".loc");
            }
            else if (direct.EndsWith(".nbt"))
            {
                File.Delete(appData + "/NBT Center/myNbts/" + mod + ".desc");
                File.Delete(appData + "/NBT Center/myNbts/" + mod + ".png");
                File.Delete(appData + "/NBT Center/myNbts/" + mod + "__" + origname + ".nbt");
            }

            MessageBox.Show("Deleted!");
            this.Close();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (direct.EndsWith(".fui"))
            {
                System.Diagnostics.Process.Start(appData + "/FUI Center/myFuis/");
            }
            else if (direct.EndsWith(".loc"))
            {
                System.Diagnostics.Process.Start(appData + "/LOC Center/myLocs/");
            }
            else if (direct.EndsWith(".nbt"))
            {
                System.Diagnostics.Process.Start(appData + "/NBT Center/myNbts/");
            }
            this.Close();
        }
    }
}
