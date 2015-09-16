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
        }
        

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            this.listViewMain.LargeImageList = Program.fruitsList;
            barStaticCashierName.Caption = Program.cashier != null ? "Cashier: " + Program.cashier.display_name : "";
            loadFruits();            
        }

        private async void refreshFruits()
        {
            this.listViewMain.Items.Clear();
            Program.fruitsList.Images.Clear();
            await Program.getFruitPool();
            loadFruits();
        }

        private void loadFruits()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "fruits\\";
            this.listViewMain.View = View.LargeIcon;
            
            if (Program.fruitPool != null)
            {
                foreach (Fruit fruit in Program.fruitPool)
                {
                    Program.fruitsList.Images.Add(Image.FromFile(path + fruit.image_name));
                    ListViewItem item = new ListViewItem();
                    item.Text = fruit.name;
                    item.ImageIndex = Program.fruitsList.Images.Count-1;
                    this.listViewMain.Items.Add(item);
                }
            }
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.userAuthenticate = false;
            Program.cashier = null;
            Application.Exit();
        }

        private void barBtnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.userAuthenticate = false;
            Program.cashier = null;
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
            if (this.listViewMain.CheckedItems.Count != 3)
            {
                MessageBox.Show("Out of 3", "Print error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (ListViewItem item in this.listViewMain.CheckedItems)
            {
                item.Checked = false;
                Program.fruitsList.Images[item.ImageIndex].Save(item.Text + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            
            frmPrint printForm = new frmPrint();
            printForm.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            refreshFruits();
        }

        private void barButtonPrintSetting_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            PrintDialog printSettingDialog = new PrintDialog();

            if (printSettingDialog.ShowDialog() == DialogResult.OK)
            {
                Program.printSetting = printSettingDialog.PrinterSettings;
            }
        }

    }
}