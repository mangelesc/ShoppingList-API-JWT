using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.ShoppingItem
{
    public class CreateShoppingItemRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [MaxLength(280, ErrorMessage ="Name cannot be over 280 characters")]
        public string Name { get; set; } = string.Empty; 

        [Required]
        [Range(0.001, 2000, ErrorMessage = "Quantity value must be between 0.001 and 2000")]        
        public decimal Quantity { get; set; }

        [Required]
        [Range(0, 3, ErrorMessage ="MeasurementUnit value must be between 0 and 3")]
        public Unit MeasurementUnit { get; set; }

        [Required]
        public bool IsPurchased { get; set; } = false; 

        [Required]
        [Range(0, 18, ErrorMessage ="FoodType value must be between 0 and 18")]
        public FoodType FoodType { get; set; }

        // Foreign Key
        // public int? ShoppingListId { get; set; }
    }
}