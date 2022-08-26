using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace CarManager.Dtos
{
    public class XeDTO
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string? XeId { get; set; }
        public string? TenXe { get; set; }
        public string? BienSo { get; set; }
        public string? TaiTrong { get; set; }
        public int? TuyenDuongId { get; set; }
        public CarManager.Models.TuyenDuong TuyenDuong { get; set; }
    }
}
