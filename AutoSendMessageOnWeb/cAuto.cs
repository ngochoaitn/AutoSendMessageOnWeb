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
    public partial class cAuto : UserControl
    {
        private IThaoTacWeb _thaoTacWeb;
        private TrangWeb _trang;
        DatabaseManager _db;


        public cAuto()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        public void CaiDatTrang(TrangWeb trang)
        {
            _trang = trang;
            _db = new DatabaseManager(trang);

            thongTinTaiKhoan_GuiBindingSource.DataSource = _db.DanhSachNguoiGui;
            thongTinTaiKhoan_NhanBindingSource.DataSource = _db.DanhSachNguoiNhan;
            lblSoLuongKetQua.Text = string.Format("Số lượng kết quả: {0}", thongTinTaiKhoan_NhanBindingSource.Count);

            switch (trang)
            {
                case TrangWeb.HenHo2:
                    _thaoTacWeb = new HenHo2();
                    break;
                case TrangWeb.DuyenSo:
                    _thaoTacWeb = new DuyenSo();
                    lblTieuDe.Visible = txtTieuDe.Visible = false;

                    lblNoiDung.Location = lblTieuDe.Location;
                    txtNoiDung.Location = txtTieuDe.Location;
                    txtNoiDung.Height += 50;
                    break;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (btnTimKiem.Text == "Tìm kiếm")
            {
                frmTimKiem tkiem = new frmTimKiem(_thaoTacWeb);
                if (tkiem.ShowDialog() == DialogResult.OK)
                {
                    thongTinTaiKhoan_NhanBindingSource.Clear();
                    btnTimKiem.Text = "Dừng";
                    btnTimKiem.BackColor = Color.Red;
                    lblSoLuongKetQua.Text = "Số lượng kết quả: 0";

                    backgroundWorkerTimKiem.RunWorkerAsync(tkiem.ParamTimKiem);
                }
            }
            else
            {
                backgroundWorkerTimKiem.CancelAsync();
                backgroundWorkerTimKiem_RunWorkerCompleted(backgroundWorkerTimKiem, null);
            }
        }

        BindingList<ThongTinTaiKhoan> _danhSach = new BindingList<ThongTinTaiKhoan>();

        private void backgroundWorkerTimKiem_DoWork(object sender, DoWorkEventArgs e)
        {
            int dem = 0;
            _danhSach = new BindingList<ThongTinTaiKhoan>();
            XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đang nhận dữ liệu...", Color.Red);
            foreach (var kq in _thaoTacWeb.TimKiem(e.Argument as ThongTinTimKiem))
            {
                if (backgroundWorkerTimKiem.CancellationPending)
                    break;

                _danhSach.Add(kq);
                XuLyDaLuong.ChangeText(lblSoLuongKetQua,
                            string.Format("Số lượng kết quả: {0}", ++dem), Color.Black);
            }
            e.Result = _danhSach;
            XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Hoàn tất tìm kiếm", Color.Green);
        }

        private void backgroundWorkerTimKiem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            thongTinTaiKhoan_NhanBindingSource.DataSource = _danhSach;
            btnTimKiem.Text = "Tìm kiếm";
            lblSoLuongKetQua.Text = "Số lượng kết quả: " + thongTinTaiKhoan_NhanBindingSource.Count.ToString();
            btnTimKiem.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void grvGui_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //    if (thongTinTaiKhoan_GuiBindingSource.Count != 0)
            //        thongTinTaiKhoan_GuiBindingSource.RemoveCurrent();
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
                    //if (tk.Cookie == null)
                    //{
                        XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang đăng nhập {0}...", tk.TaiKhoan), Color.Black);
                        tk.DangNhap(_thaoTacWeb);
                    //}
                }
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                grvGui.Refresh();
                #endregion

                #region Gửi
                var lstGui = (thongTinTaiKhoan_GuiBindingSource.List as IList<ThongTinTaiKhoan>).Where(p => p.Cookie != null);
                var lstNhan = (thongTinTaiKhoan_NhanBindingSource.List as IList<ThongTinTaiKhoan>);//.Where(p => string.IsNullOrEmpty(p.TrangThai));

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
                    for (int i = 0; i < nguoiGui.SoThuSeGui; i++)
                    {
                        ThongTinTaiKhoan nguoiNhan = lstNhan.ElementAt(index_NguoiNhanHienTai++);
                        if (string.IsNullOrEmpty(nguoiNhan.TrangThai))
                        {
                            thongTinTaiKhoan_NhanBindingSource.Position = thongTinTaiKhoan_NhanBindingSource.IndexOf(nguoiNhan);
                            XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang gửi {0}...", nguoiNhan.TenHienThi), Color.Black);

                            _thaoTacWeb.GuiTin(nguoiGui, nguoiNhan, txtTieuDe.Text, txtNoiDung.Text);

                            thongTinTaiKhoan_NhanBindingSource.EndEdit();
                            grvNhan.Refresh();

                        }
                        else
                        {
                            i--;
                        }
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
            _db.DanhSachNguoiGui = thongTinTaiKhoan_GuiBindingSource.List as BindingList<ThongTinTaiKhoan>;
            _db.DanhSachNguoiNhan = thongTinTaiKhoan_NhanBindingSource.List as BindingList<ThongTinTaiKhoan>;
            if (_db.SaveChange())
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thongTinTaiKhoan_NhanBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            XuLyDaLuong.ChangeText(lblSoLuongKetQua,
                            string.Format("Số lượng kết quả: {0}", thongTinTaiKhoan_NhanBindingSource.Count), Color.Black);
        }

        private void thongTinTaiKhoan_GuiBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            //if (thongTinTaiKhoan_GuiBindingSource.Count == 0)
            //    thongTinTaiKhoan_GuiBindingSource.Position = thongTinTaiKhoan_GuiBindingSource.Add(new ThongTinTaiKhoan());
        }

        private void grvGui_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ThongTinTaiKhoan tk = thongTinTaiKhoan_GuiBindingSource.Current as ThongTinTaiKhoan;
            if (tk != null)
            {
                tk.Cookie = null;
                tk.TrangThai = "";
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                grvGui.Refresh();
            }
        }
    }
}
