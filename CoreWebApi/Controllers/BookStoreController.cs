using BL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookStoreController : ControllerBase
    {
        private readonly IBooksService _booksService;
        private readonly ILogger<BookStoreController> _logger;

        public BookStoreController(IBooksService booksService,  ILogger<BookStoreController> logger)
        {
            _booksService = booksService;
            _logger = logger;
        }

        [HttpPost("add")]
        public IActionResult AddBook(Book book)
        {
            try
            {
                var result = _booksService.AddBook(book);

                return Created(result.ToString(), book);
            }
            catch(ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("all")]
        public IEnumerable<Book> GetAllBooks()
        {
            return _booksService.GetAllBooks();
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public Book GetBookById(Guid id)
        {
            return _booksService.GetBookById(id);
        }

        [Route("[action]/{author}")]
        [HttpGet]
        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return _booksService.GetBookByAuthor(author);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, Book book)
        {
            try
            {
                book.Id = id;

                var result = _booksService.UpdateBook(book);

                return Created(result.ToString(), book);
            }
            catch (ArgumentException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public bool RemoveBook(Guid id)
        {
            return _booksService.RemoveBookById(id);
        }
    }
}
