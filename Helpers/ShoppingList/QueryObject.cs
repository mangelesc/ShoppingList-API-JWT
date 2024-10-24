using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        public string? Name { get; set; } = null; 
        public bool? IsPurchased { get; set; } 
        public DateTime? CreatedOn { get; set; }
        public bool DateTimeFilterBefore { get; set; } = false; 
        public bool DateTimeFilterAfter { get; set; } = false;  
        public string? SortBy { get; set; } = null; 
        public bool IsDescending { get; set; } = false; 
        public int PageNumber { get; set; } = 1; 
        public int PageSize { get; set; } = 10; 

    }
}