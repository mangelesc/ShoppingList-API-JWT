using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ShoppingItem;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class ShoppingItemRepository : IShoppingItemRepository
  {

    private readonly ApplicationDBContext _context;

    public ShoppingItemRepository(ApplicationDBContext context)
        {
          _context = context; 
        }


    public async Task<List<ShoppingItem>> GetAllAsync()
    {
      return await _context.ShoppingItems.ToListAsync();
    }


    public async Task<ShoppingItem> CreateAsync(ShoppingItem ShoppingItemModel)
    {
      await _context.ShoppingItems.AddAsync(ShoppingItemModel); 
      await _context.SaveChangesAsync();
      return ShoppingItemModel; 
    }


    public async Task<ShoppingItem?> GetByIdAsync(int id)
    {
      return await _context.ShoppingItems
        // .Include(c => c.Comments)
        .FirstOrDefaultAsync(x => x.Id == id); 
    }


    public async Task<ShoppingItem?> UpdateAsync(int id, UpdateShoppingItemRequestDto ShoppingItemDto)
    {
      var shoppingItemModel = await _context.ShoppingItems.FirstOrDefaultAsync (x => x.Id == id); 

      if (shoppingItemModel == null)
        {
          return null;
        }

      shoppingItemModel.Name = ShoppingItemDto.Name ;   
      shoppingItemModel.Quantity = ShoppingItemDto.Quantity ; 
      shoppingItemModel.MeasurementUnit = ShoppingItemDto.MeasurementUnit ; 
      shoppingItemModel.IsPurchased = ShoppingItemDto.IsPurchased ; 
      shoppingItemModel.FoodType = ShoppingItemDto.FoodType ; 
      // shoppingItemModel.ShoppingListId = ShoppingItemDto.ShoppingListId ;
      shoppingItemModel.Name = ShoppingItemDto.Name;  

      await _context.SaveChangesAsync();

      return shoppingItemModel;
    }


    public async Task<ShoppingItem?> DeleteAsync(int id)
    {
            var ShoppingItemModel = await _context.ShoppingItems.FirstOrDefaultAsync (x => x.Id == id); 

          if (ShoppingItemModel == null)
            {
              return null;
            }

      _context.ShoppingItems.Remove(ShoppingItemModel); 
          
      await _context.SaveChangesAsync();

      return ShoppingItemModel;
    }
  }
}