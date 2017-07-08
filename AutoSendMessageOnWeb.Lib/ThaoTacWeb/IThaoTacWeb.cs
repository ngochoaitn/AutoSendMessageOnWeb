using AutoSendMessageOnWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb
{
    /// <summary>
    /// Mỗi web thực hiệc các thao tác một kiểu khác nhau => kế thừa rồi tự thực hiện
    /// </summary>
    public interface IThaoTacWeb
    {
        ThongTinTaiKhoan DangNhap(string taikhoan, string matkhau);
        void DangNhap(ref ThongTinTaiKhoan taikhoan);
        IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param);
        IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding);
        void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung);
        DanhSachDuLieuTimKiem TaoDuLieuTimKiem();
    }
}
