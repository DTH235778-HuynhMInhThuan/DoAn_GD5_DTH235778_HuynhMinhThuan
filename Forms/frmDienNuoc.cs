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

        private void frmDienNuoc_Load(object sender, EventArgs e)
        {
            dgvDienNuoc.AutoGenerateColumns = false;
            LoadComboBox();
            LoadData();
            SetControlState(false);
        }
        private void LoadComboBox()
        {
            cboPhong.DataSource = context.Phongs.ToList();
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";
        }
        private void LoadData()
        {
            var listDN = context.DienNuocs.Select(d => new
            {
                MaDN = d.MaDN,
                MaPhong = d.MaPhong,
                TenPhong = d.Phong.TenPhong,
                NgayGhi = d.NgayGhi,
                ChiSoDienCu = d.ChiSoDienCu,
                ChiSoDienMoi = d.ChiSoDienMoi,
                ChiSoNuocCu = d.ChiSoNuocCu,
                ChiSoNuocMoi = d.ChiSoNuocMoi
            }).ToList();

            dgvDienNuoc.DataSource = listDN;
        }
        private void SetControlState(bool editing)
        {
            cboPhong.Enabled = editing;
            dtpNgayGhi.Enabled = editing;
            nmDienCu.Enabled = editing;
            nmDienMoi.Enabled = editing;
            nmNuocCu.Enabled = editing;
            nmNuocMoi.Enabled = editing;

            btnThem.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
            btnXoa.Enabled = !editing && dgvDienNuoc.Rows.Count > 0;
            btnThoat.Enabled = true;
        }
        private void ClearInputs()
        {
            txtMaDN.Clear();
            nmDienCu.Value = 0;
            nmDienMoi.Value = 0;
            nmNuocCu.Value = 0;
            nmNuocMoi.Value = 0;
            dtpNgayGhi.Value = DateTime.Now;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInputs();
            SetControlState(true);
            btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (nmDienMoi.Value < nmDienCu.Value)
            {
                MessageBox.Show("Chỉ số điện mới không được nhỏ hơn chỉ số cũ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmDienMoi.Focus();
                return;
            }
            if (nmNuocMoi.Value < nmNuocCu.Value)
            {
                MessageBox.Show("Chỉ số nước mới không được nhỏ hơn chỉ số cũ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nmNuocMoi.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Thêm mới
                    var dn = new DienNuoc
                    {
                        MaPhong = (int)cboPhong.SelectedValue,
                        NgayGhi = dtpNgayGhi.Value,
                        ChiSoDienCu = (int)nmDienCu.Value,
                        ChiSoDienMoi = (int)nmDienMoi.Value,
                        ChiSoNuocCu = (int)nmNuocCu.Value,
                        ChiSoNuocMoi = (int)nmNuocMoi.Value
                    };
                    context.DienNuocs.Add(dn);
                }
                else
                {
                    // Cập nhật (Sửa)
                    if (string.IsNullOrEmpty(txtMaDN.Text)) return;
                    int id = int.Parse(txtMaDN.Text);
                    var dn = context.DienNuocs.FirstOrDefault(d => d.MaDN == id);
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

                context.SaveChanges();
                MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (string.IsNullOrEmpty(txtMaDN.Text)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chốt điện nước này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = int.Parse(txtMaDN.Text);
                var dn = context.DienNuocs.FirstOrDefault(d => d.MaDN == id);
                if (dn != null)
                {
                    context.DienNuocs.Remove(dn);
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

        private void dgvDienNuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !isAdding) // Đang "Thêm" thì không cho click nhảy data
            {
                dynamic rowData = dgvDienNuoc.Rows[e.RowIndex].DataBoundItem;
                if (rowData != null)
                {
                    txtMaDN.Text = rowData.MaDN.ToString();
                    cboPhong.SelectedValue = rowData.MaPhong;
                    dtpNgayGhi.Value = rowData.NgayGhi;
                    nmDienCu.Value = Convert.ToDecimal(rowData.ChiSoDienCu);
                    nmDienMoi.Value = Convert.ToDecimal(rowData.ChiSoDienMoi);
                    nmNuocCu.Value = Convert.ToDecimal(rowData.ChiSoNuocCu);
                    nmNuocMoi.Value = Convert.ToDecimal(rowData.ChiSoNuocMoi);

                    SetControlState(true); // Mở khóa ô nhập để sửa
                    btnThem.Enabled = true; // Cho phép bấm thêm mới
                }
            }
        }
    }
}
