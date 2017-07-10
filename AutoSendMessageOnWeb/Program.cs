﻿using AutoSendMessageOnWeb.Lib;
using AutoSendMessageOnWeb.Lib.Security;
using System;
using System.IO;
using System.Windows.Forms;

namespace AutoSendMessageOnWeb
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartUpOperation.CheckFile();
            //Application.Run(new frmTest());
            //new frmTest().ShowDialog();
            try
            {
                DateTime? hanSuDung = Crypto.VerifySignature(File.ReadAllText(ConstFilePath.FILE_KEY));
                if (hanSuDung != null && hanSuDung >= DataUseForSecurity.GetReadDate())
                {
                    Application.Run(new frmMain());
                }
                else
                {
                    if(new frmVerify().ShowDialog() == DialogResult.OK)
                        Application.Run(new frmMain());
                }
            }
            catch
            {
                if (new frmVerify().ShowDialog() == DialogResult.OK)
                    Application.Run(new frmMain());
            }
            
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            string loi = ex.Message;
            while(ex.InnerException != null)
            {
                ex = ex.InnerException;
                loi += ("\n" + ex.Message);
            }
            MessageBox.Show(loi, "Đã xẩy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
