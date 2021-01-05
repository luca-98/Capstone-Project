namespace databaseC
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.LabelPassword = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.GroupBoxMain = new System.Windows.Forms.GroupBox();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.PictureBoxLogin = new System.Windows.Forms.PictureBox();
            this.LabelHeader = new System.Windows.Forms.Label();
            this.GroupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelPassword
            // 
            resources.ApplyResources(this.LabelPassword, "LabelPassword");
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Click += new System.EventHandler(this.LabelPassword_Click);
            // 
            // txtusername
            // 
            resources.ApplyResources(this.txtusername, "txtusername");
            this.txtusername.ForeColor = System.Drawing.Color.Black;
            this.txtusername.Name = "txtusername";
            this.txtusername.TextChanged += new System.EventHandler(this.txtusername_TextChanged);
            // 
            // LabelUserName
            // 
            resources.ApplyResources(this.LabelUserName, "LabelUserName");
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Click += new System.EventHandler(this.LabelUserName_Click);
            // 
            // GroupBoxMain
            // 
            this.GroupBoxMain.BackColor = System.Drawing.Color.Transparent;
            this.GroupBoxMain.Controls.Add(this.ButtonClose);
            this.GroupBoxMain.Controls.Add(this.ButtonOk);
            this.GroupBoxMain.Controls.Add(this.txtpassword);
            this.GroupBoxMain.Controls.Add(this.LabelPassword);
            this.GroupBoxMain.Controls.Add(this.txtusername);
            this.GroupBoxMain.Controls.Add(this.LabelUserName);
            this.GroupBoxMain.Controls.Add(this.PictureBoxLogin);
            this.GroupBoxMain.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.GroupBoxMain, "GroupBoxMain");
            this.GroupBoxMain.Name = "GroupBoxMain";
            this.GroupBoxMain.TabStop = false;
            this.GroupBoxMain.Enter += new System.EventHandler(this.GroupBoxMain_Enter);
            // 
            // ButtonClose
            // 
            this.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.ButtonClose, "ButtonClose");
            this.ButtonClose.Image = global::databaseC.Properties.Resources.Delete_5;
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonOk
            // 
            resources.ApplyResources(this.ButtonOk, "ButtonOk");
            this.ButtonOk.Image = global::databaseC.Properties.Resources.oAccess;
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // txtpassword
            // 
            resources.ApplyResources(this.txtpassword, "txtpassword");
            this.txtpassword.ForeColor = System.Drawing.Color.Red;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            // 
            // PictureBoxLogin
            // 
            resources.ApplyResources(this.PictureBoxLogin, "PictureBoxLogin");
            this.PictureBoxLogin.Name = "PictureBoxLogin";
            this.PictureBoxLogin.TabStop = false;
            this.PictureBoxLogin.Click += new System.EventHandler(this.PictureBoxLogin_Click);
            // 
            // LabelHeader
            // 
            this.LabelHeader.AutoEllipsis = true;
            this.LabelHeader.BackColor = System.Drawing.Color.Transparent;
            this.LabelHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.LabelHeader, "LabelHeader");
            this.LabelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LabelHeader.Name = "LabelHeader";
            this.LabelHeader.UseMnemonic = false;
            this.LabelHeader.Click += new System.EventHandler(this.LabelHeader_Click);
            // 
            // login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.LabelHeader);
            this.Controls.Add(this.GroupBoxMain);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.KeyPreview = true;
            this.Name = "login";
            this.ShowInTaskbar = false;
            this.GroupBoxMain.ResumeLayout(false);
            this.GroupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLogin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label LabelPassword;
        internal System.Windows.Forms.TextBox txtusername;
        internal System.Windows.Forms.Label LabelUserName;
        internal System.Windows.Forms.PictureBox PictureBoxLogin;
        internal System.Windows.Forms.Button ButtonClose;
        internal System.Windows.Forms.Button ButtonOk;
        internal System.Windows.Forms.Label LabelHeader;
        internal System.Windows.Forms.GroupBox GroupBoxMain;
        internal System.Windows.Forms.TextBox txtpassword;
    }
}