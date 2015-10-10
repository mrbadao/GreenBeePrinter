namespace GreenBeePrinter
{
    partial class frmLogin
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
            this.txtLoginId = new DevExpress.XtraEditors.TextEdit();
            this.txtLoginPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLoginId
            // 
            this.txtLoginId.Location = new System.Drawing.Point(102, 217);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(163, 20);
            this.txtLoginId.TabIndex = 0;
            this.txtLoginId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginId_KeyDown);
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(102, 254);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Properties.UseSystemPasswordChar = true;
            this.txtLoginPassword.Size = new System.Drawing.Size(163, 20);
            this.txtLoginPassword.TabIndex = 1;
            this.txtLoginPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginPassword_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 220);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "LoginID";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 261);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Password";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Image = global::GreenBeePrinter.Properties.Resources.btn_exit;
            this.btnExit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(190, 294);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Image = global::GreenBeePrinter.Properties.Resources.btn_login;
            this.btnLogin.Location = new System.Drawing.Point(102, 294);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 25);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmLogin
            // 
            this.ActiveGlowColor = System.Drawing.Color.Empty;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::GreenBeePrinter.Properties.Resources.cmsPrinter_loginbg2;
            this.ClientSize = new System.Drawing.Size(294, 335);
            this.ControlBox = false;
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtLoginPassword);
            this.Controls.Add(this.txtLoginId);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.InactiveGlowColor = System.Drawing.Color.Empty;
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtLoginId;
        private DevExpress.XtraEditors.TextEdit txtLoginPassword;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
    }
}