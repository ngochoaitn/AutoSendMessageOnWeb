using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSendMessageOnWeb.Data;
using System.Net;
using Fizzler.Systems.HtmlAgilityPack;
using System.Web;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using System.Diagnostics;

namespace AutoSendMessageOnWeb.Lib
{
    public class HenHoKetBan : IGuiTinNhan
    {
        public CookieContainer Cookie
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool TimKiemYeuCauCookie
        {
            get
            {
                return false;
            }
        }

        public void DangNhap(ref ThongTinTaiKhoan tk)
        {
            tk.Cookie = new CookieContainer();
            string dangNhapData = string.Format("username={0}&password={1}&btn_submit=ĐĂNG NHẬP", tk.TaiKhoan, tk.MatKhau);
            var dangNhapResponse = RequestToWeb.POST(new Uri("https://henhoketban.vn/login.php"), tk.Cookie, dangNhapData, false);
            string dangNhapStringResponse = RequestToWeb.ReadStream(dangNhapResponse);
            var dangNhapHeader = RequestToWeb.ReadHeader(dangNhapResponse.Headers);
            if (dangNhapStringResponse.Contains("ĐĂNG NHẬP THÀNH CÔNG"))
            {
                tk.TrangThai = "Đăng nhập thành công";
                tk.ChoPhepGuiNhan = true;
                #region Lấy Id, tên hiển thị dùng để gửi thư
                try
                {
                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

                    #region Lấy ID
                    var layThongTin_Id_Response = RequestToWeb.GET(new Uri("https://henhoketban.vn/index.php"), false, false, tk.Cookie);
                    string layThongTinStringResponse =RequestToWeb.ReadStream(layThongTin_Id_Response);

                    document.LoadHtml(layThongTinStringResponse);

                    string duongDan = document.DocumentNode.QuerySelectorAll("div#top > div > div > font > a").FirstOrDefault().GetAttributeValue("href", "");
                    tk.Id = duongDan.Split('=')[1];
                    tk.Url = duongDan;
                    #endregion

                    #region Lấy tên hiển thị
                    var tenHienThi_Response = RequestToWeb.GET(new Uri(duongDan), false);
                    string tenHienThiStringResponse = RequestToWeb.ReadStream(tenHienThi_Response);
                    document.LoadHtml(tenHienThiStringResponse);
                    tk.TenHienThi = document.DocumentNode.QuerySelector("h1 > font").InnerText.Split('|')[1].Trim();
                    #endregion
                }
                catch
                { }
                #endregion
            }
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> callback=null)
        {
            if (nguoigui.Cookie == null)
                throw new Exception("Chưa đăng nhập");
            //Gửi tin nhắn
            string guiData = string.Format("idgui={0}&idnhan={1}&tennguoigui={2}&tennguoinhan=AutoSend_{3}&tieude={4}&noidung={5}&btn_submit=GỬI TIN NHẮN",
                                                nguoigui.Id, nguoinhan.Id, nguoigui.TenHienThi, nguoinhan.TenHienThi, tieude, noidung);

            var guiTinResponse = RequestToWeb.POST(new Uri("https://henhoketban.vn/guithu.php"), nguoigui.Cookie, guiData, false, true);
            string guiStringResponse = RequestToWeb.ReadStream(guiTinResponse);

            if (guiStringResponse.Contains("message.php?guithu=thanhcong"))
            {
                nguoinhan.TrangThai = nguoigui.TaiKhoan;
            }
            else
            {
                nguoinhan.TrangThai = "Gửi lỗi";
            }
        }

        public DanhSachDuLieuTimKiem TaoDuLieuTimKiem()
        {
            DanhSachDuLieuTimKiem res = new DanhSachDuLieuTimKiem();

            #region Nơi ở
            List<string> tinhThanh = new List<string>()
            {"Tất cả", "TP.HCM", "Hà Nội", "Đà Nẵng", "An Giang", "BR Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đăk Lăk", "Đăk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hậu Giang", "Hoà Bình", "Hưng Yên", "Khánh Hoà", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hoá", "T.T. Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"};
            List<string> idTinhThanh = new List<string>()
            { "Tất cả", "TP.HCM", "Hà Nội", "Đà Nẵng", "An Giang", "BR Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đăk Lăk", "Đăk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hậu Giang", "Hoà Bình", "Hưng Yên", "Khánh Hoà", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hoá", "Thừa Thiên Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"};

            for (int i = 0; i < tinhThanh.Count; i++)
                res.NoiO.Add(idTinhThanh[i], tinhThanh[i]);
            #endregion

            #region Tình trạng hôn nhân
            List<string> tinhTrang = new List<string>()
            {"Tất cả", "Độc Thân", "Có Người Yêu", "Có Gia Đình", "Đã Ly Hôn", "Đang Ở Goá"};
            List<string> idTinhTrang = new List<string>()
            {"Tất cả", "Độc Thân", "Đang Có Người Yêu", "Đã Có Gia Đình", "Đã Ly Hôn","Đang Ở Goá"};

            for (int i = 0; i < tinhTrang.Count; i++)
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = idTinhTrang[i], TenTinhTrang = tinhTrang[i] });
            #endregion

            #region Giới tính
            List<string> gioiTinh = new List<string>()
            {"Tất cả", "Nam", "Nữ", "Les", "Gay"};

            for (int i = 0; i < gioiTinh.Count; i++)
                res.GioiTinh.Add(gioiTinh[i], gioiTinh[i]);
            #endregion

            return res;
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            foreach (var hn in param.HonNhan)
            {
                int page = 1;
                while (true)
                {
                    #region Tạo reqeuest
                    string linkTimKiem = string.Format("?page={0}&gioitinh={1}&tuoi1={2}&tuoi2={3}&dentu={4}&honnhan={5}&muctieu=Tất cả&nuoc=Vietnam&btn_submit=",
                                                page, param.GioiTinh, param.TuTuoi, param.DenTuoi, param.NoiO, hn.Id);
                    linkTimKiem = "https://henhoketban.vn/timnguoiyeuonline.php" + linkTimKiem;
                    var response = RequestToWeb.GET(new Uri(linkTimKiem), false);
                    #endregion

                    #region Lấy dữ liệu
                    string sKQTimKiem = RequestToWeb.ReadStream(response);
                    sKQTimKiem = HttpUtility.HtmlDecode(sKQTimKiem);

                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(sKQTimKiem);

                    var results_search2 = document.DocumentNode.QuerySelectorAll("div#maincontent > table");
                    if (results_search2.Count() <= 7)
                        break;
                    foreach (var v in results_search2)
                    {
                        ThongTinTaiKhoan tk = new ThongTinTaiKhoan();

                        var hangThongTin = v.QuerySelectorAll("tr > td");
                        if (hangThongTin.Count() >= 3)
                        {
                            var ten_gioiTinh_tuoi_honNhan = hangThongTin.ElementAt(1).QuerySelectorAll("h3").ElementAt(0);
                            tk.TenHienThi = ten_gioiTinh_tuoi_honNhan.QuerySelectorAll("font").ElementAt(0).InnerText;
                            tk.GioiTinh = ten_gioiTinh_tuoi_honNhan.QuerySelectorAll("font").ElementAt(1).InnerText;
                            tk.TinhTrangHonNhan = ten_gioiTinh_tuoi_honNhan.QuerySelectorAll("font").ElementAt(2).InnerText;
                            string tuoi = string.Join("", ten_gioiTinh_tuoi_honNhan.InnerText.Where(p => p >= '0' && p <= '9'));
                            int iTuoi = 0;
                            int.TryParse(tuoi, out iTuoi);
                            tk.Tuoi = iTuoi;

                            var duongDan = hangThongTin.ElementAt(0).QuerySelector("a");
                            tk.Url = "https://henhoketban.vn/" + duongDan.GetAttributeValue("href", "");

                            tk.Id = tk.Url.Split('=')[1];
                            tk.NoiO = hangThongTin.ElementAt(0).QuerySelectorAll("center > font").ElementAt(0).InnerText;

                            if (param.ThoiGianDangNhap.HasValue)
                            {
                                try
                                {
                                    var thongTinThoiGianDangNhap = v.QuerySelectorAll("tr > td > p > font").ElementAt(1).InnerHtml;
                                    var thoiGianDangNhap = LayThoiGian(thongTinThoiGianDangNhap.Substring(0, thongTinThoiGianDangNhap.IndexOf("<")).TrimAll());
                                    if (!thoiGianDangNhap.HasValue || thoiGianDangNhap.Value > param.ThoiGianDangNhap)
                                        tk = null;
                                    Debug.WriteLine($"{thongTinThoiGianDangNhap.Substring(0, thongTinThoiGianDangNhap.IndexOf("<")).TrimAll()} = {thoiGianDangNhap}, {((!thoiGianDangNhap.HasValue || thoiGianDangNhap.Value > param.ThoiGianDangNhap) ? "loại" : "nhận")}");
                                }
                                catch
                                {

                                }
                            }
                            if (tk != null)
                                yield return tk;
                        }
                        else
                        {

                        }
                        if (param.DungTimKiem)
                            break;
                    }
                    #endregion
                    if (param.DungTimKiem)
                        break;
                    page++;
                }
            }
        }

        /// <summary>
        /// Chuyển x giây, y phút, z giờ, xx ngày thành phút
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int? LayThoiGian(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            string temp = s.ToLower();
            if (temp.Contains("giây"))
                return 0;
            if (temp.Contains("phút"))
                return Convert.ToInt32(temp.Replace("phút", "").TrimAll());
            if(temp.Contains("giờ"))
                return Convert.ToInt32(temp.Replace("giờ", "").TrimAll()) * 60;
            if(temp.Contains("ngày"))
                return Convert.ToInt32(temp.Replace("ngày", "").TrimAll()) * 1440;
            if (temp.Contains("tháng"))
                return Convert.ToInt32(temp.Replace("tháng", "").TrimAll()) * 43200;
            if (temp.Contains("năm"))
                return Convert.ToInt32(temp.Replace("năm", "").TrimAll()) * 15768000;
            return int.MaxValue;
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            throw new NotImplementedException();
        }

        public static void Test()
        {
            #region Đang nhập, gửi tin
            ThongTinTaiKhoan tk = new ThongTinTaiKhoan();
            tk.Cookie = new CookieContainer();
            tk.TaiKhoan = "ngochoaitn";
            tk.MatKhau = "noongngocj";

            string dangNhapData = string.Format("username={0}&password={1}&btn_submit=ĐĂNG NHẬP", tk.TaiKhoan, tk.MatKhau);
            var dangNhapResponse = RequestToWeb.POST(new Uri("https://henhoketban.vn/login.php"), tk.Cookie, dangNhapData, false);
            string dangNhapStringResponse = RequestToWeb.ReadStream(dangNhapResponse);
            var dangNhapHeader = RequestToWeb.ReadHeader(dangNhapResponse.Headers);
            if (dangNhapStringResponse.Contains("ĐĂNG NHẬP THÀNH CÔNG"))
            {

                //Đi lấy thông tin tài khoản
                var layThongTinResponse = RequestToWeb.GET(new Uri("https://henhoketban.vn/index.php"), false, false, tk.Cookie);
                string layThongTinStringResponse =RequestToWeb.ReadStream(layThongTinResponse);

                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(layThongTinStringResponse);

                string duongDan = document.DocumentNode.QuerySelectorAll("div#top > div > div > font > a").FirstOrDefault().GetAttributeValue("href", "");
                tk.Id = duongDan.Split('=')[1];

                //Lấy tên hiển thị
                var tenHienThiResponse = RequestToWeb.GET(new Uri(duongDan), false);
                string tenHienThiStringResponse = RequestToWeb.ReadStream(tenHienThiResponse);
                document.LoadHtml(tenHienThiStringResponse);
                tk.TenHienThi = document.DocumentNode.QuerySelector("h1 > font").InnerText.Split('|')[1].Trim();


                //Gửi tin nhắn
                ThongTinTaiKhoan tknhan = new ThongTinTaiKhoan() {Id="10454", TenHienThi="Lan" };
                string tieuDe = "Tiêu đề xxxxxxxx";
                string noidung = "Nội dung xxxxxxxxx";

                string guiData = string.Format("idgui={0}&idnhan={1}&tennguoigui={2}&tennguoinhan=AutoSend->{3}&tieude={4}&noidung={5}&btn_submit=GỬI TIN NHẮN",
                                                tk.Id, tknhan.Id, tk.TenHienThi, tknhan.TenHienThi, tieuDe, noidung);
                var guiTinResponse = RequestToWeb.POST(new Uri("https://henhoketban.vn/guithu.php"), tk.Cookie, guiData, false);
                string guiStringResponse = RequestToWeb.ReadStream(guiTinResponse);
                if(guiStringResponse.Contains("GỬI TIN NHẮN THÀNH CÔNG."))
                {
                    tknhan.TrangThai = tk.TaiKhoan;
                }
                else
                {
                    tknhan.TrangThai = "Gửi lỗi";
                }
            }
            #endregion
        }
    }
}
