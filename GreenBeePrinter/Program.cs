using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Printing;

namespace GreenBeePrinter
{
    static class Program
    {
        public static bool userAuthenticate { get; set; }
        public static Cashier cashier { get; set; }

        public static ImageList fruitsList;
        public static List<Fruit> fruitPool;

        public static PrinterSettings printSetting;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            cashier = null;
            userAuthenticate = false;

            fruitsList = new ImageList();
            fruitsList.ImageSize = new Size(64, 64);
            fruitsList.Images.Clear();

            printSetting = null;

            Program.getFruitPool();
            

            if (!userAuthenticate)
            {
                Application.Run(new frmLogin());
            }

            if (userAuthenticate)
            {
                Application.Run(new frmMain());
            }
        }

        public static async Task getFruitPool()
        {
            fruitPool = null;
            fruitPool = await ApiCore.getJsonObj<List<Fruit>>("fruit/getall/", null);
        }
    }
}