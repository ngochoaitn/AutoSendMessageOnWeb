using AutoSendMessageOnWeb.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSendMessageOnWeb.CreateKey
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException;

            StartUpOperation.CheckFile();

            Application.Run(new frmMain());
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
            MessageBox.Show(loi, "Đã xẩy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
