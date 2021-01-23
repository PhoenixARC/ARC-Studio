namespace ARC_Studio.Forms
{
    partial class NBTCenter
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonMine = new System.Windows.Forms.RadioButton();
            this.radioButtonPS3 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pckLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 610F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(810, 555);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonMine, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonPS3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSubmit, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(194, 549);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // radioButtonMine
            // 
            this.radioButtonMine.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonMine.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonMine.FlatAppearance.BorderSize = 0;
            this.radioButtonMine.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.radioButtonMine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButtonMine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButtonMine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonMine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMine.ForeColor = System.Drawing.Color.White;
            this.radioButtonMine.Location = new System.Drawing.Point(3, 245);
            this.radioButtonMine.Name = "radioButtonMine";
            this.radioButtonMine.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.radioButtonMine.Size = new System.Drawing.Size(188, 45);
            this.radioButtonMine.TabIndex = 13;
            this.radioButtonMine.Text = "My Collection";
            this.radioButtonMine.UseVisualStyleBackColor = false;
            this.radioButtonMine.CheckedChanged += new System.EventHandler(this.radioButtonMine_CheckedChanged);
            // 
            // radioButtonPS3
            // 
            this.radioButtonPS3.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonPS3.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonPS3.Checked = true;
            this.radioButtonPS3.FlatAppearance.BorderSize = 0;
            this.radioButtonPS3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.radioButtonPS3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButtonPS3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButtonPS3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonPS3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPS3.ForeColor = System.Drawing.Color.White;
            this.radioButtonPS3.Location = new System.Drawing.Point(3, 194);
            this.radioButtonPS3.Name = "radioButtonPS3";
            this.radioButtonPS3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.radioButtonPS3.Size = new System.Drawing.Size(188, 45);
            this.radioButtonPS3.TabIndex = 10;
            this.radioButtonPS3.TabStop = true;
            this.radioButtonPS3.Text = "NBT";
            this.radioButtonPS3.UseVisualStyleBackColor = false;
            this.radioButtonPS3.CheckedChanged += new System.EventHandler(this.radioButtonPS3_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ARC_Studio.Properties.Resources.nbtCenterHeader;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.FlatAppearance.BorderSize = 0;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.Color.White;
            this.buttonSubmit.Location = new System.Drawing.Point(3, 296);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonSubmit.Size = new System.Drawing.Size(188, 45);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "Submit NBT";
            this.buttonSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pckLayout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(203, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 549);
            this.panel1.TabIndex = 5;
            // 
            // pckLayout
            // 
            this.pckLayout.AutoScroll = true;
            this.pckLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pckLayout.Location = new System.Drawing.Point(0, 0);
            this.pckLayout.Name = "pckLayout";
            this.pckLayout.Size = new System.Drawing.Size(604, 549);
            this.pckLayout.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ARC_Studio.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(24, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(187, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // NBTCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 635);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "NBTCenter";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "LOC Center";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.NBTCenter_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonMine;
        private System.Windows.Forms.RadioButton radioButtonPS3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel pckLayout;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}