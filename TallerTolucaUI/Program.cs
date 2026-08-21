using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    internal static class Program
    {
        /// <summary>
        ///  Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            if (args != null && args.Length > 0 && args[0] == "--capture-clientes")
            {
                using (var frm = new FrmClientes())
                {
                    frm.Show();
                    Application.DoEvents();
                    using (Bitmap bmp = new Bitmap(frm.Width, frm.Height))
                    {
                        frm.DrawToBitmap(bmp, new Rectangle(0, 0, frm.Width, frm.Height));
                        string artifactDir = @"C:\Users\user1\.gemini\antigravity-ide\brain\97ccc333-1136-4946-a0c6-95ed9084f2ff";
                        string outPath = Path.Combine(artifactDir, "clientes_preview.png");
                        bmp.Save(outPath, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    frm.Close();
                }
                return;
            }

            if (args != null && args.Length > 0 && args[0] == "--capture")
            {
                using (var frm = new FrmLogin())
                {
                    frm.Show();
                    Application.DoEvents();
                    using (Bitmap bmp = new Bitmap(frm.Width, frm.Height))
                    {
                        frm.DrawToBitmap(bmp, new Rectangle(0, 0, frm.Width, frm.Height));
                        string artifactDir = @"C:\Users\user1\.gemini\antigravity-ide\brain\97ccc333-1136-4946-a0c6-95ed9084f2ff";
                        string outPath = Path.Combine(artifactDir, "login_preview.png");
                        bmp.Save(outPath, System.Drawing.Imaging.ImageFormat.Png);
                        bmp.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "login_preview.png"), System.Drawing.Imaging.ImageFormat.Png);
                    }
                    frm.Close();
                }
                return;
            }

            Application.Run(new FrmLogin());
        }
    }
}