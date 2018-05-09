using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSendMessageOnWeb.Data;
using System.Net;
using HtmlAgilityPack;
using System.IO;

namespace AutoSendMessageOnWeb.Lib
{
    public class ehenho : IGuiTinNhan
    {
        public CookieContainer Cookie { set; get; }

        public bool TimKiemYeuCauCookie => false;

        public void DangNhap(ref ThongTinTaiKhoan tk)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://www.ehenho.com/");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.AllowAutoRedirect = false;
            request.Method = "GET";
            //var xx = RequestToWeb.ReadHeader(request.GetResponse());
            var response = request.GetResponse();
            var s = RequestToWeb.ReadStream(response.GetResponseStream());
            HtmlDocument document = new HtmlDocument();

            document.LoadHtml(s);
            var value = document.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='csrfmiddlewaretoken']")
                .Attributes["value"].Value;
            string cookie = response.Headers[HttpResponseHeader.SetCookie];
            tk.Cookie = new CookieContainer();
            tk.Cookie.SetCookies(UriTrangWeb.Ehenho, cookie);
            
            request = WebRequest.CreateHttp("https://www.ehenho.com/accounts/login/");
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.AllowAutoRedirect = false;
            request.Method = "POST";
            request.CookieContainer = tk.Cookie;
            //string data = $"login={tk.TaiKhoan}&password={tk.MatKhau}&remember=on&X-CSRFToken={cookie.Split(';')[0].Split('=')[1]}&csrfmiddlewaretoken={value}";
            string data = $"login={tk.TaiKhoan}&password={tk.MatKhau}&remember=on&X-CSRFToken={cookie.Split(';')[0].Split('=')[1]}";
            using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Close();
                var response2 = request.GetResponse();
                var xx = RequestToWeb.ReadHeader(response2);
            }
            
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> callback = null)
        {
            throw new NotImplementedException();
        }

        public DanhSachDuLieuTimKiem TaoDuLieuTimKiem()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            throw new NotImplementedException();
        }
    }
}
