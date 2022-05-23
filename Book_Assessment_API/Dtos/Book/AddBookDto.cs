using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Book_Assessment_API.Dtos.Catergory;

namespace Book_Assessment_API.Dtos.Book
{
    public class AddBookDto
    {

        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Author Name is Required")]
        public string AuthorName { get; set; }


        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        public bool IsFavorite { get; set; }

        [Required (ErrorMessage = "Category is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid category")]
        public int CategoryId { get; set; }

    }
}
