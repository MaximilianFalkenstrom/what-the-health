using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.FoodEntries;

public interface IFoodEntryService
{
    Task<FoodEntry> Create(FoodEntry foodEntry);

    IEnumerable<FoodEntry> GetAll();

    Task<FoodEntry> GetById(string id);

    Task<FoodEntry> Edit(FoodEntry foodEntry);

    Task RemoveById(string id);
}
