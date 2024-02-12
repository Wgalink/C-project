using Microsoft.EntityFrameworkCore;
using C-project.entities.models;
using using C-project.entities.context;

namespace C-project.entities.service
{
    public class ProductService(DbContext ctx):IBasicService<Product>

    {
        public Product GetById(Guid id)
        {
            return ctx.Products.SingleOrDefault(t => t.Id == id);
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await ctx.Products.SingleOrDefaultAsync(t => t.Id == id);
        }

        public List<Product> GetAll()
        {
            return ctx.Products!.ToList();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await ctx.Products!.ToListAsync();
        }

        public void Add(Product entity)
        {
            ctx.Products?.Add(entity);
        }

        public async Task AddAsync(Product entity)
        {
            await ctx.Products.AddAsync(entity);
        }

        public void Update(Product entity)
        {
            ctx.Products?.Update(entity);
        }

        public void DeleteById(Guid id)
        {
            ctx.Products?.Remove(GetById(id));
        }

        public void SaveChanges()
        {
            ctx.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await ctx.SaveChangesAsync();
        }
    }
}
