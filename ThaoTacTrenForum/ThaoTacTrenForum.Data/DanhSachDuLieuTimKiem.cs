using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThaoTacTrenForum.Data
{
    [Serializable]
    public class DanhSachDuLieuTimKiem
    {
        public DanhSachDuLieuTimKiem()
        {
            this.DanhSachChuyenMuc = new List<ChuyenMuc>();
        }

        public List<ChuyenMuc> DanhSachChuyenMuc { get; set; }
    }
}
