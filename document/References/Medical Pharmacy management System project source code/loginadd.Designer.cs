namespace databaseC
{
    partial class loginadd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginadd));
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.PictureBoxLogin = new System.Windows.Forms.PictureBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.LabelHeader = new System.Windows.Forms.Label();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.GroupBoxMain = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogin)).BeginInit();
            this.GroupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonClose
            // 
            this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ButtonClose.Image = global::databaseC.Properties.Resources.Delete_5;
            this.ButtonClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ButtonClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButtonClose.Location = new System.Drawing.Point(248, 140);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(112, 40);
            this.ButtonClose.TabIndex = 5;
            this.ButtonClose.Text = "&Cancel";
            this.ButtonClose.UseVisualStyleBackColor = true;
            // 
            // ButtonOk
            // 
            this.ButtonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.ButtonOk.Image = global::databaseC.Properties.Resources.oAccess;
            this.ButtonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButtonOk.Location = new System.Drawing.Point(130, 140);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(112, 40);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "&Save";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // PictureBoxLogin
            // 
            this.PictureBoxLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxLogin.BackgroundImage")));
            this.PictureBoxLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureBoxLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBoxLogin.Location = new System.Drawing.Point(8, 16);
            this.PictureBoxLogin.Name = "PictureBoxLogin";
            this.PictureBoxLogin.Size = new System.Drawing.Size(48, 56);
            this.PictureBoxLogin.TabIndex = 0;
            this.PictureBoxLogin.TabStop = false;
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtusername.ForeColor = System.Drawing.Color.Black;
            this.txtusername.Location = new System.Drawing.Point(128, 56);
            this.txtusername.MaxLength = 30;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(232, 21);
            this.txtusername.TabIndex = 1;
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelPassword.Location = new System.Drawing.Point(52, 80);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(72, 13);
            this.LabelPassword.TabIndex = 2;
            this.LabelPassword.Text = "Old Password";
            this.LabelPassword.Click += new System.EventHandler(this.LabelPassword_Click);
            // 
            // LabelHeader
            // 
            this.LabelHeader.AutoEllipsis = true;
            this.LabelHeader.BackColor = System.Drawing.Color.Transparent;
            this.LabelHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LabelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LabelHeader.Image = ((System.Drawing.Image)(resources.GetObject("LabelHeader.Image")));
            this.LabelHeader.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LabelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelHeader.Location = new System.Drawing.Point(0, 0);
            this.LabelHeader.Name = "LabelHeader";
            this.LabelHeader.Size = new System.Drawing.Size(390, 73);
            this.LabelHeader.TabIndex = 4;
            this.LabelHeader.Text = "Pharmacy Management System";
            this.LabelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelHeader.UseMnemonic = false;
            // 
            // LabelUserName
            // 
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LabelUserName.Location = new System.Drawing.Point(52, 56);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(60, 13);
            this.LabelUserName.TabIndex = 0;
            this.LabelUserName.Text = "User Name";
            // 
            // GroupBoxMain
            // 
            this.GroupBoxMain.BackColor = System.Drawing.Color.Transparent;
            this.GroupBoxMain.Controls.Add(this.txtpassword);
            this.GroupBoxMain.Controls.Add(this.textBox1);
            this.GroupBoxMain.Controls.Add(this.label1);
            this.GroupBoxMain.Controls.Add(this.ButtonClose);
            this.GroupBoxMain.Controls.Add(this.ButtonOk);
            this.GroupBoxMain.Controls.Add(this.LabelPassword);
            this.GroupBoxMain.Controls.Add(this.txtusername);
            this.GroupBoxMain.Controls.Add(this.LabelUserName);
            this.GroupBoxMain.Controls.Add(this.PictureBoxLogin);
            this.GroupBoxMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GroupBoxMain.Location = new System.Drawing.Point(8, 77);
            this.GroupBoxMain.Name = "GroupBoxMain";
            this.GroupBoxMain.Size = new System.Drawing.Size(368, 186);
            this.GroupBoxMain.TabIndex = 3;
            this.GroupBoxMain.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(52, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "New Password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 107);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 20);
            this.textBox1.TabIndex = 7;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(128, 81);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(232, 20);
            this.txtpassword.TabIndex = 8;
            // 
            // loginadd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 265);
            this.ControlBox = false;
            this.Controls.Add(this.LabelHeader);
            this.Controls.Add(this.GroupBoxMain);
            this.Name = "loginadd";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogin)).EndInit();
            this.GroupBoxMain.ResumeLayout(false);
            this.GroupBoxMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button ButtonClose;
        internal System.Windows.Forms.Button ButtonOk;
        internal System.Windows.Forms.PictureBox PictureBoxLogin;
        internal System.Windows.Forms.TextBox txtusername;
        internal System.Windows.Forms.Label LabelPassword;
        internal System.Windows.Forms.Label LabelHeader;
        internal System.Windows.Forms.Label LabelUserName;
        internal System.Windows.Forms.GroupBox GroupBoxMain;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtpassword;
    }
}