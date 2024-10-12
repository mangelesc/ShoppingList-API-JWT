using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ShoppingItem;
using api.Models;

namespace api.Interfaces
{
    public interface IShoppingItemRepository
    {
        Task<List<ShoppingItem>> GetAllAsync(); 
        Task<ShoppingItem?> GetByIdAsync(int id); 
        Task<ShoppingItem> CreateAsync(ShoppingItem ShoppingItemModel); 
        Task<ShoppingItem?> UpdateAsync (int id, UpdateShoppingItemRequestDto ShoppingItemDto); 
        Task<ShoppingItem?> DeleteAsync (int id); 
        Task<bool> ListExist(int id);
  }
}