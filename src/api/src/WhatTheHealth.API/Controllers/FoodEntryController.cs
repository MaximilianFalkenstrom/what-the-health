using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhatTheHealth.API.Authorization.Constants;
using WhatTheHealth.API.Dtos;
using WhatTheHealth.API.Dtos.Extensions;
using WhatTheHealth.Core.Services.FoodEntries;

namespace WhatTheHealth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FoodEntryController : ControllerBase
{
    private readonly IFoodEntryService _foodEntryService;

    public FoodEntryController(IFoodEntryService foodEntryService)
    {
        _foodEntryService = foodEntryService;
    }

    [HttpPost]
    public async Task<ActionResult<FoodEntryDto>> CreateAsync(FoodEntryDto foodEntryDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var foodEntry = foodEntryDto.ToFoodEntry(userId);

        var createdFoodEntry = await _foodEntryService.Create(foodEntry);

        return createdFoodEntry.ToFoodEntryDto();
    }

    [HttpGet("date/{date}")]
    public IEnumerable<FoodEntryDto> GetAllByDate([FromRoute] DateOnly date)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var foodEntries = _foodEntryService.GetAllByDate(date, userId);

        return foodEntries.Select(foodEntry => foodEntry.ToFoodEntryDto());
    }

    [Authorize(Policy = Policies.UserOwnsFoodEntry)]
    [HttpGet("{foodEntryId}")]
    public async Task<FoodEntryDto> GetById([FromRoute] string foodEntryId)
    {
        var foodEntry = await _foodEntryService.GetById(foodEntryId);

        return foodEntry.ToFoodEntryDto();
    }

    [Authorize(Policy = Policies.UserOwnsFoodEntry)]
    [HttpPatch("{foodEntryId}")]
    public async Task<ActionResult<FoodEntryDto>> Update([FromRoute] string foodEntryId, [FromBody] FoodEntryDto foodEntryDto)
    {
        if (foodEntryId != foodEntryDto.Id.ToString())
        {
            return BadRequest();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var foodEntry = foodEntryDto.ToFoodEntry(userId);

        var updatedFoodEntry = await _foodEntryService.Edit(foodEntry);

        return updatedFoodEntry.ToFoodEntryDto();
    }

    [Authorize(Policy = Policies.UserOwnsFoodEntry)]
    [HttpDelete("{foodEntryId}")]
    public async Task<ActionResult> DeleteById([FromRoute] string foodEntryId)
    {
        await _foodEntryService.RemoveById(foodEntryId);

        return Ok();
    }
}
