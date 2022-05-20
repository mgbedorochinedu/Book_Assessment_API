using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book_Assessment_API.Dtos.Book;
using Book_Assessment_API.Models;

namespace Book_Assessment_API.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;

        public BookService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<ServiceResponse<ServiceResponse<GetBookDto>>> AddBook()
        {
            throw new NotImplementedException();
        }
    }
}
