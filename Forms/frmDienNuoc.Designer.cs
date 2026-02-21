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
            btnThoat = new Button();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            groupBox2 = new GroupBox();
            dgvDienNuoc = new DataGridView();
            colMaDN = new DataGridViewTextBoxColumn();
            colPhong = new DataGridViewTextBoxColumn();
            colNgayGhi = new DataGridViewTextBoxColumn();
            colDienCu = new DataGridViewTextBoxColumn();
            colDienMoi = new DataGridViewTextBoxColumn();
            colNuocCu = new DataGridViewTextBoxColumn();
            colNuocMoi = new DataGridViewTextBoxColumn();
            txtMaDienNuoc = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            nmNuocMoi = new NumericUpDown();
            nmDienMoi = new NumericUpDown();
            nmNuocCu = new NumericUpDown();
            nmDienCu = new NumericUpDown();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            dtpNgayGhi = new DateTimePicker();
            cboPhong = new ComboBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDienNuoc).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmNuocMoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmDienMoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmNuocCu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmDienCu).BeginInit();
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
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDienNuoc);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 178);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1126, 285);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách Sinh Viên";
            // 
            // dgvDienNuoc
            // 
            dgvDienNuoc.AllowUserToAddRows = false;
            dgvDienNuoc.AllowUserToDeleteRows = false;
            dgvDienNuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDienNuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDienNuoc.Columns.AddRange(new DataGridViewColumn[] { colMaDN, colPhong, colNgayGhi, colDienCu, colDienMoi, colNuocCu, colNuocMoi });
            dgvDienNuoc.Dock = DockStyle.Fill;
            dgvDienNuoc.Location = new Point(3, 23);
            dgvDienNuoc.Name = "dgvDienNuoc";
            dgvDienNuoc.ReadOnly = true;
            dgvDienNuoc.RowHeadersWidth = 51;
            dgvDienNuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDienNuoc.Size = new Size(1120, 259);
            dgvDienNuoc.TabIndex = 0;
            dgvDienNuoc.CellClick += dgvDienNuoc_CellClick;
            // 
            // colMaDN
            // 
            colMaDN.DataPropertyName = "MaDN";
            colMaDN.HeaderText = "Mã ĐN";
            colMaDN.MinimumWidth = 6;
            colMaDN.Name = "colMaDN";
            colMaDN.ReadOnly = true;
            // 
            // colPhong
            // 
            colPhong.DataPropertyName = "TenPhong";
            colPhong.HeaderText = "Phòng";
            colPhong.MinimumWidth = 6;
            colPhong.Name = "colPhong";
            colPhong.ReadOnly = true;
            // 
            // colNgayGhi
            // 
            colNgayGhi.DataPropertyName = "NgayGhi";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            colNgayGhi.DefaultCellStyle = dataGridViewCellStyle1;
            colNgayGhi.HeaderText = "Ngày Ghi";
            colNgayGhi.MinimumWidth = 6;
            colNgayGhi.Name = "colNgayGhi";
            colNgayGhi.ReadOnly = true;
            // 
            // colDienCu
            // 
            colDienCu.DataPropertyName = "ChiSoDienCu";
            colDienCu.HeaderText = "Điện Cũ";
            colDienCu.MinimumWidth = 6;
            colDienCu.Name = "colDienCu";
            colDienCu.ReadOnly = true;
            // 
            // colDienMoi
            // 
            colDienMoi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDienMoi.DataPropertyName = "ChiSoDienMoi";
            colDienMoi.HeaderText = "Điện Mới";
            colDienMoi.MinimumWidth = 6;
            colDienMoi.Name = "colDienMoi";
            colDienMoi.ReadOnly = true;
            // 
            // colNuocCu
            // 
            colNuocCu.DataPropertyName = "ChiSoNuocCu";
            colNuocCu.HeaderText = "Nước Cũ";
            colNuocCu.MinimumWidth = 6;
            colNuocCu.Name = "colNuocCu";
            colNuocCu.ReadOnly = true;
            // 
            // colNuocMoi
            // 
            colNuocMoi.DataPropertyName = "ChiSoNuocMoi";
            colNuocMoi.HeaderText = "Nước Mới";
            colNuocMoi.MinimumWidth = 6;
            colNuocMoi.Name = "colNuocMoi";
            colNuocMoi.ReadOnly = true;
            // 
            // txtMaDienNuoc
            // 
            txtMaDienNuoc.Location = new Point(138, 34);
            txtMaDienNuoc.Name = "txtMaDienNuoc";
            txtMaDienNuoc.ReadOnly = true;
            txtMaDienNuoc.Size = new Size(125, 27);
            txtMaDienNuoc.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(65, 81);
            label5.Name = "label5";
            label5.Size = new Size(54, 20);
            label5.TabIndex = 4;
            label5.Text = "Phòng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 37);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày Ghi:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 37);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã ĐN:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nmNuocMoi);
            groupBox1.Controls.Add(nmDienMoi);
            groupBox1.Controls.Add(nmNuocCu);
            groupBox1.Controls.Add(nmDienCu);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpNgayGhi);
            groupBox1.Controls.Add(cboPhong);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(btnHuy);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(txtMaDienNuoc);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1126, 178);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Điện Nước ";
            // 
            // nmNuocMoi
            // 
            nmNuocMoi.Location = new Point(898, 79);
            nmNuocMoi.Name = "nmNuocMoi";
            nmNuocMoi.Size = new Size(150, 27);
            nmNuocMoi.TabIndex = 24;
            // 
            // nmDienMoi
            // 
            nmDienMoi.Location = new Point(898, 32);
            nmDienMoi.Name = "nmDienMoi";
            nmDienMoi.Size = new Size(150, 27);
            nmDienMoi.TabIndex = 23;
            // 
            // nmNuocCu
            // 
            nmNuocCu.Location = new Point(617, 79);
            nmNuocCu.Name = "nmNuocCu";
            nmNuocCu.Size = new Size(150, 27);
            nmNuocCu.TabIndex = 22;
            // 
            // nmDienCu
            // 
            nmDienCu.Location = new Point(617, 35);
            nmDienCu.Name = "nmDienCu";
            nmDienCu.Size = new Size(150, 27);
            nmDienCu.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(819, 37);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 20;
            label7.Text = "Điện Mới:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(814, 84);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 19;
            label6.Text = "Nước Mới:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(542, 79);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 18;
            label3.Text = "Nước Cũ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(547, 37);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 17;
            label2.Text = "Điện Cũ:";
            // 
            // dtpNgayGhi
            // 
            dtpNgayGhi.CustomFormat = "dd/MM/yyyy";
            dtpNgayGhi.Format = DateTimePickerFormat.Custom;
            dtpNgayGhi.Location = new Point(381, 32);
            dtpNgayGhi.Name = "dtpNgayGhi";
            dtpNgayGhi.Size = new Size(122, 27);
            dtpNgayGhi.TabIndex = 16;
            dtpNgayGhi.ValueChanged += dtpNgayGhi_ValueChanged;
            // 
            // cboPhong
            // 
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(138, 81);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(125, 28);
            cboPhong.TabIndex = 15;
            cboPhong.SelectedIndexChanged += cboPhong_SelectedIndexChanged;
            // 
            // frmDienNuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 463);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmDienNuoc";
            Text = "frmDienNuoc";
            Load += frmDienNuoc_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDienNuoc).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmNuocMoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmDienMoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmNuocCu).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmDienCu).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnThoat;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnThem;
        private GroupBox groupBox2;
        private DataGridView dgvDienNuoc;
        private TextBox txtMaDienNuoc;
        private Label label5;
        private Label label4;
        private Label label1;
        private GroupBox groupBox1;
        private DateTimePicker dtpNgayGhi;
        private ComboBox cboPhong;
        private NumericUpDown nmNuocMoi;
        private NumericUpDown nmDienMoi;
        private NumericUpDown nmNuocCu;
        private NumericUpDown nmDienCu;
        private Label label7;
        private Label label6;
        private Label label3;
        private Label label2;
        private DataGridViewTextBoxColumn colMaDN;
        private DataGridViewTextBoxColumn colPhong;
        private DataGridViewTextBoxColumn colNgayGhi;
        private DataGridViewTextBoxColumn colDienCu;
        private DataGridViewTextBoxColumn colDienMoi;
        private DataGridViewTextBoxColumn colNuocCu;
        private DataGridViewTextBoxColumn colNuocMoi;
    }
}