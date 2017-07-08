using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Data
{
    public class ThongTinTimKiem
    {
        
        public int TuTuoi { set; get; }
        public int DenTuoi { set; get; }
        public object NoiO { set; get; }
        public List<TinhTrangHonNhan> HonNhan { set; get; }

        public ThongTinTimKiem()
        {
            this.HonNhan = new List<TinhTrangHonNhan>();
        }

        public class TinhTrangHonNhan
        {
            public string TenTinhTrang { set; get; }
            public object Id { set; get; }
        }
    }
}
