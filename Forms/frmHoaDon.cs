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
using System.Drawing.Printing;

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
            ThietKeUI.ApDungToanBo(this);
            dgvHoaDon.AutoGenerateColumns = false;
            // === 2 DÒNG CODE MỚI THÊM ĐỂ ÉP XÓA ĐỊNH DẠNG NGÀY THÁNG ===
            dgvHoaDon.Columns["colThang"].DefaultCellStyle.Format = "";
            dgvHoaDon.Columns["colNam"].DefaultCellStyle.Format = "";

            // Nạp sẵn 2 trạng thái nếu ní chưa nạp trên giao diện
            if (cboTrangThai.Items.Count == 0)
            {
                cboTrangThai.Items.Add("Chưa thanh toán");
                cboTrangThai.Items.Add("Đã thanh toán");
                cboTrangThai.Items.Add("Quá hạn");
            }

            LoadComboBox();
            LoadData();
            SetControlState(false);

            // Gắn sự kiện tự động tính tiền khi đổi Phòng, Tháng, Năm
            cboPhong.SelectedIndexChanged += AutoCalculate_Event;
            nmThang.ValueChanged += AutoCalculate_Event;
            nmNam.ValueChanged += AutoCalculate_Event;
            txtTienPhong.TextChanged += CapNhatTongTien_TrucTiep;
            txtTienDien.TextChanged += CapNhatTongTien_TrucTiep;
            txtTienNuoc.TextChanged += CapNhatTongTien_TrucTiep;
        }
        private void LoadComboBox()
        {

            var danhSachPhongDaThue = context.Phongs
                                     .Where(p => p.TrangThai == "Đã thuê")
                                     .ToList();


            cboPhong.DataSource = danhSachPhongDaThue;
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
            // 1. Kiểm tra phòng có đang thuê không
            if (cboPhong.SelectedValue == null) return;
            int maPhongSelected = (int)cboPhong.SelectedValue;
            var phong = context.Phongs.Find(maPhongSelected);

            if (phong == null || phong.TrangThai != "Đã thuê")
            {
                MessageBox.Show("Phòng này hiện đang TRỐNG, không thể tạo hóa đơn!",
                                "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Hàm xử lý tiền tệ: Gỡ bỏ dấu phẩy/chấm để chuyển thành số
                int GetMoneyFromText(string text) => string.IsNullOrWhiteSpace(text) ? 0 :
                    int.Parse(text.Replace(",", "").Replace(".", "").Replace(" ", ""));

                if (isAdding)
                {
                    // LOGIC MỚI: Chấp nhận cả hợp đồng "Còn hạn" HOẶC "Gần hết hạn"
                    bool coHopDongHieuLuc = context.HopDongs.Any(h => h.MaPhong == maPhongSelected &&
                                           (h.TrangThai == "Còn hạn" || h.TrangThai == "Gần hết hạn"));

                    if (!coHopDongHieuLuc)
                    {
                        MessageBox.Show("Phòng này hiện chưa có hợp đồng hiệu lực (hoặc đã hết hạn)!\nVui lòng kiểm tra lại trạng thái hợp đồng.",
                                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra số liệu điện nước
                    int tienDienCheck = GetMoneyFromText(txtTienDien.Text);
                    int tienNuocCheck = GetMoneyFromText(txtTienNuoc.Text);

                    if (tienDienCheck <= 0 || tienNuocCheck <= 0)
                    {
                        MessageBox.Show("Tiền điện và tiền nước chưa được tính!\nVui lòng chốt chỉ số trước khi lập hóa đơn.",
                                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // TIẾN HÀNH THÊM MỚI
                    var hd = new HoaDon
                    {
                        MaPhong = maPhongSelected,
                        Thang = (int)nmThang.Value,
                        Nam = (int)nmNam.Value,
                        TrangThai = cboTrangThai.Text,
                        TienPhong = GetMoneyFromText(txtTienPhong.Text),
                        TienDien = tienDienCheck,
                        TienNuoc = tienNuocCheck,
                        TongTien = GetMoneyFromText(txtTongTien.Text)
                    };
                    context.HoaDons.Add(hd);
                }
                else
                {
                    // CẬP NHẬT: Tìm đúng mã hóa đơn hiện tại để tránh sinh ra dòng mới
                    if (string.IsNullOrEmpty(txtMaHD.Text)) return;
                    int id = int.Parse(txtMaHD.Text);
                    var hdUpdate = context.HoaDons.FirstOrDefault(h => h.MaHoaDon == id);

                    if (hdUpdate != null)
                    {
                        hdUpdate.TrangThai = cboTrangThai.Text; // Chỉ cập nhật trạng thái thanh toán
                                                                // Nếu ní muốn cập nhật cả tiền thì gán thêm ở đây
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        private void CapNhatTongTien_TrucTiep(object sender, EventArgs e)
        {
            try
            {
                // Hàm gỡ bỏ dấu phẩy để chuyển chữ thành số chuẩn
                int GetMoney(string text) => string.IsNullOrWhiteSpace(text) ? 0 : int.Parse(text.Replace(",", "").Replace(".", ""));

                // Lấy số tiền đang hiển thị thực tế trên màn hình
                int tienPhong = GetMoney(txtTienPhong.Text);
                int tienDien = GetMoney(txtTienDien.Text);
                int tienNuoc = GetMoney(txtTienNuoc.Text);

                // Cộng lại và gán cho ô Tổng tiền
                int tongTien = tienPhong + tienDien + tienNuoc;
                txtTongTien.Text = tongTien.ToString("N0");
            }
            catch
            {
                // Bỏ qua lỗi nếu người dùng gõ sai định dạng chữ cái
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHoaDon.Rows[e.RowIndex].Cells["colTrangThai"].Value != null)
            {
                // Lấy thông tin của dòng đang xét
                // LƯU Ý: Đổi tên "colTrangThai", "colThang", "colNam" cho khớp với tên cột trong DataGridView của ní nha
                string trangThai = dgvHoaDon.Rows[e.RowIndex].Cells["colTrangThai"].Value.ToString();
                int thang = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["colThang"].Value);
                int nam = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["colNam"].Value);

                // GIẢ SỬ LUẬT NHÀ TRỌ: Mùng 5 của tháng TIẾP THEO là hạn chót đóng tiền
                // Ví dụ: Hóa đơn tháng 4/2026 -> Hạn chót là ngày 5/5/2026
                DateTime hanChot = new DateTime(nam, thang, 1).AddMonths(1).AddDays(4);

                // Nếu tình trạng là chưa thanh toán VÀ ngày hôm nay đã vượt quá hạn chót
                if (trangThai == "Chưa thanh toán" && DateTime.Now.Date > hanChot.Date)
                {
                    // Nhuộm đỏ nguyên dòng để cảnh báo
                    dgvHoaDon.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                    dgvHoaDon.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (trangThai == "Đã thanh toán")
                {
                    // Nhuộm xanh lá cho những phòng ngoan ngoãn đóng tiền đúng hạn
                    dgvHoaDon.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                    dgvHoaDon.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // Đặt tọa độ Y ban đầu (cách lề trên 50 pixel) và lề trái 50 pixel
            int yPos = 50;
            int leftMargin = 50;

            // 1. Khai báo các loại Font chữ sẽ dùng
            Font fontTitle = new Font("Arial", 20, FontStyle.Bold);     // Chữ to in đậm cho Tiêu đề
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);    // In đậm cho đầu mục
            Font fontNormal = new Font("Arial", 12, FontStyle.Regular); // Chữ thường
            Font fontItalic = new Font("Arial", 11, FontStyle.Italic);  // Chữ nghiêng

            // Lấy dữ liệu từ Form Hóa Đơn của ní
            // LƯU Ý: Ní nhớ đổi tên các ô txt... cho khớp với Design của ní nha!
            string maHD = txtMaHD.Text;
            string phong = cboPhong.Text;
            string thang = nmThang.Value.ToString();
            string nam = nmNam.Value.ToString();
            string tienPhong = txtTienPhong.Text;
            string tienDien = txtTienDien.Text;
            string tienNuoc = txtTienNuoc.Text;
            string tongTien = txtTongTien.Text;

            // ==========================================
            // PHẦN 1: TIÊU ĐỀ VÀ THÔNG TIN CHUNG
            // ==========================================
            g.DrawString("PHIẾU THU TIỀN NHÀ TRỌ", fontTitle, Brushes.Black, new PointF(220, yPos));
            yPos += 40; // Tăng Y lên 40 để xuống dòng
            g.DrawString($"Ngày in: {DateTime.Now.ToString("dd/MM/yyyy")}", fontItalic, Brushes.Black, new PointF(330, yPos));
            yPos += 50;

            g.DrawString($"Mã hóa đơn: {maHD}", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString($"Phòng: {phong}", fontHeader, Brushes.Black, new PointF(leftMargin, yPos));
            g.DrawString($"Kỳ thu: Tháng {thang} / Năm {nam}", fontNormal, Brushes.Black, new PointF(450, yPos));
            yPos += 50;

            // ==========================================
            // PHẦN 2: BẢNG CHI TIẾT CÁC KHOẢN THU
            // ==========================================
            Pen pen = new Pen(Color.Black, 1); // Bút kẻ viền màu đen

            // Kẻ viền trên của bảng
            g.DrawLine(pen, leftMargin, yPos, 750, yPos);
            yPos += 10;

            // Tiêu đề cột
            g.DrawString("STT", fontHeader, Brushes.Black, new PointF(leftMargin + 10, yPos));
            g.DrawString("Nội dung thu", fontHeader, Brushes.Black, new PointF(leftMargin + 80, yPos));
            g.DrawString("Thành tiền (VNĐ)", fontHeader, Brushes.Black, new PointF(550, yPos));
            yPos += 30;

            // Kẻ đường ngăn cách tiêu đề cột và nội dung
            g.DrawLine(pen, leftMargin, yPos, 750, yPos);
            yPos += 20;

            // Dòng 1: Tiền phòng
            g.DrawString("1", fontNormal, Brushes.Black, new PointF(leftMargin + 10, yPos));
            g.DrawString("Tiền thuê phòng", fontNormal, Brushes.Black, new PointF(leftMargin + 80, yPos));
            g.DrawString(tienPhong, fontNormal, Brushes.Black, new PointF(550, yPos));
            yPos += 40;

            // Dòng 2: Tiền điện
            g.DrawString("2", fontNormal, Brushes.Black, new PointF(leftMargin + 10, yPos));
            g.DrawString("Tiền điện năng tiêu thụ", fontNormal, Brushes.Black, new PointF(leftMargin + 80, yPos));
            g.DrawString(tienDien, fontNormal, Brushes.Black, new PointF(550, yPos));
            yPos += 40;

            // Dòng 3: Tiền nước
            g.DrawString("3", fontNormal, Brushes.Black, new PointF(leftMargin + 10, yPos));
            g.DrawString("Tiền nước sinh hoạt", fontNormal, Brushes.Black, new PointF(leftMargin + 80, yPos));
            g.DrawString(tienNuoc, fontNormal, Brushes.Black, new PointF(550, yPos));
            yPos += 40;

            // Kẻ viền dưới của bảng
            g.DrawLine(pen, leftMargin, yPos, 750, yPos);
            yPos += 30;

            // ==========================================
            // PHẦN 3: TỔNG TIỀN VÀ CHỮ KÝ
            // ==========================================
            g.DrawString("TỔNG CỘNG:", fontTitle, Brushes.Black, new PointF(300, yPos));
            g.DrawString(tongTien, fontTitle, Brushes.Red, new PointF(550, yPos)); // Chữ màu đỏ cho nổi bật
            yPos += 80;

            g.DrawString("Người nộp tiền", fontHeader, Brushes.Black, new PointF(100, yPos));
            g.DrawString("Người lập phiếu", fontHeader, Brushes.Black, new PointF(550, yPos));
            yPos += 20;
            g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, Brushes.Black, new PointF(95, yPos));
            g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, Brushes.Black, new PointF(545, yPos));
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn dưới bảng để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Khởi tạo đối tượng in ấn
            PrintDocument printDoc = new PrintDocument();
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();

            // 3. Gắn cái hàm "Vẽ" mà mình vừa viết ở Bước 1 vào đối tượng in
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

            // Gắn tài liệu vào hộp thoại xem trước
            previewDialog.Document = printDoc;

            // 4. Thiết lập kích thước cửa sổ xem trước cho to, dễ nhìn
            previewDialog.Width = 800;
            previewDialog.Height = 800;
            previewDialog.StartPosition = FormStartPosition.CenterScreen;

            // 5. Hiển thị lên màn hình
            previewDialog.ShowDialog();
        }
    }


}
