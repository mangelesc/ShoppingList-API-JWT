using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Service
{
  
  public class TokenService : ITokenService
  {

    private readonly IConfiguration _config; 
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config)
    {
      _config = config;
      // SymmetricSecurityKey - to encrypt the token in an unique way that it's only specific to our server
      _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));  
    }

    public string CreateToken(AppUser user)
    {
      // Claims
      var claims = new List<Claim>
      {
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
      };

     // Credentials
      var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); //Way of encrytion

      // Object representation of a token 
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(7), 
        SigningCredentials = creds,
        Issuer = _config["JWT:Issuer"],
        Audience = _config["JWT:Audience"]
      };

      var tokenHandler = new JwtSecurityTokenHandler(); 

      var token = tokenHandler.CreateToken(tokenDescriptor); 

      // return the token in the form of a string 
      return tokenHandler.WriteToken(token); 

    }
  }
}