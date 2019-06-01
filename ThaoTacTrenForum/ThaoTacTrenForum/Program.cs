using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace ThaoTacTrenForum
{
    static class Program
    {
        public static event Action XayRaLoi;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new Forms.FormMain());
        }


        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            string loi = ex.Message;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                loi += ("\n" + ex.Message);
            }
            if (XayRaLoi != null)
                XayRaLoi();
            MessageBox.Show(loi, "Đã xẩy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
