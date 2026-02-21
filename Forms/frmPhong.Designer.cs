namespace QuanLyNhaTro.Forms
{
    partial class frmPhong
    {
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.TextBox txtTenPhong;
        // Nếu các nút bấm cũng bị lỗi thì thêm vào:
        // private System.Windows.Forms.Button btnThem;
        // private System.Windows.Forms.Button btnXoa;
        // ...
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
            btnThoat = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            txtTenPhong = new TextBox();
            txtMaPhong = new TextBox();
            dgvPhong = new DataGridView();
            colMaPhong = new DataGridViewTextBoxColumn();
            colTenPhong = new DataGridViewTextBoxColumn();
            colGiaPhong = new DataGridViewTextBoxColumn();
            colSoNguoi = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            nmSoNguoiToiDa = new NumericUpDown();
            label2 = new Label();
            cboTrangThai = new ComboBox();
            nmGiaPhong = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoNguoiToiDa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmGiaPhong).BeginInit();
            SuspendLayout();
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
            // txtTenPhong
            // 
            txtTenPhong.Location = new Point(138, 81);
            txtTenPhong.Name = "txtTenPhong";
            txtTenPhong.Size = new Size(125, 27);
            txtTenPhong.TabIndex = 6;
            // 
            // txtMaPhong
            // 
            txtMaPhong.Location = new Point(138, 34);
            txtMaPhong.Name = "txtMaPhong";
            txtMaPhong.ReadOnly = true;
            txtMaPhong.Size = new Size(125, 27);
            txtMaPhong.TabIndex = 5;
            // 
            // dgvPhong
            // 
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.AllowUserToDeleteRows = false;
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhong.Columns.AddRange(new DataGridViewColumn[] { colMaPhong, colTenPhong, colGiaPhong, colSoNguoi, colTrangThai });
            dgvPhong.Dock = DockStyle.Fill;
            dgvPhong.Location = new Point(3, 23);
            dgvPhong.Name = "dgvPhong";
            dgvPhong.ReadOnly = true;
            dgvPhong.RowHeadersWidth = 51;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.Size = new Size(967, 299);
            dgvPhong.TabIndex = 0;
            dgvPhong.CellClick += dgvPhong_CellClick;
            // 
            // colMaPhong
            // 
            colMaPhong.DataPropertyName = "MaPhong";
            colMaPhong.HeaderText = "Mã Phòng";
            colMaPhong.MinimumWidth = 6;
            colMaPhong.Name = "colMaPhong";
            colMaPhong.ReadOnly = true;
            // 
            // colTenPhong
            // 
            colTenPhong.DataPropertyName = "TenPhong";
            colTenPhong.HeaderText = "Tên Phòng";
            colTenPhong.MinimumWidth = 6;
            colTenPhong.Name = "colTenPhong";
            colTenPhong.ReadOnly = true;
            // 
            // colGiaPhong
            // 
            colGiaPhong.DataPropertyName = "GiaPhong";
            dataGridViewCellStyle1.Format = "N0";
            colGiaPhong.DefaultCellStyle = dataGridViewCellStyle1;
            colGiaPhong.HeaderText = "Giá Phòng";
            colGiaPhong.MinimumWidth = 6;
            colGiaPhong.Name = "colGiaPhong";
            colGiaPhong.ReadOnly = true;
            // 
            // colSoNguoi
            // 
            colSoNguoi.DataPropertyName = "SoNguoiToiDa";
            colSoNguoi.HeaderText = "Số Người Tối Đa ";
            colSoNguoi.MinimumWidth = 6;
            colSoNguoi.Name = "colSoNguoi";
            colSoNguoi.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.HeaderText = "Trạng Thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvPhong);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 178);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(973, 325);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Phòng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 88);
            label5.Name = "label5";
            label5.Size = new Size(81, 20);
            label5.TabIndex = 4;
            label5.Text = "Tên Phòng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(324, 44);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 3;
            label4.Text = "Giá phòng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(324, 81);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 2;
            label3.Text = "Trạng Thái:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 40);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã Phòng:";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nmSoNguoiToiDa);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboTrangThai);
            groupBox1.Controls.Add(nmGiaPhong);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuy);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtTenPhong);
            groupBox1.Controls.Add(txtMaPhong);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(973, 178);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Phòng";
            // 
            // nmSoNguoiToiDa
            // 
            nmSoNguoiToiDa.Location = new Point(748, 38);
            nmSoNguoiToiDa.Name = "nmSoNguoiToiDa";
            nmSoNguoiToiDa.Size = new Size(150, 27);
            nmSoNguoiToiDa.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(627, 41);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 17;
            label2.Text = "Số người tối đa:";
            // 
            // cboTrangThai
            // 
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(411, 80);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 28);
            cboTrangThai.TabIndex = 16;
            // 
            // nmGiaPhong
            // 
            nmGiaPhong.Location = new Point(411, 42);
            nmGiaPhong.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nmGiaPhong.Name = "nmGiaPhong";
            nmGiaPhong.Size = new Size(150, 27);
            nmGiaPhong.TabIndex = 15;
            // 
            // frmPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 503);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPhong";
            Activated += frmPhong_Activated;
            Load += frmPhong_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoNguoiToiDa).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmGiaPhong).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnThoat;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThem;
        private TextBox txtQueQuan;
        private TextBox txtCCCD;
        private TextBox txtSDT;
        private TextBox txtTenSV;
        private TextBox txtMaSV;
        private DataGridView dgvPhong;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private GroupBox groupBox1;
        private ComboBox cboTrangThai;
        private NumericUpDown nmGiaPhong;
        private NumericUpDown nmSoNguoiToiDa;
        private Label label2;
        private DataGridViewTextBoxColumn colMaPhong;
        private DataGridViewTextBoxColumn colTenPhong;
        private DataGridViewTextBoxColumn colGiaPhong;
        private DataGridViewTextBoxColumn colSoNguoi;
        private DataGridViewTextBoxColumn colTrangThai;
    }
}