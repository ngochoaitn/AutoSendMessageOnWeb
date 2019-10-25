using AutoSendMessageOnWeb.Data;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ThuVienWinform.UI;

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb
{
    /// <summary>
    /// Form cài đặt các giá trị tìm kiếm
    /// </summary>
    public partial class frmTimKiem : Form
    {
        protected override void WndProc(ref Message m)
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
            base.WndProc(ref m);
        }

        DanhSachDuLieuTimKiem _duLieuTimKiem;
        public ThongTinTimKiem ParamTimKiem { private set; get; }
        public string ChuoiTimKiem { private set; get; }
        IGuiTinNhan _guiTinNhan;

        public frmTimKiem(IGuiTinNhan gui_tin_nhan)
        {
            InitializeComponent();

            _guiTinNhan = gui_tin_nhan;

            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1.lblFormText, this.Handle);

            panTimKiemThoiGianDangNhap.DataBindings.Add("Enabled", chkTimNguoiMoiDangNhap, "Checked");

            _duLieuTimKiem = gui_tin_nhan.TaoDuLieuTimKiem();

            foreach (var noio in _duLieuTimKiem.NoiO)
                cbbNoiO.Items.Add(noio.Value);

            foreach (var tinhtrang in _duLieuTimKiem.TinhTrangHonNhan)
                cbbTinhTrangHonNhan.Items.Add(tinhtrang);

            foreach (var gtinh in _duLieuTimKiem.GioiTinh)
                cbbGioiTinh.Items.Add(gtinh.Value);

            cbbTinhTrangHonNhan.DisplayMember = "TenTinhTrang";

            cbbGioiTinh.SelectedIndex = 0;
            cbbNoiO.SelectedIndex = 0;
            cbbTinhTrangHonNhan.SetItemChecked(0, true);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Lấy thông tin
            var noiO = _duLieuTimKiem.NoiO.Where(p => p.Value == cbbNoiO.Text).FirstOrDefault();
            var gioiTinh = _duLieuTimKiem.GioiTinh.Where(p => p.Value == cbbGioiTinh.Text).FirstOrDefault();

            //Tạo thông tin tìm kiếm
            this.ParamTimKiem = new ThongTinTimKiem();

            this.ParamTimKiem.TuTuoi = (int)numTuTuoi.Value;
            this.ParamTimKiem.DenTuoi = (int)numDenTuoi.Value;

            this.ParamTimKiem.NoiO = noiO.Key;
            this.ParamTimKiem.GioiTinh = gioiTinh.Key;
            this.ParamTimKiem.OtherParam.Add(gioiTinh.Value);
            this.ParamTimKiem.OtherParam.Add(cbbTinhTrangHonNhan.Text);

            #region Thời gian đăng nhập
            if (chkTimNguoiMoiDangNhap.Checked)
                this.ParamTimKiem.ThoiGianDangNhap = Convert.ToInt32(txtThoiGianDangNhap.Text);
            else
                this.ParamTimKiem.ThoiGianDangNhap = null;

            this.ParamTimKiem.TimNguoiMoiDangKy = chkTimNguoiMoiDangKy.Checked;
            this.ParamTimKiem.TimNguoiOnline = chkDangOnline.Checked;
            #endregion

            foreach (var sl in cbbTinhTrangHonNhan.CheckedItems)
            {
                var tinhTrang = _duLieuTimKiem.TinhTrangHonNhan.Where(p => p.TenTinhTrang == sl.ToString()).FirstOrDefault();
                this.ParamTimKiem.HonNhan.Add(sl as ThongTinTimKiem.TinhTrangHonNhan);
            }

            this.DialogResult = DialogResult.OK;
            this.ChuoiTimKiem = string.Format("Tuối: {0} - {1} | Giới tính: {2} | Nơi ở: {3} | Hôn nhân: {4}", this.ParamTimKiem.TuTuoi,
                                              this.ParamTimKiem.DenTuoi, cbbGioiTinh.Text, cbbNoiO.Text, cbbTinhTrangHonNhan.Text);
            this.Close();
        }

        private void chkTimNguoiMoiDangNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimNguoiMoiDangNhap.Checked)
            {
                if (!(_guiTinNhan is HenHo2 || _guiTinNhan is HenHoKetBan || _guiTinNhan is VietNamCupid || _guiTinNhan is ehenho))
                {
                    MessageBox.Show("Chức năng này chỉ hỗ trợ HenHo2, HenHoKetBan, VietNamCupid, ehenho");
                    chkTimNguoiMoiDangNhap.Checked = false;
                }
            }
        }

        private void chkTimNguoiMoiDangKy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimNguoiMoiDangKy.Checked)
            {
                if (!( _guiTinNhan is DuyenSo))
                {
                    MessageBox.Show("Chức năng này chỉ hỗ trợ DuyenSo");
                    chkTimNguoiMoiDangKy.Checked = false;
                }
                chkDangOnline.Checked = false;
            }
        }

        private void chkDangOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDangOnline.Checked)
            {
                if (!(_guiTinNhan is DuyenSo))
                {
                    MessageBox.Show("Chức năng này chỉ hỗ trợ DuyenSo");
                    chkDangOnline.Checked = false;
                }
                chkTimNguoiMoiDangKy.Checked = false;
            }
        }
    }
}
