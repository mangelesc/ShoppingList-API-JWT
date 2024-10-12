using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ShoppingItem;
using api.Models;

namespace api.Mappers
{
    public static class ShoppingItemMapper
    {
        public static ShoppingItemDto ToShoppingItemDto(this ShoppingItem ShoppingItemModel) {

          return new ShoppingItemDto 
          {
            Id = ShoppingItemModel.Id , 
            Name = ShoppingItemModel.Name ,   
            Quantity = ShoppingItemModel.Quantity , 
            MeasurementUnit = ShoppingItemModel.MeasurementUnit , 
            IsPurchased = ShoppingItemModel.IsPurchased , 
            FoodType = ShoppingItemModel.FoodType , 
            ShoppingListId = ShoppingItemModel.ShoppingListId , 
          }; 

        }


        public static ShoppingItem ToShoppingItemFromCreateDto(this CreateShoppingItemRequestDto createShoppingItemDto, int shoppingListId) {

          return new ShoppingItem 
          {
            Name = createShoppingItemDto.Name ,   
            Quantity = createShoppingItemDto.Quantity , 
            MeasurementUnit = createShoppingItemDto.MeasurementUnit , 
            IsPurchased = createShoppingItemDto.IsPurchased , 
            FoodType = createShoppingItemDto.FoodType , 
            ShoppingListId = shoppingListId ,
          }; 

        }

        public static ShoppingItem ToShoppingItemFromUpdateDto(this UpdateShoppingItemRequestDto updateShoppingItemDto) {

          return new ShoppingItem 
          {
            Name = updateShoppingItemDto.Name ,   
            Quantity = updateShoppingItemDto.Quantity , 
            MeasurementUnit = updateShoppingItemDto.MeasurementUnit , 
            IsPurchased = updateShoppingItemDto.IsPurchased , 
            FoodType = updateShoppingItemDto.FoodType , 
            // ShoppingListId = shoppingListId ,
          }; 

        }
    }
}