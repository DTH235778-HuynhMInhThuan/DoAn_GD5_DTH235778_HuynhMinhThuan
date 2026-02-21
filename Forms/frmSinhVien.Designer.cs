namespace QuanLyNhaTro.Forms
{
    partial class frmSinhVien
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
            groupBox1 = new GroupBox();
            btnXuatExcel = new Button();
            btnThoat = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            txtQueQuan = new TextBox();
            txtCCCD = new TextBox();
            txtSDT = new TextBox();
            txtTenSV = new TextBox();
            txtMaSV = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvSinhVien = new DataGridView();
            colMaSv = new DataGridViewTextBoxColumn();
            colTenSV = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colCCCD = new DataGridViewTextBoxColumn();
            colQueQuan = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnXuatExcel);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuy);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtQueQuan);
            groupBox1.Controls.Add(txtCCCD);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtTenSV);
            groupBox1.Controls.Add(txtMaSV);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(922, 178);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Sinh Viên";
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.FromArgb(0, 192, 0);
            btnXuatExcel.Location = new Point(749, 76);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(125, 36);
            btnXuatExcel.TabIndex = 15;
            btnXuatExcel.Text = "Xuất EXCEL";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(713, 132);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(569, 132);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 13;
            btnHuy.Text = "Hủy ";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(425, 132);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 12;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(281, 132);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa ";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(137, 132);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtQueQuan
            // 
            txtQueQuan.Location = new Point(749, 37);
            txtQueQuan.Name = "txtQueQuan";
            txtQueQuan.Size = new Size(125, 27);
            txtQueQuan.TabIndex = 9;
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(411, 81);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(125, 27);
            txtCCCD.TabIndex = 8;
            txtCCCD.TextChanged += ChiNhapSo_TextChanged;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(411, 34);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(125, 27);
            txtSDT.TabIndex = 7;
            txtSDT.TextChanged += ChiNhapSo_TextChanged;
            // 
            // txtTenSV
            // 
            txtTenSV.Location = new Point(138, 81);
            txtTenSV.Name = "txtTenSV";
            txtTenSV.Size = new Size(125, 27);
            txtTenSV.TabIndex = 6;
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(138, 34);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.ReadOnly = true;
            txtMaSV.Size = new Size(125, 27);
            txtMaSV.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(65, 81);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 4;
            label5.Text = "Tên SV:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(355, 37);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 3;
            label4.Text = "SĐT:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(355, 81);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "CCCD:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(665, 41);
            label2.Name = "label2";
            label2.Size = new Size(78, 20);
            label2.TabIndex = 1;
            label2.Text = "Quê Quán:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 37);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã SV:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvSinhVien);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 178);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(922, 308);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Sinh Viên";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { colMaSv, colTenSV, colSDT, colCCCD, colQueQuan });
            dgvSinhVien.Dock = DockStyle.Fill;
            dgvSinhVien.Location = new Point(3, 23);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(916, 282);
            dgvSinhVien.TabIndex = 0;
            dgvSinhVien.CellClick += dataGridView_CellClick;
            // 
            // colMaSv
            // 
            colMaSv.DataPropertyName = "MaSV";
            colMaSv.HeaderText = "Mã SV";
            colMaSv.MinimumWidth = 6;
            colMaSv.Name = "colMaSv";
            colMaSv.ReadOnly = true;
            // 
            // colTenSV
            // 
            colTenSV.DataPropertyName = "TenSV";
            colTenSV.HeaderText = "Tên SV";
            colTenSV.MinimumWidth = 6;
            colTenSV.Name = "colTenSV";
            colTenSV.ReadOnly = true;
            // 
            // colSDT
            // 
            colSDT.DataPropertyName = "SDT";
            colSDT.HeaderText = "Số Điện Thoại";
            colSDT.MinimumWidth = 6;
            colSDT.Name = "colSDT";
            colSDT.ReadOnly = true;
            // 
            // colCCCD
            // 
            colCCCD.DataPropertyName = "CCCD";
            colCCCD.HeaderText = "CCCD";
            colCCCD.MinimumWidth = 6;
            colCCCD.Name = "colCCCD";
            colCCCD.ReadOnly = true;
            // 
            // colQueQuan
            // 
            colQueQuan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colQueQuan.DataPropertyName = "QueQuan";
            colQueQuan.HeaderText = "Quê Quán";
            colQueQuan.MinimumWidth = 6;
            colQueQuan.Name = "colQueQuan";
            colQueQuan.ReadOnly = true;
            // 
            // frmSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 486);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SinhVien";
            Load += SinhVien_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtQueQuan;
        private TextBox txtCCCD;
        private TextBox txtSDT;
        private TextBox txtTenSV;
        private TextBox txtMaSV;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnThoat;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThem;
        private GroupBox groupBox2;
        private DataGridView dgvSinhVien;
        private DataGridViewTextBoxColumn colMaSv;
        private DataGridViewTextBoxColumn colTenSV;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colCCCD;
        private DataGridViewTextBoxColumn colQueQuan;
        private Button btnXuatExcel;
    }
}