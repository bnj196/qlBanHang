using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebQLBanHang.Models
{
    public class SanPham
    {

        [Key] // Đánh dấu đây là khóa chính
        [StringLength(10)]
        [Display(Name = "Mã sản phẩm")]
        public string MaSP { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150)]
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Đơn giá")]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải >= 0")]
        public decimal DonGia { get; set; } = 0;

        [StringLength(255)]
        [Display(Name = "Ảnh sản phẩm")]
        public string? AnhSP { get; set; }

        [Display(Name = "Mô tả chi tiết")]
        public string? MoTaChiTiet { get; set; }

        [Display(Name = "Thông tin chi tiết")]
        public string? ThongTinChiTiet { get; set; }

        [Required(ErrorMessage = "Loại sản phẩm không được để trống")]
        [StringLength(10)]
        [Display(Name = "Mã loại SP")]
        public string MaLSP { get; set; } = string.Empty;

        [Required(ErrorMessage = "Đơn vị tính không được để trống")]
        [StringLength(10)]
        [Display(Name = "Mã ĐVT")]
        public string MaDVT { get; set; } = string.Empty;
    }

}
