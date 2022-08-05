using BL;
using BL.DTOs;
using BL.Services.BooksServices;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IBookService _booksService;
        private readonly ILogger<BookStoreController> _logger;

        public BookStoreController(IBookService booksService,  ILogger<BookStoreController> logger)
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

        [Authorize(Roles = Roles.Reader)]
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

        [Route("[action]/{author}")]
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooksByAuthor(string author)
        {
            return await _booksService.GetBookByAuthor(author);
        }

        [HttpGet("full/{id}")]
        public async Task<BookDto> GetFullBookInfoById(Guid id)
        {
            return await _booksService.GetBookFullInfo(id);
        }

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
