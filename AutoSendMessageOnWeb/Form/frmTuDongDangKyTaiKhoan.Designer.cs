namespace AutoSendMessageOnWeb
{
    partial class frmTuDongDangKyTaiKhoan
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.grbDelay = new System.Windows.Forms.GroupBox();
            this.txtThoiGian5 = new System.Windows.Forms.TextBox();
            this.txtThoiGian4 = new System.Windows.Forms.TextBox();
            this.txtThoiGian3 = new System.Windows.Forms.TextBox();
            this.txtThoiGian2 = new System.Windows.Forms.TextBox();
            this.txttThoiGian1 = new System.Windows.Forms.TextBox();
            this.panCaptcha = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.infoLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.btnTienHanhDangKy = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formNameLabel = new System.Windows.Forms.Label();
            this.controlBox = new ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat();
            this.btnTaiCaptcha = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbGioiTinh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.grbDelay.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.label3);
            this.mainPanel.Controls.Add(this.cbbGioiTinh);
            this.mainPanel.Controls.Add(this.grbDelay);
            this.mainPanel.Controls.Add(this.panCaptcha);
            this.mainPanel.Controls.Add(this.label2);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Controls.Add(this.btnTienHanhDangKy);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Controls.Add(this.btnTaiCaptcha);
            this.mainPanel.Controls.Add(this.txtEmail);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.ForeColor = System.Drawing.Color.Black;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mainPanel.Size = new System.Drawing.Size(594, 403);
            this.mainPanel.TabIndex = 0;
            // 
            // grbDelay
            // 
            this.grbDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbDelay.Controls.Add(this.txtThoiGian5);
            this.grbDelay.Controls.Add(this.txtThoiGian4);
            this.grbDelay.Controls.Add(this.txtThoiGian3);
            this.grbDelay.Controls.Add(this.txtThoiGian2);
            this.grbDelay.Controls.Add(this.txttThoiGian1);
            this.grbDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbDelay.Location = new System.Drawing.Point(188, 296);
            this.grbDelay.Name = "grbDelay";
            this.grbDelay.Size = new System.Drawing.Size(398, 42);
            this.grbDelay.TabIndex = 6;
            this.grbDelay.TabStop = false;
            this.grbDelay.Text = "Thời gian chờ lần lượt giữa 2 lần đăng ký";
            // 
            // txtThoiGian5
            // 
            this.txtThoiGian5.Location = new System.Drawing.Point(142, 16);
            this.txtThoiGian5.Name = "txtThoiGian5";
            this.txtThoiGian5.Size = new System.Drawing.Size(28, 20);
            this.txtThoiGian5.TabIndex = 0;
            this.txtThoiGian5.Text = "5";
            // 
            // txtThoiGian4
            // 
            this.txtThoiGian4.Location = new System.Drawing.Point(108, 16);
            this.txtThoiGian4.Name = "txtThoiGian4";
            this.txtThoiGian4.Size = new System.Drawing.Size(28, 20);
            this.txtThoiGian4.TabIndex = 0;
            this.txtThoiGian4.Text = "4";
            // 
            // txtThoiGian3
            // 
            this.txtThoiGian3.Location = new System.Drawing.Point(74, 16);
            this.txtThoiGian3.Name = "txtThoiGian3";
            this.txtThoiGian3.Size = new System.Drawing.Size(28, 20);
            this.txtThoiGian3.TabIndex = 0;
            this.txtThoiGian3.Text = "3";
            // 
            // txtThoiGian2
            // 
            this.txtThoiGian2.Location = new System.Drawing.Point(40, 16);
            this.txtThoiGian2.Name = "txtThoiGian2";
            this.txtThoiGian2.Size = new System.Drawing.Size(28, 20);
            this.txtThoiGian2.TabIndex = 0;
            this.txtThoiGian2.Text = "2";
            // 
            // txttThoiGian1
            // 
            this.txttThoiGian1.Location = new System.Drawing.Point(6, 16);
            this.txttThoiGian1.Name = "txttThoiGian1";
            this.txttThoiGian1.Size = new System.Drawing.Size(28, 20);
            this.txttThoiGian1.TabIndex = 0;
            this.txttThoiGian1.Text = "1";
            // 
            // panCaptcha
            // 
            this.panCaptcha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panCaptcha.AutoScroll = true;
            this.panCaptcha.Location = new System.Drawing.Point(188, 53);
            this.panCaptcha.Name = "panCaptcha";
            this.panCaptcha.Size = new System.Drawing.Size(398, 237);
            this.panCaptcha.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Captcha:";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.infoLabel);
            this.bottomPanel.Controls.Add(this.statusLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.ForeColor = System.Drawing.Color.Black;
            this.bottomPanel.Location = new System.Drawing.Point(3, 373);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(586, 25);
            this.bottomPanel.TabIndex = 3;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.infoLabel.ForeColor = System.Drawing.Color.Black;
            this.infoLabel.Location = new System.Drawing.Point(470, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Padding = new System.Windows.Forms.Padding(5);
            this.infoLabel.Size = new System.Drawing.Size(116, 23);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "hopdongtinhyeu.com";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusLabel.ForeColor = System.Drawing.Color.Black;
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(5);
            this.statusLabel.Size = new System.Drawing.Size(47, 23);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Status";
            // 
            // btnTienHanhDangKy
            // 
            this.btnTienHanhDangKy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTienHanhDangKy.BackColor = System.Drawing.Color.Aquamarine;
            this.btnTienHanhDangKy.Enabled = false;
            this.btnTienHanhDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTienHanhDangKy.Location = new System.Drawing.Point(194, 344);
            this.btnTienHanhDangKy.Name = "btnTienHanhDangKy";
            this.btnTienHanhDangKy.Size = new System.Drawing.Size(118, 23);
            this.btnTienHanhDangKy.TabIndex = 2;
            this.btnTienHanhDangKy.Text = "Tiến hành đăng ký";
            this.btnTienHanhDangKy.UseVisualStyleBackColor = false;
            this.btnTienHanhDangKy.Click += new System.EventHandler(this.btnTienHanhDangKy_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.formNameLabel);
            this.topPanel.Controls.Add(this.controlBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.ForeColor = System.Drawing.Color.Black;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(586, 31);
            this.topPanel.TabIndex = 1;
            // 
            // formNameLabel
            // 
            this.formNameLabel.AutoSize = true;
            this.formNameLabel.ForeColor = System.Drawing.Color.Black;
            this.formNameLabel.Location = new System.Drawing.Point(3, 8);
            this.formNameLabel.Name = "formNameLabel";
            this.formNameLabel.Size = new System.Drawing.Size(94, 13);
            this.formNameLabel.TabIndex = 1;
            this.formNameLabel.Text = "Đăng ký tài khoản";
            // 
            // controlBox
            // 
            this.controlBox.BackColor = System.Drawing.Color.Transparent;
            this.controlBox.CloseColor = System.Drawing.Color.Transparent;
            this.controlBox.CloseHoverColor = System.Drawing.Color.Red;
            this.controlBox.CloseText = "Χ";
            this.controlBox.CloseTextColor = System.Drawing.Color.Black;
            this.controlBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlBox.ForeColor = System.Drawing.Color.Black;
            this.controlBox.FormTextColor = System.Drawing.Color.Black;
            this.controlBox.Location = new System.Drawing.Point(518, 0);
            this.controlBox.MaxSize = true;
            this.controlBox.MaxSizeColor = System.Drawing.Color.Transparent;
            this.controlBox.MaxSizeHoverColor = System.Drawing.Color.Empty;
            this.controlBox.MaxSizeText = "⌂";
            this.controlBox.MaxSizeTextColor = System.Drawing.Color.Black;
            this.controlBox.MiniSize = true;
            this.controlBox.MiniSizeColor = System.Drawing.Color.Transparent;
            this.controlBox.MiniSizeHoverColor = System.Drawing.Color.Empty;
            this.controlBox.MiniSizeText = "–";
            this.controlBox.MiniSizeTextColor = System.Drawing.Color.Black;
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(68, 31);
            this.controlBox.TabIndex = 0;
            this.controlBox.TipClose = "Đóng";
            this.controlBox.TipMaxsize = "Phóng to";
            this.controlBox.TipMaxsize2 = "Khôi phục kích thước";
            this.controlBox.TipMinisize = "Thu nhỏ";
            // 
            // btnTaiCaptcha
            // 
            this.btnTaiCaptcha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTaiCaptcha.BackColor = System.Drawing.Color.SpringGreen;
            this.btnTaiCaptcha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiCaptcha.Location = new System.Drawing.Point(9, 344);
            this.btnTaiCaptcha.Name = "btnTaiCaptcha";
            this.btnTaiCaptcha.Size = new System.Drawing.Size(173, 23);
            this.btnTaiCaptcha.TabIndex = 2;
            this.btnTaiCaptcha.Text = "Tải captcha";
            this.btnTaiCaptcha.UseVisualStyleBackColor = false;
            this.btnTaiCaptcha.Click += new System.EventHandler(this.btnTaiCaptcha_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(9, 53);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(173, 237);
            this.txtEmail.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách email:";
            // 
            // cbbGioiTinh
            // 
            this.cbbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGioiTinh.FormattingEnabled = true;
            this.cbbGioiTinh.Location = new System.Drawing.Point(11, 317);
            this.cbbGioiTinh.Name = "cbbGioiTinh";
            this.cbbGioiTinh.Size = new System.Drawing.Size(171, 21);
            this.cbbGioiTinh.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Giới tính mặc định";
            // 
            // frmTuDongDangKyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(596, 408);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(600, 1080);
            this.Name = "frmTuDongDangKyTaiKhoan";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 2, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tự động đăng ký tài khoản";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.grbDelay.ResumeLayout(false);
            this.grbDelay.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat controlBox;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label formNameLabel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.FlatStyle flatStyle1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnTaiCaptcha;
        private System.Windows.Forms.Label label2;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnTienHanhDangKy;
        private System.Windows.Forms.GroupBox grbDelay;
        private System.Windows.Forms.Panel panCaptcha;
        private System.Windows.Forms.TextBox txtThoiGian5;
        private System.Windows.Forms.TextBox txtThoiGian4;
        private System.Windows.Forms.TextBox txtThoiGian3;
        private System.Windows.Forms.TextBox txtThoiGian2;
        private System.Windows.Forms.TextBox txttThoiGian1;
        private System.Windows.Forms.ComboBox cbbGioiTinh;
        private System.Windows.Forms.Label label3;
    }
}

