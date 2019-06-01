using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ThaoTacTrenForum.Lib.ThaoTacWeb.GuiTinNhan;
using ThaoTacTrenForum.Data;

namespace ThaoTacTrenForum.Lib.ThaoTacControl
{
    public partial class FormTimKiem : DevExpress.XtraEditors.XtraForm
    {
        private IGuiTinNhan _guiTinNhan;
        private DatabaseManager _db;

        public ThongTinTimKiem ParamTimKiem { private set; get; }
        public string ChuoiTimKiem { private set; get; }

        public FormTimKiem(IGuiTinNhan gui_tin_nhan, DatabaseManager db)
        {
            InitializeComponent();
            _guiTinNhan = gui_tin_nhan;
            _db = db;
        }

        private void FormTimKiem_Load(object sender, EventArgs e)
        {
            chuyenMucBindingSource.DataSource = _guiTinNhan.TaoDuLieuTimKiem().DanhSachChuyenMuc;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.ParamTimKiem = new ThongTinTimKiem();

            foreach (int row in grvChuyenMuc.GetSelectedRows())
                this.ParamTimKiem.ChuyenMucs.Add(grvChuyenMuc.GetRow(row) as ChuyenMuc);

            this.ChuoiTimKiem = $"Chuyên mục {searchLookUpEdit1.Text}";
            this.ParamTimKiem.TimNguoiMoiBinhLuan = checkEdit1.Checked;
            this.DialogResult = DialogResult.OK;
        }
    }
}