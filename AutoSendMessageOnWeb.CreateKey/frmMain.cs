using AutoSendMessageOnWeb.Data;
using AutoSendMessageOnWeb.Lib.ExtentionMethod;
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

namespace AutoSendMessageOnWeb.CreateKey
{
    public partial class frmMain : Form
    {
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

        public frmMain()
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
            txtNhieuMa.Text = "";
            foreach (ThongTinNguoiDung nguoidung in thongTinNguoiDungBindingSource)
            {
                string s1 = string.Format("Máy: [{0}][{1}\r\n", nguoidung.TenMay, nguoidung.MAC);
                string s2 = string.Format("Mã : {0}\r\n", nguoidung.TaoMaSuDung(dateHanNhieuMa.Value));
                string s3 = new string('-', 20);

                txtNhieuMa.AppendText(string.Format("{0}{1}{2}\r\n", s1, s2, s3));
            }
        }
    }
}
