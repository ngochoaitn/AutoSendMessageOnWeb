using AutoSendMessageOnWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb
{
    /// <summary>
    /// Mỗi web thực hiệc các thao tác một kiểu khác nhau => kế thừa rồi tự thực hiện
    /// </summary>
    public interface IGuiTinNhan
    {
        void DangNhap(ref ThongTinTaiKhoan tk);
        IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param);
        IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding);
        void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> callback=null);
        DanhSachDuLieuTimKiem TaoDuLieuTimKiem();
        bool TimKiemYeuCauCookie { get; }
        CookieContainer Cookie { set; get; }
    }
}
