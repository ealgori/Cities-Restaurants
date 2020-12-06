using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class EfContext:DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public EfContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .HasMaxLength(150); 
            
            modelBuilder.Entity<Restaurant>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Name)
                .HasMaxLength(150);
        }
    }
}