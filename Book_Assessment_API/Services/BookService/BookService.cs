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

        public async Task<ServiceResponse<BookDto>> AddBook(AddBookDto newBook)
        {
            ServiceResponse<BookDto> serviceResponse = new ServiceResponse<BookDto>();
            try
            {
                Category dbCategory = await _db.Categories.Include(x => x.Book).FirstOrDefaultAsync(b => b.Id == newBook.CategoryId);
                if (dbCategory == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Category not found";

                    return serviceResponse;
                }

                Book book = new Book()
                {
                    AuthorName = newBook.AuthorName,
                    Description = newBook.Description,
                    IsFavorite = newBook.IsFavorite,
                    Category = dbCategory
                };
                await _db.Books.AddAsync(book);
                await _db.SaveChangesAsync();


                //Book book = _mapper.Map<Book>(newBook);
                //await _db.AddAsync(book);
                //await _db.SaveChangesAsync();

                serviceResponse.Data =  _mapper.Map<BookDto>(book);
                serviceResponse.Message = "Book added successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<BookDto>> UpdateBook(int id, UpdateBookDto updateBook)
        {
            ServiceResponse<BookDto> serviceResponse = new ServiceResponse<BookDto>();
            try
            {
                Book book = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
                if (book != null)
                {
                    book.Title = updateBook.Title ?? book.Title;
                    book.AuthorName = updateBook.AuthorName ?? book.AuthorName;
                    book.Description = updateBook.Description ?? book.Description;
                    book.IsFavorite = updateBook.IsFavorite == book.IsFavorite ? book.IsFavorite : !book.IsFavorite;

                    book.DateModified = DateTime.Now;

                    _db.Books.Update(book);
                    await _db.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<BookDto>(book);
                    serviceResponse.Message = "Updated successfully";
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
                List<Book> dbBooks = await _db.Books.ToListAsync();
                if (dbBooks != null)
                {
                    serviceResponse.Data = dbBooks.Select(x => _mapper.Map<BookDto>(x)).ToList();
                    serviceResponse.Message = "Successfully fetched all books";
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Books not found.";
                }

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
