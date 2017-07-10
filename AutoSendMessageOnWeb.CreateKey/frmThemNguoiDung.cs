using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using AutoSendMessageOnWeb.Lib.ThaoTacControl;
using System;
using System.Drawing;
using System.Windows.Forms;
using ThuVienWinform.UI;

namespace AutoSendMessageOnWeb.CreateKey
{
    public partial class frmThemNguoiDung : Form
    {
        public ThongTinNguoiDung NguoiDung { private set; get; }
        public frmThemNguoiDung()
        {
            InitializeComponent();

            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1.lblFormText, this.Handle);

            this.NguoiDung = new ThongTinNguoiDung();
        }

        private void txtMaNguoiDung_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.NguoiDung = new ThongTinNguoiDung();
                this.NguoiDung.LayThongTin(txtMaNguoiDung.Text);

                lblMAC.Text = "MAC: " + this.NguoiDung.MAC;

                lblTenMay.Text = "Tên máy: " + this.NguoiDung.TenMay;

                btnXacNhan.Enabled = true;

                XuLyDaLuong.ChangeText(lblTrangThai, "Ấn xác nhận để thêm người dùng", Color.Green);
            }
            catch
            {
                btnXacNhan.Enabled = false;
                this.NguoiDung = null;
                XuLyDaLuong.ChangeText(lblTrangThai, "Không đúng mã", Color.Red);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
