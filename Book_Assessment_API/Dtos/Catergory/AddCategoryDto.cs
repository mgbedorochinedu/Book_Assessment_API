using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Book_Assessment_API.Dtos.Book;

namespace Book_Assessment_API.Dtos.Catergory
{
    public class AddCategoryDto
    {
        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }

    }
}
