using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Data
{
    public enum TrangWeb
    {
        ThongTinNguoiDung,
        HenHo2,
        DuyenSo,
        VietNamCupid,
        LikeYou,
        HenHoKetBan,
        TimBanGai
    }
    public class UriTrangWeb
    {
        public static Uri HenHo2
        {
            get
            {
                return new Uri("http://henho2.com");
            }
        }
        public static Uri DuyenSo
        {
            get
            {
                return new Uri("http://duyenso.com");
            }
        }
        public static Uri VietNamCupid
        {
            get
            {
                return new Uri("https://www.vietnamcupid.com");
            }
        }
        public static Uri Ehenho
        {
            get
            {
                return new Uri("https://www.ehenho.com");
            }
        }
    }
}
