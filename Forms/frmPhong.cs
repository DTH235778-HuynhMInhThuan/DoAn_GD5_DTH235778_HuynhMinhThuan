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
    public partial class frmPhong : Form
    {
        private NhaTroContext context;
        private bool isAdding = false;
        public frmPhong()
        {
            InitializeComponent();
            context = new NhaTroContext();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            ThietKeUI.ApDungToanBo(this);

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Trống");
            cboTrangThai.Items.Add("Đã thuê");
            cboTrangThai.SelectedIndex = 0; // Mặc định chọn "Trống"

            // 2. Khóa ô Mã Phòng (vì DB tự tăng) và thiết lập trạng thái ban đầu
            txtMaPhong.Enabled = false;
            SetControlState(false);

            // 3. Load dữ liệu lên bảng
            LoadData();
        }
        private void LoadData()
        {
            try
            {

                //  TỰ ĐỘNG ĐỒNG BỘ TRẠNG THÁI PHÒNG VỚI BẢNG HỢP ĐỒNG

                var danhSachPhong = context.Phongs.ToList();

                foreach (var p in danhSachPhong)
                {
                    // Kiểm tra: Có cái hợp đồng nào của phòng này mà trạng thái đang là "Còn hạn" không?
                    bool dangCoNguoiThu = context.HopDongs.Any(h => h.MaPhong == p.MaPhong && h.TrangThai == "Còn hạn");

                    if (dangCoNguoiThu)
                    {
                        // Có người đang thuê thì chắc chắn phòng phải là "Đã thuê"
                        p.TrangThai = "Đã thuê";
                    }
                    else if (p.TrangThai == "Đã thuê")
                    {
                        // Nếu không có ai thuê (hoặc hợp đồng đã Hết hạn/Đã hủy) mà trạng thái vẫn treo "Đã thuê"
                        // thì trả nó về "Trống"
                        p.TrangThai = "Trống";
                    }
                }


                context.SaveChanges();

                // BƯỚC 2: ĐỔ DỮ LIỆU LÊN BẢNG (Giữ nguyên logic cực bén của ní)

                var listPhong = context.Phongs.Select(p => new
                {
                    p.MaPhong,
                    p.TenPhong,
                    p.GiaPhong,
                    p.SoNguoiToiDa,
                    p.TrangThai, // Trạng thái này lúc lấy lên đã là trạng thái chuẩn nhất (vừa được update ở Bước 1)

                    // Code cũ của ní: Lấy mã hợp đồng mới nhất
                    MaHopDong = p.HopDongs.OrderByDescending(h => h.MaHopDong).Select(h => h.MaHopDong).FirstOrDefault()
                }).ToList();

                dgvPhong.AutoGenerateColumns = false;
                dgvPhong.DataSource = listPhong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hoặc đồng bộ dữ liệu phòng: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetControlState(bool editing)
        {
            txtTenPhong.Enabled = editing;
            nmGiaPhong.Enabled = editing;
            nmSoNguoiToiDa.Enabled = editing;
            cboTrangThai.Enabled = editing;

            // ĐIỂM CHỐT LOGIC: Ô Hợp Đồng luôn luôn bị khóa (chỉ để xem)


            btnThem.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
        }
        private void ClearInput()
        {
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            nmGiaPhong.Value = 0;
            nmSoNguoiToiDa.Value = 0;
            cboTrangThai.SelectedIndex = 0;

        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            SetControlState(true);
            txtTenPhong.Focus();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phòng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtMaPhong.Text);
                    var phong = context.Phongs.Find(id);
                    if (phong != null)
                    {
                        context.Phongs.Remove(phong);
                        context.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                        ClearInput();
                        SetControlState(false);
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show("Lỗi khi xóa: " + msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // THÊM MỚI
                    Phong p = new Phong
                    {
                        TenPhong = txtTenPhong.Text.Trim(),
                        GiaPhong = (int)nmGiaPhong.Value,
                        SoNguoiToiDa = (int)nmSoNguoiToiDa.Value,
                        TrangThai = cboTrangThai.Text
                    };
                    context.Phongs.Add(p);
                }
                else
                {
                    // CẬP NHẬT (SỬA)
                    int id = int.Parse(txtMaPhong.Text);
                    Phong p = context.Phongs.Find(id);
                    if (p != null)
                    {
                        p.TenPhong = txtTenPhong.Text.Trim();
                        p.GiaPhong = (int)nmGiaPhong.Value;
                        p.SoNguoiToiDa = (int)nmSoNguoiToiDa.Value;
                        p.TrangThai = cboTrangThai.Text;
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                isAdding = false;
                SetControlState(false);
                LoadData();
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Có lỗi xảy ra khi lưu: " + msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];

                txtMaPhong.Text = row.Cells["colMaPhong"].Value.ToString();
                txtTenPhong.Text = row.Cells["colTenPhong"].Value.ToString();
                nmGiaPhong.Value = Convert.ToDecimal(row.Cells["colGiaPhong"].Value);
                nmSoNguoiToiDa.Value = Convert.ToDecimal(row.Cells["colSoNguoi"].Value);
                cboTrangThai.Text = row.Cells["colTrangThai"].Value.ToString();

                // Khi click vào bảng thì hiểu là đang muốn Sửa
                isAdding = false;
                SetControlState(true);
                btnXoa.Enabled = true;
            }
        }

        private void frmPhong_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
