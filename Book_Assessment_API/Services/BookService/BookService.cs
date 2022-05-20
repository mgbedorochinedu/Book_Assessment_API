using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book_Assessment_API.Data;
using Book_Assessment_API.Dtos.Book;
using Book_Assessment_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Assessment_API.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _db;

        public BookService(IMapper mapper, DataContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<ServiceResponse<List<BookDto>>> AddBook(AddBookDto newBook)
        {
            ServiceResponse<List<BookDto>> serviceResponse = new ServiceResponse<List<BookDto>>();
            try
            {
                Book book = _mapper.Map<Book>(newBook);
                await _db.AddAsync(book);
                await _db.SaveChangesAsync();

                serviceResponse.Date = await _db.Books.Select(x => _mapper.Map<BookDto>(x)).ToListAsync();
                serviceResponse.Message = "Book added successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}
