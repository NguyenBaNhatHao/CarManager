﻿using CarManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarManager.Data
{
    public class CarManageDbContext : DbContext
    {
        public CarManageDbContext(DbContextOptions<CarManageDbContext> options)
            : base(options)
        {
        }
        public DbSet<Xe> tb_xe { get; set; }
    }
}