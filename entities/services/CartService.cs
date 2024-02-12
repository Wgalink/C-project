using Microsoft.EntityFrameworkCore;
using C-project.entities.models;
using using C-project.entities.context;

namespace C-project.entities.service
{
    public class CartService(DbContext ctx):IBasicService<Cart>

    {
        public Cart GetById(Guid id)
        {
            return ctx.Carts.SingleOrDefault(t => t.Id == id);
        }

        public async Task<Cart> GetByIdAsync(Guid id)
        {
            return await ctx.Carts.SingleOrDefaultAsync(t => t.Id == id);
        }

        public List<Cart> GetAll()
        {
            return ctx.Carts!.ToList();
        }

        public async Task<List<Cart>> GetAllAsync()
        {
            return await ctx.Carts!.ToListAsync();
        }

        public void Add(Cart entity)
        {
            ctx.Carts?.Add(entity);
        }

        public async Task AddAsync(Cart entity)
        {
            await ctx.Carts.AddAsync(entity);
        }

        public void Update(Cart entity)
        {
            ctx.Carts?.Update(entity);
        }

        public void DeleteById(Guid id)
        {
            ctx.Carts?.Remove(GetById(id));
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
