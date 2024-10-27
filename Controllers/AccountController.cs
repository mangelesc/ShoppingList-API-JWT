using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/acccount")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;



        public AccountController(UserManager<AppUser> UserManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
          _userManager = UserManager;
          _tokenService = tokenService;
          _signInManager = signInManager; 
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login (LoginDto loginDto)
        {
          try 
          {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            // Find the user
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower()); 

            if (user == null) return Unauthorized("Oops, invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded) return Unauthorized("Oops, invalid credentials"); 

            return Ok
            (
              new NewUserDto
              {
                UserName = user.UserName,
                Email = user.Email, 
                Token = _tokenService.CreateToken(user),

              }
            );

          }
          catch(Exception e) 
          {
            return StatusCode(500, e);
          }
        }


        [HttpPost("register")]
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
                return Ok(
                  new NewUserDto
                  {
                    UserName = appUser.UserName,
                    Email = appUser.Email,
                    Token = _tokenService.CreateToken(appUser)
                  }
                ); 
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