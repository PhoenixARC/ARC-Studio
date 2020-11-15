namespace ARC_Studio.Forms
{
    partial class LOCEditor
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
            this.duohnRabql = new System.Windows.Forms.ListView();
            this.columnHeader_0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvMessages = new System.Windows.Forms.ListView();
            this.columnHeader_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // duohnRabql
            // 
            this.duohnRabql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.duohnRabql.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_0});
            this.duohnRabql.Dock = System.Windows.Forms.DockStyle.Left;
            this.duohnRabql.ForeColor = System.Drawing.Color.White;
            this.duohnRabql.FullRowSelect = true;
            this.duohnRabql.HideSelection = false;
            this.duohnRabql.Location = new System.Drawing.Point(20, 84);
            this.duohnRabql.Name = "duohnRabql";
            this.duohnRabql.Size = new System.Drawing.Size(178, 544);
            this.duohnRabql.TabIndex = 4;
            this.duohnRabql.UseCompatibleStateImageBehavior = false;
            this.duohnRabql.View = System.Windows.Forms.View.Details;
            this.duohnRabql.SelectedIndexChanged += new System.EventHandler(this.duohnRabql_SelectedIndexChanged);
            // 
            // columnHeader_0
            // 
            this.columnHeader_0.Text = "Language";
            this.columnHeader_0.Width = 105;
            // 
            // lvMessages
            // 
            this.lvMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_1,
            this.columnHeader_2});
            this.lvMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvMessages.ForeColor = System.Drawing.Color.White;
            this.lvMessages.FullRowSelect = true;
            this.lvMessages.HideSelection = false;
            this.lvMessages.Location = new System.Drawing.Point(0, 0);
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(605, 283);
            this.lvMessages.TabIndex = 5;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.Details;
            this.lvMessages.SelectedIndexChanged += new System.EventHandler(this.lvMessages_SelectedIndexChanged);
            // 
            // columnHeader_1
            // 
            this.columnHeader_1.Text = "#";
            this.columnHeader_1.Width = 50;
            // 
            // columnHeader_2
            // 
            this.columnHeader_2.Text = "Message";
            this.columnHeader_2.Width = 582;
            // 
            // tbMessage
            // 
            this.tbMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbMessage.ForeColor = System.Drawing.Color.White;
            this.tbMessage.Location = new System.Drawing.Point(0, 313);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(605, 231);
            this.tbMessage.TabIndex = 6;
            this.tbMessage.TextChanged += new System.EventHandler(this.tbMessage_TextChanged_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(783, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sameToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // sameToolStripMenuItem
            // 
            this.sameToolStripMenuItem.Name = "sameToolStripMenuItem";
            this.sameToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.sameToolStripMenuItem.Text = "Save";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lvMessages);
            this.panel1.Controls.Add(this.tbMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(198, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 544);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 283);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 28);
            this.panel2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Go to #";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(52, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(113, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 8;
            this.button1.Text = "Goto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ARC_Studio.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(20, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(188, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // LOCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 648);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.duohnRabql);
            this.Controls.Add(this.menuStrip1);
            this.Name = "LOCEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "Languages Editor";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Resize += new System.EventHandler(this.LOCEditor_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private ARC_Studio.Workers.LanguagesContainer languagesContainer_0;

		private ARC_Studio.Workers.MessageEntry messageEntry_0;

		private global::System.ComponentModel.IContainer icontainer_0;
        private System.Windows.Forms.ListView duohnRabql;
        private System.Windows.Forms.ColumnHeader columnHeader_0;
        private System.Windows.Forms.ListView lvMessages;
        private System.Windows.Forms.ColumnHeader columnHeader_1;
        private System.Windows.Forms.ColumnHeader columnHeader_2;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sameToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}