using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;

namespace Billing
{
    public class BillOreder
    {
        Image templateImg;
        List<Fruit> PrintProducts;
        Image ico1, ico2, ico3;

        public BillOreder()
        {
            this.templateImg = null;
            this.PrintProducts = new List<Fruit>();
        }

        public BillOreder(string _templateImg)
        {
            this.templateImg = Image.FromFile(_templateImg);
            this.PrintProducts = new List<Fruit>();
        }

        public BillOreder(List<Fruit> _PrintProducts, string _templateImg)
        {
            this.templateImg = Image.FromFile(_templateImg);
            this.PrintProducts = _PrintProducts;
        }

        public bool removeFruit(int idx){
            if (this.PrintProducts.Count > 0 && idx < this.PrintProducts.Count)
            {
                this.PrintProducts.RemoveAt(idx);
                return true;
            }
            return false;
        }

        public bool addFruit(Fruit item)
        {
            if (this.PrintProducts.Count <= 3) {
                this.PrintProducts.Add(item);
                return true;
            }
            return false;
        }

        public bool canPrint()
        {
            return this.PrintProducts.Count == 3 && this.templateImg != null;
        }
        public Fruit getFinal(){
            Fruit finalProduct = new Fruit();

            for (int i = 0; i < this.PrintProducts.Count; i++)
            {
                finalProduct = this.PrintProducts[0] + this.PrintProducts[1] + this.PrintProducts[2];
                
            }
            return finalProduct;
        }

        public Image getPrintBillOrder()
        {
            Image printImage = null;
            int width = 715;
            int height = 715;
            Fruit finalProduct = new Fruit();

            for (int i=0; i<this.PrintProducts.Count; i++)
            {
                finalProduct = finalProduct + this.PrintProducts[i];
                printImage = this.InsertProduct(this.PrintProducts[i].image_print, i, width, height, this.templateImg);
            }


            printImage = this.DrawProductInfoKcal(printImage, finalProduct.Kcal.ToString());
            printImage = this.DrawProductInfoName(printImage, this.PrintProducts[0].name.ToString(), 1);
            printImage = this.DrawProductInfoName(printImage, this.PrintProducts[1].name + " " + this.PrintProducts[2].name, 2);

            printImage = this.DrawProductInfoNutri(printImage, "fiber", finalProduct.Fiber);
            printImage = this.DrawProductInfoNutri(printImage, "ca", finalProduct.Ca);
            printImage = this.DrawProductInfoNutri(printImage, "vb", finalProduct.VB);
            printImage = this.DrawProductInfoNutri(printImage, "ka", finalProduct.Ka);
            printImage = this.DrawProductInfoNutri(printImage, "va", finalProduct.VA);
            printImage = this.DrawProductInfoNutri(printImage, "vb1", finalProduct.VB1);
            printImage = this.DrawProductInfoNutri(printImage, "vb2", finalProduct.VB2);
            printImage = this.DrawProductInfoNutri(printImage, "vc", finalProduct.VC);
            printImage = this.DrawProductInfoNutri(printImage, "ve", finalProduct.VE);
            return printImage;
        }

        public Image InsertProduct(Image inputProduct, int position, int width, int height, Image templateImg)
        {
            Image bgImage = templateImg;
            using (Graphics g = Graphics.FromImage(bgImage))
            {
                switch (position)
                {
                    case 0:
                        g.DrawImage(inputProduct, 315, 190, width, height);
                        break;
                    case 1:
                        g.DrawImage(inputProduct, 935, 190, width, height);
                        break;
                    case 2:
                        g.DrawImage(inputProduct, 625, 720, width, height);
                        break;
                    default:
                        break;
                }

            }

            return bgImage;
        }

        public Image DrawProductInfoKcal(Image templateImg, string KcaVal)
        {
            Image billImage = templateImg;
            PrivateFontCollection billFont = new PrivateFontCollection();

            billFont.AddFontFile("fonts\\multicolore.ttf");
            FontFamily calFont = billFont.Families[0];

            using (Font drawFont = new Font(calFont, 66,FontStyle.Bold))
            using (Graphics g = Graphics.FromImage(billImage))
            {
                SizeF textSize = g.MeasureString(KcaVal, drawFont);
                g.DrawString(KcaVal, drawFont, new SolidBrush(Color.FromArgb(239, 81, 122)), 120, 1730);
            }
            return billImage;
        }

        public Image DrawProductInfoName(Image templateImg, string proName, int position)
        {
            Image billImage = templateImg;
            PrivateFontCollection billFont = new PrivateFontCollection();

            billFont.AddFontFile("fonts\\Nirmala.ttf");
            FontFamily calFont = billFont.Families[0];

            using (Font drawFont = new Font(calFont, 26,FontStyle.Regular))
            using (Graphics g = Graphics.FromImage(billImage))
            {
                SizeF textSize = g.MeasureString(proName, drawFont);
                g.DrawString(proName, drawFont, new SolidBrush(Color.FromArgb(239, 81, 122)), 1000 - textSize.Width / 2, position == 1 ? 1486 : 1602);
            
            }
            return billImage;
        }

        public Image DrawProductInfoNutri(Image templateImg, string nutriName, int nutriVal)
        {         
            Image billImage = templateImg;
            if (nutriVal == 0) return billImage;
            int w = 840;
            int addW = 116;
            Image icoImg = Image.FromFile("images\\ico\\ico_" + nutriVal.ToString() + ".png");

            switch (nutriName)
            {
                case "va":
                    w += addW * 4;
                    break;
                case "vb":
                    w += addW * 2;
                    break;
                case "vb1":
                    w += addW * 5;
                    break;
                case "vb2":
                    w += addW * 6;
                    break;
                case "vc":
                    w += addW * 7;
                    break;
                case "ve":
                    w += addW * 8;
                    break;
                case "ca":
                    w += addW * 1;
                    break;
                case "ka":
                    w += addW * 3;
                    break;
                case "fiber":
                    w = 840;
                    break;

            }

            using (Graphics g = Graphics.FromImage(billImage))
            {                
                if(nutriVal == 1)
                    g.DrawImage(icoImg, w, 1930);
                if (nutriVal == 2)
                    g.DrawImage(icoImg, w, 1843);
                if (nutriVal == 3)
                    g.DrawImage(icoImg, w, 1756);
            }
            return billImage;
        }
    }
}
