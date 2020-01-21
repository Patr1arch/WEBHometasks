using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class cinemadbContext : DbContext
    {
        public cinemadbContext()
        {
        }

        public cinemadbContext(DbContextOptions<cinemadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Films> Films { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Halls> Halls { get; set; }
        public virtual DbSet<GenreFilm> GenreFilms { get; set; }

        public DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseLazyLoadingProxies()
                    .UseNpgsql("Host=127.0.0.1;Username=postgres;Password=password1234;Database=cinemadb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Films>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.CompanyId);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("numeric");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
