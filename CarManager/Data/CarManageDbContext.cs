using CarManager.Models;
using Microsoft.EntityFrameworkCore;
namespace CarManager.Data
{
    public class CarManageDbContext : DbContext
    {
        public CarManageDbContext(DbContextOptions<CarManageDbContext> options)
            : base(options)
        {
        }
        public DbSet<Xe> tb_Xe { get; set; }
        public DbSet<TuyenDuong> tb_Tuyenduong { get; set; }

    }
}
