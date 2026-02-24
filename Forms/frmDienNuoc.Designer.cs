namespace QuanLyNhaTro.Forms
{
    partial class frmDienNuoc
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
            dgvDienNuoc = new DataGridView();
            colMaDN = new DataGridViewTextBoxColumn();
            colTenPhong = new DataGridViewTextBoxColumn();
            colNgayGhi = new DataGridViewTextBoxColumn();
            colDienCu = new DataGridViewTextBoxColumn();
            colDienMoi = new DataGridViewTextBoxColumn();
            colNuocCu = new DataGridViewTextBoxColumn();
            colNuocMoi = new DataGridViewTextBoxColumn();
            cboPhong = new ComboBox();
            btnThoat = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            txtMaDN = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            nmNuocMoi = new NumericUpDown();
            nmDienMoi = new NumericUpDown();
            nmNuocCu = new NumericUpDown();
            nmDienCu = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            dtpNgayGhi = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvDienNuoc).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmNuocMoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmDienMoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmNuocCu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmDienCu).BeginInit();
            SuspendLayout();
            // 
            // dgvDienNuoc
            // 
            dgvDienNuoc.AllowUserToAddRows = false;
            dgvDienNuoc.AllowUserToDeleteRows = false;
            dgvDienNuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDienNuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDienNuoc.Columns.AddRange(new DataGridViewColumn[] { colMaDN, colTenPhong, colNgayGhi, colDienCu, colDienMoi, colNuocCu, colNuocMoi });
            dgvDienNuoc.Dock = DockStyle.Fill;
            dgvDienNuoc.Location = new Point(3, 23);
            dgvDienNuoc.Name = "dgvDienNuoc";
            dgvDienNuoc.ReadOnly = true;
            dgvDienNuoc.RowHeadersWidth = 51;
            dgvDienNuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDienNuoc.Size = new Size(1031, 237);
            dgvDienNuoc.TabIndex = 1;
            dgvDienNuoc.CellClick += dgvDienNuoc_CellClick;
            // 
            // colMaDN
            // 
            colMaDN.DataPropertyName = "MaDN";
            colMaDN.HeaderText = "Mã Điện Nước ";
            colMaDN.MinimumWidth = 6;
            colMaDN.Name = "colMaDN";
            colMaDN.ReadOnly = true;
            // 
            // colTenPhong
            // 
            colTenPhong.DataPropertyName = "TenPhong";
            colTenPhong.HeaderText = "Phòng";
            colTenPhong.MinimumWidth = 6;
            colTenPhong.Name = "colTenPhong";
            colTenPhong.ReadOnly = true;
            // 
            // colNgayGhi
            // 
            colNgayGhi.DataPropertyName = "NgayGhi";
            colNgayGhi.HeaderText = "Ngày Ghi";
            colNgayGhi.MinimumWidth = 6;
            colNgayGhi.Name = "colNgayGhi";
            colNgayGhi.ReadOnly = true;
            // 
            // colDienCu
            // 
            colDienCu.DataPropertyName = "ChiSoDienCu";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            colDienCu.DefaultCellStyle = dataGridViewCellStyle1;
            colDienCu.HeaderText = "Điện Cũ";
            colDienCu.MinimumWidth = 6;
            colDienCu.Name = "colDienCu";
            colDienCu.ReadOnly = true;
            // 
            // colDienMoi
            // 
            colDienMoi.DataPropertyName = "ChiSoDienMoi";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            colDienMoi.DefaultCellStyle = dataGridViewCellStyle2;
            colDienMoi.HeaderText = "Điện Mới";
            colDienMoi.MinimumWidth = 6;
            colDienMoi.Name = "colDienMoi";
            colDienMoi.ReadOnly = true;
            // 
            // colNuocCu
            // 
            colNuocCu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNuocCu.DataPropertyName = "ChiSoNuocCu";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            colNuocCu.DefaultCellStyle = dataGridViewCellStyle3;
            colNuocCu.HeaderText = "Nước Cũ";
            colNuocCu.MinimumWidth = 6;
            colNuocCu.Name = "colNuocCu";
            colNuocCu.ReadOnly = true;
            // 
            // colNuocMoi
            // 
            colNuocMoi.DataPropertyName = "ChiSoNuocMoi";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            colNuocMoi.DefaultCellStyle = dataGridViewCellStyle4;
            colNuocMoi.HeaderText = "Nước Mới ";
            colNuocMoi.MinimumWidth = 6;
            colNuocMoi.Name = "colNuocMoi";
            colNuocMoi.ReadOnly = true;
            // 
            // cboPhong
            // 
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(138, 80);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(94, 28);
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
            // txtMaDN
            // 
            txtMaDN.Location = new Point(138, 32);
            txtMaDN.Name = "txtMaDN";
            txtMaDN.ReadOnly = true;
            txtMaDN.Size = new Size(94, 27);
            txtMaDN.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 80);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 21;
            label4.Text = "Phòng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(700, 37);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 20;
            label3.Text = "Ngày Ghi:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 35);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 19;
            label1.Text = "Mã Điện Nước:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDienNuoc);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 195);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1037, 263);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Điện Nước";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nmNuocMoi);
            groupBox1.Controls.Add(nmDienMoi);
            groupBox1.Controls.Add(nmNuocCu);
            groupBox1.Controls.Add(nmDienCu);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpNgayGhi);
            groupBox1.Controls.Add(cboPhong);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuy);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtMaDN);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1037, 195);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Điện Nước ";
            // 
            // nmNuocMoi
            // 
            nmNuocMoi.Location = new Point(597, 78);
            nmNuocMoi.Name = "nmNuocMoi";
            nmNuocMoi.Size = new Size(88, 27);
            nmNuocMoi.TabIndex = 48;
            // 
            // nmDienMoi
            // 
            nmDienMoi.Location = new Point(597, 32);
            nmDienMoi.Name = "nmDienMoi";
            nmDienMoi.Size = new Size(88, 27);
            nmDienMoi.TabIndex = 47;
            // 
            // nmNuocCu
            // 
            nmNuocCu.Location = new Point(368, 78);
            nmNuocCu.Name = "nmNuocCu";
            nmNuocCu.Size = new Size(88, 27);
            nmNuocCu.TabIndex = 46;
            // 
            // nmDienCu
            // 
            nmDienCu.Location = new Point(368, 33);
            nmDienCu.Name = "nmDienCu";
            nmDienCu.Size = new Size(88, 27);
            nmDienCu.TabIndex = 45;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(252, 83);
            label7.Name = "label7";
            label7.Size = new Size(119, 20);
            label7.TabIndex = 44;
            label7.Text = "Chỉ Số Nước Cũ: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(472, 37);
            label6.Name = "label6";
            label6.Size = new Size(119, 20);
            label6.TabIndex = 43;
            label6.Text = "Chỉ Số Điện Mới:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(472, 83);
            label5.Name = "label5";
            label5.Size = new Size(124, 20);
            label5.TabIndex = 42;
            label5.Text = "Chỉ Số Nước Mới:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(252, 37);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 41;
            label2.Text = "Chỉ Số Điện Cũ:";
            // 
            // dtpNgayGhi
            // 
            dtpNgayGhi.Location = new Point(779, 33);
            dtpNgayGhi.Name = "dtpNgayGhi";
            dtpNgayGhi.Size = new Size(250, 27);
            dtpNgayGhi.TabIndex = 40;
            // 
            // frmDienNuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 458);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmDienNuoc";
            Text = "frmDienNuoc";
            Load += frmDienNuoc_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDienNuoc).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmNuocMoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmDienMoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmNuocCu).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmDienCu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvDienNuoc;
        private ComboBox cboPhong;
        private Button btnThoat;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThem;
        private TextBox txtMaDN;
        private Label label4;
        private Label label3;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label2;
        private DateTimePicker dtpNgayGhi;
        private NumericUpDown nmNuocMoi;
        private NumericUpDown nmDienMoi;
        private NumericUpDown nmNuocCu;
        private NumericUpDown nmDienCu;
        private DataGridViewTextBoxColumn colMaDN;
        private DataGridViewTextBoxColumn colTenPhong;
        private DataGridViewTextBoxColumn colNgayGhi;
        private DataGridViewTextBoxColumn colDienCu;
        private DataGridViewTextBoxColumn colDienMoi;
        private DataGridViewTextBoxColumn colNuocCu;
        private DataGridViewTextBoxColumn colNuocMoi;
    }
}