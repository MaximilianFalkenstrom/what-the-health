using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatTheHealth.API.Dtos;
using WhatTheHealth.Core.Services.MealTypes;
using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MealTypeController : ControllerBase
{
    private readonly IMealTypeService _mealTypeService;

    public MealTypeController(IMealTypeService mealTypeService)
    {
        _mealTypeService = mealTypeService;
    }

    [HttpPost]
    public async Task<ActionResult<MealType>> CreateAsync(MealType mealType)
    {

        var createdFoodEntry = await _mealTypeService.Create(mealType);

        return createdFoodEntry;
    }

    [HttpGet]
    public IEnumerable<MealType> GetAll()
    {
        var mealTypes = _mealTypeService.GetAll();

        return mealTypes.Select(mealType => mealType);
    }

    [HttpGet("{mealTypeId}")]
    public async Task<MealType> GetById([FromRoute] string mealTypeId)
    {
        var foodEntry = await _mealTypeService.GetById(mealTypeId);

        return foodEntry;
    }

    [HttpPatch("{mealTypeId}")]
    public async Task<ActionResult<MealType>> Update([FromRoute] string mealTypeId, [FromBody] MealType mealType)
    {
        if (mealTypeId != mealType.Id.ToString())
        {
            return BadRequest();
        }

        var updatedMealType = await _mealTypeService.Edit(mealType);

        return updatedMealType;
    }

    [HttpDelete("{mealTypeId}")]
    public async Task<ActionResult> DeleteById([FromRoute] string mealTypeId)
    {
        await _mealTypeService.RemoveById(mealTypeId);

        return Ok();
    }
}
