using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebHometaskMVC.Models
{
    public class LaptopContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Order> Orders { get; set; }

        public LaptopContext(DbContextOptions<LaptopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
