using BL.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services.BooksServices
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task<bool> RemoveBookById(Guid id);
        Task<bool> UpdateBook(Book book);
        Task<Guid> AddBook(Book book);
        Task<BookDto> GetBookFullInfo(Guid id);     
        Task<IEnumerable<Book>> GetBookByAuthor(string author);
    }
}
