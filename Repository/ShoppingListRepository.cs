using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ShoppingList;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class ShoppingListRepository : IShoppingListRepository
  {


    // Dependency injection 
    private readonly ApplicationDBContext _context;

    public ShoppingListRepository(ApplicationDBContext context)
        {
          _context = context; 
        }
    // ----


    public async Task<List<ShoppingList>> GetAllAsync()
    {
      return await _context.ShoppingLists.ToListAsync();
    }


    // public async Task<List<ShoppingList>> GetAllAsync(QueryObject query)
    // {
    //   // return await _context.ShoppingLists
    //   // // include to get the comments
    //   //   .Include(c => c.Comments)
    //   //   .ToListAsync();

    //   // Console.WriteLine("Param " + query.CompanyName + query.Symbol);

    //   var ShoppingLists = _context.ShoppingLists
    //     // .Include(c => c.Comments)
    //     .AsQueryable();

    //   if (!string.IsNullOrWhiteSpace(query.CompanyName))
    //   {
    //     ShoppingLists = ShoppingLists.Where(s => s.CompanyName.Contains(query.CompanyName));
    //   }

    //   if (!string.IsNullOrWhiteSpace(query.Symbol))
    //   {
    //     ShoppingLists = ShoppingLists.Where(s => s.Symbol.Contains(query.Symbol));
    //   }

    //   return await ShoppingLists.ToListAsync();

    // }


    public async Task<ShoppingList?> GetByIdAsync(int id)
    {
      return await _context.ShoppingLists
        // .Include(c => c.Comments)
        .FirstOrDefaultAsync(x => x.Id == id); 
    }


    public async Task<ShoppingList> CreateAsync(ShoppingList ShoppingListModel)
    {
      await _context.ShoppingLists.AddAsync(ShoppingListModel); 
      await _context.SaveChangesAsync();
      return ShoppingListModel; 
    }


    public async Task<ShoppingList?> UpdateAsync(int id, UpdateShoppingListRequestDto ShoppingListDto)
    {
      var shoppingListModel = await _context.ShoppingLists.FirstOrDefaultAsync (x => x.Id == id); 

      if (shoppingListModel == null)
        {
          return null;
        }

      shoppingListModel.Name = ShoppingListDto.Name; 
      shoppingListModel.IsPurchased = ShoppingListDto.IsPurchased; 

      await _context.SaveChangesAsync();

      return shoppingListModel;
    }


    public async Task<ShoppingList?> DeleteAsync(int id)
    {
      var ShoppingListModel = await _context.ShoppingLists.FirstOrDefaultAsync (x => x.Id == id); 

      if (ShoppingListModel == null)
        {
          return null;
        }

      _context.ShoppingLists.Remove(ShoppingListModel); 
          
      await _context.SaveChangesAsync();

      return ShoppingListModel;
    }

    public Task<bool> ShoppingListExists(int id)
    {
      return _context.ShoppingLists.AnyAsync(s => s.Id == id);
    }
  }
}