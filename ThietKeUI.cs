using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro
{
    public class ThietKeUI
    {
        public static Color MauNenForm = Color.FromArgb(240, 244, 248);     // Trắng xám nhạt
        public static Color MauNutBam = Color.FromArgb(30, 144, 255);       // Xanh dương (DodgerBlue)
        public static Color MauChuNut = Color.White;                        // Chữ trắng
        public static Color MauNenBang = Color.White;                       // Nền DataGridView
        public static Color MauTieuDeBang = Color.FromArgb(46, 139, 87);    // Xanh lá đậm (SeaGreen) cho Header
        public static Color MauChuTieuDe = Color.White;                     // Chữ Header trắng
        public static Color MauHangXenKe = Color.FromArgb(245, 245, 245);   // Xám rất nhạt xen kẽ cho dễ nhìn


        public static void FormatForm(Form frm)
        {
            frm.BackColor = MauNenForm;
            frm.Font = new Font("Segoe UI", 10F, FontStyle.Regular); // Font chữ chuẩn hiện đại
        }

        public static void FormatButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; // Bỏ viền
            btn.BackColor = MauNutBam;
            btn.ForeColor = MauChuNut;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; // Đưa chuột vào hiện bàn tay

            // Hiệu ứng hover (đưa chuột vào đổi màu nhẹ)
            btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(28, 130, 230); };
            btn.MouseLeave += (s, e) => { btn.BackColor = MauNutBam; };
        }
        public static void FormatDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false; // Phải có dòng này mới đổi màu Header được
            dgv.BackgroundColor = MauNenBang;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible = false; // Ẩn cột mũi tên trống bên trái
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bấm 1 ô là chọn cả dòng
            dgv.AllowUserToAddRows = false; // Tắt dòng trống dưới cùng
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động giãn cột

            // Chỉnh màu Header (Tiêu đề cột)
            dgv.ColumnHeadersDefaultCellStyle.BackColor = MauTieuDeBang;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = MauChuTieuDe;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;

            // Chỉnh màu dòng dữ liệu
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230); // Xanh lơ nhạt khi chọn
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.Height = 35; // Chỉnh chiều cao dòng cho thoáng

            // Xen kẽ màu dòng cho dễ nhìn
            dgv.AlternatingRowsDefaultCellStyle.BackColor = MauHangXenKe;
        }
        public static void ApDungToanBo(Form frm)
        {
            FormatForm(frm);

            // Tự động quét và làm đẹp tất cả control trên form
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is Button)
                {
                    FormatButton((Button)ctrl);
                }
                else if (ctrl is DataGridView)
                {
                    FormatDataGridView((DataGridView)ctrl);
                }
                // Nếu ní có dùng GroupBox hay Panel, nó sẽ quét thêm bên trong
                else if (ctrl is GroupBox || ctrl is Panel)
                {
                    foreach (Control subCtrl in ctrl.Controls)
                    {
                        if (subCtrl is Button) FormatButton((Button)subCtrl);
                        if (subCtrl is DataGridView) FormatDataGridView((DataGridView)subCtrl);
                    }
                }
            }
        }
    }
}




