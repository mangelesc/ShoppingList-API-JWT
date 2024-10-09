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
        public ShoppingItemController(IShoppingItemRepository shoppingItemRepository)
        {
          _shoppingItemRepository = shoppingItemRepository; 
        }

        [HttpGet]
        // public IActionResult GetAll()
        public async Task<IActionResult> GetAll()
        {
          // var shoppingItems = _context.ShoppingItems.ToItem()
          var shoppingItems = await _shoppingItemRepository.GetAllAsync();

          var shoppingItemDto = shoppingItems.Select(s => s.ToShoppingItemDto());

          return Ok(shoppingItemDto); 
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
          var shoppingItem = await _shoppingItemRepository.GetByIdAsync(id);

          if (shoppingItem == null) return NotFound();
          
          return Ok(shoppingItem.ToShoppingItemDto()); 
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShoppingItemRequestDto ShoppingItemDto){

          var shoppingItemModel = ShoppingItemDto.ToShoppingItemFromCreateDto(); 

          await _shoppingItemRepository.CreateAsync(shoppingItemModel);

          return CreatedAtAction(nameof(GetById), new { id = shoppingItemModel.Id }, shoppingItemModel.ToShoppingItemDto()); 

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateShoppingItemRequestDto shoppingItemDto){

          var shoppingItemModel = await _shoppingItemRepository.UpdateAsync(id, shoppingItemDto); 

          if (shoppingItemModel == null) return NotFound(); 

          return Ok(shoppingItemModel.ToShoppingItemDto()); 

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete ([FromRoute] int id){

          var shoppingItemModel = await _shoppingItemRepository.DeleteAsync(id); 

          if (shoppingItemModel == null) return NotFound(); 

          return Ok(shoppingItemModel.ToShoppingItemDto()); 

        }

    }
}