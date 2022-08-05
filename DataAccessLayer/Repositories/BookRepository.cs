using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly EFCoreDBContext _dBContext;

        public BookRepository(EFCoreDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IEnumerable<Book>> GetByAuthor(string author)
        {
            return await _dBContext.Books.Where(book => book.Author == author).ToListAsync();
        }

        public async Task<(Book book, IEnumerable<BookRevision> bookRevisions)> GetFullInfo(Guid id)
        {
            var result = await _dBContext.BookRevisions.Include(x => x.Book).Where(x => x.BookId == id).ToListAsync();

            var book = result.FirstOrDefault()?.Book;

            return (book, result);
        }
    }
}
