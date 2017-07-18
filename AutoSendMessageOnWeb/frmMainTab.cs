using AutoSendMessageOnWeb.Lib;
using System;
using System.Drawing;
using System.Windows.Forms;
using ThuVienWinform.UI;

namespace AutoSendMessageOnWeb
{
    public partial class frmMainTab : Form
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

        public frmMainTab()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1, this.Handle);
            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1.lblFormText, this.Handle);
        }

        private void frmMainTab_Load(object sender, EventArgs e)
        {
            cAutoHenHo2.CaiDatTrang(Data.TrangWeb.HenHo2);
            cAutoDuyenSo.CaiDatTrang(Data.TrangWeb.DuyenSo);
            cAutoVietNamCupid.CaiDatTrang(Data.TrangWeb.VietNamCupid);
            cAutoLikeYou.CaiDatTrang(Data.TrangWeb.LikeYou);
            cAutoHenHoKetBan.CaiDatTrang(Data.TrangWeb.HenHoKetBan);
            cAutoTimBanGai.CaiDatTrang(Data.TrangWeb.TimBanGai);

            this.Text += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            controlBoxFlat1.lblFormText.Text = this.Text;

            StartUpOperation.CheckVersion(CoPhienBanMoi);

            lblWebChinhThuc.Text = Properties.Settings.Default.WebChinhThuc;
        }

        private void CoPhienBanMoi()
        {
            new frmNoiDungCapNhat().ShowDialog();
        }

        private void frmMainTab_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Control)
            {
                switch(e.KeyCode)
                {
                    case Keys.N:
                        (mainTabControl.SelectedTab.Controls[0] as cAuto).TaoTaiKhoanMoi();
                        break;
                    case Keys.S:
                        (mainTabControl.SelectedTab.Controls[0] as cAuto).LuuDulieu();
                        break;
                }
            }
            else if (e.KeyCode == Keys.F3)
                (mainTabControl.SelectedTab.Controls[0] as cAuto).TimKiem();
        }
    }
}
