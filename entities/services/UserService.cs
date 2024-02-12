using Microsoft.EntityFrameworkCore;
using Cproject.Entities.Models;
using Cproject.Context;

namespace Cproject.Entities.Services
{
    public class UserService(iBayDbContext ctx):IBasicService<User>

    {
        public User GetById(Guid id)
        {
            return ctx.User.SingleOrDefault(t => t.Id == id);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await ctx.User.SingleOrDefaultAsync(t => t.Id == id);
        }

        public List<User> GetAll()
        {
            return ctx.User!.ToList();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await ctx.User!.ToListAsync();
        }

        public void Add(User entity)
        {
            ctx.User?.Add(entity);
        }

        public async Task AddAsync(User entity)
        {
            await ctx.User.AddAsync(entity);
        }

        public void Update(User entity)
        {
            ctx.User?.Update(entity);
        }

        public void DeleteById(Guid id)
        {
            ctx.User?.Remove(GetById(id));
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
