using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BookRepository
    {
        private readonly EFCoreDBContext _dBContext;

        public BookRepository(EFCoreDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IEnumerable<Book>> GetByAuthor(string author)
        {
            return await Task.Run(() =>
            _dBContext.Books.Where(book => (book.Author == author))
            );
        }
    }
}
