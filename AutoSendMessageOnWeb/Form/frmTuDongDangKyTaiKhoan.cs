using AutoSendMessageOnWeb.Controls;
using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ThaoTacControl;
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

        public frmTuDongDangKyTaiKhoan(TrangWeb trang)
        {
            InitializeComponent();
            switch(trang)
            {
                case TrangWeb.HenHo2:
                    _tuDongDanhKy = new TuDongDangKyHenHo2();
                    break;
                case TrangWeb.DuyenSo:
                    _tuDongDanhKy = new TuDongDangKyDuyenSo();
                    break;
            }
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

        private void btnTaiCaptcha_Click(object sender, EventArgs e)
        {
            btnTaiCaptcha.Enabled = false;
            txtEmail.Enabled = false;
            btnTienHanhDangKy.Enabled = true;
            int dem = 0;
            foreach (string email in txtEmail.Lines)
                if (!string.IsNullOrEmpty(email))
                    this.TaoControlDangKy(email, dem++);
        }

        private async void TaoControlDangKy(string email, object tag)
        {
            cTuDongDangKy c = new cTuDongDangKy();
            await c.Init(email, _tuDongDanhKy);//Tùy trang sẽ khởi tạo khác nhau
            c.Dock = DockStyle.Top;
            c.Padding = new Padding(0, 0, 0, 5);
            panCaptcha.Controls.Add(c);
            c.BringToFront();
            c.Tag = tag;//tag phục vụ sắp xếp
        }

        int _delayHienTai = 1;
        private int GetDelay()
        {
            string delay = "5";//Mặc định
            foreach (Control c in grbDelay.Controls)
                if (c.Name == $"txttThoiGian{_delayHienTai}")
                        delay = c.Text;
            _delayHienTai++;
            if (_delayHienTai > 5)
                _delayHienTai = 1;
            return Convert.ToInt32(delay) * (1000);// * 60);
        }

        private async void btnTienHanhDangKy_Click(object sender, EventArgs e)
        {
            int delay = GetDelay();
            foreach (Control c in panCaptcha.Controls.Cast<Control>().OrderBy(p => p.Tag))
            {
                var cDangKy = c as cTuDongDangKy;
                if (cDangKy != null && cDangKy.TaiKhoanDaDangKy.TaiKhoan == null)//Chưa đăng ký
                {
                    c.Select();
                    c.Focus();
                    await cDangKy.DangKyAsync();
                    if (cDangKy.TaiKhoanDaDangKy.TaiKhoan != null)
                        this.DanhSachTaiKhoanDaDangKy.Add(cDangKy.TaiKhoanDaDangKy);
                    await Task.Delay(delay);
                }
            }
        }
    }
}
