namespace QuanLyNhaTro.Forms
{
    partial class frmHoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dgvHoaDon = new DataGridView();
            colMaHD = new DataGridViewTextBoxColumn();
            colTenPhong = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            colThang = new DataGridViewTextBoxColumn();
            colNam = new DataGridViewTextBoxColumn();
            colTienPhong = new DataGridViewTextBoxColumn();
            colTienDien = new DataGridViewTextBoxColumn();
            colTienNuoc = new DataGridViewTextBoxColumn();
            colTongTien = new DataGridViewTextBoxColumn();
            cboTrangThai = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            cboPhong = new ComboBox();
            nmThang = new NumericUpDown();
            label2 = new Label();
            btnThoat = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            txtMaHD = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            btnInHoaDon = new Button();
            txtTongTien = new TextBox();
            txtTienNuoc = new TextBox();
            txtTienDien = new TextBox();
            txtTienPhong = new TextBox();
            label9 = new Label();
            label8 = new Label();
            nmNam = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmThang).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmNam).BeginInit();
            SuspendLayout();
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Columns.AddRange(new DataGridViewColumn[] { colMaHD, colTenPhong, colTrangThai, colThang, colNam, colTienPhong, colTienDien, colTienNuoc, colTongTien });
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(3, 23);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(1102, 236);
            dgvHoaDon.TabIndex = 1;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            dgvHoaDon.CellFormatting += dgvHoaDon_CellFormatting;
            // 
            // colMaHD
            // 
            colMaHD.DataPropertyName = "MaHoaDon";
            colMaHD.HeaderText = "Mã Hóa Đơn";
            colMaHD.MinimumWidth = 6;
            colMaHD.Name = "colMaHD";
            colMaHD.ReadOnly = true;
            // 
            // colTenPhong
            // 
            colTenPhong.DataPropertyName = "TenPhong";
            colTenPhong.HeaderText = "Phòng";
            colTenPhong.MinimumWidth = 6;
            colTenPhong.Name = "colTenPhong";
            colTenPhong.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // 
            // colThang
            // 
            colThang.DataPropertyName = "Thang";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            colThang.DefaultCellStyle = dataGridViewCellStyle1;
            colThang.HeaderText = "Tháng";
            colThang.MinimumWidth = 6;
            colThang.Name = "colThang";
            colThang.ReadOnly = true;
            // 
            // colNam
            // 
            colNam.DataPropertyName = "Nam";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            colNam.DefaultCellStyle = dataGridViewCellStyle2;
            colNam.HeaderText = "Năm";
            colNam.MinimumWidth = 6;
            colNam.Name = "colNam";
            colNam.ReadOnly = true;
            // 
            // colTienPhong
            // 
            colTienPhong.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTienPhong.DataPropertyName = "TienPhong";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            colTienPhong.DefaultCellStyle = dataGridViewCellStyle3;
            colTienPhong.HeaderText = "Tiền Phòng";
            colTienPhong.MinimumWidth = 6;
            colTienPhong.Name = "colTienPhong";
            colTienPhong.ReadOnly = true;
            // 
            // colTienDien
            // 
            colTienDien.DataPropertyName = "TienDien";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            colTienDien.DefaultCellStyle = dataGridViewCellStyle4;
            colTienDien.HeaderText = "Tiền Điện";
            colTienDien.MinimumWidth = 6;
            colTienDien.Name = "colTienDien";
            colTienDien.ReadOnly = true;
            // 
            // colTienNuoc
            // 
            colTienNuoc.DataPropertyName = "TienNuoc";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Format = "N0";
            colTienNuoc.DefaultCellStyle = dataGridViewCellStyle5;
            colTienNuoc.HeaderText = "Tiền Nước";
            colTienNuoc.MinimumWidth = 6;
            colTienNuoc.Name = "colTienNuoc";
            colTienNuoc.ReadOnly = true;
            // 
            // colTongTien
            // 
            colTongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            colTongTien.DefaultCellStyle = dataGridViewCellStyle6;
            colTongTien.HeaderText = "Tổng Tiền";
            colTongTien.MinimumWidth = 6;
            colTongTien.Name = "colTongTien";
            colTongTien.ReadOnly = true;
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Chưa thanh toán", "Đã thanh toán" });
            cboTrangThai.Location = new Point(150, 115);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(158, 28);
            cboTrangThai.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(54, 123);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 38;
            label7.Text = "Trạng Thái:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(651, 39);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 35;
            label6.Text = "Tiền Điện:";
            // 
            // cboPhong
            // 
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(150, 76);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(158, 28);
            cboPhong.TabIndex = 34;
            // 
            // nmThang
            // 
            nmThang.Location = new Point(423, 32);
            nmThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nmThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmThang.Name = "nmThang";
            nmThang.Size = new Size(150, 27);
            nmThang.TabIndex = 33;
            nmThang.ThousandsSeparator = true;
            nmThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(331, 118);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 32;
            label2.Text = "Tiền Phòng:";
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
            // txtMaHD
            // 
            txtMaHD.Location = new Point(150, 32);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.ReadOnly = true;
            txtMaHD.Size = new Size(158, 27);
            txtMaHD.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(81, 79);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 22;
            label5.Text = "Phòng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(364, 35);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 21;
            label4.Text = "Tháng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(373, 78);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 20;
            label3.Text = "Năm:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 35);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 19;
            label1.Text = "Mã Hóa Đơn:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvHoaDon);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 193);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1108, 262);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Hóa Đơn";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnInHoaDon);
            groupBox1.Controls.Add(txtTongTien);
            groupBox1.Controls.Add(txtTienNuoc);
            groupBox1.Controls.Add(txtTienDien);
            groupBox1.Controls.Add(txtTienPhong);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(nmNam);
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cboPhong);
            groupBox1.Controls.Add(nmThang);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuy);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtMaHD);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1108, 193);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Hóa Đơn";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.Location = new Point(950, 59);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(94, 62);
            btnInHoaDon.TabIndex = 47;
            btnInHoaDon.Text = "In Hóa Đơn";
            btnInHoaDon.UseVisualStyleBackColor = true;
            btnInHoaDon.Click += btnInHoaDon_Click;
            // 
            // txtTongTien
            // 
            txtTongTien.Location = new Point(732, 116);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(150, 27);
            txtTongTien.TabIndex = 46;
            // 
            // txtTienNuoc
            // 
            txtTienNuoc.Location = new Point(732, 77);
            txtTienNuoc.Name = "txtTienNuoc";
            txtTienNuoc.Size = new Size(150, 27);
            txtTienNuoc.TabIndex = 45;
            // 
            // txtTienDien
            // 
            txtTienDien.Location = new Point(732, 36);
            txtTienDien.Name = "txtTienDien";
            txtTienDien.Size = new Size(150, 27);
            txtTienDien.TabIndex = 44;
            // 
            // txtTienPhong
            // 
            txtTienPhong.Location = new Point(423, 116);
            txtTienPhong.Name = "txtTienPhong";
            txtTienPhong.Size = new Size(150, 27);
            txtTienPhong.TabIndex = 43;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(646, 118);
            label9.Name = "label9";
            label9.Size = new Size(78, 20);
            label9.TabIndex = 42;
            label9.Text = "Tổng Tiền:";
            label9.Click += label9_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(646, 78);
            label8.Name = "label8";
            label8.Size = new Size(80, 20);
            label8.TabIndex = 41;
            label8.Text = "Tiền Nước:";
            label8.Click += label8_Click;
            // 
            // nmNam
            // 
            nmNam.Location = new Point(423, 76);
            nmNam.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nmNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nmNam.Name = "nmNam";
            nmNam.Size = new Size(150, 27);
            nmNam.TabIndex = 40;
            nmNam.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // frmHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 455);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmHoaDon";
            Load += frmHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmThang).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmNam).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHoaDon;
        private ComboBox cboTrangThai;
        private Label label7;
        private Label label6;
        private NumericUpDown nmThang;
        private Label label2;
        private ComboBox cboPhong;
        private Button btnThoat;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThem;
        private TextBox txtMaHD;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label8;
        private NumericUpDown nmNam;
        private Label label9;
        private TextBox txtTongTien;
        private TextBox txtTienNuoc;
        private TextBox txtTienDien;
        private TextBox txtTienPhong;
        private DataGridViewTextBoxColumn colMaHD;
        private DataGridViewTextBoxColumn colTenPhong;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewTextBoxColumn colThang;
        private DataGridViewTextBoxColumn colNam;
        private DataGridViewTextBoxColumn colTienPhong;
        private DataGridViewTextBoxColumn colTienDien;
        private DataGridViewTextBoxColumn colTienNuoc;
        private DataGridViewTextBoxColumn colTongTien;
        private Button btnInHoaDon;
    }
}