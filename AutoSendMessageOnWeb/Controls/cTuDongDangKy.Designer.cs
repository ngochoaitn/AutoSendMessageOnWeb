namespace AutoSendMessageOnWeb.Controls
{
    partial class cTuDongDangKy
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtKetQuaCaptcha = new ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTaiKhoan = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKetQuaCaptcha
            // 
            this.txtKetQuaCaptcha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtKetQuaCaptcha.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtKetQuaCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKetQuaCaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetQuaCaptcha.Location = new System.Drawing.Point(161, 36);
            this.txtKetQuaCaptcha.Name = "txtKetQuaCaptcha";
            this.txtKetQuaCaptcha.Size = new System.Drawing.Size(86, 30);
            this.txtKetQuaCaptcha.TabIndex = 12;
            this.txtKetQuaCaptcha.TextChanged += new System.EventHandler(this.txtKetQuaCaptcha_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kết quả captcha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Captcha:";
            // 
            // picCaptcha
            // 
            this.picCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCaptcha.Location = new System.Drawing.Point(3, 36);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(138, 30);
            this.picCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCaptcha.TabIndex = 8;
            this.picCaptcha.TabStop = false;
            this.picCaptcha.Click += new System.EventHandler(this.picCaptcha_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(3, 69);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(55, 13);
            this.lblTrangThai.TabIndex = 13;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.AutoSize = true;
            this.lblTaiKhoan.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblTaiKhoan.Location = new System.Drawing.Point(-3, 0);
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(55, 13);
            this.lblTaiKhoan.TabIndex = 13;
            this.lblTaiKhoan.Text = "Tài khoản";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 1);
            this.panel1.TabIndex = 14;
            // 
            // cTuDongDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTaiKhoan);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtKetQuaCaptcha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picCaptcha);
            this.Name = "cTuDongDangKy";
            this.Size = new System.Drawing.Size(251, 87);
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat txtKetQuaCaptcha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picCaptcha;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTaiKhoan;
        private System.Windows.Forms.Panel panel1;
    }
}
