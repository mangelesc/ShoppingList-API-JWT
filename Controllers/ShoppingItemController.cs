using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ShoppingItem;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/shoppingItem")]
    [ApiController]
    public class ShoppingItemController : ControllerBase
    {
        private readonly IShoppingItemRepository _shoppingItemRepository;
        private readonly IShoppingListRepository _shoppingListRepository;

        public ShoppingItemController(IShoppingItemRepository shoppingItemRepository, IShoppingListRepository shoppingListRepository)
        {
          _shoppingItemRepository = shoppingItemRepository; 
          _shoppingListRepository = shoppingListRepository;
        }


        [HttpGet]
        // public IActionResult GetAll()
        public async Task<IActionResult> GetAll()
        {
          if (!ModelState.IsValid) return BadRequest(ModelState);

          var shoppingItems = await _shoppingItemRepository.GetAllAsync();

          var shoppingItemDto = shoppingItems.Select(s => s.ToShoppingItemDto());

          return Ok(shoppingItemDto); 
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

          if (!ModelState.IsValid) return BadRequest(ModelState);

          var shoppingItem = await _shoppingItemRepository.GetByIdAsync(id);

          if (shoppingItem == null) return NotFound();
          
          return Ok(shoppingItem.ToShoppingItemDto()); 
        }


        [HttpPost("{listId:int}")]
        public async Task<IActionResult> Create([FromRoute] int listId, [FromBody] CreateShoppingItemRequestDto ShoppingItemDto){

          if (!ModelState.IsValid) return BadRequest(ModelState);

          if (!await _shoppingListRepository.ShoppingListExists(listId)) return BadRequest("Shopping List does not exist");
          
          var shoppingItemModel = ShoppingItemDto.ToShoppingItemFromCreateDto(listId); 

          await _shoppingItemRepository.CreateAsync(shoppingItemModel);

          return CreatedAtAction(nameof(GetById), new { id = shoppingItemModel.Id }, shoppingItemModel.ToShoppingItemDto()); 

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShoppingItemRequestDto shoppingItemDto){

          if (!ModelState.IsValid) return BadRequest(ModelState);

          var shoppingItemModel = await _shoppingItemRepository.UpdateAsync(id, shoppingItemDto); 

          if (shoppingItemModel == null) return NotFound("Shopping Item not found"); 

          return Ok(shoppingItemModel.ToShoppingItemDto()); 

        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete ([FromRoute] int id){

          if (!ModelState.IsValid) return BadRequest(ModelState);

          var shoppingItemModel = await _shoppingItemRepository.DeleteAsync(id); 

          if (shoppingItemModel == null) return NotFound(); 

          return Ok(shoppingItemModel.ToShoppingItemDto()); 

        }

    }
}