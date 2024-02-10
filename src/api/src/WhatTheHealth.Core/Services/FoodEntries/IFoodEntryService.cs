using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.FoodEntries;

public interface IFoodEntryService
{
    Task<FoodEntry> Create(FoodEntry foodEntry);

    IEnumerable<FoodEntry> GetAllByDate(DateOnly date, string userId);

    Task<FoodEntry> GetById(string id);

    Task<FoodEntry> Edit(FoodEntry foodEntry);

    Task RemoveById(string id);
}
