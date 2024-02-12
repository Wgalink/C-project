using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cproject.entities.service
{
    public interface IBasicService<T>
    {
        public  T GetById(Guid id);
        public  Task<T> GetByIdAsync(Guid id);
        public List<T> GetAll();
        public Task<List<T>> GetAllAsync();
        public void Add(T entity);
        public Task AddAsync(T entity);
        public void Update(T entity);
        public void DeleteById(Guid id);
        public void SaveChanges();
        public Task SaveChangesAsync();
    }
}
