using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Assessment_API.Dtos.Catergory
{
    public class AddBooksToCategory
    {
        //[Required(ErrorMessage = "Title required")]
        //public string Title { get; set; }
        //[Required(ErrorMessage = "Author Name required")]
        //public string AuthorName { get; set; }
        //[Required(ErrorMessage = "Description required")]
        //public string Description { get; set; }
        //[Required(ErrorMessage = "IsFavorite required")]
        //public bool IsFavorite { get; set; }

        public int CategoryId { get; set; }
    }
}
