using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ThaoTacWeb.DangKy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuVienWinform.UI;

namespace AutoSendMessageOnWeb
{
    public partial class frmTuDongDangKyTaiKhoan : Form
    {
        ITuDongDangKy _tuDongDanhKy;
        private bool _allowResize = true;
        public List<ThongTinTaiKhoan> DanhSachTaiKhoanDaDangKy { private set; get; }

        public bool AllowResize
        {
            set
            {
                _allowResize = value;
            }
            get
            {
                return _allowResize;
            }
        }

        public frmTuDongDangKyTaiKhoan()
        {
            InitializeComponent();

            _tuDongDanhKy = new TuDongDangKyHenHo2();
            this.DanhSachTaiKhoanDaDangKy = new List<ThongTinTaiKhoan>();

            #region Tùy chỉnh các thông số
            //Di chuyển form khi mà di chuyển các điểu khiển sau
            ControlPlus.MovieFormWhenMouseDownControl(topPanel, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(formNameLabel, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(bottomPanel, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(statusLabel, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(infoLabel, this.Handle);
            //flatStyle1 = new Controls.FlatStyle(this);
            //flatStyle1.Style = Style.Dark;
            //Cho phép thay đổi kích thước form khi di chuột vào góc form
            this.AllowResize = true;
            this.Text = formNameLabel.Text;
            #endregion
        }

        /// <summary>
        /// Di chuyển form khi di chuột vào góc form
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (this.AllowResize)
            {
                const int wmNcHitTest = 0x84;
                const int htBottomLeft = 16;
                const int htBottomRight = 17;
                if (m.Msg == wmNcHitTest)
                {
                    int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                    int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                    Point pt = PointToClient(new Point(x, y));
                    Size clientSize = ClientSize;
                    if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                    {
                        m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                        return;
                    }
                }
            }
            base.WndProc(ref m);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            _hangHienTai = 0;
            picCaptcha.Image = _tuDongDanhKy.Captcha();
        }

        int _hangHienTai=0;
        private void btnXacNhanCaptcha_Click(object sender, EventArgs e)
        {
            if (_hangHienTai < txtEmail.Lines.Count())
            {
                string email = txtEmail.Lines.ElementAt(_hangHienTai);
                var tkMoi = _tuDongDanhKy.DangKyTaiKhoanMoi(email, email, () => txtKetQuaCaptcha.Text);
                if(tkMoi.TaiKhoan != null)
                {
                    DanhSachTaiKhoanDaDangKy.Add(tkMoi);
                    lblTrangThai.Text = $"Đăng ký thành công {email}";
                    _hangHienTai++;
                }
                else
                {
                    lblTrangThai.Text = tkMoi.TrangThai;
                }
                picCaptcha.Image = _tuDongDanhKy.Captcha();
            }
            else
            {
                MessageBox.Show("Hết Email, vui lòng bắt đầu lại");
                lblTrangThai.Text = "Hết Email, vui lòng bắt đầu lại";
            }
        }

        private void picCaptcha_Click(object sender, EventArgs e)
        {
            picCaptcha.Image = _tuDongDanhKy.Captcha();
        }
    }
}
