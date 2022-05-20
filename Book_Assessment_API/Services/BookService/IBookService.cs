using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Assessment_API.Dtos.Book;
using Book_Assessment_API.Models;

namespace Book_Assessment_API.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<BookDto>> AddBook(AddBookDto newBook);
        Task<ServiceResponse<BookDto>> UpdateBook(int id, UpdateBookDto updateBook);
        Task<ServiceResponse<List<BookDto>>> GetAllBook();
    }
}
