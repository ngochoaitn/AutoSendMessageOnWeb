using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb.DangKy
{
    public class TuDongDangKyHenHoKetBan : ITuDongDangKy
    {
        public Image Captcha()
        {
            return null;//k cần capchar
        }

        public async Task<Image> CaptchaAsync()
        {
            await Task.Delay(0);
            return null;//k cần capchar
        }

        public ThongTinTaiKhoan DangKyTaiKhoanMoi(string tai_khoan, string mat_khau, Func<string> captcha, ThongTinBoSung thong_tin_bo_sung = null)
        {
            throw new NotImplementedException();
        }

        public async Task<ThongTinTaiKhoan> DangKyTaiKhoanMoiAsync(string tai_khoan, string mat_khau, string ho_ten, Func<string> captcha, ThongTinBoSung thong_tin_bo_sung = null)
        {
            Random ran = new Random();
            List<string> lstHonNhan = new List<string>() {"Độc thân", "Có người yêu", "Có gia đình", "Ly hôn", "Ở góa" };
            List<string> lstMucTieu = new List<string>() { "Yêu lâu dài", "Tìm bạn bè", "Tâm sự" };
            List<string> lstHocVan = new List<string>() { "Phổ thông", "Trung cấp", "Cao đẳng", "Đại học", "Thạc sỹ", "Tiến sỹ", "Giáo sư" };
            List<string> lstDenTu = new List<string>() { "Tp.HCM", "Hà Nội", "Đà Nẵng", "An Giang", "BR Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu",
            "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận", "Yên Bái", "Vĩnh Phúc", "Vĩnh Long",
            "Tuyên Quang", "Trà Vinh", "Thái Nguyên", "Sóc Trăng", "Quảng Ninh", "Quảng Nam", "Lạng Sơn", "Lai Châu", "Hưng Yên"};
            List<string> lstToiLa = new List<string>() { "Người yêu văn học", "Thích lên bar", "Muốn tìm bạn lâu dài", "Inbox lấy số", "Thích sự chủ động",
            "Đam mê du lịch, khám phá đi đây đi đó", "Đọc sách là sở thích của tôi", "Ham của cải vật chất"};
            List<string> lstTimNguoi = new List<string>() { "Có trách nhiệm, dám nói dám làm", "Biết sửa máy tính", "Thế nào cũng được", "Sòng phẳng, thích thì chơi, không thì nghỉ",
            "Rõ ràng, không lợi dụng", "Không vụ lợi, lợi dụng", "Cùng nhau đi nốt quãng đời còn lại"};
            string email = tai_khoan;
            string taiKhoan = tai_khoan.Contains("@") ? tai_khoan.Substring(0, tai_khoan.IndexOf("@")) : tai_khoan;
            string data = $"username={taiKhoan}&pass={mat_khau}&name={ho_ten}&email={email}&gioitinh={thong_tin_bo_sung.GioiTinh}&tuoi={ran.Next(18, 60)}"
                + $"&chieucao={ran.Next(140, 200)}&cannang={ran.Next(45, 80)}&honnhan={lstHonNhan.GetRandomElement()}&muctieu={lstMucTieu.GetRandomElement()}"
                + $"&hocvan={lstHocVan.GetRandomElement()}&dentu={lstDenTu.GetRandomElement()}&nuoc=VietNam&toila={lstToiLa.GetRandomElement()}"
                + $"&timnguoi={lstTimNguoi.GetRandomElement()}&btn_submit=HOÀN TẤT HỒ SƠ";
            string linkDangKy = "https://henhoketban.vn/register.php";
            try
            {
                HttpWebResponse response = await RequestToWeb.POSTAsync(new Uri(linkDangKy), null, data, false, false,
                    config_more: (req) =>
                    {
                        req.Referer = linkDangKy;
                        req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
                    }) as HttpWebResponse;

                var res = HttpUtility.HtmlDecode(RequestToWeb.ReadStream(response.GetResponseStream()));
                if (response.StatusCode == HttpStatusCode.OK)
                    return new ThongTinTaiKhoan() { TaiKhoan = taiKhoan, MatKhau = mat_khau };
                else
                    return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Tạo lỗi" };
            }
            catch
            {
                return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Lỗi chưa xác định" };
            }
        }
    }
}
