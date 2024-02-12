using Microsoft.EntityFrameworkCore;
using Cproject.Entities.Models;

namespace Cproject.Context
{
    public class iBayDbContext(DbContextOptions<iBayDbContext> options) : DbContext(options)
    
    {
        public DbSet<Product>? Product { get; set; }
        public DbSet<Cart>? Cart { get; set; }
        public DbSet<User>? User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Cart)
                .HasForeignKey(p => p.CartId);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "test@test",
                    Pseudo = "test",
                    Password = "test",
                    Role = "test",
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

