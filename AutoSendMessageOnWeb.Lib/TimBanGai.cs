using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSendMessageOnWeb.Data;
using System.Net;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using Fizzler.Systems.HtmlAgilityPack;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace AutoSendMessageOnWeb.Lib
{
    public class TimBanGai : IThaoTacWeb
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
            string dangNhap_data = string.Format("username={0}&password={1}&nonxpcookie=1&login=Login&islogin=1",
                                                 tk.TaiKhoan, tk.MatKhau);
            var dangNhap_Response = RequestToWeb.POST(new Uri("http://www.timbangai.com/timbangai/account/login/"), tk.Cookie, dangNhap_data, false);
            string dangNhap_string = RequestToWeb.ReadStream(dangNhap_Response);
            var dangNhap_Header = RequestToWeb.ReadHeader(dangNhap_Response.Headers);

            if (dangNhap_string == "")
                tk.TrangThai = "Đang nhập thành công";
            else
                tk.TrangThai = "Sai tài khoản hoặc mật khẩu";
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung)
        {
            //Lấy thông tin tài khoản nhận thư
            if (string.IsNullOrEmpty(nguoinhan.Id))
            {
                var thongTinNguoiNhanThu_Response = RequestToWeb.GET(new Uri(nguoinhan.Url), false);
                string thongTinNguoiNhanThu_string = RequestToWeb.ReadStream(thongTinNguoiNhanThu_Response);
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(thongTinNguoiNhanThu_string);
                var thongTinNguoiNhanThu_message = document.DocumentNode.Descendants("li").Where(div => div.HasClass("message")).FirstOrDefault();
                string thongTinNguoiNhanThu_Url = thongTinNguoiNhanThu_message.QuerySelector("a").GetAttributeValue("href", "");
                nguoinhan.Id = thongTinNguoiNhanThu_Url.Split('/')[7];
            }
            string guiThu_data = string.Format("subject={0}&body={1}&submit=Gởi&ismessage=1", tieude, noidung);
            var guiThu_Response = RequestToWeb.POST(new Uri(string.Format("http://www.timbangai.com/timbangai/account/messages/compose/{0}", nguoinhan.Id)), nguoigui.Cookie, guiThu_data, false);
            string guiThu_string = RequestToWeb.ReadStream(guiThu_Response);
            if (guiThu_string == "")
                nguoinhan.TrangThai = nguoigui.TaiKhoan;
            else
                nguoinhan.TrangThai = "Gửi lỗi";
        }

        public DanhSachDuLieuTimKiem TaoDuLieuTimKiem()
        {
            DanhSachDuLieuTimKiem res = new DanhSachDuLieuTimKiem();

            #region Nơi ở
            List<string> tinhThanh = new List<string>()
            {"Tất cả", "Hanoi", "Ho Chi Minh", "Da Nang", "Hai Phong", "Nam Dinh", "Lai Chau", "Ha Giang", "Lang Son", "Bac Kan", "Quang Ninh", "Son La", "Thai Nguyen", "Bac Ninh", "Phu Tho", "Hai Duong", "Hoa Binh", "Ninh Binh", "Nghe An", "Quang Binh", "Binh Đinh", "Quang Nam", "Gia Lai", "Dac Lac", "Lam Đong", "Khanh Hoa", "Ben Tre", "Hau Giang", "Binh Thuan", "Tien Giang", "Vinh Long", "An Giang", "Can Tho", "Dak Nong", "Kien Giang", "Ca Mau", "Dien Bien", "Lao Cai", "Bac Giang", "Cao Bang", "Tuyen Quang", "Hung Yen", "Yen Bai", "Vinh Phuc", "Thai Binh", "Ha Nam", "Thanh Hoa", "Ha Tinh", "Quang Tri", "Thua Thien - Hue", "Quang Ngai", "Kon Tum", "Phu Yen", "Bac Lieu", "Long An", "Binh Phuoc", "Ninh Thuan", "Tay Ninh", "Tra Vinh", "Binh Duong", "Ba Ria - Vung Tau", "Soc Trang", "Dong Thap", "Dong Nai"};
            List<string> idTinhThanh = new List<string>()
            {"", "Hanoi", "Ho Chi Minh", "Da Nang", "Hai Phong", "Nam Dinh", "Lai Chau", "Ha Giang", "Lang Son", "Bac Kan", "Quang Ninh", "Son La", "Thai Nguyen", "Bac Ninh", "Phu Tho", "Hai Duong", "Hoa Binh", "Ninh Binh", "Nghe An", "Quang Binh", "Binh Đinh", "Quang Nam", "Gia Lai", "Dac Lac", "Lam Đong", "Khanh Hoa", "Ben Tre", "Hau Giang", "Binh Thuan", "Tien Giang", "Vinh Long", "An Giang", "Can Tho", "Dak Nong", "Kien Giang", "Ca Mau", "Dien Bien", "Lao Cai", "Bac Giang", "Cao Bang", "Tuyen Quang", "Hung Yen", "Yen Bai", "Vinh Phuc", "Thai Binh", "Ha Nam", "Thanh Hoa", "Ha Tinh", "Quang Tri", "Thua Thien - Hue", "Quang Ngai", "Kon Tum", "Phu Yen", "Bac Lieu", "Long An", "Binh Phuoc", "Ninh Thuan", "Tay Ninh", "Tra Vinh", "Binh Duong", "Ba Ria - Vung Tau", "Soc Trang", "Dong Thap", "Dong Nai"};

            for (int i = 0; i < tinhThanh.Count; i++)
                res.NoiO.Add(idTinhThanh[i], tinhThanh[i]);
            #endregion

            #region Tình trạng hôn nhân
            List<string> tinhTrang = new List<string>()
            {"Tất cả", "Độc thân", "Ở với trẻ", "Ở với bố mẹ", "Ở với thú cưng", "Ở với bạn", "Bạn thường đến chơi", "Thường có tiệc đêm"};
            List<int> idTinhTrang = new List<int>()
            { -1, 335, 336, 337, 338, 339, 340, 341 };

            for (int i = 0; i < tinhTrang.Count; i++)
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = idTinhTrang[i], TenTinhTrang = tinhTrang[i] });
            #endregion

            #region Giới tính
            List<string> gioiTinh = new List<string>()
            {"Nam", "Nữ"};//CÓ thể thêm tất cả vào
            List<int> idGioiTinh = new List<int>()
            {1, 2};

            for (int i = 0; i < gioiTinh.Count; i++)
                res.GioiTinh.Add(idGioiTinh[i], gioiTinh[i]);
            #endregion

            return res;
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            #region Tạo request
            NameValueCollection formData = new NameValueCollection();
            formData.Add("type_id", "members");
            formData.Add("gender2", "1");
            formData.Add("gender1", param.GioiTinh.ToString());
            formData.Add("age_from", param.TuTuoi.ToString());
            formData.Add("age_to", param.DenTuoi.ToString());
            formData.Add("country", "212");
            formData.Add("city", param.NoiO.ToString());
            if (param.HonNhan.FirstOrDefault().Id.ToString() != "-1")
                formData.Add("livingsituation[]", string.Format("{0}", string.Join("&livingsituation[]=", param.HonNhan.Select(p => p.Id.ToString()))));
            formData.Add("username", "");
            formData.Add("online_only", "0");
            formData.Add("pictures_only", "0");
            formData.Add("display_type", "1");
            formData.Add("search_save", "");
            formData.Add("submit", "Gởi");
            formData.Add("issearch", "1");

            string timKiem_data = formData.ConvertToUrlEncode();
            var timKiem_Response = RequestToWeb.POST(new Uri("http://www.timbangai.com/timbangai/search/advanced/"), null, timKiem_data, false, false);
            var headers = RequestToWeb.ReadHeader(timKiem_Response);
            string timKiem_string = RequestToWeb.ReadStream(timKiem_Response);
            string timKiem_location = timKiem_Response.Headers[HttpResponseHeader.Location];
            #endregion

            if ((timKiem_Response as HttpWebResponse).StatusCode == HttpStatusCode.Found)
            {
                int page = 1;
                while (true)
                {
                    string timKiem_link = string.Format("{0}{1}", timKiem_location, page);
                    timKiem_Response = RequestToWeb.GET(new Uri(timKiem_link), false);
                    timKiem_string = RequestToWeb.ReadStream(timKiem_Response);

                    //string timKiem_string = File.ReadAllText("DataHtmlTest.txt");
                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(HttpUtility.HtmlDecode(timKiem_string));

                    var bangKetQua = document.DocumentNode.QuerySelectorAll("div#content").FirstOrDefault();
                    var danhSachKetQua = bangKetQua.Descendants("div").Where(div => div.HasClass("image"));
                    if (danhSachKetQua.Count() == 0)
                        break;
                    foreach (var kq in danhSachKetQua)
                    {
                        ThongTinTaiKhoan tk = new ThongTinTaiKhoan();

                        var ten_tuoi = kq.InnerText.Trim().Split(',');
                        tk.TenHienThi = ten_tuoi[0];
                        tk.Tuoi = ten_tuoi[ten_tuoi.Count() - 1].ConvertToInt32();
                        tk.Url = kq.QuerySelector("a").GetAttributeValue("href", "");
                        tk.GioiTinh = param.OtherParam[0].ToString();
                        tk.TinhTrangHonNhan = param.OtherParam[1].ToString();
                        #region Lấy ID
                        Task.Run(
                        () =>
                        {
                            var thongTinNguoiNhanThu_Response = RequestToWeb.GET(new Uri(tk.Url), false);

                            string thongTinNguoiNhanThu_string = RequestToWeb.ReadStream(thongTinNguoiNhanThu_Response);
                            HtmlAgilityPack.HtmlDocument thongTinNguoiNhanThu_document = new HtmlAgilityPack.HtmlDocument();
                            thongTinNguoiNhanThu_document.LoadHtml(thongTinNguoiNhanThu_string);

                            var thongTinNguoiNhanThu_message = thongTinNguoiNhanThu_document.DocumentNode.Descendants("li").Where(div => div.HasClass("message")).FirstOrDefault();
                            string thongTinNguoiNhanThu_Url = thongTinNguoiNhanThu_message.QuerySelector("a").GetAttributeValue("href", "");
                            tk.Id = thongTinNguoiNhanThu_Url.Split('/')[7];
                        });
                        #endregion

                        yield return tk;
                    }

                    page++;
                }
            }
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            throw new NotImplementedException();
        }

        public static void Test()
        {
            ThongTinTaiKhoan tk = new ThongTinTaiKhoan();
            tk.TaiKhoan = "ngochoaitn";
            tk.MatKhau = "noongngocj";

            tk.Cookie = new CookieContainer();
            string dangNhap_data = string.Format("username={0}&password={1}&nonxpcookie=1&login=Login&islogin=1",
                                                 tk.TaiKhoan, tk.MatKhau);
            var dangNhap_Response = RequestToWeb.POST(new Uri("http://www.timbangai.com/timbangai/account/login/"), tk.Cookie, dangNhap_data, false);
            string dangNhap_string = RequestToWeb.ReadStream(dangNhap_Response);
            var dangNhap_Header = RequestToWeb.ReadHeader(dangNhap_Response.Headers);

            if(dangNhap_string == "")
            {
                tk.TrangThai = "Đang nhập thành công";
            }
            else
            {
                tk.TrangThai = "Sai tài khoản hoặc mật khẩu";
            }


            //Gửi thư
            ThongTinTaiKhoan nguoigui = tk;
            ThongTinTaiKhoan nguoinhan = new ThongTinTaiKhoan() {TenHienThi ="asbirine", Url="http://www.timbangai.com/timbangai/asbirine"};

            if (string.IsNullOrEmpty(tk.Id))
            {
                //Lấy thông tin tài khoản nhận thư
                var thongTinNguoiNhanThu_Response = RequestToWeb.GET(new Uri(nguoinhan.Url), false);
                string thongTinNguoiNhanThu_string = RequestToWeb.ReadStream(thongTinNguoiNhanThu_Response);
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(thongTinNguoiNhanThu_string);
                var thongTinNguoiNhanThu_message = document.DocumentNode.Descendants("li").Where(div => div.HasClass("message")).FirstOrDefault();
                string thongTinNguoiNhanThu_Url = thongTinNguoiNhanThu_message.QuerySelector("a").GetAttributeValue("href", "");
                nguoinhan.Id = thongTinNguoiNhanThu_Url.Split('/')[7];
            }
            string noidung = "Nội dung tự động";
            string chude="chủ đề tự động";
            string guiThu_data = string.Format("subject={0}&body={1}&submit=Gởi&ismessage=1", chude, noidung);
            var guiThu_Response = RequestToWeb.POST(new Uri(string.Format("http://www.timbangai.com/timbangai/account/messages/compose/{0}", nguoinhan.Id)), nguoigui.Cookie, guiThu_data, false);
            string guiThu_string = RequestToWeb.ReadStream(guiThu_Response);
            if (guiThu_string == "")
                nguoinhan.TrangThai = tk.TaiKhoan;
            else
                nguoinhan.TrangThai = "Gửi lỗi";
        }
    }
}
