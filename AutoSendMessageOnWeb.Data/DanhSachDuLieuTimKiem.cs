using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Data
{
    [Serializable]
    public class DanhSachDuLieuTimKiem
    {
        public DanhSachDuLieuTimKiem()
        {
            this.NoiO = new Dictionary<object, string>();
            this.TinhTrangHonNhan = new List<ThongTinTimKiem.TinhTrangHonNhan>();
            this.GioiTinh = new Dictionary<object, string>();
        }
        //Ông ấy chỉ yêu cầu về Tuổi, Nơi ở và tình trạng hôn nhân
        public Dictionary<object, string> NoiO { set; get; }
        public List<ThongTinTimKiem.TinhTrangHonNhan> TinhTrangHonNhan { set; get; }
        public Dictionary<object, string> GioiTinh { set; get; }
    }
}
