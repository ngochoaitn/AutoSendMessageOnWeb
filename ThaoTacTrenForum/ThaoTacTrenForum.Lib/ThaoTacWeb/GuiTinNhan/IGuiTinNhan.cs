using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThaoTacTrenForum.Data;

namespace ThaoTacTrenForum.Lib.ThaoTacWeb.GuiTinNhan
{
    public interface IGuiTinNhan
    {
        Task DangNhapAsync(ThongTinTaiKhoan tk);
        IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param);
        IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding);
        void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> callback = null);
        DanhSachDuLieuTimKiem TaoDuLieuTimKiem();
        bool TimKiemYeuCauCookie { get; }
        CookieContainer Cookie { set; get; }
    }
}
