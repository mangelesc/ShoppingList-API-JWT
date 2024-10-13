using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ShoppingList;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IShoppingListRepository
    {
      Task<List<ShoppingList>> GetAllAsync(QueryObject query);

      // Task<List<ShoppingList>> GetAllAsync(QueryObject query);
      Task<ShoppingList?> GetByIdAsync (int id); 
      Task<ShoppingList> CreateAsync (ShoppingList ShoppingListModel); 
      Task<ShoppingList?> UpdateAsync (int id, UpdateShoppingListRequestDto ShoppingListDto); 
      Task<ShoppingList?> DeleteAsync (int id); 
      Task<bool> ShoppingListExists (int id); 
    }
}