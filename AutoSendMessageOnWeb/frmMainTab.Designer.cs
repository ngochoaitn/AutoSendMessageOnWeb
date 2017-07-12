﻿namespace AutoSendMessageOnWeb
{
    partial class frmMainTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainTab));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabHenHo2 = new System.Windows.Forms.TabPage();
            this.tabDuyenSo = new System.Windows.Forms.TabPage();
            this.controlBoxFlat1 = new ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cAutoHenHo2 = new AutoSendMessageOnWeb.cAuto();
            this.cAutoDuyenSo = new AutoSendMessageOnWeb.cAuto();
            this.tabControl1.SuspendLayout();
            this.tabHenHo2.SuspendLayout();
            this.tabDuyenSo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHenHo2);
            this.tabControl1.Controls.Add(this.tabDuyenSo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(937, 427);
            this.tabControl1.TabIndex = 0;
            // 
            // tabHenHo2
            // 
            this.tabHenHo2.Controls.Add(this.cAutoHenHo2);
            this.tabHenHo2.Location = new System.Drawing.Point(4, 22);
            this.tabHenHo2.Name = "tabHenHo2";
            this.tabHenHo2.Padding = new System.Windows.Forms.Padding(3);
            this.tabHenHo2.Size = new System.Drawing.Size(929, 401);
            this.tabHenHo2.TabIndex = 0;
            this.tabHenHo2.Text = "henho2.com";
            this.tabHenHo2.UseVisualStyleBackColor = true;
            // 
            // tabDuyenSo
            // 
            this.tabDuyenSo.Controls.Add(this.cAutoDuyenSo);
            this.tabDuyenSo.Location = new System.Drawing.Point(4, 22);
            this.tabDuyenSo.Name = "tabDuyenSo";
            this.tabDuyenSo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDuyenSo.Size = new System.Drawing.Size(929, 401);
            this.tabDuyenSo.TabIndex = 1;
            this.tabDuyenSo.Text = "duyenso.com";
            this.tabDuyenSo.UseVisualStyleBackColor = true;
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
            this.controlBoxFlat1.Size = new System.Drawing.Size(939, 28);
            this.controlBoxFlat1.TabIndex = 1;
            this.controlBoxFlat1.TipClose = "Đóng";
            this.controlBoxFlat1.TipMaxsize = "Phóng to";
            this.controlBoxFlat1.TipMaxsize2 = "Khôi phục kích thước";
            this.controlBoxFlat1.TipMinisize = "Thu nhỏ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 457);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 27);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 429);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(829, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "hopdongtinhyeu.com";
            // 
            // cAutoHenHo2
            // 
            this.cAutoHenHo2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cAutoHenHo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cAutoHenHo2.Location = new System.Drawing.Point(3, 3);
            this.cAutoHenHo2.Name = "cAutoHenHo2";
            this.cAutoHenHo2.Size = new System.Drawing.Size(923, 395);
            this.cAutoHenHo2.TabIndex = 0;
            // 
            // cAutoDuyenSo
            // 
            this.cAutoDuyenSo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cAutoDuyenSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cAutoDuyenSo.Location = new System.Drawing.Point(3, 3);
            this.cAutoDuyenSo.Name = "cAutoDuyenSo";
            this.cAutoDuyenSo.Size = new System.Drawing.Size(923, 395);
            this.cAutoDuyenSo.TabIndex = 0;
            // 
            // frmMainTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(939, 494);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlBoxFlat1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainTab";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Text = "Gửi tin nhắn tự động";
            this.Load += new System.EventHandler(this.frmMainTab_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabHenHo2.ResumeLayout(false);
            this.tabDuyenSo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHenHo2;
        private System.Windows.Forms.TabPage tabDuyenSo;
        private ThuVienWinform.UI.Flat.CommonControls.ControlBoxFlat controlBoxFlat1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private cAuto cAutoHenHo2;
        private cAuto cAutoDuyenSo;
        private System.Windows.Forms.Label label1;
    }
}