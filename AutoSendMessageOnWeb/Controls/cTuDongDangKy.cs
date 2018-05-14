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

        public cTuDongDangKy()
        {
            InitializeComponent();
            this.TaiKhoanDaDangKy = new ThongTinTaiKhoan()
            {
                TaiKhoan = null,
                TrangThai = "Chưa đăng ký"
            };
        }

        public async Task Init(string email, ITuDongDangKy trang_web)
        {
            this.TuDongDangKy = trang_web;
            picCaptcha.Image = await TuDongDangKy.CaptchaAsync();
            lblTaiKhoan.Text = email;
            this.Email = email;
            XuLyDaLuong.ChangeText(lblTrangThai, "Chờ nhập captcha", Color.Blue);
        }

        public async Task DangKyAsync()
        {
            if (!string.IsNullOrEmpty(txtKetQuaCaptcha.Text))
            {
                this.TaiKhoanDaDangKy = await this.TuDongDangKy.DangKyTaiKhoanMoiAsync(this.Email, this.Email, () => txtKetQuaCaptcha.Text);

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
