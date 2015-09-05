using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.IO;
using System.Drawing;

namespace GreenBeePrinter
{
    static class Program
    {
        public static bool userAuthenticate { get; set; }
        public static ImageList fruitsList;

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

            userAuthenticate = false;
            fruitsList = new ImageList();
            fruitsList.ImageSize = new Size(64, 64);

            DirectoryInfo directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "fruits\\");
            FileInfo[] Archives = directory.GetFiles("*.png");
            foreach (FileInfo fileinfo in Archives)
            {
                Program.fruitsList.Images.Add(Image.FromFile(fileinfo.FullName));
            }

//             if (!userAuthenticate)
//             {
//                 Application.Run(new frmLogin());
//             }

            if (!userAuthenticate)
            {
                Application.Run(new frmMain());
            }
        }
    }
}