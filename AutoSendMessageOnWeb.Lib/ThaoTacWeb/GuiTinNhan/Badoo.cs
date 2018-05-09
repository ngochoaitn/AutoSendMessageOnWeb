using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSendMessageOnWeb.Data;
using System.Net;
using System.IO;

namespace AutoSendMessageOnWeb.Lib
{
    public class Badoo : IGuiTinNhan
    {
        public CookieContainer Cookie { set; get; }

        public bool TimKiemYeuCauCookie
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void DangNhap(ref ThongTinTaiKhoan tk)
        {
            throw new NotImplementedException();
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> call_back=null)
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

        public static void Test()
        {
            #region Logout
            RequestToWeb.GET(new Uri("https://badoo.com/profile/logout"), true);
            //HttpWebRequest logoutRequest = WebRequest.CreateHttp("https://badoo.com/profile/logout");
            //logoutRequest.Method = "GET";
            //var logoutResponse = logoutRequest.GetResponse();
            #endregion

            #region Login
            CookieContainer loginCookie = new CookieContainer();
            HttpWebRequest loginRequest1 = WebRequest.CreateHttp("https://badoo.com/signin");

            loginRequest1.CookieContainer = loginCookie;
            loginRequest1.Method = "GET";
            loginRequest1.AllowAutoRedirect = true;
            loginRequest1.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/64.4.142 Chrome/58.4.3029.142 Safari/537.36";
            loginRequest1.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //loginRequest1.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, sdch, br");
            loginRequest1.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,vi;q=0.6");
            loginRequest1.KeepAlive = true;
            loginRequest1.Headers.Add("DNT", "1");
            loginRequest1.Headers.Add("Upgrade-Insecure-Requests", "1");
            //using (StreamWriter sw = new StreamWriter(loginRequest1.GetRequestStream()))
            //{
            //    string data = File.ReadAllLines("DataHtmlTest.txt")[0];
            //    sw.Write(data);
            //    sw.Close();
            //}
            var loginRequest1Header = RequestToWeb.ReadHeader(loginRequest1.Headers);

            var loginResponse1 = loginRequest1.GetResponse();

            string sLoginCookie = loginResponse1.Headers[HttpResponseHeader.SetCookie];
            string sCookie1 = loginRequest1.Headers[HttpRequestHeader.Cookie];
            string sLoginLoc1 = loginResponse1.Headers[HttpResponseHeader.Location];

            var loginHeader1 = RequestToWeb.ReadHeader(loginResponse1.Headers);

            string logginS1 = "";
            using (StreamReader sr = new StreamReader(loginResponse1.GetResponseStream()))
            {
                logginS1 = sr.ReadToEnd();
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Bước 2

            HttpWebRequest loginRequestB2 = WebRequest.CreateHttp("https://badoo.com/api.phtml?SERVER_APP_STARTUP");

            loginRequestB2.CookieContainer = loginCookie;
            loginRequestB2.Method = "POST";
            loginRequestB2.AllowAutoRedirect = true;
            loginRequestB2.ContentType = "json";
            loginRequestB2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/64.4.142 Chrome/58.4.3029.142 Safari/537.36";
            loginRequestB2.KeepAlive = true;
            //loginRequest2.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
            loginRequestB2.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,vi;q=0.6");
            loginRequestB2.Referer = "https://badoo.com/signin";
            loginRequestB2.Headers.Add("X-Session-id", sLoginCookie.Split(new string[] { "s2=", ";" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            loginRequestB2.Headers.Add("X-Message-type:2");

            int indexIfDeviceId = sLoginCookie.IndexOf("device_id");
            string deviceId = sLoginCookie.Substring(indexIfDeviceId);
            deviceId = deviceId.Substring(10);
            deviceId = deviceId.Substring(0, deviceId.IndexOf(";"));

            using (StreamWriter sw = new StreamWriter(loginRequestB2.GetRequestStream()))
            {
                string data = File.ReadAllLines("BadooTest.txt")[1].Replace("_DEVICEID_", deviceId);
                sw.Write(data);
                sw.Close();
            }

            var loginResponseB2 = loginRequestB2.GetResponse();

            string sLoginCookieB2 = loginResponseB2.Headers[HttpResponseHeader.SetCookie];
            string sCookieB2 = loginRequestB2.Headers[HttpRequestHeader.Cookie];
            string sLoginLocB2 = loginResponseB2.Headers[HttpResponseHeader.Location];

            var loginHeaderB2 = RequestToWeb.ReadHeader(loginResponseB2.Headers);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////LẦN 2
            HttpWebRequest loginRequest2 = WebRequest.CreateHttp("https://badoo.com/api.phtml?SERVER_LOGIN_BY_PASSWORD");

            loginRequest2.CookieContainer = loginCookie;
            loginRequest2.Method = "POST";
            loginRequest2.AllowAutoRedirect = true;
            loginRequest2.ContentType = "json";
            loginRequest2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/64.4.142 Chrome/58.4.3029.142 Safari/537.36";
            loginRequest2.KeepAlive = true;
            //loginRequest2.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
            loginRequest2.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,vi;q=0.6");
            loginRequest2.Referer = "https://badoo.com/signin";
            loginRequest2.Headers.Add("X-Session-id", sLoginCookie.Split(new string[] { "s2=", ";" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            //loginRequest2.Headers.Add("X-Message-type:15");

            using (StreamWriter sw = new StreamWriter(loginRequest2.GetRequestStream()))
            {
                string data = File.ReadAllLines("BadooTest.txt")[0];
                sw.Write(data);
                sw.Close();
            }

            var loginResponse2 = loginRequest2.GetResponse();

            string sLoginCookie2 = loginResponse2.Headers[HttpResponseHeader.SetCookie];
            string sCookie2 = loginRequest2.Headers[HttpRequestHeader.Cookie];
            string sLoginLoc2 = loginResponse2.Headers[HttpResponseHeader.Location];

            var loginHeader2 = RequestToWeb.ReadHeader(loginResponse2.Headers);

            string logginS2 = "";
            using (StreamReader sr = new StreamReader(loginResponse2.GetResponseStream()))
            {
                logginS2 = sr.ReadToEnd();
                sr.Close();//Đã ok đến đây
            }
            #endregion

            #region Search
            
            #endregion
        }
    }
}
