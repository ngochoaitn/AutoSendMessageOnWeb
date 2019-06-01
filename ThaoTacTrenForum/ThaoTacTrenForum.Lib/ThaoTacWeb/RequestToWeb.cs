using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThaoTacTrenForum.Lib.ThaoTacWeb
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
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/79.0.108 Chrome/73.0.3683.108 Safari/537.36";
                if (cookie != null)
                    request.CookieContainer = cookie;
                //request.KeepAlive = false;
                var response = request.GetResponse();
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.Headers.Add(HttpRequestHeader.AcceptLanguage, "vi-VN,vi;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5");
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                //request.Headers.Add(HttpRequestHeader.CacheControl, "max-age=0");
                //request.KeepAlive = true;
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

        public static async Task<WebResponse> GETAsync(Uri link, bool autoread, bool autoredirect = true, CookieContainer cookie = null)
        {
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.AllowAutoRedirect = autoredirect;
            try
            {
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/79.0.108 Chrome/73.0.3683.108 Safari/537.36";
                if (cookie != null)
                    request.CookieContainer = cookie;
                //request.KeepAlive = false;
                var response = await request.GetResponseAsync();
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.Headers.Add(HttpRequestHeader.AcceptLanguage, "vi-VN,vi;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5");
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                //request.Headers.Add(HttpRequestHeader.CacheControl, "max-age=0");
                //request.KeepAlive = true;
                if (autoread)
                    ReadStream(response.GetResponseStream());

                return response;
            }
            catch (Exception ex)
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
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/79.0.108 Chrome/73.0.3683.108 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.Headers.Add(HttpRequestHeader.AcceptLanguage, "vi-VN,vi;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5");
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                //request.Headers.Add(HttpRequestHeader.CacheControl, "max-age=0");
                //request.KeepAlive = true;

                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(data);
                    sw.Close();

                    var response = request.GetResponse();
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

        public static async Task<WebResponse> POSTAsync(Uri link, CookieContainer cookie, string data, bool autoread, bool allowredirect = false, string contenttype = "application/x-www-form-urlencoded")
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
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/79.0.108 Chrome/73.0.3683.108 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.Headers.Add(HttpRequestHeader.AcceptLanguage, "vi-VN,vi;q=0.9,fr-FR;q=0.8,fr;q=0.7,en-US;q=0.6,en;q=0.5");
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                //request.Headers.Add(HttpRequestHeader.CacheControl, "max-age=0");
                //request.KeepAlive = true;
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(data);
                    sw.Close();
                    var response = await request.GetResponseAsync();
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

    public static class ExtensionMethod_RequestToWeb
    {
        public static string ReadStream(this WebResponse response)
        {
            return RequestToWeb.ReadStream(response);
        }

        public static object ReadHeader(this WebResponse response)
        {
            return RequestToWeb.ReadHeader(response);
        }
    }
}
