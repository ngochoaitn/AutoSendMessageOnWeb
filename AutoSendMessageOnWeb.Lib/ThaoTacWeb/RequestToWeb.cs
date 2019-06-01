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
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/78.0.136 Chrome/72.0.3626.136 Safari/537.36";
                if (cookie != null)
                    request.CookieContainer = cookie;
                //request.KeepAlive = false;
                var response = request.GetResponse();

                if (autoread)
                    ReadStream(response.GetResponseStream());

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
                        ReadStream(response.GetResponseStream());
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
                        ReadStream(response.GetResponseStream());
                    #endregion
                    return response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Dictionary<string, string> ReadHeader(WebHeaderCollection headers)
        {
            Dictionary<string, string> res = new Dictionary<string, string>();
            foreach (var h in headers)
                res.Add(h.ToString(), headers[h.ToString()]);
            return res;
        }

        public static string ReadStream(Stream s)
        {
            using (StreamReader sr = new StreamReader(s))
            {
                string res = sr.ReadToEnd();
                return res;
            }
        }
        public static string ReadStream(WebResponse response)
        {
            try
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    string res = sr.ReadToEnd();
                    return res;
                }
            }
            catch
            {
                return null;
            }
        }

        internal static object ReadHeader(WebResponse response)
        {
            return ReadHeader(response.Headers);
        }
    }
}
