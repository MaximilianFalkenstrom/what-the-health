using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhatTheHealth.API.Dtos;
using WhatTheHealth.API.Dtos.Extensions;
using WhatTheHealth.Core.Services.Workouts;

namespace WhatTheHealth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    [HttpPost]
    public async Task<ActionResult<WorkoutDto>> CreateAsync(WorkoutDto workoutDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var workout = workoutDto.ToWorkout(userId);

        var createdWorkout = await _workoutService.Create(workout);

        return createdWorkout.ToWorkoutDto();
    }

    [HttpGet]
    public IEnumerable<WorkoutDto> GetAll()
    {
        var workouts = _workoutService.GetAll();

        return workouts.Select(workout => workout.ToWorkoutDto());
    }

    // [Authorize(Policy = Policies.UserOwnsWorkout)] // Is Admin
    [HttpGet("{workoutId}")]
    public async Task<WorkoutDto> GetById([FromRoute] string workoutId)
    {
        var workout = await _workoutService.GetById(workoutId);

        return workout.ToWorkoutDto();
    }

    // [Authorize(Policy = Policies.UserOwnsWorkout)] // Is Admin
    [HttpPatch("{workoutId}")]
    public async Task<ActionResult<WorkoutDto>> Update([FromRoute] string workoutId, [FromBody] WorkoutDto workoutDto)
    {
        if (workoutId != workoutDto.Id.ToString())
        {
            return BadRequest();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var workout = workoutDto.ToWorkout(userId);

        var updatedWorkout = await _workoutService.Edit(workout);

        return updatedWorkout.ToWorkoutDto();
    }

    // [Authorize(Policy = Policies.UserOwnsWorkout)] // Is Admin
    [HttpDelete("{workoutId}")]
    public async Task<ActionResult> DeleteById([FromRoute] string workoutId)
    {
        await _workoutService.RemoveById(workoutId);

        return Ok();
    }
}
