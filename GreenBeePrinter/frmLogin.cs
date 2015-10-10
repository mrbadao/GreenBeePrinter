using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GreenBeePrinter
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {            
            Dictionary<string, string> postUser = new Dictionary<string, string>();
            postUser.Add("loginid", txtLoginId.Text.ToString());
            postUser.Add("password", txtLoginPassword.Text.ToString());

            Program.cashier = await ApiCore.getJsonObj<Cashier>("auth/authenticate/", postUser);

            if (Program.cashier != null)
            {
                 Program.userAuthenticate = true;
                 this.Close();
            }
            else
            {
                MessageBox.Show("Login failed! Please try again.", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
                btnLogin_Click(sender, e);
            }
        }

        private void txtLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLoginPassword.Focus();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtLoginId.Focus();            
        }
    }
}