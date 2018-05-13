namespace QLTV.GUI
{
    partial class frmChinh
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPhieuMuon = new System.Windows.Forms.Button();
            this.btnHocSinh = new System.Windows.Forms.Button();
            this.btnGiaoVien = new System.Windows.Forms.Button();
            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 635);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPhieuMuon);
            this.groupBox1.Controls.Add(this.btnHocSinh);
            this.groupBox1.Controls.Add(this.btnGiaoVien);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 635);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lựa Chọn";
            // 
            // btnPhieuMuon
            // 
            this.btnPhieuMuon.Location = new System.Drawing.Point(3, 139);
            this.btnPhieuMuon.Name = "btnPhieuMuon";
            this.btnPhieuMuon.Size = new System.Drawing.Size(197, 43);
            this.btnPhieuMuon.TabIndex = 2;
            this.btnPhieuMuon.Text = "Phiếu Mượn";
            this.btnPhieuMuon.UseVisualStyleBackColor = true;
            this.btnPhieuMuon.Click += new System.EventHandler(this.btnPhieuMuon_Click);
            // 
            // btnHocSinh
            // 
            this.btnHocSinh.Location = new System.Drawing.Point(3, 90);
            this.btnHocSinh.Name = "btnHocSinh";
            this.btnHocSinh.Size = new System.Drawing.Size(197, 43);
            this.btnHocSinh.TabIndex = 0;
            this.btnHocSinh.Text = "Sách";
            this.btnHocSinh.UseVisualStyleBackColor = true;
            this.btnHocSinh.Click += new System.EventHandler(this.btnHocSinh_Click);
            // 
            // btnGiaoVien
            // 
            this.btnGiaoVien.Location = new System.Drawing.Point(3, 41);
            this.btnGiaoVien.Name = "btnGiaoVien";
            this.btnGiaoVien.Size = new System.Drawing.Size(197, 43);
            this.btnGiaoVien.TabIndex = 0;
            this.btnGiaoVien.Text = "Độc Giả";
            this.btnGiaoVien.UseVisualStyleBackColor = true;
            this.btnGiaoVien.Click += new System.EventHandler(this.btnGiaoVien_Click);
            // 
            // pnlNoiDung
            // 
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(209, 0);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Size = new System.Drawing.Size(938, 635);
            this.pnlNoiDung.TabIndex = 2;
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 635);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.panel1);
            this.Name = "frmChinh";
            this.Text = "frmChinh";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChinh_FormClosing);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPhieuMuon;
        private System.Windows.Forms.Button btnHocSinh;
        private System.Windows.Forms.Button btnGiaoVien;
        private System.Windows.Forms.Panel pnlNoiDung;
    }
}