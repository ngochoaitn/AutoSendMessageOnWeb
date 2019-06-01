using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThaoTacTrenForum.Data
{
    public class ThongTinTimKiem
    {
        public List<ChuyenMuc> ChuyenMucs { get; set; } = new List<ChuyenMuc>();
        public bool TimNguoiMoiBinhLuan { get; set; }
        public bool DungTimKiem { get; set; } = false;
    }
}
