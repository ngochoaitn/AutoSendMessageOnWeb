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
    public class VietNamCupid : IThaoTacWeb
    {
        public CookieContainer Cookie { set; get; }
        public bool TimKiemYeuCauCookie
        {
            get
            {
                return true;
            }
        }

        public void DangNhap(ref ThongTinTaiKhoan tk)
        {
            #region Logout
            //Https nên có xác thực => nếu không đăng xuất sẽ bị lấy phiên đăng nhập cũ
            HttpWebRequest logoutRequest = WebRequest.CreateHttp("https://www.vietnamcupid.com/vi/auth/logout");
            logoutRequest.Method = "GET";
            var logoutResponse = RequestToWeb.GET(new Uri("https://www.vietnamcupid.com/vi/auth/logout"), true);

            #endregion

            #region Login
            tk.Cookie = new CookieContainer();

            #region Login 1: Get first Cookie

            string loginData = string.Format("Email={0}&password={1}&RememberMe=1", tk.TaiKhoan, tk.MatKhau);

            var loginResponse = RequestToWeb.POST(new Uri("https://www.vietnamcupid.com/logon_do.cfm"), tk.Cookie, loginData, true);

            string sLoginCookie = loginResponse.Headers[HttpResponseHeader.SetCookie];
            string sLoginLoc1 = loginResponse.Headers[HttpResponseHeader.Location];
            #endregion Login 1: Get first Cookie

            #region Login 2: Get login cookie

            var loginResponse2 = RequestToWeb.POST(new Uri("https://www.vietnamcupid.com/logon_do.cfm"), tk.Cookie, loginData, true);// loginRequest2.GetResponse();

            string sLoginCookie2 = loginResponse2.Headers[HttpResponseHeader.SetCookie];
            string sLoginLoc2 = loginResponse2.Headers[HttpResponseHeader.Location];
            tk.TrangThai = "Đang nhập thành công";
            if (sLoginLoc2.Contains("error"))
            {
                tk.TrangThai = "Sai tài khoản hoặc mật khẩu";
                tk.Cookie = null;
            }
            //Https chưa lưu được cookie
            //else
            //{
            //    foreach (Cookie cook in tk.Cookie.GetCookies(UriTrangWeb.VietNamCupid))
            //    {
            //        if (cook.Name == "_DIST")
            //        {
            //            tk.HanCookie = cook.Expires;
            //        }
            //    }
            //}

            #endregion Login 2: Get login cookie

            #endregion

        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung)
        {
            if (nguoigui.Cookie == null)
                throw new Exception("Thiếu cookie");
            tieude = tieude.Split('(')[0].Trim();
            bool dungTieude = false;
            for (int i = 1; i <= 10; i++)
            {
                if (tieude == string.Format("default_{0}", i))
                {
                    dungTieude = true;
                    break;
                }
            }
            if(!dungTieude)
                throw new Exception("Vui lòng chọn tiêu đề như gợi ý: default_<số từ 1 đến 10>\nVí dụ: default_1");

            string data = string.Format("memberid={0}&subject={1}&body={2}&cssSuffix=sm&subjectChanged=false&replyID=0&mailsInThread=0&imbraconsent=0", nguoinhan.Id, tieude, Uri.EscapeDataString(noidung));
            var response = RequestToWeb.POST2(new Uri("https://www.vietnamcupid.com/vi/mail/sendEmail?ajaxMode=false"), nguoigui.Cookie, data, false, false, "application/x-www-form-urlencoded; charset=UTF-8");
            var headers = RequestToWeb.ReadHeader(response);
            nguoinhan.TrangThai = nguoigui.TaiKhoan;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string stringResponse = sr.ReadToEnd();
                string noidung1 = noidung.Split(new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries)[0];
                if (!stringResponse.Contains(noidung1))
                    nguoinhan.TrangThai = "Gửi lỗi\n(không nhận tin nhắn cùng giới hoặc đã quá giới hạn gửi)";
            }
        }

        public DanhSachDuLieuTimKiem TaoDuLieuTimKiem()
        {
            DanhSachDuLieuTimKiem res = new DanhSachDuLieuTimKiem();

            List<string> tinhThanh = new List<string>()
            {"Bất Kỳ Bang Nào", "An Giang", "Bà Rịa-Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Ðịnh", "Bình Dương", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Ðà Nẵng", "Ðắc Lắk", "Ðồng Nai", "Ðồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tây", "Hà Tĩnh", "Hải Dương", "Hải Phòng", "Hồ Chí Minh", "Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Ðồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Ðịnh", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên-Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"};
            List<int> idTinhThanh = new List<int>()
            { -1, 6685, 6705, 6730, 6731, 6732, 6733, 6686, 6706, 6734, 6735, 6707, 6736, 6708, 6687, 6737, 6688, 6703, 6689, 6709, 6710, 6739, 6704, 6711, 6712, 6738, 6690, 6691, 6713, 6740, 6714, 6692, 6715, 6693, 6694, 6702, 6716, 6695, 6741, 6717, 6718, 6719, 6742, 6720, 6721, 6743, 6722, 6696, 6723, 6724, 6697, 6698, 6700, 6744, 6699, 6725, 6701, 6726, 6727, 6728, 6745, 6729 };

            for (int i = 0; i < tinhThanh.Count; i++)
                res.NoiO.Add(idTinhThanh[i], tinhThanh[i]);

            List<string> tinhTrang = new List<string>()
            {"Bất kỳ", "Độc thân", "Ly thân", "Góa", "Ly hôn", "Kết hôn"};
            List<int> idTinhTrang = new List<int>()
            { -1, 556, 557, 559, 558, 560 };

            for (int i = 0; i < tinhTrang.Count; i++)
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = idTinhTrang[i], TenTinhTrang = tinhTrang[i] });


            List<string> gioiTinh = new List<string>()
            { "Bất kỳ", "Nam", "Nữ"};
            List<int> idGioiTinh = new List<int>()
            { -1, 253, 254};

            for (int i = 0; i < gioiTinh.Count; i++)
                res.GioiTinh.Add(idGioiTinh[i], gioiTinh[i]);

            return res;
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            int pageindex = 1;
            while (true)
            {
                #region Tạo reqeuest
                var uri = new UriBuilder("https://www.vietnamcupid.com/");
                WebResponse response;
                if (pageindex == 1)
                {
                    uri = new UriBuilder("https://www.vietnamcupid.com/vi/results/search?searchtype=1");
                    string data = string.Format("resulttype=advanced&gender_w={0}&age_min={1}&age_max={2}", param.GioiTinh, param.TuTuoi, param.DenTuoi);
                    data += string.Format("&countryLive=230&stateLive={0}", param.NoiO);
                    foreach (var hn in param.HonNhan)
                        data += string.Format("&maritalStatus={0}", hn.Id);
                    data += "&cityLive=-1&searchingFor=-1&resetCurrency=VND&distanceUnit=kms&gender=253";
                    response = RequestToWeb.POST(uri.Uri, this.Cookie, data, false, true);
                }
                else
                {
                    uri = new UriBuilder(string.Format("https://www.vietnamcupid.com/vi/results/search?pageno={0}", pageindex));
                    response = RequestToWeb.GET(uri.Uri, false, false, this.Cookie);
                }
                #endregion

                #region Lấy dữ liệu
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    string content = sr.ReadToEnd();
                    //string content = File.ReadAllText("DataHtmlTest.txt");
                    content = HttpUtility.HtmlDecode(content);

                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(content);

                    var bangKetQua = document.DocumentNode.QuerySelectorAll("div#memberships > div").ToList();
                    for (int i = 0; i < bangKetQua.Count; i++)
                    {
                        ThongTinTaiKhoan taiKhoan = new ThongTinTaiKhoan();
                        var memberpicgeneric = bangKetQua[i].QuerySelectorAll("div > div > p");
                        if (memberpicgeneric.Count() < 2)
                            continue;//Quảng cáo
                        var hdg1 = memberpicgeneric.ElementAt(0).QuerySelector("a");
                        var hdg2 = memberpicgeneric.ElementAt(1);
                        if (memberpicgeneric != null)
                        {
                            string duongDan = hdg1.GetAttributeValue("href", "");
                            if (!string.IsNullOrEmpty(duongDan))
                            {
                                try
                                {
                                    var tmpUri = new Uri("https://www.vietnamcupid.com" + duongDan);
                                    string id = tmpUri.Segments[tmpUri.Segments.Count() - 1];
                                    var tenTuoi = hdg1.InnerHtml.Split('(', ')').Where(p => !string.IsNullOrEmpty(p)).ToList();
                                    string ten = tenTuoi[0];
                                    string tuoi = tenTuoi[tenTuoi.Count - 1];//lấy tuổi cuối cùng

                                    string noiO = "";
                                    if(hdg2.ChildNodes.Count >= 1)
                                        noiO = hdg2.ChildNodes[1].InnerText.TrimAll();
                                    else
                                        try
                                        {
                                            var tmp = bangKetQua[i].QuerySelectorAll("div > div").FirstOrDefault();
                                            noiO = tmp.ChildNodes[2].InnerText.TrimAll();
                                        }
                                        catch
                                        {

                                        }
                                    taiKhoan.Url = string.Format("https://www.vietnamcupid.com/vi/profile/showProfile/ID/{0}", id);
                                    taiKhoan.Id = id;
                                    taiKhoan.TenHienThi = ten.Trim();
                                    taiKhoan.ChoPhepGuiNhan = true;
                                    taiKhoan.Tuoi = tuoi.ConvertToInt32();
                                    taiKhoan.GioiTinh = param.OtherParam[0].ToString();
                                    taiKhoan.NoiO = noiO;
                                    taiKhoan.TinhTrangHonNhan = param.OtherParam[1].ToString();
                                }
                                catch//(Exception ex)
                                { taiKhoan = null; }

                                if (taiKhoan != null)
                                    yield return taiKhoan;
                            }
                        }

                    }
                    //Test: break;
                    if (bangKetQua.Count <= 1)
                        break;
                }
                #endregion

                pageindex++;
            }
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            throw new NotImplementedException();
        }

        public static void Test()
        {
            #region Logout
            HttpWebRequest logoutRequest = WebRequest.CreateHttp("https://www.vietnamcupid.com/vi/auth/logout");
            logoutRequest.Method = "GET";
            var logoutResponse = logoutRequest.GetResponse();
            #endregion

            #region Login
            CookieContainer loginCookie = new CookieContainer();
            HttpWebRequest loginRequest = WebRequest.CreateHttp("https://www.vietnamcupid.com/logon_do.cfm");

            loginRequest.CookieContainer = loginCookie;
            loginRequest.Method = "POST";
            loginRequest.AllowAutoRedirect = false;
            loginRequest.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter sw = new StreamWriter(loginRequest.GetRequestStream()))
            {
                string data = "Email=ngochoaitn@gmail.com&password=noongngocj&RememberMe=1";
                sw.Write(data);
                sw.Close();
            }
            
            var loginResponse = loginRequest.GetResponse();

            string sLoginCookie = loginResponse.Headers[HttpResponseHeader.SetCookie];
            string sCookie1 = loginRequest.Headers[HttpRequestHeader.Cookie];
            string sLoginLoc1 = loginResponse.Headers[HttpResponseHeader.Location];


            HttpWebRequest loginRequest2 = WebRequest.CreateHttp("https://www.vietnamcupid.com/logon_do.cfm");

            loginRequest2.CookieContainer = loginCookie;// new CookieContainer();
            //loginRequest2.CookieContainer.SetCookies(new Uri("https://www.vietnamcupid.com"), loginCookie);
            loginRequest2.Method = "POST";
            loginRequest2.AllowAutoRedirect = false;
            loginRequest2.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter sw = new StreamWriter(loginRequest2.GetRequestStream()))
            {
                string data = "Email=ngochoaitn@gmail.com&password=noongngocj&RememberMe=1";
                sw.Write(data);
                sw.Close();
            }

            var loginResponse2 = loginRequest2.GetResponse();

            string sLoginCookie2 = loginResponse2.Headers[HttpResponseHeader.SetCookie];
            string sCookie2 = loginRequest2.Headers[HttpRequestHeader.Cookie];
            string sLoginLoc2 = loginResponse2.Headers[HttpResponseHeader.Location];

            string logginS2 = "";
            using (StreamReader sr = new StreamReader(loginResponse2.GetResponseStream()))
            {
                logginS2 = sr.ReadToEnd();
                sr.Close();
            }
            #endregion

            #region Search
            CookieContainer searhCookie = loginCookie;

            HttpWebRequest searchRequest = WebRequest.CreateHttp("https://www.vietnamcupid.com/vi/results/search?searchtype=1");

            searchRequest.CookieContainer = searhCookie;
            searchRequest.Method = "POST";
            searchRequest.AllowAutoRedirect = false;
            searchRequest.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter sw = new StreamWriter(searchRequest.GetRequestStream()))
            {
                string data = "resulttype=advanced&gender_w=254&age_min=19&age_max=29&countryLive=230&maritalStatus=556&maritalStatus=558&cityLive=-1&searchingFor=-1&resetCurrency=VND&distanceUnit=kms&stateLive=-1&gender=253";
                sw.Write(data);
                sw.Close();
            }
            HttpWebResponse searchResponse = (HttpWebResponse)searchRequest.GetResponse();
            string searchLoc = searchResponse.Headers[HttpResponseHeader.Location];
            string searchS = "";
            using (StreamReader sr = new StreamReader(searchResponse.GetResponseStream()))
            {
                searchS = sr.ReadToEnd();
                sr.Close();
            }
            #endregion
        }
    }
}
