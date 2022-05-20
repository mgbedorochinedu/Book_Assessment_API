using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book_Assessment_API.Data;
using Book_Assessment_API.Dtos.Catergory;
using Book_Assessment_API.Models;

namespace Book_Assessment_API.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _db;

        public CategoryService(IMapper mapper, DataContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<ServiceResponse<CategoryDto>> AddCategory(AddCategoryDto newCategory)
        {
            ServiceResponse<CategoryDto> serviceResponse = new ServiceResponse<CategoryDto>();
            try
            {
                Category category = _mapper.Map<Category>(newCategory);
                await _db.AddAsync(category);
                await _db.SaveChangesAsync();

                serviceResponse.Data =  _mapper.Map<CategoryDto>(category);
                serviceResponse.Message = "Added category";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<CategoryDto>> UpdateCategory(UpdateCategoryDto updateCategory)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<CategoryDto>> AddBooksToCategory(int id, List<int> bookIds)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<CategoryDto>> RemoveBooksFromCategory(int id, List<int> bookIds)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<CategoryDto>> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
