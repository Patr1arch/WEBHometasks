using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebHometask4.Models;

namespace WebHometask4.Models
{
    public class FilmingContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasKey(x => x.Id);
            modelBuilder.Entity<Company>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }

        public FilmingContext(DbContextOptions<FilmingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
