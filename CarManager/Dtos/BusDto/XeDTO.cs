using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using CarManager.Models;
namespace CarManager.Dtos.BusDto
{
    public class XeDTO
    {
        [Required]
        public string? XeId { get; set; }
        public string? TenXe { get; set; }
        public string? BienSo { get; set; }
        public string? TaiTrong { get; set; }
        public int? TuyenDuongId { get; set; }
        public TuyenDuong? tuyenDuong { get; set; }
        
    }
}
