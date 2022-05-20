using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Book_Assessment_API.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Book> Book { get; set; }
    }
}
