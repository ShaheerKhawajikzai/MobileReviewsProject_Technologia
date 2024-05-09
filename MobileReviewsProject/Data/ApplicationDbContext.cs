using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MobileReviewsProject.Models;

namespace MobileReviewsProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand() { Id = 1, Name = "Samsung" },
                new Brand() { Id = 2, Name = "Apple" },
                new Brand() { Id = 3, Name = "Vivo" },
                new Brand() { Id = 4, Name = "Techno" },
                new Brand() { Id = 5, Name = "Oppo" }
                );

        }
    }
}
