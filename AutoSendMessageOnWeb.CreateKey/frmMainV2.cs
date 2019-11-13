using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
using AutoSendMessageOnWeb.Lib.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ThuVienWinform.UI;

namespace AutoSendMessageOnWeb.CreateKey
{
    public partial class frmMainV2 : Form
    {
        DatabaseManager _db;
        ThongTinNguoiDung NguoiDung = new ThongTinNguoiDung();

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

        public frmMainV2()
        {
            InitializeComponent();

            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1.lblFormText, this.Handle);

            _db = new DatabaseManager(TrangWeb.ThongTinNguoiDung);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            thongTinNguoiDungBindingSource.DataSource = _db.DanhSachNguoiDung;

            //Mặc định 1 tháng
            dateHanNhieuMa.Value = DateTime.Now.AddMonths(1);
        }

        private void btnThemNguoiDungMoi_Click(object sender, EventArgs e)
        {
            frmThemNguoiDung frmThem = new frmThemNguoiDung();
            if (frmThem.ShowDialog() == DialogResult.OK)
            {
                if ((thongTinNguoiDungBindingSource.List as IList<ThongTinNguoiDung>)
                                                  .Where(p => p.MAC == frmThem.NguoiDung.MAC
                                                           && p.TenMay == frmThem.NguoiDung.TenMay)
                                                  .FirstOrDefault() == null)
                {
                    thongTinNguoiDungBindingSource.Add(frmThem.NguoiDung);
                    _db.SaveChange();
                }
            }
        }

        private void btnTaoNhieuMa_Click(object sender, EventArgs e)
        {
                txtMaKichHoat.Text = NguoiDung.TaoMaSuDung(dateHanNhieuMa.Value);
        }

        private void btnTaoKhoaMoi_Click(object sender, EventArgs e)
        {
            Crypto.CreateKey(2048);
            MessageBox.Show($"Đã tạo khóa mới\r\nVui lòng cung cấp tệp \"{ConstFilePath.FILE_PUBLICKEY}\" cho khách hàng!");
        }

        private void txtMaMay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NguoiDung = new ThongTinNguoiDung();
                NguoiDung.LayThongTin(txtMaMay.Text);

                lblThongTinMay.Text = $"MAC: {NguoiDung.MAC} - Tên máy: {NguoiDung.TenMay}";
                btnTaoNhieuMa.Enabled = true;
            }
            catch
            {
                lblThongTinMay.Text = "Mã máy không đúng";
                btnTaoNhieuMa.Enabled = false;
            }
        }

        private void frmMainV2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.Shift && e.KeyCode == Keys.T)
            {
                Crypto.CreateKey(2048);
                MessageBox.Show($"Đã tạo khóa mới\r\nVui lòng cung cấp tệp \"{ConstFilePath.FILE_PUBLICKEY}\" cho khách hàng!");
            }
        }
    }
}
