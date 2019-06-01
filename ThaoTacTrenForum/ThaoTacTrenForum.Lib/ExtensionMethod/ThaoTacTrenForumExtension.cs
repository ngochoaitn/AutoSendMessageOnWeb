using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThaoTacTrenForum.Data;
using ThaoTacTrenForum.Lib.ThaoTacWeb.GuiTinNhan;

namespace ThaoTacTrenForum.Lib.ExtensionMethod
{
    public static class ThaoTacTrenForumExtension
    {
        public static async Task DangNhapAsync(this ThongTinTaiKhoan tk, IGuiTinNhan thaotacweb)
        {
            await thaotacweb.DangNhapAsync(tk);
        }
    }
}
