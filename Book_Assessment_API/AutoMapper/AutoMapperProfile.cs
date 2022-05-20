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
            CreateMap<Book, GetBookDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();

        }
    }
}
