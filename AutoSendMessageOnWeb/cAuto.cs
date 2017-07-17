using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using AutoSendMessageOnWeb.Lib.ThaoTacControl;
using AutoSendMessageOnWeb.Lib.ThaoTacWeb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void AnTieuDe()
        {
            lblTieuDe.Visible = txtTieuDe.Visible = false;

            lblNoiDung.Location = lblTieuDe.Location;
            txtNoiDung.Location = txtTieuDe.Location;
            txtNoiDung.Height += 50;
        }

        public void CaiDatTrang(TrangWeb trang)
        {
            _trang = trang;
            _db = new DatabaseManager(trang);

            Program.XayRaLoi += Program_XayRaLoi;

            thongTinTaiKhoan_GuiBindingSource.DataSource = _db.DanhSachNguoiGui;
            thongTinTaiKhoan_TimKiemBindingSource.DataSource = _db.DanhSachNguoiNhan;
            grbTimKiem.Text = _db.PhienTimKiem;

            lblSoLuongKetQua.Text = string.Format("Số lượng kết quả: {0}", thongTinTaiKhoan_TimKiemBindingSource.Count);

            switch (trang)
            {
                case TrangWeb.HenHo2:
                    _thaoTacWeb = new HenHo2();
                    break;
                case TrangWeb.DuyenSo:
                    _thaoTacWeb = new DuyenSo();
                    this.AnTieuDe();
                    break;
                case TrangWeb.VietNamCupid:
                    _thaoTacWeb = new VietNamCupid();

                    List<string> tieuDe = new List<string>() { "default_1  (Xin chào!)",
                                                               "default_2  (Tôi thích hồ sơ bạn)",
                                                               "default_3  (Hình thật đẹp!)",
                                                               "default_4  (Tôi quan tâm đến bạn)",
                                                               "default_5  (Tôi ấn tượng về bạn)",
                                                               "default_6  (Bạn thật dễ thương)",
                                                               "default_7  (Yêu từ cái nhìn đầu tiên)",
                                                               "default_8  (Chúng ta là bộ đôi hoàn hảo)",
                                                               "default_9  (Hãy nhận liên lạc của tôi)",
                                                               "default_10 (Tìm kiếm hôn nhân)" };

                    AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
                    allowedTypes.AddRange(tieuDe.ToArray());
                    txtTieuDe.AutoCompleteCustomSource = allowedTypes;
                    txtTieuDe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtTieuDe.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    txtTieuDe.Text = "default_9  (Hãy nhận liên lạc của tôi)";

                    break;
                case TrangWeb.LikeYou:
                    _thaoTacWeb = new LikeYou();
                    this.AnTieuDe();
                    break;
                case TrangWeb.HenHoKetBan:
                    _thaoTacWeb = new HenHoKetBan();
                    break;
            }
        }

        private void Program_XayRaLoi()
        {
            _db.SaveChange();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (btnTimKiem.Text == "Tìm kiếm (F3)")
            {
                #region Lấy cookie nếu trang yêu cầu
                if (_thaoTacWeb.TimKiemYeuCauCookie)
                {
                    if(thongTinTaiKhoan_GuiBindingSource.Count > 0)
                    {
                        ThongTinTaiKhoan tkTimKiem = thongTinTaiKhoan_GuiBindingSource[0] as ThongTinTaiKhoan;
                        if (tkTimKiem.YeuCauDangNhapMoi)
                        {
                            XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, string.Format("Đang nhập {0}...", tkTimKiem.TaiKhoan), Color.Red);
                            tkTimKiem.DangNhap(_thaoTacWeb);
                            if(tkTimKiem.Cookie != null)
                                XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đăng nhập thành công", Color.Blue);
                            else
                                XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đăng nhập thất bại", Color.Red);
                        }
                        _thaoTacWeb.Cookie = tkTimKiem.Cookie;
                        thongTinTaiKhoan_GuiBindingSource.EndEdit();
                        grvGui.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Trang web yêu cầu đăng nhập để tìm kiếm!\nVui lòng thêm tài khoản trước");
                        return;
                    }
                    if(_thaoTacWeb.Cookie == null)
                    {
                        MessageBox.Show("Kiểm tra lại thông tin đăng nhập!");
                        return;
                    }
                }
                #endregion

                frmTimKiem tkiem = new frmTimKiem(_thaoTacWeb);
                if (tkiem.ShowDialog() == DialogResult.OK)
                {
                    thongTinTaiKhoan_TimKiemBindingSource.Clear();
                    btnTimKiem.Text = "Dừng";
                    btnTimKiem.BackColor = Color.Red;
                    lblSoLuongKetQua.Text = "Số lượng kết quả: 0";
                    grbTimKiem.Text = tkiem.ChuoiTimKiem;

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
            thongTinTaiKhoan_TimKiemBindingSource.DataSource = _danhSach;
            btnTimKiem.Text = "Tìm kiếm (F3)";
            lblSoLuongKetQua.Text = "Số lượng kết quả: " + thongTinTaiKhoan_TimKiemBindingSource.Count.ToString();
            btnTimKiem.BackColor = Color.FromArgb(255, 255, 128);
        }

        private async void btnGuiTin_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                btnGuiTin.Enabled = false;
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                thongTinTaiKhoan_TimKiemBindingSource.EndEdit();

                #region Đăng nhập
                foreach (ThongTinTaiKhoan tk in thongTinTaiKhoan_GuiBindingSource)
                {
                    if (!string.IsNullOrEmpty(tk.TaiKhoan) && tk.SoThuSeGui > 0)
                    {
                        XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang đăng nhập {0}...", tk.TaiKhoan), Color.Black);
                        tk.DangNhap(_thaoTacWeb);
                    }
                }
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                grvGui.Refresh();
                #endregion

                #region Gửi
                var lstGui = (thongTinTaiKhoan_GuiBindingSource.List as IList<ThongTinTaiKhoan>).Where(p => p.Cookie != null);
                var lstNhan = (thongTinTaiKhoan_TimKiemBindingSource.List as IList<ThongTinTaiKhoan>);//.Where(p => string.IsNullOrEmpty(p.TrangThai));

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
                int soThuSeGui = Math.Min(lstGui.Sum(p => p.SoThuSeGui), soNguoiNhan);
                int demGui = 1;
                while (index_NguoiGuiHienTai < soNguoiGui && index_NguoiNhanHienTai < soNguoiNhan)
                {
                    ThongTinTaiKhoan nguoiGui = lstGui.ElementAt(index_NguoiGuiHienTai++);
                    for (int i = 0; i < nguoiGui.SoThuSeGui; i++)
                    {
                        ThongTinTaiKhoan nguoiNhan = lstNhan.ElementAt(index_NguoiNhanHienTai++);
                        if (string.IsNullOrEmpty(nguoiNhan.TrangThai))
                        {
                            thongTinTaiKhoan_TimKiemBindingSource.Position = thongTinTaiKhoan_TimKiemBindingSource.IndexOf(nguoiNhan);
                            XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang gửi {0}/{1} {2}...", demGui++, soThuSeGui, nguoiNhan.TenHienThi), Color.Black);

                            _thaoTacWeb.GuiTin(nguoiGui, nguoiNhan, txtTieuDe.Text, txtNoiDung.Text);

                            thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
                            grvTimKiem.Refresh();
                        }
                        else
                        {
                            i--;
                        }
                        //Nếu hết người nhận thì thoát vòng lặp
                        if (index_NguoiNhanHienTai >= soNguoiNhan)
                            break;
                    }
                }
                #endregion

                XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Hoàn tất gửi tin ({0}/{1})", soThuSeGui, soThuSeGui), Color.Black);
                btnGuiTin.Enabled = true;
            });
        }

        private void btnLuuDanhSach_Click(object sender, EventArgs e)
        {
            _db.DanhSachNguoiGui = thongTinTaiKhoan_GuiBindingSource.List as BindingList<ThongTinTaiKhoan>;
            _db.DanhSachNguoiNhan = thongTinTaiKhoan_TimKiemBindingSource.List as BindingList<ThongTinTaiKhoan>;
            _db.PhienTimKiem = grbTimKiem.Text;
            if (_db.SaveChange())
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thongTinTaiKhoan_NhanBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            XuLyDaLuong.ChangeText(lblSoLuongKetQua,
                            string.Format("Số lượng kết quả: {0}", thongTinTaiKhoan_TimKiemBindingSource.Count), Color.Black);
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

        private void grvNhan_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ThongTinTaiKhoan tk = thongTinTaiKhoan_TimKiemBindingSource.Current as ThongTinTaiKhoan;
            Process.Start(tk.Url);
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            thongTinTaiKhoan_GuiBindingSource.Position = thongTinTaiKhoan_GuiBindingSource.Add(new ThongTinTaiKhoan());
            grvGui.Focus();
        }

        private void xóaToànBộLỗiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ThongTinTaiKhoan tk in thongTinTaiKhoan_TimKiemBindingSource)
            {
                if (!string.IsNullOrEmpty(tk.TrangThai) && tk.TrangThai.Contains("lỗi"))
                    tk.TrangThai = "";
            }
            thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
            grvTimKiem.Refresh();
        }

        private void xóaLỗiHàngĐangChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan tk = thongTinTaiKhoan_TimKiemBindingSource.Current as ThongTinTaiKhoan;
            if (tk != null && !string.IsNullOrEmpty(tk.TrangThai) && tk.TrangThai.Contains("lỗi"))
                tk.TrangThai = "";
            thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
            grbTimKiem.Refresh();
        }

        private void thongTinTaiKhoan_TimKiemBindingSource_PositionChanged(object sender, EventArgs e)
        {
            ThongTinTaiKhoan tk = thongTinTaiKhoan_TimKiemBindingSource.Current as ThongTinTaiKhoan;
            if (tk != null && !string.IsNullOrEmpty(tk.TrangThai) && tk.TrangThai.Contains("lỗi"))
                xóaLỗiHàngĐangChọnToolStripMenuItem.Enabled = true;
            else
                xóaLỗiHàngĐangChọnToolStripMenuItem.Enabled = false;
        }

        private void grvTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                xóaLỗiHàngĐangChọnToolStripMenuItem_Click(sender, e);
                thongTinTaiKhoan_TimKiemBindingSource.MoveNext();
            }
        }


        public void TaoTaiKhoanMoi()
        { btnThemTaiKhoan.PerformClick(); }
        public void LuuDulieu()
        { btnLuuDanhSach.PerformClick(); }
        public void TimKiem()
        { btnTimKiem.PerformClick(); }
    }
}
