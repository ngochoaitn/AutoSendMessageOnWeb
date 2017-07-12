namespace AutoSendMessageOnWeb
{
    partial class frmAuto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAuto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBoxFlat2 = new ThuVienWinform.UI.Flat.Containers.GroupBoxFlat();
            this.grvNhan = new ThuVienWinform.UI.Flat.Data.DataGridViewFlat();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChoPhepNhan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoiO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhTrangHonNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai_Nhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thongTinTaiKhoan_NhanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTrangThaiTimKiem = new System.Windows.Forms.Label();
            this.lblSoLuongKetQua = new System.Windows.Forms.Label();
            this.btnTimKiem = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.iconButtonImageList = new System.Windows.Forms.ImageList(this.components);
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
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChoPhepGuiNhan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.taiKhoanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matKhauDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenHienThiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cookieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoThuSeGui = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thongTinTaiKhoan_GuiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorkerTimKiem = new System.ComponentModel.BackgroundWorker();
            this.controlBoxFlat1 = new ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxFlat2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoan_NhanBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupRight.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvGui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoan_GuiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 462);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 26);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1018, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "ThuVienWinform";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.groupBoxFlat2);
            this.panel2.Controls.Add(this.groupRight);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.groupLeft);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 434);
            this.panel2.TabIndex = 2;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(797, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(6, 432);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // groupBoxFlat2
            // 
            this.groupBoxFlat2.BorderColor = System.Drawing.Color.Empty;
            this.groupBoxFlat2.Controls.Add(this.grvNhan);
            this.groupBoxFlat2.Controls.Add(this.panel3);
            this.groupBoxFlat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFlat2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxFlat2.Location = new System.Drawing.Point(348, 0);
            this.groupBoxFlat2.Name = "groupBoxFlat2";
            this.groupBoxFlat2.Size = new System.Drawing.Size(455, 432);
            this.groupBoxFlat2.TabIndex = 2;
            this.groupBoxFlat2.TabStop = false;
            this.groupBoxFlat2.Text = "Danh sách người nhận ";
            // 
            // grvNhan
            // 
            this.grvNhan.AllowUserToAddRows = false;
            this.grvNhan.AutoGenerateColumns = false;
            this.grvNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvNhan.BackgroundColor = System.Drawing.Color.White;
            this.grvNhan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvNhan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grvNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvNhan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colChoPhepNhan,
            this.dataGridViewTextBoxColumn2,
            this.colTuoi,
            this.colGioiTinh,
            this.colNoiO,
            this.colTinhTrangHonNhan,
            this.colUrl,
            this.colTrangThai_Nhan});
            this.grvNhan.DataSource = this.thongTinTaiKhoan_NhanBindingSource;
            this.grvNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvNhan.Location = new System.Drawing.Point(3, 16);
            this.grvNhan.MultiSelect = false;
            this.grvNhan.Name = "grvNhan";
            this.grvNhan.RowHeadersVisible = false;
            this.grvNhan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvNhan.Size = new System.Drawing.Size(449, 388);
            this.grvNhan.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // colChoPhepNhan
            // 
            this.colChoPhepNhan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colChoPhepNhan.DataPropertyName = "ChoPhepGuiNhan";
            this.colChoPhepNhan.HeaderText = "Nhận";
            this.colChoPhepNhan.Name = "colChoPhepNhan";
            this.colChoPhepNhan.Visible = false;
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
            // thongTinTaiKhoan_NhanBindingSource
            // 
            this.thongTinTaiKhoan_NhanBindingSource.DataSource = typeof(AutoSendMessageOnWeb.Data.ThongTinTaiKhoan);
            this.thongTinTaiKhoan_NhanBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.thongTinTaiKhoan_NhanBindingSource_ListChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTrangThaiTimKiem);
            this.panel3.Controls.Add(this.lblSoLuongKetQua);
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 404);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(449, 25);
            this.panel3.TabIndex = 2;
            // 
            // lblTrangThaiTimKiem
            // 
            this.lblTrangThaiTimKiem.AutoSize = true;
            this.lblTrangThaiTimKiem.Location = new System.Drawing.Point(84, 6);
            this.lblTrangThaiTimKiem.Name = "lblTrangThaiTimKiem";
            this.lblTrangThaiTimKiem.Size = new System.Drawing.Size(0, 13);
            this.lblTrangThaiTimKiem.TabIndex = 2;
            // 
            // lblSoLuongKetQua
            // 
            this.lblSoLuongKetQua.AutoSize = true;
            this.lblSoLuongKetQua.Location = new System.Drawing.Point(237, 6);
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
            this.btnTimKiem.Location = new System.Drawing.Point(3, 1);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.Text = "Tìm kiếm";
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
            this.groupRight.Location = new System.Drawing.Point(803, 0);
            this.groupRight.Name = "groupRight";
            this.groupRight.Size = new System.Drawing.Size(303, 432);
            this.groupRight.TabIndex = 5;
            this.groupRight.TabStop = false;
            this.groupRight.Text = "Thông tin gửi ";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(14, 285);
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
            this.btnGuiTin.Location = new System.Drawing.Point(10, 250);
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
            this.txtTieuDe.Size = new System.Drawing.Size(282, 20);
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
            this.panel4.Location = new System.Drawing.Point(3, 404);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(297, 25);
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
            this.btnLuuDanhSach.Size = new System.Drawing.Size(124, 23);
            this.btnLuuDanhSach.TabIndex = 0;
            this.btnLuuDanhSach.Text = "Lưu danh sách";
            this.btnLuuDanhSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuDanhSach.UseVisualStyleBackColor = false;
            this.btnLuuDanhSach.Click += new System.EventHandler(this.btnLuuDanhSach_Click);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiDung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNoiDung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDung.Location = new System.Drawing.Point(10, 97);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(282, 147);
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
            this.splitter1.Location = new System.Drawing.Point(342, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 432);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // groupLeft
            // 
            this.groupLeft.Controls.Add(this.grvGui);
            this.groupLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupLeft.Location = new System.Drawing.Point(0, 0);
            this.groupLeft.Name = "groupLeft";
            this.groupLeft.Size = new System.Drawing.Size(342, 432);
            this.groupLeft.TabIndex = 1;
            this.groupLeft.TabStop = false;
            this.groupLeft.Text = "Tài khoản gửi ";
            // 
            // grvGui
            // 
            this.grvGui.AutoGenerateColumns = false;
            this.grvGui.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvGui.BackgroundColor = System.Drawing.Color.White;
            this.grvGui.CausesValidation = false;
            this.grvGui.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvGui.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvGui.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvGui.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.colChoPhepGuiNhan,
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
            this.grvGui.Size = new System.Drawing.Size(336, 413);
            this.grvGui.TabIndex = 0;
            this.grvGui.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvGui_CellValueChanged);
            this.grvGui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grvGui_KeyUp);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // colChoPhepGuiNhan
            // 
            this.colChoPhepGuiNhan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colChoPhepGuiNhan.DataPropertyName = "ChoPhepGuiNhan";
            this.colChoPhepGuiNhan.FillWeight = 30F;
            this.colChoPhepGuiNhan.HeaderText = "Gửi";
            this.colChoPhepGuiNhan.Name = "colChoPhepGuiNhan";
            this.colChoPhepGuiNhan.Visible = false;
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
            this.thongTinTaiKhoan_GuiBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.thongTinTaiKhoan_GuiBindingSource_ListChanged);
            // 
            // backgroundWorkerTimKiem
            // 
            this.backgroundWorkerTimKiem.WorkerSupportsCancellation = true;
            this.backgroundWorkerTimKiem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTimKiem_DoWork);
            this.backgroundWorkerTimKiem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTimKiem_RunWorkerCompleted);
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
            this.controlBoxFlat1.Size = new System.Drawing.Size(1108, 28);
            this.controlBoxFlat1.TabIndex = 0;
            this.controlBoxFlat1.TipClose = "Đóng";
            this.controlBoxFlat1.TipMaxsize = "Phóng to";
            this.controlBoxFlat1.TipMaxsize2 = "Khôi phục kích thước";
            this.controlBoxFlat1.TipMinisize = "Thu nhỏ";
            // 
            // frmAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1108, 498);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlBoxFlat1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAuto";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấu hình gửi tin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBoxFlat2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoan_NhanBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupRight.ResumeLayout(false);
            this.groupRight.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvGui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongTinTaiKhoan_GuiBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat controlBoxFlat1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnTimKiem;
        private System.Windows.Forms.GroupBox groupLeft;
        private ThuVienWinform.UI.Flat.Data.DataGridViewFlat grvGui;
        private System.Windows.Forms.BindingSource thongTinTaiKhoan_NhanBindingSource;
        private ThuVienWinform.UI.Flat.Containers.GroupBoxFlat groupBoxFlat2;
        private ThuVienWinform.UI.Flat.Data.DataGridViewFlat grvNhan;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChoPhepGuiNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn taiKhoanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matKhauDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenHienThiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cookieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoThuSeGui;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.Label lblSoLuongKetQua;
        private System.Windows.Forms.Label lblTrangThaiTimKiem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colChoPhepNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoiO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhTrangHonNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai_Nhan;
    }
}