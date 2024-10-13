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
        public bool DateTimeFilterBefore { get; set; } = false; // Indicador para filtrar antes
        public bool DateTimeFilterAfter { get; set; } = false;  // Indicador para filtrar después

    }
}