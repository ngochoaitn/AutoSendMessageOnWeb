using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThaoTacTrenForum.Data;
using Fizzler.Systems.HtmlAgilityPack;
using ThaoTacTrenForum.Lib.ExtentionMethod;
using System.Net.Http;
using System.Diagnostics;

namespace ThaoTacTrenForum.Lib.ThaoTacWeb.GuiTinNhan
{
    public class GuiTinNhanWebTreTho : IGuiTinNhan
    {
        public bool TimKiemYeuCauCookie => false;

        public CookieContainer Cookie { get; set; }

        public async Task DangNhapAsync(ThongTinTaiKhoan tk)
        {
            string data = string.Join("&", new[]
            {
                "do=login",
                "vb_login_md5password=",
                "vb_login_md5password_utf=",
                "s=",
                "securitytoken=guest",
                $"vb_login_username={tk.TaiKhoan}",
                $"vb_login_password={tk.MatKhau}",
            });
            tk.Cookie = new CookieContainer();
            //var html2 = (await RequestToWeb.GETAsync(new Uri("https://www.webtretho.com/forum/login.php?do=login"), false, true, tk.Cookie)).ReadStream();
            var response = await RequestToWeb.POSTAsync(new Uri("https://www.webtretho.com/forum/login.php?do=login"), tk.Cookie, data, false);
            //var response = RequestToWeb.POST(new Uri("https://www.webtretho.com/forum/login.php?do=login"), tk.Cookie, data, false);
            var httpRes = response as HttpWebResponse;
            string html = response.ReadStream();
            if (!html?.Contains("Bạn đã cố gắng đăng nhập hết") ?? true)
            {
                var test = tk.Cookie.GetAllCookies();
                string setCookie = httpRes.Headers[HttpResponseHeader.SetCookie];
                Debug.WriteLine(setCookie);
                //tk.Cookie = new CookieContainer();
                //tk.Cookie.SetCookies(UriTrangWeb.WEBTRETHO, setCookie);
                tk.TrangThai = "Đăng nhập thành công";
            }
            else
            {
                tk.TrangThai = "Đăng nhập thất bại";
                tk.Cookie = null;
            }

            httpRes.Close();
            httpRes.Dispose();

            response.Close();
            response.Dispose();
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> callback = null)
        {
            if (nguoigui.Cookie == null)
                throw new Exception("Thiếu cookie");

            var htmlGet = RequestToWeb.GET(new Uri("https://www.webtretho.com/forum/private.php?do=newpm"), false, true, nguoigui.Cookie).ReadStream();
            string securitytoken = htmlGet.Substring("SECURITYTOKEN = \"", "\";");

            string data = string.Join("&", new[]
            {
                $"recipients={nguoinhan.TaiKhoan}",
                "bccrecipients=",
                $"title={tieude}",
                $"message_backup={noidung}",
                $"message={noidung}",
                "wysiwyg=0",
                "iconid=0",
                "s=",
                $"securitytoken={securitytoken}",
                "do=insertpm",
                "pmid=",
                "forward=",
                "sbutton=Gửi tin nhắn",
                "savecopy=1 ",
                "parseurl=1",
            });

            var response = RequestToWeb.POST(new Uri("https://www.webtretho.com/forum/private.php?do=insertpm&pmid="), nguoigui.Cookie, data, false, true).ReadStream();
        }

        public DanhSachDuLieuTimKiem TaoDuLieuTimKiem()
        {
            DanhSachDuLieuTimKiem res = new DanhSachDuLieuTimKiem();

            res.DanhSachChuyenMuc.Add(new ChuyenMuc() { IdChuyenMuc = "f78", TenChuyenMuc = "Hội độc thân - Giao lưu - Kết bạn", UrlChuyenMuc = "https://www.webtretho.com/forum/f78/" });

            return res;
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            HtmlDocument doc = new HtmlDocument();
            foreach (var cm in param.ChuyenMucs)
            {
                string url = $"{cm.UrlChuyenMuc}?sort=dateline&order=desc";
                string html = RequestToWeb.GET(new Uri(url), false, true, this.Cookie).ReadStream();
                doc.LoadHtml(html);
                var threads = doc.GetElementbyId("threads").QuerySelectorAll("li");
                foreach(var thread in threads)
                {
                    var ctn_auTypPost = thread.QuerySelectorAll("div > div > div > ul > li");
                    if (ctn_auTypPost.Count() > 2)
                    {
                        var nameAuPost = ctn_auTypPost.ElementAt(0);// thread.QuerySelector("div > div > div > ul > li");
                        if (nameAuPost != null)
                        {
                            yield return new ThongTinTaiKhoan()
                            {
                                Id = nameAuPost.InnerHtml.Substring("?u=", "')"),
                                TaiKhoan = nameAuPost       .InnerText,
                            };

                            if (param.TimNguoiMoiBinhLuan)
                            {
                                var newRplSub = ctn_auTypPost.ElementAt(1);
                                yield return new ThongTinTaiKhoan()
                                {
                                    Id = newRplSub.InnerHtml.Substring("?u=", "&amp"),
                                    TaiKhoan = newRplSub.QuerySelector("strong")?.InnerText,
                                };
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            throw new NotImplementedException();
        }
    }
}
