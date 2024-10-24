using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/acccount")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> UserManager)
        {
          _userManager = UserManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto) 
        {
          try 
          {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var appUser = new AppUser
            {
              UserName = registerDto.UserName,
              Email = registerDto.Email
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

            if(createdUser.Succeeded)
            {
              var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

              if(roleResult.Succeeded)
              {
                return Ok("User created"); 
              } 
              
              else 
              {
                return StatusCode(500, roleResult.Errors);
              }
            }

            else{
              return StatusCode(500, createdUser.Errors);
            }
          } 
          
          catch(Exception e) 
          {
            return StatusCode(500, e);
          }
        }

    }
}