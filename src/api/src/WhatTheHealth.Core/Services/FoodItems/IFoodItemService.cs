namespace WhatTheHealth.Core.Services.FoodItems;

public interface IFoodItemService
{
    Task<FoodItemDto> Create(FoodItemDto foodItemDto);

    IEnumerable<FoodItemDto> GetAll();

    Task<FoodItemDto> GetById(string id);

    Task<FoodItemDto> Edit(FoodItemDto foodItemDto);

    Task Remove(FoodItemDto foodItemDto);

    Task RemoveById(string id);
}
