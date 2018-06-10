using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSendMessageOnWeb.Data;
using System.Net;
using System.IO;
using System.Web;
using System.Diagnostics;

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb.DangKy
{
    public class TuDongDangKyDuyenSo : ITuDongDangKy
    {
        HttpWebRequest _request;
        CookieContainer _cookieContainer;
        string _setCookie;

        public Image Captcha()
        {
            throw new NotImplementedException();
        }

        public async Task<Image> CaptchaAsync()
        {
            _request = HttpWebRequest.CreateHttp("http://duyenso.com/join.php");
            if (_cookieContainer != null)
                _request.CookieContainer = _cookieContainer;

            _request.Method = "GET";
            using (var response = await _request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (_cookieContainer == null)
                    {
                        _setCookie = (response as HttpWebResponse).Headers[HttpResponseHeader.SetCookie];
                        Debug.WriteLine($"{Task.CurrentId} - SetCookie: {_setCookie}");
                        _cookieContainer = new CookieContainer();
                        _cookieContainer.SetCookies(UriTrangWeb.DuyenSo, _setCookie);
                    }

                    var html = RequestToWeb.ReadStream(stream);
                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(html);

                    var captchaLink = document.GetElementbyId("img_join_captcha").GetAttributeValue("src", "http://duyenso.com/_server/securimage/securimage_show_custom.php");
                    Debug.WriteLine($"{Task.CurrentId} - CaptLink: {captchaLink}");

                    captchaLink = "http://duyenso.com" + captchaLink.Substring(1);
                    _request = HttpWebRequest.CreateHttp(captchaLink);
                    if (_cookieContainer != null)
                        _request.CookieContainer = _cookieContainer;

                    _request.Method = "GET";
                    using (var response2 = await _request.GetResponseAsync())
                    {
                        using (var stream2 = response2.GetResponseStream())
                        {
                            _setCookie = (response as HttpWebResponse).Headers[HttpResponseHeader.SetCookie];
                            if (_setCookie != null)
                            {
                                _cookieContainer = new CookieContainer();
                                _cookieContainer.SetCookies(UriTrangWeb.DuyenSo, _setCookie);
                            }

                            return Bitmap.FromStream(stream2);
                        }
                    }
                }
            }
        }

        public ThongTinTaiKhoan DangKyTaiKhoanMoi(string tai_khoan, string mat_khau, Func<string> captcha, ThongTinBoSung thong_tin_bo_sung = null)
        {
            throw new NotImplementedException();
        }

        public async Task<ThongTinTaiKhoan> DangKyTaiKhoanMoiAsync(string tai_khoan, string mat_khau, string ho_ten, Func<string> captcha, ThongTinBoSung thong_tin_bo_sung = null)
        {
            if (_cookieContainer == null)
                await CaptchaAsync();
            string data = $"cmd=register&ajax=1&email={tai_khoan}&join_password={mat_khau}&join_handle={ho_ten}&day=1&month=5&year=1990&orientation={thong_tin_bo_sung.GioiTinh}&country=236&state=20014&city=200116&captcha={captcha()}";
            _request = HttpWebRequest.CreateHttp("http://duyenso.com/join.php");
            _request.Headers[HttpRequestHeader.Cookie] = _setCookie;
            _request.CookieContainer = _cookieContainer;

            _request.Method = "POST";
            _request.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter sw = new StreamWriter(_request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Close();
                try
                {
                    var response = await _request.GetResponseAsync();
                    var res =  HttpUtility.HtmlDecode(RequestToWeb.ReadStream(response.GetResponseStream()));
                    if (res.Contains("E-mail đã tồn tại trong hệ thống"))
                        return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Đã có người sử dụng email này" };

                    if (res.Contains("Mã an toàn không đúng"))
                        return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Sai captcha" };

                    await HoanThienHoSo();
                    await GuiEmailXacNhan(tai_khoan);
                    _cookieContainer = null;
                    return new ThongTinTaiKhoan() { TaiKhoan = tai_khoan, MatKhau = mat_khau };
                }
                catch (Exception ex)
                {
                    if (ex.Message == "The remote server returned an error: (500) Internal Server Error.")
                    {
                        await HoanThienHoSo();
                        await GuiEmailXacNhan(tai_khoan);
                        _cookieContainer = null;
                        return new ThongTinTaiKhoan() { TaiKhoan = tai_khoan, MatKhau = mat_khau };
                    }
                    return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Lỗi chưa xác định" };
                }
            }
        }

        private async Task HoanThienHoSo()
        {
            if (_cookieContainer == null)
                await CaptchaAsync();
            int gioiTinh = new Random().Next(1, 5);
            string data = $"cmd=update_personal_field&ajax=1&i_am_here_for=1&education=4&occupation=Tìm người yêu&employment_status=4&income=2&status=1&family=1&want_more_kid=1&living_with=1&home_type=2&sexuality=1&height=21&weight=22&body=2&hair=3&eye=1&religion=25&home_town=Thái Nguyên&chinese_sign=3&language[]=1&smoking=3&drinking=2&pet=3&p_sexuality=1&p_age_from=23&p_age_to=32&p_height_from=20&p_height_to=32&p_education=2&p_income=2&p_married_before=3&p_have_kid=1&p_want_more_kid=1&p_same_religion=1";
            _request = HttpWebRequest.CreateHttp("http://duyenso.com/ajax.php");
            _request.Headers[HttpRequestHeader.Cookie] = _setCookie;
            _request.CookieContainer = _cookieContainer;

            _request.Method = "POST";
            _request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            using (StreamWriter sw = new StreamWriter(_request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Close();
                try
                {
                    var response = await _request.GetResponseAsync();
                    var timeout = RequestToWeb.ReadStream(response.GetResponseStream());
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private async Task GuiEmailXacNhan(string email)
        {
            if (_cookieContainer == null)
                await CaptchaAsync();
            int gioiTinh = new Random().Next(1, 5);
            string data = $"email={email}";
            _request = HttpWebRequest.CreateHttp("http://duyenso.com/email_not_confirmed.php");
            _request.Headers[HttpRequestHeader.Cookie] = _setCookie;
            _request.CookieContainer = _cookieContainer;

            _request.Method = "POST";
            _request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            using (StreamWriter sw = new StreamWriter(_request.GetRequestStream()))
            {
                sw.Write(data);
                sw.Close();
                try
                {
                    var response = await _request.GetResponseAsync();
                    var timeout = RequestToWeb.ReadStream(response.GetResponseStream());
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
