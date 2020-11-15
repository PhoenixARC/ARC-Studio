namespace ARC_Studio.Forms
{
    partial class FUICenterOpen
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
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelDesc = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonDirect = new System.Windows.Forms.Button();
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.SlateGray;
            this.buttonExport.FlatAppearance.BorderSize = 0;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(568, 334);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(169, 66);
            this.buttonExport.TabIndex = 18;
            this.buttonExport.Text = "Get";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Visible = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(384, 334);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(178, 66);
            this.buttonDelete.TabIndex = 17;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelDesc
            // 
            this.labelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesc.ForeColor = System.Drawing.Color.White;
            this.labelDesc.Location = new System.Drawing.Point(384, 59);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(353, 286);
            this.labelDesc.TabIndex = 16;
            this.labelDesc.Text = "labelDesc";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(24, 19);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(118, 31);
            this.labelName.TabIndex = 15;
            this.labelName.Text = "FUI Mod";
            // 
            // buttonDirect
            // 
            this.buttonDirect.BackColor = System.Drawing.Color.Purple;
            this.buttonDirect.FlatAppearance.BorderSize = 0;
            this.buttonDirect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDirect.ForeColor = System.Drawing.Color.White;
            this.buttonDirect.Location = new System.Drawing.Point(568, 357);
            this.buttonDirect.Name = "buttonDirect";
            this.buttonDirect.Size = new System.Drawing.Size(169, 43);
            this.buttonDirect.TabIndex = 14;
            this.buttonDirect.Text = "DOWNLOAD TO COLLECTION";
            this.buttonDirect.UseVisualStyleBackColor = false;
            this.buttonDirect.Click += new System.EventHandler(this.buttonDirect_Click);
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.Location = new System.Drawing.Point(24, 59);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(341, 341);
            this.pictureBoxDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDisplay.TabIndex = 13;
            this.pictureBoxDisplay.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ARC_Studio.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(24, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(187, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // FUICenterOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 418);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonDirect);
            this.Controls.Add(this.pictureBoxDisplay);
            this.Name = "FUICenterOpen";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.FUICenterOpen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonDirect;
        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}