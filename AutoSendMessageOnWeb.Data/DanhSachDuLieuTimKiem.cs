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
            this.NoiO = new Dictionary<int, string>();
            this.TinhTrangHonNhan = new List<ThongTinTimKiem.TinhTrangHonNhan>();
        }
        //Ông ấy chỉ yêu cầu về Tuổi, Nơi ở và tình trạng hôn nhân
        public Dictionary<int, string> NoiO { set; get; }
        public List<ThongTinTimKiem.TinhTrangHonNhan> TinhTrangHonNhan { set; get; }
        
    }
}
