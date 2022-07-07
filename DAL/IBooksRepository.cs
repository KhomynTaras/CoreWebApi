using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBooksRepository
    {
        Guid Add(Book book);
        IEnumerable<Book> GetAll();
        Book GetById(Guid id);
        IEnumerable<Book> GetByAuthor(string author);
        bool RemoveById(Guid id);
        bool Update(Book book);
    }
}
