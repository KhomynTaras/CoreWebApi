using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetByAuthor(string author);

        public Task<(Book book, IEnumerable<BookRevision> bookRevisions)> GetFullInfo(Guid id);
    }
}
