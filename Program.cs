//using QuanLyNhaTro.Forms;

using QuanLyNhaTro.Forms;

namespace QuanLyNhaTro
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Do An Ca Nhan");

            // 2. Sau đó mới đến các lệnh khởi tạo hệ thống
            ApplicationConfiguration.Initialize();

            // 3. Cuối cùng mới chạy Form
            Application.Run(new frmDangNhap());
        }
    }
}



