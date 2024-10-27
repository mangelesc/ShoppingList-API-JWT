using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    
    [ApiController]
    [Route("api/shoppintItem/")]
    public class EnumController: ControllerBase
    {
        [HttpGet("measurementUnit")]
        
        public IActionResult GetUnits()
        {
            var enumValues = Enum.GetValues(typeof(Unit))
                                .Cast<Unit>()
                                .Select(u => new { Id = (int)u, Name = u.ToString() })
                                .ToList();

            return Ok(enumValues);
        }

        [HttpGet("foodTypes")]
        public IActionResult GetFoodTypes()
        {
            var enumValues = Enum.GetValues(typeof(FoodType))
                                .Cast<FoodType>()
                                .Select(ft => new { Id = (int)ft, Name = ft.ToString() })
                                .ToList();

            return Ok(enumValues);
        }
        }
}