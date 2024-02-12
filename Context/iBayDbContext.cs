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
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Cart)
                .HasForeignKey(p => p.CartId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

