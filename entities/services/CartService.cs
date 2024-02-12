using Microsoft.EntityFrameworkCore;
using Cproject.Entities.Models;
using Cproject.Context;



namespace Cproject.Entities.Services
{
    public class CartService(iBayDbContext ctx):IBasicService<Cart>

    {
        public Cart GetById(Guid id)
        {
            return ctx.Cart.SingleOrDefault(t => t.Id == id);
        }

        public async Task<Cart> GetByIdAsync(Guid id)
        {
            return await ctx.Cart.SingleOrDefaultAsync(t => t.Id == id);
        }

        public List<Cart> GetAll()
        {
            return ctx.Cart!.ToList();
        }

        public async Task<List<Cart>> GetAllAsync()
        {
            return await ctx.Cart!.ToListAsync();
        }

        public void Add(Cart entity)
        {
            ctx.Cart?.Add(entity);
        }

        public async Task AddAsync(Cart entity)
        {
            await ctx.Cart.AddAsync(entity);
        }

        public void Update(Cart entity)
        {
            ctx.Cart?.Update(entity);
        }

        public void DeleteById(Guid id)
        {
            ctx.Cart?.Remove(GetById(id));
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
