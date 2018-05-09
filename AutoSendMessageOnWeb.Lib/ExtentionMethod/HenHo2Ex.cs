using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Lib.ExtentionMethod
{
    public static class HenHo2Ex
    {
        public static void DangNhap(this ThongTinTaiKhoan tk, IGuiTinNhan thaotacweb)
        {
            thaotacweb.DangNhap(ref tk);
        }
    }
}
