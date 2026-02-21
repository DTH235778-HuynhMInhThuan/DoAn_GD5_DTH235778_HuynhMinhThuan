namespace QuanLyNhaTro.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            menuStrip1 = new MenuStrip();
            menuStrip2 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            mnuQuanLySinhVien = new ToolStripMenuItem();
            mnuQuanLyPhong = new ToolStripMenuItem();
            mnuQuanLyDienNuoc = new ToolStripMenuItem();
            mnuQuanLyHopDong = new ToolStripMenuItem();
            mnuQuanLyHoaDon = new ToolStripMenuItem();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 28);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1039, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, quảnLýToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1039, 28);
            menuStrip2.TabIndex = 2;
            menuStrip2.Text = "menuStrip2";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuDangXuat, mnuDoiMatKhau, mnuThoat });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(88, 24);
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(187, 26);
            mnuDangXuat.Text = "Đăng Xuất ";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuDoiMatKhau
            // 
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Size = new Size(187, 26);
            mnuDoiMatKhau.Text = "Đổi Mật Khẩu ";
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(187, 26);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuQuanLySinhVien, mnuQuanLyPhong, mnuQuanLyDienNuoc, mnuQuanLyHopDong, mnuQuanLyHoaDon });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(79, 24);
            quảnLýToolStripMenuItem.Text = "Quản Lý ";
            // 
            // mnuQuanLySinhVien
            // 
            mnuQuanLySinhVien.Name = "mnuQuanLySinhVien";
            mnuQuanLySinhVien.Size = new Size(223, 26);
            mnuQuanLySinhVien.Text = "Quản Lý Sinh Viên";
            mnuQuanLySinhVien.Click += mnuQuanLySinhVien_Click;
            // 
            // mnuQuanLyPhong
            // 
            mnuQuanLyPhong.Name = "mnuQuanLyPhong";
            mnuQuanLyPhong.Size = new Size(223, 26);
            mnuQuanLyPhong.Text = "Quản Lý Phòng ";
            mnuQuanLyPhong.Click += mnuQuanLyPhong_Click;
            // 
            // mnuQuanLyDienNuoc
            // 
            mnuQuanLyDienNuoc.Name = "mnuQuanLyDienNuoc";
            mnuQuanLyDienNuoc.Size = new Size(223, 26);
            mnuQuanLyDienNuoc.Text = "Quản Lý Điện Nước ";
            mnuQuanLyDienNuoc.Click += mnuQuanLyDienNuoc_Click;
            // 
            // mnuQuanLyHopDong
            // 
            mnuQuanLyHopDong.Name = "mnuQuanLyHopDong";
            mnuQuanLyHopDong.Size = new Size(223, 26);
            mnuQuanLyHopDong.Text = "Quản Lý Hợp Đồng ";
            mnuQuanLyHopDong.Click += mnuQuanLyHopDong_Click;
            // 
            // mnuQuanLyHoaDon
            // 
            mnuQuanLyHoaDon.Name = "mnuQuanLyHoaDon";
            mnuQuanLyHoaDon.Size = new Size(223, 26);
            mnuQuanLyHoaDon.Text = "Quản Lý Hóa Đơn";
            mnuQuanLyHoaDon.Click += mnuQuanLyHoaDon_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1039, 464);
            Controls.Add(menuStrip1);
            Controls.Add(menuStrip2);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang Chính ";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem mnuQuanLySinhVien;
        private ToolStripMenuItem mnuQuanLyPhong;
        private ToolStripMenuItem mnuQuanLyDienNuoc;
        private ToolStripMenuItem mnuQuanLyHopDong;
        private ToolStripMenuItem mnuQuanLyHoaDon;
    }
}