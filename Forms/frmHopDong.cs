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
    public partial class frmHopDong : Form
    {

        NhaTroContext context = new NhaTroContext();
        bool isAdding = false;
        public frmHopDong()
        {
            InitializeComponent();

        }
        private void LoadComboBox()
        {
            // Đổ danh sách Sinh Viên vào cboSinhVien
            // (Lưu ý: Thay "TenSinhVien" bằng tên cột hiển thị tên SV trong model SinhVien.cs của bạn, VD: "HoTen")
            cboSinhVien.DataSource = context.SinhViens.ToList();
            cboSinhVien.DisplayMember = "TenSV";
            cboSinhVien.ValueMember = "MaSV";

            // Đổ danh sách Phòng vào cboPhong
            cboPhong.DataSource = context.Phongs.ToList();
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";

            // Nạp dữ liệu cứng cho Trạng Thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Còn hạn", "Hết hạn", "Đã hủy" });
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            dgvHopDong.AutoGenerateColumns = false; // Chặn tự đẻ cột
            LoadComboBox(); // Phải load ComboBox trước
            LoadData();     // Rồi mới load Data vào bảng
            SetControlState(false);
        }
        private void LoadData()
        {
            var listHopDong = context.HopDongs.Select(h => new
            {
                MaHopDong = h.MaHopDong,

                // Thêm 2 dòng này để lấy Tên hiển thị ra bảng
                // (Lưu ý: Thay "TenSinhVien" bằng tên biến tương ứng trong file SinhVien.cs của bạn, VD: "HoTen")
                TenSV = h.SinhVien.TenSV,
                TenPhong = h.Phong.TenPhong,

                // Vẫn giữ lại Mã ngầm để click vào bảng thì ComboBox còn biết đường chọn
                MaSV = h.MaSV,
                MaPhong = h.MaPhong,

                NgayBatDau = h.NgayBatDau,
                NgayKetThuc = h.NgayKetThuc,
                TienCoc = h.TienCoc,
                TrangThai = h.TrangThai
            }).ToList();

            dgvHopDong.DataSource = listHopDong;
        }
        private void SetControlState(bool editing)
        {
            // Bật/tắt ô nhập
            cboSinhVien.Enabled = editing;
            cboPhong.Enabled = editing;
            dtpNgayBatDau.Enabled = editing;
            dtpNgayKetThuc.Enabled = editing;
            nmTienCoc.Enabled = editing;
            cboTrangThai.Enabled = editing;

            // Bật/tắt nút bấm
            btnThem.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
        }
        private void ClearInput()
        {
            txtMaHopDong.Clear();
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now.AddMonths(6); // Mặc định hợp đồng 6 tháng
            nmTienCoc.Value = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
        }

        private void dgvHopDong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Dùng dynamic để lấy toàn bộ dữ liệu (cả Tên lẫn Mã) của dòng vừa click
                dynamic rowData = dgvHopDong.Rows[e.RowIndex].DataBoundItem;

                if (rowData != null)
                {
                    txtMaHopDong.Text = rowData.MaHopDong.ToString();

                    // Gán Mã ngầm vào ComboBox
                    cboSinhVien.SelectedValue = rowData.MaSV;
                    cboPhong.SelectedValue = rowData.MaPhong;

                    dtpNgayBatDau.Value = rowData.NgayBatDau;
                    dtpNgayKetThuc.Value = rowData.NgayKetThuc;
                    nmTienCoc.Value = Convert.ToDecimal(rowData.TienCoc);
                    cboTrangThai.Text = rowData.TrangThai?.ToString();

                    isAdding = false;
                    SetControlState(true);
                    btnXoa.Enabled = true;
                }
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
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra bắt lỗi cơ bản
                if (cboSinhVien.SelectedValue == null || cboPhong.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Sinh viên và Phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpNgayBatDau.Value > dtpNgayKetThuc.Value)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Xử lý Lưu dữ liệu
                if (isAdding) // Trường hợp THÊM MỚI
                {
                    HopDong hd = new HopDong()
                    {
                        MaSV = (int)cboSinhVien.SelectedValue,   // Lấy Mã ngầm bên dưới ComboBox
                        MaPhong = (int)cboPhong.SelectedValue,
                        NgayBatDau = dtpNgayBatDau.Value,
                        NgayKetThuc = dtpNgayKetThuc.Value,
                        TienCoc = nmTienCoc.Value,
                        TrangThai = cboTrangThai.Text
                    };
                    context.HopDongs.Add(hd);
                }
                else // Trường hợp SỬA
                {
                    if (string.IsNullOrEmpty(txtMaHopDong.Text)) return;
                    int maHD = int.Parse(txtMaHopDong.Text);

                    // Tìm hợp đồng cũ trong Database
                    HopDong hd = context.HopDongs.FirstOrDefault(h => h.MaHopDong == maHD);

                    if (hd != null)
                    {
                        hd.MaSV = (int)cboSinhVien.SelectedValue;
                        hd.MaPhong = (int)cboPhong.SelectedValue;
                        hd.NgayBatDau = dtpNgayBatDau.Value;
                        hd.NgayKetThuc = dtpNgayKetThuc.Value;
                        hd.TienCoc = nmTienCoc.Value;
                        hd.TrangThai = cboTrangThai.Text;
                    }
                }

                // 3. Đẩy thay đổi xuống Database và tải lại bảng
                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                isAdding = false;
                SetControlState(false);
                LoadData();
            }
            catch (Exception ex)
            {
                // Moi móc cái lỗi thực sự ẩn bên trong (Inner Exception)
                string loiThucSu = ex.Message;
                if (ex.InnerException != null)
                {
                    loiThucSu = ex.InnerException.Message;

                    // Nếu có lớp lỗi sâu hơn nữa thì lôi ra nốt
                    if (ex.InnerException.InnerException != null)
                    {
                        loiThucSu = ex.InnerException.InnerException.Message;
                    }
                }

                MessageBox.Show("Không thể lưu! Chi tiết lỗi từ Database:\n\n" + loiThucSu, "Bắt quả tang lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHopDong.Text))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa từ danh sách bên dưới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại hỏi lại người dùng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int maHD = int.Parse(txtMaHopDong.Text);
                    HopDong hd = context.HopDongs.FirstOrDefault(h => h.MaHopDong == maHD);

                    if (hd != null)
                    {
                        context.HopDongs.Remove(hd);
                        context.SaveChanges();
                        MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới giao diện
                        ClearInput();
                        SetControlState(false);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa hợp đồng này. Chi tiết lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Dùng dynamic để lấy toàn bộ dữ liệu (cả Tên lẫn Mã) của dòng vừa click
                dynamic rowData = dgvHopDong.Rows[e.RowIndex].DataBoundItem;

                if (rowData != null)
                {
                    txtMaHopDong.Text = rowData.MaHopDong.ToString();

                    // Gán Mã ngầm vào ComboBox
                    cboSinhVien.SelectedValue = rowData.MaSV;
                    cboPhong.SelectedValue = rowData.MaPhong;

                    dtpNgayBatDau.Value = rowData.NgayBatDau;
                    dtpNgayKetThuc.Value = rowData.NgayKetThuc;
                    nmTienCoc.Value = Convert.ToDecimal(rowData.TienCoc);
                    cboTrangThai.Text = rowData.TrangThai?.ToString();

                    isAdding = false;
                    SetControlState(true);
                    btnXoa.Enabled = true;
                }
            }
        }
    }
}
