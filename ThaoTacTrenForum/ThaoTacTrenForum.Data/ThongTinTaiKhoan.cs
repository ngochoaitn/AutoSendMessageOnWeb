using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThaoTacTrenForum.Data
{
    [Serializable]
    public partial class ThongTinTaiKhoan
    {
        public string Id { set; get; }
        public string TaiKhoan { set; get; }
        public string MatKhau { set; get; }
        public string GioiTinh { set; get; }
        public string TenHienThi { set; get; }
        public string TrangThai { set; get; }
        public bool ChoPhepGuiNhan { set; get; } = true;
        public int SoTinNhanSeGui { get; set; } = 10;
        public string Url => $"https://www.webtretho.com/forum/member.php?u={this.Id}";
        public CookieContainer Cookie { get; set; } = null;
        public bool YeuCauDangNhapMoi
        {
            get
            {
                return true;
                //return this.HanCookie == null || this.Cookie == null || (this.HanCookie.HasValue && this.HanCookie.Value <= DateTime.Now);
            }
        }
    }
}
