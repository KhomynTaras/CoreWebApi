using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBooksService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(Guid id);
        IEnumerable<Book> GetBookByAuthor(string author);
        bool RemoveBookById(Guid id);
        bool UpdateBook(Book book);
        Guid AddBook(Book book);
    }
}
