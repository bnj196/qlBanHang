using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebQLBanHang.Models;

namespace WebQLBanHang.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<DonViTinh> DonViTinh { get; set; }



        // 1. Danh sách
        public List<DonViTinh> DonViTinh_DS()
        {
            return DonViTinh.FromSqlRaw("EXEC DonViTinh_DS").ToList();
        }

        // 2. Chi tiết
        public DonViTinh? DonViTinh_CT(string maDVT)
        {
            return DonViTinh.FromSqlRaw("EXEC DonViTinh_CT @p0", maDVT).FirstOrDefault();
        }

        // 3. Thêm mới
        public void DonViTinh_Them(DonViTinh dvt)
        {
            Database.ExecuteSqlRaw(
                "EXEC DonViTinh_Them @p0, @p1",
                dvt.MaDVT, dvt.TenDVT);
        }

        // 4. Sửa
        public void DonViTinh_Sua(DonViTinh dvt)
        {
            Database.ExecuteSqlRaw(
                "EXEC DonViTinh_Sua @p0, @p1",
                dvt.MaDVT, dvt.TenDVT);
        }

        // 5. Xóa
        public void DonViTinh_Xoa(string maDVT)
        {
            Database.ExecuteSqlRaw("EXEC DonViTinh_Xoa @p0", maDVT);
        }

        // 1. Danh sách
        public List<SanPham> SanPham_DS()
        {
            return SanPham.FromSqlRaw("EXEC SanPham_DS").ToList();
        }

        // 2. Chi tiết
        public SanPham? SanPham_CT(string maSP)
        {
            return SanPham.FromSqlRaw("EXEC SanPham_CT @p0", maSP).FirstOrDefault();
        }

        // 3. Thêm mới
        public void SanPham_Them(SanPham sp)
        {
            Database.ExecuteSqlRaw(
                "EXEC SanPham_Them @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",
                sp.MaSP, sp.TenSP, sp.DonGia, sp.AnhSP, 
                sp.MoTaChiTiet, sp.ThongTinChiTiet, sp.MaLSP, sp.MaDVT);
        }

        // 4. Sửa
        public void SanPham_Sua(SanPham sp)
        {
            Database.ExecuteSqlRaw(
                "EXEC SanPham_Sua @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7",
                sp.MaSP, sp.TenSP, sp.DonGia, sp.AnhSP, 
                sp.MoTaChiTiet, sp.ThongTinChiTiet, sp.MaLSP, sp.MaDVT);
        }

        // 5. Xóa
        public void SanPham_Xoa(string maSP)
        {
            Database.ExecuteSqlRaw("EXEC SanPham_Xoa @p0", maSP);
        }
    }
}