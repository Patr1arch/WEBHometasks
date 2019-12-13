using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebHometask4.Models
{
    public class FilmingContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Company> Companies { get; set; }

        public FilmingContext(DbContextOptions<FilmingContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
