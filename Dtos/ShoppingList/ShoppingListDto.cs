using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ShoppingItem;
using api.Models;

namespace api.Dtos.ShoppingList
{
    public class ShoppingListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;   
        public bool IsPurchased { get; set; }  = false; 
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public required List<ShoppingItemDto> Items { get; set; }


    }
}