using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ShoppingItem;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class ShoppingItemRepository : IShoppingItemRepository
  {

    private readonly ApplicationDBContext _context;

    public ShoppingItemRepository (ApplicationDBContext context)
        {
          _context = context; 
        }


    public async Task<List<ShoppingItem>> GetAllAsync()
    {
      return await _context.ShoppingItems.ToListAsync();
    }


    public async Task<ShoppingItem?> GetByIdAsync(int id)
    {
      return await _context.ShoppingItems
        // .Include(c => c.Comments)
        .FirstOrDefaultAsync(x => x.Id == id); 
    }


    public async Task<ShoppingItem> CreateAsync(ShoppingItem ShoppingItemModel)
    {
      await _context.ShoppingItems.AddAsync(ShoppingItemModel); 
      await _context.SaveChangesAsync();
      return ShoppingItemModel; 
    }


    // public Task<ShoppingItem?> UpdateAsync(int id, UpdateShoppingItemRequestDto ShoppingItemDto)
    // {
    //   throw new NotImplementedException();
    // }

    public async Task<ShoppingItem?> UpdateAsync(int id, UpdateShoppingItemRequestDto shoppingItemModel)
    {

      var ExistingShoppingItem = await _context.ShoppingItems.FindAsync (id); 

      if (ExistingShoppingItem == null) return null;

      var shoppingItem = shoppingItemModel.ToShoppingItemFromUpdateDto();

      ExistingShoppingItem.Name = shoppingItem.Name ;   
      ExistingShoppingItem.Quantity = shoppingItem.Quantity ; 
      ExistingShoppingItem.MeasurementUnit = shoppingItem.MeasurementUnit ; 
      ExistingShoppingItem.IsPurchased = shoppingItem.IsPurchased ; 
      ExistingShoppingItem.FoodType = shoppingItem.FoodType ; 
      // ExistingShoppingItem.ShoppingListId = shoppingItem.ShoppingListId ; 

      await _context.SaveChangesAsync();

      return ExistingShoppingItem;
    }


    public async Task<ShoppingItem?> DeleteAsync(int id)
    {
      var ShoppingItemModel = await _context.ShoppingItems.FirstOrDefaultAsync (x => x.Id == id); 

      if (ShoppingItemModel == null) return null;

      _context.ShoppingItems.Remove(ShoppingItemModel); 
          
      await _context.SaveChangesAsync();

      return ShoppingItemModel;
    }

    public Task<bool> ListExist(int id)
    {
      return _context.ShoppingLists.AnyAsync(l => l.Id == id);
    }


  }
}