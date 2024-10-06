using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{

    public enum Unit
      {
          Units,
          Grams,   
          Kilograms, 
          Liters
      }
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 

        [Column(TypeName = "decimal(5,3)")]
        public decimal Quantity { get; set; }
        public Unit MeasurementUnit { get; set; }
        public bool IsPurchased { get; set; }
        public string FoodType { get; set; } = string.Empty; 

        // Foreign Key
        public int? ListId { get; set; }
        public ShoppingList? ShoppingList { get; set; }

        
    }
}