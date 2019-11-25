using AutoSendMessageOnWeb.Controls;
using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
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
    public partial class frmTuDongDangKyTaiKhoan_HangLoat : Form
    {
        TrangWeb _trang;
        private bool _allowResize = true;
        private List<Tuple<string, string>> _gioiTinh;
        public ITuDongDangKy TuDongDangKy { set; get; }
        bool _dung = false;

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

        public frmTuDongDangKyTaiKhoan_HangLoat(TrangWeb trang)
        {
            InitializeComponent();
            _trang = trang;
            this.DanhSachTaiKhoanDaDangKy = new List<ThongTinTaiKhoan>();
            switch(trang)
            {
                case TrangWeb.eHenHo:
                    _gioiTinh = new List<Tuple<string, string>>() { new Tuple<string, string>("Nam", "male"),
                                                                    new Tuple<string, string>("Nữ", "female")};
                    this.TuDongDangKy = new TuDongDangKyEHenho();
                    break;
                case TrangWeb.HenHoKetBan:
                    _gioiTinh = new List<Tuple<string, string>>() { new Tuple<string, string>("Nam", "Nam"), new Tuple<string, string>("Nữ", "Nữ"),
                    new Tuple<string, string>("Less", "Less"),new Tuple<string, string>("Gay", "Gay")};
                    this.TuDongDangKy = new TuDongDangKyHenHoKetBan();
                    break;
                default:
                    throw new NotSupportedException("Chỉ hỗ trợ ehenho, henhoketban");
            }
            foreach (var gt in _gioiTinh)
                cbbGioiTinh.Items.Add(gt.Item1);
            cbbGioiTinh.SelectedIndex = 0;

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

        int _delayHienTai = 1;
        private int GetDelay()
        {
            string delay = "5";//Mặc định
            foreach (Control c in grbDelay.Controls)
                if (c.Name == $"txtThoiGian{_delayHienTai}")
                        delay = c.Text;
            _delayHienTai++;
            if (_delayHienTai > 5)
                _delayHienTai = 1;
            return Convert.ToInt32(delay) * (1000 * 60);
        }

        private async void btnTienHanhDangKy_Click(object sender, EventArgs e)
        {
            if (btnTienHanhDangKy.Text == "Tiến hành đăng ký")
            {
                _dung = false;
                btnTienHanhDangKy.Text = "Dừng";
                btnTienHanhDangKy.BackColor = Color.Red;
                int delay = GetDelay();

                while (true)
                {
                    if (_dung)
                        break;
                    string email = RandomEmail.GetRandomEmail();
                    string gioiTinh = _gioiTinh?.FirstOrDefault(p => p.Item1 == cbbGioiTinh.Text)?.Item2;
                    XuLyDaLuong.ChangeText(lblTrangThai, $"Đang đăng ký {email}...", Color.Blue);
                    var taiKhoanMoi = await this.TuDongDangKy.DangKyTaiKhoanMoiAsync(email, email, ThongTinBoSung.TaoHoTenNgauNhien(), () => "K cần", new ThongTinBoSung() { GioiTinh = gioiTinh });
                    if (taiKhoanMoi.TaiKhoan != null)
                    {
                        XuLyDaLuong.AppendText(txtDaDangKy, email + "\r\n");
                        this.DanhSachTaiKhoanDaDangKy.Add(taiKhoanMoi);
                        XuLyDaLuong.ChangeText(lblTrangThai, $"Đang đăng ký {email} thành công. Delay {delay/1000/60} phút", Color.Blue);
                    }
                    else
                    {
                        XuLyDaLuong.ChangeText(lblTrangThai, $"Đang đăng ký {email} {taiKhoanMoi.TrangThai}. Delay {delay / 1000 / 60} phút", Color.Red);
                    }
                   
                    await Task.Delay(delay);
                    if (_dung)
                        break;
                    delay = GetDelay();
                }
            }
            else
            {
                _dung = true;
                btnTienHanhDangKy.Text = "Tiến hành đăng ký";
                btnTienHanhDangKy.BackColor = Color.Aquamarine;
            }
        }
    }
}
