//
//
//
//
//
//
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using ARC_Studio.Workers;
using System.Drawing.Drawing2D;
using System.Net.Mail;

namespace ARC_Studio
{
    public partial class Form1 : MetroForm
    {
        public Form1(int debug)
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

            #endregion
        }

        #region variables

        public string arcfile = "";
        public string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ARC_Data\\Media\\";
        public static string url = "http://pckstudio.tk/studio/ARC/api";
        string version = "1.6";

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

        #region ARC Saving and opening

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.CheckFileExists = true; //makes sure opened fui exists
                    ofd.Filter = "ARC (Minecraft Console Archive)|*.arc";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        //openPck(ofd.FileName);
                        EntryList.Nodes.Clear();
                        try
                        {
                            if (ofd.FileName.EndsWith(".arc"))
                            {
                                ARC_Studio.Workers.ARC.PS3ARCWorker ps3ARCWorker = new ARC_Studio.Workers.ARC.PS3ARCWorker();
                                ps3ARCWorker.ExtractArchive(ofd.FileName, appdata);
                                arcfile = ofd.FileName;
                                openPck(ofd.FileName);
                            }
                            else
                            {
                                MessageBox.Show("Check Data", "Data Error");
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("error\n" + err.ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The ARC you're trying to use currently isn't supported");//Error handling for PCKs that give errors when trying to be opened
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                ARC_Studio.Workers.ARC.PS3ARCWorker ps3ARCWorker = new ARC_Studio.Workers.ARC.PS3ARCWorker();
                ps3ARCWorker.BuildArchive(arcfile, appdata);
                MessageBox.Show("Saved", "Success");
            }
            catch (Exception err)
            {
                MessageBox.Show("error\n" + err.ToString());
            }
        }

        #endregion

        #region Item Centers(FUI, LOC, NBT)

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Forms.FUICenter().Show();
        }

        private void openLOCCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.LOCCenter().Show();
        }

        private void openNBTCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.NBTCenter().Show();
        }

        #endregion

        #region 'Help' Menu
        private void programInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Forms.ProgramInfo().Show();
        }

        #endregion

        #region 'Videos' Menu

        #endregion

        #region Loading form

        private void Form1_Load(object sender, EventArgs e)
        {
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
                if(new System.Net.WebClient().DownloadString(url + "/ARC_Center_update.txt") != version)
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
        }

        #endregion

        #region delete files when program closes

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(appdata);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
        #endregion

        #region Load ARC


        private void openPck(string filePath)
        {

            ImageList icons = new ImageList();
            icons.ColorDepth = ColorDepth.Depth32Bit;
            icons.ImageSize = new Size(20, 20);

            icons.Images.Add(ARC_Studio.Properties.Resources.ZZFolder);
            icons.Images.Add(ARC_Studio.Properties.Resources.BINKA_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.IMAGE_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.LOC_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.PCK_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.FUI_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.COL_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.NBT_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.TXT_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.ZUnknown);

            EntryList.ImageList = icons; //sets file icon image list

            //Creates folder for each directory
            foreach (string mf in Directory.GetDirectories(appdata))
            {
                TreeNode file = new TreeNode();
                file.Tag = mf;
                //search dir in those folders
                foreach (string mf1 in Directory.GetDirectories(mf))
                {
                    TreeNode file1 = new TreeNode();
                    file.Tag = mf1;
                    string directoryFile1 = mf1;
                    var currentNode1 = file.Nodes;

                    file1.ImageIndex = 0;
                    file1.SelectedImageIndex = 0;



                    //search files in dir1
                    foreach (string mf2 in Directory.GetFiles(mf1))
                    {
                        TreeNode file2 = new TreeNode();
                        file2.Tag = mf2;
                        string directoryFile2 = mf2;
                        var currentNode2 = file1.Nodes;


                        //Gives files correct icon
                        if (Path.GetExtension(directoryFile2) == ".binka")
                        {
                            file2.ImageIndex = 1;
                            file2.SelectedImageIndex = 1;
                        }
                        else if (Path.GetExtension(directoryFile2) == ".png")
                        {
                            file2.ImageIndex = 2;
                            file2.SelectedImageIndex = 2;
                        }
                        else if (Path.GetExtension(directoryFile2) == ".loc")
                        {
                            file2.ImageIndex = 3;
                            file2.SelectedImageIndex = 3;
                        }
                        else if (Path.GetExtension(directoryFile2) == ".pck")
                        {
                            file2.ImageIndex = 4;
                            file2.SelectedImageIndex = 4;
                        }
                        else if (Path.GetExtension(directoryFile2) == ".fui")
                        {
                            file2.ImageIndex = 5;
                            file2.SelectedImageIndex = 5;
                        }
                        else if (Path.GetExtension(directoryFile2) == ".col")
                        {
                            file2.ImageIndex = 6;
                            file2.SelectedImageIndex = 6;
                        }
                        else if (Path.GetExtension(directoryFile2) == "")
                        {
                            file2.ImageIndex = 7;
                            file2.SelectedImageIndex = 7;
                        }
                        else if (Path.GetExtension(directoryFile2) == ".txt")
                        {
                            file2.ImageIndex = 8;
                            file2.SelectedImageIndex = 8;
                        }
                        else
                        {
                            file2.ImageIndex = 9;
                            file2.SelectedImageIndex = 9;
                        }
                        file2.Text = Path.GetFileName(directoryFile2); //Sets file name
                        currentNode2.Add(file2); //adds final file after need subnodes are created
                        saved = false;

                        //Makes UI visible once a PCK is open
                        foreach (ToolStripMenuItem item in fileToolStripMenuItem.DropDownItems)
                        {
                            item.Enabled = true;
                        }

                        //Detects if LOC exists then presets for all functions that use the LOC
                        foreach (TreeNode item in EntryList.Nodes)
                        {
                        }
                        fileCount = 0;//Resets file count
                                      //Gets file count based of all existing minefiles
                        saved = false;
                    }




                    //MessageBox.Show(directoryFile1.Replace(Path.GetDirectoryName(directoryFile1) + "\\", ""));
                    file1.Text = directoryFile1.Replace(Path.GetDirectoryName(directoryFile1) + "\\", ""); //Sets file name
                    currentNode1.Add(file1); //adds final file after need subnodes are created
                    saved = false;
                }
                //search files in dir1
                foreach (string mf2 in Directory.GetFiles(mf))
                {
                    TreeNode file2 = new TreeNode();
                    file2.Tag = mf2;
                    string directoryFile2 = mf2;
                    var currentNode2 = file.Nodes;


                    //Gives files correct icon
                    if (Path.GetExtension(directoryFile2) == ".binka")
                    {
                        file2.ImageIndex = 1;
                        file2.SelectedImageIndex = 1;
                    }
                    else if (Path.GetExtension(directoryFile2) == ".png")
                    {
                        file2.ImageIndex = 2;
                        file2.SelectedImageIndex = 2;
                    }
                    else if (Path.GetExtension(directoryFile2) == ".loc")
                    {
                        file2.ImageIndex = 3;
                        file2.SelectedImageIndex = 3;
                    }
                    else if (Path.GetExtension(directoryFile2) == ".pck")
                    {
                        file2.ImageIndex = 4;
                        file2.SelectedImageIndex = 4;
                    }
                    else if (Path.GetExtension(directoryFile2) == ".fui")
                    {
                        file2.ImageIndex = 5;
                        file2.SelectedImageIndex = 5;
                    }
                    else if (Path.GetExtension(directoryFile2) == ".col")
                    {
                        file2.ImageIndex = 6;
                        file2.SelectedImageIndex = 6;
                    }
                    else if (Path.GetExtension(directoryFile2) == "")
                    {
                        file2.ImageIndex = 7;
                        file2.SelectedImageIndex = 7;
                    }
                    else if (Path.GetExtension(directoryFile2) == ".txt")
                    {
                        file2.ImageIndex = 8;
                        file2.SelectedImageIndex = 8;
                    }
                    else
                    {
                        file2.ImageIndex = 9;
                        file2.SelectedImageIndex = 9;
                    }
                    file2.Text = Path.GetFileName(directoryFile2); //Sets file name
                    currentNode2.Add(file2); //adds final file after need subnodes are created
                    saved = false;

                    //Makes UI visible once a PCK is open
                    foreach (ToolStripMenuItem item in fileToolStripMenuItem.DropDownItems)
                    {
                        item.Enabled = true;
                    }

                    //Detects if LOC exists then presets for all functions that use the LOC
                    foreach (TreeNode item in EntryList.Nodes)
                    {
                    }
                    fileCount = 0;//Resets file count
                                  //Gets file count based of all existing minefiles
                    saved = false;
                }


                string directoryFile = mf;
                var currentNode = EntryList.Nodes;

                    file.ImageIndex = 0;
                    file.SelectedImageIndex = 0;

                file.Text = directoryFile.Replace(Path.GetDirectoryName(directoryFile) + "\\", ""); //Sets file name
                currentNode.Add(file); //adds final file after need subnodes are created
                saved = false;
            }
            //Creates nodes for each minefile in the PCK
            foreach (string mf in Directory.GetFiles(appdata))
            {
                TreeNode file = new TreeNode();
                file.Tag = mf;
                string directoryFile = mf;
                var currentNode = EntryList.Nodes;


                    //Gives files correct icon
                    if (Path.GetExtension(directoryFile) == ".binka")
                    {
                        file.ImageIndex = 1;
                        file.SelectedImageIndex = 1;
                    }
                    else if (Path.GetExtension(directoryFile) == ".png")
                    {
                        file.ImageIndex = 2;
                        file.SelectedImageIndex = 2;
                    }
                    else if (Path.GetExtension(directoryFile) == ".loc")
                    {
                        file.ImageIndex = 3;
                        file.SelectedImageIndex = 3;
                    }
                    else if (Path.GetExtension(directoryFile) == ".pck")
                    {
                        file.ImageIndex = 4;
                        file.SelectedImageIndex = 4;
                    }
                    else if (Path.GetExtension(directoryFile) == ".fui")
                    {
                        file.ImageIndex = 5;
                        file.SelectedImageIndex = 5;
                    }
                    else if (Path.GetExtension(directoryFile) == ".col")
                    {
                        file.ImageIndex = 6;
                        file.SelectedImageIndex = 6;
                    }
                    else if (Path.GetExtension(directoryFile) == "")
                    {
                        file.ImageIndex = 7;
                        file.SelectedImageIndex = 7;
                    }
                    else if (Path.GetExtension(directoryFile) == ".txt")
                    {
                        file.ImageIndex = 8;
                        file.SelectedImageIndex = 8;
                    }
                    else
                    {
                        file.ImageIndex = 9;
                        file.SelectedImageIndex = 9;
                    }
                    file.Text = Path.GetFileName(directoryFile); //Sets file name
                    currentNode.Add(file); //adds final file after need subnodes are created
                    saved = false;

            //Makes UI visible once a PCK is open
            foreach (ToolStripMenuItem item in fileToolStripMenuItem.DropDownItems)
                {
                    item.Enabled = true;
                }

                //Detects if LOC exists then presets for all functions that use the LOC
                foreach (TreeNode item in EntryList.Nodes)
                {
                }
                fileCount = 0;//Resets file count
                              //Gets file count based of all existing minefiles
                saved = false;
            }

        }

        #endregion

        #region select file

        private void EntryList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (EntryList.SelectedNode.Text.EndsWith(".png"))
                {
                    //MessageBox.Show(EntryList.SelectedNode.Tag.ToString());
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.InterpolationMode = InterpolationMode.NearestNeighbor;
                    MemoryStream png = new MemoryStream(File.ReadAllBytes(EntryList.SelectedNode.Tag.ToString())); //Gets image data from minefile data
                    Image skinPicture = Image.FromStream(png); //Constructs image data into image
                    pictureBox1.Image = skinPicture; //Sets image preview to image


                    if (skinPicture.Size.Height == skinPicture.Size.Width / 2)
                    {
                        return;
                    }
                    else if (skinPicture.Size.Height == skinPicture.Size.Width)
                    {
                        return;
                    }
                    else
                    {
                        //Sets images to appear at largest relative size to program window size
                        Size maxDisplay = new Size(tabPage1.Size.Width / 2 - 5, tabPage1.Size.Height / 2 - 5);
                        if (skinPicture.Size.Width > maxDisplay.Width)
                        {
                            //calculate aspect ratio
                            float aspect = skinPicture.Width / (float)skinPicture.Height;
                            int newWidth, newHeight;

                            //calculate new dimensions based on aspect ratio
                            newWidth = (int)(maxDisplay.Height * aspect);
                            newHeight = (int)(newWidth / aspect);

                            //if one of the two dimensions exceed the box dimensions
                            if (newWidth > skinPicture.Width || newHeight > skinPicture.Height)
                            {
                                //depending on which of the two exceeds the box dimensions set it as the box dimension and calculate the other one based on the aspect ratio
                                if (newWidth > newHeight)
                                {
                                    newWidth = maxDisplay.Width;
                                    newHeight = (int)(newWidth / aspect);
                                }
                                else
                                {
                                    newHeight = maxDisplay.Height;
                                    newWidth = (int)(newHeight * aspect);
                                }
                            }
                            pictureBox1.Size = new Size(newWidth, newHeight);
                        }
                        else if (skinPicture.Size.Height > maxDisplay.Height)
                        {
                            //calculate aspect ratio
                            float aspect = skinPicture.Width / (float)skinPicture.Height;
                            int newWidth, newHeight;

                            //calculate new dimensions based on aspect ratio
                            newWidth = (int)(maxDisplay.Width * aspect);
                            newHeight = (int)(newWidth / aspect);

                            //if one of the two dimensions exceed the box dimensions
                            if (newWidth > skinPicture.Width || newHeight > skinPicture.Height)
                            {
                                //depending on which of the two exceeds the box dimensions set it as the box dimension and calculate the other one based on the aspect ratio
                                if (newWidth > newHeight)
                                {
                                    newWidth = maxDisplay.Width;
                                    newHeight = (int)(newWidth / aspect);
                                }
                                else
                                {
                                    newHeight = maxDisplay.Height;
                                    newWidth = (int)(newHeight * aspect);
                                }
                            }
                            pictureBox1.Size = new Size(newWidth, newHeight);
                        }
                        else
                        {
                            pictureBox1.Size = new Size(skinPicture.Size.Width, skinPicture.Size.Height);
                        }
                        return;
                    }
                    richTextBox1.Text = "";
                }
                else if (EntryList.SelectedNode.Text.EndsWith(".txt"))
                {
                    richTextBox1.Text = File.ReadAllText(EntryList.SelectedNode.Tag.ToString());
                }
                else
                {
                    richTextBox1.Text = "";

                }
            }
            catch(Exception exep)
            {
                string errormsg = DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year + "::" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + " -- " + exep.Message.ToString() + "\n\n" + exep.StackTrace.ToString();
                System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + "\\LOGS\\");
                System.IO.File.AppendAllText(Environment.CurrentDirectory + "\\LOGS\\logFile-" + DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year + ".log", errormsg + "\n\n===============NEWLOG===============n");


                if (MessageBox.Show("Update Avaliable\nDownload?", "Error!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\ARCUpdater.exe");
                }
            }
        }
        #endregion

        #region When FOrmMain Changes Sizes

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Height = metroTabPage1.Height / 2;
            tabControl1.Height = metroTabPage1.Height / 2;
        }

        #endregion

        #region edit text when edited

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText(EntryList.SelectedNode.Tag.ToString(), richTextBox1.Text);
        }

        #endregion

        #region Open File when double clicked

        private void EntryList_DoubleClick(object sender, EventArgs e)
        {
            if (EntryList.SelectedNode.Tag != null)
            {
                byte[] mf = File.ReadAllBytes(EntryList.SelectedNode.Tag.ToString());
                //Checks to see if selected minefile is a loc file
                if (Path.GetExtension(EntryList.SelectedNode.Tag.ToString()) == ".loc")
                {
                    Forms.LOCEditor le = new Forms.LOCEditor(EntryList.SelectedNode.Tag.ToString());
                    le.Show();
                    //MessageBox.Show(".LOC Editor Coming Soon!");
                }

                //Checks to see if selected minefile is a col file
                if (Path.GetExtension(EntryList.SelectedNode.Tag.ToString()) == ".col")
                {
                    MessageBox.Show(".COL Editor Coming Soon!");
                }


                //Checks to see if selected minefile is a col file
                if (Path.GetExtension(EntryList.SelectedNode.Tag.ToString()) == ".fui")
                {
                    //MessageBox.Show(".FUI Editor Coming Soon!");
                    ARC_Studio.Forms.FUIEditor fui = new Forms.FUIEditor(EntryList.SelectedNode.Tag.ToString());
                    fui.Show();
                }

                //Checks to see if selected minefile is a binka file
                if (Path.GetExtension(EntryList.SelectedNode.Tag.ToString()) == ".binka")
                {
                    File.WriteAllText(Environment.CurrentDirectory + "\\BinkMan\\files.txt", EntryList.SelectedNode.Tag.ToString());
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Waveform Audio | *.wav";
                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        System.Diagnostics.Process binkman = new System.Diagnostics.Process();
                        binkman.StartInfo.FileName = Environment.CurrentDirectory + "\\BinkMan\\BinkMan.exe";
                        binkman.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "\\BinkMan";
                        binkman.Start();
                        binkman.WaitForExit();
                        File.Copy(EntryList.SelectedNode.Tag.ToString().Replace(".binka", ".wav"), sfd.FileName, true);
                        File.Delete(EntryList.SelectedNode.Tag.ToString().Replace(".binka", ".wav"));
                    }
                    else
                    {

                    }
                    //MessageBox.Show(".binka Editor Coming Soon!");
                }

                //Checks to see if selected minefile is a col file
                if (Path.GetExtension(EntryList.SelectedNode.Tag.ToString()) == "")
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = (Environment.CurrentDirectory + "\\NBTEditor\\NBTExplorer.exe");
                    proc.StartInfo.Arguments = EntryList.SelectedNode.Tag.ToString();
                    proc.Start();
                    //MessageBox.Show(".NBT Editor Coming Soon!");
                }


            }
        }


        public void ShowLoaderForm()
        {

            new ARC_Studio.Forms.FUIEditor(EntryList.SelectedNode.Tag.ToString()).Show();

        }

        #endregion

        #region extract file

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EntryList.SelectedNode.ImageIndex == 0)
            {
                MessageBox.Show("Cannot extract folders(yet)");
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();

                switch (Path.GetExtension(EntryList.SelectedNode.Tag.ToString()))
                {

                    case (".png"):
                        {
                            sfd.Filter = "PNG Image | *.png";
                        }
                        break;
                    case (".loc"):
                        {
                            sfd.Filter = "Localization | *.loc";
                        }
                        break;
                    case (".fui"):
                        {
                            sfd.Filter = "Fuscated Universal Image | *.fui";
                        }
                        break;
                    case (".col"):
                        {
                            sfd.Filter = "Color file | *.col";
                        }
                        break;
                    case (".binka"):
                        {
                            sfd.Filter = "Waveform Audio | *.wav";
                        }
                        break;
                    case (""):
                        {
                            sfd.Filter = "NBT Data | *.nbt";
                        }
                        break;
                }
                sfd.FileName = EntryList.SelectedNode.Text;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.Filter == "Waveform Audio | *.wav")
                    {
                        System.Diagnostics.Process binkman = new System.Diagnostics.Process();
                        binkman.StartInfo.FileName = Environment.CurrentDirectory + "\\BinkMan\\BinkMan.exe";
                        binkman.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "\\BinkMan";
                        binkman.Start();
                        binkman.WaitForExit();
                        File.Copy(EntryList.SelectedNode.Tag.ToString().Replace(".binka", ".wav"), sfd.FileName, true);
                        File.Delete(EntryList.SelectedNode.Tag.ToString().Replace(".binka", ".wav"));
                    }
                    else
                        File.Copy(EntryList.SelectedNode.Tag.ToString(), sfd.FileName, true);

                }
            }


        }

        #endregion

        #region replace file

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (EntryList.SelectedNode.ImageIndex == 0)
            {
                MessageBox.Show("Cannot Replace folders");
            }
            else
            {
                OpenFileDialog sfd = new OpenFileDialog();

                switch (Path.GetExtension(EntryList.SelectedNode.Tag.ToString()))
                {

                    case (".png"):
                        {
                            sfd.Filter = "PNG Image | *.png";
                        }
                        break;
                    case (".loc"):
                        {
                            sfd.Filter = "Localization | *.loc";
                        }
                        break;
                    case (".fui"):
                        {
                            sfd.Filter = "Fuscated Universal Image | *.fui";
                        }
                        break;
                    case (".col"):
                        {
                            sfd.Filter = "Color file | *.col";
                        }
                        break;
                    case (".binka"):
                        {
                            sfd.Filter = "Waveform Audio | *.wav";
                        }
                        break;
                    case (""):
                        {
                            sfd.Filter = "NBT Data | *.nbt";
                        }
                        break;
                }
                sfd.FileName = EntryList.SelectedNode.Text;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.Filter == "Waveform Audio | *.wav")
                    {
                        System.Diagnostics.Process binkman = new System.Diagnostics.Process();
                        binkman.StartInfo.FileName = Environment.CurrentDirectory + "\\BinkMan\\BinkMan.exe";
                        binkman.StartInfo.WorkingDirectory = Environment.CurrentDirectory + "\\BinkMan";
                        binkman.Start();
                        binkman.WaitForExit();
                        File.Copy(sfd.FileName, EntryList.SelectedNode.Tag.ToString().Replace(".wav", ".binka"), true);
                        File.Delete(sfd.FileName);
                    }
                    else
                        File.Copy(sfd.FileName, EntryList.SelectedNode.Tag.ToString(), true);
                }
            }
        }

        #endregion

        #region extract full arc

        private void extractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region send bug report

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();
            //MessageBox.Show("Please be aware that this will contain the stack trace at the bottom, simply type your bug description above that");
            System.Diagnostics.Process.Start("mailto:felix.millerarc@gmail.com?subject=ARC%20Studio%20Bug%20report&body=description:%0A%0A%0A%0A%0A%0A%0A%0A%0A%0ASTACK%20TRACE:" + t.ToString().Replace(" ","%20").Replace("\n","%0A").Replace("\r\n","%0A"));
        }

        #endregion

        #region Donations

        private void toPhoenixARCDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://cash.app/$PhoenixARC");
        }

        private void toNobledezJackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.me/realnobledez");
        }

        #endregion
    }
}
