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


    public enum FoodType
    {
        Dairy,            // 0 Lácteo
        Grains,           // 1 Grano
        Meat,             // 2 Carnes
        Seafood,          // 3 Mariscos/Pescado
        Vegetables,       // 4 Verduras
        Fruits,           // 5 Frutas
        Beverages,        // 6 Bebidas
        Snacks,           // 7 Snacks
        Condiments,       // 8 Condimentos
        Frozen,           // 9 Congelados
        Canned,           // 10 Enlatados
        Bakery,           // 12 Panadería
        ReadyToEat,       // 13 Listo para comer
        PersonalCare,     // 15 Cuidado personal (geles, desodorantes, etc.)
        CleaningProducts, // 16 Productos de limpieza (fregasuelos, detergentes, etc.)
        Technology,        // 17 Tecnología (gadgets, dispositivos electrónicos, etc.)
        Miscellaneous    // 18 Misceláneos
    }
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 

        [Column(TypeName = "decimal(10,3)")]
        public decimal Quantity { get; set; }
        public Unit MeasurementUnit { get; set; }
        public bool IsPurchased { get; set; }
        public FoodType FoodType { get; set; }

        // Foreign Key
        public int? ShoppingListId { get; set; }

        // Navigation property
        public ShoppingList? ShoppingList { get; set; }

        
    }
}