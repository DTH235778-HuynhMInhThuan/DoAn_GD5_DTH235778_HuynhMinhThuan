using QuanLyNhaTro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro.Forms
{
    public partial class frmSinhVien : Form
    {
        private NhaTroContext context = new NhaTroContext();
        private bool isAdding = false;
        public frmSinhVien()
        {
            InitializeComponent();
            dataGridView.AutoGenerateColumns = false;
        }
       
     
        private void SinhVien_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }
        private void LoadData()
        {
            // Lấy danh sách từ DB
            var list = context.SinhViens.ToList();
            dataGridView.DataSource = null;
            dataGridView.DataSource = list;
        }
        private void SetControlState(bool isEditing)
        {
            // Bật/tắt ô nhập liệu (Mã SV luôn luôn khóa vì tự động tăng)
            txtMaSV.ReadOnly = true;
            txtTenSV.ReadOnly = !isEditing;
            txtSDT.ReadOnly = !isEditing;
            txtCCCD.ReadOnly = !isEditing;
            txtQueQuan.ReadOnly = !isEditing;

            // Bật/tắt các nút bấm
            btnThem.Enabled = !isEditing;
            btnXoa.Enabled = !isEditing && dataGridView.CurrentRow != null; // Chỉ xóa khi có dòng được chọn
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;
            btnThoat.Enabled = !isEditing;

            // Khóa bảng không cho chọn dòng khác khi đang nhập liệu
            dataGridView.Enabled = !isEditing;
        }
        private void ClearInput()
        {
            txtMaSV.Clear();
            txtTenSV.Clear();
            txtSDT.Clear();
            txtCCCD.Clear();
            txtQueQuan.Clear();
            txtTenSV.Focus(); // Đưa con trỏ chuột vào ô Tên
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !isAdding) // Không cho click khi đang chế độ Thêm
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["colMaSV"].Value?.ToString(); // Chú ý: Đổi tên "colMaSV" thành tên Cột của bạn nếu đặt khác
                txtTenSV.Text = row.Cells["colTenSV"].Value?.ToString();
                txtSDT.Text = row.Cells["colSDT"].Value?.ToString();
                txtCCCD.Text = row.Cells["colCCCD"].Value?.ToString();
                txtQueQuan.Text = row.Cells["colQueQuan"].Value?.ToString();

                SetControlState(false);
                btnXoa.Enabled = true; // Cho phép xóa dòng đang chọn
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            SetControlState(true);
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ClearInput();
            SetControlState(false);

            // Load lại dữ liệu của dòng đang chọn (nếu có)
            if (dataGridView.Rows.Count > 0)
            {
                dataGridView_CellClick(dataGridView, new DataGridViewCellEventArgs(0, dataGridView.CurrentCell?.RowIndex ?? 0));
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra ràng buộc dữ liệu (Validation) - Cực kỳ quan trọng để tránh lỗi NULL CCCD
            if (string.IsNullOrWhiteSpace(txtTenSV.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSV.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập Căn Cước Công Dân!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // THÊM MỚI
                    SinhVien sv = new SinhVien
                    {
                        TenSV = txtTenSV.Text.Trim(),
                        SDT = txtSDT.Text.Trim(),
                        CCCD = txtCCCD.Text.Trim(),
                        QueQuan = txtQueQuan.Text.Trim()
                    };
                    context.SinhViens.Add(sv);
                }
                else
                {
                    // CẬP NHẬT (SỬA)
                    int id = int.Parse(txtMaSV.Text);
                    SinhVien sv = context.SinhViens.FirstOrDefault(s => s.MaSV == id);
                    if (sv != null)
                    {
                        sv.TenSV = txtTenSV.Text.Trim();
                        sv.SDT = txtSDT.Text.Trim();
                        sv.CCCD = txtCCCD.Text.Trim();
                        sv.QueQuan = txtQueQuan.Text.Trim();
                    }
                }

                context.SaveChanges(); // Lưu vào Database
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trả về trạng thái bình thường
                isAdding = false;
                SetControlState(false);
                LoadData();
            }
            catch (Exception ex)
            {
                // Lấy thông báo lỗi chi tiết nhất từ SQL Server
                string errorDetail = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi chi tiết từ Database: " + errorDetail, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text)) return;

            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtMaSV.Text);
                    SinhVien sv = context.SinhViens.FirstOrDefault(s => s.MaSV == id);
                    if (sv != null)
                    {
                        context.SinhViens.Remove(sv);
                        context.SaveChanges();

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInput();
                        LoadData();
                        SetControlState(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa. Sinh viên này có thể đang có Hợp đồng! Lỗi chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
