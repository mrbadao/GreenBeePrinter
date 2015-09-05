using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenBeePrinter
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public Image printImage;
        private Printer mPrinter;

        public frmPrint()
        {
            printImage = Image.FromFile("nutrition.png");
            this.mPrinter = new Printer();
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            picPrint.Image = printImage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            mPrinter.Print(printImage);
            this.Close();
        }
    }
}
