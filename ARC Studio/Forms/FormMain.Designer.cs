namespace ARC_Studio
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.EntryList = new System.Windows.Forms.TreeView();
            this.TreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openLOCCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNBTCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toNobledezJackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toPhoenixARCDeveloperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.pictureBox1 = new ARC_Studio.PictureBoxWithInterpolationMode();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DEVELOPERLABEL = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TreeMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // EntryList
            // 
            this.EntryList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EntryList.ContextMenuStrip = this.TreeMenu;
            this.EntryList.Dock = System.Windows.Forms.DockStyle.Left;
            this.EntryList.ForeColor = System.Drawing.SystemColors.Menu;
            this.EntryList.Location = new System.Drawing.Point(0, 0);
            this.EntryList.Name = "EntryList";
            this.EntryList.Size = new System.Drawing.Size(200, 459);
            this.EntryList.TabIndex = 0;
            this.EntryList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.EntryList_AfterSelect);
            this.EntryList.DoubleClick += new System.EventHandler(this.EntryList_DoubleClick);
            // 
            // TreeMenu
            // 
            this.TreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceToolStripMenuItem,
            this.extractToolStripMenuItem});
            this.TreeMenu.Name = "TreeMenu";
            this.TreeMenu.Size = new System.Drawing.Size(116, 48);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // extractToolStripMenuItem
            // 
            this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            this.extractToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.extractToolStripMenuItem.Text = "Extract";
            this.extractToolStripMenuItem.Click += new System.EventHandler(this.extractToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.storeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(20, 60);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(778, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.extractToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // extractToolStripMenuItem1
            // 
            this.extractToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("extractToolStripMenuItem1.Image")));
            this.extractToolStripMenuItem1.Name = "extractToolStripMenuItem1";
            this.extractToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.extractToolStripMenuItem1.Text = "Extract";
            this.extractToolStripMenuItem1.Click += new System.EventHandler(this.extractToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Enabled = false;
            this.saveToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem1.Image")));
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save As";
            // 
            // storeToolStripMenuItem
            // 
            this.storeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.openLOCCenterToolStripMenuItem,
            this.openNBTCenterToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.storeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.storeToolStripMenuItem.Name = "storeToolStripMenuItem";
            this.storeToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.storeToolStripMenuItem.Text = "More";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Image = global::ARC_Studio.Properties.Resources.fuiCenterHeader;
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.openToolStripMenuItem1.Text = "Open FUI Center";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // openLOCCenterToolStripMenuItem
            // 
            this.openLOCCenterToolStripMenuItem.Image = global::ARC_Studio.Properties.Resources.locCenterHeader;
            this.openLOCCenterToolStripMenuItem.Name = "openLOCCenterToolStripMenuItem";
            this.openLOCCenterToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openLOCCenterToolStripMenuItem.Text = "Open LOC Center";
            this.openLOCCenterToolStripMenuItem.Click += new System.EventHandler(this.openLOCCenterToolStripMenuItem_Click);
            // 
            // openNBTCenterToolStripMenuItem
            // 
            this.openNBTCenterToolStripMenuItem.Image = global::ARC_Studio.Properties.Resources.nbtCenterHeader;
            this.openNBTCenterToolStripMenuItem.Name = "openNBTCenterToolStripMenuItem";
            this.openNBTCenterToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openNBTCenterToolStripMenuItem.Text = "Open NBT Center";
            this.openNBTCenterToolStripMenuItem.Click += new System.EventHandler(this.openNBTCenterToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toNobledezJackToolStripMenuItem,
            this.toPhoenixARCDeveloperToolStripMenuItem});
            this.donateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("donateToolStripMenuItem.Image")));
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            // 
            // toNobledezJackToolStripMenuItem
            // 
            this.toNobledezJackToolStripMenuItem.Name = "toNobledezJackToolStripMenuItem";
            this.toNobledezJackToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.toNobledezJackToolStripMenuItem.Text = "To Nobledez(Jack)";
            this.toNobledezJackToolStripMenuItem.Click += new System.EventHandler(this.toNobledezJackToolStripMenuItem_Click);
            // 
            // toPhoenixARCDeveloperToolStripMenuItem
            // 
            this.toPhoenixARCDeveloperToolStripMenuItem.Name = "toPhoenixARCDeveloperToolStripMenuItem";
            this.toPhoenixARCDeveloperToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.toPhoenixARCDeveloperToolStripMenuItem.Text = "To PhoenixARC(Developer)";
            this.toPhoenixARCDeveloperToolStripMenuItem.Click += new System.EventHandler(this.toPhoenixARCDeveloperToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programInfoToolStripMenuItem,
            this.reportABugToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // programInfoToolStripMenuItem
            // 
            this.programInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("programInfoToolStripMenuItem.Image")));
            this.programInfoToolStripMenuItem.Name = "programInfoToolStripMenuItem";
            this.programInfoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.programInfoToolStripMenuItem.Text = "Program Info";
            this.programInfoToolStripMenuItem.Click += new System.EventHandler(this.programInfoToolStripMenuItem_Click);
            // 
            // reportABugToolStripMenuItem
            // 
            this.reportABugToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportABugToolStripMenuItem.Image")));
            this.reportABugToolStripMenuItem.Name = "reportABugToolStripMenuItem";
            this.reportABugToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.reportABugToolStripMenuItem.Text = "Report a bug";
            this.reportABugToolStripMenuItem.Click += new System.EventHandler(this.reportABugToolStripMenuItem_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 84);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(778, 498);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.White;
            this.metroTabControl1.TabIndex = 4;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.pictureBox1);
            this.metroTabPage1.Controls.Add(this.tabControl1);
            this.metroTabPage1.Controls.Add(this.EntryList);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(770, 459);
            this.metroTabPage1.Style = MetroFramework.MetroColorStyle.White;
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBox1.Location = new System.Drawing.Point(200, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(570, 215);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(200, 221);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 238);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 212);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TextData";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Menu;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(556, 206);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // DEVELOPERLABEL
            // 
            this.DEVELOPERLABEL.AutoSize = true;
            this.DEVELOPERLABEL.BackColor = System.Drawing.Color.Transparent;
            this.DEVELOPERLABEL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DEVELOPERLABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEVELOPERLABEL.ForeColor = System.Drawing.Color.Red;
            this.DEVELOPERLABEL.Location = new System.Drawing.Point(20, 566);
            this.DEVELOPERLABEL.Name = "DEVELOPERLABEL";
            this.DEVELOPERLABEL.Size = new System.Drawing.Size(147, 16);
            this.DEVELOPERLABEL.TabIndex = 6;
            this.DEVELOPERLABEL.Text = "DEVELOPER BUILD";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.VersionLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.VersionLabel.Location = new System.Drawing.Point(20, 550);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(89, 16);
            this.VersionLabel.TabIndex = 7;
            this.VersionLabel.Text = "Version: 1.0";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ARC_Studio.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(20, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(161, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 602);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.DEVELOPERLABEL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "FUI Studio";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.TreeMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView EntryList;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem openLOCCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNBTCenterToolStripMenuItem;
        private System.Windows.Forms.Label DEVELOPERLABEL;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.ContextMenuStrip TreeMenu;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private PictureBoxWithInterpolationMode pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem reportABugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toNobledezJackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toPhoenixARCDeveloperToolStripMenuItem;
    }
}

