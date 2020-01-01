using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using HtmlAgilityPack;

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb.DangKy
{
    public class TuDongDangKyEHenho : ITuDongDangKy
    {
        //CookieContainer _cookieContainer;

        public Image Captcha()
        {
            return null;
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
            try
            {
                CookieContainer _cookieContainer = new CookieContainer();

                string linkDangKy = "https://ehenho.com/accounts/signup/";
                HttpWebResponse response = await RequestToWeb.GETAsync(new Uri(linkDangKy), false, true, _cookieContainer) as HttpWebResponse;
                //var cookies = _cookieContainer.GetAllCookies();
                var check = await RequestToWeb.GETAsync(new Uri("https://ehenho.com/static/js/provinces/tp-ho-chi-minh.js"), true, cookie: _cookieContainer);
                string csrfTokenHeader = _cookieContainer.GetCookie("csrftoken");
                HtmlDocument document = new HtmlDocument();
                string htmlText = HttpUtility.HtmlDecode(RequestToWeb.ReadStream(response.GetResponseStream()));
                document.LoadHtml(htmlText);
                string csrfmiddlewaretoken = document.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='csrfmiddlewaretoken']").Attributes["value"].Value;
                
                Random rand = new Random();
                List<string> tinhTrangHonNhan = new List<string>() { "single", "divorced", "widowed", "in-relationship" };
                List<string> mucTieu = new List<string>() { "long-term-love", "short-term-love", "new-friends", "chat-or-intimate-friends", "marriage", "life-mate" };
                List<string> hocVan = new List<string>() { "GRA", "VCA", "ASO", "BAC", "MAS", "AMA" };
                List<string> noiO = new List<string>() { "tp-ho-chi-minh", "ha-noi", "an-giang", "ba-ria-vung-tau", "bac-lieu", "ca-mau", "gia-lai", "son-la", "lang-son", "ninh-binh", "da-nang", "dien-bien", "tuyen-quang" };
                List<string> headline = new List<string>() { "Em mộc mạc", "Tìm anh à", "Bố mẹ dục cưới", "Bị bắt cưới", "Làm đám cưới", "Tìm người giàu", "Nhà điều kiện" };
                List<string> profiles = new List<string>() { "Muốn hẹn hò kết bạn", "TÌm người yêu", "Cần một muối quan hệ lâu dài", "Đã có con, nếu không ngại thì inbox làm quen", "Đang bị dục cưới", "Bố mẹ bắt cưới, cần tìm bạn tình gấp", "Chả có gì giới thiệu cả" };

                string data = $"csrfmiddlewaretoken={csrfmiddlewaretoken}&email={tai_khoan}&password={mat_khau}&name={ho_ten}" +
                    $"&dob_day={rand.Next(1, 28)}&dob_month={rand.Next(1, 12)}&dob_year={rand.Next(1986, 2005)}&gender={thong_tin_bo_sung.GioiTinh}" +
                    $"&marital_status={tinhTrangHonNhan.GetRandomElement()}&look_for={mucTieu.GetRandomElement()}&height={rand.Next(145, 208)}" +
                    $"&weight={rand.Next(35, 80)}&education={hocVan.GetRandomElement()}&province={noiO.GetRandomElement()}&headline={headline.GetRandomElement()}" +
                    $"&master_appearance={rand.Next(1, 50)}&master_interest={rand.Next(1, 417)}&master_personality={rand.Next(1, 496)}" +
                    $"&way_of_life={rand.Next(1, 64)}&most_valued={rand.Next(1, 53)}&i_am={profiles.GetRandomElement()}&my_match={profiles.GetRandomElement()}" +
                    $"&setfc_flag=on&appearance_str1=2&appearance_str2=&appearance_str3=&interest_str1=3&interest_str2=" +
                    $"&interest_str3=&interest_str4=&interest_str5=&personality_str1=2&personality_str2=&personality_str3=&personality_str4=" +
                    $"&personality_str5=&personality_str6=&personality_str7=&way_of_life_str=7&most_valued_str=3&submit=Đăng ký";

                response = RequestToWeb.POST(new Uri(linkDangKy), _cookieContainer, data, false, true,
                    config_more: (req) =>
                    {
                        req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
                        req.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                        req.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.9,vi;q=0.8");
                        req.Headers.Add(HttpRequestHeader.CacheControl, "max-age=0");
                        //req.KeepAlive = true;
                        //req.Connection = "keep-alive";

                        req.Headers.Add("DNT", "1");

                        //req.Host = "ehenho.com";
                        req.Headers.Add("Origin", "https://ehenho.com");
                        req.Referer = "https://ehenho.com/accounts/signup/";

                        req.Headers.Add("Sec-Fetch-Mode", "navigate");
                        req.Headers.Add("Sec-Fetch-Site", "same-origin");
                        //req.Headers.Add("Sec-Fetch-User", "?1");
                        //req.Headers.Add("Upgrade-Insecure-Requests", "1");

                        req.Headers.Add("X-CSRFToken", csrfTokenHeader);

                    }) as HttpWebResponse;


                if (response == null)
                    return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Lỗi: Web phản hồi quá lâu" };

                var res = HttpUtility.HtmlDecode(RequestToWeb.ReadStream(response.GetResponseStream()));
                if (response.StatusCode == HttpStatusCode.Found)
                    return new ThongTinTaiKhoan() { TaiKhoan = tai_khoan, MatKhau = mat_khau };
                else
                    return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Tạo lỗi" };
            }
            catch (Exception ex)
            {
                return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Lỗi chưa xác định" };
            }
        }
    }
}
