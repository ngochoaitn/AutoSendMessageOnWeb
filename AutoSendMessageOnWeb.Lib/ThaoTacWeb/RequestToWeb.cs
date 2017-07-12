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
        public static WebResponse GET(Uri link, bool autoread)
        {
            HttpWebRequest request = WebRequest.CreateHttp(link);

            try
            {
                request.Method = "GET";

                var response = request.GetResponse();

                if (autoread)
                {
                    //Làm thế này sẽ hết lỗi timeout
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string ss = sr.ReadToEnd();
                    }
                    var httpRes = (HttpWebResponse)response;
                    if (httpRes != null)
                    {
                        using (StreamReader sr = new StreamReader(httpRes.GetResponseStream()))
                        {
                            string ss = sr.ReadToEnd();
                        }
                    }
                }

                return response;
            }
            catch
            {
                request.Abort();
                return null;
            }
        }

        public static WebResponse POST(Uri link, CookieContainer cookie, string data, bool autoread, bool allowredirect=false, string contenttype= "application/x-www-form-urlencoded")
        {
            HttpWebRequest request = WebRequest.CreateHttp(link);
            try
            {
                request.AllowAutoRedirect = allowredirect;
                request.Method = "POST";
                if (cookie != null)
                    request.CookieContainer = cookie;
                request.ContentType = "application/x-www-form-urlencoded";

                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(data);
                    sw.Close();
                    var response = request.GetResponse();

                    if (autoread)
                    {
                        //Làm thế này sẽ hết lỗi timeout
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            string ss = sr.ReadToEnd();
                        }

                        try
                        {
                            var httpRes = response as HttpWebResponse;
                            using (StreamReader sr2 = new StreamReader(httpRes.GetResponseStream()))
                            {
                                string ss2 = sr2.ReadToEnd();
                            }
                        }
                        catch { }
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                request.Abort();
                return null;
            }
        }
    }
}
