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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSendMessageOnWeb
{
    public partial class cAuto : UserControl
    {
        private IGuiTinNhan _guiTinNhan;
        private TrangWeb _trang;
        DatabaseManager _db;
        CancellationTokenSource _guiTinNhanTokenResource, _timKiemTokenResource;
        frmTimKiem tkiem = null;


        private List<cThongTinGui> DanhSachNoiDung()
        {
            var res = new List<cThongTinGui>();
            foreach (Control c in panTopThongTinGui.Controls)
                if (c is cThongTinGui)
                    res.Add(c as cThongTinGui);
            return res.OrderBy(p => p.STT).ToList();
        }

        public cAuto()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            btnDangKyTaiKhoan.Visible = false;
        }

        private void AnTieuDe()
        {
            foreach (var c in DanhSachNoiDung())
                c.AnTieuDe();
        }

        public void CaiDatTrang(TrangWeb trang)
        {
            _trang = trang;
            _db = new DatabaseManager(trang);
            for(int i = 0; i < _db.DanhSachNoiDung.Count; i++)
                this.ThemNoiDung(_db.DanhSachTieuDe[i], _db.DanhSachNoiDung[i]);
            if(_db.DanhSachNoiDung.Count == 0)
                this.ThemNoiDung();

            Program.XayRaLoi += Program_XayRaLoi;

            thongTinTaiKhoan_GuiBindingSource.DataSource = _db.DanhSachNguoiGui;
            thongTinTaiKhoan_TimKiemBindingSource.DataSource = _db.DanhSachNguoiNhan;
            grbTimKiem.Text = _db.PhienTimKiem;

            lblSoLuongKetQua.Text = string.Format("Số lượng kết quả: {0}", thongTinTaiKhoan_TimKiemBindingSource.Count);

            switch (trang)
            {
                case TrangWeb.HenHo2:
                    _guiTinNhan = new HenHo2();
                    break;
                case TrangWeb.DuyenSo:
                    _guiTinNhan = new DuyenSo();
                    radCheDo2.Checked = true;
                    this.AnTieuDe();
                    break;
                case TrangWeb.VietNamCupid:
                    _guiTinNhan = new VietNamCupid();
                    break;
                case TrangWeb.LikeYou:
                    _guiTinNhan = new LikeYou();
                    this.AnTieuDe();
                    break;
                case TrangWeb.HenHoKetBan:
                    _guiTinNhan = new HenHoKetBan();
                    break;
                case TrangWeb.TimBanGai:
                    _guiTinNhan = new TimBanGai();
                    break;
                case TrangWeb.eHenHo:
                    _guiTinNhan = new ehenho();
                    (_guiTinNhan as ehenho).TimThayKetQua += (danh_sach) => { _danhSach = new BindingList<ThongTinTaiKhoan>(danh_sach.ToList()); XuLyDaLuong.ChangeText(lblSoLuongKetQua,$"Số lượng kết quả: {_danhSach.Count}", Color.Black);};
                    break;
            }
        }

        public void ChoPhepDangKy(bool cho_phep)
        {
            btnDangKyTaiKhoan.Visible = cho_phep;
        }

        private void Program_XayRaLoi()
        {
            _db.SaveChange();
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (btnTimKiem.Text == "Tìm kiếm (F3)")
            {
                #region Lấy cookie nếu trang yêu cầu
                if (_guiTinNhan.TimKiemYeuCauCookie)
                {
                    if(thongTinTaiKhoan_GuiBindingSource.Count > 0)
                    {
                        ThongTinTaiKhoan tkTimKiem = thongTinTaiKhoan_GuiBindingSource[0] as ThongTinTaiKhoan;
                        if (tkTimKiem.YeuCauDangNhapMoi)
                        {
                            XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, string.Format("Đang nhập {0}...", tkTimKiem.TaiKhoan), Color.Red);
                            tkTimKiem.DangNhap(_guiTinNhan);
                            if(tkTimKiem.Cookie != null)
                                XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đăng nhập thành công", Color.Blue);
                            else
                                XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đăng nhập thất bại", Color.Red);
                        }
                        _guiTinNhan.Cookie = tkTimKiem.Cookie;
                        thongTinTaiKhoan_GuiBindingSource.EndEdit();
                        grvGui.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Trang web yêu cầu đăng nhập để tìm kiếm!\nVui lòng thêm tài khoản trước");
                        return;
                    }
                    if(_guiTinNhan.Cookie == null)
                    {
                        MessageBox.Show("Kiểm tra lại thông tin đăng nhập!");
                        return;
                    }
                }
                #endregion

                tkiem = new frmTimKiem(_guiTinNhan);
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
                    //await Task.Run(() => TimKiemTask(tkiem.ParamTimKiem, _timKiemTokenResource.Token));
                }
            }
            else
            {
                btnTimKiem.Enabled = false;
                XuLyDaLuong.ChangeText(lblSoLuongKetQua, "Đang dừng....", Color.Black);
                //backgroundWorkerTimKiem.CancelAsync();
                if (tkiem != null)
                    tkiem.ParamTimKiem.DungTimKiem = true;
                _timKiemTokenResource.Cancel();
                backgroundWorkerTimKiem_RunWorkerCompleted(backgroundWorkerTimKiem, null);
            }
        }

        BindingList<ThongTinTaiKhoan> _danhSach = new BindingList<ThongTinTaiKhoan>();

        private void backgroundWorkerTimKiem_DoWork(object sender, DoWorkEventArgs e)
        {
            int dem = 0;
            _danhSach = new BindingList<ThongTinTaiKhoan>();
            XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đang nhận dữ liệu...", Color.Red);
            foreach (var kq in _guiTinNhan.TimKiem(e.Argument as ThongTinTimKiem))
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

        private async Task TimKiemTask(ThongTinTimKiem param, CancellationToken token)
        {
            await Task.Run(() =>
            {
                try
                {
                    int dem = 0;
                    _danhSach = new BindingList<ThongTinTaiKhoan>();
                    XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Đang nhận dữ liệu...", Color.Red);
                    foreach (var kq in _guiTinNhan.TimKiem(param))
                    {
                        if (kq == null)
                            continue;
                        if (token.IsCancellationRequested)
                            break;
                        if (!_danhSach.Select(p => p.Id).Contains(kq.Id) || (_guiTinNhan is TimBanGai && !string.IsNullOrEmpty(kq.TenHienThi)))
                        {
                            _danhSach.Add(kq);
                            XuLyDaLuong.ChangeText(lblSoLuongKetQua,
                                        string.Format("Số lượng kết quả: {0}", ++dem), Color.Black);
                            if (token.IsCancellationRequested)
                                break;
                        }
                    }
                }
                catch
                { }
            });
            //Thread.Sleep(1000);
            XuLyDaLuong.ChangeText(lblTrangThaiTimKiem, "Hoàn tất tìm kiếm", Color.Green);
            btnTimKiem.Enabled = true;
            thongTinTaiKhoan_TimKiemBindingSource.DataSource = _danhSach;
            btnTimKiem.Text = "Tìm kiếm (F3)";
            lblSoLuongKetQua.Text = "Số lượng kết quả: " + thongTinTaiKhoan_TimKiemBindingSource.Count.ToString();
            btnTimKiem.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void backgroundWorkerTimKiem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            thongTinTaiKhoan_TimKiemBindingSource.DataSource = _danhSach;
            btnTimKiem.Text = "Tìm kiếm (F3)";
            lblSoLuongKetQua.Text = "Số lượng kết quả: " + thongTinTaiKhoan_TimKiemBindingSource.Count.ToString();
            btnTimKiem.BackColor = Color.FromArgb(255, 255, 128);
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
                    if (!string.IsNullOrEmpty(tk.TaiKhoan) && tk.SoThuSeGui > 0)
                    {
                        XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang đăng nhập {0}...", tk.TaiKhoan), Color.Black);
                        try
                        {
                            tk.DangNhap(_guiTinNhan);
                        }
                        catch { }
                    }
                }
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                grvGui.Refresh();
                #endregion

                #region Gửi
                if (radCheDo1.Checked)
                    await CheDo1();
                else if(radCheDo2.Checked)
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

            int soThuSeGui = Math.Min(lstGui.Sum(p => p.SoThuSeGui), soNguoiNhan);
            int demGui = 1;
            var danhSachNoiDung = this.DanhSachNoiDung();
            while (index_NguoiGuiHienTai < soNguoiGui && index_NguoiNhanHienTai < soNguoiNhan && !_guiTinNhanTokenResource.IsCancellationRequested)
            {
                ThongTinTaiKhoan nguoiGui = lstGui.ElementAt(index_NguoiGuiHienTai++);
                bool breakNow = false;
                for (int i = 0; i < nguoiGui.SoThuSeGui; i++)
                {
                    ThongTinTaiKhoan nguoiNhan = lstNhan.ElementAt(index_NguoiNhanHienTai++);
                    if (string.IsNullOrEmpty(nguoiNhan.TrangThai))
                    {
                        thongTinTaiKhoan_TimKiemBindingSource.Position = thongTinTaiKhoan_TimKiemBindingSource.IndexOf(nguoiNhan);
                        XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang gửi {0}/{1} {2}...", demGui++, soThuSeGui, nguoiNhan.TenHienThi), Color.Green);
                        var noiDung = danhSachNoiDung[index_NoiDungHienTai];
                        Debug.WriteLine($"Gửi:/r/nTiêu đề:/r/n{this.LayTextTuSpinText(noiDung.TieuDe)}/r/nNội dung:/r/n{this.LayTextTuSpinText(noiDung.NoiDung)}");
                        try
                        {
                            _guiTinNhan.GuiTin(nguoiGui, nguoiNhan, this.LayTextTuSpinText(noiDung.TieuDe), this.LayTextTuSpinText(noiDung.NoiDung),
                                (code =>
                                {
                                    if (code == CONST_HENHO2.TAI_KHOAN_BI_KHOA)
                                        breakNow = true;
                                }));
                        }
                        catch
                        {
                            //nguoiGui.TrangThai = "Chuyển tài khoản";
                            break;
                        }
                        if (breakNow)
                        {
                            nguoiGui.TrangThai = "Bị khóa";
                            thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
                            grvGui.Refresh();
                            grvTimKiem.Focus();
                            break;
                        }
                        if (!nguoiGui.ChoPhepGuiNhan)
                            break;

                        await Task.Delay(thoiGianCho * 1000);
                        thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
                        grvTimKiem.Refresh();

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
            grvTimKiem.Refresh();
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
            int soThuSeGui = Math.Min(lstGui.Sum(p => p.SoThuSeGui), soNguoiNhan)*danhSachNoiDung.Count;
            int demGui = 1;
            while (index_NguoiGuiHienTai < soNguoiGui && index_NguoiNhanHienTai < soNguoiNhan && !_guiTinNhanTokenResource.IsCancellationRequested)
            {
                ThongTinTaiKhoan nguoiGui = lstGui.ElementAt(index_NguoiGuiHienTai++);
                bool breakNow = false;
                
                for (int i = 0; i < nguoiGui.SoThuSeGui; i++)
                {
                    ThongTinTaiKhoan nguoiNhan = lstNhan.ElementAt(index_NguoiNhanHienTai++);
                    if (string.IsNullOrEmpty(nguoiNhan.TrangThai))
                    {
                        thongTinTaiKhoan_TimKiemBindingSource.Position = thongTinTaiKhoan_TimKiemBindingSource.IndexOf(nguoiNhan);
                        foreach (var nd in danhSachNoiDung)
                        {
                            XuLyDaLuong.ChangeText(lblTrangThai, string.Format("Đang gửi {0}/{1} {2}...", demGui++, soThuSeGui, nguoiNhan.TenHienThi), Color.Green);
                            Debug.WriteLine($"Gửi:/r/nTiêu đề:/r/n{this.LayTextTuSpinText(nd.TieuDe)}/r/nNội dung:/r/n{this.LayTextTuSpinText(nd.NoiDung)}");
                            try
                            {
                                _guiTinNhan.GuiTin(nguoiGui, nguoiNhan, this.LayTextTuSpinText(nd.TieuDe), this.LayTextTuSpinText(nd.NoiDung),
                                    (code =>
                                    {
                                        if (code == CONST_HENHO2.TAI_KHOAN_BI_KHOA)
                                            breakNow = true;
                                    }));
                            }
                            catch
                            {
                                break;
                            }

                            if (breakNow)
                                break;

                            await Task.Delay(thoiGianCho * 1000);
                            thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
                            grvTimKiem.Refresh();
                            if (_guiTinNhanTokenResource.IsCancellationRequested)
                                break;
                            if (!nguoiGui.ChoPhepGuiNhan)
                                break;
                        }
                        if (breakNow)
                        {
                            nguoiGui.TrangThai = "Bị khóa";
                            thongTinTaiKhoan_TimKiemBindingSource.EndEdit();
                            grvGui.Refresh();
                            grvTimKiem.Focus();
                            break;
                        }
                        if (!nguoiGui.ChoPhepGuiNhan)
                            break;
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

        private async void btnGuiTin_Click(object sender, EventArgs e)
        {
            if(btnGuiTin.Text == "Gửi tin nhắn")
            {
                await TienHanhGuiTin();
            }
            else
            {
                btnGuiTin.Text = "Gửi tin nhắn";
                btnGuiTin.BackColor = Color.LightSkyBlue;
                _guiTinNhanTokenResource.Cancel();
            }
        }

        private void btnLuuDanhSach_Click(object sender, EventArgs e)
        {
            _db.DanhSachNguoiGui = thongTinTaiKhoan_GuiBindingSource.List as BindingList<ThongTinTaiKhoan>;
            _db.DanhSachNguoiNhan = thongTinTaiKhoan_TimKiemBindingSource.List as BindingList<ThongTinTaiKhoan>;
            _db.PhienTimKiem = grbTimKiem.Text;
            _db.DanhSachNoiDung.Clear();
            _db.DanhSachTieuDe.Clear();
            foreach (var c in DanhSachNoiDung().OrderBy(p => p.STT))
            {
                _db.DanhSachNoiDung.Add(c.NoiDung);
                _db.DanhSachTieuDe.Add(c.TieuDe);
            }
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

        private void btnThemNoiDung_Click(object sender, EventArgs e)
        {
            this.ThemNoiDung();
        }

        private void ThemNoiDung(string tieu_de = "Tiêu đề", string noi_dung = "Nội dung")
        {
            cThongTinGui noiDungMoi = new cThongTinGui(DanhSachNoiDung().Count + 1);

            if (_trang == TrangWeb.VietNamCupid)
                noiDungMoi.VietNamCupid();

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

        private void càiĐạtSLGửiTheoTàiKhoảnNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan taiKhoan = thongTinTaiKhoan_GuiBindingSource.Current as ThongTinTaiKhoan;
            if (taiKhoan != null)
            {
                foreach(ThongTinTaiKhoan tk in thongTinTaiKhoan_GuiBindingSource)
                    tk.SoThuSeGui = taiKhoan.SoThuSeGui;
                thongTinTaiKhoan_GuiBindingSource.EndEdit();
                grvGui.Refresh();
            }
            else
            {
                MessageBox.Show("Chưa chọn tài khoản");
            }
        }

        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            if (_trang == TrangWeb.eHenHo || _trang == TrangWeb.HenHoKetBan)
            {
                frmTuDongDangKyTaiKhoan_HangLoat frmDangKy = new frmTuDongDangKyTaiKhoan_HangLoat(_trang);
                frmDangKy.ShowDialog();
                foreach (var tk in frmDangKy.DanhSachTaiKhoanDaDangKy)
                    thongTinTaiKhoan_GuiBindingSource.Add(tk);
            }
            else
            {
                frmTuDongDangKyTaiKhoan frmDangKy = new frmTuDongDangKyTaiKhoan(_trang);
                frmDangKy.ShowDialog();
                foreach (var tk in frmDangKy.DanhSachTaiKhoanDaDangKy)
                    thongTinTaiKhoan_GuiBindingSource.Add(tk);
            }
            _db.SaveChange();
        }
    }
}
