using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using Fizzler.Systems.HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace AutoSendMessageOnWeb.Lib
{
    public class LikeYou : IThaoTacWeb
    {
        public CookieContainer Cookie { set; get; }

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
            #region Lấy cookie ban đầu
            var cookieBanDauResponse = RequestToWeb.GET(new Uri("http://cdn.likeyou.vn/sites/all/themes/jam_likeyou/images/bgfacbookren.png"), true, false, tk.Cookie);
            //var cookieBanDauResponse = RequestToWeb.GET(new Uri("http://media.likeyou.vn/"), true, false, tk.Cookie);
            #endregion

            #region Đăng nhập
            string data = string.Format("name={0}&pass={1}&remember_me=1&form_id=user_login", tk.TaiKhoan, tk.MatKhau);
            var dangNhapResponse = RequestToWeb.POST(new Uri("http://likeyou.vn/vi/user?destination=user"), tk.Cookie, data, false, true);
            string res = RequestToWeb.ReadStream(dangNhapResponse);
            if (dangNhapResponse.ResponseUri != null
             && dangNhapResponse.ResponseUri.Query != null
             && dangNhapResponse.ResponseUri.Query.Contains("user="))
            {
                tk.Id = dangNhapResponse.ResponseUri.ToString().Split('=')[1];
                tk.TrangThai = "Đang nhập thành công";
            }
            else
            {
                tk.TrangThai = "Sai tài khoản hoặc mật khẩu";
            }
            #endregion
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung)
        {
            if (nguoigui.Cookie == null)
                throw new Exception("Thiếu cookie");
            
            string dataGui = string.Format("fuid={0}&tuid={1}&message={2}&from_to={0}-{1}", nguoigui.Id, nguoinhan.Id, noidung);
            var responseGuiTin = RequestToWeb.POST(new Uri("http://likeyou.vn/messages/send-message"), nguoigui.Cookie, dataGui, false);

            string phanHoi = Uri.UnescapeDataString(RequestToWeb.ReadStream(responseGuiTin));
            var header3 = RequestToWeb.ReadHeader(responseGuiTin.Headers);

            if (phanHoi == "\n\n 1")
            {
                nguoinhan.TrangThai = nguoigui.TaiKhoan;
                System.Threading.Tasks.Task.Run(() =>
                {
                    //Để tự gửi lại 1 tìn => mới lưu vào hộp thư đến
                    dataGui = string.Format("fuid={1}&tuid={0}&from_to={1}-{0}", nguoigui.Id, nguoinhan.Id);
                    var gg = RequestToWeb.POST(new Uri("http://likeyou.vn/messages/send-message"), nguoigui.Cookie, dataGui, true);
                });
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
            {"Tất cả", "Hanoi", "Ho Chi Minh", "Da Nang", "Hai Phong", "Nam Dinh", "Lai Chau", "Ha Giang", "Lang Son", "Bac Kan", "Quang Ninh", "Son La", "Thai Nguyen", "Bac Ninh", "Phu Tho", "Hai Duong", "Hoa Binh", "Ninh Binh", "Nghe An", "Quang Binh", "Binh Đinh", "Quang Nam", "Gia Lai", "Dac Lac", "Lam Đong", "Khanh Hoa", "Ben Tre", "Hau Giang", "Binh Thuan", "Tien Giang", "Vinh Long", "An Giang", "Can Tho", "Dak Nong", "Kien Giang", "Ca Mau", "Dien Bien", "Lao Cai", "Bac Giang", "Cao Bang", "Tuyen Quang", "Hung Yen", "Yen Bai", "Vinh Phuc", "Thai Binh", "Ha Nam", "Thanh Hoa", "Ha Tinh", "Quang Tri", "Thua Thien - Hue", "Quang Ngai", "Kon Tum", "Phu Yen", "Bac Lieu", "Long An", "Binh Phuoc", "Ninh Thuan", "Tay Ninh", "Tra Vinh", "Binh Duong", "Ba Ria - Vung Tau", "Soc Trang", "Dong Thap", "Dong Nai"};
            List<int> idTinhThanh = new List<int>()
            { -1, 2, 3, 4, 6, 7, 148, 149, 150, 151, 152, 153, 154, 155, 156, 157, 158, 159, 160, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 190, 191, 192, 193, 194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207};

            for (int i = 0; i < tinhThanh.Count; i++)
                res.NoiO.Add(idTinhThanh[i], tinhThanh[i]);
            #endregion

            #region Tình trạng hôn nhân
            List<string> tinhTrang = new List<string>()
            {"Không", "Không có gì nghiêm túc", "Có mối quan hệ", "Đã kết hôn"};
            List<int> idTinhTrang = new List<int>()
            { 1, 2, 3, 4 };

            for (int i = 0; i < tinhTrang.Count; i++)
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = idTinhTrang[i], TenTinhTrang = tinhTrang[i] });
            #endregion

            #region Giới tính
            List<string> gioiTinh = new List<string>()
            {"Tất cả", "Bạn nam", "Bạn nữ"};
            List<int> idGioiTinh = new List<int>()
            {-1, 1, 2};

            for (int i = 0; i < gioiTinh.Count; i++)
                res.GioiTinh.Add(idGioiTinh[i], gioiTinh[i]);
            #endregion

            return res;
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            int page = 1;

            while (true)
            {

                #region Tạo reqeuest
                var uri = new UriBuilder("http://likeyou.vn/vi/searchs");

                var query = HttpUtility.ParseQueryString(uri.Query);
                #region Giới tính
                switch(param.GioiTinh.ToString())
                {
                    case "1": query["men"] = "1"; break;
                    case "2": query["woman"] = "2"; break;
                    case "-1": query["men"] = "1"; query["woman"] = "1"; break;
                }
                #endregion
                query["agefrom"] = param.TuTuoi.ToString();
                query["ageto"] = param.DenTuoi.ToString();
                if (param.NoiO.ToString() != "-1")
                    query["district"] = param.NoiO.ToString();
                query["country"] = "1";//Việt Nam;
                query["type"] = "advanced";
                query["relationship"] = string.Join("-", param.HonNhan.Select(p => p.Id.ToString()));
                if (page >= 2)
                    query["page"] = page.ToString();

                uri.Query = query.ToString();
                var response = RequestToWeb.GET(uri.Uri, false);
                #endregion

                #region Lấy dữ liệu
                string sKQTimKiem = RequestToWeb.ReadStream(response);
                sKQTimKiem = HttpUtility.HtmlDecode(sKQTimKiem);

                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(sKQTimKiem);

                var results_search2 = document.DocumentNode.Descendants("div").Where(div => div.HasClass("item-search-content-left"));
                if (results_search2.Count() < 1)
                    break;
                foreach (var v in results_search2)
                {
                    var infousearchg = v.Descendants("div").Where(div => div.HasClass("infousearchg")).FirstOrDefault();
                    var item_provice = v.Descendants("div").Where(div => div.HasClass("item-provice")).FirstOrDefault();
                    string link = infousearchg.QuerySelector("a").GetAttributeValue("href", "");
                    string id = link.Split('=')[1];
                    string tuoi="", ten="";
                    var gioiTinh = infousearchg.Descendants("i").FirstOrDefault();
                    string sGioiTinh = "";
                    if (gioiTinh != null && gioiTinh.GetAttributeValue("class", "") != null)
                        sGioiTinh = gioiTinh.GetAttributeValue("class", "");
                    if (infousearchg != null)
                    {
                        var ten_tuoi = infousearchg.InnerText.Split(',');
                        ten = ten_tuoi[0].Trim();
                        tuoi = ten_tuoi[ten_tuoi.Count() - 1].Trim();
                    }
                    string noiO = item_provice.InnerText.Trim();

                    ThongTinTaiKhoan tk = new ThongTinTaiKhoan();
                    tk.Tuoi = tuoi.ConvertToInt32();
                    tk.TenHienThi = ten;
                    tk.NoiO = noiO;
                    tk.GioiTinh = sGioiTinh != "" ? (sGioiTinh == "men" ? "Nam" : "Nữ") : param.OtherParam[0].ToString();
                    tk.TinhTrangHonNhan = param.OtherParam[1].ToString();
                    tk.Url = link;
                    tk.Id = id;

                    yield return tk;
                }
                #endregion

                page++;
            }
                
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            throw new NotImplementedException();
        }

        public static void Test()
        {
            ThongTinTaiKhoan tk = new ThongTinTaiKhoan();
            tk.Cookie = new CookieContainer();
            var cookieBanDauResponse = RequestToWeb.GET(new Uri("http://media.likeyou.vn/"), true, false, tk.Cookie);

            tk.TaiKhoan = "nda.ytb@gmail.com";
            tk.MatKhau = "nda.ytb@gmail.com";

            string data = string.Format("name={0}&pass={1}&remember_me=1&form_id=user_login", tk.TaiKhoan, tk.MatKhau);
            var dangNhapResponse = RequestToWeb.POST(new Uri("http://likeyou.vn/vi/user?destination=user"), tk.Cookie, data, false, true);
            string res = RequestToWeb.ReadStream(dangNhapResponse);
            var loginHeader = RequestToWeb.ReadHeader(dangNhapResponse.Headers);
            if ((dangNhapResponse as HttpWebResponse).StatusCode == HttpStatusCode.Found)
            {
                if(dangNhapResponse.ResponseUri != null 
                    && dangNhapResponse.ResponseUri.Query != null
                    && dangNhapResponse.ResponseUri.Query.Contains("user="))
                tk.Id = dangNhapResponse.ResponseUri.ToString().Split('=')[1];
                tk.TrangThai = "Đang nhập thành công";
            }
            else
            {
                tk.TrangThai = "Đang nhập thất bại";
            }

            var guiTin = RequestToWeb.POST(new Uri("http://likeyou.vn/messages/send-message"), tk.Cookie, "fuid=636691&tuid=636421&message=Không có id người gửi", false);
            string s3 = Uri.UnescapeDataString(RequestToWeb.ReadStream(guiTin));
            var header3 = RequestToWeb.ReadHeader(guiTin.Headers);
        }
    }
}
