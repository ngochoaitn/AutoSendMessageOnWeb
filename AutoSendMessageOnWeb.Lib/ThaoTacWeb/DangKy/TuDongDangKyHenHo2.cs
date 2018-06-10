using AutoSendMessageOnWeb.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb.DangKy
{
    public class TuDongDangKyHenHo2 : ITuDongDangKy
    {
        HttpWebRequest _request;
        CookieContainer _cookieContainer;
        string _setCookie;

        public Image Captcha()
        {
            _request = HttpWebRequest.CreateHttp("https://henho2.com/Captcha/CaptchaImage");
            if (_cookieContainer != null)
                _request.CookieContainer = _cookieContainer;

            _request.Method = "GET";
            using (var response = _request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    if (_cookieContainer == null)
                    {
                        _setCookie = (response as HttpWebResponse).Headers[HttpResponseHeader.SetCookie];
                        _cookieContainer = new CookieContainer();
                        _cookieContainer.SetCookies(UriTrangWeb.HenHo2, _setCookie);
                    }

                    return Bitmap.FromStream(stream);
                }
            }
        }

        public ThongTinTaiKhoan DangKyTaiKhoanMoi(string tai_khoan, string mat_khau, Func<string> captcha, ThongTinBoSung thong_tin_bo_sung = null)
        {
            _request = HttpWebRequest.CreateHttp("https://henho2.com/Account/DangKy");
            _request.Method = "GET";
            if(_cookieContainer != null)
                _request.CookieContainer = _cookieContainer;

            var response = _request.GetResponse();

            if (_cookieContainer == null)
            {
                _setCookie = (response as HttpWebResponse).Headers[HttpResponseHeader.SetCookie];
                _cookieContainer = new CookieContainer();
                _cookieContainer.SetCookies(UriTrangWeb.HenHo2, _setCookie);
            }
            string hoTen = ThongTinBoSung.TaoHoTenNgauNhien();
            var timeout = RequestToWeb.ReadStream(response.GetResponseStream());
            string data = $"Email={tai_khoan}&Name={hoTen}&Password={mat_khau}&Sex=0&MariedStatus=0&Objective=0&Degree=1&Age=18&Height=170&Weight=50&Country=237&Province=58&Profile=Muốn hẹn hò kết bạn&LookingFor=Muốn hẹn hò kết bạn&Captcha={captcha()}";
            _request = HttpWebRequest.CreateHttp("https://henho2.com/Account/DangKy");
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
                    response = _request.GetResponse();
                    var res =  HttpUtility.HtmlDecode(RequestToWeb.ReadStream(response.GetResponseStream()));
                    if (res.Contains("Đã có người sử dụng email này, bạn hãy dùng email khác."))
                        return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Đã có người sử dụng email này" };

                    if (res.Contains("Nhập sai!"))
                        return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Sai captcha" };
                    _cookieContainer = null;
                    return new ThongTinTaiKhoan() { TaiKhoan = tai_khoan, MatKhau = mat_khau };
                }
                catch (Exception ex)
                {
                    if (ex.Message == "The remote server returned an error: (500) Internal Server Error.")
                    {
                        _cookieContainer = null;
                        return new ThongTinTaiKhoan() { TaiKhoan = tai_khoan, MatKhau = mat_khau };
                    }
                    return new ThongTinTaiKhoan() {TaiKhoan = null, TrangThai = "Lỗi chưa xác định" };
                }
            }
        }

        public async Task<ThongTinTaiKhoan> DangKyTaiKhoanMoiAsync(string tai_khoan, string mat_khau, string ho_ten, Func<string> captcha, ThongTinBoSung thong_tin_bo_sung = null)
        {
            _request = HttpWebRequest.CreateHttp("https://henho2.com/Account/DangKy");
            _request.Method = "GET";
            if (_cookieContainer != null)
                _request.CookieContainer = _cookieContainer;

            var response = await _request.GetResponseAsync();

            if (_cookieContainer == null)
            {
                _setCookie = (response as HttpWebResponse).Headers[HttpResponseHeader.SetCookie];
                _cookieContainer = new CookieContainer();
                _cookieContainer.SetCookies(UriTrangWeb.HenHo2, _setCookie);
            }
            string hoTen = ThongTinBoSung.TaoHoTenNgauNhien();
            var timeout = RequestToWeb.ReadStream(response.GetResponseStream());
            string data = $"Email={tai_khoan}&Name={ho_ten}&Password={mat_khau}&Sex=0&MariedStatus=0&Objective=0&Degree=1&Age=18&Height=170&Weight=50&Country=237&Province=58&Profile=Muốn hẹn hò kết bạn&LookingFor=Muốn hẹn hò kết bạn&Captcha={captcha()}";
            _request = HttpWebRequest.CreateHttp("https://henho2.com/Account/DangKy");
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
                    response = await _request.GetResponseAsync();
                    var res =  HttpUtility.HtmlDecode(RequestToWeb.ReadStream(response.GetResponseStream()));
                    if (res.Contains("Đã có người sử dụng email này, bạn hãy dùng email khác."))
                        return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Đã có người sử dụng email này" };

                    if (res.Contains("Nhập sai!"))
                        return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Sai captcha" };
                    _cookieContainer = null;
                    return new ThongTinTaiKhoan() { TaiKhoan = tai_khoan, MatKhau = mat_khau };
                }
                catch (Exception ex)
                {
                    if (ex.Message == "The remote server returned an error: (500) Internal Server Error.")
                    {
                        _cookieContainer = null;
                        return new ThongTinTaiKhoan() { TaiKhoan = tai_khoan, MatKhau = mat_khau };
                    }
                    return new ThongTinTaiKhoan() { TaiKhoan = null, TrangThai = "Lỗi chưa xác định" };
                }
            }
        }

        public async Task<Image> CaptchaAsync()
        {
            _request = HttpWebRequest.CreateHttp("https://henho2.com/Captcha/CaptchaImage");
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
                        _cookieContainer = new CookieContainer();
                        _cookieContainer.SetCookies(UriTrangWeb.HenHo2, _setCookie);
                    }

                    return Bitmap.FromStream(stream);
                }
            }
        }
    }
}
