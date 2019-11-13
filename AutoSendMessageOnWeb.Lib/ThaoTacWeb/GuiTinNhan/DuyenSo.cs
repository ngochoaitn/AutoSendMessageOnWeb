using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace AutoSendMessageOnWeb.Lib
{
    public class DuyenSo : IGuiTinNhan
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
            HttpWebRequest request = WebRequest.CreateHttp("http://duyenso.com/ajax.php");
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = false;
            request.Method = "POST";

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(string.Format("cmd=login&user={0}&password={1}&remember=1", tk.TaiKhoan, tk.MatKhau));
            sw.Close();

            var response = request.GetResponse();
            var httpRes = response as HttpWebResponse;

            //string stringResponse = 
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                string stringResponse = sr.ReadToEnd();
                if (stringResponse == "profile_view.php")
                {
                    string setCookie = httpRes.Headers[HttpResponseHeader.SetCookie];
                    tk.Cookie = new CookieContainer();
                    tk.Cookie.SetCookies(UriTrangWeb.DuyenSo, setCookie);
                    tk.TrangThai = "Đang nhập thành công";
                    tk.ChoPhepGuiNhan = true;
                }
                else
                {
                    if (stringResponse.Contains("Không thể đăng nhập lúc này. Xin thử lại sau "))
                        tk.TrangThai = "Bị khóa (Thử lại sau)";
                    else
                        tk.TrangThai = "Sai tài khoản hoặc mật khẩu";
                    tk.Cookie = null;
                }
            }
            sw.Dispose();
            request.Abort();

            httpRes.Close();
            httpRes.Dispose();

            response.Close();
            response.Dispose();
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> callback=null)
        {
            if (nguoigui.Cookie == null)
                throw new Exception("Thiếu cookie");

            string data = string.Format("cmd=send_message&user_to={0}&msg={1}&to_delete=0", nguoinhan.Id, noidung);

            var response = RequestToWeb.POST(new Uri("http://duyenso.com/ajax.php"), nguoigui.Cookie, data, false);
            if(response == null)
            {
                nguoinhan.TrangThai = "Gửi lỗi (Time out)";
                return;
            }

            nguoinhan.TrangThai = nguoigui.TaiKhoan;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string stringResponse = sr.ReadToEnd();
                if (!stringResponse.Contains("ERROR") && !stringResponse.Contains("Error"))
                {
                    if (stringResponse.Contains("VIP"))
                        nguoinhan.TrangThai = "Thất bại (Cần VIP)";
                }
                else
                {
                    nguoinhan.TrangThai = "Gửi lỗi (Server)";
                }

                var dataResponse = stringResponse.Split('"');
                string senderId = dataResponse[6].Trim();

                string dataUpdate = string.Format("cmd=pp_messages&user_id={0}&is_mode_fb=false", nguoinhan.Id);

                var resUpdate = RequestToWeb.POST(new Uri("http://duyenso.com/ajax.php"), nguoigui.Cookie, dataUpdate, true);
            }
        }

        public DanhSachDuLieuTimKiem TaoDuLieuTimKiem()
        {
            DanhSachDuLieuTimKiem res = new DanhSachDuLieuTimKiem();

            res.NoiO.Add(0, "Tất cả");
            List<string> tinhThanh = new List<string>()
            {"An Giang", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bà Rịa - Vũng Tàu", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đắk Lắk", "Đắk Nông", "Đà Nẵng", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hải Dương", "Hải Phòng", "Hà Nam", "Hà Nội", "Hà Tĩnh", "Hậu Giang", "Hòa Bình", "Hồ Chí Minh", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"};
            List<int> idTinhThanh = new List<int>()
            { 20089, 20024, 20006, 20095, 20027, 20077, 20083, 20052, 20074, 20070, 20060, 20096, 20092, 20004, 20066, 20067, 20048, 20011, 20075, 20087, 20064, 20002, 20030, 20031, 20035, 20001, 20042, 20093, 20017, 20079, 20033, 20056, 20091, 20062, 20012, 20068, 20020, 20010, 20080, 20036, 20040, 20037, 20058, 20025, 20054, 20044, 20049, 20051, 20022, 20045, 20094, 20014, 20072, 20034, 20019, 20038, 20046, 20082, 20084, 20008, 20086, 20026, 20015};

            for (int i = 0; i < tinhThanh.Count; i++)
                res.NoiO.Add(idTinhThanh[i], tinhThanh[i]);

            List<string> tinhTrang = new List<string>()
            {"Chưa từng kết hôn", "Đang kết hôn", "Đang ly thân", "Đã ly dị", "Góa vợ/chồng"};
            List<int> idTinhTrang = new List<int>()
            { 1,2,3,4,5};

            for (int i = 0; i < tinhTrang.Count; i++)
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = idTinhTrang[i], TenTinhTrang = tinhTrang[i] });

            
            res.GioiTinh.Add(-1, "Tất cả");
            List<string> gioiTinh = new List<string>()
            { "Nam", "Nữ", "Gay", "Les"};

            for (int i = 0; i < 4; i++)
                res.GioiTinh.Add(i+1, gioiTinh[i]);

            return res;
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            int offset = 1;
            while (true)
            {
                #region Tạo reqeuest
                var uri = new UriBuilder("http://duyenso.com/search_results.php");
                var query = HttpUtility.ParseQueryString(uri.Query);
                query["offset"] = offset.ToString();
                query["set_filter"] = "1";
                query["country"] = "236";                                 //Việt Nam
                query["city"] = "0";                                      //huyện=0=> cả tỉnh
                query["state"] = param.NoiO.ToString();                   //tỉnh
                query["radius"] = "50";
                if ((int)param.GioiTinh != -1)
                    query["p_orientation[]"] = param.GioiTinh.ToString(); //Giới tính
                else                                                      //Tất cả
                {
                    query["p_orientation[]"] = "1";
                    for (int i = 2; i <= 4; i++)
                        query["p_orientation[]"] += string.Format("&p_orientation[]={0}", i.ToString());
                }
                query["p_age_from"] = param.TuTuoi.ToString();
                query["p_age_to"] = param.DenTuoi.ToString();
                query["p_status[]"] = param.HonNhan.FirstOrDefault().Id.ToString();
                for(int i = 2; i < param.HonNhan.Count; i++)
                    query["p_status[]"] += string.Format("&p_status[]={0}", param.HonNhan[i].Id.ToString());
                query["with_photo"] = "1";

                if (param.TimNguoiOnline)
                {
                    query["status"] = "online";
                }
                if (param.TimNguoiMoiDangKy)
                {
                    query["status"] = "new";
                }

                uri.Query = query.ToString();

                HttpWebRequest request = WebRequest.CreateHttp(uri.Uri);
                request.Method = "POST";

                StreamWriter sw = new StreamWriter(request.GetRequestStream());
                sw.Write("ajax=1");
                sw.Close();

                var response = request.GetResponse();
                #endregion

                #region Lấy dữ liệu
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    string content = sr.ReadToEnd();
                    //content = File.ReadAllText("DataHtmlTest.txt");
                    content = HttpUtility.HtmlDecode(content);

                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

                    document.LoadHtml(content);
                    IEnumerable<HtmlNode> hasFloatClass = document.DocumentNode.Descendants("div").Where(div => div.HasClass("filter_result"));

                    document.LoadHtml(hasFloatClass.FirstOrDefault().OuterHtml);
                    var bangKetQua = document.DocumentNode.Descendants("div").Where(div => div.HasClass("item"));
                    for (int i = 0; i < bangKetQua.Count(); i++)
                    {
                        ThongTinTaiKhoan taiKhoan = new ThongTinTaiKhoan();
                        var kq = bangKetQua.ElementAt(i);
                        try
                        {
                            var link = kq.QuerySelector("div > a").GetAttributeValue("href", "");
                            var tenHienThi = kq.QuerySelector("div").GetAttributeValue("title", "");

                            taiKhoan.Id = new string(link.Where(p => char.IsDigit(p)).ToArray());
                            taiKhoan.Url = string.Format("http://duyenso.com/search_results.php?display=profile&uid={0}&ref=spotlight", taiKhoan.Id);

                            var thongTin = tenHienThi.Split(',');

                            taiKhoan.GioiTinh = param.OtherParam[0].ToString();
                            taiKhoan.TenHienThi = thongTin[0].Trim();
                            taiKhoan.Tuoi = thongTin[1].Trim().ConvertToInt32();
                            taiKhoan.NoiO = thongTin[2].Trim();
                        }
                        catch
                        {
                            taiKhoan = null;
                        }
                        if (taiKhoan != null)
                        {
                            yield return taiKhoan;
                        }
                        if (param.DungTimKiem)
                            break;
                    }
                    if (bangKetQua.Count() <= 0)
                        break;
                }
                #endregion
                if (param.DungTimKiem)
                    break;
                offset +=20;
            }
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            throw new NotImplementedException();
        }
    }
}
