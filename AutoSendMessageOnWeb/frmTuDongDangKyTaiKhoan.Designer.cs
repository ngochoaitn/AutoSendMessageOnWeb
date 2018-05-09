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
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtKetQuaCaptcha = new ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXacNhanCaptcha = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.label2 = new System.Windows.Forms.Label();
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            this.btnDangKy = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
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
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
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
            this.mainPanel.Size = new System.Drawing.Size(347, 304);
            this.mainPanel.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(339, 240);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTrangThai);
            this.tabPage1.Controls.Add(this.txtKetQuaCaptcha);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnXacNhanCaptcha);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.picCaptcha);
            this.tabPage1.Controls.Add(this.btnDangKy);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(331, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "henho2";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(185, 125);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(0, 13);
            this.lblTrangThai.TabIndex = 8;
            // 
            // txtKetQuaCaptcha
            // 
            this.txtKetQuaCaptcha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtKetQuaCaptcha.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtKetQuaCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKetQuaCaptcha.Location = new System.Drawing.Point(185, 71);
            this.txtKetQuaCaptcha.Name = "txtKetQuaCaptcha";
            this.txtKetQuaCaptcha.Size = new System.Drawing.Size(138, 20);
            this.txtKetQuaCaptcha.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kết quả captcha:";
            // 
            // btnXacNhanCaptcha
            // 
            this.btnXacNhanCaptcha.BackColor = System.Drawing.Color.Aqua;
            this.btnXacNhanCaptcha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanCaptcha.Location = new System.Drawing.Point(185, 97);
            this.btnXacNhanCaptcha.Name = "btnXacNhanCaptcha";
            this.btnXacNhanCaptcha.Size = new System.Drawing.Size(75, 23);
            this.btnXacNhanCaptcha.TabIndex = 5;
            this.btnXacNhanCaptcha.Text = "Xác nhận";
            this.btnXacNhanCaptcha.UseVisualStyleBackColor = false;
            this.btnXacNhanCaptcha.Click += new System.EventHandler(this.btnXacNhanCaptcha_Click);
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
            // picCaptcha
            // 
            this.picCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCaptcha.Location = new System.Drawing.Point(185, 22);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(138, 30);
            this.picCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCaptcha.TabIndex = 3;
            this.picCaptcha.TabStop = false;
            this.picCaptcha.Click += new System.EventHandler(this.picCaptcha_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.SpringGreen;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Location = new System.Drawing.Point(6, 184);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(75, 23);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "Bắt đầu";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
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
            this.txtEmail.Location = new System.Drawing.Point(6, 22);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(173, 156);
            this.txtEmail.TabIndex = 0;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.infoLabel);
            this.bottomPanel.Controls.Add(this.statusLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.ForeColor = System.Drawing.Color.Black;
            this.bottomPanel.Location = new System.Drawing.Point(3, 274);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(339, 25);
            this.bottomPanel.TabIndex = 3;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.infoLabel.ForeColor = System.Drawing.Color.Black;
            this.infoLabel.Location = new System.Drawing.Point(223, 0);
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
            this.topPanel.Size = new System.Drawing.Size(339, 31);
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
            this.controlBox.Location = new System.Drawing.Point(271, 0);
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
            this.ClientSize = new System.Drawing.Size(349, 309);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTuDongDangKyTaiKhoan";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 2, 5);
            this.Text = "Tự động đăng ký tài khoản";
            this.mainPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
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
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnDangKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picCaptcha;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnXacNhanCaptcha;
        private ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat txtKetQuaCaptcha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTrangThai;
    }
}

