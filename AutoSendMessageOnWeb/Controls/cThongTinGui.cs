using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSendMessageOnWeb
{
    public partial class cThongTinGui : UserControl
    {
        public string TieuDe { get { return txtTieuDe.Text; } set { txtTieuDe.Text = value; } }
        public string NoiDung { get { return txtNoiDung.Text; } set { txtNoiDung.Text = value; } }
        public int STT { set; get; }
        public event Action Dong;

        public cThongTinGui()
        {
            InitializeComponent();
        }
        public cThongTinGui(int stt)
        {
            InitializeComponent();
            lblStt.Text = $"Nội dung {stt}";
            this.STT = stt;
        }
        public void AnTieuDe()
        {
            lblTieuDe.Visible = txtTieuDe.Visible = false;

            lblNoiDung.Location = lblTieuDe.Location;
            txtNoiDung.Location = txtTieuDe.Location;
            txtNoiDung.Height += 50;
        }

        public void VietNamCupid()
        {
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
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (Dong != null)
                Dong();
        }
    }
}
