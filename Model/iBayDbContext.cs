using Microsoft.EntityFrameworkCore;
using Cproject.Entities.Models;

namespace iBayProject.Data
{
    public class DbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product>? Product { get; set; }
        public DbSet<Cart>? Cart { get; set; }
        public DbSet<User>? User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(c => c.Cart)
                .WithOne(t => t.User)
                .HasForeignKey<Cart>(t => t.UserId);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Product)
                .WithOne(s => s.Cart)
                .HasForeignKey(s => s.CartId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

