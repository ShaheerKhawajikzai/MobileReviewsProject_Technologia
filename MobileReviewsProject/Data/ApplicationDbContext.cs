using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MobileReviewsProject.Models;
using MobileReviewsProject.Models.Admin;

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
        public DbSet<User> Users { get; set; }

        public DbSet<DeviceOldNewSlug> DevicesOldNewSlug { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand() { Id = 1, Name = "Samsung" },
                new Brand() { Id = 2, Name = "Apple" },
                new Brand() { Id = 3, Name = "Vivo" },
                new Brand() { Id = 4, Name = "Techno" },
                new Brand() { Id = 5, Name = "Oppo" }
                );

            modelBuilder.Entity<Device>().HasIndex(x => x.Slug).IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Name="Shaheer Khan", Email = "shaheersk12@gmail.com", IsActive = true, Password = "03330337272" }

                    );

        }
    }
}
