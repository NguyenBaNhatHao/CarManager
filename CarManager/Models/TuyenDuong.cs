using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarManager.Models
{
    public class TuyenDuong
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? TuyenDuongId { get; set; }
        public string? QuangDuong { get; set; }
        public string? DiemBD { get; set; }
        public string? DiemKT { get; set; }
    }
}
