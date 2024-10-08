using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ShoppingList;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{

  [Route("api/shoppingList")]
  [ApiController]
    public class ShoppingListController : ControllerBase

    {
        private readonly ApplicationDBContext _context;
        public ShoppingListController(ApplicationDBContext context)
        {
          _context = context; 
        }

        [HttpGet]
        // public IActionResult GetAll()
        public async Task<IActionResult> GetAll()
        {
          // var shoppingLists = _context.ShoppingLists.ToList()
          var shoppingLists = await _context.ShoppingLists.ToListAsync();

          var shoppingListDto = shoppingLists.Select(s => s.ToShoppingListDto());

          return Ok(shoppingListDto); 
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
          var shoppingList = await _context.ShoppingLists.FindAsync(id);

          if (shoppingList == null) return NotFound();
          
          return Ok(shoppingList.ToShoppingListDto()); 
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShoppingListRequestDto ShoppingListDto){

          var shoppingListModel = ShoppingListDto.ToShoppingListFromCreateDto(); 

          await _context.ShoppingLists.AddAsync(shoppingListModel);
          await _context.SaveChangesAsync();

          return CreatedAtAction(nameof(GetById), new { id = shoppingListModel.Id }, shoppingListModel.ToShoppingListDto()); 

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShoppingListRequestDto ShoppingListDto){

          var shoppingListModel = await _context.ShoppingLists.FirstOrDefaultAsync(x => x.Id == id); 

          if (shoppingListModel == null) return NotFound(); 


          shoppingListModel.Name = ShoppingListDto.Name; 
          shoppingListModel.IsPurchased = ShoppingListDto.IsPurchased; 

          await _context.SaveChangesAsync();

          return Ok(shoppingListModel.ToShoppingListDto()); 

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete ([FromRoute] int id){

          var shoppingListModel = await _context.ShoppingLists.FirstOrDefaultAsync(x => x.Id == id); 

          if (shoppingListModel == null) return NotFound(); 

          _context.ShoppingLists.Remove(shoppingListModel);
          
          await _context.SaveChangesAsync();

          return Ok(shoppingListModel.ToShoppingListDto()); 

        }

    }
}