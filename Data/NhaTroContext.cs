using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace QuanLyNhaTro.Data
{
    public class NhaTroContext : DbContext
    {
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<DienNuoc> DienNuocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                ConfigurationManager.ConnectionStrings["NhaTroDB"].ConnectionString);
        }
    }
}
