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

namespace ThaoTacTrenForum.Forms.GuiTinNhan
{
    public partial class FormGuiTinNhanTab : DevExpress.XtraEditors.XtraForm
    {
        public FormGuiTinNhanTab()
        {
            InitializeComponent();
        }

        private void FormGuiTinNhanTab_Load(object sender, EventArgs e)
        {
            ucGuiTinNhanWebTreTho.CaiDatTrang(Data.TrangWeb.WebTreTho);
        }
    }
}