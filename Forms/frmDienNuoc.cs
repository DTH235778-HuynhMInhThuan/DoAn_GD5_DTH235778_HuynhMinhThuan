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
    public partial class frmDienNuoc : Form
    {

        NhaTroContext context = new NhaTroContext();
        bool isAdding = false;
        public frmDienNuoc()
        {
            InitializeComponent();
        }

        private void dtpNgayGhi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmDienNuoc_Load(object sender, EventArgs e)
        {
            ThietKeUI.ApDungToanBo(this);
            var danhSachPhongDaThue = context.Phongs
                                     .Where(p => p.TrangThai == "Đã thuê")
                                     .ToList();

            cboPhong.DataSource = danhSachPhongDaThue;
            cboPhong.DisplayMember = "TenPhong"; // Hiển thị tên phòng (P101, P102...)
            cboPhong.ValueMember = "MaPhong";    // Giá trị ngầm là mã phòng

            // 3. Các thiết lập khác
            txtMaDienNuoc.Enabled = false;
            SetControlState(false);
            LoadData();

        }
        private void LoadData()
        {
            // Lấy dữ liệu từ Database, nhớ phải khớp đúng DataPropertyName ngoài giao diện
            var listDienNuoc = context.DienNuocs.Select(d => new
            {
                d.MaDN,
                TenPhong = d.Phong.TenPhong,
                d.NgayGhi,
                d.ChiSoDienCu,
                d.ChiSoDienMoi,
                d.ChiSoNuocCu,
                d.ChiSoNuocMoi
            }).ToList();

            dgvDienNuoc.AutoGenerateColumns = false;
            dgvDienNuoc.DataSource = listDienNuoc;
        }
        private void SetControlState(bool editing)
        {
            // Bật/tắt các ô nhập liệu
            cboPhong.Enabled = editing;
            dtpNgayGhi.Enabled = editing;
            nmDienCu.Enabled = editing;
            nmDienMoi.Enabled = editing;
            nmNuocCu.Enabled = editing;
            nmNuocMoi.Enabled = editing;

            // Bật/tắt các nút bấm
            btnThem.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
        }

        private void ClearInput()
        {
            txtMaDienNuoc.Clear();
            dtpNgayGhi.Value = DateTime.Now;
            nmDienCu.Value = 0;
            nmDienMoi.Value = 0;
            nmNuocCu.Value = 0;
            nmNuocMoi.Value = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            SetControlState(true);
            btnXoa.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ClearInput();
            SetControlState(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra logic điện nước: Số mới không được nhỏ hơn số cũ
                if (nmDienMoi.Value < nmDienCu.Value)
                {
                    MessageBox.Show("Chỉ số ĐIỆN mới không thể nhỏ hơn chỉ số cũ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (nmNuocMoi.Value < nmNuocCu.Value)
                {
                    MessageBox.Show("Chỉ số NƯỚC mới không thể nhỏ hơn chỉ số cũ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isAdding)
                {
                    // 2. Kiểm tra xem tháng này phòng này đã ghi điện nước chưa (tránh trùng lặp)
                    int maPh = (int)cboPhong.SelectedValue;
                    DateTime ngayGhi = dtpNgayGhi.Value;
                    bool daTonTai = context.DienNuocs.Any(dn => dn.MaPhong == maPh &&
                                                         dn.NgayGhi.Month == ngayGhi.Month &&
                                                         dn.NgayGhi.Year == ngayGhi.Year);
                    if (daTonTai)
                    {
                        MessageBox.Show("Phòng này đã được ghi điện nước trong tháng này rồi!", "Thông báo");
                        return;
                    }

                    // THÊM MỚI
                    DienNuoc dn = new DienNuoc
                    {
                        MaPhong = maPh,
                        NgayGhi = ngayGhi,
                        ChiSoDienCu = (int)nmDienCu.Value,
                        ChiSoDienMoi = (int)nmDienMoi.Value,
                        ChiSoNuocCu = (int)nmNuocCu.Value,
                        ChiSoNuocMoi = (int)nmNuocMoi.Value
                    };
                    context.DienNuocs.Add(dn);
                }
                else
                {
                    // SỬA (Cập nhật)
                    if (string.IsNullOrEmpty(txtMaDienNuoc.Text)) return;

                    int maDN = int.Parse(txtMaDienNuoc.Text);
                    DienNuoc dn = context.DienNuocs.Find(maDN);
                    if (dn != null)
                    {
                        dn.MaPhong = (int)cboPhong.SelectedValue;
                        dn.NgayGhi = dtpNgayGhi.Value;
                        dn.ChiSoDienCu = (int)nmDienCu.Value;
                        dn.ChiSoDienMoi = (int)nmDienMoi.Value;
                        dn.ChiSoNuocCu = (int)nmNuocCu.Value;
                        dn.ChiSoNuocMoi = (int)nmNuocMoi.Value;
                    }
                }

                // 3. Thực thi lưu
                context.SaveChanges();
                MessageBox.Show("Lưu thông tin điện nước thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Reset trạng thái giao diện
                isAdding = false;
                SetControlState(false);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDienNuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn một phiếu điện nước dưới bảng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Ní có chắc chắn muốn xóa dữ liệu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int maDN = int.Parse(txtMaDienNuoc.Text);
                var dn = context.DienNuocs.Find(maDN);
                if (dn != null)
                {
                    context.DienNuocs.Remove(dn);
                    context.SaveChanges();
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInput();
                    SetControlState(false);
                }
            }
        }

        private void dgvDienNuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDienNuoc.Rows[e.RowIndex];

                // Đổ dữ liệu ngược lên các ô nhập liệu
                txtMaDienNuoc.Text = row.Cells["colMaDN"].Value?.ToString(); // Chú ý: Dùng đúng tên Name của cột ngoài Design
                cboPhong.Text = row.Cells["colPhong"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["colNgayGhi"].Value?.ToString(), out DateTime ngay))
                    dtpNgayGhi.Value = ngay;

                if (decimal.TryParse(row.Cells["colDienCu"].Value?.ToString(), out decimal dienCu)) nmDienCu.Value = dienCu;
                if (decimal.TryParse(row.Cells["colDienMoi"].Value?.ToString(), out decimal dienMoi)) nmDienMoi.Value = dienMoi;
                if (decimal.TryParse(row.Cells["colNuocCu"].Value?.ToString(), out decimal nuocCu)) nmNuocCu.Value = nuocCu;
                if (decimal.TryParse(row.Cells["colNuocMoi"].Value?.ToString(), out decimal nuocMoi)) nmNuocMoi.Value = nuocMoi;

                // Mở khóa để cho phép Sửa/Xóa
                isAdding = false;
                SetControlState(true);
                btnXoa.Enabled = true; // Bật nút Xóa
            }
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue == null || !(cboPhong.SelectedValue is int)) return;

            int maPhong = (int)cboPhong.SelectedValue;

            // Tìm bản ghi điện nước mới nhất của phòng này trong bảng DienNuoc (hoặc HoaDon tùy DB của ní)
            var lichSuGanNhat = context.DienNuocs // Hoặc context.HoaDons
                .Where(dn => dn.MaPhong == maPhong)
                .OrderByDescending(dn => dn.NgayGhi) // Hoặc Order theo Nam, Thang
                .FirstOrDefault();

            if (lichSuGanNhat != null)
            {
                // Với NumericUpDown, ní dùng .Value và ép kiểu về decimal hoặc int
                // Giả sử tên control của ní là nmDienCu và nmNuocCu
                nmDienCu.Value = (decimal)lichSuGanNhat.ChiSoDienMoi;
                nmNuocCu.Value = (decimal)lichSuGanNhat.ChiSoNuocMoi;
            }
            else
            {
                // Nếu là phòng mới tinh, cho về 0
                nmDienCu.Value = 0;
                nmNuocCu.Value = 0;
            }

        }
    }
}
