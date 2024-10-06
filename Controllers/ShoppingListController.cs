using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
          var shoppingLists = _context.ShoppingLists.ToList();

          return Ok(shoppingLists); 
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
          var shoppingList = _context.ShoppingLists.Find(id);

          if (shoppingList == null) return NotFound();
          
          return Ok(shoppingList); 
        }
    
    }
}