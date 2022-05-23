using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Assessment_API.Dtos.Book;
using Book_Assessment_API.Dtos.Catergory;
using Book_Assessment_API.Models;

namespace Book_Assessment_API.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ServiceResponse<CategoryDto>> AddCategory(AddCategoryDto newCategory);
        Task <ServiceResponse<CategoryDto>> UpdateCategory(int id, UpdateCategoryDto updateCategory);
        Task<ServiceResponse<CategoryDto>> DeleteCategory(int id);
        Task<ServiceResponse<List<CategoryDto>>> GetAllCategories();
        Task<ServiceResponse<BookDto>> AddBooksToCategory(int id, int bookId);
        Task<ServiceResponse<List<BookDto>>> GetCategoryBooks(int id);
        //Task<ServiceResponse<CategoryDto>> AddBooksToCategory(int id, List<int> bookIds);
        //Task<ServiceResponse<CategoryDto>> RemoveBooksFromCategory(int id, List<int> bookIds);

    }
}
