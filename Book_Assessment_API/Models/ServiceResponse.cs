using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Assessment_API.Models
{
    public class ServiceResponse<T>
    {
        public T Date { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
    }
}
