using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System.Threading;

using System.Drawing.Printing;
using System.IO;

namespace GreenBeePrinter
{   
    public partial class frmMain : RibbonForm
    {
        

        public frmMain()
        {
            InitializeComponent();
            this.listViewMain.View = View.LargeIcon;   
        }
        

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            this.listViewMain.LargeImageList = Program.fruitsList;
            ListViewItem item = new ListViewItem();
            item.ImageIndex = 2;
            item.Text = "item 1";
            listViewMain.Items.Add(item);

            ListViewItem item1 = new ListViewItem();
            item1.ImageIndex = 0;
            item1.Text = "item 2";
            listViewMain.Items.Add(item1);

            ListViewItem item2 = new ListViewItem();
            item2.ImageIndex = 1;
            item2.Text = "item 3";
            listViewMain.Items.Add(item2);
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barBtnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Restart();
            this.Close();
        }

        private void notifyIcoGreenBee_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown || e.CloseReason == CloseReason.ApplicationExitCall) return;
            
            // Confirm user wants to close
            e.Cancel = true;
            this.Hide();
        }

        private void barButtonPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPrint printForm = new frmPrint();
            printForm.ShowDialog();
        }

        private void ribbonControl_Click(object sender, EventArgs e)
        {

        }

    }
}