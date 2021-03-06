﻿using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib
{
    public class ehenho : IGuiTinNhan
    {
        string _fileLog = "Data\\ehenho_log.txt";
        public CookieContainer Cookie { set; get; }

        public bool TimKiemYeuCauCookie => false;

        public void DangNhap(ref ThongTinTaiKhoan tk)
        {
            tk.Cookie = new CookieContainer();
            var response = RequestToWeb.GET(new Uri("https://www.ehenho.com/"), false, true, tk.Cookie);
            var s = RequestToWeb.ReadStream(response.GetResponseStream());
            HtmlDocument document = new HtmlDocument();

            document.LoadHtml(s);
            var value = document.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='csrfmiddlewaretoken']").Attributes["value"].Value;
            
            string data = $"login={tk.TaiKhoan}&password={tk.MatKhau}&remember=on&csrfmiddlewaretoken={value}&remember=on";
            response = RequestToWeb.POST(new Uri("https://www.ehenho.com/accounts/login/"), tk.Cookie, data, true,
                config_more: (request) =>
                 {
                     request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
                     request.Referer = "https://www.ehenho.com/";
                 });
            if((response as HttpWebResponse)?.StatusCode == HttpStatusCode.Found)
            {
                tk.TrangThai = "Đang nhập thành công";
                tk.ChoPhepGuiNhan = true;
            }
            else
            {
                tk.TrangThai = "Đăng nhập thất bại";
                tk.Cookie = null;
            }
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> callback = null)
        {
            HttpWebResponse response = RequestToWeb.GET(new Uri(nguoinhan.Url), false, true, nguoigui.Cookie) as HttpWebResponse;
            string htmlText = RequestToWeb.ReadStream(response.GetResponseStream());
            if (htmlText.Contains("class=\"msg-cp\""))
            {
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(htmlText);
                var csrfmiddlewaretoken = document.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='csrfmiddlewaretoken']").Attributes["value"].Value;
                string data = $"csrfmiddlewaretoken={csrfmiddlewaretoken}&body={noidung}&send=      Gửi!      ";
                string responseHtml = RequestToWeb.ReadStream(RequestToWeb.POST(new Uri(nguoinhan.Url), nguoigui.Cookie, data, false, true,
                    config_more: (request) =>
                    {
                        request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
                        request.Referer = nguoinhan.Url;
                    }));

                if (responseHtml == null)
                {
                    nguoinhan.TrangThai = nguoigui.TrangThai = "Gửi lỗi\r\nKhông đọc được nội dung";
                    nguoigui.ChoPhepGuiNhan = false;
                    nguoinhan.TrangThai = "Gửi lỗi (Web không trả về dữ liệu để xử lý)";
                }
                else if (responseHtml?.Contains("Thư gửi không thành công!") ?? true)
                {
                    nguoinhan.TrangThai = nguoigui.TrangThai = "Gửi lỗi\nQuá giới hạn 48 thư";
                    nguoigui.ChoPhepGuiNhan = false;
                }
                else
                {
                    nguoinhan.TrangThai = nguoigui.TaiKhoan;
                }
            }
            else
            {
                nguoinhan.TrangThai = nguoigui.TrangThai = "Gửi lỗi. Tài khoản bị khóa";
                nguoigui.ChoPhepGuiNhan = false;
            }
        }

        public DanhSachDuLieuTimKiem TaoDuLieuTimKiem()
        {
            //try
            //{
                DanhSachDuLieuTimKiem res = new DanhSachDuLieuTimKiem();

                //HttpWebResponse resposne = RequestToWeb.GET(new Uri("https://www.ehenho.com/tim-ban-cac-noi-o-chinh/"), false, true, Cookie) as HttpWebResponse;
                HttpWebResponse resposne = RequestToWeb.GET(new Uri("https://www.ehenho.com/tim-ban-bon-phuong-theo-noi-o/"), false, true, Cookie) as HttpWebResponse;
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(RequestToWeb.ReadStream(resposne.GetResponseStream()));
                foreach (HtmlNode node in document.DocumentNode.QuerySelectorAll("a").Where(p => p.OuterHtml.Contains("/tim-ban-bon-phuong/")))
                    try { res.NoiO.Add(node.GetAttributeValue("href", ""), node.InnerText?.Replace("Tìm bạn ", "")?.Replace(",", "")?.Replace("&nbsp;", "")); }
                    catch { }

                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = "/tim-ban-ban-phuong/", TenTinhTrang = "Tất cả" });
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = "/tim-ban-doc-than/", TenTinhTrang = "Độc thân" });
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = "/tim-ban-ly-di/", TenTinhTrang = "Ly dị" });
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = "/tim-ban-o-goa/", TenTinhTrang = "Ở góa" });
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = "/dang-co-nguoi-yeu-tim-ban/", TenTinhTrang = "Đang có người yêu" });

                res.GioiTinh.Add("Tất cả", "Tất cả");
                res.GioiTinh.Add("Nam", "Nam");
                res.GioiTinh.Add("Nữ", "Nữ");

                return res;
            //}
            //catch(Exception ex)
            //{
            //    Log.WriteLog(_fileLog, $"Lỗi TaoDuLieuTimKiem() {ex.Message}\r\n{ex.ReadAllStatcktrace()}\r\n--------------------------------");
            //    throw new Exception("Không tạo được dữ liệu tìm kiếm");
            //}
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            return this.TimKiemAll(param).Result;
        }

        public async Task<IEnumerable<ThongTinTaiKhoan>> TimKiemAll(ThongTinTimKiem param)
        {
            Log.WriteLog(_fileLog, "Bắt đầu tìm kiếm ehenho...");
            List<ThongTinTaiKhoan> res = new List<ThongTinTaiKhoan>();
            int pageindex = 1;
            HtmlDocument document = new HtmlDocument();
            string linkNoiO = $"https://www.ehenho.com{param.NoiO}";// $"https://www.ehenho.com{tinhtrang.Id}";
            int countTry = 0;
            while (true)
            {
                try
                {
                    Debug.WriteLine($"Trang {pageindex}----------------------------------");
                    Log.WriteLog(_fileLog, $"Trang {pageindex}----------------------------------");
                    HttpWebResponse response = RequestToWeb.GET(new Uri(linkNoiO), false, true, this.Cookie) as HttpWebResponse;
                    string htmlText = RequestToWeb.ReadStream(response.GetResponseStream());
                    document.LoadHtml(htmlText);

                    var bangKetQua = document.DocumentNode.QuerySelectorAll("#pro_info");//
                    res.AddRange(await Task.WhenAll(bangKetQua.Select(p => TimKiemTaiKhoan(param, p))));

                    TimThayKetQua?.Invoke(res.Where(p => p != null));

                    //Tạo link trang tiếp
                    if (htmlText.Contains($"?page={pageindex + 1}"))
                        linkNoiO = $"https://www.ehenho.com{param.NoiO}?page={++pageindex}";
                    else if (htmlText.Contains($"?trang={pageindex + 1}"))
                        linkNoiO = $"https://www.ehenho.com{param.NoiO}?trang={++pageindex}";
                    else
                        break;

                    if (param.DungTimKiem)
                        break;
                    countTry = 0;
                }
                catch(Exception ex)
                {
                    if (countTry++ >= 20)
                        break;
                    Log.WriteLog(_fileLog, $"Lỗi {ex.Message}\r\n{ex.StackTrace}");
                }
            }
            Debug.WriteLine($"Kết thúc tìm kiếm tại {param.NoiO}, trang {pageindex}");
            Log.WriteLog(_fileLog, $"Kết thúc tìm kiếm tại {param.NoiO}, trang {pageindex}");
            return res;
        }

        private Task<ThongTinTaiKhoan> TimKiemTaiKhoan(ThongTinTimKiem param, HtmlNode kq)
        {
           return Task.Run<ThongTinTaiKhoan>(() =>
           {
               ThongTinTaiKhoan tk = new ThongTinTaiKhoan();
               try
               {
                   string log = $"{DateTime.Now.ToString("HH:mm:ss")} -> ";

                   var thongTinKq = kq.QuerySelector("p");
                   var spanKq = thongTinKq?.QuerySelectorAll("span");

                   var ten_tuoi_tinhTrang = spanKq.ElementAt(0);

                   var ten_tuoi_tinh_trang_a = ten_tuoi_tinhTrang?.QuerySelectorAll("a");

                   var ten = ten_tuoi_tinh_trang_a.ElementAt(0);
                   tk.TenHienThi = ten.InnerText;
                   tk.Url = $"https://www.ehenho.com{ten.GetAttributeValue("href", "")}";
                   tk.Id = tk.Url?.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries)?.Last();
                   tk.Tuoi = ten_tuoi_tinhTrang.InnerText.Split(new[] { "&nbsp;" }, StringSplitOptions.RemoveEmptyEntries)?.ElementAt(1)?.Trim()?.ConvertToInt32();
                   if (string.IsNullOrEmpty(tk.Id) || tk.Tuoi == null || tk.Tuoi > param.DenTuoi || tk.Tuoi < param.TuTuoi)
                   {
                       Debug.WriteLine($"{log}{DateTime.Now.ToString("HH:mm:ss")} Faild (không đủ tuổi: {tk.Tuoi})");
                       return null;
                   }

                   #region Tỉnh trạng hôn nhân
                   tk.TinhTrangHonNhan = ten_tuoi_tinh_trang_a.ElementAt(1)?.InnerText;
                   if (!param.HonNhan.Select(p => p.TenTinhTrang).Contains("Tất cả") && !param.HonNhan.Select(p => p.Id).Contains(ten_tuoi_tinh_trang_a.ElementAt(1).GetAttributeValue("href", "")))
                       if (tk.GioiTinh != param.GioiTinh.ToString())
                       {
                           Debug.WriteLine($"{log}{DateTime.Now.ToString("HH:mm:ss")} Faild (Tình trạng hôn nhân: {tk.TinhTrangHonNhan})");
                           return null;
                       }
                   #endregion Tình trạng hôn nhân

                   #region Nơi ở
                   var noiO = spanKq.ElementAt(1);
                   var noiO_a = noiO.QuerySelectorAll("a");
                   List<string> diaChi = new List<string>();
                   for (int i = 1; i < noiO_a.Count(); i++)
                       diaChi.Add(noiO_a.ElementAt(i).InnerText);
                   tk.NoiO = string.Join(", ", diaChi);
                   #endregion Nơi ở

                   #region Giới tính (có thể lấy thông tin qua cách này luôn cho dễ với đầy đủ)
                   tk.GioiTinh = "Tất cả";
                   if (param.GioiTinh.ToString() != "Tất cả" || param.ThoiGianDangNhap.HasValue)
                   {
                       HtmlDocument docChiTiet = new HtmlDocument();
                       string html = RequestToWeb.ReadStream(RequestToWeb.GET(new Uri(tk.Url), false, true, this.Cookie));
                       int countTry = 0;
                       while (string.IsNullOrEmpty(html) && countTry++ < 3)
                       {
                           Log.WriteLog(_fileLog, $"TimKiemTaiKhoan() Thử lại {tk?.Url}");
                           html = RequestToWeb.ReadStream(RequestToWeb.GET(new Uri(tk.Url), false, true, this.Cookie));
                       }

                       if (string.IsNullOrEmpty(html))
                           return null;

                       docChiTiet.LoadHtml(html);
                       var allRow = docChiTiet?.DocumentNode?.QuerySelectorAll("table > tr");
                       if (param.GioiTinh.ToString() != "Tất cả")
                       {
                           tk.GioiTinh = allRow?.ElementAt(6)?.QuerySelectorAll("td")?.Last()?.InnerText?.Split(' ')?.First();
                           if (tk.GioiTinh != param.GioiTinh.ToString())
                           {
                               Debug.WriteLine($"{log}{DateTime.Now.ToString("HH:mm:ss")} Faild (Giới tính: {tk.GioiTinh})");
                               return null;
                           }
                       }

                       if (param.ThoiGianDangNhap.HasValue)
                       {
                           try
                           {
                               DateTime thoiGianDangNhapganNhat = Convert.ToDateTime(allRow?.ElementAt(allRow.Count() - 2)?.QuerySelectorAll("td")?.Last()?.InnerText?.Replace(".", ""));
                               if ((DateTime.Now - thoiGianDangNhapganNhat).TotalMinutes > param.ThoiGianDangNhap)
                               {
                                   Debug.WriteLine($"{log}{DateTime.Now.ToString("HH:mm:ss")} Faild (Thời gian đăng nhập: {thoiGianDangNhapganNhat.ToString("dd/MM/yyyy HH:mm")})");
                                   return null;
                               }
                           }
                           catch { }
                       }
                   }
                   #endregion Giới tính
                   Debug.WriteLine($"{log}{DateTime.Now.ToString("HH:mm:ss")} OK: {tk.Url}");
                   return tk;
               }
               catch(Exception ex)
               {
                   Log.WriteLog(_fileLog, $"Lỗi TimKiemTaiKhoan({tk?.Url}) {ex.Message}\r\n{ex.StackTrace}");
                   return null;
               }
           });
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            throw new NotImplementedException();
        }

        public event Action<IEnumerable<ThongTinTaiKhoan>> TimThayKetQua;

        public IEnumerable<ThongTinTaiKhoan> TimKiemAsync(ThongTinTimKiem param)
        {
            throw new NotImplementedException();
        }
    }
}
