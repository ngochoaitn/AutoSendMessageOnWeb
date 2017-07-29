using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSendMessageOnWeb.Data;
using HtmlAgilityPack;
using System.Web;
using System.IO;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using System.Net;
using Fizzler.Systems.HtmlAgilityPack;

namespace AutoSendMessageOnWeb.Lib
{
    public class DocThan : IThaoTacWeb
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
            throw new NotImplementedException();
        }

        public void GuiTin(ThongTinTaiKhoan nguoigui, ThongTinTaiKhoan nguoinhan, string tieude, string noidung, Action<string> callback=null)
        {
            throw new NotImplementedException();
        }

        public DanhSachDuLieuTimKiem TaoDuLieuTimKiem()
        {
            DanhSachDuLieuTimKiem res = new DanhSachDuLieuTimKiem();

            res.NoiO.Add(0, "Tất cả");
            List<string> tinhThanh = new List<string>()
            {"- - Tất cả - -", "An Giang", "Bắc Cạn", "Bắc Giang", "Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Dương", "Bình Định", "Bình Phước", "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Dak Nông", "Đà Nẵng", "Đắc Lắc", "Điện Biên", "Đồng Nai", "Đồng Tháp", "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tỉnh", "Hải Dương", "Hải Phòng", "Hậu Giang", "Hồ Chí Minh", "Hòa Bình", "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình", "Quảng Nam", "Quãng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên - Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang", "Vĩnh Long", "Vĩnh Phúc", "Vũng Tàu", "Yên Bái"};
            List<int> idTinhThanh = new List<int>()
            { 0, 312, 337, 338, 339, 340, 341, 342, 343, 344, 345, 346, 347, 348, 349, 350, 351, 352, 353, 354, 355, 356, 357, 358, 359, 360, 361, 362, 363, 364, 365, 366, 367, 368, 369, 370, 371, 372, 373, 374, 375, 376, 377, 378, 379, 380, 381, 382, 383, 384, 385, 386, 387, 388, 389, 390, 391, 392, 393, 394, 395, 396, 336, 397};

            for (int i = 0; i < tinhThanh.Count; i++)
                res.NoiO.Add(idTinhThanh[i], tinhThanh[i]);

            List<string> tinhTrang = new List<string>()
            {"- - Tất cả - -", "Đã có gia đình", "Đang có người yêu", "Đang ở góa", "Độc thân","Ly Dị","Ly thân" };
            List<int> idTinhTrang = new List<int>()
            { 0,3,2,4,1,6,5 };

            for (int i = 0; i < tinhTrang.Count; i++)
                res.TinhTrangHonNhan.Add(new ThongTinTimKiem.TinhTrangHonNhan() { Id = idTinhTrang[i], TenTinhTrang = tinhTrang[i] });

            
            List<string> gioiTinh = new List<string>()
            { "- - Tất cả - -", "Khác", "Nam", "Nữ"};
            List<int> idGioiTinh = new List<int>()
            { 0,4,1,2};

            for (int i = 0; i < gioiTinh.Count; i++)
                res.GioiTinh.Add(idGioiTinh[i], gioiTinh[i]);

            return res;
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiem(ThongTinTimKiem param)
        {
            foreach (var hn in param.HonNhan)
            {
                int page = 1;
                while (true)
                {
                    #region Tạo reqeuest
                    var uri = new UriBuilder("http://docthan.com/results.php");
                    var query = HttpUtility.ParseQueryString(uri.Query);

                    query["fg"] = param.GioiTinh.ToString();            //find gen
                    query["af"] = param.TuTuoi.ToString();              //age from
                    query["at"] = param.DenTuoi.ToString();             //age to
                    query["m"] = hn.Id.ToString();                      //Marital
                    query["c"] = "230";                                 //country, vietnam=230
                    query["st"] = param.NoiO.ToString();                //street??    
                    query["o"] = "0";                                   //?
                    query["t"] = "0";                                   //?type
                    if (page != 1)
                        query["p"] = page.ToString();                   //page

                    uri.Query = query.ToString();

                    HttpWebRequest request = WebRequest.CreateHttp(uri.Uri);
                    request.Method = "GET";

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
                        }
                        if (bangKetQua.Count() <= 0)
                            break;
                    }
                    #endregion

                    page++;
                }
            }
        }

        public IEnumerable<ThongTinTaiKhoan> TimKiemBangWebbrowser(IEnumerable<ThongTinTaiKhoan> binding)
        {
            throw new NotImplementedException();
        }
    }
}
