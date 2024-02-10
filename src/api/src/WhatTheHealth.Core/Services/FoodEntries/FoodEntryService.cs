using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.FoodEntries;

public class FoodEntryService : IFoodEntryService
{
    private readonly IFoodEntryRepository _foodEntryRepository;

    public FoodEntryService(IFoodEntryRepository foodEntryRepository)
    {
        _foodEntryRepository = foodEntryRepository;
    }

    public async Task<FoodEntry> Create(FoodEntry foodEntry)
    {
        return await _foodEntryRepository.Create(foodEntry);
    }

    public async Task<FoodEntry> Edit(FoodEntry foodEntry)
    {
        return await _foodEntryRepository.Update(foodEntry);
    }

    public IEnumerable<FoodEntry> GetAllByDate(DateOnly date, string userId)
    {
        var foodEntries = _foodEntryRepository.GetAllByDate(date, userId);

        return foodEntries;
    }

    public async Task<FoodEntry> GetById(string id)
    {
        var guid = Guid.Parse(id);

        return await _foodEntryRepository.GetById(guid);
    }

    public async Task RemoveById(string id)
    {
        var guid = Guid.Parse(id);

        await _foodEntryRepository.DeleteById(guid);
    }
}
