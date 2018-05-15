using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSendMessageOnWeb.Data;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Web;
using Fizzler.Systems.HtmlAgilityPack;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;

namespace AutoSendMessageOnWeb.Lib
{
    public class HenHo2 : IGuiTinNhan
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
            string data = string.Format("Email={0}&Password={1}&RememberMe=true&returnUrl=%2F", tk.TaiKhoan, tk.MatKhau);

            var response = RequestToWeb.POST(new Uri("https://henho2.com/Account/Login"), null, data, true);
            var httpRes = response as HttpWebResponse;

            if (httpRes.StatusCode == HttpStatusCode.Found)
            {
                string setCookie = httpRes.Headers[HttpResponseHeader.SetCookie];
                tk.Cookie = new CookieContainer();
                tk.Cookie.SetCookies(UriTrangWeb.HenHo2, setCookie);
                tk.TrangThai = "Đang nhập thành công";

                //foreach (Cookie co in tk.Cookie.GetCookies(UriTrangWeb.HenHo2))
                //{
                //    if (co.Name == ".ASPXAUTH")
                //    {
                //        tk.HanCookie = co.Expires;
                //        break;
                //    }
                //}
            }
            else
            {
                tk.TrangThai = "Sai tài khoản hoặc mật khẩu";
                tk.Cookie = null;
            }

            httpRes.Close();
            httpRes.Dispose();

            response.Close();
            response.Dispose();
        }

        #region bỏ rồi
        public ThongTinTaiKhoan DangNhap(string taikhoan, string matkhau)
        {
            ThongTinTaiKhoan res = new ThongTinTaiKhoan();

            HttpWebRequest request = WebRequest.CreateHttp("https://henho2.com/Account/Login");
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = false;
            request.Method = "POST";

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(string.Format("Email={0}&Password={1}&RememberMe=true&returnUrl=%2F", taikhoan, matkhau));
            sw.Close();

            var response = request.GetResponse();
            var httpRes = response as HttpWebResponse;

            res.TaiKhoan = taikhoan;
            res.MatKhau = matkhau;

            if (httpRes.StatusCode == HttpStatusCode.Found)
            {
                string setCookie = httpRes.Headers[HttpResponseHeader.SetCookie];
                res.Cookie = new CookieContainer();
                res.Cookie.SetCookies(UriTrangWeb.HenHo2, setCookie);
                res.TrangThai = "Đang nhập thành công";
            }
            else
            {
                res.TrangThai = "Sai tài khoản hoặc mật khẩu";
                res.Cookie = null;
            }

            return res;
        }
        #endregion

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> callback=null)
        {
            if (nguoigui.Cookie == null)
                throw new Exception("Thiếu cookie");

            string data = string.Format("IdTo={0}&NameTo={1}&Title={2}&MessageContent={3}", nguoinhan.Id, nguoinhan.TenHienThi, tieude, noidung);
            
            var response = RequestToWeb.POST(new Uri("https://henho2.com/Message/Create"), nguoigui.Cookie, data, false, true);

            nguoinhan.TrangThai = nguoigui.TaiKhoan;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string stringResponse = sr.ReadToEnd();
                if (!stringResponse.Contains("Gửi tin nhắn th&#224;nh c&#244;ng"))
                {
                    if (stringResponse.Contains("gửi qu&#225; số thư cho ph&#233;p"))
                        nguoinhan.TrangThai = "Gửi lỗi\n(quá số thư cho phép)";
                    else if (stringResponse.Contains("Vui l&#242;ng nhập từ"))
                        nguoinhan.TrangThai = "Gửi lỗi\n(quá ngắn)";
                    else if (stringResponse.Contains("Chưa kích hoạt"))
                        nguoinhan.TrangThai = "Chưa kích hoạt";
                    else if (stringResponse.Contains("Bạn đ&#227; bị ban"))
                    {
                        nguoinhan.TrangThai = "Gửi lỗi\n(tài khoản bị khóa)";
                        if (callback != null)
                            callback(CONST_HENHO2.TAI_KHOAN_BI_KHOA);
                    }
                    else
                        nguoinhan.TrangThai = "Gửi lỗi\n(nhập lại tài khoản)";
                }
            }
        }

        public DanhSachDuLieuTimKiem TaoDuLieuTimKiem()
        {
            DanhSachDuLieuTimKiem res = new DanhSachDuLieuTimKiem();

            res.NoiO.Add(-1, "Tất cả");

            res.NoiO.Add(58, "TP Hồ Chí Minh");
            res.NoiO.Add(24, "Hà Nội");
            res.NoiO.Add(15, "Đà Nẵng");

            List<string> tinhThanh = new List<string>()
            {"", "An Giang", "Bà Rịa - Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định","Bình Dương","Bình Phước",
            "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "", "Đăk Lăk", "Đăk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp",
            "Gia Lai", "Hà Giang", "Hà Nam", "", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hậu Giang", "Hoà Bình", "Hưng Yên",
            "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An",
            "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng",
            "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên-Huế", "Tiền Giang", "", "Trà Vinh", "Tuyên Quang",
            "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"};

            for (int i = 1; i <= 14; i++)
                res.NoiO.Add(i, tinhThanh[i]);

            for (int i = 16; i <= 23; i++)
                res.NoiO.Add(i, tinhThanh[i]);

            for (int i = 25; i <= 57; i++)
                res.NoiO.Add(i, tinhThanh[i]);

            for (int i = 59; i <= 63; i++)
                res.NoiO.Add(i, tinhThanh[i]);

            List<string> tinhTrang = new List<string>()
            {"Tất cả", "Độc thân", "Đang có người yêu", "Đã có gia đình", "Ly dị", "Ở góa"};

            for (int i = -1; i <= 4; i++)
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = i, TenTinhTrang = tinhTrang[i + 1] });

            List<string> gioiTinh = new List<string>()
            { "Tất cả", "Nam", "Nữ", "Gay", "Les"};
            for (int i = -1; i < 4; i++)
                res.GioiTinh.Add(i, gioiTinh[i + 1]);

            return res;
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            foreach (var tinhtrang in param.HonNhan)
            {
                int pageindex = 1;
                while (true)
                {
                    #region Tạo reqeuest
                    var uri = new UriBuilder("https://henho2.com/Home/Index");
                    var query = HttpUtility.ParseQueryString(uri.Query);
                    query["gtinh"] = param.GioiTinh.ToString();
                    query["countryid"] = "237";
                    query["province"] = param.NoiO.ToString();
                    query["maritial"] = tinhtrang.Id.ToString();
                    query["objective"] = "-1";
                    query["ageFrom"] = param.TuTuoi.ToString();
                    query["ageTo"] = param.DenTuoi.ToString();
                    query["name"] = "";
                    query["pageindex"] = pageindex.ToString();
                    uri.Query = query.ToString();

                    var response = RequestToWeb.GET(uri.Uri, false);
                    #endregion

                    #region Lấy dữ liệu
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        string content = sr.ReadToEnd();
                        //content = File.ReadAllText("DataHtmlTest.txt");
                        content = HttpUtility.HtmlDecode(content);

                        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                        document.LoadHtml(content);
                        

                        var bangKetQua = document.DocumentNode.QuerySelectorAll("table > tbody > tr > td").ToList();
                        for (int i = 0; i < bangKetQua.Count; i++)
                        {
                            ThongTinTaiKhoan taiKhoan = new ThongTinTaiKhoan();
                            var tenHienThi = bangKetQua[i].QuerySelector("a");
                            if (tenHienThi != null)
                            {
                                string duongDan = tenHienThi.GetAttributeValue("href", "");
                                if (!string.IsNullOrEmpty(duongDan))
                                {
                                    try
                                    {
                                        int id = Convert.ToInt32(duongDan.Split('/')[3]);
                                        string[] ten_gioitinh_tuoi = bangKetQua[i].InnerText.Split('\n');
                                        string ten = ten_gioitinh_tuoi[4];
                                        string tuoi = ten_gioitinh_tuoi[8].Replace("Tuổi : ", "").Trim();
                                        string gioiTinh = ten_gioitinh_tuoi[6].Trim();

                                        taiKhoan.Url = string.Format("https://henho2.com{0}", duongDan);
                                        taiKhoan.Id = duongDan.Split('/')[3];
                                        taiKhoan.TenHienThi = ten.Trim();
                                        taiKhoan.ChoPhepGuiNhan = true;
                                        taiKhoan.Tuoi = tuoi.ConvertToInt32();
                                        taiKhoan.GioiTinh = gioiTinh;
                                    }
                                    catch { taiKhoan = null; }
                                    if (taiKhoan != null && i < bangKetQua.Count)//TÌm thông tin hôn nhân
                                    {
                                        i++;
                                        var honNhan_noiO = bangKetQua[i].InnerText.Split('\n');
                                        if (honNhan_noiO.Count() >= 2)
                                            taiKhoan.TinhTrangHonNhan = honNhan_noiO[2].Trim();
                                        if (honNhan_noiO.Count() >= 8)
                                            taiKhoan.NoiO = honNhan_noiO[8].Trim();
                                    }

                                    if (taiKhoan != null)
                                        yield return taiKhoan;
                                }
                            }
                            
                        }
                        if (bangKetQua.Count <= 1)
                            break;
                    }
                    #endregion

                    pageindex++;
                }
            }
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            frmTimKiemBrowser tk = new frmTimKiemBrowser(TrangWeb.HenHo2);
            if (binding != null)
                tk.DanhSachTaiKhoanDuocChon = binding;

            if (tk.ShowDialog() == DialogResult.OK)
                return tk.DanhSachTaiKhoanDuocChon;
            else
                return binding;
        }

    }

    public class CONST_HENHO2
    {
        public const string TAI_KHOAN_BI_KHOA = "Henho2.com Tài khoản bị khóa";
    }
}
