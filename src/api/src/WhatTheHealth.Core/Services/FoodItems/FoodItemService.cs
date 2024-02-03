namespace WhatTheHealth.Core.Services.FoodItems;

public class FoodItemService : IFoodItemService
{
    private readonly IFoodItemRepository _foodItemRepository;

    public FoodItemService(IFoodItemRepository foodItemRepository)
    {
        _foodItemRepository = foodItemRepository;
    }

    public async Task<FoodItemDto> Create(FoodItemDto foodItemDto)
    {
        var foodItem = foodItemDto.ToFoodItem();

        var updatedFoodItem = await _foodItemRepository.Create(foodItem);

        return updatedFoodItem.ToFoodItemDto();
    }

    public async Task<FoodItemDto> Edit(FoodItemDto foodItemDto)
    {
        var foodItem = foodItemDto.ToFoodItem();

        var updatedFoodItem = await _foodItemRepository.Update(foodItem);

        return updatedFoodItem.ToFoodItemDto();
    }

    public IEnumerable<FoodItemDto> GetAll()
    {
        var foodItems = _foodItemRepository.GetAll();

        return foodItems.Select(foodItem => foodItem.ToFoodItemDto());
    }

    public async Task<FoodItemDto> GetById(string id)
    {
        var guid = Guid.Parse(id);

        var foodItem = await _foodItemRepository.GetById(guid);

        return foodItem.ToFoodItemDto();
    }

    public async Task Remove(FoodItemDto foodItemDto)
    {
        var foodItem = foodItemDto.ToFoodItem();

        await _foodItemRepository.Delete(foodItem);
    }

    public async Task RemoveById(string id)
    {
        var guid = Guid.Parse(id);

        await _foodItemRepository.DeleteById(guid);
    }
}
