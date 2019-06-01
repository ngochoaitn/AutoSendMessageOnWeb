using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThaoTacTrenForum.Forms
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnGiTinNhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new GuiTinNhan.FormGuiTinNhanTab().ShowDialog();
        }
    }
}
