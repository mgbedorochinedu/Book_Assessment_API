using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Assessment_API.Dtos.Book;
using Book_Assessment_API.Models;
using Book_Assessment_API.Services.BookService;

namespace Book_Assessment_API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookDto request)
        {
            if (ModelState.IsValid) 
                return Ok(await _bookService.AddBook(request));

            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return  BadRequest(message);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto request)
        {
            ServiceResponse<BookDto> response = await _bookService.UpdateBook(id, request);
            if (response.Data == null || !response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            return Ok(await _bookService.GetAllBook());
        }

        [HttpGet("favorites")]
        public async Task<IActionResult> FavoriteBook([FromQuery] bool request)
        {
            return Ok(await _bookService.FavoriteBooks(request));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            ServiceResponse<BookDto> response = await _bookService.DeleteBook(id);
            if (response.Data == null || !response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
