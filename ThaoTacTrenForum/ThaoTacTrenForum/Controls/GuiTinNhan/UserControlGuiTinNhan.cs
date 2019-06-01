using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThaoTacTrenForum.Data;
using ThaoTacTrenForum.Lib.ExtensionMethod;
using ThaoTacTrenForum.Lib.ThaoTacControl;
using ThaoTacTrenForum.Lib.ThaoTacWeb.GuiTinNhan;

namespace ThaoTacTrenForum.Controls.GuiTinNhan
{
    public partial class UserControlGuiTinNhan : DevExpress.XtraEditors.XtraUserControl
    {
        private IGuiTinNhan _guiTinNhan;
        private TrangWeb _trang;
        private DatabaseManager _db;
        private FormTimKiem tkiem = null;
        private CancellationTokenSource _guiTinNhanTokenResource, _timKiemTokenResource;
        private BindingList<ThongTinTaiKhoan> _danhSach = new BindingList<ThongTinTaiKhoan>();

        public UserControlGuiTinNhan()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void CaiDatTrang(TrangWeb trang)
        {
            _trang = trang;
            _db = new DatabaseManager(trang);
            for (int i = 0; i < _db.DanhSachNoiDung.Count; i++)
                this.ThemNoiDung(_db.DanhSachTieuDe[i], _db.DanhSachNoiDung[i]);
            if (_db.DanhSachNoiDung.Count == 0)
                this.ThemNoiDung();

            Program.XayRaLoi += Program_XayRaLoi;

            thongTinTaiKhoan_GuiBindingSource.DataSource = _db.DanhSachNguoiGui;
            thongTinTaiKhoan_TimKiemBindingSource.DataSource = _db.DanhSachNguoiNhan;
            grbTimKiem.Text = _db.PhienTimKiem;

            lblSoLuongKetQua.Text = string.Format("Số lượng kết quả: {0}", thongTinTaiKhoan_TimKiemBindingSource.Count);

            switch (trang)
            {
                case TrangWeb.WebTreTho:
                    _guiTinNhan = new GuiTinNhanWebTreTho();
                    break;
            }
        }

        private void Program_XayRaLoi()
        {
            _db.SaveChange();
        }

        private List<UserControlThongTinGui> DanhSachNoiDung()
        {
            var res = new List<UserControlThongTinGui>();
            foreach (Control c in panTopThongTinGui.Controls)
                if (c is UserControlThongTinGui)
                    res.Add(c as UserControlThongTinGui);
            return res.OrderBy(p => p.STT).ToList();
        }

        private void ThemNoiDung(string tieu_de = "Tiêu đề", string noi_dung = "Nội dung")
        {
            UserControlThongTinGui noiDungMoi = new UserControlThongTinGui(DanhSachNoiDung().Count + 1);

            noiDungMoi.Dock = DockStyle.Top;
            noiDungMoi.Height = 165;
            noiDungMoi.TieuDe = tieu_de;
            noiDungMoi.NoiDung = noi_dung;
            noiDungMoi.Dong += () =>
            {
                panTopThongTinGui.Controls.Remove(noiDungMoi);
                btnGuiTin.Enabled = panTopThongTinGui.Controls.Count != 0;
            };
            panTopThongTinGui.Controls.Add(noiDungMoi);
            btnGuiTin.Enabled = true;
            noiDungMoi.BringToFront();
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (btnTimKiem.Text == "Tìm kiếm (F3)")
            {
                #region Lấy cookie nếu trang yêu cầu
                if (_guiTinNhan.TimKiemYeuCauCookie)
                {
                    if (thongTinTaiKhoan_GuiBindingSource.Count > 0)
                    {
                        ThongTinTaiKhoan tkTimKiem = thongTinTaiKhoan_GuiBindingSource[0] as ThongTinTaiKhoan;
                        if (tkTimKiem.YeuCauDangNhapMoi)
                        {
                            XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, string.Format("Đang nhập {0}...", tkTimKiem.TaiKhoan), Color.Red);
                            await _guiTinNhan.DangNhapAsync(tkTimKiem);
                            if (tkTimKiem.Cookie != null)
                                XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đăng nhập thành công", Color.Blue);
                            else
                                XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đăng nhập thất bại", Color.Red);
                        }
                        _guiTinNhan.Cookie = tkTimKiem.Cookie;
                        thongTinTaiKhoan_GuiBindingSource.EndEdit();
                        grvTaiKhoanGui.RefreshData();
                    }
                    else
                    {
                        MessageBox.Show("Trang web yêu cầu đăng nhập để tìm kiếm!\nVui lòng thêm tài khoản trước");
                        return;
                    }
                    if (_guiTinNhan.Cookie == null)
                    {
                        MessageBox.Show("Kiểm tra lại thông tin đăng nhập!");
                        return;
                    }
                }
                #endregion
                tkiem = new FormTimKiem(_guiTinNhan, _db);
                if (tkiem.ShowDialog() == DialogResult.OK)
                {
                    _timKiemTokenResource = new CancellationTokenSource();
                    thongTinTaiKhoan_TimKiemBindingSource.Clear();
                    btnTimKiem.Text = "Dừng";
                    btnTimKiem.BackColor = Color.Red;
                    lblSoLuongKetQua.Text = "Số lượng kết quả: 0";
                    grbTimKiem.Text = tkiem.ChuoiTimKiem;

                    //backgroundWorkerTimKiem.RunWorkerAsync(tkiem.ParamTimKiem);
                    await TimKiemTask(tkiem.ParamTimKiem, _timKiemTokenResource.Token);
                }
            }
            else
            {
                if (tkiem != null)
                    tkiem.ParamTimKiem.DungTimKiem = true;
                _timKiemTokenResource.Cancel();
                backgroundWorkerTimKiem_RunWorkerCompleted(null, null);
            }
        }

        private void backgroundWorkerTimKiem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            thongTinTaiKhoan_TimKiemBindingSource.DataSource = _danhSach;
            btnTimKiem.Text = "Tìm kiếm (F3)";
            lblSoLuongKetQua.Text = "Số lượng kết quả: " + thongTinTaiKhoan_TimKiemBindingSource.Count.ToString();
            btnTimKiem.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void btnThemNoiDung_Click(object sender, EventArgs e)
        {
            this.ThemNoiDung();
        }

        private async void btnGuiTin_Click(object sender, EventArgs e)
        {
            await TienHanhGuiTin();
        }

        private async Task TienHanhGuiTin()
        {
            _guiTinNhanTokenResource = new CancellationTokenSource();
            btnGuiTin.Text = "Dừng";
            btnGuiTin.BackColor = Color.Red;

            await Task.Run(async () =>
            {
                //btnGuiTin.Enabled = false;
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                thongTinTaiKhoan_TimKiemBindingSource.EndEdit();

                #region Đăng nhập
                foreach (ThongTinTaiKhoan tk in thongTinTaiKhoan_GuiBindingSource)
                {
                    if (!string.IsNullOrEmpty(tk.TaiKhoan) && tk.SoTinNhanSeGui > 0)
                    {
                        XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang đăng nhập {0}...", tk.TaiKhoan), Color.Black);
                        await tk.DangNhapAsync(_guiTinNhan);
                    }
                }
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                grvTaiKhoanGui.RefreshData();
                #endregion

                #region Gửi
                if (radCheDo1.Checked)
                    await CheDo1();
                else if (radCheDo2.Checked)
                    await CheDo2();
                #endregion

            }, _guiTinNhanTokenResource.Token);
        }

        private async Task CheDo1()
        {
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
            int thoiGianCho;
            if (!int.TryParse(txtThoiGianCho.Text, out thoiGianCho))
            {
                MessageBox.Show("Chưa điền thời gian chờ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index_NguoiGuiHienTai = 0;
            int index_NguoiNhanHienTai = 0;
            int index_NoiDungHienTai = 0;

            int soThuSeGui = Math.Min(lstGui.Sum(p => p.SoTinNhanSeGui), soNguoiNhan);
            int demGui = 1;
            var danhSachNoiDung = this.DanhSachNoiDung();
            while (index_NguoiGuiHienTai < soNguoiGui && index_NguoiNhanHienTai < soNguoiNhan && !_guiTinNhanTokenResource.IsCancellationRequested)
            {
                ThongTinTaiKhoan nguoiGui = lstGui.ElementAt(index_NguoiGuiHienTai++);
                bool breakNow = false;
                for (int i = 0; i < nguoiGui.SoTinNhanSeGui; i++)
                {
                    ThongTinTaiKhoan nguoiNhan = lstNhan.ElementAt(index_NguoiNhanHienTai++);
                    if (string.IsNullOrEmpty(nguoiNhan.TrangThai))
                    {
                        thongTinTaiKhoan_TimKiemBindingSource.Position = thongTinTaiKhoan_TimKiemBindingSource.IndexOf(nguoiNhan);
                        XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang gửi {0}/{1} {2}...", demGui++, soThuSeGui, nguoiNhan.TenHienThi), Color.Green);
                        var noiDung = danhSachNoiDung[index_NoiDungHienTai];
                        Debug.WriteLine($"Gửi:/r/nTiêu đề:/r/n{this.LayTextTuSpinText(noiDung.TieuDe)}/r/nNội dung:/r/n{this.LayTextTuSpinText(noiDung.NoiDung)}");
                        _guiTinNhan.GuiTin(nguoiGui, nguoiNhan, this.LayTextTuSpinText(noiDung.TieuDe), this.LayTextTuSpinText(noiDung.NoiDung),
                            (code => {
                                if (code == CONST.TAI_KHOAN_BI_KHOA)
                                    breakNow = true;
                            }));
                        if (breakNow)
                        {
                            nguoiGui.TrangThai = "Bị khóa";
                            thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
                            grvTaiKhoanGui.RefreshData();
                            grvNguoiNhan.Focus();
                            break;
                        }
                        await Task.Delay(thoiGianCho * 1000);
                        thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
                        grvNguoiNhan.RefreshData();

                        //Chuyển nội dung
                        index_NoiDungHienTai = index_NoiDungHienTai == danhSachNoiDung.Count - 1 ? 0 : index_NoiDungHienTai + 1;
                    }
                    else
                    {
                        //Nếu đã gửi rồi thì không tính
                        i--;
                    }
                    //Nếu hết người nhận thì thoát vòng lặp
                    if (index_NguoiNhanHienTai >= soNguoiNhan)
                        break;
                    if (_guiTinNhanTokenResource.IsCancellationRequested)
                        break;
                }
            }
            XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Hoàn tất gửi tin ({0}/{1})", demGui - 1, soThuSeGui), Color.Black);
            btnGuiTin.Text = "Gửi tin nhắn";
            btnGuiTin.BackColor = Color.LightSkyBlue;
        }

        private async Task CheDo2()
        {
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
            int thoiGianCho;
            if (!int.TryParse(txtThoiGianCho.Text, out thoiGianCho))
            {
                MessageBox.Show("Chưa điền thời gian chờ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int index_NguoiGuiHienTai = 0;
            int index_NguoiNhanHienTai = 0;
            var danhSachNoiDung = this.DanhSachNoiDung();
            int soThuSeGui = Math.Min(lstGui.Sum(p => p.SoTinNhanSeGui), soNguoiNhan) * danhSachNoiDung.Count;
            int demGui = 1;
            while (index_NguoiGuiHienTai < soNguoiGui && index_NguoiNhanHienTai < soNguoiNhan && !_guiTinNhanTokenResource.IsCancellationRequested)
            {
                ThongTinTaiKhoan nguoiGui = lstGui.ElementAt(index_NguoiGuiHienTai++);
                bool breakNow = false;

                for (int i = 0; i < nguoiGui.SoTinNhanSeGui; i++)
                {
                    ThongTinTaiKhoan nguoiNhan = lstNhan.ElementAt(index_NguoiNhanHienTai++);
                    if (string.IsNullOrEmpty(nguoiNhan.TrangThai))
                    {
                        thongTinTaiKhoan_TimKiemBindingSource.Position = thongTinTaiKhoan_TimKiemBindingSource.IndexOf(nguoiNhan);
                        foreach (var nd in danhSachNoiDung)
                        {
                            XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang gửi {0}/{1} {2}...", demGui++, soThuSeGui, nguoiNhan.TenHienThi), Color.Green);
                            Debug.WriteLine($"Gửi:/r/nTiêu đề:/r/n{this.LayTextTuSpinText(nd.TieuDe)}/r/nNội dung:/r/n{this.LayTextTuSpinText(nd.NoiDung)}");
                            _guiTinNhan.GuiTin(nguoiGui, nguoiNhan, this.LayTextTuSpinText(nd.TieuDe), this.LayTextTuSpinText(nd.NoiDung),
                                (code =>
                                {
                                    if (code == CONST.TAI_KHOAN_BI_KHOA)
                                        breakNow = true;
                                }));
                            if (breakNow)
                                break;
                            await Task.Delay(thoiGianCho * 1000);
                            thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
                            grvNguoiNhan.RefreshData();
                            if (_guiTinNhanTokenResource.IsCancellationRequested)
                                break;
                        }
                        if (breakNow)
                        {
                            nguoiGui.TrangThai = "Bị khóa";
                            thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
                            grvTaiKhoanGui.RefreshData();
                            grvNguoiNhan.Focus();
                            break;
                        }
                    }
                    else
                    {
                        //Nếu đã gửi rồi thì không tính
                        i--;
                    }
                    //Nếu hết người nhận thì thoát vòng lặp
                    if (index_NguoiNhanHienTai >= soNguoiNhan)
                        break;
                    if (_guiTinNhanTokenResource.IsCancellationRequested)
                        break;
                }
            }
            XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Hoàn tất gửi tin ({0}/{1})", demGui - 1, soThuSeGui), Color.Black);
            btnGuiTin.Text = "Gửi tin nhắn";
            btnGuiTin.BackColor = Color.LightSkyBlue;
        }

        private static string spintax(Random rnd, string str)
        {
            string pattern = "{[^{}]*}";
            Match i = Regex.Match(str, pattern);
            while (i.Success)
            {
                string seg = str.Substring(i.Index + 1, i.Length - 2);
                string[] choices = seg.Split('|');
                str = str.Substring(0, i.Index) + choices[rnd.Next(choices.Length)] + str.Substring(i.Index + i.Length);
                i = Regex.Match(str, pattern);
            }
            return str;
        }

        private string LayTextTuSpinText(string spintext)
        {
            Random rnd = new Random();
            return spintax(rnd, spintext);
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            thongTinTaiKhoan_GuiBindingSource.Position = thongTinTaiKhoan_GuiBindingSource.Add(new ThongTinTaiKhoan());
            grvTaiKhoanGui.Focus();
        }

        private async void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan tk = thongTinTaiKhoan_GuiBindingSource.Current as ThongTinTaiKhoan;
            if (tk != null)
            {
                đăngNhậpToolStripMenuItem.Enabled = false;
                await tk.DangNhapAsync(_guiTinNhan);
                đăngNhậpToolStripMenuItem.Enabled = true;
            }
        }

        private Task TimKiemTask(ThongTinTimKiem param, CancellationToken token)
        {
            return Task.Run(() =>
            {
                int dem = 0;
                _danhSach = new BindingList<ThongTinTaiKhoan>();
                XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đang nhận dữ liệu...", Color.Red);
                foreach (var kq in _guiTinNhan.TimKiem(param))
                {
                    if (token.IsCancellationRequested)
                        break;
                    if (!_danhSach.Select(p => p.Id).Contains(kq.Id))
                    {
                        _danhSach.Add(kq);
                        Debug.WriteLine($"{kq.Id} - {kq.TaiKhoan}");
                        XuLyDaLuong.ChangeText(lblSoLuongKetQua,
                                    string.Format("Số lượng kết quả: {0}", ++dem), Color.Black);
                    }
                }
                XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Hoàn tất tìm kiếm", Color.Green);

                thongTinTaiKhoan_TimKiemBindingSource.DataSource = _danhSach;
                btnTimKiem.Text = "Tìm kiếm (F3)";
                lblSoLuongKetQua.Text = "Số lượng kết quả: " + thongTinTaiKhoan_TimKiemBindingSource.Count.ToString();
                btnTimKiem.BackColor = Color.FromArgb(255, 255, 128);
            });
        }
    }
}
