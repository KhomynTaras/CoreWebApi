using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GerericRepository<T> : IGerericRepository<T> where T : BaseEntity, new()
    {
        private readonly EFCoreDBContext _dBContext;
        private readonly DbSet<T> _dbSet;

        public GerericRepository(EFCoreDBContext dBContext)
        {
            _dBContext = dBContext;
            _dbSet = _dBContext.Set<T>();
        }
        public async Task<Guid> Add(T item)
        {
            item.Id = Guid.NewGuid();

            _dbSet.Add(item);
            await _dBContext.SaveChangesAsync();

            return item.Id;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task <bool> Update(T item)
        {
            _dBContext.Entry(item).State = EntityState.Modified;

            return await _dBContext.SaveChangesAsync() > 0;
        }

        public async Task<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<bool> RemoveById(Guid id)
        {
            var item = new T { Id = id };
            _dBContext.Entry(item).State = EntityState.Deleted;

            return await _dBContext.SaveChangesAsync() > 0;
        }
    }
}
