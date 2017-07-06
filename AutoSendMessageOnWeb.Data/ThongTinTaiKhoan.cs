using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Data
{
    [Serializable]
    public partial class ThongTinTaiKhoan
    {
        public string Id { set; get; }
        public string TaiKhoan { set; get; }
        public string MatKhau { set; get; }
        public string TenHienThi { set; get; }
        public CookieContainer Cookie { set; get; }
        public string Url { set; get; }
        public string TrangThai { set; get; }
        [DefaultValue(true)]
        public bool ChoPhepGuiNhan { set; get; }
    }
}
