using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ShoppingList;
using api.Interfaces;
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
        private readonly IShoppingListRepository _shoppingListRepository;
        public ShoppingListController(IShoppingListRepository shoppingListRepository)
        {
          _shoppingListRepository = shoppingListRepository; 
        }

        [HttpGet]
        // public IActionResult GetAll()
        public async Task<IActionResult> GetAll()
        {
          // var shoppingLists = _context.ShoppingLists.ToList()
          var shoppingLists = await _shoppingListRepository.GetAllAsync();

          var shoppingListDto = shoppingLists.Select(s => s.ToShoppingListDto());

          return Ok(shoppingListDto); 
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
          var shoppingList = await _shoppingListRepository.GetByIdAsync(id);

          if (shoppingList == null) return NotFound();
          
          return Ok(shoppingList.ToShoppingListDto()); 
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShoppingListRequestDto ShoppingListDto){

          var shoppingListModel = ShoppingListDto.ToShoppingListFromCreateDto(); 

          await _shoppingListRepository.CreateAsync(shoppingListModel);

          return CreatedAtAction(nameof(GetById), new { id = shoppingListModel.Id }, shoppingListModel.ToShoppingListDto()); 

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShoppingListRequestDto shoppingListDto){

          var shoppingListModel = await _shoppingListRepository.UpdateAsync(id, shoppingListDto); 

          if (shoppingListModel == null) return NotFound(); 

          return Ok(shoppingListModel.ToShoppingListDto()); 

        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete ([FromRoute] int id){

          var shoppingListModel = await _shoppingListRepository.DeleteAsync(id); 

          if (shoppingListModel == null) return NotFound(); 

          return Ok(shoppingListModel.ToShoppingListDto()); 

        }

    }
}