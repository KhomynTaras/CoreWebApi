using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BooksRepository : IBooksRepository
    {
        private readonly EFCoreDBContext _dBContext; 

        public BooksRepository(EFCoreDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public Guid Add(Book book)
        {
            book.Id = Guid.NewGuid();

            _dBContext.Books.Add(book);
            _dBContext.SaveChanges();

            return book.Id;
        }

        public IEnumerable<Book> GetAll()
        {
            return _dBContext.Books.ToList();
        }

        public Book GetById(Guid id)
        {
            return _dBContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            return _dBContext.Books.Where(book => book.Author == author);
        }

        public bool Update(Book book)
        {
            _dBContext.Books.Update(book);

            return _dBContext.SaveChanges() > 0;
        }

        public bool RemoveById(Guid id)
        {
            var book = new Book { Id = id };
            _dBContext.Entry(book).State = EntityState.Deleted;

            return _dBContext.SaveChanges() > 0;
        }
    }
}
