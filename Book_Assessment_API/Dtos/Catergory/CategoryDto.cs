using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Assessment_API.Dtos.Book;

namespace Book_Assessment_API.Dtos.Catergory
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public List<BookDto> Book { get; set; }
    }
}
