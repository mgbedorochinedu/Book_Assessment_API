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

                serviceResponse.Data = await _db.Books.Select(x => _mapper.Map<BookDto>(x)).ToListAsync();
                serviceResponse.Message = "Book added successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<BookDto>> UpdateBook(UpdateBookDto updateBook)
        {
            ServiceResponse<BookDto> serviceResponse = new ServiceResponse<BookDto>();
            try
            {
                Book book = await _db.Books.FirstOrDefaultAsync(x => x.Id.Equals(updateBook.Id));
                if (book != null)
                {
                    book.Title = updateBook.Title;
                    book.AuthorName = updateBook.AuthorName;
                    book.Description = updateBook.Description;
                    book.DateModified = DateTime.Now;

                    _db.Books.Update(book);
                    await _db.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<BookDto>(book);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Book not found.";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BookDto>>> GetAllBook()
        {
            ServiceResponse<List<BookDto>> serviceResponse = new ServiceResponse<List<BookDto>>();
            try
            {

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
