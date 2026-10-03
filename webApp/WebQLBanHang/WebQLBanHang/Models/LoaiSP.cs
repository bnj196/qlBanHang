using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQLBanHang.Models
{
    [Table("LoaiSP")]
    public class LoaiSP
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "Mã loại sản phẩm")]
        public string MaLSP { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên loại sản phẩm")]
        public string TenLSP { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn nhóm sản phẩm")]
        [StringLength(10)]
        [Display(Name = "Nhóm sản phẩm")]
        public string MaNSP { get; set; } = string.Empty;
    }
}