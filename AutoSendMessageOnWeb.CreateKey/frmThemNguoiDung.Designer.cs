namespace AutoSendMessageOnWeb.CreateKey
{
    partial class frmThemNguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemNguoiDung));
            this.label1 = new System.Windows.Forms.Label();
            this.lblTenMay = new System.Windows.Forms.Label();
            this.lblMAC = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaNguoiDung = new ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat();
            this.btnXacNhan = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.controlBoxFlat1 = new ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã người dùng:";
            // 
            // lblTenMay
            // 
            this.lblTenMay.AutoSize = true;
            this.lblTenMay.Location = new System.Drawing.Point(12, 152);
            this.lblTenMay.Name = "lblTenMay";
            this.lblTenMay.Size = new System.Drawing.Size(48, 13);
            this.lblTenMay.TabIndex = 2;
            this.lblTenMay.Text = "Tên máy";
            // 
            // lblMAC
            // 
            this.lblMAC.AutoSize = true;
            this.lblMAC.Location = new System.Drawing.Point(12, 169);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(30, 13);
            this.lblMAC.TabIndex = 3;
            this.lblMAC.Text = "MAC";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 22);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(347, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ThuVienWinform";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTrangThai);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtMaNguoiDung);
            this.panel2.Controls.Add(this.lblTenMay);
            this.panel2.Controls.Add(this.btnXacNhan);
            this.panel2.Controls.Add(this.lblMAC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 222);
            this.panel2.TabIndex = 7;
            // 
            // txtMaNguoiDung
            // 
            this.txtMaNguoiDung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtMaNguoiDung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMaNguoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaNguoiDung.Location = new System.Drawing.Point(15, 30);
            this.txtMaNguoiDung.Multiline = true;
            this.txtMaNguoiDung.Name = "txtMaNguoiDung";
            this.txtMaNguoiDung.Size = new System.Drawing.Size(409, 96);
            this.txtMaNguoiDung.TabIndex = 1;
            this.txtMaNguoiDung.TextChanged += new System.EventHandler(this.txtMaNguoiDung_TextChanged);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.Transparent;
            this.btnXacNhan.Enabled = false;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Location = new System.Drawing.Point(12, 190);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 23);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
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
            this.controlBoxFlat1.Size = new System.Drawing.Size(436, 28);
            this.controlBoxFlat1.TabIndex = 5;
            this.controlBoxFlat1.TipClose = "Đóng";
            this.controlBoxFlat1.TipMaxsize = "Phóng to";
            this.controlBoxFlat1.TipMaxsize2 = "Khôi phục kích thước";
            this.controlBoxFlat1.TipMinisize = "Thu nhỏ";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(12, 129);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(0, 13);
            this.lblTrangThai.TabIndex = 5;
            // 
            // frmThemNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 272);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlBoxFlat1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThemNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm người dùng";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat txtMaNguoiDung;
        private System.Windows.Forms.Label lblTenMay;
        private System.Windows.Forms.Label lblMAC;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnXacNhan;
        private ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat controlBoxFlat1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTrangThai;
    }
}