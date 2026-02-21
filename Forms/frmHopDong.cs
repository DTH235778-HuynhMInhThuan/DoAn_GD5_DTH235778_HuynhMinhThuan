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
            cboTrangThai.Items.AddRange(new string[] { "Còn hạn", " Sắp Hết hạn", "Hết hạn" });
        }

        private void LoadData()
        {
            try
            {
                DateTime homNay = DateTime.Now.Date;
                DateTime motThangSau = homNay.AddMonths(1);

                // 1. Cập nhật trạng thái cho TẤT CẢ Hợp Đồng trước
                var tatCaHopDong = context.HopDongs.ToList();
                foreach (var hd in tatCaHopDong)
                {
                    if (hd.NgayKetThuc < homNay)
                        hd.TrangThai = "Hết hạn";
                    else if (hd.NgayKetThuc <= motThangSau)
                        hd.TrangThai = "Gần hết hạn";
                    else
                        hd.TrangThai = "Còn hạn";
                }
                // Lưu bước này để đảm bảo trạng thái HD trong DB đã chuẩn
                context.SaveChanges();

                // 2. CẬP NHẬT TRẠNG THÁI PHÒNG (Logic then chốt ở đây)
                var tatCaPhong = context.Phongs.ToList();
                foreach (var p in tatCaPhong)
                {
                    // Tìm xem phòng này có cái hợp đồng nào "đang hiệu lực" không 
                    // Hiệu lực = "Còn hạn" HOẶC "Gần hết hạn"
                    bool coNguoiO = context.HopDongs.Any(h => h.MaPhong == p.MaPhong &&
                                                        (h.TrangThai == "Còn hạn" || h.TrangThai == "Gần hết hạn"));

                    if (coNguoiO)
                        p.TrangThai = "Đã thuê"; // Chỉ cần có HD gần hết hạn hoặc còn hạn là Đã thuê
                    else
                        p.TrangThai = "Trống";    // Chỉ khi không tìm thấy HD nào còn/gần hết hạn mới Trống
                }
                context.SaveChanges(); // Lưu lại trạng thái phòng vào DB

                // 3. Hiển thị lên DataGridView
                var listHienThi = context.HopDongs.Select(h => new
                {
                    h.MaHopDong,
                    TenSV = h.SinhVien.TenSV,
                    TenPhong = h.Phong.TenPhong,
                    h.MaSV,
                    h.MaPhong,
                    h.NgayBatDau,
                    h.NgayKetThuc,
                    h.TienCoc,
                    h.TrangThai
                }).ToList();

                dgvHopDong.DataSource = listHienThi;

                // Ẩn cột mã
                if (dgvHopDong.Columns["MaSV"] != null) dgvHopDong.Columns["MaSV"].Visible = false;
                if (dgvHopDong.Columns["MaPhong"] != null) dgvHopDong.Columns["MaPhong"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

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

                // =====================================================================
                // 1.5 CHỐT CHẶN: MỖI SINH VIÊN CHỈ ĐƯỢC 1 PHÒNG
                // =====================================================================
                int maSVCheck = (int)cboSinhVien.SelectedValue;
                int maPhongCheck = (int)cboPhong.SelectedValue;

                if (isAdding) // Ràng buộc lúc THÊM MỚI
                {
                    // Kiểm tra sinh viên phân thân
                    bool daCoPhong = context.HopDongs.Any(h => h.MaSV == maSVCheck && h.TrangThai == "Còn hạn");
                    if (daCoPhong)
                    {
                        MessageBox.Show("Khoan ní ơi! Sinh viên này đang có một hợp đồng Còn hạn rồi. Mỗi người chỉ được 1 phòng thôi!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // =====================================================================
                    // 1.6 CHỐT CHẶN MỚI: PHÒNG ĐÃ CÓ CHỦ THÌ KHÔNG CHO THUÊ
                    // =====================================================================
                    bool phongDaCoNguoiThu = context.HopDongs.Any(h => h.MaPhong == maPhongCheck && h.TrangThai == "Còn hạn");
                    if (phongDaCoNguoiThu)
                    {
                        MessageBox.Show("Phòng này đang có người thuê (Hợp đồng Còn hạn). Vui lòng chọn phòng trống khác!", "Báo Động Đụng Hàng", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                else // Ràng buộc lúc SỬA
                {
                    if (!string.IsNullOrEmpty(txtMaHopDong.Text))
                    {
                        int maHDHienTai = int.Parse(txtMaHopDong.Text);

                        // Kiểm tra sinh viên phân thân (loại trừ hợp đồng đang sửa)
                        bool daCoPhongKhac = context.HopDongs.Any(h => h.MaSV == maSVCheck && h.TrangThai == "Còn hạn" && h.MaHopDong != maHDHienTai);
                        if (daCoPhongKhac)
                        {
                            MessageBox.Show("Lỗi rồi! Sinh viên này đang có một hợp đồng ở phòng khác!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // =====================================================================
                        // 1.6 CHỐT CHẶN MỚI: KIỂM TRA PHÒNG ĐÃ CÓ CHỦ KHI SỬA
                        // =====================================================================
                        bool phongDaCoNguoiThuKhac = context.HopDongs.Any(h => h.MaPhong == maPhongCheck && h.TrangThai == "Còn hạn" && h.MaHopDong != maHDHienTai);
                        if (phongDaCoNguoiThuKhac)
                        {
                            MessageBox.Show("Phòng bạn vừa đổi sang đang có người khác thuê. Vui lòng chọn phòng trống!", "Báo Động Đụng Hàng", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                // =====================================================================


                // 2. Xử lý Lưu dữ liệu
                if (isAdding) // Trường hợp THÊM MỚI
                {
                    HopDong hd = new HopDong()
                    {
                        MaSV = (int)cboSinhVien.SelectedValue,
                        MaPhong = (int)cboPhong.SelectedValue,
                        NgayBatDau = dtpNgayBatDau.Value,
                        NgayKetThuc = dtpNgayKetThuc.Value,
                        TienCoc = nmTienCoc.Value,
                        TrangThai = cboTrangThai.Text
                    };
                    context.HopDongs.Add(hd);

                    // Tìm phòng đó trong Database để cập nhật trạng thái
                    var phong = context.Phongs.Find(maPhongCheck);
                    if (phong != null)
                    {
                        phong.TrangThai = "Đã thuê";
                    }
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
                // Moi móc cái lỗi thực sự ẩn bên trong
                string loiThucSu = ex.Message;
                if (ex.InnerException != null)
                {
                    loiThucSu = ex.InnerException.Message;
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
            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    int maHD = int.Parse(txtMaHopDong.Text);

                    // 1. Tìm cái hợp đồng cần xóa
                    var hd = context.HopDongs.FirstOrDefault(h => h.MaHopDong == maHD);

                    if (hd != null)
                    {
                        // 2. TÌM CÁI PHÒNG CỦA HỢP ĐỒNG ĐÓ VÀ ĐỔI TRẠNG THÁI LẠI
                        // (Lưu ý: Chữ "hd.MaPhong" phải đúng với tên thuộc tính khóa ngoại mã phòng trong bảng HopDong của ní nha)
                        var phong = context.Phongs.FirstOrDefault(p => p.MaPhong == hd.MaPhong);
                        if (phong != null)
                        {
                            phong.TrangThai = "Trống"; // Gán lại thành Trống
                        }

                        // 3. Tiến hành xóa hợp đồng
                        context.HopDongs.Remove(hd);

                        // 4. Lưu tất cả thay đổi xuống Database (Vừa xóa HĐ, vừa cập nhật Phòng)
                        context.SaveChanges();

                        MessageBox.Show("Xóa thành công và đã cập nhật lại trạng thái phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearInput();
                        LoadData();
                        SetControlState(false);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            ThietKeUI.ApDungToanBo(this);
            LoadData(); // Gọi hàm này để vừa mở lên là nó quét hợp đồng luôn




            LoadComboBox();
            LoadData();
            SetControlState(false);
        }
        private void printDocHopDong_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int yPos = 40;
            int leftMargin = 50;

            // 1. Khai báo Font chữ
            Font fontQuocHieu = new Font("Times New Roman", 13, FontStyle.Bold);
            Font fontTieuNgu = new Font("Times New Roman", 14, FontStyle.Bold);
            Font fontTitle = new Font("Times New Roman", 18, FontStyle.Bold);
            Font fontHeader = new Font("Times New Roman", 13, FontStyle.Bold);
            Font fontNormal = new Font("Times New Roman", 13, FontStyle.Regular);
            Font fontItalic = new Font("Times New Roman", 13, FontStyle.Italic);

            // ==========================================
            // LẤY DỮ LIỆU TỪ CÁC CONTROL TRÊN FORM
            // ==========================================
            string maHopDong = txtMaHopDong.Text;
            string tenSV = cboSinhVien.Text; // Lấy tên SV đang hiển thị
            string phong = cboPhong.Text;    // Lấy tên Phòng đang hiển thị

            // Ép kiểu DateTimpicker ra chuỗi ngày tháng năm
            string ngayLap = dtpNgayBatDau.Value.ToString("dd/MM/yyyy");
            string ngayHetHan = dtpNgayKetThuc.Value.ToString("dd/MM/yyyy");

            // Lấy Tiền Cọc từ NumericUpDown (Dùng .Value và định dạng "N0" để có dấu phẩy 1,000,000)
            string tienCoc = nmTienCoc.Value.ToString("N0");

            // ==========================================
            // TRUY XUẤT THÊM DỮ LIỆU TỪ DATABASE (CCCD, SĐT, Giá Phòng)
            // ==========================================
            string cccd = "....................";
            string sdt = "....................";
            string giaThue = "....................";

            try
            {
                // Tìm thông tin Sinh Viên theo Mã SV đang chọn trong ComboBox
                if (cboSinhVien.SelectedValue != null && cboSinhVien.SelectedValue is int maSV)
                {
                    var sv = context.SinhViens.Find(maSV);
                    if (sv != null)
                    {
                        cccd = sv.CCCD;
                        sdt = sv.SDT; // Đổi lại tên cột cho đúng với DB của ní
                    }
                }

                // Tìm thông tin Phòng để lấy Giá Thuê
                if (cboPhong.SelectedValue != null && cboPhong.SelectedValue is int maPh)
                {
                    var p = context.Phongs.Find(maPh);
                    if (p != null)
                    {
                        giaThue = p.GiaPhong.ToString("N0"); // Đổi tên cột giá phòng cho đúng DB
                    }
                }
            }
            catch
            {
                // Nếu lỗi thì giữ nguyên dấu chấm "..." để in ra viết tay
            }

            // ==========================================
            // VẼ HỢP ĐỒNG LÊN GIẤY
            // ==========================================
            g.DrawString("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM", fontQuocHieu, Brushes.Black, new PointF(220, yPos));
            yPos += 25;
            g.DrawString("Độc lập - Tự do - Hạnh phúc", fontTieuNgu, Brushes.Black, new PointF(280, yPos));

            g.DrawLine(new Pen(Color.Black, 1.5f), 300, yPos + 25, 520, yPos + 25);
            yPos += 60;

            g.DrawString("HỢP ĐỒNG THUÊ PHÒNG TRỌ", fontTitle, Brushes.Black, new PointF(230, yPos));
            yPos += 40;
            g.DrawString($"Hôm nay, ngày {DateTime.Now.Day} tháng {DateTime.Now.Month} năm {DateTime.Now.Year}, tại nhà trọ...", fontItalic, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 40;

            // THÔNG TIN BÊN A (Ní tự điền tên chủ trọ cứng vào đây luôn cho lẹ)
            g.DrawString("BÊN CHO THUÊ (BÊN A):", fontHeader, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString("- Ông/Bà: Nguyễn Văn Chủ Trọ                            SĐT: 0988.xxx.xxx", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString("- Địa chỉ: Long Xuyên, An Giang", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 40;

            // THÔNG TIN BÊN B (Lấy từ dữ liệu Form & DB)
            g.DrawString("BÊN THUÊ (BÊN B):", fontHeader, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString($"- Ông/Bà: {tenSV}", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString($"- CMND/CCCD: {cccd}                   SĐT: {sdt}", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 40;

            g.DrawString("Hai bên cùng thỏa thuận ký hợp đồng thuê phòng với các điều khoản sau:", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 40;

            // ĐIỀU KHOẢN
            g.DrawString("Điều 1: Thông tin phòng thuê", fontHeader, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString($"- Bên A đồng ý cho bên B thuê phòng số: {phong}", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString($"- Giá thuê: {giaThue} VNĐ / Tháng (Chưa bao gồm điện, nước, dịch vụ).", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString($"- Tiền đặt cọc: {tienCoc} VNĐ. Số tiền này sẽ được hoàn trả khi hết hợp đồng.", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 40;

            g.DrawString("Điều 2: Thời hạn hợp đồng", fontHeader, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString($"- Hợp đồng có giá trị kể từ ngày {ngayLap} đến ngày {ngayHetHan}.", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 30;
            g.DrawString("- Khi hết hạn, nếu hai bên không có ý kiến gì thì Hợp đồng tự động gia hạn.", fontNormal, Brushes.Black, new PointF(leftMargin, yPos));
            yPos += 40;

            // CHỮ KÝ
            yPos += 30;
            g.DrawString("BÊN A (CHO THUÊ)", fontHeader, Brushes.Black, new PointF(100, yPos));
            g.DrawString("BÊN B (NGƯỜI THUÊ)", fontHeader, Brushes.Black, new PointF(550, yPos));
            yPos += 25;
            g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, Brushes.Black, new PointF(110, yPos));
            g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, Brushes.Black, new PointF(570, yPos));
        }

        private void btnInHopDong_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn Hợp đồng nào chưa
            if (string.IsNullOrEmpty(txtMaHopDong.Text))
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();

            // Gắn hàm in hợp đồng vừa viết vào
            printDoc.PrintPage += new PrintPageEventHandler(printDocHopDong_PrintPage);

            // Gắn tài liệu vào giao diện xem trước
            previewDialog.Document = printDoc;

            // Setup kích thước cửa sổ cho dễ nhìn
            previewDialog.Width = 850;
            previewDialog.Height = 900;
            previewDialog.StartPosition = FormStartPosition.CenterScreen;

            // Hiển thị lên
            previewDialog.ShowDialog();
        }
    }
}
