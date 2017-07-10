using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.Security;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
