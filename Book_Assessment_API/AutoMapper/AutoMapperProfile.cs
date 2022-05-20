using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book_Assessment_API.Dtos.Book;
using Book_Assessment_API.Dtos.Catergory;
using Book_Assessment_API.Models;

namespace Book_Assessment_API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Category, UpdateBookDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();

        }
    }
}
