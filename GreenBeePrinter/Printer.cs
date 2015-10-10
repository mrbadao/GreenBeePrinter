using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GreenBeePrinter
{
    class Printer
    {
        PrintDocument printer;
        Image imagePrinted;

        public Printer()
        {
            this.printer = new PrintDocument();
            this.printer.PrintPage += new PrintPageEventHandler(printPage);
            this.imagePrinted = null;
        }

        public Printer(PrinterSettings printSettings)
        {
            this.printer = new PrintDocument();
            this.printer.PrintPage += new PrintPageEventHandler(printPage);
            this.imagePrinted = null;
            if (printSettings != null)
                this.printer.PrinterSettings = printSettings;
        }

        public bool Print(Image img)
        {
            this.imagePrinted = null;
            if (img != null)
            {
                this.imagePrinted = img;
                this.printer.Print();
                return true;
            }
            return false;
        }

        public bool Print(string imgPath)
        {
            this.imagePrinted = null;
            if (File.Exists(imgPath))
            {
                this.imagePrinted = Image.FromFile(imgPath);
                this.printer.Print();
                return true;
            }
            return false;
        }

        public void printerSettings(PrinterSettings printSettings)
        {
            if (printSettings != null)
            {
                this.printer.PrinterSettings = printSettings;
                PaperSize mPaperSize = new PaperSize("BillPage", 317, 515);
                this.printer.DefaultPageSettings.PaperSize = mPaperSize;
                this.printer.PrinterSettings.DefaultPageSettings.PaperSize = mPaperSize;
            }
        }

        private void printPage(object sender, PrintPageEventArgs e)
        {         
            e.Graphics.DrawImage(this.imagePrinted, 0, 0, 227, 369);
        }
    }
}
