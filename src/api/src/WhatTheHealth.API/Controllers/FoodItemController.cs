using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatTheHealth.API.Dtos;
using WhatTheHealth.API.Dtos.Extensions;
using WhatTheHealth.Core.Services.FoodItems;

namespace WhatTheHealth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FoodItemController : ControllerBase
{
    private readonly IFoodItemService _foodItemService;

    public FoodItemController(IFoodItemService foodItemService)
    {
        _foodItemService = foodItemService;
    }

    [HttpPost]
    public async Task<ActionResult<FoodItemDto>> CreateAsync(FoodItemDto foodItemDto)
    {
        var foodItem = foodItemDto.ToFoodItem();

        var createdFoodItem = await _foodItemService.Create(foodItem);

        return createdFoodItem.ToFoodItemDto();
    }

    [HttpGet]
    public IEnumerable<FoodItemDto> GetAll()
    {
        var foodItems = _foodItemService.GetAll();

        return foodItems.Select(foodItem => foodItem.ToFoodItemDto());
    }

    [HttpGet("{id}")]
    public async Task<FoodItemDto> GetById([FromRoute] string id)
    {
        var foodItem = await _foodItemService.GetById(id);

        return foodItem.ToFoodItemDto();
    }

    [HttpPatch]
    public async Task<FoodItemDto> Update([FromBody] FoodItemDto foodItemDto)
    {
        var foodItem = foodItemDto.ToFoodItem();

        var updatedFoodItem = await _foodItemService.Edit(foodItem);

        return updatedFoodItem.ToFoodItemDto();
    }

    [HttpDelete("{id}")]
    public async Task DeleteById([FromRoute] string id)
    {
        await _foodItemService.RemoveById(id);
    }
}
