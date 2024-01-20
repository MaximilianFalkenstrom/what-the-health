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
    public async Task<ActionResult<FoodItem>> CreateAsync(FoodItem foodItem)
    {
        return await _foodItemService.Create(foodItem);
    }

    [HttpGet]
    public IEnumerable<FoodItem> GetAll()
    {
        return _foodItemService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<FoodItem> GetById([FromRoute] string id)
    {
        return await _foodItemService.GetById(id);
    }

    [HttpPatch]
    public async Task<FoodItem> Update([FromBody]FoodItem foodItem)
    {
        return await _foodItemService.Edit(foodItem);
    }

    [HttpDelete]
    public async Task Delete([FromBody]FoodItem foodItem)
    {
        await _foodItemService.Remove(foodItem);
    }

    [HttpDelete("{id}")]
    public async Task DeleteById([FromRoute] string id)
    {
        await _foodItemService.RemoveById(id);
    }
}
