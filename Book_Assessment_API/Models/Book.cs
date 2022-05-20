using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Assessment_API.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; } = false;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}