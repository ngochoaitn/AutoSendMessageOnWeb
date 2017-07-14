using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb
{
    public class RequestToWeb
    {
        public static WebResponse GET(Uri link, bool autoread, bool autoredirect=true, CookieContainer cookie=null)
        {
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.AllowAutoRedirect = autoredirect;
            try
            {
                request.Method = "GET";
                if (cookie != null)
                    request.CookieContainer = cookie;
                var response = request.GetResponse();

                if (autoread)
                {
                    //Làm thế này sẽ hết lỗi timeout
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string ss = sr.ReadToEnd();
                    }
                }

                return response;
            }
            catch(Exception ex)
            {
                //request.Abort();
                return null;
            }
        }

        public static WebResponse POST(Uri link, CookieContainer cookie, string data, bool autoread, bool allowredirect=false, string contenttype= "application/x-www-form-urlencoded")
        {
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(link);

                if (cookie != null)
                    request.CookieContainer = cookie;
                request.Method = "POST";
                request.AllowAutoRedirect = allowredirect;
                if (contenttype != null)
                    request.ContentType = contenttype;
                //request.UserAgent = "user-agent:Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/64.4.142 Chrome/58.4.3029.142 Safari/537.36";

                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(data);
                    sw.Close();
                    var response = request.GetResponse();
                    string header = "";
                    foreach (var h in response.Headers)
                        header += string.Format("{0} = {1}\n", h.ToString(), response.Headers[h.ToString()]);
                    #region Xử lý Time out
                    if (autoread)
                    {
                        //Làm thế này sẽ hết lỗi timeout
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            string ss = sr.ReadToEnd();
                        }
                    }
                    #endregion

                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static WebResponse POST2(Uri link, CookieContainer cookie, string data, bool autoread, bool allowredirect = false, string contenttype = "application/x-www-form-urlencoded")
        {
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(link);

                if (cookie != null)
                    request.CookieContainer = cookie;
                request.Method = "POST";
                request.AllowAutoRedirect = allowredirect;
                if (contenttype != null)
                    request.ContentType = contenttype;
                byte[] dataArray = Encoding.UTF8.GetBytes(data);
                request.ContentLength = dataArray.Length;
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(data, 0, data.Length);
                    sw.Close();

                    var response = request.GetResponse();
                    string header = "";
                    foreach (var h in response.Headers)
                        header += string.Format("{0} = {1}\n", h.ToString(), response.Headers[h.ToString()]);

                    #region Xử lý Time out
                    if (autoread)
                    {
                        //Làm thế này sẽ hết lỗi timeout
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            string ss = sr.ReadToEnd();
                        }
                    }
                    #endregion
                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
