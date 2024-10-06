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
            CreatedOn = shoppingListModel.CreatedOn 
          }; 

        }
    }
}