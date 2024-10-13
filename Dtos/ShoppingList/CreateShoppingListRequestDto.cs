using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ShoppingList
{
    public class CreateShoppingListRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [MaxLength(280, ErrorMessage ="Name cannot be over 280 characters")]
        public string Name { get; set; } = string.Empty;   
        
        [Required]
        public bool IsPurchased { get; set; } = false; 
        // public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}