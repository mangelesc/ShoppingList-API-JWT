using api.Data;
using api.Interfaces;
using api.Models;
using api.Repository;
using api.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<ApplicationDBContext> (options => {
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// JWT Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options => {
  options.Password.RequireDigit = true; 
  options.Password.RequireLowercase = true; 
  options.Password.RequireUppercase = true;
  options.Password.RequireNonAlphanumeric = true;
  options.Password.RequiredLength = 12;
  
})
// Add the entity Framewor source
.AddEntityFrameworkStores<ApplicationDBContext>();

// Add scheme - JWT Identity
builder.Services.AddAuthentication(options => {
  options.DefaultAuthenticateScheme = 
  options.DefaultChallengeScheme = 
  options.DefaultForbidScheme = 
  options.DefaultScheme = 
  options.DefaultSignInScheme = 
  options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
})
// JWT validation parameters (with JWT Bearer package)
.AddJwtBearer(options => {
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuer = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"], //Make this whitini appsetting.json (Issuer-server, audience-user )
    ValidateAudience = true, 
    ValidAudience = builder.Configuration["JWT:Audience"],
    ValidateIssuerSigningKey = true, 
    IssuerSigningKey = new SymmetricSecurityKey(
      System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
    )
  };
});


// Dependency injections
builder.Services.AddScoped<IShoppingListRepository, ShoppingListRepository>(); 
builder.Services.AddScoped<IShoppingItemRepository, ShoppingItemRepository>(); 
builder.Services.AddScoped<ITokenService, TokenService>(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// JWT validation 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
