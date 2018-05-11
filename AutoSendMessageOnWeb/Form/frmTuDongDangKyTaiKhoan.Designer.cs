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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grbDelay = new System.Windows.Forms.GroupBox();
            this.rad12phut = new System.Windows.Forms.RadioButton();
            this.rad70phut = new System.Windows.Forms.RadioButton();
            this.rad60phut = new System.Windows.Forms.RadioButton();
            this.rad3phut = new System.Windows.Forms.RadioButton();
            this.rad1phut = new System.Windows.Forms.RadioButton();
            this.panCaptcha = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTienHanhDangKy = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.btnTaiCaptcha = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.infoLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.formNameLabel = new System.Windows.Forms.Label();
            this.controlBox = new ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat();
            this.mainPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grbDelay.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.tabControl1);
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.ForeColor = System.Drawing.Color.Black;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(3);
            this.mainPanel.Size = new System.Drawing.Size(521, 468);
            this.mainPanel.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(513, 404);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grbDelay);
            this.tabPage1.Controls.Add(this.panCaptcha);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnTienHanhDangKy);
            this.tabPage1.Controls.Add(this.btnTaiCaptcha);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(505, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "henho2";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grbDelay
            // 
            this.grbDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbDelay.Controls.Add(this.rad12phut);
            this.grbDelay.Controls.Add(this.rad70phut);
            this.grbDelay.Controls.Add(this.rad60phut);
            this.grbDelay.Controls.Add(this.rad3phut);
            this.grbDelay.Controls.Add(this.rad1phut);
            this.grbDelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbDelay.Location = new System.Drawing.Point(185, 301);
            this.grbDelay.Name = "grbDelay";
            this.grbDelay.Size = new System.Drawing.Size(314, 42);
            this.grbDelay.TabIndex = 6;
            this.grbDelay.TabStop = false;
            this.grbDelay.Text = "Thời gian chờ giữa 2 lần đăng ký";
            // 
            // rad12phut
            // 
            this.rad12phut.AutoSize = true;
            this.rad12phut.Location = new System.Drawing.Point(247, 20);
            this.rad12phut.Name = "rad12phut";
            this.rad12phut.Size = new System.Drawing.Size(61, 17);
            this.rad12phut.TabIndex = 4;
            this.rad12phut.TabStop = true;
            this.rad12phut.Tag = "12";
            this.rad12phut.Text = "12 phút";
            this.rad12phut.UseVisualStyleBackColor = true;
            // 
            // rad70phut
            // 
            this.rad70phut.AutoSize = true;
            this.rad70phut.Location = new System.Drawing.Point(185, 20);
            this.rad70phut.Name = "rad70phut";
            this.rad70phut.Size = new System.Drawing.Size(61, 17);
            this.rad70phut.TabIndex = 3;
            this.rad70phut.TabStop = true;
            this.rad70phut.Tag = "70";
            this.rad70phut.Text = "70 phút";
            this.rad70phut.UseVisualStyleBackColor = true;
            // 
            // rad60phut
            // 
            this.rad60phut.AutoSize = true;
            this.rad60phut.Location = new System.Drawing.Point(124, 20);
            this.rad60phut.Name = "rad60phut";
            this.rad60phut.Size = new System.Drawing.Size(61, 17);
            this.rad60phut.TabIndex = 2;
            this.rad60phut.TabStop = true;
            this.rad60phut.Tag = "60";
            this.rad60phut.Text = "60 phút";
            this.rad60phut.UseVisualStyleBackColor = true;
            // 
            // rad3phut
            // 
            this.rad3phut.AutoSize = true;
            this.rad3phut.Location = new System.Drawing.Point(64, 20);
            this.rad3phut.Name = "rad3phut";
            this.rad3phut.Size = new System.Drawing.Size(55, 17);
            this.rad3phut.TabIndex = 1;
            this.rad3phut.TabStop = true;
            this.rad3phut.Tag = "3";
            this.rad3phut.Text = "3 phút";
            this.rad3phut.UseVisualStyleBackColor = true;
            // 
            // rad1phut
            // 
            this.rad1phut.AutoSize = true;
            this.rad1phut.Checked = true;
            this.rad1phut.Location = new System.Drawing.Point(7, 20);
            this.rad1phut.Name = "rad1phut";
            this.rad1phut.Size = new System.Drawing.Size(55, 17);
            this.rad1phut.TabIndex = 0;
            this.rad1phut.TabStop = true;
            this.rad1phut.Tag = "1";
            this.rad1phut.Text = "1 phút";
            this.rad1phut.UseVisualStyleBackColor = true;
            // 
            // panCaptcha
            // 
            this.panCaptcha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panCaptcha.AutoScroll = true;
            this.panCaptcha.Location = new System.Drawing.Point(185, 22);
            this.panCaptcha.Name = "panCaptcha";
            this.panCaptcha.Size = new System.Drawing.Size(314, 273);
            this.panCaptcha.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Captcha:";
            // 
            // btnTienHanhDangKy
            // 
            this.btnTienHanhDangKy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTienHanhDangKy.BackColor = System.Drawing.Color.Aquamarine;
            this.btnTienHanhDangKy.Enabled = false;
            this.btnTienHanhDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTienHanhDangKy.Location = new System.Drawing.Point(185, 349);
            this.btnTienHanhDangKy.Name = "btnTienHanhDangKy";
            this.btnTienHanhDangKy.Size = new System.Drawing.Size(118, 23);
            this.btnTienHanhDangKy.TabIndex = 2;
            this.btnTienHanhDangKy.Text = "Tiến hành đăng ký";
            this.btnTienHanhDangKy.UseVisualStyleBackColor = false;
            this.btnTienHanhDangKy.Click += new System.EventHandler(this.btnTienHanhDangKy_Click);
            // 
            // btnTaiCaptcha
            // 
            this.btnTaiCaptcha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTaiCaptcha.BackColor = System.Drawing.Color.SpringGreen;
            this.btnTaiCaptcha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiCaptcha.Location = new System.Drawing.Point(6, 349);
            this.btnTaiCaptcha.Name = "btnTaiCaptcha";
            this.btnTaiCaptcha.Size = new System.Drawing.Size(75, 23);
            this.btnTaiCaptcha.TabIndex = 2;
            this.btnTaiCaptcha.Text = "Tải captcha";
            this.btnTaiCaptcha.UseVisualStyleBackColor = false;
            this.btnTaiCaptcha.Click += new System.EventHandler(this.btnTaiCaptcha_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(6, 22);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(173, 321);
            this.txtEmail.TabIndex = 0;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.infoLabel);
            this.bottomPanel.Controls.Add(this.statusLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.ForeColor = System.Drawing.Color.Black;
            this.bottomPanel.Location = new System.Drawing.Point(3, 438);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(513, 25);
            this.bottomPanel.TabIndex = 3;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.infoLabel.ForeColor = System.Drawing.Color.Black;
            this.infoLabel.Location = new System.Drawing.Point(397, 0);
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
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.formNameLabel);
            this.topPanel.Controls.Add(this.controlBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.ForeColor = System.Drawing.Color.Black;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(513, 31);
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
            this.controlBox.Location = new System.Drawing.Point(445, 0);
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
            // frmTuDongDangKyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(523, 473);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(600, 1080);
            this.Name = "frmTuDongDangKyTaiKhoan";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 2, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tự động đăng ký tài khoản";
            this.mainPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnTaiCaptcha;
        private System.Windows.Forms.Label label2;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnTienHanhDangKy;
        private System.Windows.Forms.GroupBox grbDelay;
        private System.Windows.Forms.RadioButton rad70phut;
        private System.Windows.Forms.RadioButton rad60phut;
        private System.Windows.Forms.RadioButton rad3phut;
        private System.Windows.Forms.RadioButton rad1phut;
        private System.Windows.Forms.RadioButton rad12phut;
        private System.Windows.Forms.Panel panCaptcha;
    }
}

