using Microsoft.EntityFrameworkCore;
using Cproject.Entities.Models;
using Cproject.Context;

namespace Cproject.Entities.Services
{
    public class ProductService(iBayDbContext ctx):IBasicService<Product>

    {
        public Product GetById(Guid id)
        {
            return ctx.Product.SingleOrDefault(t => t.Id == id);
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await ctx.Product.SingleOrDefaultAsync(t => t.Id == id);
        }
        public List<Product> GetAll()
        {
            return ctx.Product!.OrderBy(AddedTime => AddedTime).ToList();
        }

        public List<Product> GetAllBy(object type)
        {
            return ctx.Product!.OrderBy(type => type).ToList();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await ctx.Product!.ToListAsync();
        }

        public void Add(Product entity)
        {
            ctx.Product?.Add(entity);
        }

        public async Task AddAsync(Product entity)
        {
            await ctx.Product.AddAsync(entity);
        }

        public void Update(Product entity)
        {
            ctx.Product?.Update(entity);
        }

        public void DeleteById(Guid id)
        {
            ctx.Product?.Remove(GetById(id));
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
