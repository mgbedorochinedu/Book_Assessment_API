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
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Category, UpdateBookDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Book, BookDto>()
                .ForMember(c => c.AuthorName, x => x.MapFrom(x => x.AuthorName))
                .ForMember(c => c.Title, x => x.MapFrom(x => x.Title))
                .ForMember(c => c.Description, x => x.MapFrom(x => x.Description))
                .ForMember(c => c.IsFavorite, x => x.MapFrom(x => x.IsFavorite))
                .ForMember(c => c.CategoryName, x => x.MapFrom(x => x.Category.Name));
        }
    }
}
