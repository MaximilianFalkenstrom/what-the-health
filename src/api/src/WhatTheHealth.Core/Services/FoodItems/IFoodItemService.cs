using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.FoodItems;

public interface IFoodItemService
{
    Task<FoodItem> Create(FoodItem foodItem);

    IEnumerable<FoodItem> GetAll();

    Task<FoodItem> GetById(string id);

    Task<FoodItem> Edit(FoodItem foodItem);

    Task Remove(FoodItem item);

    Task RemoveById(string id);
}
