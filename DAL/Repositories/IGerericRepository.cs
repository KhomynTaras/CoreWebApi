using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IGerericRepository<T> where T : BaseEntity, new()
    {
        Task<Guid> Add(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<bool> RemoveById(Guid id);
        Task<bool> Update(T item); 
    }
}
