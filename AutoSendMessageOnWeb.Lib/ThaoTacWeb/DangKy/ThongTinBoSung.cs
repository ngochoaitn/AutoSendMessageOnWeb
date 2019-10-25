using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb.DangKy
{
    public class ThongTinBoSung
    {
        public string GioiTinh { set; get; }

        private static List<string> _ho = new List<string>() {"Nguyễn", "Hoàng", "Trịnh", "Mã", "Đỗ", "Hồ", "Vũ", "Lục", "Bế", "Văn", "Trần", "Lý", "Phan", "Nông", "Dương", "Đặng", "Diêm", "Ngô", "Mai", "An", "Hà"};
        private static List<string> _tenDem = new List<string>() {"", "Ngọc", "Thanh", "Hồng", "Xuân", "Mai", "Đăng", "Việt", "Đình", "Diệu", "Thanh", "Hồng", "Ngọc Mai", "Diệu", "Ngọc"};
        private static List<string> _ten = new List<string>() {"Bưởi", "Chi", "Diễm", "Diên", "Dung", "Đức", "Nghĩa", "Hưng", "Thanh", "Mai", "Hùng", "Hoàng", "Tú", "Kiên", "Nga", "Việt", "Huấn", "Huy", "Giỏi", "Anh", "Ánh", "Dũng", "Quyền", "Phú", "Nhận", "Cường", "An",  "Linh", "Ly", "Thủy", "Hải", "Diễm", "Trang", "Khánh", "Hà"};
        private static Random rand = new Random();
        public static string TaoHoTenNgauNhien()
        {
            //return await Task.Run(() =>
            //{
            //    int delay = 5;
                //Random rand = new Random();
                int iHo = rand.Next(0, _ho.Count);
               // await Task.Delay(delay);

                int iTenDem = rand.Next(0, _tenDem.Count);
                //await Task.Delay(delay);

                int iTen = rand.Next(0, _ten.Count);
                return $"{_ho[iHo]} {_tenDem[iTenDem]} {_ten[iTen]}".Replace("  ", " ");
            //});
        }        
    }
}
