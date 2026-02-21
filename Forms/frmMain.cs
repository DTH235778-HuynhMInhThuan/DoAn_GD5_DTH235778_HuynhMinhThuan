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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    // Ép cái bạt xám đó phải xài chung hình nền với form chính
                    ctrl.BackgroundImage = this.BackgroundImage;
                    ctrl.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                }
            }
        }
        private void ShowForm(Type formType)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formType)
                {
                    // Nếu form đó đang mở rồi thì chỉ focus vào nó thôi (Tránh việc load lại làm mất dữ liệu ní đang gõ dở)
                    f.Activate();
                    return;
                }
            }

            // Bước 2: Nếu là một form KHÁC, thì mình sẽ quét và ĐÓNG TẤT CẢ các form con đang mở
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            // Bước 3: Sau khi dọn dẹp sạch sẽ, tạo và gọi form mới ra
            Form form = (Form)Activator.CreateInstance(formType);
            form.MdiParent = this; // Xác nhận frmMain là cửa sổ cha
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide(); // Ẩn Main đi

               
                 frmDangNhap fLogin = new frmDangNhap();
                 fLogin.ShowDialog();

                this.Close(); // Đóng hẳn Main
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát phần mềm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuQuanLySinhVien_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(frmSinhVien));
        }

        private void mnuQuanLyPhong_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(frmPhong));
        }

        private void mnuQuanLyDienNuoc_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(frmDienNuoc));
        }

        private void mnuQuanLyHopDong_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(frmHopDong));
        }

        private void mnuQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            ShowForm(typeof(frmHoaDon));
        }
    }
}
