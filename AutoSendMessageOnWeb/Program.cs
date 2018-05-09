using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib;
using AutoSendMessageOnWeb.Lib.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSendMessageOnWeb
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
            //Lib.ThaoTacWeb.IGuiTinNhan x = new ehenho();
            //ThongTinTaiKhoan tk = new ThongTinTaiKhoan() {TaiKhoan = "asbirine@gmail.com", MatKhau = "noongngocj" };
            //x.DangNhap(ref tk);

            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartUpOperation.CheckFile();
            //Application.Run(new frmTest());
            //new frmTest().ShowDialog();
            frmMainTab main = new frmMainTab();
            try
            {
                var keys = File.ReadAllLines(ConstFilePath.FILE_KEY);
                DateTime? hanSuDung = null;

                foreach (string k in keys)
                {
                    hanSuDung = Crypto.VerifySignature(k);
                    if (hanSuDung != null && hanSuDung >= DataUseForSecurity.GetReadDate())
                        break;
                }

                if (hanSuDung != null && hanSuDung >= DataUseForSecurity.GetReadDate())
                {
                    Application.Run(main);
                }
                else
                {
                    if(new frmVerify().ShowDialog() == DialogResult.OK)
                        Application.Run(main);
                }
            }
            catch
            {
                if (new frmVerify().ShowDialog() == DialogResult.OK)
                    Application.Run(main);
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
            if (XayRaLoi != null)
                XayRaLoi();
            MessageBox.Show(loi, "Đã xẩy ra lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
