using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ShoppingList;
using api.Models;

namespace api.Mappers
{
    public static class ShoppingListMappers
    {
        public static ShoppingListDto ToShoppingListDto(this ShoppingList shoppingListModel) {

          return new ShoppingListDto 
          {
            Id = shoppingListModel.Id , 
            Name = shoppingListModel.Name ,   
            IsPurchased = shoppingListModel.IsPurchased , 
            CreatedOn = shoppingListModel.CreatedOn, 
            Items = shoppingListModel.Items.Select(i => i.ToShoppingItemDto()).ToList()
          }; 

        }


        public static ShoppingList ToShoppingListFromCreateDto(this CreateShoppingListRequestDto createShoppingListDto) {

          return new ShoppingList 
          {
            Name = createShoppingListDto.Name ,   
            IsPurchased = createShoppingListDto.IsPurchased , 
            // CreatedOn = createShoppingListDto.CreatedOn 
          }; 

        }
    }
}