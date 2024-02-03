using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.FoodItems;

public static class FoodItemExtensions
{
    public static FoodItem ToFoodItem(this FoodItemDto foodItemDto)
    {
        return new FoodItem
        {
            Id = foodItemDto.Id,
            Name = foodItemDto.Name,
            Calories = foodItemDto.Calories,
            Carbohydrates = foodItemDto.Carbohydrates,
            Fat = foodItemDto.Fat,
            Protein = foodItemDto.Protein
        };
    }

    public static FoodItemDto ToFoodItemDto(this FoodItem foodItem)
    {
        return new FoodItemDto
        {
            Id = foodItem.Id,
            Name = foodItem.Name,
            Calories = foodItem.Calories,
            Carbohydrates = foodItem.Carbohydrates,
            Fat = foodItem.Fat,
            Protein = foodItem.Protein
        };
    }
}
