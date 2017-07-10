using AutoSendMessageOnWeb.Data;
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

namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb
{

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

        public frmTimKiem(IThaoTacWeb thaotacweb)
        {
            InitializeComponent();

            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1.lblFormText, this.Handle);

            _duLieuTimKiem = thaotacweb.TaoDuLieuTimKiem();

            foreach (var noio in _duLieuTimKiem.NoiO)
                cbbNoiO.Items.Add(noio.Value);

            foreach (var tinhtrang in _duLieuTimKiem.TinhTrangHonNhan)
                cbbTinhTrangHonNhan.Items.Add(tinhtrang);

            foreach (var gtinh in _duLieuTimKiem.GioiTinh)
                cbbGioiTinh.Items.Add(gtinh.Value);

            cbbTinhTrangHonNhan.DisplayMember = "TenTinhTrang";

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

            foreach (var sl in cbbTinhTrangHonNhan.CheckedItems)
            {
                var tinhTrang = _duLieuTimKiem.TinhTrangHonNhan.Where(p => p.TenTinhTrang == sl.ToString()).FirstOrDefault();
                this.ParamTimKiem.HonNhan.Add(sl as ThongTinTimKiem.TinhTrangHonNhan);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
