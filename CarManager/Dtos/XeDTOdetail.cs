using System.ComponentModel.DataAnnotations;
using CarManager.Models;
using Newtonsoft.Json;

namespace CarManager.Dtos
{
    public class XeDTOdetail
    {
        [Required]
        public string? XeId { get; set; }
        public string? TenXe { get; set; }
        public string? BienSo { get; set; }
        public string? TaiTrong { get; set; }
        [Required]
        [JsonProperty(PropertyName = "TuyenDuong")]
        public TuyenDuongDTO TuyenDuong { get; set; }
    }
    public class TuyenDuongDTO
    {
        public int? TuyenDuongId { get; set; }
        public string? QuangDuong { get; set; }
        public string? DiemBD { get; set; }
        public string? DiemKT { get; set; }
    }
}
