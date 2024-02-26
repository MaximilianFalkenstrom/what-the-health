using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Dtos.Extensions;

public static class FoodEntryExtensions
{
    public static FoodEntry ToFoodEntry(this FoodEntryDto foodEntryDto, string userId)
    {
        return new FoodEntry
        {
            Id = foodEntryDto.Id,
            UserId = userId,
            Amount = foodEntryDto.Amount,
            Date = foodEntryDto.Date,
            FoodItemId = foodEntryDto.FoodItemId,
            FoodItem = foodEntryDto.FoodItem,
            MealTypeId = foodEntryDto.MealTypeId,
            MealType = foodEntryDto.MealType,
        };
    }

    public static FoodEntryDto ToFoodEntryDto(this FoodEntry foodEntry)
    {
        return new FoodEntryDto
        {
            Id = foodEntry.Id,
            Amount = foodEntry.Amount,
            Date = foodEntry.Date,
            FoodItemId = foodEntry.FoodItemId,
            FoodItem = foodEntry.FoodItem,
            MealTypeId = foodEntry.MealTypeId,
            MealType = foodEntry.MealType,
        };
    }
}
