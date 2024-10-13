using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{

    public enum Unit
    {
        Units = 0,
        Grams = 1,
        Kilograms = 2,
        Liters = 3
    }


    public enum FoodType
    {
        Dairy = 0,
        Grains = 1,
        Meat = 2,
        Seafood = 3,
        Vegetables = 4,
        Fruits = 5,
        Beverages = 6,
        Snacks = 7,
        Condiments = 8,
        Frozen = 9,
        Canned = 10,
        Bakery = 12,
        ReadyToEat = 13,
        PersonalCare = 15,
        CleaningProducts = 16,
        Technology = 17,
        Miscellaneous = 18
    }
    
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 

        [Column(TypeName = "decimal(10,3)")]
        public decimal Quantity { get; set; }
        public Unit MeasurementUnit { get; set; }
        public bool IsPurchased { get; set; }  = false; 
        public FoodType FoodType { get; set; }

        // Foreign Key
        [ForeignKey("ShoppingListId")]
        public int? ShoppingListId { get; set; }

        // Navigation property
        public ShoppingList? ShoppingList { get; set; }

        
    }
}