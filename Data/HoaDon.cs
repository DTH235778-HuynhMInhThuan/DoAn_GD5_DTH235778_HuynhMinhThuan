using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.Data
{
    public class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        public int MaPhong { get; set; }

        public int Thang { get; set; }
        public int Nam { get; set; }

        public int TienPhong { get; set; }
        public int TienDien { get; set; }
        public int TienNuoc { get; set; }

        public int TongTien { get; set; }

       
        public string TrangThai { get; set; }

        [ForeignKey("MaPhong")]
        public Phong Phong { get; set; }
    }
}
