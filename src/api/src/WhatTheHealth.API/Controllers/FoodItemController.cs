using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatTheHealth.Core.Services.FoodItems;
using WhatTheHealth.Domain.Entities;

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
    public async Task<ActionResult<FoodItemDto>> CreateAsync(FoodItemDto foodItem)
    {
        return await _foodItemService.Create(foodItem);
    }

    [HttpGet]
    public IEnumerable<FoodItemDto> GetAll()
    {
        return _foodItemService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<FoodItemDto> GetById([FromRoute] string id)
    {
        return await _foodItemService.GetById(id);
    }

    [HttpPatch]
    public async Task<FoodItemDto> Update([FromBody] FoodItemDto foodItem)
    {
        return await _foodItemService.Edit(foodItem);
    }

    [HttpDelete]
    public async Task Delete([FromBody] FoodItemDto foodItem)
    {
        await _foodItemService.Remove(foodItem);
    }

    [HttpDelete("{id}")]
    public async Task DeleteById([FromRoute] string id)
    {
        await _foodItemService.RemoveById(id);
    }
}
