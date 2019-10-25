using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib.ExtentionMethod
{
    public static class DataTypeEx
    {
        public static int? ConvertToInt32(this string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch
            {
                return null;
            }
        }
        public static string TrimAll(this string s)
        {
            return s.Replace("\n", "").Replace("\t", "").Replace("\r", "").Trim();
        }
        public static DateTime? ddMMyyyy(string s)
        {
            try
            {
                string[] spl = s.Split('/');
                int day = Convert.ToInt32(spl[0]);
                int month = Convert.ToInt32(spl[1]);
                int year = Convert.ToInt32(spl[2]);
                return new DateTime(year, month, day);
            }
            catch
            {
                return null;
            }
        }
        public static void LayThongTin(this ThongTinNguoiDung nguoidung, string manguoidung)
        {
            if (nguoidung == null)
                nguoidung = new ThongTinNguoiDung();
            string thongTin = Crypto.Decrypt(manguoidung);
            string[] data = thongTin.Split('[', ']');

            nguoidung.TenMay = data[1];
            nguoidung.MAC = data[3];
        }
        public static string TaoMaSuDung(this ThongTinNguoiDung nguoidung, DateTime hansudung)
        {
            return DataUseForSecurity.GenKeySendToClient(string.Format("[{0}][{1}]", nguoidung.TenMay, nguoidung.MAC), hansudung);
        }

        public static CookieCollection GetAllCookies(this CookieContainer cookieJar)
        {
            CookieCollection cookieCollection = new CookieCollection();

            Hashtable table = (Hashtable)cookieJar.GetType().InvokeMember("m_domainTable",
                                                                            BindingFlags.NonPublic |
                                                                            BindingFlags.GetField |
                                                                            BindingFlags.Instance,
                                                                            null,
                                                                            cookieJar,
                                                                            new object[] { });

            foreach (var tableKey in table.Keys)
            {
                String str_tableKey = (string)tableKey;

                if (str_tableKey[0] == '.')
                {
                    str_tableKey = str_tableKey.Substring(1);
                }

                SortedList list = (SortedList)table[tableKey].GetType().InvokeMember("m_list",
                                                                            BindingFlags.NonPublic |
                                                                            BindingFlags.GetField |
                                                                            BindingFlags.Instance,
                                                                            null,
                                                                            table[tableKey],
                                                                            new object[] { });

                foreach (var listKey in list.Keys)
                {
                    String url = "https://" + str_tableKey + (string)listKey;
                    cookieCollection.Add(cookieJar.GetCookies(new Uri(url)));
                }
            }

            return cookieCollection;
        }

        public static string ConvertToUrlEncode(this System.Collections.Specialized.NameValueCollection co)
        {
            string res = "";

            foreach(var c in co.AllKeys)
                res += string.Format("&{0}={1}", c, co[c]);

            return res.Substring(1);
        }

        public static T GetRandomElement<T>(this IEnumerable<T> lst)
        {
            Random rand = new Random();
            return lst.ElementAt(rand.Next(0, lst.Count()));
        }
    }
}
