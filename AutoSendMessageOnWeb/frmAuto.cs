using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using AutoSendMessageOnWeb.Lib.ThaoTacControl;
using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
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
    public partial class frmAuto : Form
    {
        private IThaoTacWeb _thaoTacWeb;
        private TrangWeb _trang;
        DatabaseManager _db;

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

        public frmAuto(TrangWeb trang)
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1.lblFormText, this.Handle);

            _trang = trang;
            _db = new DatabaseManager(trang);

            thongTinTaiKhoan_GuiBindingSource.DataSource = _db.DanhSachNguoiGui;
            thongTinTaiKhoan_NhanBindingSource.DataSource = _db.DanhSachNguoiNhan;

            switch (trang)
            {
                case TrangWeb.HenHo2:
                    _thaoTacWeb = new HenHo2();
                    this.Text = string.Format("Cấu hình gửi tin {0}", "http://henho2.com/");
                    break;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            thongTinTaiKhoan_NhanBindingSource.DataSource = _thaoTacWeb.TimKiemBangWebbrowser(_db.DanhSachNguoiNhan);
            //_db.DanhSachNguoiNhan.Add(new ThongTinTaiKhoan());
            thongTinTaiKhoan_NhanBindingSource.EndEdit();
            grvNhan.Update();
            grvNhan.Refresh();
        }

        private void dataGridViewFlat1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                thongTinTaiKhoan_NhanBindingSource.RemoveCurrent();
        }

        private async void btnGuiTin_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                btnGuiTin.Enabled = false;
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                thongTinTaiKhoan_NhanBindingSource.EndEdit();

                #region Đăng nhập
                foreach (ThongTinTaiKhoan tk in thongTinTaiKhoan_GuiBindingSource)
                {
                    if (tk.Cookie == null)
                    {
                        XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang đăng nhập {0}...", tk.TaiKhoan), Color.Black);
                        tk.DangNhap(_thaoTacWeb);
                    }
                }
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                grvGui.Refresh();
                #endregion

                #region Gửi
                var lstGui = (thongTinTaiKhoan_GuiBindingSource.List as IList<ThongTinTaiKhoan>).Where(p => p.ChoPhepGuiNhan && p.Cookie != null);
                var lstNhan = (thongTinTaiKhoan_NhanBindingSource.List as IList<ThongTinTaiKhoan>).Where(p => p.ChoPhepGuiNhan);

                int soNguoiGui = lstGui.Count();
                int soNguoiNhan = lstNhan.Count();

                if (soNguoiGui == 0)
                {
                    MessageBox.Show("Vui lòng thêm người gửi hoặc kiểm tra lại trạng thái đăng nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGuiTin.Enabled = true;
                    XuLyDaLuong.ChangeText(lblTrangThai, "Vui lòng kiểm tra lại thông tin người gửi", Color.Red);
                    return;
                }

                if (soNguoiNhan == 0)
                {
                    MessageBox.Show("Vui lòng thêm người nhận", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    XuLyDaLuong.ChangeText(lblTrangThai, "Vui lòng chọn người nhận", Color.Red);
                    btnGuiTin.Enabled = true;
                    return;
                }

                int index_NguoiGuiHienTai = 0;
                int index_NguoiNhanHienTai = 0;

                while (index_NguoiGuiHienTai < soNguoiGui && index_NguoiNhanHienTai < soNguoiNhan)
                {
                    ThongTinTaiKhoan nguoiGui = lstGui.ElementAt(index_NguoiGuiHienTai++);
                    for (int i = 0; i < GioiHanGuiThu.LayGioiHan(TrangWeb.HenHo2); i++)
                    {
                        ThongTinTaiKhoan nguoiNhan = lstNhan.ElementAt(index_NguoiNhanHienTai++);
                        thongTinTaiKhoan_NhanBindingSource.Position =  thongTinTaiKhoan_NhanBindingSource.IndexOf(nguoiNhan);
                        XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang gửi {0}...", nguoiNhan.TenHienThi), Color.Black);

                        _thaoTacWeb.GuiTin(nguoiGui, nguoiNhan, txtTieuDe.Text, txtNoiDung.Text);
                        nguoiNhan.TrangThai = "Đã gửi";

                        thongTinTaiKhoan_NhanBindingSource.EndEdit();
                        grvNhan.Refresh();

                        if (index_NguoiNhanHienTai >= soNguoiNhan)
                            break;
                    }
                }
                #endregion

                XuLyDaLuong.ChangeText(lblTrangThai, "Hoàn tất gửi tin", Color.Black);
                btnGuiTin.Enabled = true;
            });
        }

        private void btnLuuDanhSach_Click(object sender, EventArgs e)
        {
            if (_db.SaveChange())
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
