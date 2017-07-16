namespace AutoSendMessageOnWeb
{
    partial class frmNoiDungCapNhat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoiDungCapNhat));
            this.textBoxFlat1 = new ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat();
            this.btnThoat = new ThuVienWinform.UI.Flat.CommonControls.ButtonFlat();
            this.controlBoxFlat1 = new ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat();
            this.SuspendLayout();
            // 
            // textBoxFlat1
            // 
            this.textBoxFlat1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxFlat1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxFlat1.BackColor = System.Drawing.Color.White;
            this.textBoxFlat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFlat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFlat1.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFlat1.Location = new System.Drawing.Point(0, 28);
            this.textBoxFlat1.Multiline = true;
            this.textBoxFlat1.Name = "textBoxFlat1";
            this.textBoxFlat1.ReadOnly = true;
            this.textBoxFlat1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxFlat1.Size = new System.Drawing.Size(689, 320);
            this.textBoxFlat1.TabIndex = 1;
            this.textBoxFlat1.WordWrap = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Lime;
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(0, 348);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(689, 43);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "OK";
            this.btnThoat.UseVisualStyleBackColor = false;
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
            this.controlBoxFlat1.Size = new System.Drawing.Size(689, 28);
            this.controlBoxFlat1.TabIndex = 0;
            this.controlBoxFlat1.TipClose = "Đóng";
            this.controlBoxFlat1.TipMaxsize = "Phóng to";
            this.controlBoxFlat1.TipMaxsize2 = "Khôi phục kích thước";
            this.controlBoxFlat1.TipMinisize = "Thu nhỏ";
            // 
            // frmNoiDungCapNhat
            // 
            this.AcceptButton = this.btnThoat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 391);
            this.Controls.Add(this.textBoxFlat1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.controlBoxFlat1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNoiDungCapNhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nội dung cập nhật mới";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat controlBoxFlat1;
        private ThuVienWinform.UI.Flat.CommonControls.TextBoxFlat textBoxFlat1;
        private ThuVienWinform.UI.Flat.CommonControls.ButtonFlat btnThoat;
    }
}