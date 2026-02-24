using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.Data
{
    public class Phong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Mã phòng tự tăng
        public int MaPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string TenPhong { get; set; }

        public int GiaPhong { get; set; }

        public int SoNguoiToiDa { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; } // Ví dụ: Trống, Đã thuê

        
        public ICollection<HopDong> HopDongs { get; set; }
    }
}
