using BL.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services.BooksServices
{
    public class BookService : IBookService
    {
        private readonly IGerericRepository<Book> _genericBookRepository;
        private readonly IBookRepository _bookRepository;

        public BookService(IGerericRepository<Book> booksRepository, IBookRepository bookRepository)
        {
            _genericBookRepository = booksRepository;
            _bookRepository = bookRepository;
        }
        public async Task<Guid> AddBook(Book book)
        {
            return await _genericBookRepository.Add(book);
        }

        public async Task<bool> RemoveBookById(Guid id)
        {
            return await _genericBookRepository.RemoveById(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _genericBookRepository.GetAll();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _genericBookRepository.GetById(id);
        }

        public async Task<bool> UpdateBook(Book book)
        {
            return await _genericBookRepository.Update(book);
        }
        public async Task<IEnumerable<Book>> GetBookByAuthor(string author)
        {
            return await _bookRepository.GetByAuthor(author);
        }

        public async Task<BookDto> GetBookFullInfo(Guid id)
        {
            var result = await _bookRepository.GetFullInfo(id);

            return MapTupleToBookDto(result);
        }

        private BookDto MapTupleToBookDto((Book book, IEnumerable<BookRevision> bookRevisions) result)
        {
            return new BookDto
            {
                BookId = result.book.Id,
                Genre = result.book.Genre,
                Author = result.book?.Author,
                Title = result.book.Title,
                Price = result.book.Price,
                BookRevisions = MapRevisions(result.bookRevisions)
            };
        }

        private IEnumerable<BookRevisionDto> MapRevisions(IEnumerable<BookRevision> bookRevisions)
        {
            return bookRevisions.Select(x => new BookRevisionDto
            {
                Price = x.Price,
                PagesCount = x.PagesCount,
                YearOfPublishing = x.YearOfPublishing
            });
        }
    }
}
