using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{

    public enum Unit
      {
          Units,
          Grams,   
          Kilograms, 
          Liters,     
          Milliliters 
      }
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public decimal Quantity { get; set; }
        public Unit MeasurementUnit { get; set; }
        public bool IsPurchased { get; set; }
        public string FoodType { get; set; } = string.Empty; 

        // Foreign Key
        public int? ListId { get; set; }
        public ShoppingList? ShoppingList { get; set; }

        
    }
}