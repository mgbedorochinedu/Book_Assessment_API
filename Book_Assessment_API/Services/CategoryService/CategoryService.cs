using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book_Assessment_API.Data;
using Book_Assessment_API.Dtos.Book;
using Book_Assessment_API.Dtos.Catergory;
using Book_Assessment_API.Models;
using Microsoft.EntityFrameworkCore;

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
                await _db.Categories.AddAsync(category);
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


        public async Task<ServiceResponse<CategoryDto>> UpdateCategory(int id, UpdateCategoryDto updateCategory)
        {
            ServiceResponse<CategoryDto> serviceResponse = new ServiceResponse<CategoryDto>();
            try
            {
                Category category = await _db.Categories.FirstOrDefaultAsync(c => c.Id.Equals(id));
                if (category != null)
                {
                    category.Name = updateCategory.Name ?? category.Name;

                    category.DateModified = DateTime.Now;

                    _db.Categories.Update(category);
                    await _db.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<CategoryDto>(category);
                    serviceResponse.Message = "Updated successfully";
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Category not found.";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CategoryDto>>> GetAllCategories()
        {
            ServiceResponse<List<CategoryDto>> serviceResponse = new ServiceResponse<List<CategoryDto>>();
            try
            {
                List<Category> dbCategories = await _db.Categories.ToListAsync();
                if (dbCategories != null)
                {
                    serviceResponse.Data = dbCategories.Select(c => _mapper.Map<CategoryDto>(c)).ToList();
                    serviceResponse.Message = "Successfully fetched all categories";
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Categories not found.";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }



        public async Task<ServiceResponse<CategoryDto>> DeleteCategory(int id)
        {
            ServiceResponse<CategoryDto> serviceResponse = new ServiceResponse<CategoryDto>();
            try
            {
                Category dbCategory = await _db.Categories.Include(x => x.Book).Where(c => c.Id == id).FirstOrDefaultAsync();
                if (dbCategory != null)
                {
                    _db.Remove(dbCategory);
                    await _db.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<CategoryDto>(dbCategory);
                    serviceResponse.Message = "Category successfully deleted";
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Category not found!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

      

        public async Task<ServiceResponse<BookDto>> AddBooksToCategory(int id, int bookId)
        {
            ServiceResponse<BookDto> serviceResponse = new ServiceResponse<BookDto>();
            try
            {
                Book dbBook = await _db.Books.FirstOrDefaultAsync(x => x.Id == bookId);
                if(dbBook != null)
                {
                    dbBook.CategoryId = id;
                    _db.Books.Update(dbBook);
                    await _db.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<BookDto>(await _db.Books.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == bookId));
                    serviceResponse.Success = true;
                    serviceResponse.Message = "Book Category successfully updated";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Book not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<BookDto>>> GetCategoryBooks(int id)
        {
            ServiceResponse<List<BookDto>> serviceResponse = new ServiceResponse<List<BookDto>>();
            try
            {
                List<Book> dbBooks = await _db.Books.Include(x => x.Category).Where(x => x.CategoryId == id).ToListAsync();
                if (dbBooks.Any())
                {
                    serviceResponse.Data = _mapper.Map<List<BookDto>>(dbBooks);
                    serviceResponse.Message = "Successfully fetched all category books";
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




    }
}
