using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ShoppingList
{
    public class ShoppingListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;   
        public bool IsPurchased { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}