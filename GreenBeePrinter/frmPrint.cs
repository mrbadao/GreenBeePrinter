using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Billing;

namespace GreenBeePrinter
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public Image printImage;
        private Printer mPrinter;

        public frmPrint()
        {
            this.mPrinter = new Printer();
            this.mPrinter.printerSettings(Program.printSetting);
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            picPrint.Image = Program.billingOder.getPrintBillOrder();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Program.billingOder = new BillOreder(Program.printTemplate);
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            mPrinter.Print(picPrint.Image);
            Program.billingOder = new BillOreder(Program.printTemplate);
            this.Close();
        }
    }
}
