namespace AutoSendMessageOnWeb.Lib.ThaoTacWeb
{
    partial class frmTimKiem
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
            this.controlBoxFlat1 = new ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat();
            this.panBot = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panMid = new System.Windows.Forms.Panel();
            this.btnTimKiem = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.cbbNoiO = new System.Windows.Forms.ComboBox();
            this.numTuTuoi = new System.Windows.Forms.NumericUpDown();
            this.numDenTuoi = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTinhTrangHonNhan = new ThuVienWinform.UI.Flat.CommonControls.CheckedComboBox();
            this.panBot.SuspendLayout();
            this.panMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTuTuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDenTuoi)).BeginInit();
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
            this.controlBoxFlat1.Size = new System.Drawing.Size(314, 28);
            this.controlBoxFlat1.TabIndex = 0;
            this.controlBoxFlat1.TipClose = "Đóng";
            this.controlBoxFlat1.TipMaxsize = "Phóng to";
            this.controlBoxFlat1.TipMaxsize2 = "Khôi phục kích thước";
            this.controlBoxFlat1.TipMinisize = "Thu nhỏ";
            // 
            // panBot
            // 
            this.panBot.Controls.Add(this.label3);
            this.panBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBot.Location = new System.Drawing.Point(0, 166);
            this.panBot.Name = "panBot";
            this.panBot.Size = new System.Drawing.Size(314, 29);
            this.panBot.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(225, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ThuVienWinform";
            // 
            // panMid
            // 
            this.panMid.BackColor = System.Drawing.Color.White;
            this.panMid.Controls.Add(this.cbbTinhTrangHonNhan);
            this.panMid.Controls.Add(this.btnTimKiem);
            this.panMid.Controls.Add(this.cbbNoiO);
            this.panMid.Controls.Add(this.numTuTuoi);
            this.panMid.Controls.Add(this.numDenTuoi);
            this.panMid.Controls.Add(this.label5);
            this.panMid.Controls.Add(this.label4);
            this.panMid.Controls.Add(this.label2);
            this.panMid.Controls.Add(this.label1);
            this.panMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMid.Location = new System.Drawing.Point(0, 28);
            this.panMid.Name = "panMid";
            this.panMid.Size = new System.Drawing.Size(314, 138);
            this.panMid.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Location = new System.Drawing.Point(124, 107);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cbbNoiO
            // 
            this.cbbNoiO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNoiO.FormattingEnabled = true;
            this.cbbNoiO.Location = new System.Drawing.Point(124, 49);
            this.cbbNoiO.Name = "cbbNoiO";
            this.cbbNoiO.Size = new System.Drawing.Size(166, 21);
            this.cbbNoiO.TabIndex = 8;
            // 
            // numTuTuoi
            // 
            this.numTuTuoi.Location = new System.Drawing.Point(124, 19);
            this.numTuTuoi.Name = "numTuTuoi";
            this.numTuTuoi.Size = new System.Drawing.Size(40, 20);
            this.numTuTuoi.TabIndex = 6;
            this.numTuTuoi.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // numDenTuoi
            // 
            this.numDenTuoi.Location = new System.Drawing.Point(250, 22);
            this.numDenTuoi.Name = "numDenTuoi";
            this.numDenTuoi.Size = new System.Drawing.Size(40, 20);
            this.numDenTuoi.TabIndex = 7;
            this.numDenTuoi.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đến tuổi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tình trạng hôn nhân:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nơi ở:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tuổi:";
            // 
            // cbbTinhTrangHonNhan
            // 
            this.cbbTinhTrangHonNhan.CheckOnClick = true;
            this.cbbTinhTrangHonNhan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbTinhTrangHonNhan.DropDownHeight = 1;
            this.cbbTinhTrangHonNhan.FormattingEnabled = true;
            this.cbbTinhTrangHonNhan.IntegralHeight = false;
            this.cbbTinhTrangHonNhan.Location = new System.Drawing.Point(123, 80);
            this.cbbTinhTrangHonNhan.Name = "cbbTinhTrangHonNhan";
            this.cbbTinhTrangHonNhan.Size = new System.Drawing.Size(167, 21);
            this.cbbTinhTrangHonNhan.TabIndex = 11;
            this.cbbTinhTrangHonNhan.ValueMember = "TenTinhTrang";
            this.cbbTinhTrangHonNhan.ValueSeparator = ", ";
            // 
            // frmTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(314, 195);
            this.Controls.Add(this.panMid);
            this.Controls.Add(this.panBot);
            this.Controls.Add(this.controlBoxFlat1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm";
            this.panBot.ResumeLayout(false);
            this.panBot.PerformLayout();
            this.panMid.ResumeLayout(false);
            this.panMid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTuTuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDenTuoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat controlBoxFlat1;
        private System.Windows.Forms.Panel panBot;
        private System.Windows.Forms.Panel panMid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTuTuoi;
        private System.Windows.Forms.NumericUpDown numDenTuoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbNoiO;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnTimKiem;
        private ThuVienWinform.UI.Flat.CommonControls.CheckedComboBox cbbTinhTrangHonNhan;
    }
}