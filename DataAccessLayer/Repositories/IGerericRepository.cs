using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IGerericRepository<T> where T : BaseEntity, new()
    {
        Task<Guid> Add(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<bool> RemoveById(Guid id);
        Task<bool> Update(T item);
        Task<T> GetByPredicate(Expression<Func<T, bool>> predicate);
    }
}
