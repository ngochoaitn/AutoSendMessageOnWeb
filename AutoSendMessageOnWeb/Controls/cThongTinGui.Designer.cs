namespace AutoSendMessageOnWeb
{
    partial class cThongTinGui
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
            this.txtTieuDe = new ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtNoiDung = new ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.lblStt = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTieuDe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTieuDe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTieuDe.Location = new System.Drawing.Point(6, 41);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(235, 20);
            this.txtTieuDe.TabIndex = 9;
            this.txtTieuDe.Text = "Xin chào";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(3, 25);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(47, 13);
            this.lblTieuDe.TabIndex = 8;
            this.lblTieuDe.Text = "Tiêu đề:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiDung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNoiDung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoiDung.Location = new System.Drawing.Point(6, 67);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNoiDung.Size = new System.Drawing.Size(250, 197);
            this.txtNoiDung.TabIndex = 7;
            this.txtNoiDung.Text = "Nội dung";
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(3, 72);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(53, 13);
            this.lblNoiDung.TabIndex = 6;
            this.lblNoiDung.Text = "Nội dung:";
            // 
            // lblStt
            // 
            this.lblStt.AutoSize = true;
            this.lblStt.Location = new System.Drawing.Point(3, 2);
            this.lblStt.Name = "lblStt";
            this.lblStt.Size = new System.Drawing.Size(59, 13);
            this.lblStt.TabIndex = 10;
            this.lblStt.Text = "Nội dung 1";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.Transparent;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Location = new System.Drawing.Point(231, 1);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(25, 20);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "X";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // cThongTinGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.lblStt);
            this.Controls.Add(this.txtTieuDe);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.lblNoiDung);
            this.Name = "cThongTinGui";
            this.Size = new System.Drawing.Size(259, 266);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat txtTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat txtNoiDung;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.Label lblStt;
        private System.Windows.Forms.Button btnDong;
    }
}
