using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task<bool> RemoveBookById(Guid id);
        Task<bool> UpdateBook(Book book);
        Task<Guid> AddBook(Book book);
    }
}
