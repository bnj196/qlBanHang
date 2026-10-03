using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQLBanHang.Models
{
    [Table("NhomSP")]
    public class NhomSP
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "Mã nhóm sản phẩm")]
        public string MaNSP { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên nhóm sản phẩm không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên nhóm sản phẩm")]
        public string TenNSP { get; set; } = string.Empty;
    }
}