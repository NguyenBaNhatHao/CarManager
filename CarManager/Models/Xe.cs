using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CarManager.Models
{
    public class Xe
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? XeId { get; set; }
        public string? TenXe { get; set; }
        public string? BienSo { get; set; }
        public string? TaiTrong { get; set; }
        public int? TuyenDuongId { get; set; }
        public TuyenDuong TuyenDuong { get; set; }
    }
}
