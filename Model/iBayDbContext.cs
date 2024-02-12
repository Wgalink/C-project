using Microsoft.EntityFrameworkCore;
using iBayProject.Models; // Remplacez ceci par votre espace de noms approprié

namespace iBayProject.Data
{
    public class iBayDbContext : DbContext
    {
        public iBayDbContext(DbContextOptions<iBayDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        // Ajoutez d'autres DbSet ici pour d'autres entités
    }
}
