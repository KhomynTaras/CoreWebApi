using DAL.Contexts;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookRepository
    {
        private readonly EFCoreDBContext _dBContext;

        public BookRepository(EFCoreDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        //public async Task<IEnumerable<Book>> GetByAuthor(string author)
        //{
        //    return await _dBContext.Books.Where(book => (book.Author == author));
        //}
    }
}
