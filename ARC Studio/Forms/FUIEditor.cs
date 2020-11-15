using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using MetroFramework.Forms;

namespace ARC_Studio.Forms
{
    public partial class FUIEditor : MetroForm
    {

        #region variables

        string appData = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/ARC_Data/";
        public ImageList icons = new ImageList();
        string openfui = "";

        #endregion

        public FUIEditor(string file)
        {
            InitializeComponent();
            icons.ColorDepth = ColorDepth.Depth32Bit;
            icons.ImageSize = new Size(20, 20);

            icons.Images.Add(ARC_Studio.Properties.Resources.IMAGE_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.FUI_ICON);
            icons.Images.Add(ARC_Studio.Properties.Resources.ZUnknown);

            EntryList.ImageList = icons; //sets file icon image list
            Console.WriteLine("LoadFUI");
            openfui = file;
            LoadFUI(file);
        }

        public void LoadFUI(string file)
        {
            Console.WriteLine("Make Node0");
            TreeNode tn = new TreeNode();
            tn.Text = Path.GetFileName(file);
            tn.Tag = file;
            tn.ImageIndex = 1;
            Console.WriteLine("Extract file");
            extractFUI(file);
            int imgno = 0;
            try
            {
                foreach (string imgdat in Directory.GetFiles(appData + "/FUI_Data/"))
                {
                    Console.WriteLine("Make Node1");
                    TreeNode tn1 = new TreeNode();
                    tn1.Text = Path.GetFileName(imgdat);
                    tn1.Tag = imgdat;
                    tn1.ImageIndex = 0;
                    Console.WriteLine("Add Node");
                    tn.Nodes.Add(tn1);
                    imgno++;
                    Console.WriteLine("Add1 to imgno");

                }
            }
            catch
            {

            }
            EntryList.Nodes.Add(tn);
        }

        public void extractFUI(string file)
        {
            string data = BitConverter.ToString(File.ReadAllBytes(file)).Replace('-', ' ');
            string[] datasplit = data.Split(new[] { "89 50 4E 47" }, StringSplitOptions.None);
            int imgno = 0;

            File.WriteAllBytes(appData + "/file.bin", ARC_Studio.Workers.SplitterClass.HexStringToByteArray(datasplit[0].Replace(" ", "")));
            try
            {
                foreach (string imgdat in datasplit)
                {
                    string fullfile = "89 50 4E 47 " + datasplit[imgno + 1];
                    File.WriteAllBytes(appData + "/FUI_Data/image" + imgno.ToString() + ".png", ARC_Studio.Workers.SplitterClass.HexStringToByteArray(fullfile.Replace(" ", "")));
                    imgno++;

                }
            }
            catch
            {

            }
        }

        private void EntryList_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (EntryList.SelectedNode.Text.EndsWith(".png"))
            {
                //MessageBox.Show(EntryList.SelectedNode.Tag.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
                    Size maxDisplay = new Size(metroTabPage1.Size.Width, metroTabPage1.Size.Height);
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
            }
        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image | *.png";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(EntryList.SelectedNode.Tag.ToString(), sfd.FileName) ;
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "PNG Image | *.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(sfd.FileName, EntryList.SelectedNode.Tag.ToString(), true);
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<string> img = new List<string>();
            string filebeg = BitConverter.ToString(File.ReadAllBytes(appData + "/file.bin")).Replace('-', ' ');
            int i = 0;
            foreach(string file in Directory.GetFiles(appData + "/FUI_Data/"))
            {
                img.Add(BitConverter.ToString(File.ReadAllBytes(appData + "/FUI_Data/image" + i.ToString() + ".png")));
                i++;
            }
            foreach(string imag in img)
            {
                filebeg += imag;
            }
            File.WriteAllBytes(openfui, Workers.SplitterClass.HexStringToByteArray(filebeg.Replace(" ", "").Replace("-", "")));
        }

        private void FUIEditor_FormClosing(object sender, FormClosingEventArgs e)
        {

            System.IO.DirectoryInfo di = new DirectoryInfo(appData + "/FUI_Data/");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
