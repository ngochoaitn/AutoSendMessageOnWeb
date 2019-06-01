using System;

namespace ThaoTacTrenForum.Controls.GuiTinNhan
{
    public partial class UserControlThongTinGui : DevExpress.XtraEditors.XtraUserControl
    {
        public string TieuDe { get { return txtTieuDe.Text; } set { txtTieuDe.Text = value; } }
        public string NoiDung { get { return txtNoiDung.Text; } set { txtNoiDung.Text = value; } }
        public int STT { set; get; }
        public event Action Dong;

        public UserControlThongTinGui()
        {
            InitializeComponent();
        }

        public UserControlThongTinGui(int stt)
        {
            InitializeComponent();
            lblStt.Text = $"Nội dung {stt}";
            this.STT = stt;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (Dong != null)
                Dong();
        }
    }
}
