using AutoSendMessageOnWeb.Data;
using Fizzler.Systems.HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ThuVienWinform.UI;

namespace AutoSendMessageOnWeb.Lib
{
    public partial class frmTimKiemBrowser : Form
    {
        private TrangWeb _trang;
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

        public IEnumerable<ThongTinTaiKhoan> DanhSachTaiKhoanDuocChon { set; get; }
        public frmTimKiemBrowser(TrangWeb trang)
        {
            InitializeComponent();

            _trang = trang;
            

            ControlPlus.MovieFormWhenMouseDownControl(controlBoxFlat1.lblFormText, this.Handle);

            this.DanhSachTaiKhoanDuocChon = new List<ThongTinTaiKhoan>();

            switch(trang)
            {
                case TrangWeb.HenHo2:
                    //webBrowser1.Navigate("http://henho2.com/Home/Index?gtinh=0&countryid=237&province=-1&maritial=1&objective=2&ageFrom=&ageTo=&name=");
                    webBrowser1.Navigate("http://henho2.com/");
                    break;
            }
        }

        private void LayThongTinTrangNay()
        {
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(webBrowser1.Document.Body.OuterHtml);

            var xx = document.DocumentNode.QuerySelectorAll("table > tbody > tr > td").ToList();
            for (int i = 0; i < xx.Count; i++)
            {
                ThongTinTaiKhoan taiKhoan = new ThongTinTaiKhoan();
                var tenHienThi = xx[i].QuerySelector("a");
                if (tenHienThi != null)
                {
                    string duongDan = tenHienThi.GetAttributeValue("href", "");
                    if (!string.IsNullOrEmpty(duongDan))
                    {
                        try
                        {
                            int id = Convert.ToInt32(duongDan.Split('/')[3]);
                            string ten = xx[i].InnerText.Split('\n')[4];

                            taiKhoan.Url = string.Format("http://henho2.com{0}", duongDan);
                            taiKhoan.Id = duongDan.Split('/')[3];
                            taiKhoan.TenHienThi = ten.Trim();
                            taiKhoan.ChoPhepGuiNhan = true;

                            if ((thongTinTaiKhoanBindingSource.List as IList<ThongTinTaiKhoan>).Where(p => p.Id == taiKhoan.Id).FirstOrDefault() == null)
                                thongTinTaiKhoanBindingSource.Add(taiKhoan);
                        }
                        catch { }
                    }
                }
            }
        }

        private void btnLayThongTin_Click(object sender, EventArgs e)
        {
            if (thongTinTaiKhoanBindingSource == null || thongTinTaiKhoanBindingSource.Count == 0)
                this.LayThongTinTrangNay();
            else
                menuLayThongTinTrang.Show(Cursor.Position);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.DanhSachTaiKhoanDuocChon = thongTinTaiKhoanBindingSource.List as IList<ThongTinTaiKhoan>;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtDuongDan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(txtDuongDan.Text);
                daAnTimKiem_HenHo2 = false;
            }
        }

        bool daAnTimKiem_HenHo2 = false;
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtDuongDan.Text = webBrowser1.Url.ToString();

            #region Nút tìm kiếm HenHo2
            if (_trang == TrangWeb.HenHo2 &&  webBrowser1.Url.ToString() == "http://henho2.com/")
            {
                var buttons = webBrowser1.Document.GetElementsByTagName("a");

                HtmlElement btnDangNhap = null;
                foreach (HtmlElement btn in buttons)
                {
                    if (btn.GetAttribute("className") == "btn btn-danger btn-sm" && btn.Id == null)
                    {
                        btnDangNhap = btn;
                        if (!daAnTimKiem_HenHo2 && btn.InnerText == "Tìm kiếm")
                        {
                            btnDangNhap.InvokeMember("Click");
                            daAnTimKiem_HenHo2 = true;
                            break;
                        }
                    }
                }
            }
            #endregion
        }

        private void dataGridViewFlat1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                thongTinTaiKhoanBindingSource.RemoveCurrent();
        }

        private void btnThemVaoDanhSachDaCo_Click(object sender, EventArgs e)
        {
            this.LayThongTinTrangNay();
        }

        private void btnXoaRoiThem_Click(object sender, EventArgs e)
        {
            thongTinTaiKhoanBindingSource.Clear();
            this.LayThongTinTrangNay();
        }

        private void frmTimKiemBrowser_Load(object sender, EventArgs e)
        {
            thongTinTaiKhoanBindingSource.DataSource = this.DanhSachTaiKhoanDuocChon;
        }
    }
}
