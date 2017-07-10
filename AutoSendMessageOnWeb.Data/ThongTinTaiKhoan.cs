using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoSendMessageOnWeb.Data
{
    [Serializable]
    public partial class ThongTinTaiKhoan
    {
        public string Id { set; get; }
        public string TaiKhoan { set; get; }
        public string MatKhau { set; get; }
        public string GioiTinh { set; get; }
        public string TenHienThi { set; get; }
        public string TrangThai { set; get; }
        [DefaultValue(true)]
        public bool ChoPhepGuiNhan { set; get; }

        public int SoThuSeGui
        {
            get
            {
                return _soThuSeGui;
            }

            set
            {
                _soThuSeGui = value;
            }
        }

        private int _soThuSeGui = 10;

        public string TinhTrangHonNhan { set; get; }
        public int? Tuoi { set; get; }
        public string NoiO { set; get; }



        public string Url { set; get; }

        public CookieContainer Cookie { set; get; }
    }
}
