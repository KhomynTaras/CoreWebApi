using BL;
using BL.Services;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddBook(Book book)
        {
            try
            {
                var result = await _booksService.AddBook(book);

                return Created(result.ToString(), book);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _booksService.GetAllBooks();
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<Book> GetBookById(Guid id)
        {
            return await _booksService.GetBookById(id);
        }

        //[Route("[action]/{author}")]
        //[HttpGet]
        //public IEnumerable<Book> GetBooksByAuthor(string author)
        //{
        //    return _booksService.GetBookByAuthor(author);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, Book book)
        {
            try
            {
                book.Id = id;

                var result = await _booksService.UpdateBook(book);

                return Created(result.ToString(), book);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> RemoveBook(Guid id)
        {
            return await _booksService.RemoveBookById(id);
        }
    }
}
