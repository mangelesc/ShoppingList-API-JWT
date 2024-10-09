using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.ShoppingItem
{
    public class UpdateShoppingItemRequestDto
    {
        public string Name { get; set; } = string.Empty; 
        public decimal Quantity { get; set; }
        public Unit MeasurementUnit { get; set; }
        public bool IsPurchased { get; set; }
        public FoodType FoodType { get; set; }

        // Foreign Key
        // public int? ShoppingListId { get; set; }
    }
}