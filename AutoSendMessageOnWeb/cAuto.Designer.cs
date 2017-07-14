namespace AutoSendMessageOnWeb
{
    partial class cAuto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cAuto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbTimKiem = new ThuVienWinform.UI.Flat.Containers.GroupBoxFlat();
            this.grvTimKiem = new ThuVienWinform.UI.Flat.Data.DataGridViewFlat();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoiO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhTrangHonNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai_Nhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuGrvTimKiem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToànBộLỗiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaLỗiHàngĐangChọnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongTinTaiKhoan_TimKiemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTrangThaiTimKiem = new System.Windows.Forms.Label();
            this.lblSoLuongKetQua = new System.Windows.Forms.Label();
            this.btnTimKiem = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.iconButtonImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupRight = new System.Windows.Forms.GroupBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.btnGuiTin = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.txtTieuDe = new ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLuuDanhSach = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.txtNoiDung = new ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupLeft = new System.Windows.Forms.GroupBox();
            this.grvGui = new ThuVienWinform.UI.Flat.Data.DataGridViewFlat();
            this.taiKhoanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matKhauDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenHienThiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cookieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoThuSeGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thongTinTaiKhoan_GuiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThemTaiKhoan = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.backgroundWorkerTimKiem = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.grbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvTimKiem)).BeginInit();
            this.menuGrvTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoan_TimKiemBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupRight.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvGui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoan_GuiBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.grbTimKiem);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.groupRight);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.groupLeft);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 411);
            this.panel2.TabIndex = 2;
            // 
            // grbTimKiem
            // 
            this.grbTimKiem.BorderColor = System.Drawing.Color.Empty;
            this.grbTimKiem.Controls.Add(this.grvTimKiem);
            this.grbTimKiem.Controls.Add(this.panel3);
            this.grbTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbTimKiem.Location = new System.Drawing.Point(307, 0);
            this.grbTimKiem.Name = "grbTimKiem";
            this.grbTimKiem.Size = new System.Drawing.Size(411, 411);
            this.grbTimKiem.TabIndex = 2;
            this.grbTimKiem.TabStop = false;
            this.grbTimKiem.Text = "Danh sách người nhận ";
            // 
            // grvTimKiem
            // 
            this.grvTimKiem.AllowUserToAddRows = false;
            this.grvTimKiem.AutoGenerateColumns = false;
            this.grvTimKiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvTimKiem.BackgroundColor = System.Drawing.Color.White;
            this.grvTimKiem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvTimKiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTimKiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.colTuoi,
            this.colGioiTinh,
            this.colNoiO,
            this.colTinhTrangHonNhan,
            this.colUrl,
            this.colTrangThai_Nhan});
            this.grvTimKiem.ContextMenuStrip = this.menuGrvTimKiem;
            this.grvTimKiem.DataSource = this.thongTinTaiKhoan_TimKiemBindingSource;
            this.grvTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvTimKiem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grvTimKiem.Location = new System.Drawing.Point(3, 16);
            this.grvTimKiem.MultiSelect = false;
            this.grvTimKiem.Name = "grvTimKiem";
            this.grvTimKiem.RowHeadersVisible = false;
            this.grvTimKiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvTimKiem.Size = new System.Drawing.Size(405, 367);
            this.grvTimKiem.TabIndex = 1;
            this.grvTimKiem.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grvNhan_CellMouseDoubleClick);
            this.grvTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvTimKiem_KeyDown);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenHienThi";
            this.dataGridViewTextBoxColumn2.FillWeight = 100.7498F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên hiển thị";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // colTuoi
            // 
            this.colTuoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTuoi.DataPropertyName = "Tuoi";
            this.colTuoi.FillWeight = 45F;
            this.colTuoi.HeaderText = "Tuổi";
            this.colTuoi.Name = "colTuoi";
            this.colTuoi.Width = 45;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colGioiTinh.DataPropertyName = "GioiTinh";
            this.colGioiTinh.FillWeight = 45F;
            this.colGioiTinh.HeaderText = "G.Tính";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;
            this.colGioiTinh.Width = 45;
            // 
            // colNoiO
            // 
            this.colNoiO.DataPropertyName = "NoiO";
            this.colNoiO.HeaderText = "Nơi ở";
            this.colNoiO.Name = "colNoiO";
            // 
            // colTinhTrangHonNhan
            // 
            this.colTinhTrangHonNhan.DataPropertyName = "TinhTrangHonNhan";
            this.colTinhTrangHonNhan.HeaderText = "Tình trạng";
            this.colTinhTrangHonNhan.Name = "colTinhTrangHonNhan";
            // 
            // colUrl
            // 
            this.colUrl.DataPropertyName = "Url";
            this.colUrl.FillWeight = 97.72733F;
            this.colUrl.HeaderText = "Link";
            this.colUrl.Name = "colUrl";
            // 
            // colTrangThai_Nhan
            // 
            this.colTrangThai_Nhan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTrangThai_Nhan.DataPropertyName = "TrangThai";
            this.colTrangThai_Nhan.FillWeight = 150F;
            this.colTrangThai_Nhan.HeaderText = "Gửi bởi";
            this.colTrangThai_Nhan.Name = "colTrangThai_Nhan";
            this.colTrangThai_Nhan.ReadOnly = true;
            this.colTrangThai_Nhan.Width = 80;
            // 
            // menuGrvTimKiem
            // 
            this.menuGrvTimKiem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToànBộLỗiToolStripMenuItem,
            this.xóaLỗiHàngĐangChọnToolStripMenuItem});
            this.menuGrvTimKiem.Name = "menuGrvTimKiem";
            this.menuGrvTimKiem.Size = new System.Drawing.Size(224, 48);
            // 
            // xóaToànBộLỗiToolStripMenuItem
            // 
            this.xóaToànBộLỗiToolStripMenuItem.Image = global::AutoSendMessageOnWeb.Properties.Resources._12x12subforum;
            this.xóaToànBộLỗiToolStripMenuItem.Name = "xóaToànBộLỗiToolStripMenuItem";
            this.xóaToànBộLỗiToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.xóaToànBộLỗiToolStripMenuItem.Text = "Xóa toàn bộ lỗi";
            this.xóaToànBộLỗiToolStripMenuItem.ToolTipText = "Xóa toàn bộ các trạng thái lỗi";
            this.xóaToànBộLỗiToolStripMenuItem.Click += new System.EventHandler(this.xóaToànBộLỗiToolStripMenuItem_Click);
            // 
            // xóaLỗiHàngĐangChọnToolStripMenuItem
            // 
            this.xóaLỗiHàngĐangChọnToolStripMenuItem.Image = global::AutoSendMessageOnWeb.Properties.Resources.Action_Remove_16x16;
            this.xóaLỗiHàngĐangChọnToolStripMenuItem.Name = "xóaLỗiHàngĐangChọnToolStripMenuItem";
            this.xóaLỗiHàngĐangChọnToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.xóaLỗiHàngĐangChọnToolStripMenuItem.Text = "Xóa lỗi hàng đang chọn (F2)";
            this.xóaLỗiHàngĐangChọnToolStripMenuItem.ToolTipText = "Xóa trạng thái lỗi của hàng hiện tại";
            this.xóaLỗiHàngĐangChọnToolStripMenuItem.Click += new System.EventHandler(this.xóaLỗiHàngĐangChọnToolStripMenuItem_Click);
            // 
            // thongTinTaiKhoan_TimKiemBindingSource
            // 
            this.thongTinTaiKhoan_TimKiemBindingSource.DataSource = typeof(AutoSendMessageOnWeb.Data.ThongTinTaiKhoan);
            this.thongTinTaiKhoan_TimKiemBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.thongTinTaiKhoan_NhanBindingSource_ListChanged);
            this.thongTinTaiKhoan_TimKiemBindingSource.PositionChanged += new System.EventHandler(this.thongTinTaiKhoan_TimKiemBindingSource_PositionChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTrangThaiTimKiem);
            this.panel3.Controls.Add(this.lblSoLuongKetQua);
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 383);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(405, 25);
            this.panel3.TabIndex = 2;
            // 
            // lblTrangThaiTimKiem
            // 
            this.lblTrangThaiTimKiem.AutoSize = true;
            this.lblTrangThaiTimKiem.Location = new System.Drawing.Point(106, 6);
            this.lblTrangThaiTimKiem.Name = "lblTrangThaiTimKiem";
            this.lblTrangThaiTimKiem.Size = new System.Drawing.Size(0, 13);
            this.lblTrangThaiTimKiem.TabIndex = 2;
            // 
            // lblSoLuongKetQua
            // 
            this.lblSoLuongKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoLuongKetQua.AutoSize = true;
            this.lblSoLuongKetQua.Location = new System.Drawing.Point(278, 6);
            this.lblSoLuongKetQua.Name = "lblSoLuongKetQua";
            this.lblSoLuongKetQua.Size = new System.Drawing.Size(100, 13);
            this.lblSoLuongKetQua.TabIndex = 1;
            this.lblSoLuongKetQua.Text = "Số lượng kết quả: 0";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ImageIndex = 1;
            this.btnTimKiem.ImageList = this.iconButtonImageList;
            this.btnTimKiem.Location = new System.Drawing.Point(2, 1);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(98, 23);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm (F3)";
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // iconButtonImageList
            // 
            this.iconButtonImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconButtonImageList.ImageStream")));
            this.iconButtonImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconButtonImageList.Images.SetKeyName(0, "16x16 1499318962_send.png");
            this.iconButtonImageList.Images.SetKeyName(1, "16x16 search black.png");
            this.iconButtonImageList.Images.SetKeyName(2, "Action_Save_16x16.png");
            this.iconButtonImageList.Images.SetKeyName(3, "editcontact_16x16.png");
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(718, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(6, 411);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // groupRight
            // 
            this.groupRight.Controls.Add(this.lblTrangThai);
            this.groupRight.Controls.Add(this.btnGuiTin);
            this.groupRight.Controls.Add(this.txtTieuDe);
            this.groupRight.Controls.Add(this.lblTieuDe);
            this.groupRight.Controls.Add(this.panel4);
            this.groupRight.Controls.Add(this.txtNoiDung);
            this.groupRight.Controls.Add(this.lblNoiDung);
            this.groupRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupRight.Location = new System.Drawing.Point(724, 0);
            this.groupRight.Name = "groupRight";
            this.groupRight.Size = new System.Drawing.Size(242, 411);
            this.groupRight.TabIndex = 5;
            this.groupRight.TabStop = false;
            this.groupRight.Text = "Thông tin gửi ";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(7, 355);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(0, 13);
            this.lblTrangThai.TabIndex = 1;
            // 
            // btnGuiTin
            // 
            this.btnGuiTin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuiTin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGuiTin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiTin.ImageIndex = 0;
            this.btnGuiTin.ImageList = this.iconButtonImageList;
            this.btnGuiTin.Location = new System.Drawing.Point(10, 319);
            this.btnGuiTin.Name = "btnGuiTin";
            this.btnGuiTin.Size = new System.Drawing.Size(107, 29);
            this.btnGuiTin.TabIndex = 3;
            this.btnGuiTin.Text = "Gửi tin nhắn";
            this.btnGuiTin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuiTin.UseVisualStyleBackColor = false;
            this.btnGuiTin.Click += new System.EventHandler(this.btnGuiTin_Click);
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTieuDe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTieuDe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTieuDe.Location = new System.Drawing.Point(10, 50);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(221, 20);
            this.txtTieuDe.TabIndex = 5;
            this.txtTieuDe.Text = "Xin chào";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(7, 34);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(47, 13);
            this.lblTieuDe.TabIndex = 4;
            this.lblTieuDe.Text = "Tiêu đề:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnLuuDanhSach);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 383);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(236, 25);
            this.panel4.TabIndex = 2;
            // 
            // btnLuuDanhSach
            // 
            this.btnLuuDanhSach.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLuuDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuDanhSach.ImageIndex = 2;
            this.btnLuuDanhSach.ImageList = this.iconButtonImageList;
            this.btnLuuDanhSach.Location = new System.Drawing.Point(5, 1);
            this.btnLuuDanhSach.Name = "btnLuuDanhSach";
            this.btnLuuDanhSach.Size = new System.Drawing.Size(151, 23);
            this.btnLuuDanhSach.TabIndex = 0;
            this.btnLuuDanhSach.Text = "Lưu danh sách (Ctrl + S)";
            this.btnLuuDanhSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuDanhSach.UseVisualStyleBackColor = false;
            this.btnLuuDanhSach.Click += new System.EventHandler(this.btnLuuDanhSach_Click);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiDung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNoiDung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDung.Location = new System.Drawing.Point(10, 97);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(221, 217);
            this.txtNoiDung.TabIndex = 1;
            this.txtNoiDung.Text = "Nội dung";
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(7, 81);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(53, 13);
            this.lblNoiDung.TabIndex = 0;
            this.lblNoiDung.Text = "Nội dung:";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(301, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 411);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // groupLeft
            // 
            this.groupLeft.Controls.Add(this.grvGui);
            this.groupLeft.Controls.Add(this.panel1);
            this.groupLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupLeft.Location = new System.Drawing.Point(0, 0);
            this.groupLeft.Name = "groupLeft";
            this.groupLeft.Size = new System.Drawing.Size(301, 411);
            this.groupLeft.TabIndex = 1;
            this.groupLeft.TabStop = false;
            this.groupLeft.Text = "Tài khoản gửi ";
            // 
            // grvGui
            // 
            this.grvGui.AllowUserToAddRows = false;
            this.grvGui.AutoGenerateColumns = false;
            this.grvGui.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvGui.BackgroundColor = System.Drawing.Color.White;
            this.grvGui.CausesValidation = false;
            this.grvGui.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvGui.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grvGui.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvGui.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taiKhoanDataGridViewTextBoxColumn,
            this.matKhauDataGridViewTextBoxColumn,
            this.tenHienThiDataGridViewTextBoxColumn,
            this.cookieDataGridViewTextBoxColumn,
            this.urlDataGridViewTextBoxColumn,
            this.colSoThuSeGui,
            this.colTrangThai});
            this.grvGui.DataSource = this.thongTinTaiKhoan_GuiBindingSource;
            this.grvGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvGui.Location = new System.Drawing.Point(3, 16);
            this.grvGui.MultiSelect = false;
            this.grvGui.Name = "grvGui";
            this.grvGui.RowHeadersVisible = false;
            this.grvGui.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvGui.Size = new System.Drawing.Size(295, 367);
            this.grvGui.TabIndex = 0;
            this.grvGui.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvGui_CellValueChanged);
            // 
            // taiKhoanDataGridViewTextBoxColumn
            // 
            this.taiKhoanDataGridViewTextBoxColumn.DataPropertyName = "TaiKhoan";
            this.taiKhoanDataGridViewTextBoxColumn.HeaderText = "Tài khoản";
            this.taiKhoanDataGridViewTextBoxColumn.Name = "taiKhoanDataGridViewTextBoxColumn";
            // 
            // matKhauDataGridViewTextBoxColumn
            // 
            this.matKhauDataGridViewTextBoxColumn.DataPropertyName = "MatKhau";
            this.matKhauDataGridViewTextBoxColumn.HeaderText = "Mật khẩu";
            this.matKhauDataGridViewTextBoxColumn.Name = "matKhauDataGridViewTextBoxColumn";
            // 
            // tenHienThiDataGridViewTextBoxColumn
            // 
            this.tenHienThiDataGridViewTextBoxColumn.DataPropertyName = "TenHienThi";
            this.tenHienThiDataGridViewTextBoxColumn.HeaderText = "TenHienThi";
            this.tenHienThiDataGridViewTextBoxColumn.Name = "tenHienThiDataGridViewTextBoxColumn";
            this.tenHienThiDataGridViewTextBoxColumn.Visible = false;
            // 
            // cookieDataGridViewTextBoxColumn
            // 
            this.cookieDataGridViewTextBoxColumn.DataPropertyName = "Cookie";
            this.cookieDataGridViewTextBoxColumn.HeaderText = "Cookie";
            this.cookieDataGridViewTextBoxColumn.Name = "cookieDataGridViewTextBoxColumn";
            this.cookieDataGridViewTextBoxColumn.Visible = false;
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            this.urlDataGridViewTextBoxColumn.Visible = false;
            // 
            // colSoThuSeGui
            // 
            this.colSoThuSeGui.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSoThuSeGui.DataPropertyName = "SoThuSeGui";
            this.colSoThuSeGui.FillWeight = 65F;
            this.colSoThuSeGui.HeaderText = "SL gửi";
            this.colSoThuSeGui.Name = "colSoThuSeGui";
            this.colSoThuSeGui.ToolTipText = "Số lượng thư sẽ gửi";
            this.colSoThuSeGui.Width = 65;
            // 
            // colTrangThai
            // 
            this.colTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            // 
            // thongTinTaiKhoan_GuiBindingSource
            // 
            this.thongTinTaiKhoan_GuiBindingSource.DataSource = typeof(AutoSendMessageOnWeb.Data.ThongTinTaiKhoan);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThemTaiKhoan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 25);
            this.panel1.TabIndex = 1;
            // 
            // btnThemTaiKhoan
            // 
            this.btnThemTaiKhoan.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnThemTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemTaiKhoan.ImageIndex = 3;
            this.btnThemTaiKhoan.ImageList = this.iconButtonImageList;
            this.btnThemTaiKhoan.Location = new System.Drawing.Point(3, 1);
            this.btnThemTaiKhoan.Name = "btnThemTaiKhoan";
            this.btnThemTaiKhoan.Size = new System.Drawing.Size(159, 23);
            this.btnThemTaiKhoan.TabIndex = 3;
            this.btnThemTaiKhoan.Text = "Thêm tài khoản (Ctrl + N)";
            this.btnThemTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemTaiKhoan.UseVisualStyleBackColor = false;
            this.btnThemTaiKhoan.Click += new System.EventHandler(this.btnThemTaiKhoan_Click);
            // 
            // backgroundWorkerTimKiem
            // 
            this.backgroundWorkerTimKiem.WorkerSupportsCancellation = true;
            this.backgroundWorkerTimKiem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTimKiem_DoWork);
            this.backgroundWorkerTimKiem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTimKiem_RunWorkerCompleted);
            // 
            // cAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.panel2);
            this.Name = "cAuto";
            this.Size = new System.Drawing.Size(966, 411);
            this.panel2.ResumeLayout(false);
            this.grbTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvTimKiem)).EndInit();
            this.menuGrvTimKiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoan_TimKiemBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupRight.ResumeLayout(false);
            this.groupRight.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvGui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoan_GuiBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnTimKiem;
        private System.Windows.Forms.GroupBox groupLeft;
        private ThuVienWinform.UI.Flat.Data.DataGridViewFlat grvGui;
        private System.Windows.Forms.BindingSource thongTinTaiKhoan_TimKiemBindingSource;
        private ThuVienWinform.UI.Flat.Containers.GroupBoxFlat grbTimKiem;
        private ThuVienWinform.UI.Flat.Data.DataGridViewFlat grvTimKiem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource thongTinTaiKhoan_GuiBindingSource;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupRight;
        private ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat txtNoiDung;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Panel panel4;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnGuiTin;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnLuuDanhSach;
        private ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat txtTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.ImageList iconButtonImageList;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblSoLuongKetQua;
        private System.Windows.Forms.Label lblTrangThaiTimKiem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn taiKhoanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matKhauDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenHienThiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cookieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoThuSeGui;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoiO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhTrangHonNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai_Nhan;
        private System.Windows.Forms.Panel panel1;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnThemTaiKhoan;
        private System.Windows.Forms.ContextMenuStrip menuGrvTimKiem;
        private System.Windows.Forms.ToolStripMenuItem xóaToànBộLỗiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaLỗiHàngĐangChọnToolStripMenuItem;
    }
}