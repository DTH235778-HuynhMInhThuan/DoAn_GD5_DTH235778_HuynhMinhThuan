using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.Data
{
    public class SinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int MaSV { get; set; }

        [Required]
        public string TenSV { get; set; }

        public string SDT { get; set; }
        public string CCCD { get; set; }
        public string QueQuan { get; set; }

        public ICollection<HopDong> HopDongs { get; set; }
    }
}
