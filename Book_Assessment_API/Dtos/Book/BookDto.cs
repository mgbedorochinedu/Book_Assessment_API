using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Assessment_API.Dtos.Catergory;

namespace Book_Assessment_API.Dtos.Book
{
    public class BookDto
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }

    }
}
