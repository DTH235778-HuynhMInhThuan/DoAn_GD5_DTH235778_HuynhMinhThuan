namespace QuanLyNhaTro.Forms
{
    partial class frmHopDong
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            cboTrangThai = new ComboBox();
            label7 = new Label();
            dtpNgayKetThuc = new DateTimePicker();
            dtpNgayBatDau = new DateTimePicker();
            label6 = new Label();
            cboSinhVien = new ComboBox();
            nmTienCoc = new NumericUpDown();
            label2 = new Label();
            cboPhong = new ComboBox();
            btnThoat = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            txtMaHopDong = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvHopDong = new DataGridView();
            colMaHopDong = new DataGridViewTextBoxColumn();
            colSinhVien = new DataGridViewTextBoxColumn();
            colPhong = new DataGridViewTextBoxColumn();
            colNgayBatDau = new DataGridViewTextBoxColumn();
            colNgayKetThuc = new DataGridViewTextBoxColumn();
            colTienCoc = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            btnInHopDong = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmTienCoc).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnInHopDong);
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(dtpNgayKetThuc);
            groupBox1.Controls.Add(dtpNgayBatDau);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cboSinhVien);
            groupBox1.Controls.Add(nmTienCoc);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboPhong);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuy);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtMaHopDong);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1059, 195);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Hợp Đồng";
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(424, 115);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 28);
            cboTrangThai.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(337, 118);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 38;
            label7.Text = "Trạng Thái:";
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.Location = new Point(750, 74);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(250, 27);
            dtpNgayKetThuc.TabIndex = 37;
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.Location = new Point(750, 28);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(250, 27);
            dtpNgayBatDau.TabIndex = 36;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(640, 78);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 35;
            label6.Text = "Ngày Kết Thúc:";
            // 
            // cboSinhVien
            // 
            cboSinhVien.FormattingEnabled = true;
            cboSinhVien.Location = new Point(150, 76);
            cboSinhVien.Name = "cboSinhVien";
            cboSinhVien.Size = new Size(158, 28);
            cboSinhVien.TabIndex = 34;
            // 
            // nmTienCoc
            // 
            nmTienCoc.Location = new Point(425, 76);
            nmTienCoc.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nmTienCoc.Name = "nmTienCoc";
            nmTienCoc.Size = new Size(150, 27);
            nmTienCoc.TabIndex = 33;
            nmTienCoc.ThousandsSeparator = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(640, 32);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 32;
            label2.Text = "Ngày Bắt Đầu:";
            // 
            // cboPhong
            // 
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(424, 29);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(151, 28);
            cboPhong.TabIndex = 31;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(738, 151);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 29;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(591, 151);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 28;
            btnHuy.Text = "Hủy ";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(444, 151);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 27;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(297, 151);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 26;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(150, 151);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 25;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtMaHopDong
            // 
            txtMaHopDong.Location = new Point(150, 32);
            txtMaHopDong.Name = "txtMaHopDong";
            txtMaHopDong.ReadOnly = true;
            txtMaHopDong.Size = new Size(158, 27);
            txtMaHopDong.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(64, 79);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 22;
            label5.Text = "Sinh Viên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(364, 35);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 21;
            label4.Text = "Phòng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(349, 79);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 20;
            label3.Text = "Tiền Cọc:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 35);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 19;
            label1.Text = "Mã Hợp Đồng:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvHopDong);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 195);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1059, 318);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Hợp Đồng";
            // 
            // dgvHopDong
            // 
            dgvHopDong.AllowUserToAddRows = false;
            dgvHopDong.AllowUserToDeleteRows = false;
            dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHopDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHopDong.Columns.AddRange(new DataGridViewColumn[] { colMaHopDong, colSinhVien, colPhong, colNgayBatDau, colNgayKetThuc, colTienCoc, colTrangThai });
            dgvHopDong.Dock = DockStyle.Fill;
            dgvHopDong.Location = new Point(3, 23);
            dgvHopDong.Name = "dgvHopDong";
            dgvHopDong.ReadOnly = true;
            dgvHopDong.RowHeadersWidth = 51;
            dgvHopDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHopDong.Size = new Size(1053, 292);
            dgvHopDong.TabIndex = 1;
            dgvHopDong.CellClick += dgvHopDong_CellClick;
            // 
            // colMaHopDong
            // 
            colMaHopDong.DataPropertyName = "MaHopDong";
            colMaHopDong.HeaderText = "Mã Hợp Đồng";
            colMaHopDong.MinimumWidth = 6;
            colMaHopDong.Name = "colMaHopDong";
            colMaHopDong.ReadOnly = true;
            // 
            // colSinhVien
            // 
            colSinhVien.DataPropertyName = "TenSV";
            colSinhVien.HeaderText = "Sinh Viên";
            colSinhVien.MinimumWidth = 6;
            colSinhVien.Name = "colSinhVien";
            colSinhVien.ReadOnly = true;
            // 
            // colPhong
            // 
            colPhong.DataPropertyName = "TenPhong";
            colPhong.HeaderText = "Phòng";
            colPhong.MinimumWidth = 6;
            colPhong.Name = "colPhong";
            colPhong.ReadOnly = true;
            // 
            // colNgayBatDau
            // 
            colNgayBatDau.DataPropertyName = "NgayBatDau";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            colNgayBatDau.DefaultCellStyle = dataGridViewCellStyle4;
            colNgayBatDau.HeaderText = "Ngày Bắt Đầu";
            colNgayBatDau.MinimumWidth = 6;
            colNgayBatDau.Name = "colNgayBatDau";
            colNgayBatDau.ReadOnly = true;
            // 
            // colNgayKetThuc
            // 
            colNgayKetThuc.DataPropertyName = "NgayKetThuc";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            colNgayKetThuc.DefaultCellStyle = dataGridViewCellStyle5;
            colNgayKetThuc.HeaderText = "Ngày Kết Thúc";
            colNgayKetThuc.MinimumWidth = 6;
            colNgayKetThuc.Name = "colNgayKetThuc";
            colNgayKetThuc.ReadOnly = true;
            // 
            // colTienCoc
            // 
            colTienCoc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTienCoc.DataPropertyName = "TienCoc";
            dataGridViewCellStyle6.Format = "N0";
            colTienCoc.DefaultCellStyle = dataGridViewCellStyle6;
            colTienCoc.HeaderText = "Tiền Cọc ";
            colTienCoc.MinimumWidth = 6;
            colTienCoc.Name = "colTienCoc";
            colTienCoc.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // 
            // btnInHopDong
            // 
            btnInHopDong.Location = new Point(886, 133);
            btnInHopDong.Name = "btnInHopDong";
            btnInHopDong.Size = new Size(124, 47);
            btnInHopDong.TabIndex = 40;
            btnInHopDong.Text = "IN HỢP ĐỒNG";
            btnInHopDong.UseVisualStyleBackColor = true;
            btnInHopDong.Click += btnInHopDong_Click;
            // 
            // frmHopDong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 513);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmHopDong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmHopDong";
            Load += frmHopDong_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmTienCoc).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox cboSinhVien;
        private NumericUpDown nmTienCoc;
        private Label label2;
        private ComboBox cboPhong;
        private Button btnThoat;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThem;
        private TextBox txtMaHopDong;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private DateTimePicker dtpNgayKetThuc;
        private DateTimePicker dtpNgayBatDau;
        private Label label6;
        private ComboBox cboTrangThai;
        private Label label7;
        private DataGridView dgvHopDong;
        private DataGridViewTextBoxColumn colMaHopDong;
        private DataGridViewTextBoxColumn colSinhVien;
        private DataGridViewTextBoxColumn colPhong;
        private DataGridViewTextBoxColumn colNgayBatDau;
        private DataGridViewTextBoxColumn colNgayKetThuc;
        private DataGridViewTextBoxColumn colTienCoc;
        private DataGridViewTextBoxColumn colTrangThai;
        private Button btnInHopDong;
    }
}