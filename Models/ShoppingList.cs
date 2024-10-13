using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;   
        public bool IsPurchased { get; set; } = false; 
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<ShoppingItem> Items { get; set; } = new List<ShoppingItem>();
    }
}