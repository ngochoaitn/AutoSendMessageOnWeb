using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Data
{
    public class ThongTinTimKiem
    {
        public int TuTuoi { set; get; }
        public int DenTuoi { set; get; }
        public object NoiO { set; get; }
        public List<TinhTrangHonNhan> HonNhan { set; get; }
        public object GioiTinh { set; get; }
        public List<object> OtherParam { set; get; }
        /// <summary>
        /// Tìm những tài khoản đã đăng nhập được bao phút
        /// </summary>
        public int? ThoiGianDangNhap { get; set; } = null;
        public bool TimNguoiMoiDangKy { get; set; } = false;
        public bool TimNguoiOnline { get; set; } = false;
        public bool DungTimKiem { get; set; } = false;
        public ThongTinTimKiem()
        {
            this.HonNhan = new List<TinhTrangHonNhan>();
            this.OtherParam = new List<object>();
        }

        public class TinhTrangHonNhan
        {
            public string TenTinhTrang { set; get; }
            public object Id { set; get; }
        }
    }
}
