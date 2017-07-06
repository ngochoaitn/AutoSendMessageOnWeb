namespace AutoSendMessageOnWeb
{
    partial class frmTimKiemBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemBrowser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.controlBoxFlat1 = new ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtDuongDan = new ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLayThongTin = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panRight = new System.Windows.Forms.Panel();
            this.dataGridViewFlat1 = new ThuVienWinform.UI.Flat.Data.DataGridViewFlat();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenHienThiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taiKhoanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cookieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thongTinTaiKhoanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panRight_bot = new System.Windows.Forms.Panel();
            this.btnXacNhan = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.menuLayThongTinTrang = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThemVaoDanhSachDaCo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXoaRoiThem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoanBindingSource)).BeginInit();
            this.panRight_bot.SuspendLayout();
            this.menuLayThongTinTrang.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlBoxFlat1
            // 
            this.controlBoxFlat1.BackColor = System.Drawing.Color.Transparent;
            this.controlBoxFlat1.CloseColor = System.Drawing.Color.Transparent;
            this.controlBoxFlat1.CloseHoverColor = System.Drawing.Color.Red;
            this.controlBoxFlat1.CloseText = "Χ";
            this.controlBoxFlat1.CloseTextColor = System.Drawing.Color.Black;
            this.controlBoxFlat1.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBoxFlat1.FormTextColor = System.Drawing.SystemColors.ControlText;
            this.controlBoxFlat1.Location = new System.Drawing.Point(0, 0);
            this.controlBoxFlat1.MaxSize = true;
            this.controlBoxFlat1.MaxSizeColor = System.Drawing.Color.Transparent;
            this.controlBoxFlat1.MaxSizeHoverColor = System.Drawing.Color.Empty;
            this.controlBoxFlat1.MaxSizeText = "⌂";
            this.controlBoxFlat1.MaxSizeTextColor = System.Drawing.Color.Black;
            this.controlBoxFlat1.MiniSize = true;
            this.controlBoxFlat1.MiniSizeColor = System.Drawing.Color.Transparent;
            this.controlBoxFlat1.MiniSizeHoverColor = System.Drawing.Color.Empty;
            this.controlBoxFlat1.MiniSizeText = "–";
            this.controlBoxFlat1.MiniSizeTextColor = System.Drawing.Color.Black;
            this.controlBoxFlat1.Name = "controlBoxFlat1";
            this.controlBoxFlat1.Size = new System.Drawing.Size(892, 28);
            this.controlBoxFlat1.TabIndex = 0;
            this.controlBoxFlat1.TipClose = "Đóng";
            this.controlBoxFlat1.TipMaxsize = "Phóng to";
            this.controlBoxFlat1.TipMaxsize2 = "Khôi phục kích thước";
            this.controlBoxFlat1.TipMinisize = "Thu nhỏ";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 637);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 37);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.webBrowser1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnLayThongTin);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panRight);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(892, 609);
            this.panel2.TabIndex = 2;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(536, 542);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtDuongDan);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(536, 25);
            this.panel3.TabIndex = 4;
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuongDan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDuongDan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDuongDan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDuongDan.Location = new System.Drawing.Point(63, 3);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.Size = new System.Drawing.Size(473, 20);
            this.txtDuongDan.TabIndex = 1;
            this.txtDuongDan.Text = "Đang tải...";
            this.txtDuongDan.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDuongDan_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn:";
            // 
            // btnLayThongTin
            // 
            this.btnLayThongTin.BackColor = System.Drawing.Color.Aqua;
            this.btnLayThongTin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLayThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLayThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayThongTin.ImageIndex = 0;
            this.btnLayThongTin.ImageList = this.imageList1;
            this.btnLayThongTin.Location = new System.Drawing.Point(0, 567);
            this.btnLayThongTin.Name = "btnLayThongTin";
            this.btnLayThongTin.Size = new System.Drawing.Size(536, 40);
            this.btnLayThongTin.TabIndex = 3;
            this.btnLayThongTin.Text = "Lấy thông tin trang này";
            this.btnLayThongTin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLayThongTin.UseVisualStyleBackColor = false;
            this.btnLayThongTin.Click += new System.EventHandler(this.btnLayThongTin_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Info_16x16.png");
            this.imageList1.Images.SetKeyName(1, "CheckBox_16x16.png");
            this.imageList1.Images.SetKeyName(2, "16x16 check gray.png");
            this.imageList1.Images.SetKeyName(3, "16x16 check blue.png");
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(536, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 607);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panRight
            // 
            this.panRight.Controls.Add(this.dataGridViewFlat1);
            this.panRight.Controls.Add(this.panRight_bot);
            this.panRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panRight.Location = new System.Drawing.Point(542, 0);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(348, 607);
            this.panRight.TabIndex = 1;
            // 
            // dataGridViewFlat1
            // 
            this.dataGridViewFlat1.AllowUserToAddRows = false;
            this.dataGridViewFlat1.AutoGenerateColumns = false;
            this.dataGridViewFlat1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFlat1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFlat1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFlat1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFlat1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlat1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.tenHienThiDataGridViewTextBoxColumn,
            this.colUrl,
            this.taiKhoanDataGridViewTextBoxColumn,
            this.cookieDataGridViewTextBoxColumn});
            this.dataGridViewFlat1.DataSource = this.thongTinTaiKhoanBindingSource;
            this.dataGridViewFlat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFlat1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFlat1.MultiSelect = false;
            this.dataGridViewFlat1.Name = "dataGridViewFlat1";
            this.dataGridViewFlat1.ReadOnly = true;
            this.dataGridViewFlat1.RowHeadersVisible = false;
            this.dataGridViewFlat1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFlat1.Size = new System.Drawing.Size(348, 566);
            this.dataGridViewFlat1.TabIndex = 0;
            this.dataGridViewFlat1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewFlat1_KeyUp);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // tenHienThiDataGridViewTextBoxColumn
            // 
            this.tenHienThiDataGridViewTextBoxColumn.DataPropertyName = "TenHienThi";
            this.tenHienThiDataGridViewTextBoxColumn.FillWeight = 100.7498F;
            this.tenHienThiDataGridViewTextBoxColumn.HeaderText = "Tên hiển thị";
            this.tenHienThiDataGridViewTextBoxColumn.Name = "tenHienThiDataGridViewTextBoxColumn";
            this.tenHienThiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colUrl
            // 
            this.colUrl.DataPropertyName = "Url";
            this.colUrl.FillWeight = 97.72733F;
            this.colUrl.HeaderText = "Link";
            this.colUrl.Name = "colUrl";
            this.colUrl.ReadOnly = true;
            // 
            // taiKhoanDataGridViewTextBoxColumn
            // 
            this.taiKhoanDataGridViewTextBoxColumn.DataPropertyName = "TaiKhoan";
            this.taiKhoanDataGridViewTextBoxColumn.HeaderText = "Tài khoản";
            this.taiKhoanDataGridViewTextBoxColumn.Name = "taiKhoanDataGridViewTextBoxColumn";
            this.taiKhoanDataGridViewTextBoxColumn.ReadOnly = true;
            this.taiKhoanDataGridViewTextBoxColumn.Visible = false;
            // 
            // cookieDataGridViewTextBoxColumn
            // 
            this.cookieDataGridViewTextBoxColumn.DataPropertyName = "Cookie";
            this.cookieDataGridViewTextBoxColumn.HeaderText = "Cookie";
            this.cookieDataGridViewTextBoxColumn.Name = "cookieDataGridViewTextBoxColumn";
            this.cookieDataGridViewTextBoxColumn.ReadOnly = true;
            this.cookieDataGridViewTextBoxColumn.Visible = false;
            // 
            // thongTinTaiKhoanBindingSource
            // 
            this.thongTinTaiKhoanBindingSource.DataSource = typeof(AutoSendMessageOnWeb.Data.ThongTinTaiKhoan);
            // 
            // panRight_bot
            // 
            this.panRight_bot.Controls.Add(this.btnXacNhan);
            this.panRight_bot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panRight_bot.Location = new System.Drawing.Point(0, 566);
            this.panRight_bot.Name = "panRight_bot";
            this.panRight_bot.Size = new System.Drawing.Size(348, 41);
            this.panRight_bot.TabIndex = 1;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ImageIndex = 3;
            this.btnXacNhan.ImageList = this.imageList1;
            this.btnXacNhan.Location = new System.Drawing.Point(2, 3);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(91, 36);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // menuLayThongTinTrang
            // 
            this.menuLayThongTinTrang.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemVaoDanhSachDaCo,
            this.btnXoaRoiThem});
            this.menuLayThongTinTrang.Name = "menuLayThongTinTrang";
            this.menuLayThongTinTrang.Size = new System.Drawing.Size(222, 48);
            // 
            // btnThemVaoDanhSachDaCo
            // 
            this.btnThemVaoDanhSachDaCo.Image = global::AutoSendMessageOnWeb.Properties.Resources.add;
            this.btnThemVaoDanhSachDaCo.Name = "btnThemVaoDanhSachDaCo";
            this.btnThemVaoDanhSachDaCo.Size = new System.Drawing.Size(221, 22);
            this.btnThemVaoDanhSachDaCo.Text = "Thêm vào danh sách đã có";
            this.btnThemVaoDanhSachDaCo.Click += new System.EventHandler(this.btnThemVaoDanhSachDaCo_Click);
            // 
            // btnXoaRoiThem
            // 
            this.btnXoaRoiThem.Image = global::AutoSendMessageOnWeb.Properties.Resources.Action_Remove_16x16;
            this.btnXoaRoiThem.Name = "btnXoaRoiThem";
            this.btnXoaRoiThem.Size = new System.Drawing.Size(221, 22);
            this.btnXoaRoiThem.Text = "Xóa thông tin cũ rồi mới lấy";
            this.btnXoaRoiThem.Click += new System.EventHandler(this.btnXoaRoiThem_Click);
            // 
            // frmTimKiemBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(892, 682);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlBoxFlat1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimKiemBrowser";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.frmTimKiemBrowser_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoanBindingSource)).EndInit();
            this.panRight_bot.ResumeLayout(false);
            this.menuLayThongTinTrang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat controlBoxFlat1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panRight;
        private ThuVienWinform.UI.Flat.Data.DataGridViewFlat dataGridViewFlat1;
        private System.Windows.Forms.Panel panRight_bot;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnXacNhan;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.BindingSource thongTinTaiKhoanBindingSource;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnLayThongTin;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel3;
        private ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat txtDuongDan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenHienThiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn taiKhoanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cookieDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip menuLayThongTinTrang;
        private System.Windows.Forms.ToolStripMenuItem btnThemVaoDanhSachDaCo;
        private System.Windows.Forms.ToolStripMenuItem btnXoaRoiThem;
    }
}