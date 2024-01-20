using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.FoodItems;

public class FoodItemService : IFoodItemService
{
    private readonly IFoodItemRepository _foodItemRepository;

    public FoodItemService(IFoodItemRepository foodItemRepository)
    {
        _foodItemRepository = foodItemRepository;
    }

    public async Task<FoodItem> Create(FoodItem foodItem)
    {
        return await _foodItemRepository.Create(foodItem);
    }

    public async Task<FoodItem> Edit(FoodItem foodItem)
    {
        return await _foodItemRepository.Update(foodItem);
    }

    public IEnumerable<FoodItem> GetAll()
    {
        return _foodItemRepository.GetAll();
    }

    public async Task<FoodItem> GetById(string id)
    {
        var guid = Guid.Parse(id);

        return await _foodItemRepository.GetById(guid);
    }

    public async Task Remove(FoodItem foodItem)
    {
        await _foodItemRepository.Delete(foodItem);
    }

    public async Task RemoveById(string id)
    {
        var guid = Guid.Parse(id);

        await _foodItemRepository.DeleteById(guid);
    }
}
