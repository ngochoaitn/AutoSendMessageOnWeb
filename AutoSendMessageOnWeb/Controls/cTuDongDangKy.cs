using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoSendMessageOnWeb.Lib.ThaoTacWeb.DangKy;
using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ThaoTacControl;

namespace AutoSendMessageOnWeb.Controls
{
    public partial class cTuDongDangKy : UserControl
    {
        public ITuDongDangKy TuDongDangKy { set; get; }
        public ThongTinTaiKhoan TaiKhoanDaDangKy { private set; get; }
        public string Email { private set; get; }
        public string HoTen { private set; get; }
        List<Tuple<string, string>> _gioiTinh = new List<Tuple<string, string>>();

        public cTuDongDangKy()
        {
            InitializeComponent();
            this.TaiKhoanDaDangKy = new ThongTinTaiKhoan()
            {
                TaiKhoan = null,
                TrangThai = "Chưa đăng ký"
            };
        }

        public async Task Init(string email, string ho_ten, TrangWeb trang_web, List<Tuple<string, string>> gioi_tinh, int selected_gioi_tinh)
        {
            switch(trang_web)
            {
                case TrangWeb.HenHo2:
                    this.TuDongDangKy = new TuDongDangKyHenHo2();
                    break;
                case TrangWeb.DuyenSo:
                    this.TuDongDangKy = new TuDongDangKyDuyenSo();
                    break;
            }
            _gioiTinh = gioi_tinh;
            picCaptcha.Image = await TuDongDangKy.CaptchaAsync();
            this.Email = email;
            this.HoTen = ho_ten;
            lblTaiKhoan.Text = $"{email} - {ho_ten}";
            XuLyDaLuong.ChangeText(lblTrangThai, "Chờ nhập captcha", Color.Blue);
            if(_gioiTinh != null)
            {
                foreach(var gt in _gioiTinh)
                    cbbGioiTinh.Items.Add(gt.Item1);
            }
            cbbGioiTinh.SelectedIndex = selected_gioi_tinh;
        }

        public async Task DangKyAsync()
        {
            if (!string.IsNullOrEmpty(txtKetQuaCaptcha.Text))
            {
                string gioiTinh = _gioiTinh?.FirstOrDefault(p => p.Item1 == cbbGioiTinh.Text)?.Item2;
                this.TaiKhoanDaDangKy = await this.TuDongDangKy.DangKyTaiKhoanMoiAsync(this.Email, this.Email, this.HoTen, () => txtKetQuaCaptcha.Text, new ThongTinBoSung() { GioiTinh = gioiTinh });

                if (this.TaiKhoanDaDangKy.TaiKhoan != null)
                {
                    XuLyDaLuong.ChangeText(lblTrangThai, $"Đăng ký thành công {this.Email}", Color.Green);
                    this.Enabled = false;
                }
                else
                {
                    XuLyDaLuong.ChangeText(lblTrangThai, this.TaiKhoanDaDangKy.TrangThai, Color.Red);
                    if (this.TaiKhoanDaDangKy.TrangThai == "Sai captcha")
                        picCaptcha.Image = await TuDongDangKy.CaptchaAsync();
                }
            }
            else
                XuLyDaLuong.ChangeText(lblTrangThai, "Chưa nhập captcha", Color.Red);
        }

        private async void picCaptcha_Click(object sender, EventArgs e)
        {
            picCaptcha.Image = null;
            picCaptcha.Image = await this.TuDongDangKy.CaptchaAsync();
        }

        private void txtKetQuaCaptcha_TextChanged(object sender, EventArgs e)
        {
            XuLyDaLuong.ChangeText(lblTrangThai, "Chờ đăng ký", Color.Blue);
        }
    }
}
