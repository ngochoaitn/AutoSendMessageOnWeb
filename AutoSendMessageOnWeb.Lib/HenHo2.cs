using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSendMessageOnWeb.Data;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace AutoSendMessageOnWeb.Lib
{
    public class HenHo2 : IThaoTacWeb
    {
        public ThongTinTaiKhoan DangNhap(string taikhoan, string matkhau)
        {
            ThongTinTaiKhoan res = new ThongTinTaiKhoan();

            HttpWebRequest request = WebRequest.CreateHttp("http://henho2.com/Account/Login");
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = false;
            request.Method = "POST";

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(string.Format("Email={0}&Password={1}&RememberMe=true&returnUrl=%2F", taikhoan, matkhau));
            sw.Close();

            var response = request.GetResponse();
            var httpRes = response as HttpWebResponse;

            res.TaiKhoan = taikhoan;
            res.MatKhau = matkhau;

            if (httpRes.StatusCode == HttpStatusCode.Found)
            {
                string setCookie = httpRes.Headers[HttpResponseHeader.SetCookie];
                res.Cookie = new CookieContainer();
                res.Cookie.SetCookies(UriTrangWeb.HenHo2, setCookie);
                res.TrangThai = "Đang nhập thành công";
            }
            else
            {
                res.TrangThai = "Sai tài khoản hoặc mật khẩu";
                res.Cookie = null;
            }

            return res;
        }

        public void DangNhap(ref ThongTinTaiKhoan tk)
        {
            HttpWebRequest request = WebRequest.CreateHttp("http://henho2.com/Account/Login");
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = false;
            request.Method = "POST";
            
            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(string.Format("Email={0}&Password={1}&RememberMe=true&returnUrl=%2F", tk.TaiKhoan, tk.MatKhau));
            sw.Close();

            var response = request.GetResponse();
            var httpRes = response as HttpWebResponse;

            if (httpRes.StatusCode == HttpStatusCode.Found)
            {
                string setCookie = httpRes.Headers[HttpResponseHeader.SetCookie];
                tk.Cookie = new CookieContainer();
                tk.Cookie.SetCookies(UriTrangWeb.HenHo2, setCookie);
                tk.TrangThai = "Đang nhập thành công";
            }
            else
            {
                tk.TrangThai = "Sai tài khoản hoặc mật khẩu";
                tk.Cookie = null;
            }


            sw.Dispose();
            request.Abort();

            httpRes.Close();
            httpRes.Dispose();

            response.Close();
            response.Dispose();
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung)
        {
            if (nguoigui.Cookie == null)
                throw new Exception("Thiếu cookie");

            HttpWebRequest request = WebRequest.CreateHttp("http://henho2.com/Message/Create");
            request.AllowAutoRedirect = false;
            request.Method = "POST";
            request.CookieContainer = nguoigui.Cookie;
            request.ContentType = "application/x-www-form-urlencoded";

            string data = string.Format("IdTo={0}&NameTo={1}&Title={2}&MessageContent={3}", nguoinhan.Id, nguoinhan.TenHienThi, tieude, noidung);
            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(data);
            sw.Close();

            var response = request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string ss = sr.ReadToEnd();

            var httpRes = response as HttpWebResponse;
            StreamReader sr2 = new StreamReader(httpRes.GetResponseStream());
            string ss2 = sr2.ReadToEnd();
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            throw new NotImplementedException("Tính năng đang xây dựng");
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            frmTimKiemBrowser tk = new frmTimKiemBrowser(TrangWeb.HenHo2);
            if (binding != null)
                tk.DanhSachTaiKhoanDuocChon = binding;

            if (tk.ShowDialog() == DialogResult.OK)
                return tk.DanhSachTaiKhoanDuocChon;
            else
                return binding;
        }
    }
}
