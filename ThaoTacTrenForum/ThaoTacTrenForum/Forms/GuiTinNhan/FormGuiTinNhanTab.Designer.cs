namespace ThaoTacTrenForum.Forms.GuiTinNhan
{
    partial class FormGuiTinNhanTab
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabWebTreTho = new DevExpress.XtraTab.XtraTabPage();
            this.ucGuiTinNhanWebTreTho = new ThaoTacTrenForum.Controls.GuiTinNhan.UserControlGuiTinNhan();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabWebTreTho.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabWebTreTho;
            this.xtraTabControl1.Size = new System.Drawing.Size(812, 461);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabWebTreTho,
            this.xtraTabPage2});
            // 
            // tabWebTreTho
            // 
            this.tabWebTreTho.Controls.Add(this.ucGuiTinNhanWebTreTho);
            this.tabWebTreTho.Name = "tabWebTreTho";
            this.tabWebTreTho.Size = new System.Drawing.Size(810, 436);
            this.tabWebTreTho.Text = "webtretho";
            // 
            // userControlGuiTinNhan1
            // 
            this.ucGuiTinNhanWebTreTho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGuiTinNhanWebTreTho.Location = new System.Drawing.Point(0, 0);
            this.ucGuiTinNhanWebTreTho.Name = "userControlGuiTinNhan1";
            this.ucGuiTinNhanWebTreTho.Size = new System.Drawing.Size(810, 436);
            this.ucGuiTinNhanWebTreTho.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(810, 436);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // FormGuiTinNhanTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 461);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormGuiTinNhanTab";
            this.Text = "FormGuiTinNhanTab";
            this.Load += new System.EventHandler(this.FormGuiTinNhanTab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabWebTreTho.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabWebTreTho;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private Controls.GuiTinNhan.UserControlGuiTinNhan ucGuiTinNhanWebTreTho;
    }
}