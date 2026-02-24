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
    public partial class frmHoaDon : Form
    {

        NhaTroContext context = new NhaTroContext();
        bool isAdding = false;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            // Nạp sẵn 2 trạng thái nếu ní chưa nạp trên giao diện
            if (cboTrangThai.Items.Count == 0)
            {
                cboTrangThai.Items.Add("Chưa thanh toán");
                cboTrangThai.Items.Add("Đã thanh toán");
            }

            LoadComboBox();
            LoadData();
            SetControlState(false);

            // Gắn sự kiện tự động tính tiền khi đổi Phòng, Tháng, Năm
            cboPhong.SelectedIndexChanged += AutoCalculate_Event;
            nmThang.ValueChanged += AutoCalculate_Event;
            nmNam.ValueChanged += AutoCalculate_Event;
        }
        private void LoadComboBox()
        {
            cboPhong.DataSource = context.Phongs.ToList();
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }
        private void LoadData()
        {
            var listHD = context.HoaDons.Select(h => new
            {
                MaHoaDon = h.MaHoaDon,
                MaPhong = h.MaPhong,
                TenPhong = h.Phong.TenPhong,
                Thang = h.Thang,
                Nam = h.Nam,
                TienPhong = h.TienPhong,
                TienDien = h.TienDien,
                TienNuoc = h.TienNuoc,
                TongTien = h.TongTien,
                TrangThai = h.TrangThai
            }).ToList();

            dgvHoaDon.DataSource = listHD;
        }
        private void SetControlState(bool editing)
        {
            cboPhong.Enabled = editing;
            nmThang.Enabled = editing;
            nmNam.Enabled = editing;
            cboTrangThai.Enabled = editing;

            btnThem.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
            btnXoa.Enabled = !editing && dgvHoaDon.Rows.Count > 0;
            btnThoat.Enabled = true;
        }
        private void ClearInputs()
        {
            txtMaHD.Clear();
            nmThang.Value = DateTime.Now.Month;
            nmNam.Value = DateTime.Now.Year;
            cboTrangThai.SelectedIndex = 0; // Mặc định là Chưa thanh toán
            txtTienPhong.Text = "0";
            txtTienDien.Text = "0";
            txtTienNuoc.Text = "0";
            txtTongTien.Text = "0";
        }
        private void AutoCalculate_Event(object sender, EventArgs e)
        {
            if (isAdding) // Chỉ tự tính khi đang bấm Thêm Mới
            {
                TinhTienTuDong();
            }
        }
        private void TinhTienTuDong()
        {
            try
            {
                int maPhong = (int)cboPhong.SelectedValue;
                int thang = (int)nmThang.Value;
                int nam = (int)nmNam.Value;

                int tienPhong = 0;
                int tienDien = 0;
                int tienNuoc = 0;

                // 1. Lấy giá phòng (Giả sử bảng Phong của ní có cột GiaPhong)
                var phong = context.Phongs.FirstOrDefault(p => p.MaPhong == maPhong);
                if (phong != null)
                {
                    // Nếu lỗi đỏ chữ GiaPhong, ní tự đổi lại tên cột giá phòng trong class Phong của ní nhé
                    tienPhong = Convert.ToInt32(phong.GiaPhong);
                }

                // 2. Lấy số điện nước của tháng đó để tính tiền
                var dn = context.DienNuocs.FirstOrDefault(d => d.MaPhong == maPhong && d.NgayGhi.Month == thang && d.NgayGhi.Year == nam);
                if (dn != null)
                {
                    int soDien = dn.ChiSoDienMoi - dn.ChiSoDienCu;
                    int soNuoc = dn.ChiSoNuocMoi - dn.ChiSoNuocCu;

                    // ĐƠN GIÁ (Ní có thể tự sửa lại số tiền cho phù hợp)
                    tienDien = soDien * 3500;   // 3,500đ / 1 kWh
                    tienNuoc = soNuoc * 15000;  // 15,000đ / 1 khối
                }

                int tongTien = tienPhong + tienDien + tienNuoc;

                // 3. Hiển thị lên UI kèm định dạng dấu phẩy cho đẹp (vd: 1,500,000)
                txtTienPhong.Text = tienPhong.ToString("N0");
                txtTienDien.Text = tienDien.ToString("N0");
                txtTienNuoc.Text = tienNuoc.ToString("N0");
                txtTongTien.Text = tongTien.ToString("N0");
            }
            catch { }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInputs();
            SetControlState(true);
            btnXoa.Enabled = false;
            TinhTienTuDong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Hàm gỡ bỏ dấu phẩy để chuyển chữ (1,500,000) thành số (1500000) lưu vào DB
                int GetMoneyFromText(string text) => string.IsNullOrWhiteSpace(text) ? 0 : int.Parse(text.Replace(",", "").Replace(".", ""));

                if (isAdding)
                {
                    var hd = new HoaDon
                    {
                        MaPhong = (int)cboPhong.SelectedValue,
                        Thang = (int)nmThang.Value,
                        Nam = (int)nmNam.Value,
                        TrangThai = cboTrangThai.Text,
                        TienPhong = GetMoneyFromText(txtTienPhong.Text),
                        TienDien = GetMoneyFromText(txtTienDien.Text),
                        TienNuoc = GetMoneyFromText(txtTienNuoc.Text),
                        TongTien = GetMoneyFromText(txtTongTien.Text)
                    };
                    context.HoaDons.Add(hd);
                }
                else
                {
                    if (string.IsNullOrEmpty(txtMaHD.Text)) return;
                    int id = int.Parse(txtMaHD.Text);
                    var hd = context.HoaDons.FirstOrDefault(h => h.MaHoaDon == id);
                    if (hd != null)
                    {
                        hd.TrangThai = cboTrangThai.Text; // Thường sửa hóa đơn thì chỉ sửa Trạng thái (Đã thu tiền)
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                isAdding = false;
                LoadData();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = int.Parse(txtMaHD.Text);
                var hd = context.HoaDons.FirstOrDefault(h => h.MaHoaDon == id);
                if (hd != null)
                {
                    context.HoaDons.Remove(hd);
                    context.SaveChanges();
                    LoadData();
                    ClearInputs();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            ClearInputs();
            SetControlState(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !isAdding)
            {
                dynamic rowData = dgvHoaDon.Rows[e.RowIndex].DataBoundItem;
                if (rowData != null)
                {
                    txtMaHD.Text = rowData.MaHoaDon.ToString();
                    cboPhong.SelectedValue = rowData.MaPhong;
                    nmThang.Value = Convert.ToDecimal(rowData.Thang);
                    nmNam.Value = Convert.ToDecimal(rowData.Nam);
                    cboTrangThai.Text = rowData.TrangThai;

                    // Load ngược số tiền lên định dạng có dấu phẩy
                    txtTienPhong.Text = ((int)rowData.TienPhong).ToString("N0");
                    txtTienDien.Text = ((int)rowData.TienDien).ToString("N0");
                    txtTienNuoc.Text = ((int)rowData.TienNuoc).ToString("N0");
                    txtTongTien.Text = ((int)rowData.TongTien).ToString("N0");

                    SetControlState(false);
                    btnLuu.Enabled = true;
                    cboTrangThai.Enabled = true; 
                }
            }
        }
    }
    
}
