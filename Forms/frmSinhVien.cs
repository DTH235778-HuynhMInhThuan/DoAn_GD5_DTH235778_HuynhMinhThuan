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
using OfficeOpenXml;


namespace QuanLyNhaTro.Forms
{
    public partial class frmSinhVien : Form
    {
        private NhaTroContext context = new NhaTroContext();
        private bool isAdding = false;
        public frmSinhVien()
        {
            InitializeComponent();
            dgvSinhVien.AutoGenerateColumns = false;
        }


        private void SinhVien_Load(object sender, EventArgs e)
        {
            ThietKeUI.ApDungToanBo(this);
            LoadData();
            SetControlState(false);
        }
        private void LoadData()
        {
            // Lấy danh sách từ DB
            var list = context.SinhViens.ToList();
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = list;
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
            btnXoa.Enabled = !isEditing && dgvSinhVien.CurrentRow != null; // Chỉ xóa khi có dòng được chọn
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;
            btnThoat.Enabled = !isEditing;

            // Khóa bảng không cho chọn dòng khác khi đang nhập liệu
            dgvSinhVien.Enabled = !isEditing;
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
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];
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
            if (dgvSinhVien.Rows.Count > 0)
            {
                dataGridView_CellClick(dgvSinhVien, new DataGridViewCellEventArgs(0, dgvSinhVien.CurrentCell?.RowIndex ?? 0));
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
        private void btnXoa_Click(object sender, EventArgs e)
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

        private void ChiNhapSo_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            // Lọc ra chỉ lấy đúng các con số từ cái chuỗi đang nhập
            string chiLaySo = string.Join("", txt.Text.Where(char.IsDigit));

            // Nếu phát hiện có chữ lọt vào (chuỗi gốc khác chuỗi đã lọc)
            if (txt.Text != chiLaySo)
            {
                txt.Text = chiLaySo; // Ghi đè lại bằng chuỗi sạch (chỉ toàn số)
                txt.SelectionStart = txt.Text.Length; // Kéo con trỏ chuột về cuối cùng để gõ tiếp
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // 1. Cấu hình bản quyền EPPlus (Bắt buộc)
            OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Do An Ca Nhan");

            try
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    // 2. Tạo một Sheet mới đặt tên là "Danh sách Sinh viên"
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("SinhVien");

                    // 3. Xuất Tiêu đề cột từ DataGridView
                    // (Chỉ lấy các cột: Mã SV, Tên SV, SĐT, CCCD, Quê Quán)
                    for (int i = 0; i < dgvSinhVien.Columns.Count; i++)
                    {
                        ws.Cells[1, i + 1].Value = dgvSinhVien.Columns[i].HeaderText;
                        ws.Cells[1, i + 1].Style.Font.Bold = true; // In đậm tiêu đề
                        ws.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        ws.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                    }

                    // 4. Đổ dữ liệu từ bảng (dgvSinhVien) vào file Excel
                    for (int row = 0; row < dgvSinhVien.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvSinhVien.Columns.Count; col++)
                        {
                            ws.Cells[row + 2, col + 1].Value = dgvSinhVien.Rows[row].Cells[col].Value?.ToString();
                        }
                    }

                    // 5. Tự động căn chỉnh độ rộng cột cho đẹp
                    ws.Cells.AutoFitColumns();

                    // 6. Mở hộp thoại lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.FileName = "Danh_Sach_Sinh_Vien_" + DateTime.Now.ToString("yyyyMMdd");

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, pck.GetAsByteArray());
                        MessageBox.Show("Đã xuất danh sách sinh viên ra Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
