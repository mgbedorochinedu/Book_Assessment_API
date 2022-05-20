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
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost("add-book")]
        public async Task<IActionResult> AddBook(AddBookDto request)
        {
            
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _bookService.AddBook(request));
        }

        [HttpPut("update-book")]
        public async Task<IActionResult> UpdateBook(UpdateBookDto request)
        {
            ServiceResponse<BookDto> response = await _bookService.UpdateBook(request);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
