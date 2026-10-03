using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WebQLBanHang.Models
{
    [Table("DonViTinh")] 
    public class DonViTinh
    {
        [Key] 

        public string MaDVT { get; set; } = string.Empty;

        public string TenDVT { get; set; } = string.Empty;

        public ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}