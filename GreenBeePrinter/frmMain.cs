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
using DevExpress.XtraEditors.Controls;
using Billing;

namespace GreenBeePrinter
{   
    public partial class frmMain : RibbonForm
    {       
        public frmMain()
        {
            InitializeComponent();
            Program.billingOder = new BillOreder(Program.printTemplate);
            pictureBoxIcoCart.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "images\\icon-cart.png");
        }
        

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.imageListBoxCart.ImageList = this.listViewMain.LargeImageList = Program.fruitsList;
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
                    fruit.image_print = Image.FromFile(path + fruit.image_name);
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
            if (!(Program.billingOder != null) || !Program.billingOder.canPrint())
            {
                MessageBox.Show("Nothing to print.", "Print error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Program.printSetting == null)
            {
                barButtonPrintSetting_ItemClick_1(sender, e);
            }

            frmPrint printForm = new frmPrint();
            printForm.ShowDialog();
            this.imageListBoxCart.Items.Clear();
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

        private void listViewMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listViewMain.SelectedItems.Count != 0)
            {
                if (this.imageListBoxCart.Items.Count<3)
                {  
                    ImageListBoxItem item = new ImageListBoxItem(this.listViewMain.SelectedItems[0].Text, this.listViewMain.SelectedItems[0].ImageIndex);

                    this.imageListBoxCart.Items.Add(item);                        
                    Program.billingOder.addFruit(Program.fruitPool[this.listViewMain.SelectedItems[0].Index]);
                }
                else
                {
                    MessageBox.Show("Out of bound (3 Fruits only).", "Print error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                             
            }
        }

        private void imageListBoxCart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.imageListBoxCart.SelectedItems.Count !=0)
            {
                int removeIdx = this.imageListBoxCart.Items.IndexOf(this.imageListBoxCart.SelectedItems[0]);
                this.imageListBoxCart.Items.RemoveAt(removeIdx);
                Program.billingOder.removeFruit(removeIdx);
            }
        }

    }
}